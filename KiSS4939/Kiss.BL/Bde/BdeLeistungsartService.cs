using System.Linq;

using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Bde
{
    /// <summary>
    /// Service to manage a "BDELeistungsart".
    /// </summary>
    public class BdeLeistungsartService : ServiceCRUDBase<BDELeistungsart>
    {
        #region Constructors

        private BdeLeistungsartService()
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
        public override BDELeistungsart GetById(Interfaces.BL.IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BDELeistungsart>(unitOfWork);

            var returnValue = repository
                .Where(bdeLeistungsart => bdeLeistungsart.BDELeistungsartID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'BDELeistungsart' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        #endregion

        #endregion
    }
}