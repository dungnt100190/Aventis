using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Modules.Sozialhilfe.Positionsarten
{
    public class PositionsartenQueryHandler : TypedMessageHandler<PositionsartenQuery, IEnumerable<PositionsartDisplayItem>>
    {
        private readonly SqlConnection _dbConnection;

        public PositionsartenQueryHandler(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public override async Task<IEnumerable<PositionsartDisplayItem>> Handle(PositionsartenQuery query)
        {
            return await _dbConnection.QueryAsync<PositionsartDisplayItem>(
                          @"SELECT POA.BgPositionsartID,
                                   Text = IsNull(KOA.KontoNr, '') + ' ' + POA.Name
                            FROM dbo.WhPositionsart   POA
                            LEFT JOIN dbo.WhKostenart KOA ON KOA.BgKostenartID = POA.BgKostenartID
                            WHERE BgKategorieCode = 3
                            ORDER BY SortKey");
        }
    }
}