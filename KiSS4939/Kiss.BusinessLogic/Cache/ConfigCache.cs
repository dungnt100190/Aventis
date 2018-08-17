using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Sys.NodeEnumeration;

namespace Kiss.BusinessLogic.Cache
{
    /// <summary>
    /// Manages caching for XConfig values
    /// </summary>
    public sealed class ConfigCache
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Dictionary with the cached config items
        /// </summary>
        private readonly IDictionary<string, IList<IConfigCacheItem>> _mapXConfigItems;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        internal ConfigCache(IDictionary<string, IList<IConfigCacheItem>> configEntriesToCache)
        {
            _mapXConfigItems = configEntriesToCache;
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
        /// Query if the cache is empty
        /// </summary>
        /// <returns>True when cache is empty, false when cache is filled</returns>
        internal bool IsCacheEmpty
        {
            get { return !_mapXConfigItems.Any(); }
        }

        /// <summary>
        /// Get config value by key path
        /// </summary>
        /// <param name="configNode">Identifies the node the query, contains the default value. Use the nodes in <see cref="ConfigNodes"/></param>
        /// <param name="validAt">The DateTime the ConfigValue has to be valid at</param>
        /// <returns>The ConfigCacheItem that is valid at validAt</returns>
        internal ConfigCacheItem<T> GetConfigValue<T>(ConfigNode<T> configNode, DateTime? validAt = null)
        {
            // null means DateTime.Now
            validAt = validAt ?? DateTime.Now;
            IList<IConfigCacheItem> configKeyItems;
            if (_mapXConfigItems.TryGetValue(configNode.KeyPath, out configKeyItems))
            {
                var cacheItem = configKeyItems
                                .FirstOrDefault(cfg => cfg.DatumVon <= validAt &&
                                                       cfg.DatumBis >= validAt);

                return cacheItem as ConfigCacheItem<T>;
            }

            return null;
        }

        /// <summary>
        /// Get map with config items
        /// Configs are returned, which the KeyPath match the rootKeyPath
        /// </summary>
        /// <param name="rootKeyPath">Filter criteria, all configs KeyPath must start with rootKeyPath</param>
        /// <param name="validAt">The DateTime the ConfigValue has to be valid at</param>
        /// <returns>Filtered map with ConfigCacheItem</returns>
        internal IDictionary<string, ConfigCacheItem<T>> GetConfigValueByRootpath<T>(string rootKeyPath, DateTime? validAt = null)
        {
            // if date is null, then we assign date now, because we don't want any configs valid in the future.
            validAt = validAt ?? DateTime.Now;
            return _mapXConfigItems
                   .Where(kvp => kvp.Key.StartsWith(rootKeyPath))
                   .ToDictionary(kvp => kvp.Key,
                                 kvp => kvp.Value
                                           .Where(cfg => cfg.DatumVon <= validAt && cfg.DatumBis >= validAt)
                                           .OrderByDescending(cfg => cfg.DatumVon)
                                           .FirstOrDefault() as ConfigCacheItem<T>);
        }

        #endregion

        #endregion
    }
}