using System;
using System.Collections.Generic;

using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.LocalResources.Kes;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;

namespace Kiss.BusinessLogic.Kes
{
    public class KesPflegekinderaufsichtService : ServiceCRUD<KesPflegekinderaufsicht>
    {
        private KesPflegekinderaufsichtService()
        {
        }

        public string GetAdressePflegeeltern(BaInstitution institution)
        {
            if (institution != null)
            {
                var adresseService = Container.Resolve<BaAdresseService>();
                var institutionService = Container.Resolve<BaInstitutionService>();
                var baAdresse = adresseService.GetByBaInstitutionId(institution.BaInstitutionID);

                if (baAdresse != null)
                {
                    var contactInfo = institutionService.GetContactInfoMultiline(institution);
                    var addressText = adresseService.GetAddressTextMultiline(baAdresse);
                    return addressText + Environment.NewLine + contactInfo;
                }
            }

            return null;
        }

        public virtual IList<KesPflegekinderaufsicht> GetByFaLeistungId(int faLeistungId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.KesPflegekinderaufsicht.GetByFaLeistungId(faLeistungId);
            }
        }

        public override Kiss.Interfaces.BL.IServiceResult SaveEntity(KesPflegekinderaufsicht entityToSave)
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