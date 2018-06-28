using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Kiss4Web.Infrastructure.Authorization
{
    public class UserRightsCache : IUserRightsProvider
    {
        private readonly IUserRightsProvider _decoratee;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _slidingExpiration = new TimeSpan(1, 0, 0, 0);

        public UserRightsCache(IUserRightsProvider decoratee, IMemoryCache cache)
        {
            _decoratee = decoratee;
            _cache = cache;
        }

        public async Task<IDictionary<string, Kiss4UserRight>> GetRightsOfUser(int userId)
        {
            var key = new UserRightsCacheKey(userId);
            return await _cache.GetOrCreateAsync(key, entry =>
            {
                entry.SlidingExpiration = _slidingExpiration;
                return _decoratee.GetRightsOfUser(userId);
            });
        }
    }
}