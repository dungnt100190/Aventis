using Kiss4Web.Infrastructure.DataAccess.Entities.Configuration;

namespace Kiss4Web.Infrastructure.Configuration
{
    public class FeatureConfigurationMap : EntityMap<FeatureConfigurationEntity>
    {
        public FeatureConfigurationMap()
        {
            Property(t => t.Key)
                .HasMaxLength(1000);

            Property(t => t.FeatureConfigurationType)
                .HasMaxLength(1000);

            Property(t => t.Language)
                .HasMaxLength(10);
        }
    }
}