namespace Kiss4Web.Infrastructure.Configuration
{
    public interface IFeatureRegistry
    {
        T GetFeatureConfiguration<T>(Language? language = null, string key = null)
            where T : class, IFeatureConfiguration;

        IFeatureConfiguration GetFeatureConfiguration(string configType, Language? language = null, string key = null);
    }
}