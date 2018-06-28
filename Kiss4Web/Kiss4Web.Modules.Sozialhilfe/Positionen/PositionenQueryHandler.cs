using Dapper;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Sozialhilfe.Positionen
{
    public class PositionenQueryHandler : TypedMessageHandler<PositionenQuery, IEnumerable<PositionDisplayItem>>
    {
        private readonly SqlConnection _dbConnection;

        public PositionenQueryHandler(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public override async Task<IEnumerable<PositionDisplayItem>> Handle(PositionenQuery query)
        {
            return await _dbConnection.QueryAsync<PositionDisplayItem>(
                     @"DECLARE @BgSpezkontoID INT,
                               @BgSpezkontoTypCode INT;

                        SELECT @BgSpezkontoID      = @BgSpezkontoId,
                               @BgSpezkontoTypCode = @Typ;

                        -- Position im Budget
                        SELECT 
                          SortKey      = CASE
                                           WHEN BPO.BgKategorieCode = 101  THEN 2
                                           WHEN @BgSpezkontoTypCode = 2    THEN 1
                                           ELSE 3
                                         END,
                          Datum        = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
                          DatumSort    = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
                          Gutschrift   = CASE WHEN BPO.BgKategorieCode = 101 THEN NULL ELSE BPO.BetragRechnung END,
                          Belastung    = CASE WHEN BPO.BgKategorieCode = 101 THEN BPO.BetragRechnung ELSE NULL END,
                          Freigegeben  = CONVERT(BIT, CASE WHEN BBG.BgBewilligungStatusCode = 5 THEN 1 
                          WHEN EXISTS (SELECT TOP 1 1
                                             FROM dbo.KbBuchung                   BUC WITH (READUNCOMMITTED) 
                                               INNER JOIN dbo.KbBuchungKostenart  BUK WITH (READUNCOMMITTED) ON BUK.KbBuchungID  = BUC.KbBuchungID
                                             WHERE BUC.BgBudgetID = BBG.BgBudgetID
                                               AND BUC.KbBuchungTypCode IN (1, 2, 3, 4) /* Budget, Manuell, Automatisch, Ausgleich */                     
                                               AND BUC.KbBuchungStatusCode NOT IN (1, 7, 8) -- vorbereitet, gesperrt, storniert
                                            ) THEN 1
                        ELSE 0 END),
                          Verbucht     = CONVERT(BIT, CASE
                                                        WHEN BBG.BgBewilligungStatusCode = 5 AND BPO.BgKategorieCode <> 101 THEN 1
                                                        WHEN EXISTS (SELECT TOP 1 1
                                                                     FROM dbo.KbBuchung BUC WITH (READUNCOMMITTED)
                                                                       INNER JOIN dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) ON BUK.KbBuchungID = BUC.KbBuchungID
                                                                     WHERE BUC.BgBudgetID = BPO.BgBudgetID AND BUK.BgPositionID = BPO.BgPositionID
                                                                       AND BUC.KbBuchungTypCode IN (1, 2) /* Einnahmen, Ausgaben */
                                                                       AND BUC.KbBuchungStatusCode NOT IN (1, 7, 8)) THEN 1
                                                        ELSE 0
                                                      END),
                          Gesperrt     = CONVERT(BIT, CASE WHEN BBG.BgBewilligungStatusCode = 9 THEN 1 ELSE 0 END),
                          Buchungstext = BPO.Buchungstext,
                          Saldo        = CONVERT(MONEY, NULL)
                        FROM dbo.vwBgPosition      BPO
                          INNER JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID = BPO.BgBudgetID 
                                                                             AND BBG.MasterBudget = 0
                        WHERE BPO.BgSpezkontoID = @BgSpezkontoID

                        UNION ALL

                        -- Startsaldo des Spezialkonto
                        SELECT 
                          SortKey      = 0, 
                          Datum        = NULL,
                          DatumSort    = NULL,
                          Gutschrift   = CASE WHEN StartSaldo > $0.00 AND BgSpezkontoTypCode <> 3 THEN StartSaldo END,
                          Belastung    = CASE WHEN StartSaldo > $0.00 AND BgSpezkontoTypCode = 3 AND OhneEinzelzahlung = 1 THEN StartSaldo 
                                              WHEN StartSaldo < $0.00 AND BgSpezkontoTypCode = 2 THEN StartSaldo 
                                              END,
                          Freigegeben  = NULL, 
                          Verbucht     = NULL, 
                          Gesperrt     = NULL, 
                          Buchungstext = 'Startsaldo', 
                          Saldo        = NULL
                        FROM dbo.BgSpezkonto WITH (READUNCOMMITTED)
                        WHERE BgSpezkontoID = @BgSpezkontoID 
                          AND (StartSaldo > $0.00 OR BgSpezkontoTypCode = 2)

                        UNION ALL

                        -- Abschluss des Spezialkonto
                        SELECT 
                          SortKey      = 4, 
                          Datum        = NULL,
                          DatumSort    = Created,
                          Gutschrift   = Betrag,
                          Belastung    = NULL,
                          Freigegeben  = CONVERT(BIT, 0), 
                          Verbucht     = CONVERT(BIT, 0), 
                          Gesperrt     = CONVERT(BIT, 0), 
                          Buchungstext = [Text], 
                          Saldo        = NULL
                        FROM dbo.BgSpezkontoAbschluss WITH (READUNCOMMITTED)
                        WHERE BgSpezkontoID = @BgSpezkontoID

                        ORDER BY DatumSort DESC, SortKey DESC;", new { query.BgSpezkontoId, query.Typ });
        }
    }
}
