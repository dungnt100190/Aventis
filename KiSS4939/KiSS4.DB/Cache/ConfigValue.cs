using System;
using System.Collections;

namespace KiSS4.DB.Cache
{
    /// <summary>
    /// Class for storing and managing config values read from database
    /// </summary>
    public class ConfigValue
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Store the config key with it's value
        /// </summary>
        private readonly Hashtable _htConfigKeyWithValue;

        /// <summary>
        /// Lock-object for multithreading safety
        /// </summary>
        private readonly object _lock;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Create new instance of <see cref="ConfigValue"/>
        /// </summary>
        public ConfigValue()
        {
            _lock = new object();
            _htConfigKeyWithValue = new Hashtable();
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
                _htConfigKeyWithValue.Clear();
            }
        }

        /// <summary>
        /// Get the config value for given key
        /// </summary>
        /// <param name="keyPath">The key-path for the value</param>
        /// <param name="defaultValue">The default value if none was found</param>
        /// <param name="datumVon">The starting date for reading config value if multiple values are defined</param>
        /// <returns>The config value if any found or the default value if none was found or error occured</returns>
        /// <exception cref="KissErrorException">Thrown if a transaction is actually open</exception>
        public Object GetConfigValue(string keyPath, object defaultValue, DateTime datumVon)
        {
            return GetConfigValue(keyPath, defaultValue, datumVon, true);
        }

        /// <summary>
        /// Get the config value for given key
        /// </summary>
        /// <param name="keyPath">The key-path for the value</param>
        /// <param name="defaultValue">The default value if none was found</param>
        /// <param name="datumVon">The starting date for reading config value if multiple values are defined</param>
        /// <param name="useCache">If a cached value is present, use it.</param>
        /// <returns>The config value if any found or the default value if none was found or error occured</returns>
        /// <exception cref="KissErrorException">Thrown if a transaction is actually open</exception>
        public object GetConfigValue(string keyPath, object defaultValue, DateTime datumVon, bool useCache)
        {
            lock (_lock)
            {
                if (useCache && _htConfigKeyWithValue.ContainsKey(keyPath))
                {
                    if (_htConfigKeyWithValue[keyPath] == null)
                    {
                        return defaultValue;
                    }

                    return _htConfigKeyWithValue[keyPath];
                }

                bool noDataFound;

                // key does not yet exist, we try to get value from database
                object dbConfigValue = GetConfigValueFromDB(keyPath, datumVon, out noDataFound);

                if (dbConfigValue == null)
                {
                    // depending on flag, we store value in hashtable
                    if (noDataFound && useCache)
                    {
                        // value successfully read from database but no data found, apply to hashtable
                        _htConfigKeyWithValue.Add(keyPath, null);
                    }

                    return defaultValue;
                }

                if (useCache)
                {
                    // value successfully read from database, apply to hashtable
                    _htConfigKeyWithValue.Add(keyPath, dbConfigValue);
                }

                // return value found on database
                return dbConfigValue;
            }
        }

        /// <summary>
        /// Remove the given key from memory to reload it the next time again from database
        /// </summary>
        /// <param name="keyPath">The key-path for the value to remove from memory</param>
        public void RemoveKeyFromMemory(string keyPath)
        {
            lock (_lock)
            {
                if (_htConfigKeyWithValue.ContainsKey(keyPath))
                {
                    _htConfigKeyWithValue.Remove(keyPath);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the config value from database
        /// </summary>
        /// <param name="keyPath">The key-path for the value</param>
        /// <param name="datumVon">The starting date for reading config value if multiple values are defined</param>
        /// <param name="noDataFound">Flag if any data was found on database (false=data found, true=no data found)</param>
        /// <returns>The config value if any found</returns>
        private object GetConfigValueFromDB(string keyPath, DateTime datumVon, out bool noDataFound)
        {
            // init flag
            noDataFound = false;

            // REMEMBER: null and System.DBNull are different values
            try
            {
                // get data from database
                var qryXConfig = DBUtil.OpenSQL(@"
                    SELECT
                      ValueVar = dbo.fnXConfig({0}, {1}), -- sql_variant
                      ValueVarchar = dbo.fnXConfigVarchar({0}, {1}); -- varchar(max), da len(sql_variant)<=8000", keyPath, datumVon);

                // check if any data was found
                if (qryXConfig.Count < 1)
                {
                    // set flag
                    noDataFound = true;

                    return null;
                }

                // Varchar zurückgeben, falls gesetzt (sql_variant kann nur 8000 bytes fassen)
                if (!DBUtil.IsEmpty(qryXConfig["ValueVarchar"]))
                {
                    return qryXConfig["ValueVarchar"];
                }

                return qryXConfig["ValueVar"];
            }
            catch (Exception ex)
            {
                // 06.04.2009: Umbau Transaktionen:
                // Wenn eine Transaktion vorhanden ist, dann darf Fehler nicht hier abgehandelt werden:
                if (Session.Transaction == null)
                {
                    KissMsg.ShowError("ConfigValue", "ErrorGettingConfigFromDB", "Der Konfigurationswert konnte nicht von der Datenbank gelesen werden.", ex);
                }
                else
                {
                    throw new KissErrorException(KissMsg.GetMLMessage("ConfigValue", "ErrorGettingConfigFromDBWithErrMsg", "Der Konfigurationswert konnte nicht von der Datenbank gelesen werden.\r\n\r\nError:\r\n{0}", KissMsgCode.MsgError, ex.Message));
                }

                // done
                return null;
            }
        }

        #endregion

        #endregion
    }
}