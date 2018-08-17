using System;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Kbu
{
    interface IKbuBelegVerbuchenPlugin
    {
        #region Methods

        KissServiceResult ValidateBeleg(IUnitOfWork unitOfWork, KbuBeleg beleg, DateTime valutaDatum);

        void VerbucheBeleg(IUnitOfWork unitOfWork, KbuBeleg beleg, DateTime valutaDatum);

        #endregion
    }
}