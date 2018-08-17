using System.Linq;

using Kiss.BL.Fs.Validation;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Fs
{
    /// <summary>
    /// Service to manage an FsReduktion
    /// </summary>
    public class FsReduktionService : ServiceCRUDBase<FsReduktion>
    {
        #region Constructors

        private FsReduktionService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override FsReduktion GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<FsReduktion>(unitOfWork);

            var returnValue = repository
                .Where(reduktion => reduktion.FsReduktionID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'FsReduktion' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public override KissServiceResult ValidateInMemory(FsReduktion dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var serviceResult = FsReduktionValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}