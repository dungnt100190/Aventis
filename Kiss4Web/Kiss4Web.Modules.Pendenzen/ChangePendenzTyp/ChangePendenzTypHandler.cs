using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.ChangePendenzTyp
{
    public class ChangePendenzTypHandler : TypedMessageHandler<ChangePendenzTypQuery, ChangePendenzTypItem>
    {
        private readonly SqlConnection _dbConnection;

        public ChangePendenzTypHandler(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public override async Task<ChangePendenzTypItem> Handle(ChangePendenzTypQuery query)
        {
            var data = await _dbConnection.QueryAsync<ChangePendenzTypItem>(string.Format(@"  
				SELECT [Subject] =
                  (SELECT ISNULL(TXT.[Text], LOV.Value1)
                   FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                   LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.Value1TID
                   AND TXT.LanguageCode = {0}
                   WHERE LOV.LOVName = 'TaskType'
                     AND LOV.Code = {1}),
                
                       [TaskDescription] =
                  (SELECT ISNULL(TXT.[Text], LOV.Value2)
                   FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                   LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.Value2TID
                   AND TXT.LanguageCode = {0}
                   WHERE LOV.LOVName = 'TaskType'
                     AND LOV.Code = {1})
                
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE 1 = 1 AND LOVName = 'TaskType'
                  AND Code = {1}",
            query.LanguageCode, query.LovCode));
            var result = data.AsList();
            if (result.Count > 0)
            {
                return result[0];
            }
            return new ChangePendenzTypItem();
        }
    }
}
