using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KiSS4.DB.Cache
{
    /// <summary>
    /// Stores and manages translation for controls and components
    /// </summary>
    public class LOVQuery
    {
        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        /// <summary>
        /// Store the result SqlQuery of the lov-query
        /// </summary>
        private Dictionary<string, QueryHashCodeContainer> _dicLOVQuery = null;

        /// <summary>
        /// Lock-object for multithreading safety
        /// </summary>
        private object _lock = null;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Create new instance of <see cref="LOVQuery"/>
        /// </summary>
        public LOVQuery()
        {
            // create new lock-object
            this._lock = new object();

            // create new dictionaries
            this._dicLOVQuery = new Dictionary<string, QueryHashCodeContainer>();
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
                _dicLOVQuery.Clear();
            }
        }

        /// <summary>
        /// Get the cached SqlQuery of the lov depending on given parameters
        /// </summary>
        /// <param name="sqlCode">The specific sql code used to get data from database</param>
        /// <param name="lovName">The name of the lov</param>
        /// <param name="languageCode">The language code to use for entry</param>
        /// <param name="allowNull">Flag if an empty entry at the beginning of the list is allowed</param>
        /// <param name="withRowFilter">Flag if this query is going to be filtered with a RowFilter</param>
        /// <returns>The SqlQuery containing the translation</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if parameter are invalid</exception>
        public SqlQuery GetLOVQuery(string sqlCode, string lovName, int languageCode, bool allowNull, bool withRowFilter)
        {
            // validate
            if (string.IsNullOrEmpty(sqlCode))
            {
                throw new ArgumentOutOfRangeException("sqlCode", "Invalid sql statement received, cannot get lov query.");
            }

            if (string.IsNullOrEmpty(lovName))
            {
                throw new ArgumentOutOfRangeException("lovName", "Invalid lov name received, cannot get lov query.");
            }

            // allow only one thread for following section
            lock (_lock)
            {
                // define key
                string key = CreateDictionaryKey(sqlCode, lovName, languageCode, allowNull, withRowFilter);

                // check if desired value already exists in dictionary
                if (_dicLOVQuery.ContainsKey(key))
                {
                    // key already exists in dictionary, validate cached content
                    if (_dicLOVQuery[key] == null || _dicLOVQuery[key].SqlQuery == null || string.IsNullOrEmpty(_dicLOVQuery[key].HashCode))
                    {
                        // logging
                        _logger.InfoFormat("No or invalid instance in lov-cache for given lov='{0}', languagecode='{1}' and allownull='{2}'", lovName, languageCode, allowNull);

                        // remove entry from dictionary (to recache instance)
                        _dicLOVQuery.Remove(key);
                    }
                    else if (CacheUtils.HasQueryChanged(_dicLOVQuery[key].SqlQuery, _dicLOVQuery[key].HashCode))
                    {
                        // logging
                        _logger.InfoFormat("Cached query has changed, hash code does not match for given lov='{0}', languagecode='{1}' and allownull='{2}'", lovName, languageCode, allowNull);

                        // remove entry from dictionary (to recache instance)
                        _dicLOVQuery.Remove(key);
                    }
                    else
                    {
                        // return data from dictionary
                        return _dicLOVQuery[key].SqlQuery;
                    }
                }

                // key does not yet exist, we try to create a new SqlQuery containing the lov data
                SqlQuery qry = GetLOVFromDatabase(sqlCode, lovName, languageCode, allowNull);

                // SqlQuery successfully executed on database, apply to dictionary including validation hash code
                _dicLOVQuery.Add(key, new QueryHashCodeContainer(qry, CacheUtils.GetMD5Hash(qry)));

                // return SqlQuery
                return qry;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create identifying key for class in dictionary
        /// </summary>
        /// <param name="sqlCode">The specific sql code used to get data from database</param>
        /// <param name="lovName">The name of the lov</param>
        /// <param name="languageCode">The language code to use for entry</param>
        /// <param name="allowNull">Flag if an empty entry at the beginning of the list is allowed</param>
        /// <param name="withRowFilter">Flag if this query is going to be filtered with a RowFilter</param>
        /// <returns>Key used in dictionary to identify entry</returns>
        private string CreateDictionaryKey(string sqlCode, string lovName, int languageCode, bool allowNull, bool withRowFilter)
        {
            // combine values to unique identifying key
            return string.Format("{0}##{1}##{2}##{3}###{4}", lovName, languageCode, allowNull, withRowFilter, CacheUtils.CreateMD5Hash(sqlCode));
        }

        /// <summary>
        /// Get SqlQuery containing the lov data
        /// </summary>
        /// <param name="sqlCode">The specific sql code used to get data from database</param>
        /// <param name="lovName">The name of the lov</param>
        /// <param name="languageCode">The language code to use for entry</param>
        /// <param name="allowNull">Flag if an empty entry at the beginning of the list is allowed</param>
        /// <returns>The SqlQuery containing all the translation for given class</returns>
        private SqlQuery GetLOVFromDatabase(string sqlCode, string lovName, int languageCode, bool allowNull)
        {
            // get lov data from database
            SqlQuery qry = DBUtil.OpenSQL(sqlCode, lovName, languageCode);

            // check if need to add a new row to query
            if (allowNull)
            {
                DataRow newRow = qry.DataTable.NewRow();

                newRow["Text"] = string.Empty;
                newRow["SortKey"] = -1;
                qry.DataTable.Rows.InsertAt(newRow, 0);

                newRow.AcceptChanges();
            }

            // return query
            return qry;
        }

        #endregion

        #endregion
    }
}