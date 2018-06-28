using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kiss4Web.Infrastructure.Authentication.UserId;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.Authorization
{
    public class AllUserRightsQueryHandler : TypedMessageHandler<AllUserRightsQuery, IEnumerable<Kiss4UserRight>>
    {
        private readonly SqlConnection _dbConnection;
        private readonly AuthenticatedUserId _userId;

        public AllUserRightsQueryHandler(SqlConnection dbConnection, AuthenticatedUserId userId)
        {
            _dbConnection = dbConnection;
            _userId = userId;
        }

        public override async Task<IEnumerable<Kiss4UserRight>> Handle(AllUserRightsQuery request)
        {
            return await _dbConnection.QueryAsync<Kiss4UserRight>(@"SELECT UGR.ClassName,
       RightName = MAX(COALESCE(RGT.RightName, UGR.ClassName)),
       MayInsert = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayInsert))),
       MayUpdate = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayUpdate))),
       MayDelete = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayDelete)))
FROM dbo.XUser_UserGroup          UUG WITH (READUNCOMMITTED)
  INNER JOIN dbo.XUserGroup_Right UGR WITH (READUNCOMMITTED) ON UGR.UserGroupID = UUG.UserGroupID
  LEFT  JOIN dbo.XRight           RGT WITH (READUNCOMMITTED) ON RGT.RightID = UGR.RightID
WHERE UUG.UserID = @UserId AND
        (UGR.RightID IS NULL OR RGT.RightID IS NOT NULL)
GROUP BY UGR.ClassName, COALESCE(RGT.RightName, UGR.ClassName)
ORDER BY UGR.ClassName, 2", new { UserId = (int)_userId });

            // Too slow:
            //var result = await _userGroupRights.Where(ugr => ugr.UserGroup.XUserUserGroup.Any(uug => uug.UserId == _userId)
            //                                             && (ugr.RightId == null || ugr.Right != null))
            //                                   .Select(ugr => new Kiss4UserRight
            //                                   {
            //                                       ClassName = ugr.ClassName,
            //                                       RightName = ugr.Right.RightName ?? ugr.ClassName,
            //                                       MayInsert = ugr.MayInsert,
            //                                       MayDelete = ugr.MayDelete,
            //                                       MayUpdate = ugr.MayUpdate
            //                                   })
            //                                   .ToListAsync();
            //return result;
        }
    }
}