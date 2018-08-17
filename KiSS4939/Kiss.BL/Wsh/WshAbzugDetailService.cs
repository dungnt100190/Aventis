using System;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.Wsh.Validation;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage a WshAbzugDetail entity.
    /// </summary>
    [UsableBy(typeof(WshAbzugDetailDTOService))]
    internal class WshAbzugDetailService : ServiceCRUDBase<WshAbzugDetail>
    {
        #region Constructors

        private WshAbzugDetailService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override WshAbzugDetail GetById(IUnitOfWork unitOfWork, int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<WshAbzugDetail> GetByWshAbzugId(IUnitOfWork unitOfWork, int wshAbzugId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshAbzugDetail>(unitOfWork);

            var result = repository.Where(x => x.WshAbzugID == wshAbzugId).ToList();

            return new ObservableCollection<WshAbzugDetail>(result);
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork, WshAbzugDetail dataToSave)
        {
            // Wenn BaPersoID kleiner als null ist, dann bedeutet das keine Auswahl.
            if (dataToSave.BaPersonID <= 0)
            {
                dataToSave.BaPerson = null;
                dataToSave.BaPersonID = null;
            }

            return base.SaveData(unitOfWork, dataToSave);
        }

        public override KissServiceResult ValidateInMemory(WshAbzugDetail dataToValidate)
        {
            var serviceResult = WshAbzugDetailValidator.ValidateEntity(dataToValidate);
            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}