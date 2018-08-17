using System.Collections.Generic;

using Kiss.BusinessLogic.LocalResources.Kes;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Kes
{
    public class KesPraeventionService : ServiceCRUD<KesPraevention>
    {
        private KesPraeventionService()
        {
        }

        public virtual IList<KesPraevention> GetByFaLeistungId(int faLeistungId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.KesPraevention.GetByFaLeistungId(faLeistungId);
            }
        }

        public override IServiceResult SaveEntity(KesPraevention entityToSave)
        {
            var leistungService = Container.Resolve<KesLeistungService>();
            var leistung = leistungService.GetEntityById(entityToSave.FaLeistungID);

            if (entityToSave.DatumVon < leistung.DatumVon)
            {
                return ServiceResult.Error(KesServiceRes.ErrorDatumVon, leistung.DatumVon);
            }

            return base.SaveEntity(entityToSave);
        }
    }
}