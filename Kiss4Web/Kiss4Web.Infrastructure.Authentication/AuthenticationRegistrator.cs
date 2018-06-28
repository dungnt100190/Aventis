using Kiss4Web.Infrastructure.Authentication.UserId;
using Kiss4Web.Infrastructure.Modularity;
using Microsoft.AspNetCore.Http;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.Authentication
{
    public class AuthenticationRegistrator : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies assemblies)
        {
            //container.Register<IIdentityResolver, IdentityResolver>();

            container.RegisterSingleton<IUserIdProvider, UserIdProvider>();

            container.Register<AuthenticatedUserId>(() => container.GetInstance<IUserIdProvider>().UserId);
            //container.Register<AuthenticatedLogin>(() => ExctratLogin(container.GetInstance<IHttpContextAccessor>()));
            container.Register<AuthenticatedUsername>(() => container.GetInstance<IHttpContextAccessor>().HttpContext?.User?.Identity?.Name ?? "unbekannt");
        }
    }
}