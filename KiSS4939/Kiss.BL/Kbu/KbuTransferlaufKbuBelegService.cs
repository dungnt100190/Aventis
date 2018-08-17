using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class KbuTransferlaufKbuBelegService : ServiceCRUDBase<KbuTransferlauf_KbuBeleg>
    {
        #region Constructors

        private KbuTransferlaufKbuBelegService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public IList<int> GetBelegIDsOfTransferlauf(IUnitOfWork unitOfWork, int kbuTransferlaufID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuTransferlauf_KbuBeleg>(unitOfWork);

            var idList = repository
                .Where(transferlaufBeleg => transferlaufBeleg.KbuTransferlaufID == kbuTransferlaufID)
                .Select(transferlaufBeleg => transferlaufBeleg.KbuBelegID)
                .ToArray();

            return idList;
        }

        public override KbuTransferlauf_KbuBeleg GetById(IUnitOfWork unitOfWork, int id)
        {
            return null;
        }

        public KbuTransferlauf_KbuBeleg GetByTransferlaufIDAndBelegID(IUnitOfWork unitOfWork, int kbuTransferlaufID, int kbuBelegID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuTransferlauf_KbuBeleg>(unitOfWork);

            var entity = repository
                         .Where(transferlaufBeleg => transferlaufBeleg.KbuTransferlaufID == kbuTransferlaufID && transferlaufBeleg.KbuBelegID == kbuBelegID)
                         .SingleOrDefault();

            //SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return entity;
        }

        public KissServiceResult SaveTransferResult(IUnitOfWork unitOfWork, int kbuTransferlaufID, int kbuBelegId, string errorMsg)
        {
            var transferlaufBeleg = GetByTransferlaufIDAndBelegID(unitOfWork, kbuTransferlaufID, kbuBelegId);
            transferlaufBeleg.TransferZeitpunkt = DateTime.Now;
            transferlaufBeleg.Fehlermeldung = errorMsg;

            return base.SaveData(unitOfWork, transferlaufBeleg);
        }

        public override KissServiceResult ValidateInMemory(KbuTransferlauf_KbuBeleg dataToValidate)
        {
            // validation: check if entity is consistent in itself
            //var validator = new TValidator();
            //var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));

            //return serviceResult + base.ValidateInMemory(dataToValidate);
            return base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}