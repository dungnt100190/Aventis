using Kiss4Web.Infrastructure.Modularity;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.Kiss4Configuration
{
    public class Kiss4ConfigurationRegistrar : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies licensedAssemblies)
        {
            container.Register<IKiss4Configuration, Kiss4Configuration>();
        }
    }
}