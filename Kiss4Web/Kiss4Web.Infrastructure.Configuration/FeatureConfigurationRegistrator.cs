using System.Linq;
using Kiss4Web.Infrastructure.Modularity;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.Configuration
{
    public class FeatureConfigurationRegistrator : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies licensedAssemblies)
        {
            container.Register<IFeatureRegistry, FeatureRegistry>();
            container.Register<FeatureConfigurationStorage>();

            // allow to inject featureconfiguration directly
            var featureConfigurations = licensedAssemblies.GetTypes<IFeatureConfiguration>()
                                        .Except(licensedAssemblies.GetTypes<IDefaultFeatureConfiguration>())
                                        .Where(cfg => !cfg.HasAttribute<NeedsOptionalKeyAttribute>())
                                        .ToList();
            featureConfigurations.DoForEach(cfg => container.Register(cfg, () => container.GetInstance<IFeatureRegistry>()
                                                                                          .GetFeatureConfiguration(cfg.AssemblyQualifiedName)));
            // default configs
            var defaultFeatureConfigurations = licensedAssemblies.Get<IDefaultFeatureConfiguration>()
                                               .Where(cfg => cfg != null)
                                               .ToArray();
            container.RegisterCollection(defaultFeatureConfigurations);
        }
    }
}