using System.Linq;

using Kiss.BL.Wsh.Validation;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage a WshGrundbudgetPositionKreditor
    /// </summary>
    internal class WshGrundbudgetPositionKreditorService : ServiceCRUDBase<WshGrundbudgetPositionKreditor>
    {
        #region Constructors

        private WshGrundbudgetPositionKreditorService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Löscht alle WshGrundBudgetPositionKreditor der GrundbudgetPosition.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionId"></param>
        /// <returns>True wenn mindestens ein WshGrundBudgetPositionKreditor gelöscht worden ist. False sonst.</returns>
        public bool DeleteKreditor(IUnitOfWork unitOfWork, int positionId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);

            var query = from x in repository
                        where x.WshGrundbudgetPositionID == positionId
                        select x;

            var list = query.ToList();

            list.ForEach(x => x.MarkAsDeleted());
            list.ForEach(repository.ApplyChanges);
            unitOfWork.SaveChanges();

            return list.Count > 0;
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override WshGrundbudgetPositionKreditor GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);

            var returnValue = repository
                .Where(x => x.WshGrundbudgetPositionKreditorID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'WshGrundbudgetPositionKreditor' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Hohlt den Kreditor anhand der Positionsid.
        /// Zwischen Kreditor und Grundbudgetposition ist zur Zeit eine 1 zu 1 Beziehung.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionID"></param>
        /// <returns>Kreditor. null, wenn die Position keinen Kreditor angehängt hat.</returns>
        public WshGrundbudgetPositionKreditor GetByPositionId(IUnitOfWork unitOfWork, int positionID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);

            var query = from x in repository
                        where x.WshGrundbudgetPositionID == positionID
                        select x;

            var kreditor = query.SingleOrDefault();

            if (kreditor != null)
            {
                SetEntityValidator(kreditor);
                unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            }

            return kreditor;
        }

        /// <summary>
        /// Sets the modifier and validates the entity.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kreditor"></param>
        /// <returns></returns>
        public KissServiceResult ValidateAndInit(IUnitOfWork unitOfWork, WshGrundbudgetPositionKreditor kreditor)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            SetModifier(kreditor);

            var result = ValidateInMemory(kreditor);
            result += ValidateOnDatabase(unitOfWork, kreditor);

            return result;
        }

        public override KissServiceResult ValidateInMemory(WshGrundbudgetPositionKreditor dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var serviceResult = WshGrundbudgetPositionKreditorValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}