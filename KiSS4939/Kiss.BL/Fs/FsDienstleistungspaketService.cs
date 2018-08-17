using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.Fs.Validation;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Fs
{
    public class FsDienstleistungspaketService : ServiceCRUDBase<FsDienstleistungspaket>
    {
        #region Constructors

        private FsDienstleistungspaketService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Deletes the <see cref="FsDienstleistungspaket"/> and its releted <see cref="FsDienstleistung_FsDienstleistungspaket"/> mapping data
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/></param>
        /// <param name="dataToDelete">The <see cref="FsDienstleistungspaket"/> to delete</param>
        /// <param name="saveChanges">say if the <see cref="IUnitOfWork"/> has to call the SaveChanges method</param>
        /// <returns>The <see cref="KissServiceResult"/> to tell if the data could be deleted</returns>
        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork, FsDienstleistungspaket dataToDelete, bool saveChanges = true)
        {
            // Validate Delete statically
            KissServiceResult result = IsDeleteAllowed(dataToDelete);

            if (!result)
            {
                return result;
            }

            // Delete the Entity in the DB
            using (var trx = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

                // Delete the adhered mapping data
                var repositoryDl2Dlp = UnitOfWork.GetRepository<FsDienstleistung_FsDienstleistungspaket>(unitOfWork);
                foreach (var itemToDelete in dataToDelete.FsDienstleistung_FsDienstleistungspaket.ToList())
                {
                    itemToDelete.MarkAsDeleted();
                    repositoryDl2Dlp.ApplyChanges(itemToDelete);
                }

                // Now the delete of the item itself
                base.DeleteData(unitOfWork, dataToDelete);

                if(saveChanges)
                {
                    unitOfWork.SaveChanges();
                }

                trx.Complete();
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Get all assigned  <see cref="FsDienstleistung_FsDienstleistungspaket"/> objects of the
        /// given entity <see cref="FsDienstleistungspaket"/>.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use</param>
        /// <param name="fsDienstleistungspaketID">The id of the <see cref="FsDienstleistungspaket"/></param>
        /// <returns></returns>
        public List<FsDienstleistung_FsDienstleistungspaket> GetAssignedDienstleistungRelationen(IUnitOfWork unitOfWork, int fsDienstleistungspaketID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var reporitory = UnitOfWork.GetRepository<FsDienstleistung_FsDienstleistungspaket>(unitOfWork);

            var returnValue = reporitory
                .Where(dlInDlp => dlInDlp.FsDienstleistungspaketID == fsDienstleistungspaketID)
                .Select(dlInDlp => dlInDlp)
                .ToList();

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Gets the assigned <see cref="FsDienstleistung"/> entities of the given <see cref="FsDienstleistungspaket"/> id
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use</param>
        /// <param name="fsDienstleistungspaketID">The id of the <see cref="FsDienstleistungspaket"/></param>
        /// <returns>All assigned <see cref="FsDienstleistung"/> entities of the given <see cref="FsDienstleistungspaket"/></returns>
        /// <exception cref="EntityNotFoundException">Thrown if no <see cref="FsDienstleistungspaket"/> with the given id was found</exception>
        public List<FsDienstleistung> GetAssignedDienstleistungen(IUnitOfWork unitOfWork, int fsDienstleistungspaketID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var reporitory = UnitOfWork.GetRepository<FsDienstleistung_FsDienstleistungspaket>(unitOfWork);

            var returnValue = reporitory
                .Where(dlInDlp => dlInDlp.FsDienstleistungspaketID == fsDienstleistungspaketID)
                .Select(dlInDlp => dlInDlp.FsDienstleistung)
                .ToList();

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override FsDienstleistungspaket GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<FsDienstleistungspaket>(unitOfWork);

            var returnValue = repository
                .Where(paket => paket.FsDienstleistungspaketID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'FsDienstleistungspaket' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Saves the relation between <see cref="FsDienstleistungspaket"/> and <see cref="FsDienstleistung"/>. 
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use</param>
        /// <param name="paket"> <see cref="FsDienstleistungspaket"/></param>
        /// <param name="fsDienstleistungen">List of Dienstleistungen to assign. <see cref="FsDienstleistung"/></param>
        /// <returns></returns>
        public KissServiceResult SaveAssignedDienstleistungen(IUnitOfWork unitOfWork, FsDienstleistungspaket paket, List<FsDienstleistung> fsDienstleistungen)
        {
            using (var trx = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
                var serviceDlDlp = new RelationTableServiceCRUDBase<FsDienstleistung_FsDienstleistungspaket>();

                //Get all assigned dienstleistungen.
                var alreadyAssignedDls = GetAssignedDienstleistungRelationen(unitOfWork, paket.FsDienstleistungspaketID);

                //Create Lists of Ids for both lists (FsDienstleistung_FsDienstleistungspaket and FsDienstleistung).
                var alreadyAssignedDlIds = new List<int>();
                alreadyAssignedDls.ForEach(dldlp => alreadyAssignedDlIds.Add(dldlp.FsDienstleistungID));

                var fsDienstleistungenIds = new List<int>();
                fsDienstleistungen.ForEach(dl => fsDienstleistungenIds.Add(dl.FsDienstleistungID));

                //Remove all existing relations not used any more.
                foreach (var relation in alreadyAssignedDls.Where(dldlp => !fsDienstleistungenIds.Contains(dldlp.FsDienstleistungID)))
                {
                    serviceDlDlp.DeleteData(unitOfWork, relation);
                }

                //Add relations that do not alerady exist
                foreach (var dienstleistung in fsDienstleistungen.Where(dl => !alreadyAssignedDlIds.Contains(dl.FsDienstleistungID)))
                {
                    FsDienstleistung_FsDienstleistungspaket relation;
                    serviceDlDlp.NewData(out relation);
                    relation.FsDienstleistungspaketID = paket.FsDienstleistungspaketID;
                    relation.FsDienstleistungID = dienstleistung.FsDienstleistungID;
                    serviceDlDlp.SaveData(unitOfWork, relation);
                }

                unitOfWork.SaveChanges();
                trx.Complete();
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Validates the given entity in memory
        /// </summary>
        /// <param name="dataToValidate">The entity to validate</param>
        /// <returns>The service result of the validation</returns>
        public override KissServiceResult ValidateInMemory(FsDienstleistungspaket dataToValidate)
        {
            // Validation: Check if Entity is consistent in itself
            var serviceResult = FsDienstleistungspaketValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}