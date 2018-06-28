using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Modules.Sozialhilfe.Personen
{
    public class PersonenQueryHandler : TypedMessageHandler<PersonenQuery, IEnumerable<PersonDisplayItem>>
    {
        private readonly SqlConnection _dbConnection;

        public PersonenQueryHandler(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public override async Task<IEnumerable<PersonDisplayItem>> Handle(PersonenQuery query)
        {
            return await _dbConnection.QueryAsync<PersonDisplayItem>(
                      @"SELECT BaPersonID      = NULL, 
                               NameVorname     = ''
                        UNION ALL
                        SELECT PRS.BaPersonID,
                               PRS.NameVorname
                        FROM vwPerson   PRS
                            INNER JOIN (SELECT BPR.BaPersonID
                                        FROM   BgFinanzplan                  BFP
                                            INNER JOIN BgFinanzplan_BaPerson BPR ON BPR.BgFinanzplanID = BFP.BgFinanzplanID
                                        WHERE BFP.FaLeistungID = @FaLeistungId AND BPR.IstUnterstuetzt = 1
                                        GROUP BY BPR.BaPersonID
                                        ) TMP ON TMP.BaPersonID = PRS.BaPersonID", new { query.FaLeistungId });
        }
    }
}