using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.Authorization
{
    public interface IUserRightsProvider
    {
        Task<IDictionary<string, Kiss4UserRight>> GetRightsOfUser(int userId);
    }
}