using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.Ba;
using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.BL.Wsh;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.BA;
using Kiss.Model.DTO.Kbu;
using Kiss.Model.DTO.Wsh;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage an WshPosition entity
    /// </summary>
    public class WshPositionService : ServiceCRUDBase<WshPosition>, IWshPositionService
    {
        #region Constructors

        private WshPositionService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshPosition dataToDelete, bool saveChanges = true)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var kreditorService = Container.Resolve<WshPositionKreditorService>();
            var debitorService = Container.Resolve<WshPositionDebitorService>();

            KissServiceResult result;

            using (var ts = new TransactionScope())
            {
                kreditorService.DeleteKreditor(unitOfWork, dataToDelete.WshPositionID);
                debitorService.DeleteDebitor(unitOfWork, dataToDelete.WshPositionID);

                var posRepository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
                var refreshedDataToDelete = posRepository.Where(x => x.WshPositionID == dataToDelete.WshPositionID).First();

                result = base.DeleteData(unitOfWork, refreshedDataToDelete, saveChanges);

                ts.Complete();
            }

            return result;
        }

        /// <summary>
        /// Setzt das Flag Dauerauftrag bei allen Positionen,
        /// die vom Grundbudget abgeleitet wurden.
        /// Ebenfalls das Flag WshDauerauftragAktiv der Leistung wird angepasst.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        public KissServiceResult DauerauftragFlagSetzen(IUnitOfWork unitOfWork, int faLeistungId, bool isDauerauftragAktiv)
        {

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            using (TransactionScope ts = new TransactionScope())
            {
                var repositoryPositionen = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
                var positionen = repositoryPositionen
                    .Include(x => x.FaLeistung)
                    .Where(x => x.WshGrundbudgetPosition.FaLeistungID == faLeistungId)
                    .WhereIf(isDauerauftragAktiv, x => x.KbuBelegPosition.Count() == 0)
                    .WhereIf(!isDauerauftragAktiv, x => x.DauerauftragAktiv == true)
                    .ToList();

                foreach (var wshPosition in positionen)
                {
                    wshPosition.DauerauftragAktiv = isDauerauftragAktiv;
                    wshPosition.FaLeistung.WshDauerauftragAktiv = isDauerauftragAktiv;
                }
                unitOfWork.SaveChanges();
                ts.Complete();
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Holt alle Positionen, welche mit dem angegebenen Datumsbereich interagieren.
        /// Wird z.B. nur DatumVon als Suchbegriff übergeben, dann werden alle Positionen der Leistung und der Person
        /// zurückgegeben, welche nach diesem Datum enden. Analog mit DatumBis -> es werden
        /// nur die Positionen angezeigt, welche vor diesem Datum erstellt wurden.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="faLeistungID">Die FaLeistungID, mit der Positionen gesucht werden sollen.</param>
        /// <param name="baPersonID">Die BaPersonID, für die Positionen gesucht werden sollen.</param>
        /// <param name="datumVon">Das Anfangsdatum des Datumsbereichs, der durchsucht werden soll. </param>
        /// <param name="datumBis">Das Enddatum des Datumsbereichs, der durchsucht werden soll. </param>
        /// <param name="stichtagInklusive">Zum definieren ob beide Stichtage inklusive (auf true) gesucht werden müssen</param>
        /// <returns>True wenn eine Position in diesem Datumsbereich vorhanden ist</returns>
        public bool DoPositionenExist(
            IUnitOfWork unitOfWork,
            int faLeistungID,
            int baPersonID,
            DateTime? datumVon,
            DateTime? datumBis,
            bool stichtagInklusive)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            // ReSharper disable PossibleInvalidOperationException
            return repository
                .Where(pos => pos.FaLeistungID == faLeistungID)
                .Where(pos => pos.BaPersonID == baPersonID)
                .WhereIf(datumVon.HasValue && stichtagInklusive, pos => pos.VerwPeriodeBis >= datumVon.Value) //datumVon.Value kann keine InvalidOperationException werfen (ist mit WhereIf geprüft)
                .WhereIf(datumBis.HasValue && stichtagInklusive, pos => pos.VerwPeriodeVon <= datumBis.Value) //datumBis.Value kann keine InvalidOperationException werfen (ist mit WhereIf geprüft)
                .WhereIf(datumVon.HasValue && !stichtagInklusive, pos => pos.VerwPeriodeBis > datumVon.Value) //datumVon.Value kann keine InvalidOperationException werfen (ist mit WhereIf geprüft)
                .WhereIf(datumBis.HasValue && !stichtagInklusive, pos => pos.VerwPeriodeVon < datumBis.Value) //datumBis.Value kann keine InvalidOperationException werfen (ist mit WhereIf geprüft)
                .Any();
            // ReSharper restore PossibleInvalidOperationException
        }

        public List<WshBudgetmonatDTO> GetBudgetmonate(IUnitOfWork unitOfWork, int faLeistungID, MonthYear from, int numerOfMonths)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            var to = from + numerOfMonths;
            var fromDate = new DateTime(from.Year, from.Month, 1);
            var toDate = new DateTime(to.Year, to.Month, 1).AddMonths(1).AddDays(-1);

            var monate = repository
                .Where(p => p.FaLeistungID == faLeistungID)
                .Where(p => p.MonatBis >= fromDate && p.MonatVon <= toDate);

            var a = monate
                .ToList()
                .Select(
                    p => new WshBudgetmonatDTO
                    {
                        MonatJahr = new MonthYear(p.MonatVon.Year, p.MonatVon.Month),
                        Status = WshBudgetmonatStatus.NichtVorhanden
                    });
            // ToDo: Auch Monate liefern, die noch keine Positionen haben
            return a.ToList();
        }

        /// <summary>
        /// Gets a List of <see cref="WshPosition"/> with the given <paramref name="faLeistungID"/>. 
        /// Gets also the <see cref="WshPositionDebitor"/> and <see cref="WshPositionKreditor"/> informations.
        /// </summary>
        /// <param name="unitOfWork">The UnitOfWork</param>
        /// <param name="faLeistungID">The FaLeistungID of the entity to look for</param>
        /// <returns>The entity list with the given <paramref name="faLeistungID"/></returns>
        public IList<WshPosition> GetByFaLeistungID(IUnitOfWork unitOfWork, int faLeistungID)
        {
            return GetByFaLeistungID(unitOfWork, faLeistungID, null, null);
        }

        /// <summary>
        /// Holt alle Positionen, welche optional nach Monat und Jahr gefiltert sind.
        /// 
        /// Folgende Relationen werden eager geladen:
        /// => KbuKonto
        /// => BaPerson
        /// => WshPositionKreditor
        /// 
        /// Die Summe der Belegpositionen wird ebenfalls berechnet:
        /// 
        /// - SummeBelegPositionBetragFreigegeben: Summe aller Beträge der Belegpositionen zu Belegen, die freigegeben sind.
        /// - SummeBelegPositionBetragVerbucht: Summe aller Beträge der Belegpositionen zu Belegen, die verbucht sind.
        /// 
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork</param>
        /// <param name="faLeistungID">Die ID der Leistung</param>
        /// <param name="jahr">Year of the <see cref="WshPosition"/></param>
        /// <param name="monat">Month of the <see cref="WshPosition"/></param>
        /// <returns>Eine Liste der Positions-Entitäten</returns>
        public IList<WshPosition> GetByFaLeistungID(IUnitOfWork unitOfWork, int faLeistungID, int? jahr, int? monat)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            //Query nach Positionen.
            var query = repository
                .Where(pos => pos.FaLeistungID == faLeistungID)
                .Include(pos => pos.KbuKonto)
                .Include(pos => pos.BaPerson)
                .Include(pos => pos.WshPositionKreditor.SubInclude(zw => zw.BaZahlungsweg))
                .Include(pos => pos.WshPositionDebitor)
                //.Include(pos => pos.KbuKonto.SubInclude(a => a.WshKontoAttribut))
                .Select(pos => pos);

            if (jahr.HasValue && monat.HasValue)
            {
                DateTime date = new DateTime(jahr.Value, monat.Value, 1);
                query = query.Where(pos => pos.MonatVon <= date);
                query = query.Where(pos => pos.MonatBis >= date);
            }

            IList<WshPosition> result = SummenDerWshPositionenBerechnen(unitOfWork, query);
            return result;
        }

        /// <summary>
        /// Gets the <see cref="WshPosition"/> with the given ID. 
        /// Gets also the <see cref="WshPositionDebitor"/> and <see cref="WshPositionKreditor"/> informations.
        /// </summary>
        /// <param name="unitOfWork">The UnitOfWork</param>
        /// <param name="id">The ID of the entity to look for</param>
        /// <returns>The entity with the given <paramref name="id"/></returns>
        public override WshPosition GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            var returnValue = repository
                .Where(pos => pos.WshPositionID == id)
                .Include(pos => pos.WshPositionDebitor)
                .Include(pos => pos.WshPositionKreditor)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'WshPosition' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public IList<WshPosition> GetByWshGrundbudgetPositionID(IUnitOfWork unitOfWork, int wshGrundbudgetPositionID)
        {
            return GetByWshGrundbudgetPositionIdQueryable(unitOfWork, wshGrundbudgetPositionID).ToList();
        }

        public IQueryable<WshPosition> GetByWshGrundbudgetPositionIdQueryable(IUnitOfWork unitOfWork, int wshGrundbudgetPositionID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            var  query = repository
                .Where(pos => pos.WshGrundbudgetPositionID == wshGrundbudgetPositionID)
                .Include(pos => pos.WshPositionDebitor)
                .Include(pos => pos.WshPositionKreditor);

            return query;
        }

        /// <summary>
        /// Erstellt ein <see cref="BaDebitorDTO"/>, aus Daten in WshPositionDebitor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="wshPositionID"></param>
        /// <returns></returns>
        public BaDebitorDTO GetDebitorDTO(IUnitOfWork unitOfWork, int wshPositionID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repositoryDebitor = UnitOfWork.GetRepository<WshPositionDebitor>(unitOfWork);
            var debitor = repositoryDebitor.FirstOrDefault(x => x.WshPositionID == wshPositionID);

            if (debitor != null)
            {
                var debitorService = Container.Resolve<BaDebitorSearchService>();

                if (debitor.BaPersonID != null)
                {
                    return debitorService.GetDebitorPerson(unitOfWork, debitor.BaPersonID.Value);
                }

                if (debitor.BaInstitutionID != null)
                {
                    return debitorService.GetDebitorInstitution(unitOfWork, debitor.BaInstitutionID.Value);
                }
            }

            return null;
        }

        /// <summary>
        /// Erstellt das BaZahlungswegDTO für die Position als Kreditorinformationen.
        /// Hinweis: In Zukunft kann es mehrere Kreditoren pro Position geben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionID">Die ID der WshPosition</param>
        /// <returns>Das DTO. Kann null sein, wenn es keinen Kreditor gibt.</returns>
        public BaZahlungswegDTO GetZahlungswegDTO(IUnitOfWork unitOfWork, int positionID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPositionKreditor>(unitOfWork);
            int? zahlungswegId = repository.Where(x => x.WshPositionID == positionID).Select(x => x.BaZahlungswegID)
                .FirstOrDefault();
            if (zahlungswegId.HasValue)
            {
                BaZahlungswegSearchService service = Container.Resolve<BaZahlungswegSearchService>();
                return service.GetBaZahlungswegDTO(unitOfWork, zahlungswegId.Value);
            }
            return null;
        }

        public override KissServiceResult NewData(out WshPosition newData)
        {
            var result = base.NewData(out newData);

            if (result)
            {
                // default values
                newData.WshKategorieID = Convert.ToInt32(LOVsGenerated.WshKategorie.Einnahme);
                newData.WshPeriodizitaetCode = Convert.ToInt32(LOVsGenerated.WshPeriodizitaet._1xProMonat);
                newData.BudgetMonatJahr = new MonthYear(Constant.SqlDateTimeMin);
            }

            return result;
        }

        /// <summary>
        /// Speichert die Budgetposition ab.
        /// Speichert auch den WshPositionKreditor und -Debitor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="position"></param>
        /// <param name="questionsAndAnswers"></param>
        /// <returns></returns>
        public override KissServiceResult SaveData(
            IUnitOfWork unitOfWork,
            WshPosition position)
        {
            using (var ts = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

                // Wenn BaPersoID kleiner als null ist, dann bedeutet das keine Auswahl.
                if (position.BaPersonID <= 0)
                {
                    position.BaPerson = null;
                    position.BaPersonID = null;
                }

                KissServiceResult result;

                if (position.WshPositionKreditor.Count == 1)
                {
                    result = SaveKreditorAndPosition(unitOfWork, position);
                }
                else if (position.WshPositionDebitor.Count == 1)
                {
                    result = SaveDebitorAndPosition(unitOfWork, position);
                }
                else
                {
                    result = base.SaveData(unitOfWork, position);
                }

                if (!result)
                {
                    return result;
                }

                ts.Complete();
                return result;
            }
        }

        /// <summary>
        /// Berechnet die zwei Felder SummeBelegPositionBetragFreigegeben
        /// und SummeBelegPositionBetragVerbucht.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public IList<WshPosition> SummenDerWshPositionenBerechnen(IUnitOfWork unitOfWork, IQueryable<WshPosition> query)
        {
            int kbuStatusFreigegeben = (int)LOVsGenerated.KbuBelegstatus.Freigegeben;
            int kbuStatusVerbucht = (int)LOVsGenerated.KbuBelegstatus.Verbucht;

            //Query nach den Summen. Bei Projektionen funktioniert das Inlcude nicht.
            //Aus diesem Grund wird hier ein neues Query erstellt und ausgeführt.
            var queryWithSummen = query.Select(
                x => new WshPositionSummeDTO
                {
                    WshPositionID = x.WshPositionID,
                    SummeBelegPositionenFreigegeben = x.KbuBelegPosition
                         .Where(y => y.HauptPosition == false)
                         .Where(u => u.KbuBeleg.KbuBelegstatusCode == kbuStatusFreigegeben)
                         .Sum(z => z.BetragBrutto),
                    SummeBelegPositionenVerbucht = x.KbuBelegPosition
                         .Where(y => y.HauptPosition == false)
                         .Where(u => u.KbuBeleg.KbuBelegstatusCode == kbuStatusVerbucht)
                         .Sum(z => z.BetragBrutto)
                });

            IList<WshPosition> result = query.ToList();
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            foreach (var t in queryWithSummen)
            {
                //TODO Kann man mit einem Hashtable schneller machen.
                WshPosition position = result.Where(x => x.WshPositionID == t.WshPositionID)
                    .Single();

                if (t.SummeBelegPositionenFreigegeben.HasValue)
                {
                    position.SummeBelegPositionBetragFreigegeben = t.SummeBelegPositionenFreigegeben.Value;
                }

                if (t.SummeBelegPositionenVerbucht.HasValue)
                {
                    position.SummeBelegPositionBetragVerbucht = t.SummeBelegPositionenVerbucht.Value;
                }
            }
            return result;
        }

        public override KissServiceResult ValidateInMemory(WshPosition dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var serviceResult = WshPositionValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #region Private Methods

        private KissServiceResult SaveDebitorAndPosition(IUnitOfWork unitOfWork, WshPosition position)
        {
            var positionDebitorService = Container.Resolve<WshPositionDebitorService>();

            var debitor = position.WshPositionDebitor.Single();

            // Debitor löschen, wenn nichts ausgewählt ist.
            if (debitor.BaPersonID == null && debitor.BaInstitutionID == null)
            {
                if (debitor.ChangeTracker.State != ObjectState.Added)
                {
                    positionDebitorService.DeleteDebitor(unitOfWork, position.WshPositionID);
                }

                return base.SaveData(unitOfWork, position);
            }

            var result = positionDebitorService.ValidateAndInit(unitOfWork, debitor);

            if (!result)
            {
                return result;
            }

            result += base.SaveData(unitOfWork, position);

            if (!result.IsOk)
            {
                return result;
            }

            return positionDebitorService.SaveData(unitOfWork, debitor);
        }

        private KissServiceResult SaveKreditorAndPosition(IUnitOfWork unitOfWork, WshPosition position)
        {
            var positionKreditorService = Container.Resolve<WshPositionKreditorService>();

            var kreditor = position.WshPositionKreditor.Single();

            if (position.KbuAuszahlungArtCode != Convert.ToInt32(LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung))
            {
                kreditor.MitteilungZeile1 = "";
                kreditor.MitteilungZeile2 = "";
                kreditor.MitteilungZeile3 = "";
                kreditor.MitteilungZeile4 = "";
                kreditor.BaZahlungsweg = null;
            }

            KissServiceResult result = positionKreditorService.ValidateAndInit(unitOfWork, kreditor);

            if (!result.IsOk)
            {
                return result;
            }

            result += base.SaveData(unitOfWork, position);

            if (!result.IsOk)
            {
                return result;
            }

            return positionKreditorService.SaveData(unitOfWork, kreditor);
        }

        #endregion

        #endregion
    }
}