using System;
using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.Kiss4Configuration
{
    public interface IKiss4Configuration
    {
        /// <summary>
        /// Get config value by key path
        /// </summary>
        /// <param name="configNode">Identifies the node the query, contains the default value. Use the nodes in <see cref="ConfigNodes"/></param>
        /// <param name="validAt">The DateTime the ConfigValue has to be valid at</param>
        /// <returns>The ConfigCacheItem that is valid at validAt</returns>
        Task<T> GetConfigValue<T>(ConfigNode<T> configNode, DateTime? validAt = null);
    }
}