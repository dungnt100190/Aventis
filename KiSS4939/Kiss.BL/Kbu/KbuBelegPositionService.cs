using System.Linq;

using Kiss.BL.Kbu.Validation;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class KbuBelegPositionService : ServiceCRUDBase<KbuBelegPosition>
    {
        #region Constructors

        private KbuBelegPositionService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Lädt einen Datensatz aufgrund der KbuBeleg-ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="kbuBelegId">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public IQueryable<KbuBelegPosition> GetByBelegId(IUnitOfWork unitOfWork, int kbuBelegId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);

            var returnValue = repository
                .Where(entity => entity.KbuBelegID == kbuBelegId);

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbBeleg' found with id: " + kbuBelegId);
            }

            //SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override KbuBelegPosition GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);

            var returnValue = repository
                .Where(entity => entity.KbuBelegPositionID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbBeleg' found with id: " + id);
            }

            //SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public override KissServiceResult ValidateInMemory(KbuBelegPosition dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var validator = new KbuBelegPositionValidator();
            var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}