using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.Pendenzen
{
	public class CreateUpdateHandler : TypedMessageHandler<CreateUpQuery, NavBarItemItem>
	{
		private readonly SqlConnection _dbConnection;
		//private readonly UnitOfWork unitOfWork = new UnitOfWork
		
		public CreateUpdateHandler(SqlConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public override async Task<NavBarItemItem> Handle(CreateUpQuery query)
		{
			//var data = await _dbConnection.QueryAsync<NavBarItemModel>(@"EXECUTE spFaGetTreeFallNavigator
			//             @UserId, @Active, @Closed, @Archived, @IncludeGroup, @IncludeGuest, @IncludeTasks",
			//	new { UserId = (int)_userId, query.Active, query.Closed, query.Archived, query.IncludeGroup, query.IncludeGuest, query.IncludeTasks });
			var userId = query.UserId;
			var data =  await _dbConnection.QueryAsync<NavBarItemItem>(
							@" SELECT 
							itmMeineFaellig			= (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE ((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND TaskStatusCode IN (1, 2) AND ExpirationDate <= GetDate()),
							itmMeineOffen			= (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE ((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND TaskStatusCode IN (1, 2)),
							itmMeineInBearbeitung	= (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE TaskReceiverCode = 1 AND ReceiverID = @userId AND TaskStatusCode IN (2)),
							itmMeineErstellt		= (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE ((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2)),
							itmMeineErhalten		= (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE ((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND (TaskSenderCode = 2 OR SenderID <> @userId) AND TaskStatusCode IN (1, 2)),
							itmMeineZuVisieren		= (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE ((TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM dbo.FaPendenzgruppe_User WHERE UserID = @userId AND FaPendenzgruppeID = ReceiverID)) OR (TaskReceiverCode = 1 AND ReceiverID = @userId)) AND TaskStatusCode IN (1, 2) AND TaskTypeCode = 2),
							itmVersandteFaellig		= (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2) AND ExpirationDate <= GetDate()),
							itmVersandteZuVisieren	= (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2) AND TaskTypeCode = 2),
							itmVersandteAllgemein	= (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2) AND TaskTypeCode <> 2),
							itmVersandteOffen		= (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE TaskSenderCode = 1 AND SenderID = @userId AND TaskStatusCode IN (1, 2))", new { userId });
			return data.AsList()[0];
			
		}
	}
}
