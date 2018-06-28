using System;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Model;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.Kiss4Configuration
{
    /// <summary>
    /// Service to access system configuration
    /// </summary>
    public class Kiss4Configuration : IKiss4Configuration
    {
        private readonly IQueryable<XConfig> _configs;
        private readonly IDateTimeProvider _dateTimeProvider;

        public Kiss4Configuration(IQueryable<XConfig> configs, IDateTimeProvider dateTimeProvider)
        {
            _configs = configs;
            _dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// Get config value by key path
        /// </summary>
        /// <param name="configNode">Identifies the node the query, contains the default value. Use the nodes in <see cref="ConfigNodes"/></param>
        /// <param name="validAt">The DateTime the ConfigValue has to be valid at</param>
        /// <returns>The ConfigCacheItem that is valid at validAt</returns>
        public async Task<T> GetConfigValue<T>(ConfigNode<T> configNode, DateTime? validAt = null)
        {
            // null means DateTime.Now
            validAt = validAt ?? _dateTimeProvider.Now;

            var config = await _configs.Where(cfg => cfg.KeyPath == configNode.KeyPath
                                                  && (cfg.DatumVon ?? DateTime.MinValue) <= validAt)
                                       .OrderByDescending(cfg => cfg.DatumVon ?? DateTime.MinValue)
                                       .FirstOrDefaultAsync();

            return GetValue<T>(config);
        }

        /// <summary>
        /// Converts a XConfig-Row into a ConfigCacheItem
        /// </summary>
        /// <param name="configValue">XConfig to convert</param>
        /// <returns>Converted ConfigCacheItem</returns>
        private static T GetValue<T>(XConfig configValue)
        {
            object value = null;
            switch ((ValueCode)configValue.ValueCode)
            {
                case ValueCode.Varchar:
                case ValueCode.VarcharMultiline:
                    {
                        if (configValue.ValueVarchar != null)
                        {
                            value = configValue.ValueVarchar;
                        }
                    }
                    break;

                case ValueCode.Int:
                    {
                        if (configValue.ValueInt.HasValue)
                        {
                            //if (configValue.LOVName != null)
                            //{
                            //    var lovService = Container.Resolve<XLovService>();
                            //    var lovCode = lovService.GetSingleLovCode(configValue.LOVName, configValue.ValueInt.Value);
                            //    return new ConfigCacheItem<XLOVCode>(lovCode, validFrom, validUntil);
                            //}
                            value = configValue.ValueInt.Value;
                        }
                    }
                    break;

                case ValueCode.Decimal:
                    {
                        if (configValue.ValueDecimal.HasValue)
                        {
                            value = configValue.ValueDecimal.Value;
                        }
                    }
                    break;

                case ValueCode.Money:
                    {
                        if (configValue.ValueMoney.HasValue)
                        {
                            value = configValue.ValueMoney.Value;
                        }
                    }
                    break;

                case ValueCode.Bit:
                    {
                        if (configValue.ValueBit.HasValue)
                        {
                            value = configValue.ValueBit.Value;
                        }
                    }
                    break;

                case ValueCode.DateTime:
                    {
                        if (configValue.ValueDateTime.HasValue)
                        {
                            value = configValue.ValueDateTime.Value;
                        }
                    }
                    break;

                case ValueCode.UncFile:
                case ValueCode.UncPath:
                    {
                        if (configValue.ValueVarchar != null)
                        {
                            value = new Uri(configValue.ValueVarchar);
                        }
                    }
                    break;

                    //case (ValueCode.Csv):
                    //    {
                    //        if (configValue.ValueVarchar != null)
                    //        {
                    //            if (configValue.LOVName != null)
                    //            {
                    //                var lovService = Container.Resolve<XLovService>();
                    //                var lovCodes = lovService.GetLovCodes(configValue.LOVName, configValue.ValueVarchar);
                    //                return new ConfigCacheItem<XLOVCode[]>(lovCodes, validFrom, validUntil);
                    //            }
                    //            return new ConfigCacheItem<int[]>(configValue.ValueVarchar
                    //                                                         .Split(',')
                    //                                                         .Select(int.Parse)
                    //                                                         .ToArray(),
                    //                                              validFrom, validUntil);
                    //        }
                    //    }
                    //    break;
            }
            return (T)value;
        }
    }
}