using System;
using System.Collections.Generic;

using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Sys;
using Kiss.DataAccess.Interfaces;
using Kiss.DataAccess.Sys;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Kes
{
    public class KesMandatsfuehrendePersonService : ServiceCRUD<KesMandatsfuehrendePerson>
    {
        private KesMandatsfuehrendePersonService()
        {
        }

        public void DeleteEntities(IList<KesMandatsfuehrendePersonDTO> entityList)
        {
            foreach (var entity in entityList)
            {
                DeleteEntity(entity.WrappedEntity);
            }
        }

        public virtual string GetAdresseMandatsfuehrendePerson(XUser mandatstraeger, BaInstitution fachperson)
        {
            BaAdresse baAdresse = null;
            string contactInfo = null;

            var adresseService = Container.Resolve<BaAdresseService>();
            if (mandatstraeger != null)
            {
                var userService = Container.Resolve<XUserService>();
                baAdresse = adresseService.GetByUserId(mandatstraeger.UserID);
                contactInfo = userService.GetContactInfoMultiline(mandatstraeger);
            }
            else
            {
                if (fachperson != null)
                {
                    var institutionService = Container.Resolve<BaInstitutionService>();
                    baAdresse = adresseService.GetByBaInstitutionId(fachperson.BaInstitutionID);
                    contactInfo = institutionService.GetContactInfoMultiline(fachperson);
                }
            }

            if (baAdresse != null)
            {
                var addressText = adresseService.GetAddressTextMultiline(baAdresse);
                return addressText + Environment.NewLine + contactInfo;
            }

            return null;
        }

        public virtual List<KesMandatsfuehrendePersonDTO> GetByKesMassnahmeID(int kesMassnahmeID, bool inclDeleted)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.KesMandatsfuehrendePerson.GetByKesMassnahmeID(kesMassnahmeID, inclDeleted);
            }
        }

        protected override IServiceResult RemoveDependentEntities(DataAccess.Interfaces.IUnitOfWork unitOfWork, KesMandatsfuehrendePerson entityToRemove)
        {
            try
            {
                // Dokument löschen
                var documentRepository = (XDocumentRepository)unitOfWork.Repository<XDocument>();
                documentRepository.Remove(entityToRemove.DocumentID_Ernennungsurkunde);
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }
    }
}