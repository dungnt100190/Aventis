using Dapper;
using Kiss4Web.Infrastructure.DataAccess;
using Kiss4Web.Infrastructure.Mediator;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Kiss4Web.Model;

namespace Kiss4Web.Modules.Pendenzen.ProcessTask
{
	public class ProcessTaskHandler : TypedMessageHandler<ProcessTaskQuery, bool>
	{
		private readonly SqlConnection _dbConnection;
        private readonly Queryable<XUser> _xUsers;
        public ProcessTaskHandler(SqlConnection dbConnection, Queryable<XUser> xUsers)
		{
			_dbConnection = dbConnection;
            _xUsers = xUsers;

        }

		public override async Task<bool> Handle(ProcessTaskQuery query)
		{
			var userId = query.UserId;
            var reciveTask = 2;
            var userDetail = _xUsers.GetByID(query.ReceiverId);
            if (userDetail != null)
            {
                reciveTask = 1;
            }

            if (query.ReceiverId == 1 || query.ReceiverId == 2 || query.ReceiverId == 3 || query.ReceiverId == 1003)
                query.ReceiverId = 2091;
            switch (query.ProcessType)
			{
				case "process":
					// Step 1: update TaskStatusCode
					await _dbConnection.QueryAsync<bool>(@"
						update	XTask
						set		TaskStatusCode = '2', StartDate = getdate(), UserID_InBearbeitung = @userId
						where	XTaskID = @TaskId", new { userId, query.TaskId });

					// Step 2: check TaskReceiverCode == 2
					var code = await _dbConnection.QueryAsync<int>(@"
						Select	TaskReceiverCode
						From	XTask
						Where	XTaskID = @TaskId", new { query.TaskId });
					if (code.AsList()[0] != 2)
					{
						return true;
					}

					// Step 3: update TaskReceiverCode
					await _dbConnection.QueryAsync<bool>(@"
						Update	XTask
						Set		TaskReceiverCode = '1', ReceiverID = @userId
						Where	XTaskID = @TaskId", new { userId, query.TaskId });
					return true;

				case "finish":
                    

                    await _dbConnection.QueryAsync<bool>(@"
						update	XTask
						set		TaskStatusCode = '3', DoneDate = getdate(), UserID_Erledigt = @receiverId, SenderID = @UserId
						where	XTaskID = @TaskId", new { query.ReceiverId, query.TaskId, query.UserId });
					return true;

				case "assign":
					await _dbConnection.QueryAsync<bool>(@"
						Update	XTask
						set		ReceiverID = @ReceiverId, TaskDescription = @descriptionTask
						Where	XTaskID = @TaskId", new { query.ReceiverId, query.TaskId,  query.DescriptionTask});
					return true;

                case "anfangszustandsdossier":
                    await _dbConnection.QueryAsync<bool>(@"
						Update	XTask
						set		UserID_Erledigt = @receiverId, TaskStatusCode = '3', DoneDate = getdate()
						Where	XTaskID = @TaskId", new { query.ReceiverId, query.TaskId, query.DescriptionTask });
                    return true;

                default:
					return false;
			}
			
		}
	}
}
