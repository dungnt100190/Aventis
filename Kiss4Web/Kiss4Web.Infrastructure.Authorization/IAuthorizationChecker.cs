using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.Authorization
{
    public interface IAuthorizationChecker
    {
        Task<bool> UserHasRights(IEnumerable<Kiss4RightAttribute> expectedRights);
    }
}