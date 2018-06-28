using Kiss4Web.Infrastructure.Modularity;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.Authorization
{
    public class AuthorizationRegistrar : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies licensedAssemblies)
        {
            container.Register<IAuthorizationChecker, AuthorizationChecker>();
            container.Register<IUserRightsProvider, UserRightsProvider>();
            container.RegisterDecorator<IUserRightsProvider, UserRightsCache>();
        }
    }
}