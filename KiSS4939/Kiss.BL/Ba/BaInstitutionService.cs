using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Ba
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class BaInstitutionService : ServiceCRUDBase<BaInstitution>
    {
        #region Constructors

        private BaInstitutionService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gets the <see cref="BaPerson"/> entity with the given ID
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/> to get the <see cref="IRepository{T}"/> from or create a new one if it's <c>null</c></param>
        /// <param name="id">Person's ID</param>
        /// <returns><see cref="BaPerson"/> with the given ID or <c>null</c> if it doesn't exists</returns>
        public override BaInstitution GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BaInstitution>(unitOfWork);

            var returnValue = repository
                .Where(x => x.BaInstitutionID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'BaInstitution' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public override KissServiceResult ValidateInMemory(BaInstitution dataToValidate)
        {
            // validation: check if entity is consistent in itself
            /*
            var validator = new BaInstitution();
            var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));

            return serviceResult + base.ValidateInMemory(dataToValidate);
             * */
            return KissServiceResult.Ok();
        }

        #endregion

        #endregion
    }
}