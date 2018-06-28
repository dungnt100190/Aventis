using System;
using Kiss4Web.Infrastructure.DataAccess.Entities;

namespace Kiss4Web.Infrastructure.Configuration
{
    public class FeatureConfigurationEntity : GuidEntity, IValidPeriodEntity
    {
        public string ConfigurationJson { get; set; }
        public string FeatureConfigurationType { get; set; }
        public string Key { get; set; }
        public string Language { get; set; }
        public string OptionalKey { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
    }
}