using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

using Kiss.BL.Ba.Validation;
using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

using KiSS.Common.Exceptions;

using Kiss.Model.DTO.BA;
using Kiss.Infrastructure.Constant;

namespace Kiss.BL.Ba
{
    /// <summary>
    /// Service to manage a person
    /// </summary>
    public class BaPersonService : ServiceCRUDBase<BaPerson>
    {
        #region Constructors

        private BaPersonService()
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
        public override BaPerson GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BaPerson>(unitOfWork);

            var returnValue = repository
                .Where(x => x.BaPersonID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'BaPerson' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Gets the <see cref="BaPerson"/> entity with the given ID. Includling its addresses (<see cref="TrackableCollection{BaAdresse}"/>)
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/> to get the <see cref="IRepository{T}"/> from or create a new one if it's <c>null</c></param>
        /// <param name="id">Person's ID</param>
        /// <returns><see cref="BaPerson"/> with the given ID or <c>null</c> if it doesn't exists</returns>
        public BaPerson GetByIdWithBaAdresse(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var reporitory = UnitOfWork.GetRepository<BaPerson>(unitOfWork);

            var returnValue = reporitory
                .Include(x => x.BaAdresse)
                .Where(x => x.BaPersonID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no person found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork, BaPerson dataToSave)
        {
            //New history version
            SystemService.NewHistoryVersion(unitOfWork);

            return base.SaveData(unitOfWork, dataToSave);
        }

        public ObservableCollection<BaPerson> Search(IUnitOfWork unitOfWork, string searchName)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BaPerson>(unitOfWork);

            var result = (from person in repository
                          where searchName == null || person.Name.Contains(searchName)
                          select person).ToList();

            result.ForEach(SetEntityValidator);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return new ObservableCollection<BaPerson>(result);
        }

        ////public List<WshKlientDTO> SearchWshKlient(IUnitOfWork unitOfWork, string searchString)
        ////{
        ////    unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

        ////    int faFallId;
        ////    if(int.TryParse(searchString, out faFallId))
        ////    {
        ////        return SearchWshKlient(unitOfWork, faFallId);
        ////    }

        ////    var personRepository = UnitOfWork.GetRepository<BaPerson>(unitOfWork);
        ////    var result = personRepository
        ////        .WhereNameVornameContains(searchString)
        ////        .SelectMany(p => p.WshHaushaltPerson)
        ////        .Where(hp => (hp.DatumVon ?? DateTime.Today) <= DateTime.Today)
        ////        .Where(hp => (hp.DatumBis ?? DateTime.Today) >= DateTime.Today)
        ////        .Where(hp => hp.FaLeistung.FaProzessCode == (int)LOVsGenerated.FaProzess.Existenzsicherung || hp.FaLeistung.FaProzessCode == (int)LOVsGenerated.FaProzess.Platzierung)
        ////        .Select(hp => new WshKlientDTO
        ////        {
        ////            FaLeistung = hp.FaLeistung,
        ////            FaFall = hp.FaLeistung.FaFall,
        ////            Falltraeger = hp.FaLeistung.FaFall.BaPerson,
        ////            WshHaushaltPerson = hp.BaPerson != hp.FaLeistung.FaFall.BaPerson ? hp.BaPerson : null,
        ////        })
        ////        .OrderBy(k => k.Falltraeger.Name)
        ////        .ThenBy(k => k.Falltraeger.Vorname)
        ////        .ThenBy(k => k.WshHaushaltPerson.Name)
        ////        .ThenBy(k => k.WshHaushaltPerson.Vorname);
        ////    return result.ToList();
        ////}

        ////private List<WshKlientDTO> SearchWshKlient(IUnitOfWork unitOfWork, int faFallId)
        ////{
        ////    var fallRepository = UnitOfWork.GetRepository<FaFall>(unitOfWork);
        ////    return fallRepository
        ////        .Where(f => f.FaFallID == faFallId)
        ////        .Include(f => f.BaPerson)
        ////        .Include(f => f.FaLeistung)
        ////        .Select(f => new WshKlientDTO
        ////        {
        ////            FaLeistung = f.FaLeistung.FirstOrDefault(),
        ////            FaFall = f,
        ////            Falltraeger = f.BaPerson,
        ////            WshHaushaltPerson = null,
        ////        }).Distinct()
        ////        .ToList();
        ////}

        // TODO: Beispiel für denormalisierte Suche von Personen mit Adressen
        //public ObservableCollection<SearchPersonAdresseDTO> SearchWithAdresse(IUnitOfWork unitOfWork, string searchPersonName)
        //{
        //    unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
        //    // Do the search, but return it as an not yet evaluated IQueryable
        //    IQueryable<BaPerson> queryablePersons = SearchWithAdresseAsQueryable(unitOfWork, searchPersonName);
        //    // Projection / denormalisation into a List of DTOs
        //    IEnumerable<SearchPersonAdresseDTO> query =
        //                from person in queryablePersons
        //                from adresse in person.BaAdresse
        //                select new SearchPersonAdresseDTO
        //                        {
        //                            BaPerson = person,
        //                            Strasse = adresse.Strasse,
        //                            BaAdresseDatumVon = adresse.DatumVon
        //                        };
        //    // Fill the Data into an ObservableCollection => This will also evaluate the query and create the Entities in Memory
        //    ObservableCollection<SearchPersonAdresseDTO> result = new ObservableCollection<SearchPersonAdresseDTO>(query);
        //    // Start Tracking Changes
        //    unitOfWork.StartTrackingAndMarkAsUnchangedAll();
        //    return result;
        //}
        //private IQueryable<BaPerson> SearchWithAdresseAsQueryable(IUnitOfWork unitOfWork, string searchPersonName)
        //{
        //    unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
        //    var repository = UnitOfWork.GetRepository<BaPerson>(unitOfWork);
        //    IQueryable<BaPerson> result = repository
        //        .Include(x => x.BaAdresse)
        //        .WhereIf(searchPersonName != null, x => x.Name.Contains(searchPersonName));
        //    return result;
        //}
        public override KissServiceResult ValidateInMemory(BaPerson dataToValidate)
        {
            var serviceResult = BaPersonValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}