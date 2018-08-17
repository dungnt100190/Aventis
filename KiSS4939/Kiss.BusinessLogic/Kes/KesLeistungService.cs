using System.Linq;

using Kiss.BusinessLogic.Fa;
using Kiss.BusinessLogic.LocalResources.Kes;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Kes
{
    public class KesLeistungService : FaLeistungService
    {
        public IServiceResult AbschlussPruefung(FaLeistung faLeistung)
        {
            var result = ServiceResult.Ok();

            var faLeistungId = faLeistung.FaLeistungID;

            var kesPraeventionService = Container.Resolve<KesPraeventionService>();
            var kesPraevention = kesPraeventionService.GetByFaLeistungId(faLeistungId);

            var kesAuftragService = Container.Resolve<KesAuftragService>();
            var kesAuftrag = kesAuftragService.GetByFaLeistungId(faLeistungId);

            var kesMassnahmeService = Container.Resolve<KesMassnahmeService>();
            var kesMassnahme = kesMassnahmeService.GetByFaLeistungId(faLeistungId, false);

            var kesPflegekinderaufsichtService = Container.Resolve<KesPflegekinderaufsichtService>();
            var kesPflegekinderaufsicht = kesPflegekinderaufsichtService.GetByFaLeistungId(faLeistungId);

            var abschlussDatum = faLeistung.DatumBis;

            if (faLeistung.DatumVon > abschlussDatum)
            {
                result = ServiceResult.Error(KesServiceRes.ErrorDatumBisLeistung, faLeistung.DatumVon);
            }
            else if (faLeistung.AbschlussGrundCode == null || faLeistung.AbschlussGrundCode == -1 || faLeistung.AbschlussGrundCode == 0)
            {
                result = ServiceResult.Error(KesServiceRes.ErrorDatumBisGrund);
            }
            else if (kesPraevention.Any(pra => pra.DatumBis > abschlussDatum || pra.DatumBis == null))
            {
                result = ServiceResult.Error(KesServiceRes.ErrorDatumBisPraevention, abschlussDatum);
            }
            else if (kesAuftrag.Any(auf => auf.AbschlussDatum > abschlussDatum || auf.AbschlussDatum == null))
            {
                result = ServiceResult.Error(KesServiceRes.ErrorDatumBisAuftrag, abschlussDatum);
            }
            else if (kesMassnahme.Any(mas => mas.DatumBis > abschlussDatum || mas.DatumBis == null))
            {
                result = ServiceResult.Error(KesServiceRes.ErrorDatumBisMassnahme, abschlussDatum);
            }
            else if (kesPflegekinderaufsicht.Any(kpa => kpa.DatumBis > abschlussDatum || kpa.DatumBis == null))
            {
                result = ServiceResult.Error(KesServiceRes.ErrorDatumBisPflegekinderaufsicht, abschlussDatum);
            }

            return result;
        }
    }
}