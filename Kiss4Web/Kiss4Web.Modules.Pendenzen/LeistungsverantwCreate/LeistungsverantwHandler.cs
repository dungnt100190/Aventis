using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.LeistungsverantwCreate
{
    public class LeistungsverantwCreateHandler : TypedMessageHandler<LeistungsverantwCreateQuery, LeistungsverantwCreateItem>
    {
        private readonly SqlConnection _dbConnection;

        public LeistungsverantwCreateHandler(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public override async Task<LeistungsverantwCreateItem> Handle(LeistungsverantwCreateQuery query)
        {
            var data = _dbConnection.QueryAsync<LeistungsverantwCreateItem>(
                           string.Format(@"
                SELECT NULLIF(USR.DisplayText, '') as LeistungsverantwName, USR.UserID
                FROM dbo.vwUser USR
                  INNER JOIN dbo.FaLeistung LEI ON LEI.UserID = USR.UserID
                WHERE LEI.FaLeistungID = {0}", query.FaFallId)).Result.AsList();
            if(data.Count > 0)
            {
                return data[0];
            }
            return new LeistungsverantwCreateItem();
        }
    }
}
