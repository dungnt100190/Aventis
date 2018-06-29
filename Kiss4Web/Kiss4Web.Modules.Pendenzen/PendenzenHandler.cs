using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kiss4Web.Infrastructure.Authentication.UserId;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.Pendenzen;

namespace Kiss4Web.Modules.Pendenzen
{
    public class PendenzenHandler : TypedMessageHandler<PendenzenQuery, IEnumerable<NavBarItemsModel>>
	{
		private readonly SqlConnection _dbConnection;
		private readonly AuthenticatedUserId _userId;

		public PendenzenHandler(SqlConnection dbConnection, AuthenticatedUserId userId)
		{
			_dbConnection = dbConnection;
			_userId = userId;
		}

		public override async Task<IEnumerable<NavBarItemsModel>> Handle(PendenzenQuery query)
		{
			//var data = await _dbConnection.QueryAsync<NavBarItemModel>(@"EXECUTE spFaGetTreeFallNavigator
			//             @UserId, @Active, @Closed, @Archived, @IncludeGroup, @IncludeGuest, @IncludeTasks",
			//	new { UserId = (int)_userId, query.Active, query.Closed, query.Archived, query.IncludeGroup, query.IncludeGuest, query.IncludeTasks });
			var userId = "2091";
			var data = _dbConnection.QueryAsync<NavBarItemsModel>(
							@"select a = null,
									itmmeinefaellig = (select count(1) from dbo.xtask with (readuncommitted) where ((taskreceivercode = 2 and exists (select top 1 1 from dbo.fapendenzgruppe_user where userid = @userid and fapendenzgruppeid = receiverid)) or (taskreceivercode = 1 and receiverid = @userid)) and taskstatuscode in (1, 2) and expirationdate <= getdate()),
									itmmeineoffen = (select count(1) from dbo.xtask with (readuncommitted) where ((taskreceivercode = 2 and exists (select top 1 1 from dbo.fapendenzgruppe_user where userid = @userid and fapendenzgruppeid = receiverid)) or (taskreceivercode = 1 and receiverid = @userid)) and taskstatuscode in (1, 2)),
									itmmeineinbearbeitung = (select count(1) from dbo.xtask with (readuncommitted) where taskreceivercode = 1 and receiverid = @userid and taskstatuscode in (2)),
									itmmeineerstellt = (select count(1) from dbo.xtask with (readuncommitted) where ((taskreceivercode = 2 and exists (select top 1 1 from dbo.fapendenzgruppe_user where userid = @userid and fapendenzgruppeid = receiverid)) or (taskreceivercode = 1 and receiverid = @userid)) and tasksendercode = 1 and senderid = @userid and taskstatuscode in (1, 2)),
									itmmeineerhalten = (select count(1) from dbo.xtask with (readuncommitted) where ((taskreceivercode = 2 and exists (select top 1 1 from dbo.fapendenzgruppe_user where userid = @userid and fapendenzgruppeid = receiverid)) or (taskreceivercode = 1 and receiverid = @userid)) and (tasksendercode = 2 or senderid <> @userid) and taskstatuscode in (1, 2)),
									itmmeinezuvisieren = (select count(1) from dbo.xtask with (readuncommitted) where ((taskreceivercode = 2 and exists (select top 1 1 from dbo.fapendenzgruppe_user where userid = @userid and fapendenzgruppeid = receiverid)) or (taskreceivercode = 1 and receiverid = @userid)) and taskstatuscode in (1, 2) and tasktypecode = 2),
									itmversandtefaellig = (select count(1) from dbo.xtask with (readuncommitted) where tasksendercode = 1 and senderid = @userid and taskstatuscode in (1, 2) and expirationdate <= getdate()),
									itmversandtezuvisieren = (select count(1) from dbo.xtask with (readuncommitted) where tasksendercode = 1 and senderid = @userid and taskstatuscode in (1, 2) and tasktypecode = 2),
									itmversandteallgemein = (select count(1) from dbo.xtask with (readuncommitted) where tasksendercode = 1 and senderid = @userid and taskstatuscode in (1, 2) and tasktypecode <> 2),
									itmversandteoffen = (select count(1) from dbo.xtask with (readuncommitted) where tasksendercode = 1 and senderid = @userid and taskstatuscode in (1, 2)),
									itmmeinefaellig = (select count(1) from dbo.xtask with (readuncommitted) where ((taskreceivercode = 2 and exists (select top 1 1 from dbo.fapendenzgruppe_user where userid = @userid and fapendenzgruppeid = receiverid)) or (taskreceivercode = 1 and receiverid = @userid)) and taskstatuscode in (1, 2) and expirationdate <= getdate()),
									itmmeineoffen = (select count(1) from dbo.xtask with (readuncommitted) where ((taskreceivercode = 2 and exists (select top 1 1 from dbo.fapendenzgruppe_user where userid = @userid and fapendenzgruppeid = receiverid)) or (taskreceivercode = 1 and receiverid = @userid)) and taskstatuscode in (1, 2)),
									itmmeineinbearbeitung = (select count(1) from dbo.xtask with (readuncommitted) where taskreceivercode = 1 and receiverid = @userid and taskstatuscode in (2)),
									itmmeineerstellt = (select count(1) from dbo.xtask with (readuncommitted) where ((taskreceivercode = 2 and exists (select top 1 1 from dbo.fapendenzgruppe_user where userid = @userid and fapendenzgruppeid = receiverid)) or (taskreceivercode = 1 and receiverid = @userid)) and tasksendercode = 1 and senderid = @userid and taskstatuscode in (1, 2)),
									itmmeineerhalten = (select count(1) from dbo.xtask with (readuncommitted) where ((taskreceivercode = 2 and exists (select top 1 1 from dbo.fapendenzgruppe_user where userid = @userid and fapendenzgruppeid = receiverid)) or (taskreceivercode = 1 and receiverid = @userid)) and (tasksendercode = 2 or senderid <> @userid) and taskstatuscode in (1, 2)),
									itmmeinezuvisieren = (select count(1) from dbo.xtask with (readuncommitted) where ((taskreceivercode = 2 and exists (select top 1 1 from dbo.fapendenzgruppe_user where userid = @userid and fapendenzgruppeid = receiverid)) or (taskreceivercode = 1 and receiverid = @userid)) and taskstatuscode in (1, 2) and tasktypecode = 2),
									itmversandtefaellig = (select count(1) from dbo.xtask with (readuncommitted) where tasksendercode = 1 and senderid = @userid and taskstatuscode in (1, 2) and expirationdate <= getdate()),
									itmversandtezuvisieren = (select count(1) from dbo.xtask with (readuncommitted) where tasksendercode = 1 and senderid = @userid and taskstatuscode in (1, 2) and tasktypecode = 2),
									itmversandteallgemein = (select count(1	) from dbo.xtask with (readuncommitted) where tasksendercode = 1 and senderid = @userid and taskstatuscode in (1, 2) and tasktypecode <> 2),
									itmversandteoffen = (select count(1) from dbo.xtask with (readuncommitted) where tasksendercode = 1 and senderid = @userid and taskstatuscode in (1, 2))
									", new { userId }).Result.AsList();
			return data;
		}
	}
}
