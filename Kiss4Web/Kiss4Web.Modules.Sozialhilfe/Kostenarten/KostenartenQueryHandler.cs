using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Modules.Sozialhilfe.Kostenarten
{
    public class KostenartenQueryHandler : TypedMessageHandler<KostenartenQuery, IEnumerable<KostenartDisplayItem>>
    {
        private readonly SqlConnection _dbConnection;

        public KostenartenQueryHandler(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public override async Task<IEnumerable<KostenartDisplayItem>> Handle(KostenartenQuery query)
        {
            return await _dbConnection.QueryAsync<KostenartDisplayItem>(
                            @"SELECT BKA.*,
                                     NrName = BKA.KontoNr + ' ' + BKA.Name
                              FROM BgKostenart  BKA
                              WHERE EXISTS (SELECT * FROM WhPositionsart
                                            WHERE BgKostenartID = BKA.BgKostenartID AND BgKategorieCode = 2
                                            AND (EXISTS (SELECT * FROM BgFinanzplan WHERE WhGrundbedarfTypCode = BgPositionsartID AND FaLeistungID = @FaLeistungId)
                                                        OR BgGruppeCode BETWEEN 39000 AND 39999 OR @Typ = 1))", new { query.FaLeistungId, query.Typ });
        }
    }
}