using System;
using System.Collections.Generic;

using Kiss.DataAccess.Interfaces;
using Kiss.DataAccess.Sys;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Fa
{
    public class FaDokumentAblageService : ServiceCRUD<FaDokumentAblage>
    {
        private FaDokumentAblageService()
        {
        }

        public IServiceResult<IEnumerable<FaDokumentAblageDTO>> RunQuery(FaDokumentAblageSearchParamDto searchParams)
        {
            var result = new ServiceResult<IEnumerable<FaDokumentAblageDTO>>(ServiceResultType.Ok);

            var datumVon = searchParams.DokumentDatumVon;
            var datumBis = searchParams.DokumentDatumBis;

            if (datumVon > datumBis)
            {
                result.AddEntry(ServiceResultType.Error, "Das VON-Datum darf nicht grösser als das BIS-Datum sein.");
                return result;
            }

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                result.Result = unitOfWork.FaDokumentAblage.GetDtoList(searchParams);
            }

            return result;
        }

        public override IServiceResult SaveEntity(FaDokumentAblage entityToSave)
        {
            var result = base.SaveEntity(entityToSave);

            if (result.IsOk)
            {
                using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
                {
                    unitOfWork.FaDokumentAblage.SaveBetroffenePersonen(entityToSave);
                    unitOfWork.SaveChanges();
                }
            }

            return result;
        }

        protected override IServiceResult RemoveDependentEntities(DataAccess.Interfaces.IUnitOfWork uow, FaDokumentAblage entityToRemove)
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