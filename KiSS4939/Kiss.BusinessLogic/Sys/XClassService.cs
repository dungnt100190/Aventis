using System.Collections.Generic;

using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

namespace Kiss.BusinessLogic.Sys
{
    /// <summary>
    /// Service to manage a person
    /// </summary>
    public class XClassService : Service
    {
        #region Constructors

        private XClassService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public IList<XClass> GetWpfViews()
        {
            using (var uow = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return uow.XClass.GetAllWpfViews();
            }
        }

        #endregion

        #endregion
    }
}