using System.Linq;

using Kiss.BL.Wsh.Validation;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage a WshGrundbudgetPositionDebitor.
    /// </summary>
    internal class WshGrundbudgetPositionDebitorService : ServiceCRUDBase<WshGrundbudgetPositionDebitor>
    {
        #region Constructors

        private WshGrundbudgetPositionDebitorService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Löscht alle WshGrundBudgetPositionDebitor der GrundbudgetPosition.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionId"></param>
        /// <returns>True wenn mindestens ein WshGrundBudgetPositionDebitor gelöscht worden ist. False sonst.</returns>
        public bool DeleteDebitor(IUnitOfWork unitOfWork, int positionId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPositionDebitor>(unitOfWork);

            var query = from x in repository
                        where x.WshGrundbudgetPositionID == positionId
                        select x;

            var list = query.ToList();

            list.ForEach(x => x.MarkAsDeleted());
            list.ForEach(repository.ApplyChanges);
            unitOfWork.SaveChanges();

            return list.Count > 0;
        }

        public override WshGrundbudgetPositionDebitor GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPositionDebitor>(unitOfWork);

            var returnValue = repository
                .Where(x => x.WshGrundbudgetPositionDebitorID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'WshGrundbudgetPositionDebitor' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Holt den Debitor anhand der Positions-ID.
        /// Zwischen Debitor und Grundbudgetposition ist zur Zeit eine 1 zu 1 Beziehung.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionID"></param>
        /// <returns>Debitor. Null, wenn die Position keinen Debitor angehängt hat.</returns>
        public WshGrundbudgetPositionDebitor GetByPositionId(IUnitOfWork unitOfWork, int positionID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPositionDebitor>(unitOfWork);

            var query = from x in repository
                        where x.WshGrundbudgetPositionID == positionID
                        select x;

            var debitor = query.SingleOrDefault();

            if (debitor != null)
            {
                SetEntityValidator(debitor);
                unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            }

            return debitor;
        }

        /// <summary>
        /// Sets the modifier and validates the entity.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="debitor"></param>
        /// <returns></returns>
        public KissServiceResult ValidateAndInit(IUnitOfWork unitOfWork, WshGrundbudgetPositionDebitor debitor)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            SetModifier(debitor);

            var result = ValidateInMemory(debitor);
            result += ValidateOnDatabase(unitOfWork, debitor);

            return result;
        }

        public override KissServiceResult ValidateInMemory(WshGrundbudgetPositionDebitor dataToValidate)
        {
            var serviceResult = WshGrundbudgetPositionDebitorValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}