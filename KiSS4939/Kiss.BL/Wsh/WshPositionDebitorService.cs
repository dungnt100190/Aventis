using System.Linq;

using Kiss.BL.Wsh.Validation;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage a WshPositionDebitor.
    /// </summary>
    public class WshPositionDebitorService : ServiceCRUDBase<WshPositionDebitor>
    {
        #region Constructors

        private WshPositionDebitorService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Löscht alle WshPositionDebitor der Position.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionId"></param>
        /// <returns>True wenn mindestens ein WshPositionDebitor gelöscht worden ist. False sonst.</returns>
        public bool DeleteDebitor(IUnitOfWork unitOfWork, int positionId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPositionDebitor>(unitOfWork);

            var query = from x in repository
                        where x.WshPositionID == positionId
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
        public override WshPositionDebitor GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPositionDebitor>(unitOfWork);

            var returnValue = repository
                .Where(x => x.WshPositionDebitorID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("No entity of 'WshPositionDebitor' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Hohlt den Debitor anhand der Positionsid.
        /// Zwischen Debitor und Position ist zur Zeit eine 1 zu 1 Beziehung.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionId"></param>
        /// <returns>Debitor. null, wenn die Position keinen Debitor angehängt hat.</returns>
        public WshPositionDebitor GetByPositionId(IUnitOfWork unitOfWork, int positionId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPositionDebitor>(unitOfWork);

            var query = from x in repository
                        where x.WshPositionID == positionId
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
        public KissServiceResult ValidateAndInit(IUnitOfWork unitOfWork, WshPositionDebitor debitor)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            SetModifier(debitor);

            var result = ValidateInMemory(debitor);
            result += ValidateOnDatabase(unitOfWork, debitor);

            return result;
        }

        public override KissServiceResult ValidateInMemory(WshPositionDebitor dataToValidate)
        {
            var serviceResult = WshPositionDebitorValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}