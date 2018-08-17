using System;
using System.Collections.Generic;
using System.Linq;

namespace Kiss.BL.Cache
{
    /// <summary>
    /// Manages caching for XConfig values
    /// </summary>
    public sealed class CacheManager
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// Singleton instance
        /// </summary>
        private static readonly CacheManager _instance = new CacheManager();

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Dictionary with the cached config items
        /// </summary>
        private readonly IDictionary<string, List<ConfigCacheItem>> _mapXConfigItems;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private CacheManager()
        {
            _mapXConfigItems = new Dictionary<string, List<ConfigCacheItem>>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Singleton Property.
        /// </summary>
        public static CacheManager Instance
        {
            get { return _instance; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Clears the cache
        /// </summary>
        public void ClearCache()
        {
            _mapXConfigItems.Clear();
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Get config value by key path
        /// </summary>
        /// <param name="keyPath">Key path of the config value</param>
        /// <param name="date">Date for quering DatumVon and DatumBis</param>
        /// <returns>ConfigCacheItem</returns>
        internal ConfigCacheItem GetConfigValue(string keyPath, DateTime? date = null)
        {
            // if date is null, then we assign date now, because we don't want any configs valid in the future.
            DateTime filterDate = date.HasValue ? date.Value : DateTime.Now;
            List<ConfigCacheItem> configKeyItems;
            if (_mapXConfigItems.TryGetValue(keyPath, out configKeyItems))
            {
                var query = from c in configKeyItems
                            where c.DatumBis >= filterDate && c.DatumVon <= filterDate
                            orderby c.DatumVon, c.DatumBis
                            select c;
                ConfigCacheItem item = query.FirstOrDefault();
                if (item != null)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Get map with config items
        /// Configs are returned, which the KeyPath match the rootKeyPath
        /// </summary>
        /// <param name="rootKeyPath">Filter criteria, all configs KeyPath must start with rootKeyPath</param>
        /// <param name="date">Filter for DatumVon, DatumBis</param>
        /// <returns>Filtered map with ConfigCacheItem</returns>
        internal IList<ConfigCacheItem> GetConfigValueByRootpath(string rootKeyPath, DateTime? date)
        {
            // if date is null, then we assign date now, because we don't want any configs valid in the future.
            DateTime filterDate = date.HasValue ? date.Value : DateTime.Now;
            var queryConfigKeyStartWith = from c in _mapXConfigItems
                                          where c.Key.StartsWith(rootKeyPath)
                                          select new { KeyValue = c.Key, ConfigList = c.Value };
            IList<ConfigCacheItem> listConfigResult = new List<ConfigCacheItem>();
            foreach (var configKeyValue in queryConfigKeyStartWith)
            {
                var queryConfigDate = from i in configKeyValue.ConfigList
                                      where i.DatumVon <= filterDate && i.DatumBis >= filterDate
                                      orderby i.DatumVon descending
                                      select i;
                ConfigCacheItem item = queryConfigDate.FirstOrDefault();
                if (item != null)
                {
                    listConfigResult.Add(item);
                }
            }

            return listConfigResult;
        }

        /// <summary>
        /// Clear and set the config cache with the xConfigItems
        /// </summary>
        /// <param name="xConfigItems">New ConfigItems for saving in the cache</param>
        internal void InitializeConfigCache(IDictionary<string, List<ConfigCacheItem>> xConfigItems)
        {
            _mapXConfigItems.Clear();
            foreach (var xConfigItem in xConfigItems)
            {
                _mapXConfigItems.Add(xConfigItem.Key, xConfigItem.Value);
            }
        }

        /// <summary>
        /// Query if the cache is empty
        /// </summary>
        /// <returns>True when cache is empty, false when cache is filled</returns>
        internal bool IsCacheEmpty()
        {
            return !_mapXConfigItems.Any();
        }

        #endregion

        #endregion
    }
}