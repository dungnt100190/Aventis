using System;
using System.Collections.Generic;
using Kiss.BL;
using Kiss.BusinessLogic.LocalResources.System;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

using Kiss.DbContext;

using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Kes
{
    /// <summary>
    /// Service to manage a TEntity.
    /// </summary>
    public class KesBehoerdeService : ServiceCRUD<KesBehoerde>
    {
        #region Constructors

        private KesBehoerdeService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public List<KesBehoerde> SearchKesBehoerde(string searchString, string kanton = "")
        {
            List<KesBehoerde> kesBehoerdes;

            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                kesBehoerdes = unitOfWork.KesBehoerde.FindBehoerdeBySearchParams(searchString, kanton);
            }

            return kesBehoerdes;
        }

        #endregion

        #endregion
    }
}