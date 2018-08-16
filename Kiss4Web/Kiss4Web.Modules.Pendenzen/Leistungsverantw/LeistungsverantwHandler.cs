using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.Leistungsverantw
{
    public class LeistungsverantwHandler : TypedMessageHandler<LeistungsverantwQuery, IEnumerable<LeistungsverantwItem>>
    {
        private readonly SqlConnection _dbConnection;

        public LeistungsverantwHandler(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public override async Task<IEnumerable<LeistungsverantwItem>> Handle(LeistungsverantwQuery query)
        {
            string keyword = query.Keyword ?? "";
            var querystring = string.Format(@"  SELECT  UserId,
                                        Name = NameVorname,
                                        LogonName,
                                        DisplayText = DisplayText
                                        FROM dbo.vwUser WITH (READUNCOMMITTED)
                                        WHERE (NameVorname LIKE  '%' + N'{0}' + '%' OR LogonName LIKE '%' + N'{0}' + '%')
                                        ORDER BY Name", keyword);
            var data = _dbConnection.QueryAsync<LeistungsverantwItem>(
                           querystring).Result.AsList();

          
            return data;
        }
    }
}
