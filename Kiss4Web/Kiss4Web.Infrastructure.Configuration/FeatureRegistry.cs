using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kiss4Web.Infrastructure.Configuration
{
    internal class FeatureRegistry : IFeatureRegistry
    {
        private readonly IEnumerable<IDefaultFeatureConfiguration> _defaultFeatureConfigurations;
        private readonly FeatureConfigurationStorage _storage;

        public FeatureRegistry(FeatureConfigurationStorage storage,
                               IEnumerable<IDefaultFeatureConfiguration> defaultFeatureConfigurations)
        {
            _storage = storage;
            _defaultFeatureConfigurations = defaultFeatureConfigurations;
        }

        public T GetFeatureConfiguration<T>(Language? language = null, string key = null)
            where T : class, IFeatureConfiguration
        {
            return GetFeatureConfiguration(typeof(T).AssemblyQualifiedName, language, key) as T;
        }

        public IFeatureConfiguration GetFeatureConfiguration(string configTypeAssemblyQualifiedName, Language? language = null, string key = null)
        {
            var type = Type.GetType(configTypeAssemblyQualifiedName);
            if (type == null)
            {
                // ToDo: log
                return null;
            }

            var configEntity = _storage.GetFeatureConfiguration(type, null, language, key);
            if (configEntity != null)
            {
                return configEntity.Configuration;
            }
            var isLanguageDependend = type.HasAttribute<LanguageDependendConfigurationAttribute>();
            var defaultConfig = _defaultFeatureConfigurations
                                .Where(dfc => dfc.GetType().GetTypeInfo().BaseType == type &&
                                              (key == null || dfc.GetType().HasAttribute<OptionalKeyAttribute>() &&
                                                              dfc.GetType().GetTypeInfo().GetCustomAttribute<OptionalKeyAttribute>().Key == key))
                                .ToList();
            if (!isLanguageDependend)
            {
                return defaultConfig.FirstOrDefault();
            }
            var matchingLanguageConfig = defaultConfig.FirstOrDefault(dfc => dfc.GetType().HasAttribute<LanguageAttribute>() &&
                                                                             dfc.GetType().GetTypeInfo().GetCustomAttribute<LanguageAttribute>().Language == language);
            if (matchingLanguageConfig != null)
            {
                return matchingLanguageConfig;
            }
            return defaultConfig.FirstOrDefault();
        }
    }
}