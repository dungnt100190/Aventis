using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.Fs.Validation;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Fs
{
    /// <summary>
    /// Service to manage FsReduktionMitarbeiter
    /// </summary>
    public class FsReduktionMitarbeiterService : ServiceCRUDBase<FsReduktionMitarbeiter>
    {
        #region Constructors

        private FsReduktionMitarbeiterService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Überprüft, ob für den User im angegebenen Monat
        /// die Einträge bereits erstellt worden sind.
        ///
        /// Sobald es mindestens einen Eintrag gibt, wird angenommen, dass die Einträge generiert worden sind.
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userId"></param>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        public bool AreEntriesGenerated(IUnitOfWork unitOfWork, int userId, MonthYear monthYear)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var reporitory = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            var query = from x in reporitory
                        where x.UserID == userId
                        where x.Jahr == monthYear.Year
                        where x.Monat == monthYear.Month
                        select x;
            if (query.Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Überprüft, ob für den User im angegebenen Monat
        /// die Einträge bereits erstellt worden sind.
        ///
        ///  Sobald es mindestens einen Eintrag gibt, wird angenommen, dass die Einträge generiert worden sind.
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        public bool AreEntriesGenerated(IUnitOfWork unitOfWork, MonthYear monthYear)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var reporitory = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            var query = from x in reporitory
                        where x.Jahr == monthYear.Year
                        where x.Monat == monthYear.Month
                        select x;
            if (query.Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Überprüft, ob die Einträge in dem Zeitraum für den User generiert worden sind.
        /// Das Zeitintervall wird erweitert (1. Tag vom "von" Monat, letzter Tag vom "bis" Monat).
        /// Im KissServiceResult ist eine Warnung enthalten, je eine Warnung pro Monat, falls die
        /// für diesen Monat nicht generiert worden sind.
        /// </summary>
        public KissServiceResult AreEntriesGenerated(IUnitOfWork unitOfWork, int? userid, TimePeriod timePeriod)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            KissServiceResult result = null;
            MonthYear monthYearVon = new MonthYear(timePeriod.From);
            MonthYear monthYearBis = new MonthYear(timePeriod.To);

            while (monthYearVon <= monthYearBis)
            {
                bool entriesGenerated;
                if (userid != null)
                {
                    entriesGenerated = AreEntriesGenerated(unitOfWork, (int)userid, monthYearVon);
                }
                else
                {
                    entriesGenerated = AreEntriesGenerated(unitOfWork, monthYearVon);
                }

                if (!entriesGenerated)
                {
                    DateTime month = new DateTime(monthYearVon.Year, monthYearVon.Month, 1);
                    string monthString = month.ToString("MMMM");

                    string message = string.Format("Für den Monat {0} {1} wurden noch keine Reduktionen erzeugt.", monthString, monthYearVon.Year);
                    if (result == null)
                    {
                        result = new KissServiceResult(ServiceResultType.Warning, message);
                    }
                    else
                    {
                        result += new KissServiceResult(ServiceResultType.Warning, message);
                    }
                }
                monthYearVon++;
            }
            if (result == null)
            {
                return KissServiceResult.Ok();
            }
            return result;
        }

        /// <summary>
        /// Erstellt Einträge für alle User für den angegebenen Monat.
        ///
        /// Nur die noch nicht vorhandenen Einträge werden erstellt, die bereits erstellten
        /// Einträge werden nicht verändert.
        ///
        /// Werte werden von FsReduktion übernommen.
        ///
        /// Wo im Vormonat die Werte angepasst wurden, werden diese in das Feld
        /// AngepassteReduktionZeit übernommen.
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        public KissServiceResult CreateEntries(IUnitOfWork unitOfWork, MonthYear monthYear)
        {
            using (var ts = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
                IRepository<XUser> repositoryUser = UnitOfWork.GetRepository<XUser>(unitOfWork);

                DateTime firstDayOfMonth = monthYear.GetFirstDayOfMonth();
                DateTime lastDayOfMonth = monthYear.GetLastDayOfMonth();

                var query = from x in repositoryUser
                            select new
                            {
                                UserID = x.UserID,
                                Pensum = x.BDEPensum_XUser.Where(p => p.DatumVon <= firstDayOfMonth && (!p.DatumBis.HasValue || p.DatumBis.Value >= lastDayOfMonth)).FirstOrDefault(),
                            };

                foreach (var userPensum in query)
                {
                    var bdePensum = userPensum.Pensum;
                    var pensum = bdePensum != null ? bdePensum.PensumProzent : 0;

                    KissServiceResult serviceResult = CreateEntries(unitOfWork, userPensum.UserID, monthYear, pensum);
                    if (!serviceResult.IsOk)
                    {
                        return new KissServiceResult(
                            ServiceResultType.Error,
                            string.Format("Konnte Einträge für UserId {0} nicht erstellen.", userPensum.UserID));
                    }
                }
                ts.Complete();
            }
            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Erstellt Einträge für alle User für den angegebenen Monat.
        ///
        /// Nur die noch nicht vorhandenen Einträge werden erstellt, die bereits erstellten
        /// Einträge werden nicht verändert.
        ///
        /// Werte werden von FsReduktion übernommen.
        ///
        /// Wo im Vormonat die Werte angepasst wurden, werden diese in das Feld
        /// AngepassteReduktionZeit übernommen.
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userId">Die Id des Users</param>
        /// <param name="monthYear">Jahr/Monat, für welchen die Einträge erstellt werden.</param>
        /// <returns></returns>
        public KissServiceResult CreateEntries(IUnitOfWork unitOfWork, int userId, MonthYear monthYear, int pensum)
        {
            using (var ts = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

                //Fehlende Einträge suchen
                IList<FsReduktion> reduktionen = GetMissingReduktionen(unitOfWork, userId, monthYear);

                //Liste mit Einträgen, die neu erstellt worden sind.
                IList<FsReduktionMitarbeiter> reduktionenMitarbeiter = new List<FsReduktionMitarbeiter>();

                //Einträge erstellen
                foreach (var reduktion in reduktionen)
                {
                    FsReduktionMitarbeiter reduktionMitarbeiter;
                    NewData(out reduktionMitarbeiter);

                    reduktionMitarbeiter.FsReduktion = reduktion;
                    reduktionMitarbeiter.UserID = userId;

                    //Pensum einbeziehen wenn Abhängig
                    if (reduktion.AbhaengigVonBG && (pensum > 0 && pensum < 100))
                    {
                        reduktionMitarbeiter.OriginalReduktionZeit = reduktion.StandardAufwand * pensum / System.Convert.ToDecimal(100);
                    }
                    else
                    {
                        reduktionMitarbeiter.OriginalReduktionZeit = reduktion.StandardAufwand;
                    }

                    reduktionMitarbeiter.Monat = monthYear.Month;
                    reduktionMitarbeiter.Jahr = monthYear.Year;

                    SaveData(unitOfWork, reduktionMitarbeiter);
                    reduktionenMitarbeiter.Add(reduktionMitarbeiter);
                }

                //Modifizierte Werte vom Vormonat übernehmen.
                var repository = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
                List<FsReduktionMitarbeiter> modifizierteMitarbeiterReduktionenVormonat;
                KissServiceResult serviceResult = GetModifiedEntriesOfPreviousMonth(unitOfWork, out modifizierteMitarbeiterReduktionenVormonat, userId, monthYear);

                if (!serviceResult.IsOk)
                {
                    return serviceResult;
                }

                foreach (var reduktionMitarbeiterVormonat in modifizierteMitarbeiterReduktionenVormonat)
                {
                    int id = reduktionMitarbeiterVormonat.FsReduktionID;
                    var red = (from x in reduktionenMitarbeiter
                               where x.FsReduktionID == id
                               select x).FirstOrDefault();
                    if (red != null)
                    {
                        red.AngepassteReduktionZeit = reduktionMitarbeiterVormonat.AngepassteReduktionZeit;
                        repository.ApplyChanges(red);
                    }
                }
                unitOfWork.SaveChanges();
                ts.Complete();
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Löscht alle Einträge eines
        /// Users für den angegebenen Monat.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userId"></param>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        public KissServiceResult DeleteEntries(IUnitOfWork unitOfWork, int userId, MonthYear monthYear)
        {
            using (var ts = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
                List<FsReduktionMitarbeiter> entries = GetEntries(unitOfWork, userId, monthYear);
                var reporitory = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
                entries.ForEach(
                    x =>
                    {
                        x.MarkAsDeleted();
                        reporitory.ApplyChanges(x);
                    });
                unitOfWork.SaveChanges();
                ts.Complete();
            }
            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Löscht alle Einträge für den angegebenen Monat.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        public KissServiceResult DeleteEntries(IUnitOfWork unitOfWork, MonthYear monthYear)
        {
            using (var ts = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
                List<FsReduktionMitarbeiter> entries = GetEntries(unitOfWork, monthYear);
                var reporitory = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
                entries.ForEach(
                    x =>
                    {
                        x.MarkAsDeleted();
                        reporitory.ApplyChanges(x);
                    });
                unitOfWork.SaveChanges();
                ts.Complete();
            }
            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override FsReduktionMitarbeiter GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);

            var returnValue = repository
                .Where(redMa => redMa.FsReduktionMitarbeiterID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'FsReduktionMitarbeiter' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Hohlt alle Einträge des Vormonats, welche manuell angepasst worden sind.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="result"></param>
        /// <param name="userId"></param>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        public KissServiceResult GetModifiedEntriesOfPreviousMonth(IUnitOfWork unitOfWork, out List<FsReduktionMitarbeiter> result, int userId, MonthYear monthYear)
        {
            //Vormonat ausrechnen
            monthYear--;

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var reporitory = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            var query = from x in reporitory
                        where x.UserID == userId
                        where x.Monat == monthYear.Month
                        where x.Jahr == monthYear.Year
                        where x.AngepassteReduktionZeit != null
                        select x;

            result = query.ToList();

            result.ForEach(SetEntityValidator);

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Validiert die Werte in der Entität FsReduktionMitarbeiter.
        /// </summary>
        /// <param name="dataToValidate"></param>
        /// <returns></returns>
        public override KissServiceResult ValidateInMemory(FsReduktionMitarbeiter dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var serviceResult = FsReduktionMitarbeiterValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Hohlt alle Einträge eines Users von einem Monat.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userId"></param>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        private static List<FsReduktionMitarbeiter> GetEntries(IUnitOfWork unitOfWork, int userId, MonthYear monthYear)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var reporitory = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            var query = from x in reporitory
                        where x.UserID == userId
                        where x.Jahr == monthYear.Year
                        where x.Monat == monthYear.Month
                        select x;
            return query.ToList();
        }

        /// <summary>
        /// Hohlt alle Einträge von einem Monat.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        private static List<FsReduktionMitarbeiter> GetEntries(IUnitOfWork unitOfWork, MonthYear monthYear)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var reporitory = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            var query = from x in reporitory
                        where x.Jahr == monthYear.Year
                        where x.Monat == monthYear.Month
                        select x;
            return query.ToList();
        }

        /// <summary>
        /// Hohlt alle Reduktionen, für die es zum angegebenen Monat und User noch keinen Eintrag gibt.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userid"></param>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        private static IList<FsReduktion> GetMissingReduktionen(IUnitOfWork unitOfWork, int userid, MonthYear monthYear)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            IRepository<FsReduktionMitarbeiter> repositoryMitarbeiterReduktion = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            IRepository<FsReduktion> repositoryReduktion = UnitOfWork.GetRepository<FsReduktion>(unitOfWork);

            var queryMitarbeiterReduktion = from x in repositoryMitarbeiterReduktion
                                            where x.Jahr == monthYear.Year
                                            where x.Monat == monthYear.Month
                                            where x.UserID == userid
                                            select x.FsReduktion;

            var query = from red in repositoryReduktion
                        where !queryMitarbeiterReduktion.Contains(red)
                        select red;

            return query.ToList();
        }

        #endregion

        #endregion
    }
}