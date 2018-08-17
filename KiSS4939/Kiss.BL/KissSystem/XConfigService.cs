using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL.Cache;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.KissSystem
{
    /// <summary>
    /// Service to manage an TEntity XConfig
    /// Config entries are cached for performance enhancement
    /// </summary>
    public class XConfigService : ServiceCRUDBase<XConfig>
    {
        #region Constructors

        protected XConfigService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Get xconfig item by xconfigid
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        /// <param name="xConfigId">Key of xconfig</param>
        /// <returns>XConfig entity</returns>
        public override XConfig GetById(IUnitOfWork unitOfWork, int xConfigId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<XConfig>(unitOfWork);
            var returnValue = repository.SingleOrDefault(xConfig => xConfig.XConfigID == xConfigId);
            if (returnValue == null)
            {
                return null;
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return returnValue;
        }

        /// <summary>
        /// Get config value filtered by keypath
        /// </summary>
        /// <typeparam name="T">The type of the property, for example string or int</typeparam>
        /// <param name="keyPath">Config key path</param>
        /// <param name="date">Date for filtering old configs. return the actual config if the date is not set</param>
        /// <returns>Config value t or default value t</returns>
        public T GetConfigValue<T>(string keyPath, DateTime? date = null)
        {
            return GetConfigValue(keyPath, date ?? DateTime.Now, default(T));
        }

        /// <summary>
        /// Get config filtered by key path
        /// </summary>
        /// <typeparam name="T">Type of the config value</typeparam>
        /// <param name="keyPath">Key path of xconfig</param>
        /// <param name="date">Date for filtering old configs</param>
        /// <param name="defaultValue">Default value of type T</param>
        /// <returns></returns>
        public T GetConfigValue<T>(string keyPath, DateTime date, T defaultValue)
        {
            var cacheItem = GetConfigFromCache(keyPath, date);
            if (cacheItem == null)
            {
                return defaultValue;
            }

            var objectValue = ConvertCacheConfigValue<T>(cacheItem);
            if (objectValue != null)
            {
                return (T)objectValue;
            }

            return defaultValue;
        }

        /// <summary>
        /// Der Wert unter keyPath enthält mehrere Werte mit Komma getrennt.
        /// Bsp: 2,4,6  -> Liste {2,4,6}
        /// </summary>
        /// <typeparam name="T">Unterstützt wird int, string, XLOVCode</typeparam>
        /// <param name="keyPath"></param>
        /// <param name="splitter">Splitter</param>
        /// <param name="date">Filter for DatumVon, DatumBis</param>
        /// <returns>Generic list of t, when config values are available. Null, when nothing is found</returns>
        public IList<T> GetConfigValueSplitted<T>(string keyPath, string splitter = ",", DateTime? date = null)
        {
            var cacheItem = GetConfigFromCache(keyPath, date);
            if (cacheItem == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(cacheItem.ValueVarchar))
            {
                return new List<T>();
            }

            var lovService = Container.Resolve<XLovService>();
            var splittedValues = cacheItem.ValueVarchar.Split(',');
            var result = new List<T>();
            var type = typeof(T);

            foreach (string stringVal in splittedValues.Where(c => !string.IsNullOrWhiteSpace(c)))
            {
                if (type == typeof(int))
                {
                    int intVal = Convert.ToInt32(stringVal);
                    var tVal = (T)Convert.ChangeType(intVal, typeof(T));
                    result.Add(tVal);
                }
                else if (type == typeof(string))
                {
                    var tVal = (T)Convert.ChangeType(stringVal, typeof(T));
                    result.Add(tVal);
                }
                else if (type == typeof(XLOVCode))
                {
                    int lovCode = Convert.ToInt32(stringVal);
                    XLOVCode code = lovService.GetLovCode(null, lovCode, cacheItem.LovName);
                    if (code != null)
                    {
                        var tVal = (T)Convert.ChangeType(code, typeof(T));
                        result.Add(tVal);
                    }
                }
                else
                {
                    throw new NotSupportedException(string.Format("Typ {0} ist nicht unterstützt. Unterstüzt wird: int, string, XLOVCode", type));
                }
            }

            return result;
        }

        /// <summary>
        /// Get all config items, which are still valid (DatumVon) filtered by a root key path.
        /// </summary>
        /// <typeparam name="T">Type of config value</typeparam>
        /// <param name="rootKeyPath">Root key path</param>
        /// <param name="date">Filter for DatumVon, DatumBis</param>
        /// <returns>Im Value ist der Konfigurationswert, im Key ist der Unterschlüssel</returns>
        public IDictionary<string, T> GetConfigValues<T>(string rootKeyPath, DateTime? date = null)
        {
            var filteredConfigs = GetConfigValueByRootpath(rootKeyPath, date);
            var keyPathValuemap = new Dictionary<string, T>();
            foreach (var configItem in filteredConfigs)
            {
                // We want also the slash after the path
                string subKeyPath = configItem.KeyPath.Substring(rootKeyPath.Length + 1);
                var objectValue = ConvertCacheConfigValue<T>(configItem);
                if (objectValue != null)
                {
                    keyPathValuemap.Add(subKeyPath, (T)objectValue);
                }
            }

            return keyPathValuemap;
        }

        public KissServiceResult SetConfigValue<T>(IUnitOfWork unitOfWork, string keyPath, T data, DateTime validFrom)
        {
            KissServiceResult result;

            validFrom = validFrom.Date;

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<XConfig>(unitOfWork);
            var existing = repository
                               .Where(x => x.KeyPath == keyPath)
                               .OrderByDescending(x => x.DatumVon)
                               .ToList()
                               .FirstOrDefault(x => x.DatumVon != null && x.DatumVon.Value.Date <= validFrom) ??
                           repository.FirstOrDefault(x => x.KeyPath == keyPath);

            XConfig dataToSave;
            bool newValue = false;

            if (existing != null && existing.DatumVon != null && existing.DatumVon.Value.Date == validFrom)
            {
                existing.StartTracking();
                SetConfigValue(existing, data);
                dataToSave = existing;
            }
            else
            {
                newValue = true;
                result = NewData(out dataToSave);

                if (!result)
                {
                    return result;
                }
            }

            dataToSave.KeyPath = keyPath;
            dataToSave.DatumVon = validFrom;
            SetConfigValue(dataToSave, data);

            if (newValue && existing != null)
            {
                dataToSave.Description = existing.Description;
                dataToSave.LOVName = existing.LOVName;
                dataToSave.System = existing.System;
                dataToSave.XNamespaceExtensionID = existing.XNamespaceExtensionID;
                dataToSave.OriginalValueBit = existing.OriginalValueBit;
                dataToSave.OriginalValueDateTime = existing.OriginalValueDateTime;
                dataToSave.OriginalValueDecimal = existing.OriginalValueDecimal;
                dataToSave.OriginalValueInt = existing.OriginalValueInt;
                dataToSave.OriginalValueMoney = existing.OriginalValueMoney;
                dataToSave.OriginalValueVarchar = existing.OriginalValueVarchar;
            }

            result = SaveData(unitOfWork, dataToSave);

            if (result)
            {
                CacheManager.Instance.ClearCache();
            }

            return result;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Convert ConfigCacheItem value into T
        /// </summary>
        /// <typeparam name="T">Value is converted to T</typeparam>
        /// <param name="cacheItem">CacheItem with the included value</param>
        /// <returns>Converted value with type T</returns>
        private static object ConvertCacheConfigValue<T>(ConfigCacheItem cacheItem)
        {
            var type = typeof(T);
            var changeType = Nullable.GetUnderlyingType(type) ?? type;

            if (type == typeof(string) && !string.IsNullOrWhiteSpace(cacheItem.ValueVarchar))
            {
                return (T)Convert.ChangeType(cacheItem.ValueVarchar, typeof(string));
            }

            if (changeType == typeof(int) && cacheItem.ValueInt.HasValue)
            {
                return (T)Convert.ChangeType(cacheItem.ValueInt, changeType);
            }

            if (changeType == typeof(decimal) && cacheItem.ValueDecimal.HasValue)
            {
                return (T)Convert.ChangeType(cacheItem.ValueDecimal, changeType);
            }

            if (changeType == typeof(bool) && cacheItem.ValueBool.HasValue)
            {
                return (T)Convert.ChangeType(cacheItem.ValueBool, changeType);
            }

            if (changeType == typeof(DateTime) && cacheItem.ValueDateTime.HasValue)
            {
                return (T)Convert.ChangeType(cacheItem.ValueDateTime, changeType);
            }

            if (type == typeof(XLOVCode) && cacheItem.ValueInt.HasValue)
            {
                var lovService = Container.Resolve<XLovService>();
                return lovService.GetLovCode(null, cacheItem.ValueInt.Value, cacheItem.LovName);
            }

            return null;
        }

        /// <summary>
        /// Convert list with ConfigCacheItem into list of XConfig 
        /// </summary>
        /// <param name="configValues">Config values which are converted</param>
        /// <returns>List with config cache items</returns>
        private static List<ConfigCacheItem> ConvertToCacheItemList(List<XConfig> configValues)
        {
            var configCacheItems = new List<ConfigCacheItem>();
            var listSearchingBisDate = configValues.ToList();
            foreach (var configValue in configValues)
            {
                var convertedConfigValue = new ConfigCacheItem
                {
                    DatumVon = configValue.DatumVon,
                    KeyPath = configValue.KeyPath,
                    ValueBool = configValue.ValueBit,
                    ValueDateTime = configValue.ValueDateTime,
                    LovName = configValue.LOVName,
                    ValueInt = configValue.ValueInt,
                    ValueVarchar = configValue.ValueVarchar,
                    ValueDecimal = configValue.ValueDecimal.HasValue
                                       ? configValue.ValueDecimal
                                       : configValue.ValueMoney
                };

                // Calculate DatumBis
                var queryBisDatum = from d in listSearchingBisDate
                                    where d.DatumVon > convertedConfigValue.DatumVon
                                    orderby d.DatumVon
                                    select d;
                var xConfig = queryBisDatum.FirstOrDefault();
                if (xConfig == null)
                {
                    convertedConfigValue.DatumBis = DateTime.MaxValue;
                }
                else if (xConfig.DatumVon.HasValue)
                {
                    convertedConfigValue.DatumBis = xConfig.DatumVon.Value.AddMilliseconds(-1);
                }

                configCacheItems.Add(convertedConfigValue);
            }

            return configCacheItems;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get config item from cach
        /// </summary>
        /// <param name="keyPath">Filter criteria key path</param>
        /// <param name="date">Filter criteria date</param>
        /// <returns>Filtered config item</returns>
        private ConfigCacheItem GetConfigFromCache(string keyPath, DateTime? date = null)
        {
            LoadConfigCache();
            return CacheManager.Instance.GetConfigValue(keyPath, date);
        }

        /// <summary>
        /// Get all values, which match the rootpath
        /// </summary>
        /// <param name="rootPath">Root path</param>
        /// <param name="date">Filter for DatumVon, DatumBis</param>
        /// <returns>Filtered config values</returns>
        private IEnumerable<ConfigCacheItem> GetConfigValueByRootpath(string rootPath, DateTime? date = null)
        {
            LoadConfigCache();
            return CacheManager.Instance.GetConfigValueByRootpath(rootPath, date);
        }

        /// <summary>
        /// When cache is empty, the cache is initialized from database
        /// </summary>
        private void LoadConfigCache()
        {
            if (!CacheManager.Instance.IsCacheEmpty())
            {
                return;
            }

            var unitOfWork = UnitOfWork.GetNew;
            var repository = UnitOfWork.GetRepository<XConfig>(unitOfWork);
            var query = from c in repository
                        group c by c.KeyPath
                            into g
                            select new { KeyPath = g.Key, ConfigValues = g };
            var listCacheItems = query.ToDictionary(configItem => configItem.KeyPath, configItem => ConvertToCacheItemList(configItem.ConfigValues.ToList()));
            CacheManager.Instance.InitializeConfigCache(listCacheItems);
        }

        /// <summary>
        /// Fills the <paramref name="value"/> into the the corresponding column based on type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        private void SetConfigValue<T>(XConfig entity, T value)
        {
            var type = typeof(T);
            if (type == typeof(string))
            {
                entity.ValueVarchar = (string)(object)value;
            }
            else if (type == typeof(int) || type == typeof(int?))
            {
                entity.ValueInt = (int)(object)value;
            }
            else if (type == typeof(decimal) || type == typeof(decimal?))
            {
                entity.ValueDecimal = (decimal)(object)value;
            }
            else if (type == typeof(bool) || type == typeof(bool?))
            {
                entity.ValueBit = (bool)(object)value;
            }
            else if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                entity.ValueDateTime = (DateTime)(object)value;
            }
            else if (typeof(T) == typeof(XLOVCode))
            {
                var lovCode = (XLOVCode)(object)value;
                entity.LOVName = lovCode.LOVName;
                entity.ValueInt = lovCode.Code;
            }
        }

        #endregion

        #endregion
    }
}