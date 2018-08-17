using System.Linq;

using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

using KiSS.Common.Exceptions;
using System;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage a WshAbzug entity.
    /// </summary>
    [UsableBy(typeof(WshAbzugDTOService))]
    internal class WshAbzugService : ServiceCRUDBase<WshAbzug>
    {
        #region Constructors

        private WshAbzugService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork, WshAbzug dataToSave, bool acceptChanges)
        {
            //make sure, we rather store null than empty-string
            if (string.IsNullOrWhiteSpace(dataToSave.AbschlussGrund))
            {
                dataToSave.AbschlussGrund = null;
            }

            return base.SaveData(unitOfWork, dataToSave, acceptChanges);
        }

        public override WshAbzug GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repo = UnitOfWork.GetRepository<WshAbzug>(unitOfWork);

            var result = repo
                .Include(x => x.WshGrundbudgetPosition)
                .SingleOrDefault(x => x.WshAbzugID == id);

            if (result == null)
            {
                throw new EntityNotFoundException("WshAbzug with ID " + id + " not found.");
            }

            SetEntityValidator(result);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return result;
        }

        public WshAbzug GetByWshGrundbudgetPositionId(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repo = UnitOfWork.GetRepository<WshAbzug>(unitOfWork);

            var result = repo
                .Include(x => x.WshGrundbudgetPosition)
                .SingleOrDefault(x => x.WshGrundbudgetPositionID == id);

            SetEntityValidator(result);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return result;
        }

        public override KissServiceResult ValidateInMemory(WshAbzug dataToValidate)
        {
            var result = WshAbzugValidator.ValidateEntity(dataToValidate);
            return result + base.ValidateInMemory(dataToValidate);
        }

        public override KissServiceResult ValidateOnDatabase(IUnitOfWork unitOfWork, WshAbzug dataToValidate)
        {
            // Get new UnitOfWork due to errors
            var uow = UnitOfWork.GetNew;

            if (dataToValidate.ChangeTracker.State == ObjectState.Modified)
            {
                // Get old data
                var repository = UnitOfWork.GetRepository<WshAbzug>(uow);
                var originalAbzug = repository.FirstOrDefault(x => x.WshAbzugID == dataToValidate.WshAbzugID);

                if (originalAbzug != null)
                {
                    // Abschluss-Daten wurden geändert, nur fortfahren, wenn keine grünen Positionen existieren
                    var positionSvc = Container.Resolve<WshGrundbudgetPositionService>();

                    if (originalAbzug.AbschlussDatum != dataToValidate.AbschlussDatum ||
                     originalAbzug.AbschlussGrund != dataToValidate.AbschlussGrund ||
                     originalAbzug.WshAbzugAbschlussAktionCode != dataToValidate.WshAbzugAbschlussAktionCode)
                    {
                        var freigegebene = positionSvc.DoDependingPositionsExist(
                            uow,
                            originalAbzug.WshGrundbudgetPositionID,
                            WshPositionsstatus.Freigegeben);

                        if (freigegebene)
                        {
                            return new KissServiceResult(
                                KissServiceResult.ResultType.Error,
                                "WshAbzugService_CannotChangeData",
                                "Es existieren noch freigegebene Positionen.");
                        }
                    }

                    if (originalAbzug.AbschlussDatum != dataToValidate.AbschlussDatum)
                    {
                        DateTime? firstNonGrayPosition;
                        DateTime? lastNonGrayPosition;
                        positionSvc.AreAllDependingPositionsGray(unitOfWork, dataToValidate.WshGrundbudgetPositionID, out firstNonGrayPosition, out lastNonGrayPosition);
                        if (dataToValidate.AbschlussDatum < lastNonGrayPosition)
                        {
                            return new KissServiceResult(
                                KissServiceResult.ResultType.Error,
                                "WshAbzugService_CannotChangeData",
                                "Es existieren bereits verbuchte Positionen nach dem Abschlussdatum.");
                        }
                    }
                }
            }

            return base.ValidateOnDatabase(unitOfWork, dataToValidate);
        }

        #endregion

        #endregion
    }
}