using System;
using System.Collections.Generic;

namespace KiSS4.DB.Cache
{
    /// <summary>
    /// Class for storing and managing translation for controls and components
    /// </summary>
    public class ClassTranslation
    {
        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        /// <summary>
        /// Store flag if KissTranslation filled controls and components into database
        /// </summary>
        private Dictionary<string, bool> _dicClassInsertedClassIntoDB = null;

        /// <summary>
        /// Store the result SqlQuery of the translation in dictionary
        /// </summary>
        private Dictionary<string, SqlQuery> _dicClassTranslation = null;

        /// <summary>
        /// Lock-object for multithreading safety
        /// </summary>
        private object _lock = null;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Create new instance of <see cref="ClassTranslation"/>
        /// </summary>
        public ClassTranslation()
        {
            // create new lock-object
            this._lock = new object();

            // create new dictionaries
            this._dicClassTranslation = new Dictionary<string, SqlQuery>();
            this._dicClassInsertedClassIntoDB = new Dictionary<string, bool>();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Clear the cached values and allow items to be reloaded from database with next access
        /// </summary>
        public void Clear()
        {
            // allow only one thread for following section
            lock (_lock)
            {
                // clear all values from dictionary
                _dicClassTranslation.Clear();
                _dicClassInsertedClassIntoDB.Clear();
            }
        }

        /// <summary>
        /// Get the cached SqlQuery of the class translation for given class and language
        /// </summary>
        /// <param name="typeName">The type name of the class or control</param>
        /// <param name="languageCode">The language code to use for entry</param>
        /// <returns>The SqlQuery containing the translation</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if parameter are invalid</exception>
        public SqlQuery GetTranslationQuery(string typeName, int languageCode)
        {
            // validate
            if (string.IsNullOrEmpty(typeName))
            {
                throw new ArgumentOutOfRangeException("typeName", "Invalid typename received, cannot get translation query.");
            }

            // allow only one thread for following section
            lock (_lock)
            {
                // define key
                string key = CreateDictionaryKey(typeName, languageCode);

                // check if desired value already exists in dictionary
                if (_dicClassTranslation.ContainsKey(key))
                {
                    // key already exists in dictionary, get this value
                    if (_dicClassTranslation[key] == null)
                    {
                        // logging
                        _logger.InfoFormat("No instance in translation-cache for given class='{0}' and languagecode='{1}'", typeName, languageCode);

                        // remove entry from dictionary (to recache it next time)
                        _dicClassTranslation.Remove(key);

                        // no data in dictionary, return default SqlQuery
                        return GetClassTranslation(typeName, languageCode);
                    }

                    // return data from dictionary
                    return _dicClassTranslation[key];
                }

                // key does not yet exist, we try to create a new SqlQuery containing the translation data
                SqlQuery qry = GetClassTranslation(typeName, languageCode);

                // SqlQuery successfully executed on database, apply to dictionary
                _dicClassTranslation.Add(key, qry);

                // return SqlQuery
                return qry;
            }
        }

        /// <summary>
        /// Get the flag if controls and components have already been inserted into database for given class
        /// </summary>
        /// <param name="typeFullName">The type fullname of the class or control</param>
        /// <param name="languageCode">The language code to use for entry</param>
        /// <returns>Instance of KissTranslation for given class fullname or null if invalid or not existing</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if parameter are invalid</exception>
        public bool IsClassInsertedIntoDB(string typeFullName, int languageCode)
        {
            // validate
            if (string.IsNullOrEmpty(typeFullName))
            {
                throw new ArgumentOutOfRangeException("typeFullName", "Invalid typefullname received, cannot get class flag.");
            }

            // allow only one thread for following section
            lock (_lock)
            {
                // define key
                string key = CreateDictionaryKey(typeFullName, languageCode);

                // check if desired value already exists in dictionary
                if (_dicClassInsertedClassIntoDB.ContainsKey(key))
                {
                    // key already exists in dictionary
                    return true;
                }

                // apply class to dictionary
                _dicClassInsertedClassIntoDB.Add(key, true);

                // return false, as inserting was not yet completed
                // (yes, if failure, we will have inconsistent state >> class cannot be properly translated until cache is cleared)
                return false;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create identifying key for class in dictionary
        /// </summary>
        /// <param name="typeName">The type (full)name of the class or control</param>
        /// <param name="languageCode">The language code to use for entry</param>
        /// <returns>Key used in dictionary to identify entry</returns>
        private string CreateDictionaryKey(string typeName, int languageCode)
        {
            // combine values to unique identifying key
            return string.Format("{0}##{1}", typeName, languageCode);
        }

        /// <summary>
        /// Get SqlQuery containing the translation of a whole class (control)
        /// </summary>
        /// <param name="typeName">The type name of the class or control</param>
        /// <param name="languageCode">The language code to use for entry</param>
        /// <returns>The SqlQuery containing all the translation for given class</returns>
        private SqlQuery GetClassTranslation(string typeName, int languageCode)
        {
            // get data from database
            return DBUtil.OpenSQL(@"
                DECLARE @ClassName VARCHAR(100)
                DECLARE @LanguageCode INT

                SET @ClassName = {0}
                SET @LanguageCode = {1}

                SELECT ClassName   = CTL.ClassName,
                       ControlName = CTL.ControlName,
                       Text        = ISNULL(TXT.Text, TXT_D.Text)
                FROM dbo.XClassControl     CTL   WITH (READUNCOMMITTED)
                  LEFT  JOIN dbo.XLangText TXT   WITH (READUNCOMMITTED) ON TXT.TID = CTL.ControlTID
                                                                       AND TXT.LanguageCode = @LanguageCode
                  INNER JOIN dbo.XLangText TXT_D WITH (READUNCOMMITTED) ON TXT_D.TID = CTL.ControlTID
                                                                       AND TXT_D.LanguageCode = 1
                WHERE ClassName = @ClassName

                UNION ALL

                SELECT ClassName   = CMP.ClassName,
                       ControlName = CMP.ComponentName,
                       Text        = ISNULL(TXT.Text, TXT_D.Text)
                FROM dbo.XClassComponent   CMP   WITH (READUNCOMMITTED)
                  LEFT  JOIN dbo.XLangText TXT   WITH (READUNCOMMITTED) ON TXT.TID = CMP.ComponentTID
                                                                       AND TXT.LanguageCode = @LanguageCode
                  INNER JOIN dbo.XLangText TXT_D WITH (READUNCOMMITTED) ON TXT_D.TID = CMP.ComponentTID
                                                                       AND TXT_D.LanguageCode = 1
                WHERE ClassName = @ClassName

                UNION ALL

                SELECT ClassName   = CLA.ClassName,
                       ControlName = CLA.ClassName,
                       Text        = ISNULL(TXT.Text, TXT_D.Text)
                FROM dbo.XClass            CLA   WITH (READUNCOMMITTED)
                  LEFT  JOIN dbo.XLangText TXT   WITH (READUNCOMMITTED) ON TXT.TID = CLA.ClassTID
                                                                       AND TXT.LanguageCode = @LanguageCode
                  INNER JOIN dbo.XLangText TXT_D WITH (READUNCOMMITTED) ON TXT_D.TID = CLA.ClassTID
                                                                       AND TXT_D.LanguageCode = 1
                WHERE ClassName = @ClassName", typeName, languageCode);
        }

        #endregion

        #endregion
    }
}