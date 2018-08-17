using System.Linq;

using Kiss.BL.Kbu.Validation;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class KbuBelegDebitorService : ServiceCRUDBase<KbuBelegDebitor>
    {
        #region Constructors

        private KbuBelegDebitorService()
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
        public override KbuBelegDebitor GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            IRepository<KbuBelegDebitor> repository = UnitOfWork.GetRepository<KbuBelegDebitor>(unitOfWork);

            KbuBelegDebitor returnValue = repository
                .Where(entity => entity.KbuBelegDebitorID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbuBelegDebitor' found with id: " + id);
            }

            //SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Holt den KbuBelegDebitor.
        /// Folgende Relationen werden eager geladen:
        /// -> BaInstitution
        /// -> BaPerson
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kbuBelegId"></param>
        /// <returns></returns>
        public KbuBelegDebitor GetByKbuBelegId(IUnitOfWork unitOfWork, int kbuBelegId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            IRepository<KbuBelegDebitor> repository = UnitOfWork.GetRepository<KbuBelegDebitor>(unitOfWork);

            KbuBelegDebitor returnValue = repository
                .Include(x => x.BaInstitution)
                .Include(x => x.BaPerson)
                .Where(entity => entity.KbuBelegID == kbuBelegId)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbuBelegDebitor' found with kbuBelegId: " + kbuBelegId);
            }

            //SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }


        /// <summary>
        /// Holt den KbuBelegDebitor.
        /// Folgende Relationen werden eager geladen:
        /// -> BaInstitution
        /// -> BaPerson
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kbuBelegId"></param>
        /// <returns></returns>
        public KbuBelegDebitor GetByKbuBelegIdOrCreate(IUnitOfWork unitOfWork, int kbuBelegId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuBelegDebitor>(unitOfWork);

            var debitor = repository.FirstOrDefault(deb => deb.KbuBelegID == kbuBelegId);
            if( debitor == null)
            {
                NewData(out debitor);
                debitor.KbuBelegID = kbuBelegId;
                SaveData(unitOfWork, debitor);
            }

            return GetByKbuBelegId(unitOfWork, kbuBelegId);
        }

        public override KissServiceResult ValidateInMemory(KbuBelegDebitor dataToValidate)
        {
            // validation: check if entity is consistent in itself

            var validator = new KbuBelegDebitorValidator();
            var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}