using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.Vm;

namespace Kiss.BL.Vm
{
    public class VmKlientenbudgetDTOService : ServiceBase, IServiceCRUD<VmKlientenbudgetDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly VmKlientenbudgetService _klientenbudgetService;
        private readonly VmPositionDTOService _positionDtoService;

        #endregion

        #endregion

        #region Constructors

        private VmKlientenbudgetDTOService()
        {
            _klientenbudgetService = Container.Resolve<VmKlientenbudgetService>();
            _positionDtoService = Container.Resolve<VmPositionDTOService>();
        }

        #endregion

        #region EventHandlers

        private KissServiceResult StatusWechsel_UpdatePositionen(IUnitOfWork unitOfWork, VmKlientenbudgetDTO dto)
        {
            if (dto == null)
            {
                return KissServiceResult.Ok();
            }

            var serviceResult = KissServiceResult.Ok();

            if (dto.VmKlientenbudget.VmKlientenbudgetStatusEnum == LOVsGenerated.VmKlientenbudgetStatus.InOrdnung)
            {
                //Status hat gewechselt auf InOrdnung

                var ivRentePosition = dto.Einnahmen
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.EinnIvRente);
                var ahvRentePosition = dto.Einnahmen
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.EinnAhvRente);
                var ahvBeitraegePosition = dto.FixeKosten
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.AusgAhvBeitraege);
                var elFreibetragPosition = dto.Vermoegen
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElFreibetrag);
                var elBerechnungPosition = dto.Vermoegen
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElBerechnung);
                var mietzinsPosition = dto.FixeKosten
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.AusgMietzins);
                var heimkostenPosition = dto.FixeKosten
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.AusgHeimkosten);
                var heizNebenkostenPosition = dto.FixeKosten
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.AusgHeizUndNebenkosten);
                var energiePosition = dto.FixeKosten
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.AusgEnergie);

                var positionsToDelete = new List<Tuple<bool, ObservableCollection<VmPositionDTO>, VmPositionDTO>>();

                //Kein Wert in IV-Rente und AHV-Rente -> "ELFreibetrag" + "Vermögen EL-Berechnung" löschen
                bool condition = (ivRentePosition == null || (ivRentePosition.VmPosition.BetragMonatlich ?? 0) == 0)
                                 && (ahvRentePosition == null || (ahvRentePosition.VmPosition.BetragMonatlich ?? 0) == 0);
                positionsToDelete.Add(
                    new Tuple<bool, ObservableCollection<VmPositionDTO>, VmPositionDTO>(
                        condition,
                        dto.Vermoegen,
                        elFreibetragPosition));
                positionsToDelete.Add(
                    new Tuple<bool, ObservableCollection<VmPositionDTO>, VmPositionDTO>(
                        condition,
                        dto.Vermoegen,
                        elBerechnungPosition));

                //Mietzins hat Wert -> "Heimkosten" löschen
                condition = mietzinsPosition != null && mietzinsPosition.VmPosition.BetragMonatlich > 0;
                positionsToDelete.Add(
                    new Tuple<bool, ObservableCollection<VmPositionDTO>, VmPositionDTO>(
                        condition,
                        dto.FixeKosten,
                        heimkostenPosition));

                //Heimkosten hat Wert -> "Mietzins", "Heiz- und NK", "Energie" löschen
                condition = heimkostenPosition != null && heimkostenPosition.VmPosition.BetragMonatlich > 0;
                positionsToDelete.Add(
                    new Tuple<bool, ObservableCollection<VmPositionDTO>, VmPositionDTO>(
                        condition,
                        dto.FixeKosten,
                        mietzinsPosition));
                positionsToDelete.Add(
                    new Tuple<bool, ObservableCollection<VmPositionDTO>, VmPositionDTO>(
                        condition,
                        dto.FixeKosten,
                        heizNebenkostenPosition));
                positionsToDelete.Add(
                    new Tuple<bool, ObservableCollection<VmPositionDTO>, VmPositionDTO>(
                        condition,
                        dto.FixeKosten,
                        energiePosition));

                //AHV-Rente hat Wert -> "AHV-Beiträge" löschen
                condition = ahvRentePosition != null && ahvRentePosition.VmPosition.BetragMonatlich > 0;
                positionsToDelete.Add(
                    new Tuple<bool, ObservableCollection<VmPositionDTO>, VmPositionDTO>(
                        condition,
                        dto.FixeKosten,
                        ahvBeitraegePosition));

                // alle Positionen die automatisch gelöscht werden müssen löschen
                foreach (var tuple in positionsToDelete)
                {
                    bool tupleCondition = tuple.Item1;
                    var tupleCollection = tuple.Item2;
                    var tuplePosition = tuple.Item3;

                    if (tupleCondition)
                    {
                        serviceResult += _positionDtoService.DeleteData(unitOfWork, tuplePosition);
                        if (!serviceResult.IsOk)
                        {
                            return serviceResult;
                        }

                        tupleCollection.Remove(tuplePosition);
                    }
                }
            }

            return serviceResult;
        }

        private KissServiceResult StatusWechsel_Validate(VmKlientenbudgetDTO dto)
        {
            if (dto == null)
            {
                return KissServiceResult.Ok();
            }

            var serviceResult = KissServiceResult.Ok();

            if (dto.VmKlientenbudget.VmKlientenbudgetStatusEnum == LOVsGenerated.VmKlientenbudgetStatus.InOrdnung)
            {
                //Status hat gewechselt auf InOrdnung

                int inOrdnungCount = 0;

                // bei neuem Budget nicht überprüfen sonst kann es nicht archiviert werden
                if(dto.ChangeTracker.State != ObjectState.Added)
                {
                    inOrdnungCount = _klientenbudgetService.GetAnzahlBudgetsMitStatus(
                    null, dto.VmKlientenbudget.FaLeistungID, LOVsGenerated.VmKlientenbudgetStatus.InOrdnung);
                }

                //gibt es bereits ein Klientenbudget mit Status In Ordnung?
                if (inOrdnungCount > 0)
                {
                    serviceResult += new KissServiceResult(
                        ServiceResultType.Error, "Budget kann nicht auf 'in Ordnung' gesetzt werden. Es gibt bereits ein Budget mit diesem Status.");
                }

                var ivRentePosition = dto.Einnahmen
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.EinnIvRente);
                var ahvRentePosition = dto.Einnahmen
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.EinnAhvRente);
                var elFreibetragPosition = dto.Vermoegen
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElFreibetrag);
                var elVermoegenPosition = dto.Vermoegen
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElBerechnung);
                var mietzinsPosition = dto.FixeKosten
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.AusgMietzins);
                var heimkostenPosition = dto.FixeKosten
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.AusgHeimkosten);
                var ahvBeitragPosition = dto.FixeKosten
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.AusgAhvBeitraege);

                //Wert vorhanden in IV-Rente oder AHV-Rente -> EL-Freibetrag-Position muss existieren
                if (((ivRentePosition != null && ivRentePosition.VmPosition.BetragMonatlich > 0) //Wert vorhanden in IV-Rente
                     || (ahvRentePosition != null && ahvRentePosition.VmPosition.BetragMonatlich > 0)) //Wert vorhanden in AHV-Rente
                    && (elFreibetragPosition == null || elFreibetragPosition.VmPosition.Saldo == null)) //EL-Freibetrag-Position existiert nicht / leer
                {
                    serviceResult += new KissServiceResult(
                        ServiceResultType.Error, "Wenn 'IV-Rente' oder 'AHV-Rente' gesetzt ist, müssen 'EL-Freibetrag' und 'Vermögen EL-Berechnung' ebenfalls gesetzt sein.");
                }

                //EL-Freibetrag-Position existiert nicht / leer
                if (elFreibetragPosition != null && elFreibetragPosition.VmPosition.Saldo != null
                    && elVermoegenPosition == null)
                {
                    serviceResult += new KissServiceResult(
                        ServiceResultType.Error, "Wenn 'EL-Freibetrag' gesetzt ist, muss 'Vermögen EL-Berechnung' vorhanden sein.");
                }

                //Entweder Mietzins oder Heimkosten, aber nicht beide ausgefüllt
                if (mietzinsPosition != null && mietzinsPosition.VmPosition.BetragMonatlich > 0
                    && heimkostenPosition != null && heimkostenPosition.VmPosition.BetragMonatlich > 0)
                {
                    serviceResult += new KissServiceResult(
                        ServiceResultType.Error, "'Mietzins' und 'Heimkosten' dürfen nicht gleichzeitig erfasst werden.");
                }

                //Wenn AHV-Rente erfasst, darf kein AHV-Beitrag erfasst sein
                if (ahvRentePosition != null && ahvRentePosition.VmPosition.BetragMonatlich > 0
                    && ahvBeitragPosition != null && ahvBeitragPosition.VmPosition.BetragMonatlich > 0)
                {
                    serviceResult += new KissServiceResult(
                        ServiceResultType.Error, "'AHV-Rente' und 'AHV-Beitrag' dürfen nicht gleichzeitig erfasst werden.");
                }
            }

            return serviceResult;
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult BudgetArchivieren(IUnitOfWork unitOfWork, int faLeistungID, VmKlientenbudgetDTO selectedBudget, ICollection<VmKlientenbudgetDTO> budgets)
        {
            var budgetCollection = budgets.Select(b => b.VmKlientenbudget).ToList();
            return _klientenbudgetService.BudgetArchivieren(unitOfWork, faLeistungID, selectedBudget.VmKlientenbudget, budgetCollection);
        }

        /// <summary>
        /// Prüft, ob ein neues Budget erstellt werden darf (es darf nur 1 Budget in Bearbeitung sein).
        /// </summary>
        /// <remarks>
        /// Kann leider nicht in NewData aufgerufen werden, da man dort die Leistung und bestehende EntityList nicht hat.
        /// </remarks>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungId"></param>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public KissServiceResult CanCreateNewData(IUnitOfWork unitOfWork, int faLeistungId, IEnumerable<VmKlientenbudgetDTO> entityList)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var existing = _klientenbudgetService.GetByFaLeistungId(unitOfWork, faLeistungId);
            var inBearbeitung = existing.Any(x => x.VmKlientenbudgetStatusCode == (int)LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung);
            inBearbeitung |= entityList.Any(x => x.VmKlientenbudget.VmKlientenbudgetStatusCode == (int)LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung);

            if (inBearbeitung)
            {
                return KissServiceResult.Error(new Exception("Es gibt bereits ein Budget in Bearbeitung."));
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Kopiert ein Klientenbudget mit allen zugehörigen Positionen.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="vmKlientenbudgetDto"></param>
        /// <param name="budgets"> </param>
        /// <param name="newDto"></param>
        /// <param name="user"> </param>
        /// <returns></returns>
        public KissServiceResult CopyBudget(
            IUnitOfWork unitOfWork,
            VmKlientenbudgetDTO vmKlientenbudgetDto,
            XUser user,
            ICollection<VmKlientenbudgetDTO> budgets,
            out VmKlientenbudgetDTO newDto)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            // Validate
            var existing = _klientenbudgetService.GetByFaLeistungId(unitOfWork, vmKlientenbudgetDto.VmKlientenbudget.FaLeistungID);

            if (existing.Any(x => x.VmKlientenbudgetStatusEnum == LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung))
            {
                newDto = null;
                return KissServiceResult.Error("VmKlientenbudgetDTOService.CopyInBearbeitung", "Das Budget konnte nicht kopiert werden, da bereits ein Budget in Bearbeitung existiert.");
            }

            // Create new
            var result = NewData(out newDto, false);

            if (!result)
            {
                return result;
            }

            // VmKlientenbudget kopieren
            CopyVmKlientenbudgetProperties(vmKlientenbudgetDto.VmKlientenbudget, newDto.VmKlientenbudget);

            // Update Properties
            newDto.VmKlientenbudget.VmKlientenbudgetStatusCode = (int)LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung;
            newDto.VmKlientenbudget.XUser = user;

            var gueltigAb = vmKlientenbudgetDto.VmKlientenbudget.GueltigAb.AddMonths(1);
            newDto.VmKlientenbudget.GueltigAb = new DateTime(gueltigAb.Year, gueltigAb.Month, 1);

            // VmPositionen kopieren
            var positionen = _positionDtoService.GetByVmKlientenbudgetId(unitOfWork, vmKlientenbudgetDto.VmKlientenbudget.VmKlientenbudgetID);

            foreach (var vmPosition in positionen)
            {
                VmPositionDTO newPos;
                result = _positionDtoService.NewData(out newPos);

                if (!result)
                {
                    return result;
                }

                newPos.VmPosition.VmKlientenbudget = newDto.VmKlientenbudget;
                newPos.VmPosition.VmKlientenbudgetID = newDto.VmKlientenbudget.VmKlientenbudgetID;

                CopyVmPositionProperties(vmPosition, newPos.VmPosition);
            }

            return result;
        }

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, VmKlientenbudgetDTO dataToDelete, bool saveChanges = true)
        {
            return _klientenbudgetService.DeleteData(unitOfWork, dataToDelete.VmKlientenbudget);
        }

        /// <summary>
        /// Hole alle Klientenbudgets einer Leistung
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="faLeistungId">ID der Leistung</param>
        /// <returns>Liste von Klientenbudgets</returns>
        public ObservableCollection<VmKlientenbudgetDTO> GetByFaLeistungId(IUnitOfWork unitOfWork, int faLeistungId)
        {
            var list = _klientenbudgetService.GetByFaLeistungId(unitOfWork, faLeistungId);

            var result = from vmKlientenbudget in list
                         select new VmKlientenbudgetDTO
                         {
                             VmKlientenbudget = vmKlientenbudget
                         };

            return new ObservableCollection<VmKlientenbudgetDTO>(result);
        }

        public VmKlientenbudgetDTO GetById(IUnitOfWork unitOfWork, int vmKlientenbudgetId)
        {
            var budget = _klientenbudgetService.GetById(unitOfWork, vmKlientenbudgetId);

            var dto = new VmKlientenbudgetDTO
            {
                VmKlientenbudget = budget
            };

            return dto;
        }

        public ObservableCollection<VmKlientenbudgetDTO> GetData(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        public bool NeedToSaveData(VmKlientenbudgetDTO dataToSave)
        {
            if (dataToSave == null)
            {
                return false;
            }

            if (dataToSave.ChangeTracker.State != ObjectState.Unchanged)
            {
                return true;
            }

            if (!dataToSave.IsVermoegenEmpty && dataToSave.Vermoegen.Any(x => x.ChangeTracker.State != ObjectState.Unchanged))
            {
                return true;
            }

            if (!dataToSave.IsFixeKostenEmpty && dataToSave.FixeKosten.Any(x => x.ChangeTracker.State != ObjectState.Unchanged))
            {
                return true;
            }

            if (!dataToSave.IsEinnahmenEmpty && dataToSave.Einnahmen.Any(x => x.ChangeTracker.State != ObjectState.Unchanged))
            {
                return true;
            }

            if (!dataToSave.IsVariableKostenEmpty && dataToSave.VariableKosten.Any(x => x.ChangeTracker.State != ObjectState.Unchanged))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Neues Budget erstellen mit Standard Positionen
        /// </summary>
        /// <param name="newData">Das neu erstellt Budget</param>
        /// <returns><see cref="KissServiceResult"/></returns>
        public KissServiceResult NewData(out VmKlientenbudgetDTO newData)
        {
            return NewData(out newData, true);
        }

        public KissServiceResult NewData(out VmKlientenbudgetDTO newData, bool createStandardPositionen)
        {
            VmKlientenbudget budget;
            var result = _klientenbudgetService.NewData(out budget, createStandardPositionen);
            newData = new VmKlientenbudgetDTO
            {
                VmKlientenbudget = budget,
                Bearbeiten = true,
            };

            return result;
        }

        /// <summary>
        /// Ein Budget und die abhängigen Positionen speichern
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="dataToSave">Das Budget dass gespeichert werden muss</param>
        /// <returns><see cref="KissServiceResult"/></returns>
        public KissServiceResult SaveData(IUnitOfWork unitOfWork, VmKlientenbudgetDTO dataToSave)
        {
            var result = SaveDataIntern(unitOfWork, dataToSave);

            return result;
        }

        /// <summary>
        /// Eine Liste von Budgets speichern
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="dataToSave">Die Liste die gespeichert werden muss</param>
        /// <returns><see cref="KissServiceResult"/></returns>
        public KissServiceResult SaveData(IUnitOfWork unitOfWork, List<VmKlientenbudgetDTO> dataToSave)
        {
            var result = KissServiceResult.Ok();

            foreach (var vmKlientenbudgetDTO in dataToSave)
            {
                result += SaveData(unitOfWork, vmKlientenbudgetDTO);
            }

            return result;
        }

        public KissServiceResult SaveData(
            IUnitOfWork unitOfWork,
            VmKlientenbudgetDTO dataToSave,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Holt die Positionen eines Klientenbudgets
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="dto">Das <see cref="VmKlientenbudgetDTO"/> für welches die Positionen geholt werden müssen</param>
        /// <returns><see cref="KissServiceResult"/></returns>
        public KissServiceResult SetPositionen(IUnitOfWork unitOfWork, VmKlientenbudgetDTO dto)
        {
            if (dto == null)
            {
                return KissServiceResult.Ok();
            }

            // Positionen nur beim ersten Mal holen
            if (dto.Vermoegen == null)
            {
                IList<VmPosition> positionen;
                if (dto.VmKlientenbudget.VmPosition.Any())
                {
                    // Positionen aus DTO holen für neu erstellte Budgets
                    positionen = dto.VmKlientenbudget.VmPosition;
                }
                else
                {
                    // Positionen aus DB holen für bestehende Budgets
                    positionen = _positionDtoService.GetByVmKlientenbudgetId(unitOfWork, dto.VmKlientenbudget.VmKlientenbudgetID);
                }

                dto.Vermoegen = _positionDtoService.GetByVmKategorie(positionen, LOVsGenerated.VmKategorie.Vermoegen);
                dto.Einnahmen = _positionDtoService.GetByVmKategorie(positionen, LOVsGenerated.VmKategorie.Einnahmen);
                dto.FixeKosten = _positionDtoService.GetByVmKategorie(positionen, LOVsGenerated.VmKategorie.FixeKosten);
                dto.VariableKosten = _positionDtoService.GetByVmKategorie(positionen, LOVsGenerated.VmKategorie.VariableKosten);

                _positionDtoService.SetBudgetBetraege(dto);
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Aktiviert die korrekten Statuseinträge in der übergebenen Statusliste anhand des aktuellen Status
        ///  in Bearbeitung -> in Bearbeitung
        ///                 -> in Ordnung
        ///                 -> Archiviert
        ///  in Ordnung     -> Archiviert
        ///                 -> in Ordnung
        ///  Archiviert     -> Archiviert
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="statusListe"></param>
        /// <returns></returns>
        public KissServiceResult UpdateStatusliste(
            LOVsGenerated.VmKlientenbudgetStatus status,
            IList<XLOVCode> statusListe)
        {
            switch (status)
            {
                case LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung:
                    statusListe.Single(x => x.Code == (int)LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung).IsActive = true;
                    statusListe.Single(x => x.Code == (int)LOVsGenerated.VmKlientenbudgetStatus.InOrdnung).IsActive = true;
                    statusListe.Single(x => x.Code == (int)LOVsGenerated.VmKlientenbudgetStatus.Archiviert).IsActive = true;
                    break;

                case LOVsGenerated.VmKlientenbudgetStatus.InOrdnung:
                    statusListe.Single(x => x.Code == (int)LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung).IsActive = false;
                    statusListe.Single(x => x.Code == (int)LOVsGenerated.VmKlientenbudgetStatus.InOrdnung).IsActive = true;
                    statusListe.Single(x => x.Code == (int)LOVsGenerated.VmKlientenbudgetStatus.Archiviert).IsActive = true;
                    break;

                case LOVsGenerated.VmKlientenbudgetStatus.Archiviert:
                    statusListe.Single(x => x.Code == (int)LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung).IsActive = false;
                    statusListe.Single(x => x.Code == (int)LOVsGenerated.VmKlientenbudgetStatus.InOrdnung).IsActive = false;
                    statusListe.Single(x => x.Code == (int)LOVsGenerated.VmKlientenbudgetStatus.Archiviert).IsActive = true;
                    break;
            }

            return KissServiceResult.Ok();
        }

        #endregion

        #region Private Methods

        private void CopyVmKlientenbudgetProperties(VmKlientenbudget oldEntity, VmKlientenbudget newEntity)
        {
            newEntity.FaLeistung = oldEntity.FaLeistung;
            newEntity.FaLeistungID = oldEntity.FaLeistungID;
            newEntity.GueltigAb = oldEntity.GueltigAb;
            //newEntity.XUser = oldEntity.XUser;
            //newEntity.UserID = oldEntity.UserID;
            //newEntity.VmKlientenbudgetMutationsgrundCode = oldEntity.VmKlientenbudgetMutationsgrundCode;
            newEntity.VmKlientenbudgetStatusCode = oldEntity.VmKlientenbudgetStatusCode;
        }

        private void CopyVmPositionProperties(VmPosition oldEntity, VmPosition newEntity)
        {
            newEntity.Bemerkung = oldEntity.Bemerkung;
            newEntity.BetragJaehrlich = oldEntity.BetragJaehrlich;
            newEntity.BetragMonatlich = oldEntity.BetragMonatlich;
            newEntity.DatumSaldoPer = oldEntity.DatumSaldoPer;
            newEntity.IstImportiert = oldEntity.IstImportiert;
            newEntity.Name = oldEntity.Name;
            newEntity.Saldo = oldEntity.Saldo;
            newEntity.VmPositionsart = oldEntity.VmPositionsart;
            newEntity.SortKey = oldEntity.SortKey;
            newEntity.VmPositionsartID = oldEntity.VmPositionsartID;
        }

        /// <summary>
        /// Ein Budget und die abhängigen Positionen speichern
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="dataToSave">Das Budget dass gespeichert werden muss</param>
        /// <returns><see cref="KissServiceResult"/></returns>
        private KissServiceResult SaveDataIntern(IUnitOfWork unitOfWork, VmKlientenbudgetDTO dataToSave)
        {
            if (!NeedToSaveData(dataToSave))
            {
                return KissServiceResult.Ok();
            }

            var budget = dataToSave.VmKlientenbudget;
            var initialState = budget.ChangeTracker.State;

            // bei einem neuen Budget gelöschte Positionen nicht auf der DB speichern
            if (dataToSave.ChangeTracker.State == ObjectState.Added)
            {
                var positionToAdd = dataToSave.Vermoegen.Union(dataToSave.Einnahmen.Union(dataToSave.VariableKosten.Union(dataToSave.FixeKosten))).Select(x => x.VmPosition).ToList();

                var positionToRemove = budget.VmPosition.Where(position => !positionToAdd.Contains(position)).ToList();
                foreach (var position in positionToRemove)
                {
                    budget.VmPosition.Remove(position);
                }
            }

            // Hat der Status des Budgets geändert?
            int originalStatusCode;

            var statusFound = budget.OriginalValues.TryGetValue(
                PropertyName.GetPropertyName(() => budget.VmKlientenbudgetStatusCode), out originalStatusCode);

            var result = KissServiceResult.Ok();

            if (statusFound && originalStatusCode != budget.VmKlientenbudgetStatusCode || initialState == ObjectState.Added)
            {
                //status hat gewechselt
                result += StatusWechsel_Validate(dataToSave);
            }

            if (!result.IsOk)
            {
                return result;
            }

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            using (var ts = new TransactionScope())
            {
                //Andere Budget des Users als unchanged markieren.
                //Wir hatten ab und zu eine Optimistic-Lock Exception.
                //foreach (var budgetOfUser in budget.XUser.VmKlientenbudget)
                //{
                //    if (budgetOfUser != budget && budgetOfUser.ChangeTracker.State != ObjectState.Added)
                //    {
                //        budgetOfUser.MarkAsUnchanged();
                //        foreach (var pos in budgetOfUser.VmPosition)
                //        {
                //            pos.MarkAsUnchanged();
                //        }
                //    }
                //    else
                //    {
                //        foreach (var pos in budgetOfUser.VmPosition)
                //        {
                //            if (pos.ChangeTracker.State == ObjectState.Deleted)
                //            {
                //                pos.MarkAsUnchanged();
                //            }
                //        }
                //    }
                //}

                result += _klientenbudgetService.SaveData(unitOfWork, budget);

                if (result.IsError)
                {
                    return result;
                }

                if (!dataToSave.CanEdit)
                {
                    dataToSave.Bearbeiten = false;
                }

                if (!dataToSave.IsFixeKostenEmpty)
                {
                    foreach (var vmPosition in dataToSave.FixeKosten)
                    {
                        result += _positionDtoService.SaveData(unitOfWork, vmPosition);
                    }
                }

                if (!dataToSave.IsEinnahmenEmpty)
                {
                    foreach (var vmPosition in dataToSave.Einnahmen)
                    {
                        result += _positionDtoService.SaveData(unitOfWork, vmPosition);
                    }
                }

                if (!dataToSave.IsVariableKostenEmpty)
                {
                    foreach (var vmPosition in dataToSave.VariableKosten)
                    {
                        result += _positionDtoService.SaveData(unitOfWork, vmPosition);
                    }
                }

                if (!dataToSave.IsVermoegenEmpty)
                {
                    foreach (var vmPosition in dataToSave.Vermoegen)
                    {
                        result += _positionDtoService.SaveData(unitOfWork, vmPosition);
                    }
                }

                if ((statusFound && originalStatusCode != budget.VmKlientenbudgetStatusCode) || initialState == ObjectState.Added)
                {
                    //status hat gewechselt
                    result += StatusWechsel_UpdatePositionen(unitOfWork, dataToSave);
                }

                if (result.IsOk)
                {
                    ts.Complete();
                }
            }

            if (result.IsOk)
            {
                dataToSave.ChangeTracker.State = ObjectState.Unchanged;
            }

            return result;
        }

        #endregion

        #endregion
    }
}