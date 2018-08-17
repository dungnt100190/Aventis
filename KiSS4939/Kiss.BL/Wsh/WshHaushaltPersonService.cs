using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.Ba;
using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.BL.Wsh;
using Kiss.Interfaces.IoC;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class WshHaushaltPersonService : ServiceCRUDBase<WshHaushaltPerson>
    {
        #region Constructors

        private WshHaushaltPersonService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Siehe CreateHaushaltFromWohnsituation.
        /// Diese Version ist für den Standard.
        /// Wenn eine Person im Klientensystem amgleichen Ort wohnt (BaAdresse),
        /// dann wird sie in WshWohnsituation eingefügt.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="leistung"></param>
        /// <returns></returns>
        public KissServiceResult CreateHaushaltFromAdresse(IUnitOfWork unitOfWork, FaLeistung leistung)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //Personen vom Klientensystem holen.
            BaKlientensystemService klientensystemService = Container.Resolve<BaKlientensystemService>();
            List<BaPerson> personenKlientenSystem = klientensystemService.GetKlientensystemByFaLeistungId(unitOfWork, leistung.FaLeistungID);

            //Adresse vom Leistngsträger holen.
            BaAdresseService adresseService = Container.Resolve<BaAdresseService>();
            BaAdresse adresseLeistungstraeger = adresseService.GetByBaPersonId(unitOfWork, leistung.BaPersonID, DateTime.Today);

            //Über das Klientensystem iterieren und WshHaushalt einfügen.
            foreach (BaPerson person in personenKlientenSystem)
            {
                BaAdresse adressePerson = adresseService.GetByBaPersonId(unitOfWork, person.BaPersonID, DateTime.Now);
                if (adresseService.IsSameAddress(adressePerson, adresseLeistungstraeger))
                {
                    InsertWshHaushalt(unitOfWork, leistung, person);
                }
            }

            unitOfWork.SaveChanges();

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Eine neue WshHaushaltPerson wird mit der aktuellen Wohnsituation aus Modul B zum Zeitpunkt des 
        /// Eröffnungsdatums erstellt und das Flag "Unterstützt" wird automatisch aus den Basisdaten
        /// gesetzt. Eröffnungsdatum ist Systemdatum. Diese Version ist für ZH.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="leistung"></param>
        /// <returns></returns>
        public KissServiceResult CreateHaushaltFromWohnsituation(IUnitOfWork unitOfWork, FaLeistung leistung)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //Personen von der Wohnsituation holen.
            BaWohnsituationService wohnsituationService = Container.Resolve<BaWohnsituationService>();
            List<BaPerson> personenWohnsituation;
            KissServiceResult result = wohnsituationService.GetPersonenInWohnsituation(unitOfWork, leistung.BaPersonID, out personenWohnsituation);
            if (!result.IsOk)
            {
                return result;
            }

            //Personen vom Klientensystem holen.
            BaKlientensystemService klientensystemService = Container.Resolve<BaKlientensystemService>();
            List<BaPerson> personenKlientenSystem = klientensystemService.GetKlientensystemByFaLeistungId(unitOfWork, leistung.FaLeistungID);

            //Schnittmenge der beiden listen bilden.
            List<BaPerson> intersection = personenKlientenSystem.Intersect(personenWohnsituation).ToList();

            if (intersection.Count > 0)
            {
                foreach (var person in intersection)
                {
                    InsertWshHaushalt(unitOfWork, leistung, person);
                }
            }
            else
            {
                BaPerson leistungstraeger = leistung.BaPerson ?? Container.Resolve<BaPersonService>().GetById(unitOfWork, leistung.BaPersonID);
                InsertWshHaushalt(unitOfWork, leistung, leistungstraeger);
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override WshHaushaltPerson GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);

            var returnValue = repository
                .Where(person => person.WshHaushaltPersonID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'WshHaushaltPerson' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Gets all <see cref="WshHaushaltPerson"/> entities of the given <see cref="FaLeistung"/> id
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use.</param>
        /// <param name="faLeistungID">The id of the <see cref="FaLeistung"/>.</param>
        /// <returns>All assigned <see cref="WshHaushaltPerson"/> entities of the given <see cref="FaLeistung"/> id.</returns>
        /// <exception cref="EntityNotFoundException">Thrown if no <see cref="WshHaushaltPerson"/> with the given id was found.</exception>
        public List<WshHaushaltPerson> GetHaushaltPersonen(IUnitOfWork unitOfWork, int faLeistungID)
        {
            return GetHaushaltPersonen(unitOfWork, faLeistungID, false);
        }

        /// <summary>
        /// Gets all <see cref="WshHaushaltPerson"/> entities of the given <see cref="FaLeistung"/> id
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use.</param>
        /// <param name="faLeistungID">The id of the <see cref="FaLeistung"/>.</param>
        /// <param name="nurUnterstuetztePersonen">Whether only the HaushaltPersonen having the Unterstuetzt property set should be returned.</param>
        /// <returns>All assigned <see cref="WshHaushaltPerson"/> entities of the given <see cref="FaLeistung"/> id.</returns>
        /// <exception cref="EntityNotFoundException">Thrown if no <see cref="WshHaushaltPerson"/> with the given id was found.</exception>
        public List<WshHaushaltPerson> GetHaushaltPersonen(IUnitOfWork unitOfWork, int faLeistungID, bool nurUnterstuetztePersonen)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);

            var returnValue = repository
                .Include(persInHaushalt => persInHaushalt.BaPerson)
                .Where(
                    persInHaushalt => persInHaushalt.FaLeistungID == faLeistungID
                                      && (!nurUnterstuetztePersonen
                                          || persInHaushalt.Unterstuetzt))
                .OrderBy(persInHaushalt => persInHaushalt.BaPerson.Name)
                .ThenBy(persInHaushalt => persInHaushalt.BaPerson.Vorname)
                .ThenByDescending(persInHaushalt => persInHaushalt.DatumVon)
                .ToList();

            returnValue.ForEach(SetEntityValidator);

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Gets all <see cref="WshHaushaltPerson"/> entities of the given <see cref="FaLeistung"/> id per a given <see cref="DateTime"/>.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use.</param>
        /// <param name="faLeistungID">The id of the <see cref="FaLeistung"/>.</param>
        /// <param name="stichtag">The <see cref="DateTime"/> to compare with.</param>
        /// <returns>All assigned <see cref="WshHaushaltPerson"/> entities of the given <see cref="FaLeistung"/> id.</returns>
        /// <exception cref="EntityNotFoundException">Thrown if no <see cref="WshHaushaltPerson"/> with the given id and <see cref="DateTime"/> was found.</exception>
        public List<WshHaushaltPerson> GetHaushaltPersonen(IUnitOfWork unitOfWork, int faLeistungID, DateTime stichtag)
        {
            return GetHaushaltPersonen(unitOfWork, faLeistungID, stichtag, false);
        }

        /// <summary>
        /// Gets all <see cref="WshHaushaltPerson"/> entities of the given <see cref="FaLeistung"/> id per a given <see cref="DateTime"/>.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use.</param>
        /// <param name="faLeistungID">The id of the <see cref="FaLeistung"/>.</param>
        /// <param name="stichtag">The <see cref="DateTime"/> to compare with.</param>
        /// <param name="nurUnterstuetztePersonen">Whether only the HaushaltPersonen having the Unterstuetzt property set should be returned.</param>
        /// <returns>All assigned <see cref="WshHaushaltPerson"/> entities of the given <see cref="FaLeistung"/> id.</returns>
        /// <exception cref="EntityNotFoundException">Thrown if no <see cref="WshHaushaltPerson"/> with the given id and <see cref="DateTime"/> was found.</exception>
        public List<WshHaushaltPerson> GetHaushaltPersonen(IUnitOfWork unitOfWork, int faLeistungID, DateTime stichtag, bool nurUnterstuetztePersonen)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);

            var returnValue = repository
                .Include(persInHaushalt => persInHaushalt.BaPerson)
                .Where(
                    persInHaushalt => persInHaushalt.FaLeistungID == faLeistungID
                                      && (!persInHaushalt.DatumVon.HasValue
                                          || persInHaushalt.DatumVon <= stichtag)
                                      && (!persInHaushalt.DatumBis.HasValue
                                          || persInHaushalt.DatumBis >= stichtag) //DatumBis is Null or >= Stichtag
                                      && (!nurUnterstuetztePersonen
                                          || persInHaushalt.Unterstuetzt))
                .OrderBy(persInHaushalt => persInHaushalt.BaPerson.Name)
                .ThenBy(persInHaushalt => persInHaushalt.BaPerson.Vorname)
                .ThenByDescending(persInHaushalt => persInHaushalt.DatumVon)
                .ToList();

            returnValue.ForEach(SetEntityValidator);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public List<WshHaushaltPerson> GetHaushaltPersonenForFall(IUnitOfWork unitOfWork,
            int faFallID,
            DateTime stichtag,
            bool nurUnterstuetztePersonen)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);

            var returnValue = repository
                .Include(persInHaushalt => persInHaushalt.FaLeistung)
                .Where(persInHaushalt => persInHaushalt.FaLeistung.FaFallID == faFallID)
                .Where(
                    persInHaushalt => (!persInHaushalt.DatumVon.HasValue
                                       || persInHaushalt.DatumVon <= stichtag)
                                      && (!persInHaushalt.DatumBis.HasValue
                                          || persInHaushalt.DatumBis >= stichtag) //DatumBis is Null or >= Stichtag
                                      && (!nurUnterstuetztePersonen
                                          || persInHaushalt.Unterstuetzt))
                .Include(persInHaushalt => persInHaushalt.BaPerson)
                .OrderBy(persInHaushalt => persInHaushalt.BaPerson.Name)
                .ThenBy(persInHaushalt => persInHaushalt.BaPerson.Vorname)
                .ThenByDescending(persInHaushalt => persInHaushalt.DatumVon)
                .ToList();

            returnValue.ForEach(SetEntityValidator);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Gibt die Anzahl Personen zurück, die in dem Haushalt leben.
        /// Als Datum für die Prüfung Gültigkeit  wird das Systemdatum verwendet.
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungID"></param>
        /// <returns></returns>
        public int GetHaushaltsGroesse(IUnitOfWork unitOfWork, int faLeistungID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repositoryHaushalt = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);

            DateTime now = DateTime.Today;

            var query = from x in repositoryHaushalt
                        where x.FaLeistungID == faLeistungID
                        where x.DatumVon == null || x.DatumVon <= now
                        where x.DatumBis == null || x.DatumBis >= now
                        select x;

            int count = query.Count();
            return count;
        }

        public ObservableCollection<BaPerson> GetPersonenHaushaltAlle(IUnitOfWork unitOfWork, int faLeistungId)
        {
            var listPersonenHaushaltAlle = GetHaushaltPersonen(unitOfWork, faLeistungId);
            var personenHaushaltAlle = listPersonenHaushaltAlle.Select(ph => ph.BaPerson);
            return new ObservableCollection<BaPerson>(personenHaushaltAlle);
        }

        /// <summary>
        /// Gibt die Anzahl Personen zurück, die in dem Haushalt unterstützt werden.
        /// Als Datum für die Prüfung Gültigkeit  wird das Systemdatum verwendet.
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungID"></param>
        /// <returns></returns>
        public int GetUnterstuetzungsEinheitsGroesse(IUnitOfWork unitOfWork, int faLeistungID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repositoryHaushalt = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);

            DateTime now = DateTime.Today;

            var query = from x in repositoryHaushalt
                        where x.FaLeistungID == faLeistungID
                        where x.Unterstuetzt
                        where x.DatumVon == null || x.DatumVon <= now
                        where x.DatumBis == null || x.DatumBis >= now
                        select x;

            int count = query.Count();
            return count;
        }

        public override KissServiceResult IsDeleteAllowed(WshHaushaltPerson dataToDelete)
        {
            //Gibt es abhängige Belege?
            //TODO: Belege sind noch nicht migriert -> kann noch nicht geprüft werden

            //Gibt es abhängige Grundbudget-Positionen?
            var grundbudgetService = Container.Resolve<WshGrundbudgetPositionDTOService>();
            if (grundbudgetService.DoPositionenExist(
                null, dataToDelete.FaLeistungID, dataToDelete.BaPersonID, dataToDelete.DatumVon, dataToDelete.DatumBis, false))
            {
                return new KissServiceResult(
                    KissServiceResult.ResultType.Error,
                    "Der Datensatz kann nicht gelöscht werden. Es gibt abhängige Grundbudget-Positionen.");
            }

            //Gibt es abhängige Monatsbudget-Positionen?

            return base.IsDeleteAllowed(dataToDelete);
        }

        public override KissServiceResult ValidateInMemory(WshHaushaltPerson dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var serviceResult = WshHaushaltPersonValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        public override KissServiceResult ValidateOnDatabase(IUnitOfWork unitOfWork, WshHaushaltPerson dataToValidate)
        {
            var repository = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);
            //Gibt es eine Überschneidung mit anderen Person im Haushalt
            if (repository.Any(
                persInHaushalt =>
                persInHaushalt.FaLeistungID == dataToValidate.FaLeistungID
                && persInHaushalt.BaPersonID == dataToValidate.BaPersonID
                && (persInHaushalt.DatumVon ?? Constant.SqlDateTimeMin) <= (dataToValidate.DatumBis ?? Constant.SqlDateTimeMax)
                && (persInHaushalt.DatumBis ?? Constant.SqlDateTimeMax) >= (dataToValidate.DatumVon ?? Constant.SqlDateTimeMin)
                && persInHaushalt.WshHaushaltPersonID != dataToValidate.WshHaushaltPersonID))
            {
                return new KissServiceResult(
                    KissServiceResult.ResultType.Error,
                    "Der Datensatz kann nicht gespeichert werden. Es gibt eine Datums-Überschneidung mit derselben Person im Haushalt.");
            }

            //Wurde der Datumsbereich verändert?
            if (dataToValidate.ChangeTracker.State == ObjectState.Modified)
            {
                var haushaltPersonOriginal = GetById(null, dataToValidate.WshHaushaltPersonID);

                //2. Check: Gibt es abhängige GrundbudgetPositionen?
                //--> veränderte Daten (DatumVon/DatumBis) ermitteln
                if (!IsValid(Container.Resolve<WshGrundbudgetPositionDTOService>(), unitOfWork, dataToValidate, haushaltPersonOriginal))
                {
                    return new KissServiceResult(
                        KissServiceResult.ResultType.Error,
                        "Der Datensatz kann nicht verändert werden. Es gibt abhängige Grundbudget-Positionen.");
                }

                //ditto mit MonatsbudgetPositionen
                if (!IsValid(Container.Resolve<WshPositionService>(), unitOfWork, dataToValidate, haushaltPersonOriginal))
                {
                    return new KissServiceResult(
                        KissServiceResult.ResultType.Error,
                        "Der Datensatz kann nicht verändert werden. Es gibt abhängige Budgetpositionen.");
                }

                //sowie: Gibt es abhängige Belege?
                //TODO: Belege sind noch nicht migriert -> kann noch nicht geprüft werden
            }

            return base.ValidateOnDatabase(unitOfWork, dataToValidate);
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///  Erstellt einen neuen WshHaushalt.        
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="leistung"></param>
        /// <param name="person"></param>
        private void InsertWshHaushalt(IUnitOfWork unitOfWork, FaLeistung leistung, BaPerson person)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            WshHaushaltPerson haushaltPerson;
            NewData(out haushaltPerson);
            haushaltPerson.BaPersonID = person.BaPersonID;
            haushaltPerson.FaLeistungID = leistung.FaLeistungID;
            haushaltPerson.Unterstuetzt = !person.PersonOhneLeistung;

            SaveData(unitOfWork, haushaltPerson);
        }

        private bool IsValid(IWshPositionService service,
            IUnitOfWork unitOfWork,
            WshHaushaltPerson dataToValidate,
            WshHaushaltPerson haushaltPersonOriginal)
        {
            DateTime? datumVonOriginal = haushaltPersonOriginal.DatumVon;
            DateTime? datumBisOriginal = haushaltPersonOriginal.DatumBis;

            //1. Check: War die Person früher unterstützt und neu nicht mehr?
            if (!dataToValidate.Unterstuetzt && haushaltPersonOriginal.Unterstuetzt)
            {
                //Die Person war unterstützt und ist jetzt neu nicht mehr unterstützt
                //--> zu prüfender Datumsbereich: service.DoPositionenExist(..., dataToValidate.DatumBis, null)
                if (service.DoPositionenExist(
                    unitOfWork, dataToValidate.FaLeistungID, dataToValidate.BaPersonID, dataToValidate.DatumVon, dataToValidate.DatumBis, false))
                {
                    return false;
                }
            }

            if (datumVonOriginal.HasValue && dataToValidate.DatumVon.HasValue)
            {
                var compareResult = DateTime.Compare(datumVonOriginal.Value, dataToValidate.DatumVon.Value);
                switch (compareResult)
                {
                    case 1:
                        //DatumVonNeu ist früher als DatumVonOriginal
                        //--> nichts zu prüfen
                        break;
                    case -1:
                        //DatumVonOriginal ist früher als DatumVonNeu
                        //--> zu prüfender Datumsbereich: service.DoPositionenExist(..., datumVonOriginal, dataToValidate.DatumVon)
                        if (service.DoPositionenExist(
                            unitOfWork, dataToValidate.FaLeistungID, dataToValidate.BaPersonID, datumVonOriginal, dataToValidate.DatumVon, false))
                        {
                            return false;
                        }

                        break;
                    default:
                        //do nothing
                        break;
                }
            }
            else if (!datumVonOriginal.HasValue && dataToValidate.DatumVon.HasValue)
            {
                //zu prüfender Datumsbereich: service.DoPositionenExist(..., null, dataToValidate.DatumVon)
                if (service.DoPositionenExist(
                    unitOfWork, dataToValidate.FaLeistungID, dataToValidate.BaPersonID, null, dataToValidate.DatumVon, false))
                {
                    return false;
                }
            }

            if (datumBisOriginal.HasValue && dataToValidate.DatumBis.HasValue)
            {
                var compareResult = DateTime.Compare(datumBisOriginal.Value, dataToValidate.DatumBis.Value);
                switch (compareResult)
                {
                    case 1:
                        //DatumBisNeu ist früher als DatumBisOriginal
                        //--> zu prüfender Datumsbereich: service.DoPositionenExist(..., dataToValidate.DatumBis, datumBisOriginal)
                        if (service.DoPositionenExist(
                            null, dataToValidate.FaLeistungID, dataToValidate.BaPersonID, dataToValidate.DatumBis, datumBisOriginal, false))
                        {
                            return false;
                        }
                        break;
                    case -1:
                        //DatumBisOriginal ist früher als DatumBisNeu
                        //--> nichts zu prüfen
                        break;
                    default:
                        //do nothing
                        break;
                }
            }
            else if (!datumBisOriginal.HasValue && dataToValidate.DatumBis.HasValue)
            {
                //zu prüfender Datumsbereich: service.DoPositionenExist(..., dataToValidate.DatumBis, null)
                if (service.DoPositionenExist(
                    unitOfWork, dataToValidate.FaLeistungID, dataToValidate.BaPersonID, dataToValidate.DatumBis, null, false))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #endregion
    }
}