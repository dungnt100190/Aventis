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
    public class KbuBelegKreditorService : ServiceCRUDBase<KbuBelegKreditor>
    {
        #region Constructors

        private KbuBelegKreditorService()
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
        public override KbuBelegKreditor GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            IRepository<KbuBelegKreditor> repository = UnitOfWork.GetRepository<KbuBelegKreditor>(unitOfWork);

            KbuBelegKreditor returnValue = repository
                .Where(entity => entity.KbuBelegKreditorID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbBeleg' found with id: " + id);
            }

            //SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Hohlt den KbuBelegKreditor.
        /// Folgende Relationen werden eager geladen:
        /// -> BaZahlungsweg
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kbuBelegKreditorId"></param>
        /// <returns></returns>
        public KbuBelegKreditor GetByKbuBelegId(IUnitOfWork unitOfWork, int kbuBelegKreditorId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            IRepository<KbuBelegKreditor> repository = UnitOfWork.GetRepository<KbuBelegKreditor>(unitOfWork);

            KbuBelegKreditor returnValue = repository
                .Include(x => x.BaZahlungsweg.SubInclude(zw => zw.BaBank))
                .Where(entity => entity.KbuBelegID == kbuBelegKreditorId)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbBelegKreditor' found with kbuBelegKreditorID: " + kbuBelegKreditorId);
            }

            //SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public override KissServiceResult ValidateInMemory(KbuBelegKreditor dataToValidate)
        {
            // validation: check if entity is consistent in itself

            var validator = new KbuBelegKreditorValidator();
            var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}