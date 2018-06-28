using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Modularity;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.Authorization
{
    public class UserRightsProvider : IUserRightsProvider
    {
        private readonly Container _container;

        public UserRightsProvider(Container container)
        {
            _container = container;
        }

        public async Task<IDictionary<string, Kiss4UserRight>> GetRightsOfUser(int userId)
        {
            using (new EnsureExecutionScope(_container))
            {
                // build handler "manually" to avoid pipeline
                var queryHandler = new AllUserRightsQueryHandler(_container.GetInstance<SqlConnection>(), userId);
                var rights = await queryHandler.Handle(new AllUserRightsQuery());
                return rights.ToImmutableDictionary(rgt => rgt.RightName);
            }
        }
    }
}