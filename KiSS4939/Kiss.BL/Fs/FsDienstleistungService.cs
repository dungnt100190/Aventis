using System.Linq;

using Kiss.BL.Fs.Validation;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Fs
{
    /// <summary>
    /// Service to manage an FaDienstleistung
    /// </summary>
    public class FsDienstleistungService : ServiceCRUDBase<FsDienstleistung>
    {
        #region Constructors

        private FsDienstleistungService()
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
        public override FsDienstleistung GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);

            var returnValue = repository
                .Where(dienstleistung => dienstleistung.FsDienstleistungID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'FsDienstleistung' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public override KissServiceResult ValidateInMemory(FsDienstleistung dataToValidate)
        {
            // Validation: Check if Entity is consistent in itself
            var serviceResult = FsDienstleistungValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion

        #region Other

        //public ObservableCollection<FsDienstleistung> GetWithDlp(IUnitOfWork unitOfWork)
        //{
        //    unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
        //    var repository = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
        //    var ret = from dl in repository
        //                  .Include(d => d.FaDienstleistung2Dlp)
        //                  .Include(d => d.FaDienstleistung2Dlp.SubInclude(dlp => dlp.FsDienstleistung))
        //              select dl;
        //    ObservableCollection<FsDienstleistung> list = new ObservableCollection<FsDienstleistung>(ret);
        //    unitOfWork.StartTrackingAndMarkAsUnchangedAll();
        //    return list;
        //}

        #endregion
    }
}