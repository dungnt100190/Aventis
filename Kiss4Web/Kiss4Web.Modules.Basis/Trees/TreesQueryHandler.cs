using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kiss4Web.Infrastructure.Authentication.UserId;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Modules.Basis.Trees
{
    public class TreesQueryHandler : TypedMessageHandler<TreesQuery, IEnumerable<TreeDisplayItem>>
    {
        private readonly SqlConnection _dbConnection;
        private readonly AuthenticatedUserId _userId;

        public TreesQueryHandler(SqlConnection dbConnection, AuthenticatedUserId userId)
        {
            _dbConnection = dbConnection;
            _userId = userId;
        }

        public override async Task<IEnumerable<TreeDisplayItem>> Handle(TreesQuery query)
        {
            return await _dbConnection.QueryAsync<TreeDisplayItem>(@"EXECUTE spFaGetTreeFallNavigator
                @UserId, @Active, @Closed, @Archived, @IncludeGroup, @IncludeGuest, @IncludeTasks",
                new { UserId = (int)_userId, query.Active, query.Closed, query.Archived, query.IncludeGroup, query.IncludeGuest, query.IncludeTasks });
        }
    }
}