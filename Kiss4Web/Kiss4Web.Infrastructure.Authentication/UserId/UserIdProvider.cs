using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Kiss4Web.Infrastructure.Authentication.UserId
{
    public class UserIdProvider : IUserIdProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIdProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId
        {
            get
            {
                var idString = _httpContextAccessor
                                 ?.HttpContext
                                 ?.User
                                 ?.Claims
                                 ?.FirstOrDefault(clm => clm.Type == "sub")
                                 ?.Value;
                // id is verified (in ExtractUserIdMiddleware)
                return int.TryParse(idString, out var userId) ? userId : (int?)0;
            }
        }

        public bool IsUserAdmin
        {
            get
            {
                return _httpContextAccessor
                    ?.HttpContext
                    ?.User
                    ?.Claims
                    ?.FirstOrDefault(clm => clm.Type == Kiss4WebClaims.IsUserAdmin)
                    ?.Value == bool.TrueString;
            }
        }

        public bool IsUserSuperAdmin
        {
            get
            {
                return _httpContextAccessor
                           ?.HttpContext
                           ?.User
                           ?.Claims
                           ?.FirstOrDefault(clm => clm.Type == Kiss4WebClaims.IsUserSuperAdmin)
                           ?.Value == bool.TrueString;
            }
        }
    }
}