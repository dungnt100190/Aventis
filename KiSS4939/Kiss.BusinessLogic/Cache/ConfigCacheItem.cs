using System;
using System.Diagnostics;

namespace Kiss.BusinessLogic.Cache
{
    /// <summary>
    /// Represents a system config value in cache
    /// </summary>
    /// <typeparam name="T">Type of config value</typeparam>
    /// <remarks>Since it is used in a dictionary, there is no need to have a property for KeyPath</remarks>
    [DebuggerDisplay("Value: {Value}, Valid: {DatumVon}-{DatumBis}, LOV: {LovName}")]
    internal class ConfigCacheItem<T> : IConfigCacheItem
    {
        /// <summary>
        /// Initializes an new instance of the ConfigCachItem class
        /// </summary>
        /// <param name="value">config value</param>
        /// <param name="datumVon">valid from</param>
        /// <param name="datumBis">valid until</param>
        /// <typeparam name="T">Type of config value</typeparam>
        public ConfigCacheItem(T value, DateTime datumVon, DateTime datumBis) 
        {
            Value = value;
            DatumVon = datumVon;
            DatumBis = datumBis;
        }

        /// <summary>
        /// Gets the config value
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Gets the validity from
        /// </summary>
        public DateTime DatumVon { get; private set; }

        /// <summary>
        /// Gets the validity until
        /// </summary>
        public DateTime DatumBis { get; private set; }
    }
}
