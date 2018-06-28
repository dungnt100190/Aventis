using SimpleInjector;

namespace Kiss4Web.Infrastructure.Modularity
{
    public interface ITypeRegistrator
    {
        void RegisterTypes(Container container, ILicensedAssemblies licensedAssemblies);
    }
}