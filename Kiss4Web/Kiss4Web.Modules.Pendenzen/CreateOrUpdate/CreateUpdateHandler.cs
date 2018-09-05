using Dapper;
using Kiss4Web.Infrastructure.DataAccess;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.CreateOrUpdate
{
    public class CreateUpdateHandler : TypedMessageHandler<CreateUpdateQuery, bool>
    {
        private readonly SqlConnection _dbConnection;
        private readonly Queryable<XUser> _xUsers;
        private readonly IRepository<XTask> _xTask;

        public CreateUpdateHandler(SqlConnection dbConnection, Queryable<XUser> xUsers, IRepository<XTask> xTask)
        {
            _dbConnection = dbConnection;
            _xUsers = xUsers;
            _xTask = xTask;
        }

        public override async Task<bool> Handle(CreateUpdateQuery query)
        {
            // GET empfanger information by empfanger Id
            //var faPendenzgruppeUserDetail = _faPendenzgruppeUsers.GetDetailByCondition(s => s.FaPendenzgruppeId.Equals(query.empfangerId));

            //if (faPendenzgruppeUserDetail != null)s
            //{
            //    query.empfangerId = faPendenzgruppeUserDetail.UserId;
            //}
            var reciveTask = 2;
            var userDetail = _xUsers.GetByID(query.empfangerId);
            if (userDetail != null)
            {
                reciveTask = 1;
            }

            if (query.id.HasValue)
            {

                var strQuery = string.Format(@"
					UPDATE XTask
					SET [TaskStatusCode] =			{0},
						[TaskTypeCode] =			{1},
						[Subject] =					{2},
						[TaskDescription] =			{3},
						[ReceiverID] =				{4},
						[FaFallID] =				{5},
						[FaLeistungID] =			{6},
						
						[BaPersonID] =			{7},
						[ResponseText] =			{8},
						[ExpirationDate] =			{9}
					WHERE XTaskID = {10}",
                    query.status,
                    query.pendenzTyp,
                    "'" + query.betreff + "'",
                    query.beschreibung == null ? "null" : "'" + query.beschreibung + "'",
                    query.empfangerId,
                    query.falltrager == null ? "null" : "'" + query.falltrager + "'",
                    query.leistung == null ? "null" : "'" + query.leistung + "'",

                    query.PersonId == null ? "null" : "'" + query.PersonId + "'",
                    query.antwort == null ? "null" : "'" + query.antwort + "'",

                    query.fallig == null ? "null" : "'" + query.fallig + "'",
                    query.id);

                // Update
                await _dbConnection.QueryAsync<bool>(strQuery);
            }
            else
            {
                var task = new XTask()
                {
                    TaskStatusCode = query.status,
                    TaskTypeCode = query.pendenzTyp,
                    Subject = query.betreff,
                    TaskDescription = query.beschreibung,
                    ReceiverId = query.empfangerId,
                    FaFallId = query.falltrager,
                    FaLeistungId = query.leistung,
                    BaPersonId = query.PersonId,
                    ResponseText = query.antwort,
                    CreateDate = DateTime.Now,
                    ExpirationDate = DateTime.ParseExact(query.fallig,
                                        "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    TaskReceiverCode = 1,
                    TaskSenderCode = reciveTask,
                    SenderId = Convert.ToInt32(query.SenderId),
                    StartDate = DateTime.ParseExact(query.erfasst,
                                        "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
                };

                await _xTask.InsertOrUpdateEntity(task);
            }
            return true;
        }

    }
}