using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Authentication.UserId;

namespace Kiss4Web.Infrastructure.Authorization
{
    public class AuthorizationChecker : IAuthorizationChecker
    {
        private readonly IUserIdProvider _userIdProvider;
        private readonly IUserRightsProvider _userRightsProvider;

        public AuthorizationChecker(IUserIdProvider userIdProvider, IUserRightsProvider userRightsProvider)
        {
            _userIdProvider = userIdProvider;
            _userRightsProvider = userRightsProvider;
        }

        public async Task<bool> UserHasRights(IEnumerable<Kiss4RightAttribute> expectedRights)
        {
            if (expectedRights.IsNullOrEmpty())
            {
                return true;
            }

            var userId = _userIdProvider.UserId;
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (_userIdProvider.IsUserAdmin || _userIdProvider.IsUserSuperAdmin)
            {
                // ToDo: handle queries that only SuperAdmin may execute
                return true;
            }

            var userRights = await _userRightsProvider.GetRightsOfUser(userId.Value);
            foreach (var expectedRight in expectedRights)
            {
                if (userRights.TryGetValue(expectedRight.RightName, out var userRight))
                {
                    if (expectedRight.Insert && !userRight.MayInsert
                     || expectedRight.Update && !userRight.MayUpdate
                     || expectedRight.Delete && !userRight.MayDelete)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}