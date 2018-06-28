namespace Kiss4Web.Infrastructure.Authentication
{
    //public class IdentityResolver : IIdentityResolver
    //{
    //    private readonly IHttpContextAccessor _contextAccessor;

    //    public IdentityResolver(IHttpContextAccessor contextAccessor)
    //    {
    //        _contextAccessor = contextAccessor;
    //        Login = GetLogin();
    //    }

    //    public Login Login { get; }

    //    public void OverrideIdentity(IIdentity identity)
    //    {
    //        // ToDo
    //    }

    //    private static AuthenticationMode GetAuthenticationMode(IIdentity user)
    //    {
    //        if (user is ClaimsIdentity claimsUser &&
    //            claimsUser.RoleClaimType == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" &&
    //            claimsUser.Claims.FirstOrDefault(claim => claim.Type == "name")?.Issuer?.StartsWith("https://login.microsoftonline.com/") == true)
    //        {
    //            // see https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-v2-tokens
    //            var objectId = claimsUser.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier");
    //            return AuthenticationMode.AzureActiveDirectory;
    //        }
    //        if (user.AuthenticationType == "Bearer")
    //        {
    //            return AuthenticationMode.Aventis;
    //        }

    //        if (Enum.TryParse(user.AuthenticationType, out AuthenticationMode mode))
    //        {
    //            return mode;
    //        }
    //        return AuthenticationMode.Windows;
    //    }

    //    private Login GetLogin()
    //    {
    //        var user = _contextAccessor.HttpContext?.User?.Identity;
    //        if (user?.IsAuthenticated == true)
    //        {
    //            var mode = GetAuthenticationMode(user);
    //            var name = user.Name;
    //            return new Login(mode, name);
    //        }
    //        return null;
    //    }
    //}
}