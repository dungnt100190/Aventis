using System;
using System.Collections.Generic;

namespace KiSS4.DB.Cache
{
    /// <summary>
    /// Class for storing and managing multilanguage texts and messages read from database
    /// </summary>
    public class LanguageText
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Fields

        /// <summary>
        /// Store the multilanguage messages with it's value
        /// </summary>
        private Dictionary<String, String> _dicMLMessages = null;

        /// <summary>
        /// Lock-object for multithreading safety
        /// </summary>
        private Object _lock = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Create new instance of <see cref="LanguageText"/>
        /// </summary>
        public LanguageText()
        {
            // create new lock-object
            this._lock = new Object();

            // create new hashtable
            this._dicMLMessages = new Dictionary<String, String>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Clear the cached values and allow items to be reloaded from database with next access
        /// </summary>
        public void Clear()
        {
            // allow only one thread for following section
            lock (this._lock)
            {
                // clear all values from hashtable
                this._dicMLMessages.Clear();
            }
        }

        /// <summary>
        /// Get the multilanguage text for specific message
        /// </summary>
        /// <param name="maskName">The name of the class or control where the message belongs to</param>
        /// <param name="messageName">The unique message name within given maskName</param>
        /// <param name="defaultText">The default text to use if message is not yet in database</param>
        /// <param name="msgCode">The message code of the message, used for grouping type of messages</param>
        /// <returns>The text in given language if any found or the default value if none was found or error occured</returns>
        /// <exception cref="KissErrorException">Thrown if a transaction is actually open</exception>
        public String GetMLMessageText(String maskName, String messageName, String defaultText, KissMsgCode msgCode)
        {
            // get value with current set language
            return this.GetMLMessageText(maskName, messageName, defaultText, msgCode, Session.User.LanguageCode);
        }

        /// <summary>
        /// Get the multilanguage text for specific message
        /// </summary>
        /// <param name="maskName">The name of the class or control where the message belongs to</param>
        /// <param name="messageName">The unique message name within given maskName</param>
        /// <param name="defaultText">The default text to use if message is not yet in database</param>
        /// <param name="msgCode">The message code of the message, used for grouping type of messages</param>
        /// <param name="languageCode">The language code of given message</param>
        /// <returns>The text in given language if any found or the default value if none was found or error occured</returns>
        /// <exception cref="KissErrorException">Thrown if a transaction is actually open</exception>
        public String GetMLMessageText(String maskName, String messageName, String defaultText, KissMsgCode msgCode, Int32 languageCode)
        {
            // allow only one thread for following section
            lock (this._lock)
            {
                // define key
                String key = this.CreateHashTableKeyForMLMessageText(maskName, messageName, msgCode, languageCode);

                // check if desired value already exists in hashtable
                if (this._dicMLMessages.ContainsKey(key))
                {
                    // key already exists in hashtable, get this value
                    if (this._dicMLMessages[key] == null)
                    {
                        // no data in hashtable, return default text
                        return defaultText;
                    }

                    // return data from hashtable
                    return this._dicMLMessages[key];
                }

                // key does not yet exist, we try to get value from database
                String mlMsgText = this.GetMLMessageTextFromDB(maskName, messageName, defaultText, msgCode, languageCode);

                // value successfully read from database, apply to hashtable
                this._dicMLMessages.Add(key, mlMsgText);

                // return value found on database
                return mlMsgText;
            }
        }

        /// <summary>
        /// Remove the given key from memory to reload it the next time again from database
        /// </summary>
        /// <param name="maskName">The name of the class or control where the message belongs to</param>
        /// <param name="messageName">The unique message name within given maskName</param>
        /// <param name="defaultText">The default text to use if message is not yet in database</param>
        /// <param name="msgCode">The message code of the message, used for grouping type of messages</param>
        /// <param name="languageCode">The language code of given message</param>
        public void RemoveMLMessageTextFromMemory(String maskName, String messageName, String defaultText, KissMsgCode msgCode, Int32 languageCode)
        {
            // allow only one thread for following section
            lock (this._lock)
            {
                // define key
                String key = this.CreateHashTableKeyForMLMessageText(maskName, messageName, msgCode, languageCode);

                // check if key exists in hashtable
                if (this._dicMLMessages.ContainsKey(key))
                {
                    // remove key from hashtable
                    this._dicMLMessages.Remove(key);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create identifying key for message in hashtable
        /// </summary>
        /// <param name="maskName">The name of the class or control where the message belongs to</param>
        /// <param name="messageName">The unique message name within given maskName</param>
        /// <param name="msgCode">The message code of the message, used for grouping type of messages</param>
        /// <param name="languageCode">The language code of given message</param>
        /// <returns>Key used in hashtable to identify text</returns>
        private String CreateHashTableKeyForMLMessageText(String maskName, String messageName, KissMsgCode msgCode, Int32 languageCode)
        {
            // combine values to unique identifying key
            return String.Format("{0}##{1}##{2}##{3}", maskName, messageName, msgCode, languageCode);
        }

        /// <summary>
        /// Get the config value from database
        /// </summary>
        /// <param name="maskName">The name of the class or control where the message belongs to</param>
        /// <param name="messageName">The unique message name within given maskName</param>
        /// <param name="defaultText">The default text to use if message is not yet in database</param>
        /// <param name="msgCode">The message code of the message, used for grouping type of messages</param>
        /// <param name="languageCode">The language code of given message</param>
        /// <returns>The multilanguage message text from database or the default text if none was found</returns>
        private String GetMLMessageTextFromDB(String maskName, String messageName, String defaultText, KissMsgCode msgCode, Int32 languageCode)
        {
            try
            {
                // try to get value from database (if not yet in database, do insert immediately)
                return Convert.ToString(DBUtil.ExecuteScalarSQLThrowingException(@"
                        EXECUTE dbo.spXSetMsgBox 1, {2}, {0}, {1}, {3}

                        SELECT Message = dbo.fnGetMLText(MSG.MessageTID, {4})
                        FROM dbo.XMessage MSG WITH (READUNCOMMITTED)
                        WHERE MSG.MaskName = CONVERT(VARCHAR(100), {0}) AND
                              MSG.MessageName = CONVERT(VARCHAR(100), {1})", maskName, messageName, defaultText, msgCode, languageCode));
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                // stop if debugging due to unexpected error
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    // stop here
                    System.Diagnostics.Debugger.Break();
                }

                // in case of error, return default text
                return defaultText;
            }
        }

        #endregion
    }
}