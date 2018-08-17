using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Cache;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;

namespace Kiss.BusinessLogic.Sys
{
    /// <summary>
    /// Service to access system configuration
    /// </summary>
    public class XConfigService : ServiceCRUD<XConfig>
    {
        private ConfigCache _cache;

        private XConfigService()
        {
            _cache = Container.TryResolve<ConfigCache>();

            if (_cache == null)
            {
                LoadConfigCache();
            }
        }

        /// <summary>
        /// Gets a configured value
        /// </summary>
        /// <typeparam name="T">Type of the configured value</typeparam>
        /// <param name="configNode">The config value node to be queried. Use <see cref="ConfigNodes"/></param>
        /// <param name="validAt">The DateTime the config value has to be valid at</param>
        /// <returns>The config value that is valid at validAt</returns>
        public T GetConfigValue<T>(ConfigNode<T> configNode, DateTime? validAt = null)
        {
            //LoadConfigCache();
            var cachedItem = _cache.GetConfigValue(configNode, validAt);
            if (cachedItem == null)
            {
                return configNode.DefaultValue;
            }

            return cachedItem.Value;
        }

        /// <summary>
        /// Get all config items, which are still valid (DatumVon) filtered by a root key path.
        /// </summary>
        /// <typeparam name="T">Type of config value</typeparam>
        /// <param name="rootKeyPath">Root key path</param>
        /// <param name="date">Filter for DatumVon, DatumBis</param>
        /// <returns>Im Value ist der Konfigurationswert, im Key ist der Unterschlüssel</returns>
        public IDictionary<string, T> GetConfigValues<T>(string rootKeyPath, DateTime? date = null) // ToDo: Methode unnötig machen oder ConfigNode statt string
        {
            return GetConfigValueByRootpath<T>(rootKeyPath, date)
                   .ToDictionary(cfg => cfg.Key,
                                 cfg => cfg.Value.Value);
        }

        /// <summary>
        /// Lädt alle Configwerte erneut von der Datenbank in den Cache.
        /// </summary>
        public void ReloadCache()
        {
            lock (_cache)
            {
                if (_cache != null)
                {
                    _cache.ClearCache();
                }

                LoadConfigCache();
            }
        }

        ///// <summary>
        ///// Der Wert unter keyPath enthält mehrere Werte mit Komma getrennt.
        ///// Bsp: 2,4,6  -> Liste {2,4,6}
        ///// </summary>
        ///// <typeparam name="T">Unterstützt wird int, string, XLOVCode</typeparam>
        ///// <param name="keyPath"></param>
        ///// <param name="splitter">Splitter</param>
        ///// <param name="validAt">Filter for DatumVon, DatumBis</param>
        ///// <returns>Generic list of t, when config values are available. Null, when nothing is found</returns>
        //public IList<T> GetConfigValueSplitted<T>(ConfigNode<T> keyPath, DateTime? validAt = null, char splitter = ',')
        //{
        //    LoadConfigCache();

        //    var cacheItem = _cache.GetConfigValue(keyPath, validAt);
        //    if (cacheItem == null)
        //    {
        //        return null;
        //    }
        //    var configValue = cacheItem.Value as string;
        //    if (string.IsNullOrWhiteSpace(configValue))
        //    {
        //        return new List<T>();
        //    }

        //    var lovService = Container.Resolve<XLovService>();
        //    var type = typeof(T);
        //    return configValue
        //           .Split(splitter)
        //           .Where(itm => !string.IsNullOrWhiteSpace(itm))
        //           .Select(itm =>
        //                          {
        //                              if (type == typeof(int) ||
        //                                  type == typeof(string))
        //                              {
        //                                  return (T)Convert.ChangeType(itm, typeof(T));
        //                              }
        //                              if (type == typeof(XLOVCode))
        //                              {
        //                                  var lovCode = Convert.ToInt32(itm);
        //                                  var code = lovService.GetSingleLovCode(cacheItem.LovName, lovCode);
        //                                  if (code == null)
        //                                  {
        //                                      // ToDo: Log into db (inform admin)
        //                                  }
        //                                  return (T)Convert.ChangeType(code, typeof(XLOVCode));
        //                              }
        //                              throw new NotSupportedException(string.Format("Typ {0} ist nicht unterstützt. Unterstüzt wird: int, string, XLOVCode", type));
        //                          })
        //           // ToDo: klappt das?
        //           .Where(itm => !(itm is XLOVCode) || (itm as XLOVCode) != null)  // null-items herausfiltern
        //           .ToList();
        //}

        /// <summary>
        /// Get all values, which match the rootpath
        /// </summary>
        /// <param name="rootPath">Root path</param>
        /// <param name="date">Filter for DatumVon, DatumBis</param>
        /// <returns>Filtered config values</returns>
        private IDictionary<string, ConfigCacheItem<T>> GetConfigValueByRootpath<T>(string rootPath, DateTime? date = null)
        {
            //LoadConfigCache();
            return _cache.GetConfigValueByRootpath<T>(rootPath, date);
        }

        /// <summary>
        /// Initializes cache if not yet done
        /// </summary>
        private void LoadConfigCache()
        {
            using (var uow = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                //var start = DateTime.Now;
                var entities = uow.XConfig.GetAllEntities();
                //var middle = DateTime.Now;

                var cache = ConfigCacheFactory.CreateConfigCache(entities);

                //var end = DateTime.Now;
                //var load = middle - start;
                //var duration = end - start;

                _cache = cache;
                Container.RegisterInstance(_cache);
            }
        }
    }
}