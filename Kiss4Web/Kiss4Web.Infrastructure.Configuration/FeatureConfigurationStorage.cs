using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Newtonsoft.Json;

namespace Kiss4Web.Infrastructure.Configuration
{
    public class FeatureConfigurationStorage
    {
        private readonly IGuidRepository<FeatureConfigurationEntity> _configurations;
        private readonly RequestLanguage _requestLanguage;
        private readonly IDateTimeProvider _dateTimeProvider;

        public FeatureConfigurationStorage(IGuidRepository<FeatureConfigurationEntity> configurations,
                                           RequestLanguage requestLanguage,
                                           IDateTimeProvider dateTimeProvider)
        {
            _configurations = configurations;
            _requestLanguage = requestLanguage;
            _dateTimeProvider = dateTimeProvider;
        }

        public FeatureConfiguration GetDerivedFeatureConfiguration(Type type, DateTime? validAt = null, Language? language = null, string key = null)
        {
            var validAtNotNullable = validAt ?? _dateTimeProvider.Now;
            var entities = _configurations.Where(cfg => cfg.Key == type.FullName &&
                                                        cfg.ValidFrom <= validAtNotNullable &&
                                                        cfg.ValidTill > validAtNotNullable &&
                                                        (key == null || cfg.OptionalKey == key))
                                          .ToList();
            Func<FeatureConfigurationEntity, bool> condition = cfg => true;
            var isLanguageDependend = type.HasAttribute<LanguageDependendConfigurationAttribute>();
            if (isLanguageDependend)
            {
                condition = cfg => cfg.Language == _requestLanguage.Language;
            }
            var entity = entities.FirstOrDefault(condition);

            //var validAtNotNullable = validAt ?? _dateTimeProvider.Now;
            //var isLanguageDependend = type.HasAttribute<LanguageDependendConfigurationAttribute>();
            //if (isLanguageDependend && language == null)
            //{
            //    language = _languageResolver.GetRequestLanguage();
            //}
            //var languageString = language.ToString();
            //var entity = _configurations.FirstOrDefault(cfg => cfg.Key == type.FullName &&
            //                                                   (!isLanguageDependend || cfg.Language == languageString) &&
            //                                                   cfg.ValidFrom < validAtNotNullable &&
            //                                                   cfg.ValidTill > validAtNotNullable);
            if (entity == null)
            {
                return null;
            }

            var savedType = Type.GetType(entity.FeatureConfigurationType); // Vergleichen?

            var configurationString = entity.ConfigurationJson;
            //if (typeof(IEncryptedFeatureConfiguration).IsAssignableFrom(type))
            //{
            //    using (var cryptoProvider = new SymmetricCryptographyProvider())
            //    {
            //        configurationString = cryptoProvider.DecryptString(configurationString);
            //    }
            //}

            var config = JsonConvert.DeserializeObject(configurationString, type);
            return new FeatureConfiguration
            {
                Id = entity.Id,
                Configuration = config as IFeatureConfiguration,
                ValidFrom = entity.ValidFrom,
                ValidTill = entity.ValidTill,
                RowVersion = entity.RowVersion
            };
        }

        public FeatureConfiguration GetFeatureConfiguration<T>(DateTime? validAt = null, Language? language = null, string key = null)
                    where T : IFeatureConfiguration
        {
            return GetFeatureConfiguration(typeof(T), validAt, language);
        }

        public FeatureConfiguration GetFeatureConfiguration(Type type, DateTime? validAt = null, Language? language = null, string key = null)
        {
            var validAtNotNullable = validAt ?? _dateTimeProvider.Now;
            var entities = new List<FeatureConfigurationEntity>();/*_configurations.Where(cfg => cfg.Key == type.FullName &&
                                                        cfg.ValidFrom <= validAtNotNullable &&
                                                        cfg.ValidTill > validAtNotNullable &&
                                                        (key == null || cfg.OptionalKey == key))
                                          .ToList();*/
            Func<FeatureConfigurationEntity, bool> condition = cfg => true;
            var isLanguageDependend = type.HasAttribute<LanguageDependendConfigurationAttribute>();
            if (isLanguageDependend)
            {
                condition = cfg => cfg.Language == _requestLanguage.Language;
            }
            var entity = entities.FirstOrDefault(condition);

            //var validAtNotNullable = validAt ?? _dateTimeProvider.Now;
            //var isLanguageDependend = type.HasAttribute<LanguageDependendConfigurationAttribute>();
            //if (isLanguageDependend && language == null)
            //{
            //    language = _languageResolver.GetRequestLanguage();
            //}
            //var languageString = language.ToString();
            //var entity = _configurations.FirstOrDefault(cfg => cfg.Key == type.FullName &&
            //                                                   (!isLanguageDependend || cfg.Language == languageString) &&
            //                                                   cfg.ValidFrom < validAtNotNullable &&
            //                                                   cfg.ValidTill > validAtNotNullable);
            if (entity == null)
            {
                return null;
            }

            var savedType = Type.GetType(entity.FeatureConfigurationType); // Vergleichen?

            var configurationString = entity.ConfigurationJson;
            //if (typeof(IEncryptedFeatureConfiguration).IsAssignableFrom(type))
            //{
            //    using (var cryptoProvider = new SymmetricCryptographyProvider())
            //    {
            //        configurationString = cryptoProvider.DecryptString(configurationString);
            //    }
            //}

            var config = JsonConvert.DeserializeObject(configurationString, type);
            return new FeatureConfiguration
            {
                Id = entity.Id,
                Configuration = config as IFeatureConfiguration,
                ValidFrom = entity.ValidFrom,
                ValidTill = entity.ValidTill,
                RowVersion = entity.RowVersion
            };
        }

        public Task SaveFeatureConfiguration(FeatureConfiguration entity)
        {
            var json = JsonConvert.SerializeObject(entity.Configuration);
            var configType = entity.Configuration.GetType();

            //if (typeof(IEncryptedFeatureConfiguration).IsAssignableFrom(configType))
            //{
            //    using (var cryptoProvider = new SymmetricCryptographyProvider())
            //    {
            //        json = cryptoProvider.EncryptString(json);
            //    }
            //}

            var storage = new FeatureConfigurationEntity
            {
                Id = entity.Id,
                Key = configType.FullName,
                Language = entity.Language,
                FeatureConfigurationType = configType.AssemblyQualifiedName,
                ConfigurationJson = json,
                ValidFrom = entity.ValidFrom,
                ValidTill = entity.ValidTill,
                RowVersion = entity.RowVersion
            };
            return _configurations.InsertOrUpdateEntity(storage);
        }
    }
}