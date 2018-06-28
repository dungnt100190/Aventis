using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Modules.Sozialhilfe.Spezialkonten
{
    public class SpezialkontenQueryHandler : TypedMessageHandler<SpezialkontenQuery, IEnumerable<SpezialkontoDisplayItem>>
    {
        private readonly IQueryable<SpezialkontoDisplayItem> _displayItems;
        private readonly IDateTimeProvider _dateTimeProvider;

        public SpezialkontenQueryHandler(IQueryable<SpezialkontoDisplayItem> displayItems, IDateTimeProvider dateTimeProvider)
        {
            _displayItems = displayItems;
            _dateTimeProvider = dateTimeProvider;
        }

        public override async Task<IEnumerable<SpezialkontoDisplayItem>> Handle(SpezialkontenQuery query)
        {
            return await _displayItems
                .AsNoTracking()
                .FromSql(@"SELECT SSK.*,
                                  Saldo                 = dbo.fnBgSpezkonto(SSK.BgSpezkontoID, 3, default, default),
                                  DatumVonJahr          = year(SSK.DatumVon),
                                  DatumVonMonat         = month(SSK.DatumVon),
                                  DatumBisJahr          = year(SSK.DatumBis),
                                  DatumBisMonat         = month(SSK.DatumBis),
                                  GueltigVon            = dbo.fnXKurzMonatJahr(SSK.DatumVon),
                                  GueltigBis            = dbo.fnXKurzMonatJahr(SSK.DatumBis),
                                  InstitutionName       = INS.Name,
                                  BewilligungStatusCode = CASE
                                                            WHEN SSK.Inaktiv = 0 THEN 5
                                                            WHEN SSK.Inaktiv = 1 AND BUC.FreigegebenePositionenVorhanden = 1 THEN 9
                                                            ELSE 1
                                                          END,
                                  ProPerson             = BPA.ProPerson,
                                  ProUE                 = BPA.ProUE
                            FROM BgSpezkonto            SSK
                              LEFT JOIN BgKostenart     FLK ON FLK.BgKostenartID    = SSK.BgKostenartID
                              LEFT JOIN BgPositionsart  BPA ON BPA.BgPositionsartID = SSK.BgPositionsartID
                              LEFT JOIN vwInstitution   INS ON INS.BaInstitutionID  = SSK.BaInstitutionID
                              LEFT JOIN (SELECT BPO.BgSpezkontoID, FreigegebenePositionenVorhanden = CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END
                                         FROM vwBgPosition     BPO
                                           INNER JOIN BgBudget BBG ON BBG.BgBudgetID   = BPO.BgBudgetID
                                                                  AND BBG.MasterBudget = 0
                                         WHERE BBG.BgBewilligungStatusCode >= 5 -- grün oder gesperrt
                                         GROUP BY BPO.BgSpezkontoID) BUC ON BUC.BgSpezkontoID = SSK.BgSpezkontoID
                            WHERE SSK.FaLeistungID       = {0}
                              AND SSK.BgSpezkontoTypCode = {1}
                              AND ({2} = 0 OR (dbo.fnDateOf(ISNULL(SSK.DatumBis, {3})) >= dbo.fnDateOf({3}) AND SSK.Inaktiv = 0))
                            ORDER BY SSK.DatumVon DESC, SSK.NameSpezkonto", query.FaLeistungId, query.Typ, query.NurAktive, _dateTimeProvider.Now)
                .ToListAsync();
        }
    }
}