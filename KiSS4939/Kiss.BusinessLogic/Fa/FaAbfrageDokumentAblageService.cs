using System.Collections.Generic;

using Kiss.DataAccess.Interfaces;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Fa
{
    public class FaAbfrageDokumentAblageService : Service
    {
        #region Constructors

        private FaAbfrageDokumentAblageService()
        {
        }

        #endregion Constructors

        #region Methods

        #region Public Methods

        public IServiceResult<IEnumerable<FaDokumentAblageDTO>> RunQuery(FaDokumentAblageSearchParamDto searchParameters)
        {
            return RunQueryDokumentAblage(searchParameters);
        }

        private IServiceResult<IEnumerable<FaDokumentAblageDTO>> RunQueryDokumentAblage(FaDokumentAblageSearchParamDto searchParams)
        {
            var result = new ServiceResult<IEnumerable<FaDokumentAblageDTO>>(ServiceResultType.Ok);

            var datumVon = searchParams.DokumentDatumVon;
            var datumBis = searchParams.DokumentDatumBis;

            if (datumVon > datumBis)
            {
                result.AddEntry(ServiceResultType.Error, "Das VON-Datum darf nicht grösser als das BIS-Datum sein.");
                return result;
            }

            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                result.Result = unitOfWork.FaDokumentAblage.GetDtoList(searchParams);
            }

            return result;
        }

        #endregion Public Methods

        #endregion Methods
    }
}