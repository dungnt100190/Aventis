using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kiss.Model;
using Kiss.Interfaces.BL;
using KiSS.Common.Exceptions;


namespace Kiss.BL.Wsh
{
    class WshKategorieKbuKontoService : ServiceCRUDBase<WshKategorie_KbuKonto>
    {
        #region Constructors

        private WshKategorieKbuKontoService()
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
        public override WshKategorie_KbuKonto GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKategorie_KbuKonto>(unitOfWork);

            var returnValue = repository
                .Where(kategorie => kategorie.WshKategorie_KbuKontoID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'WshKategorie_KbuKonto' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return returnValue;
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="wshKategorieID"></param>
        /// <param name="kbuKontoID"></param>
        /// <returns>Der Datensatz mit den angegebenen Fremdschlüsseln</returns>
        public WshKategorie_KbuKonto GetByForeignKeys(IUnitOfWork unitOfWork, int wshKategorieID, int kbuKontoID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKategorie_KbuKonto>(unitOfWork);

            var returnValue = repository
                .Where(kategorie => kategorie.WshKategorieID == wshKategorieID && kategorie.KbuKontoID == kbuKontoID)
                .SingleOrDefault();

            if (returnValue != null)
            {
                SetEntityValidator(returnValue);
            }

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return returnValue;
        } 
        
        
        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="wshKategorieID"></param>
        /// <param name="kbuKontoID"></param>
        /// <returns>Der Datensatz mit den angegebenen Fremdschlüsseln</returns>
        public WshKategorie_KbuKonto GetByForeignKeysOrCreate(IUnitOfWork unitOfWork, int wshKategorieID, int kbuKontoID)
        {
            var entry = GetByForeignKeys(unitOfWork, wshKategorieID, kbuKontoID);

            if (entry== null)
            {
                NewData(out entry);
                entry.WshKategorieID = wshKategorieID;
                entry.KbuKontoID = kbuKontoID;
                entry.NurMitSpezialrecht = false;
                SetEntityValidator(entry);
            }

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return entry;
        }



        /// <summary>
        /// Lädt Datensätze aufgrund der Konto-ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public List<WshKategorie_KbuKonto> GetByKontoId(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKategorie_KbuKonto>(unitOfWork);

            var returnValue = repository
                .Where(kategorie => kategorie.KbuKontoID == id)
                .ToList();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'WshKategorie_KbuKonto' found with konto-id: " + id);
            }

            returnValue.ForEach(SetEntityValidator);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return returnValue;
        }

        /// <summary>
        /// Gets all <see cref="WshKategorie"/> entities
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use.</param>
        /// <returns>All assigned <see cref="WshKategorie"/> entities</returns>
        /// <exception cref="EntityNotFoundException">Thrown if no <see cref="WshKategorie"/> with the given id was found.</exception>
        public List<WshKategorie_KbuKonto> GetKontoKategorien(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKategorie_KbuKonto>(unitOfWork);

            var returnValue = repository
                .OrderBy(kategorie => kategorie.KbuKontoID)
                .ToList();

            returnValue.ForEach(SetEntityValidator);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return returnValue;
        }

        #endregion

        #endregion
    }
}
