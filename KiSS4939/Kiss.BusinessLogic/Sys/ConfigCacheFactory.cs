using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Cache;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;

namespace Kiss.BusinessLogic.Sys
{
    // ToDo: Automatisch generieren lassen
    public enum ValueCode
    {
        Varchar = 1,
        Int = 2,
        Decimal = 3,
        Money = 4,
        Bit = 5,
        DateTime = 6,
        VarcharMultiline = 7,
        UncPath = 8,
        UncFile = 9,
        Xmldoc = 10,
        Csv = 11
    }

    internal static class ConfigCacheFactory
    {
        /// <summary>
        /// Clear and set the config cache with XConfig-Entries
        /// </summary>
        /// <param name="configEntriesToCache">The XConfig-Entries that have to be cached</param>
        internal static ConfigCache CreateConfigCache(IEnumerable<XConfig> configEntriesToCache)
        {
            var mapXConfigItems = configEntriesToCache
                                  .GroupBy(cfg => cfg.KeyPath, cfg => cfg)
                                  .ToDictionary(configs => configs.Key,
                                                           configs => ConvertToCacheItemList(configs.ToList()));
            return new ConfigCache(mapXConfigItems);
        }

        /// <summary>
        /// Converts a list of XConfig-Row into a list of ConfigCacheItem
        /// </summary>
        /// <param name="configValues">List of XConfig to convert</param>
        /// <returns>List of ConfigCacheItems</returns>
        private static IList<IConfigCacheItem> ConvertToCacheItemList(IEnumerable<XConfig> configValues)
        {
            var nextDatumBis = DateTime.MaxValue;
            var list = new List<IConfigCacheItem>();
            foreach (var configValue in configValues
                                        .ToList()
                                        .OrderByDescending(cfg => cfg.DatumVon ?? DateTime.MinValue))
            {
                var datumVon = configValue.DatumVon ?? DateTime.MinValue;
                var cacheItem = CreateCacheItem(configValue, datumVon, nextDatumBis);
                if (cacheItem == null)
                {
                    // invalid XConfig-entry, i.e. because there is no int-value in a int config row
                    continue;
                }
                list.Add(cacheItem);
                if (datumVon == DateTime.MinValue)
                {
                    // cancel because the first entry is reached
                    break;
                }
                nextDatumBis = datumVon.AddMilliseconds(-1);
            }
            return list;
        }

        /// <summary>
        /// Converts a XConfig-Row into a ConfigCacheItem
        /// </summary>
        /// <param name="configValue">XConfig to convert</param>
        /// <param name="validFrom">item is valid from</param>
        /// <param name="validUntil">item is valid until</param>
        /// <returns>Converted ConfigCacheItem</returns>
        private static IConfigCacheItem CreateCacheItem(XConfig configValue, DateTime validFrom, DateTime validUntil)
        {
            switch ((ValueCode)configValue.ValueCode)
            {
                case (ValueCode.Varchar):
                case (ValueCode.VarcharMultiline):
                    {
                        if (configValue.ValueVarchar != null)
                        {
                            return new ConfigCacheItem<string>(configValue.ValueVarchar, validFrom, validUntil);
                        }
                    }
                    break;

                case (ValueCode.Int):
                    {
                        if (configValue.ValueInt.HasValue)
                        {
                            if (configValue.LOVName != null)
                            {
                                var lovService = Container.Resolve<XLovService>();
                                var lovCode = lovService.GetSingleLovCode(configValue.LOVName, configValue.ValueInt.Value);
                                return new ConfigCacheItem<XLOVCode>(lovCode, validFrom, validUntil);
                            }
                            return new ConfigCacheItem<int>(configValue.ValueInt.Value, validFrom, validUntil);
                        }
                    }
                    break;

                case (ValueCode.Decimal):
                    {
                        if (configValue.ValueDecimal.HasValue)
                        {
                            return new ConfigCacheItem<decimal>(configValue.ValueDecimal.Value, validFrom, validUntil);
                        }
                    }
                    break;

                case (ValueCode.Money):
                    {
                        if (configValue.ValueMoney.HasValue)
                        {
                            return new ConfigCacheItem<decimal>(configValue.ValueMoney.Value, validFrom, validUntil);
                        }
                    }
                    break;

                case (ValueCode.Bit):
                    {
                        if (configValue.ValueBit.HasValue)
                        {
                            return new ConfigCacheItem<bool>(configValue.ValueBit.Value, validFrom, validUntil);
                        }
                    }
                    break;

                case (ValueCode.DateTime):
                    {
                        if (configValue.ValueDateTime.HasValue)
                        {
                            return new ConfigCacheItem<DateTime>(configValue.ValueDateTime.Value, validFrom, validUntil);
                        }
                    }
                    break;

                case (ValueCode.UncFile):
                case (ValueCode.UncPath):
                    {
                        if (configValue.ValueVarchar != null)
                        {
                            return new ConfigCacheItem<Uri>(new Uri(configValue.ValueVarchar), validFrom, validUntil);
                        }
                    }
                    break;

                case (ValueCode.Csv):
                    {
                        if (configValue.ValueVarchar != null)
                        {
                            if (configValue.LOVName != null)
                            {
                                var lovService = Container.Resolve<XLovService>();
                                var lovCodes = lovService.GetLovCodes(configValue.LOVName, configValue.ValueVarchar);
                                return new ConfigCacheItem<XLOVCode[]>(lovCodes, validFrom, validUntil);
                            }
                            return new ConfigCacheItem<int[]>(configValue.ValueVarchar
                                                                         .Split(',')
                                                                         .Select(int.Parse)
                                                                         .ToArray(),
                                                              validFrom, validUntil);
                        }
                    }
                    break;
            }
            return null;
        }
    }
}