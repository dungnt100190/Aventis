using System;
using Kiss4Web.Infrastructure.DataAccess.Entities;

namespace Kiss4Web.Infrastructure.Configuration
{
    public class FeatureConfiguration : GuidEntity, IValidPeriodEntity
    {
        public IFeatureConfiguration Configuration { get; set; }

        public Language Language { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTill { get; set; }
    }
}