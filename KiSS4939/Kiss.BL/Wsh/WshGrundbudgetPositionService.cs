using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.Ba;
using Kiss.BL.Kbu;
using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Enumeration;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.BA;
using Kiss.Model.DTO.Kbu;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage an WshGrundbudgetPosition entity
    /// </summary>
    [UsableBy(
        typeof(WshGrundbudgetPositionDTOService),
        typeof(WshAbzugDTOService),
        typeof(WshAbzugDetailDTOService),
        ClassNames = new[]
        {
            "Kiss.BL.Test.Wsh.WshGrundbudgetPositionServiceTest", 
            "Kiss.BL.Test.Wsh.WshGrundbudgetPositionServiceTest1", 
            "Kiss.BL.Test.Wsh.WshGrundbudgetUebertragenServiceTest", 
            "Kiss.BL.Test.Helpers.WshGrundbudgetPositionHelper"
        })]
    internal class WshGrundbudgetPositionService : ServiceCRUDBase<WshGrundbudgetPosition>
    {
        #region Constructors

        private WshGrundbudgetPositionService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Prüft, ob alle abhängigen Positionen grau sind, bzw. wann die erste/letzte Belegposition existiert.
        /// Wenn <paramref name="istAbzug"/> <c>true</c> ist, werden zusätzlich graue Budgetpositionen mit Betrag 0 als "nicht grau" miteinbezogen.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="wshGrundbudgetPositionID"></param>
        /// <param name="firstNonGrayPosition"></param>
        /// <param name="lastNonGrayPosition"></param>
        /// <param name="istAbzug"></param>
        /// <returns></returns>
        public bool AreAllDependingPositionsGray(IUnitOfWork unitOfWork,
            int wshGrundbudgetPositionID,
            out DateTime? firstNonGrayPosition,
            out DateTime? lastNonGrayPosition,
            bool istAbzug = false)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            firstNonGrayPosition = null;
            lastNonGrayPosition = null;

            // Belegpositionen
            var repoBelegPosition = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);

            var belegPositions = repoBelegPosition
                .Where(bp => bp.WshPosition != null && bp.WshPosition.WshGrundbudgetPositionID == wshGrundbudgetPositionID) //Die Haupt-Position (ohne WshPosition-Referenz) interessiert uns nicht
                .Where(bp => bp.KbuBeleg.KbuBelegstatusCode != (int)LOVsGenerated.KbuBelegstatus.Vorschlag);

            if (belegPositions.Any())
            {
                firstNonGrayPosition = belegPositions.Min(bp => bp.WshPosition.MonatVon);
                lastNonGrayPosition = belegPositions.Max(bp => bp.WshPosition.MonatBis);
            }

            // Für Abzüge graue 0-Positionen holen
            if (istAbzug)
            {
                var wshPositionService = Container.Resolve<WshPositionService>();

                var query = wshPositionService.GetByWshGrundbudgetPositionIdQueryable(unitOfWork, wshGrundbudgetPositionID)
                    .Where(p => p.Betrag == 0);
                var positions = wshPositionService.SummenDerWshPositionenBerechnen(unitOfWork, query)
                    .Where(p => p.PositionsStatus <= WshPositionsstatus.Vorbereitet);

                if (positions.Any())
                {
                    var firstPos = positions.Min(p => p.MonatVon);
                    var lastPos = positions.Max(p => p.MonatBis);

                    if (firstNonGrayPosition != null)
                    {
                        firstNonGrayPosition = Min(firstNonGrayPosition.Value, firstPos);
                        lastNonGrayPosition = Max(lastNonGrayPosition.Value, lastPos);
                    }
                    else
                    {
                        firstNonGrayPosition = firstPos;
                        lastNonGrayPosition = lastPos;
                    }
                }
            }

            return firstNonGrayPosition == null;
        }

        /// <summary>
        /// Löscht einen Datensatz mitsamt dazugehörigen Monatsbudgetpositionen und Kreditor/Debitor.
        /// Geschäftsregeln müssen noch definiert werden.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionToDelete"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshGrundbudgetPosition positionToDelete, bool saveChanges = true)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var kreditorService = Container.Resolve<WshGrundbudgetPositionKreditorService>();
            var debitorService = Container.Resolve<WshGrundbudgetPositionDebitorService>();
            var result = KissServiceResult.Ok();

            using (var ts = new TransactionScope())
            {
                var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
                var tmpPosition = repository.Where(x => x.WshGrundbudgetPositionID == positionToDelete.WshGrundbudgetPositionID).FirstOrDefault();

                if (tmpPosition == null)
                {
                    throw new EntityNotFoundException(string.Format("Die Grundbudgetposition  mit Id {0} wurde nicht gefunden", positionToDelete.WshGrundbudgetPositionID));
                }

                // start with tracking first to prevent errors with deleting pending data
                tmpPosition.StartTracking();

                // delete belonging WshPosition*
                DeleteWshPositionInclBelongingData(unitOfWork, tmpPosition.WshGrundbudgetPositionID);

                // delete WshGrundbudgetPositionKreditor
                kreditorService.DeleteKreditor(unitOfWork, tmpPosition.WshGrundbudgetPositionID);

                // delete WshGrundbudgetPositionDebitor
                debitorService.DeleteDebitor(unitOfWork, tmpPosition.WshGrundbudgetPositionID);

                // delete WshGrundbudgetPosition
                tmpPosition.MarkAsDeleted();
                repository.ApplyChanges(tmpPosition);

                if(saveChanges)
                {
                    unitOfWork.SaveChanges();
                }

                ts.Complete();
            }

            return result;
        }

        /// <summary>
        /// Prüft, ob abhängige Monatsbudget-Positionen mit dem angegebenen Status existieren.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="wshGrundbudgetPositionId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool DoDependingPositionsExist(IUnitOfWork unitOfWork, int wshGrundbudgetPositionId, WshPositionsstatus status)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var positionService = Container.Resolve<WshPositionService>();

            var positionenQueryable = positionService.GetByWshGrundbudgetPositionIdQueryable(unitOfWork, wshGrundbudgetPositionId);
            var positionen = positionService.SummenDerWshPositionenBerechnen(unitOfWork, positionenQueryable);

            return positionen != null && positionen.Any(x => x.PositionsStatus == status);
        }

        /// <summary>
        /// Holt alle GrundbudgetPositionen, welche mit dem angegebenen Datumsbereich interagieren.
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
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);

            // ReSharper disable PossibleInvalidOperationException
            return repository
                .Where(pos => pos.FaLeistungID == faLeistungID)
                .Where(pos => pos.BaPersonID == baPersonID)
                .WhereIf(datumVon.HasValue && stichtagInklusive, pos => pos.DatumBis == null || pos.DatumBis >= datumVon.Value)  //datumVon.Value kann keine InvalidOperationException werfen (ist mit WhereIf geprüft)
                .WhereIf(datumBis.HasValue && stichtagInklusive, pos => pos.DatumVon <= datumBis.Value)  //datumBis.Value kann keine InvalidOperationException werfen (ist mit WhereIf geprüft)
                .WhereIf(datumVon.HasValue && !stichtagInklusive, pos => pos.DatumBis == null || pos.DatumBis > datumVon.Value)  //datumVon.Value kann keine InvalidOperationException werfen (ist mit WhereIf geprüft)
                .WhereIf(datumBis.HasValue && !stichtagInklusive, pos => pos.DatumVon < datumBis.Value)  //datumBis.Value kann keine InvalidOperationException werfen (ist mit WhereIf geprüft)
                .Any();
            // ReSharper restore PossibleInvalidOperationException
        }

        /// <summary>
        /// Gets a List of <see cref="WshGrundbudgetPosition"/> with the given <paramref name="faLeistungID"/>. 
        /// Gets also the <see cref="WshGrundbudgetPositionDebitor"/> and <see cref="WshGrundbudgetPositionKreditor"/> informations.
        /// </summary>
        /// <param name="unitOfWork">The UnitOfWork</param>
        /// <param name="faLeistungID">The FaLeistungID of the entity to look for</param>
        /// <returns>The entity list with the given <paramref name="faLeistungID"/></returns>
        public IList<WshGrundbudgetPosition> GetByFaLeistungID(IUnitOfWork unitOfWork, int faLeistungID)
        {
            return GetByFaLeistungID(unitOfWork, faLeistungID, null, false);
        }

        /// <summary>
        /// Holt alle GrundbudgetPositionen, welche zum Datum date aktiv sind.
        /// Ist date null, dann wird nicht gefiltert.
        /// Ist <paramref name="withDateFromFilter"/> <c>false</c> wird das DatumVon nicht gefiltert.
        /// 
        /// Folgende Relationen werden eager geladen:
        /// => KbuKonto
        /// => BaPerson
        /// => WshGrundbudgetPositionKreditor
        /// 
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork</param>
        /// <param name="faLeistungID">Die ID der Leistung</param>
        /// <param name="date">Das Stichdatum zum Filtern der Positionen</param>
        /// <param name="withDateFromFilter">Auf <c>true</c> setzen wenn <paramref name="date"/> das DatumVon nicht gefiltert werden muss</param>
        /// <returns>Eine Liste der Positions-Entitäten</returns>
        public IList<WshGrundbudgetPosition> GetByFaLeistungID(IUnitOfWork unitOfWork, int faLeistungID, DateTime? date, bool withDateFromFilter)
        {
            return GetByFaLeistungID(unitOfWork, faLeistungID, date, withDateFromFilter, null);
        }

        /// <summary>
        /// Holt alle GrundbudgetPositionen, welche zum Datum date aktiv sind.
        /// Ist date null, dann wird nicht gefiltert.
        /// Ist <paramref name="withDateFromFilter"/> <c>false</c> wird das DatumVon nicht gefiltert.
        /// 
        /// Folgende Relationen werden eager geladen:
        /// => KbuKonto
        /// => BaPerson
        /// => WshGrundbudgetPositionKreditor
        /// 
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork</param>
        /// <param name="faLeistungID">Die ID der Leistung</param>
        /// <param name="date">Das Stichdatum zum Filtern der Positionen</param>
        /// <param name="withDateFromFilter">Auf <c>true</c> setzen wenn <paramref name="date"/> das DatumVon nicht gefiltert werden muss</param>
        /// <param name="istAbzug">Definiert ob die Abzug-Positionen geholt werden müssen (<c>true</c>) oder nicht (<c>false</c>)</param>
        /// <returns>Eine Liste der Positions-Entitäten</returns>
        public IList<WshGrundbudgetPosition> GetByFaLeistungID(
            IUnitOfWork unitOfWork,
            int faLeistungID,
            DateTime? date,
            bool withDateFromFilter,
            bool istAbzug)
        {
            return GetByFaLeistungID(unitOfWork, faLeistungID, date, withDateFromFilter, istAbzug as bool?);
        }

        public IQueryable<WshGrundbudgetPosition> GetByFaLeistungIDQueryable(IUnitOfWork unitOfWork,
            int faLeistungID,
            DateTime? date,
            bool withDateFromFilter,
            bool? istAbzug)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);

            return repository
                .Include(pos => pos.WshKategorie)
                .Include(pos => pos.KbuKonto)
                .Include(pos => pos.BaPerson)
                .Include(pos => pos.WshGrundbudgetPositionKreditor.SubInclude(kred => kred.BaZahlungsweg))
                .Include(pos => pos.WshGrundbudgetPositionDebitor)
                .Where(pos => pos.FaLeistungID == faLeistungID)
                .WhereIf(date != null && withDateFromFilter, pos => pos.DatumVon <= date)
                .WhereIf(date != null, pos => pos.DatumBis == null || pos.DatumBis >= date)
                .WhereIf(istAbzug != null, pos => pos.WshKategorie.IstAbzug == istAbzug);
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">The UnitOfWork</param>
        /// <param name="id">The ID of the entity to look for</param>
        /// <returns>The entity with the given <paramref name="id"/></returns>
        public override WshGrundbudgetPosition GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);

            var returnValue = repository
                .Where(gbPosition => gbPosition.WshGrundbudgetPositionID == id)
                .Include(pos => pos.WshGrundbudgetPositionDebitor)
                .Include(pos => pos.WshGrundbudgetPositionKreditor)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'WshGrundbudgetPosition' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Erstellt ein <see cref="BaDebitorDTO"/>, aus Daten in WshGrundbudgetPositionDebitor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="wshGrundbudgetPositionID"></param>
        /// <returns></returns>
        public BaDebitorDTO GetDebitorDTO(IUnitOfWork unitOfWork, int wshGrundbudgetPositionID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repositoryDebitor = UnitOfWork.GetRepository<WshGrundbudgetPositionDebitor>(unitOfWork);
            var debitor = repositoryDebitor.FirstOrDefault(x => x.WshGrundbudgetPositionID == wshGrundbudgetPositionID);

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

        public LOVsGenerated.SysEditMode GetSysEditModePersonBetrifft(int kbuKontoId, DateTime? datumVon, DateTime? datumBis)
        {
            var wshKbuKontoService = Container.Resolve<WshKbuKontoService>();
            return wshKbuKontoService.GetSysEditModeBetrifftPerson(null, kbuKontoId, datumVon, datumBis);
        }

        /// <summary>
        /// Erstellt das BaZahlungswegDTO für die Position als Kreditorinformationen.
        /// Hinweis: In Zukunft kann es mehrere Kreditoren pro Position geben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionID"></param>
        /// <returns>Das DTO. Kann null sein, wenn es keinen Kreditor gibt.</returns>
        public BaZahlungswegDTO GetZahlungswegDTO(IUnitOfWork unitOfWork, int positionID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repositoryKreditor = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);

            int? baZahulngswegId = repositoryKreditor
                .Where(x => x.WshGrundbudgetPositionID == positionID)
                .Select(x => x.BaZahlungswegID).FirstOrDefault();
            if (baZahulngswegId.HasValue)
            {
                BaZahlungswegSearchService searchService = Container.Resolve<BaZahlungswegSearchService>();
                return searchService.GetBaZahlungswegDTO(unitOfWork, baZahulngswegId.Value);
            }

            return null;
        }

        /// <summary>
        /// Gibt es für diese Leistung GrundbudgetPositionen
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="faLeistung">ID der Leistung</param>
        /// <returns><c>true</c> wenn GrundbudgetPositionen vorhanden sind, sonst <c>false</c></returns>
        public bool HasWshGrundbudgetPosition(IUnitOfWork unitOfWork, int faLeistung)
        {
            return GetByFaLeistungIDQueryable(unitOfWork, faLeistung, null, false, null).Any();
        }

        public override KissServiceResult NewData(out WshGrundbudgetPosition newData)
        {
            var result = base.NewData(out newData);

            if (result)
            {
                //Gemäss UserStory 7472-010 sol Datum von der nächste Monat sein.
                //mit Ausnahme berechnetes GBL
                DateTime nextMonth = DateTime.Today.AddMonths(1);
                newData.DatumVon = new DateTime(nextMonth.Year, nextMonth.Month, 1);
            }

            return result;
        }

        /// <summary>
        /// Speichert die Grundbudgetposition ab.
        /// Speichert auch den WshGrundbudgetPositionKreditor und -Debitor. 
        /// </summary>
        public KissServiceResult SaveData(
            IUnitOfWork unitOfWork,
            WshGrundbudgetPosition position,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers,
            bool acceptChanges = true,
            bool inMonatsbudgetUebertragen = true)
        {
            KissServiceResult result;

            using (var ts = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

                // Wenn BaPersoID kleiner als null ist, dann bedeutet das keine Auswahl.
                if (position.BaPersonID <= 0)
                {
                    position.BaPerson = null;
                    position.BaPersonID = null;
                }

                // Entscheid Datum auf null setzen wenn Splittingart nicht Entscheid ist
                if (position.DatumEntscheid.HasValue && position.KbuKonto.WshSplittingartCode != (int)LOVsGenerated.WshSplittingart.Entscheid)
                {
                    position.DatumEntscheid = null;
                }

                // FaelligAm nullen, falls Valutas per Lookup bestimmt werden
                LOVsGenerated.WshPeriodizitaet wshPeriodizitaet;
                if (Utils.TryConvertCodeToEnumMember(position.WshPeriodizitaetCode, out wshPeriodizitaet) &&
                    KbuZahlungslaufValutaService.IsWshPeriodizitaetCalculated(wshPeriodizitaet))
                {
                    position.FaelligAm = null;
                }

                // Daten der Position speichern. Inklusiv Kreditor/Debitor wenn es vorhanden ist
                var modifiedProperties = position.ModifiedProperties;
                if (position.WshGrundbudgetPositionKreditor.Count == 1)
                {
                    modifiedProperties.AddRange(position.WshGrundbudgetPositionKreditor.Single().ModifiedProperties);
                    result = SaveKreditorAndPosition(unitOfWork, position, false);
                }
                else if (position.WshGrundbudgetPositionDebitor.Count == 1)
                {
                    modifiedProperties.AddRange(position.WshGrundbudgetPositionDebitor.Single().ModifiedProperties);
                    result = SaveDebitorAndPosition(unitOfWork, position, false);
                }
                else
                {
                    result = base.SaveData(unitOfWork, position, false);
                }

                // nicht weiter gehen falls es bereits Fehler gibt
                if (!result)
                {
                    return result;
                }

                // Position in Monatsbudget übertragen wenn das Flag Planwert nicht gesetzt ist
                if (!position.Planwert && inMonatsbudgetUebertragen)
                {
                    // create new WshPosition* entries based on current data
                    var grundbudgetUebertragenService = Container.Resolve<WshGrundbudgetUebertragenService>();

                    result += grundbudgetUebertragenService.PositionInMonatsbudgetUebertragen(unitOfWork, position.WshGrundbudgetPositionID, DateTime.Today, modifiedProperties, questionsAndAnswers);
                }

                //Transaktion "committen" nur wenn das ServiceResult ok ist
                if (result.IsOk)
                {
                    ts.Complete();
                }
            }

            if (result.IsOk && acceptChanges)
            {
                position.AcceptChanges();
            }

            return result;
        }

        public override KissServiceResult ValidateInMemory(WshGrundbudgetPosition dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var serviceResult = WshGrundbudgetPositionValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        public override KissServiceResult ValidateOnDatabase(IUnitOfWork unitOfWork, WshGrundbudgetPosition dataToValidate)
        {
            // Wurde das DatumBis verändert?
            if (dataToValidate.ChangeTracker.State == ObjectState.Modified)
            {
                var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(UnitOfWork.GetNew);

                var originalPosition = repository.FirstOrDefault(x => x.WshGrundbudgetPositionID == dataToValidate.WshGrundbudgetPositionID);

                if (originalPosition != null && ((originalPosition.DatumBis == null && dataToValidate.DatumBis != null)
                                                 || (dataToValidate.DatumBis < originalPosition.DatumBis)))
                {
                    // Datum wurde verändert, abbrechen, falls gelbe MB-Positionen existieren
                    DateTime? first, last;
                    bool nurGraue = AreAllDependingPositionsGray(
                        null, dataToValidate.WshGrundbudgetPositionID, out first, out last, dataToValidate.WshKategorie.IstAbzug);

                    if (!nurGraue && last.HasValue && last.Value > dataToValidate.DatumBis)
                    {
                        return new KissServiceResult(
                            KissServiceResult.ResultType.Error,
                            "WshGrundbudgetPositionService_CannotChangeDate",
                            "Es existieren bereits freigegebene Positionen nach dem gewählten Datum.");
                    }
                }
            }

            KbuKontoValidationDTO validationDTO = new KbuKontoValidationDTO
            {
                DatumVon = dataToValidate.DatumVon,
                DatumBis = dataToValidate.DatumBis,
                LeistungWsh = true,
                Grundbudget = true,
                KbuKontoID = dataToValidate.KbuKontoID,
                WshKategorieID = dataToValidate.WshKategorieID,
                PersonAusgewaehlt = dataToValidate.BaPersonID.HasValue && dataToValidate.BaPersonID.Value > 0
            };
            var kontoService = Container.Resolve<WshKbuKontoService>();
            var serviceResult = kontoService.IsValidKbuKontoWshKategorieKombination(unitOfWork, validationDTO);
            if (serviceResult.IsError)
            {
                return serviceResult;
            }

            return base.ValidateOnDatabase(unitOfWork, dataToValidate);
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Löscht alle WshGrundBudgetPosition* der GrundbudgetPosition.
        /// 
        /// TODO: Zurzeit werden noch alle WshPositionen* gelöscht, ohne Validierung auf Änderungen oder Belege!
        /// </summary>
        /// <param name="unitOfWork">Das UnitOfWork, welches verwendet werden soll</param>
        /// <param name="wshGrundbudgetPositionID">ID der GrundbudgetPosition</param>
        private static void DeleteWshPositionInclBelongingData(IUnitOfWork unitOfWork, int wshGrundbudgetPositionID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var wshPosition = GetWshPositionByWshGrundbudgetPositionID(unitOfWork, wshGrundbudgetPositionID);

            if (wshPosition == null)
            {
                return;
            }

            var wshPositionService = Container.Resolve<WshPositionService>();

            wshPosition
                .ToList()
                .ForEach(p => wshPositionService.DeleteData(unitOfWork, p));

            unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Holt alle Positionen, welche für die gegebene GrundbudgetPosition vorhanden sind
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork</param>
        /// <param name="wshGrundbudgetPositionID">Die ID der GrundbudgetPosition</param>
        /// <returns>Eine Liste der WshPositions-Entitäten</returns>
        private static IList<WshPosition> GetWshPositionByWshGrundbudgetPositionID(IUnitOfWork unitOfWork, int wshGrundbudgetPositionID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            var query = repository
                .Where(pos => pos.WshGrundbudgetPositionID == wshGrundbudgetPositionID)
                .Select(pos => pos).ToList();

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return query;
        }

        private static DateTime Max(DateTime d1, DateTime d2)
        {
            return d1 > d2 ? d1 : d2;
        }

        private static DateTime Min(DateTime d1, DateTime d2)
        {
            return d1 < d2 ? d1 : d2;
        }

        #endregion

        #region Private Methods

        private IList<WshGrundbudgetPosition> GetByFaLeistungID(
            IUnitOfWork unitOfWork,
            int faLeistungID,
            DateTime? date,
            bool withDateFromFilter,
            bool? istAbzug)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var returnValue = GetByFaLeistungIDQueryable(unitOfWork, faLeistungID, date, withDateFromFilter, istAbzug).ToList();

            returnValue.ForEach(SetEntityValidator);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        private KissServiceResult SaveDebitorAndPosition(IUnitOfWork unitOfWork, WshGrundbudgetPosition position, bool acceptChanges)
        {
            var debitorService = Container.Resolve<WshGrundbudgetPositionDebitorService>();

            var debitor = position.WshGrundbudgetPositionDebitor.Single();

            // Debitor löschen, wenn keine Person oder Institution ausgewählt ist
            if (debitor.BaPersonID == null && debitor.BaInstitutionID == null)
            {
                if (debitor.ChangeTracker.State != ObjectState.Added)
                {
                    debitorService.DeleteDebitor(unitOfWork, position.WshGrundbudgetPositionID);
                }

                return SaveData(unitOfWork, position);
            }

            var result = debitorService.ValidateAndInit(unitOfWork, debitor);

            if (!result)
            {
                return result;
            }

            result += SaveData(unitOfWork, position, acceptChanges);

            if (!result)
            {
                return result;
            }

            return debitorService.SaveData(unitOfWork, debitor, acceptChanges);
        }

        private KissServiceResult SaveKreditorAndPosition(IUnitOfWork unitOfWork, WshGrundbudgetPosition position, bool acceptChanges)
        {
            var grundbudgetPositionKreditorService = Container.Resolve<WshGrundbudgetPositionKreditorService>();

            var kreditor = position.WshGrundbudgetPositionKreditor.Single();

            if (position.KbuAuszahlungArtCode != Convert.ToInt32(LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung))
            {
                kreditor.MitteilungZeile1 = "";
                kreditor.MitteilungZeile2 = "";
                kreditor.MitteilungZeile3 = "";
                kreditor.MitteilungZeile4 = "";
                kreditor.BaZahlungsweg = null;
            }

            var result = grundbudgetPositionKreditorService.ValidateAndInit(unitOfWork, kreditor);

            if (!result.IsOk)
            {
                return result;
            }

            result += SaveData(unitOfWork, position, acceptChanges);

            if (!result.IsOk)
            {
                return result;
            }

            return grundbudgetPositionKreditorService.SaveData(unitOfWork, kreditor, acceptChanges);
        }

        #endregion

        #endregion
    }
}