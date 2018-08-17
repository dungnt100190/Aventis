using System;
using System.Collections.Generic;

using Kiss.DataAccess.Interfaces;
using Kiss.DataAccess.Sys;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;
using Kiss.DbContext.Enums.Kes;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Kes
{
    public class KesVerlaufService : ServiceCRUD<KesVerlauf>
    {
        private KesVerlaufService()
        {
        }

        public virtual IList<KesVerlaufDTO> GetByFaLeistungId(int faLeistungId, KesVerlaufTyp kesVerlaufTyp)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.KesVerlauf.GetByFaLeistungId(faLeistungId, (int)kesVerlaufTyp);
            }
        }

        protected override IServiceResult RemoveDependentEntities(DataAccess.Interfaces.IUnitOfWork uow, KesVerlauf entityToRemove)
        {
            var unitOfWork = (IKissUnitOfWork)uow;
            try
            {
                // Dokumente löschen
                var documentRepository = (XDocumentRepository)unitOfWork.Repository<XDocument>();
                documentRepository.Remove(entityToRemove.DocumentID);
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }
    }
}