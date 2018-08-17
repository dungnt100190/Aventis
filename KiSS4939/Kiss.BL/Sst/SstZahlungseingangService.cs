using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Sst
{
    /// <summary>
    /// Service to manage a SstZahlungseingang.
    /// </summary>
    public class SstZahlungseingangService : ServiceCRUDBase<SstZahlungseingang>
    {
        #region Constructors

        private SstZahlungseingangService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override SstZahlungseingang GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<SstZahlungseingang>(unitOfWork);

            var result = repository.Include(x => x.SstZahlungseingangLauf).SingleOrDefault(x => x.SstZahlungseingangID == id);

            if (result == null)
            {
                throw new EntityNotFoundException("No entity of type 'SstZahlungseingang' found with id: " + id);
            }

            SetEntityValidator(result);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return result;
        }

        #endregion

        #endregion
    }
}