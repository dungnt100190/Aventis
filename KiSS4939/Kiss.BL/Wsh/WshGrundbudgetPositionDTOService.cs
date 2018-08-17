using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;

using Kiss.BL.Ba;
using Kiss.BL.Fa;
using Kiss.BL.Kbu;
using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.BL.Wsh;
using Kiss.Interfaces.IoC;
using Kiss.Interfaces.ViewModel;
using Kiss.Model;
using Kiss.Model.DTO.BA;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage a WshGrundbudgetPositionDTO.
    /// </summary>
    public class WshGrundbudgetPositionDTOService : ServiceBase, IServiceCRUD<WshGrundbudgetPositionDTO>, IWshPositionService
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshGrundbudgetPositionService _wshGrundbudgetPositionService;

        #endregion

        #endregion

        #region Constructors

        private WshGrundbudgetPositionDTOService()
        {
            _wshGrundbudgetPositionService = Container.Resolve<WshGrundbudgetPositionService>();
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool AreAllDependingPositionsGray(IUnitOfWork unitOfWork,
            int wshGrundbudgetPositionID,
            out DateTime? firstNonGrayPosition,
            out DateTime? lastNonGrayPosition)
        {
            return _wshGrundbudgetPositionService.AreAllDependingPositionsGray(
                unitOfWork, wshGrundbudgetPositionID, out firstNonGrayPosition, out lastNonGrayPosition);
        }

        /// <summary>
        /// Zu den Monatsbudgetpositionen werden automatisch 
        /// KbuBelegPositionen erzeugt.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        public KissServiceResult DauerauftragAktivieren(IUnitOfWork unitOfWork, int faLeistungId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            KissServiceResult result;

            //2. Flag auf Positionen setzen.
            using (TransactionScope ts = new TransactionScope())
            {
                var positionsService = Container.Resolve<WshPositionService>();
                result = positionsService.DauerauftragFlagSetzen(unitOfWork, faLeistungId, true);
                if(!result.IsOk)
                {
                    return result;
                }

                var kbuBelegService = Container.Resolve<KbuBelegService>();
                result = kbuBelegService.CreateBelegeFuerDauerauftrag(null, faLeistungId);
                if(!result.IsOk)
                {
                    return result;
                }
                ts.Complete();
            }

            return result;
        }

        /// <summary>
        /// Die automatisch erzeugten Belegpositionen werden gelöscht.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        public KissServiceResult DauerauftragDeaktivieren(IUnitOfWork unitOfWork, int faLeistungId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            KissServiceResult result;

            //2. Flag auf Positionen setzen.
            using (TransactionScope ts = new TransactionScope())
            {

                var kbuBelegService = Container.Resolve<KbuBelegService>();
                result = kbuBelegService.DeleteFreigegebeneBelegeVonDauerauftrag(null, faLeistungId);
                if (!result.IsOk)
                {
                    return result;
                }

                var positionsService = Container.Resolve<WshPositionService>();
                result = positionsService.DauerauftragFlagSetzen(unitOfWork, faLeistungId, false);
                if (!result.IsOk)
                {
                    return result;
                }               

                ts.Complete();
            }

            return result;
        }

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshGrundbudgetPositionDTO dataToDelete, bool saveChanges = true)
        {
            return _wshGrundbudgetPositionService.DeleteData(unitOfWork, dataToDelete.WshGrundbudgetPosition, saveChanges);
        }

        public bool DoPositionenExist(
            IUnitOfWork unitOfWork,
            int faLeistungID,
            int baPersonID,
            DateTime? datumVon,
            DateTime? datumBis,
            bool stichtagInklusive)
        {
            return _wshGrundbudgetPositionService.DoPositionenExist(unitOfWork, faLeistungID, baPersonID, datumVon, datumBis, stichtagInklusive);
        }

        /// <summary>
        /// Holt alle Grundbudgetpositionen die keine Abzug-Positionen sind
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="faLeistungId">Die FaLeistungID, mit der Positionen gesucht werden sollen.</param>
        /// <returns>Eine Liste der Positions-Entitäten</returns>
        public IList<WshGrundbudgetPositionDTO> GetByFaLeistungID(IUnitOfWork unitOfWork, int faLeistungId)
        {
            return GetByFaLeistungID(unitOfWork, faLeistungId, null, false);
        }

        /// <summary>
        /// Holt alle Grundbudgetpositionen die keine Abzug-Positionen sind
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="faLeistungId">Die FaLeistungID, mit der Positionen gesucht werden sollen.</param>
        /// <param name="date">Das Stichdatum zum Filtern der Positionen.</param>
        /// <param name="withDateFromFilter">Auf <c>true</c> setzen, wenn <paramref name="date"/> das DatumVon nicht gefiltert werden muss.</param>
        /// <param name="istAbzug">Auf <c>true</c> setzen, wenn nur Abzüge zurückgeliefert werden sollen.</param>
        /// <returns>Eine Liste der Positions-Entitäten</returns>
        public IList<WshGrundbudgetPositionDTO> GetByFaLeistungID(
            IUnitOfWork unitOfWork,
            int faLeistungId,
            DateTime? date = null,
            bool withDateFromFilter = false,
            bool istAbzug = false)
        {
            var positionDtos = _wshGrundbudgetPositionService
                .GetByFaLeistungID(unitOfWork, faLeistungId, date, withDateFromFilter, istAbzug)
                .Select(p => new WshGrundbudgetPositionDTO { WshGrundbudgetPosition = p })
                .ToList();

            SetDtoProperties(unitOfWork, positionDtos);

            return positionDtos;
        }

        public WshGrundbudgetPosition GetById(IUnitOfWork unitOfWork, int id)
        {
            return _wshGrundbudgetPositionService.GetById(unitOfWork, id);
        }

        public ObservableCollection<WshGrundbudgetPositionDTO> GetData(IUnitOfWork unitOfWork)
        {
            var positionDtos = _wshGrundbudgetPositionService
                .GetData(unitOfWork)
                .Select(p => new WshGrundbudgetPositionDTO { WshGrundbudgetPosition = p })
                .ToList();

            SetDtoProperties(unitOfWork, positionDtos);

            return new ObservableCollection<WshGrundbudgetPositionDTO>(positionDtos);
        }

        public BaDebitorDTO GetDebitorDTO(IUnitOfWork unitOfWork, int wshPositionID)
        {
            return _wshGrundbudgetPositionService.GetDebitorDTO(unitOfWork, wshPositionID);
        }

        public LOVsGenerated.SysEditMode GetSysEditModePersonBetrifft(int kbuKontoId, DateTime? datumVon, DateTime? datumBis)
        {
            return _wshGrundbudgetPositionService.GetSysEditModePersonBetrifft(kbuKontoId, datumVon, datumBis);
        }

        public BaZahlungswegDTO GetZahlungswegDTO(IUnitOfWork unitOfWork, int positionID)
        {
            return _wshGrundbudgetPositionService.GetZahlungswegDTO(unitOfWork, positionID);
        }

        public bool HasWshGrundbudgetPosition(IUnitOfWork unitOfWork, int faLeistung)
        {
            return _wshGrundbudgetPositionService.HasWshGrundbudgetPosition(unitOfWork, faLeistung);
        }

        public bool NeedToSaveData(WshGrundbudgetPositionDTO positionDTO)
        {
            if (positionDTO == null)
            {
                return false;
            }

            var kreditor = positionDTO.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.FirstOrDefault();
            var debitor = positionDTO.WshGrundbudgetPosition.WshGrundbudgetPositionDebitor.FirstOrDefault();

            // Check kreditor and debitor if position is unchanged
            if (positionDTO.WshGrundbudgetPosition.ChangeTracker.State == ObjectState.Unchanged)
            {
                if ((kreditor == null && debitor == null)
                    || (kreditor != null && kreditor.ChangeTracker.State == ObjectState.Unchanged)
                    || (debitor != null && debitor.ChangeTracker.State == ObjectState.Unchanged))
                {
                    return false;
                }
            }

            return true;
        }

        public KissServiceResult NewData(out WshGrundbudgetPositionDTO newData)
        {
            newData = new WshGrundbudgetPositionDTO();
            WshGrundbudgetPosition wshGrundbudgetPosition;

            var serviceResult = _wshGrundbudgetPositionService.NewData(out wshGrundbudgetPosition);
            newData.WshGrundbudgetPosition = wshGrundbudgetPosition;

            return serviceResult;
        }

        /// <summary>
        /// NotSupportedException
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dataToSave"></param>
        /// <returns></returns>
        public KissServiceResult SaveData(IUnitOfWork unitOfWork, WshGrundbudgetPositionDTO dataToSave)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// NotSupportedException
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dataToSave"></param>
        /// <returns></returns>
        public KissServiceResult SaveData(IUnitOfWork unitOfWork, List<WshGrundbudgetPositionDTO> dataToSave)
        {
            throw new NotSupportedException();
        }

        public KissServiceResult SaveData(
            IUnitOfWork unitOfWork,
            WshGrundbudgetPositionDTO selectedEntity,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            // return if there is no need to save
            if (!NeedToSaveData(selectedEntity))
            {
                return KissServiceResult.Ok();
            }

            var result = ValidateInMemory(selectedEntity);

            if (!result)
            {
                return result;
            }

            return _wshGrundbudgetPositionService.SaveData(unitOfWork, selectedEntity.WshGrundbudgetPosition, questionsAndAnswers);
        }

        /// <summary>
        /// Berechnet den monatlichen Betrag der Position.
        /// </summary>
        /// <param name="positionDto"></param>
        public void SetBetragMonatlich(WshGrundbudgetPositionDTO positionDto)
        {
            var periodizitaet = (LOVsGenerated.WshPeriodizitaet?)positionDto.WshGrundbudgetPosition.WshPeriodizitaetCode;
            var kbuRundungsService = Container.Resolve<KbuGeldbetragRundungsService>();

            if (periodizitaet.HasValue && periodizitaet == LOVsGenerated.WshPeriodizitaet.Quartal ||
                periodizitaet.HasValue && periodizitaet == LOVsGenerated.WshPeriodizitaet.Semester)
            {
                if (!positionDto.WshGrundbudgetPosition.BetragTotal.HasValue)
                {
                    positionDto.WshGrundbudgetPosition.BetragTotal = positionDto.WshGrundbudgetPosition.BetragMonatlich; //todo exception werfen
                    //throw new Exception("BetragTotal muss einen Wert enthalten, wenn Periodizität Quartal ist");
                }

                double numMonth = 3;
                if (periodizitaet == LOVsGenerated.WshPeriodizitaet.Semester)
                {
                    numMonth = 6;
                }

                positionDto.BetragBerechnet = kbuRundungsService.GeldbetragRunden((double)positionDto.WshGrundbudgetPosition.BetragTotal / numMonth);
            }
            else
            {
                positionDto.BetragBerechnet = positionDto.WshGrundbudgetPosition.BetragMonatlich;
            }
        }

        /// <summary>
        /// TODO: similar to WshPositionMonatBudgetDTOService. Refactoring?
        /// </summary>
        /// <param name="positionDto"></param>
        public void SetDebitor(WshGrundbudgetPositionDTO positionDto)
        {
            // Es existiert noch kein Debitor, wir erzeugen einen neuen.
            if (positionDto.SelectedDebitor != null && positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionDebitor.Count == 0)
            {
                var debitorService = Container.Resolve<WshGrundbudgetPositionDebitorService>();
                WshGrundbudgetPositionDebitor debitor;
                debitorService.NewData(out debitor);
                positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionDebitor.Add(debitor);
            }

            // Übertragen der Daten
            if (positionDto.SelectedDebitor != null)
            {
                var debitor = positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionDebitor.First();

                if (positionDto.SelectedDebitor.Type == DebitorType.Person)
                {
                    debitor.BaInstitutionID = null;
                    debitor.BaPersonID = positionDto.SelectedDebitor.BaPersonId;
                }
                else if (positionDto.SelectedDebitor.Type == DebitorType.Institution)
                {
                    debitor.BaInstitutionID = positionDto.SelectedDebitor.BaInstitutionId;
                    debitor.BaPersonID = null;
                }
            }
            else if (positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionDebitor.Count > 0)
            {
                var debitor = positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionDebitor.First();
                debitor.BaPersonID = debitor.BaInstitutionID = null;
            }
        }

        public KissServiceResult SetKreditor(WshGrundbudgetPositionDTO positionDto)
        {
            var grundbudgetPositionKreditorService = Container.Resolve<WshGrundbudgetPositionKreditorService>();
            WshGrundbudgetPositionKreditor kreditor;
            var result = grundbudgetPositionKreditorService.NewData(out kreditor);

            if (!result.IsOk)
            {
                return result;
            }

            positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Add(kreditor);
            UpdateKreditorMitteilungszeile1(positionDto.WshGrundbudgetPosition);

            return result;
        }

        /// <summary>
        /// TODO: similar to WshPositionMonatBudgetDTOService. Refactoring?
        /// </summary>
        /// <param name="positionDto"></param>
        /// <param name="personenHaushaltAlle"></param>
        public void SetZahlungsweg(WshGrundbudgetPositionDTO positionDto, ObservableCollection<BaPerson> personenHaushaltAlle)
        {
            // Es existiert noch kein Kreditor, wir erzeugen einen neuen.
            if (positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Count == 0 && positionDto.SelectedZahlungsweg != null)
            {
                var grundbudgetPositionKreditorService = Container.Resolve<WshGrundbudgetPositionKreditorService>();
                WshGrundbudgetPositionKreditor kreditor;
                grundbudgetPositionKreditorService.NewData(out kreditor);
                positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Add(kreditor);
            }

            // Übertragen der Daten vom DTO in den WshGrundbudgetPositionKreditor.
            if (positionDto.SelectedZahlungsweg != null)
            {
                var kred = positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.First();
                kred.BaZahlungswegID = positionDto.SelectedZahlungsweg.BaZahlungswegID;
            }
            else if (positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Count == 1)
            {
                var kred = positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.First();
                kred.BaZahlungsweg = null;
            }

            // Flag IsAuszahlungDritte updaten
            if (positionDto.SelectedZahlungsweg != null)
            {
                UpdateIsAuszahlungDritte(positionDto, positionDto.SelectedZahlungsweg.BaPersonId, personenHaushaltAlle);
            }
            else
            {
                UpdateIsAuszahlungDritte(positionDto, null, personenHaushaltAlle);
            }
        }

        public void SetZahlungswegStandard(WshGrundbudgetPositionDTO positionDto)
        {
            var standardZahlungsweg = Container.Resolve<BaZahlungswegSearchService>().GetStandardZahlungsweg(
                null, positionDto.WshGrundbudgetPosition.FaLeistungID, Constant.MODULEID_W);
            if (standardZahlungsweg != null)
            {
                positionDto.SelectedZahlungsweg = standardZahlungsweg;
                positionDto.WshGrundbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            }
            else
            {
                positionDto.WshGrundbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.CashBarauszahlung;
            }

            positionDto.WshGrundbudgetPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat;
        }

        public void UpdateAuszahlungstermin(WshGrundbudgetPositionDTO entity)
        {
            if (entity.IstEinnahmeOrHatFaelligAmPeriodizität)
            {
                entity.AuszahlungTermin = entity.WshGrundbudgetPosition.FaelligAm;
                return;
            }

            LOVsGenerated.WshPeriodizitaet periodizität;

            if (Utils.TryConvertCodeToEnumMember(entity.WshGrundbudgetPosition.WshPeriodizitaetCode, out periodizität))
            {
                var zahlungslaufValutaService = Container.Resolve<KbuZahlungslaufValutaService>();
                var daten = zahlungslaufValutaService.GetValutaDatum(
                    null, periodizität, entity.WshGrundbudgetPosition.DatumVon.Year, entity.WshGrundbudgetPosition.DatumVon.Month);
                entity.AuszahlungTermin = daten.Count > 0 ? (DateTime?)daten[0] : null;
            }
        }

        /// <summary>
        /// Flag <see cref="WshGrundbudgetPositionDTO.IsAuszahlungDritte"/> auf grund Kreditor Informationen updaten.
        /// </summary>
        /// <param name="entityList">Liste von DTO zu updaten</param>
        /// <param name="personenHaushaltAlle">personen die im Haushalt sind</param>
        public void UpdateIsAuszahlungDritte(ObservableCollection<WshGrundbudgetPositionDTO> entityList,
            ObservableCollection<BaPerson> personenHaushaltAlle)
        {
            foreach (var position in entityList)
            {
                UpdateIsAuszahlungDritte(position, personenHaushaltAlle);
            }
        }

        /// <summary>
        /// Flag <see cref="WshGrundbudgetPositionDTO.IsAuszahlungDritte"/> auf grund PersonID updaten.
        /// </summary>
        /// <param name="positionDto">DTO zu updaten</param>
        /// <param name="personId">PersonID zu überprüfen</param>
        /// <param name="personenHaushaltAlle">personen die im Haushalt sind</param>
        public void UpdateIsAuszahlungDritte(WshGrundbudgetPositionDTO positionDto, int? personId, ObservableCollection<BaPerson> personenHaushaltAlle)
        {
            if (positionDto.WshGrundbudgetPosition.KbuAuszahlungArtCode == (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung)
            {
                positionDto.IsAuszahlungDritte = true;

                if (personId.HasValue && personenHaushaltAlle.Any(person => person.BaPersonID == personId))
                {
                    positionDto.IsAuszahlungDritte = false;
                }
            }
        }

        /// <summary>
        /// Flag <see cref="WshGrundbudgetPositionDTO.IsAuszahlungDritte"/> auf grund Kreditor Informationen updaten.
        /// </summary>
        /// <param name="positionDto">DTO zu updaten</param>
        /// <param name="personenHaushaltAlle">personen die im Haushalt sind</param>
        public void UpdateIsAuszahlungDritte(WshGrundbudgetPositionDTO positionDto, ObservableCollection<BaPerson> personenHaushaltAlle)
        {
            var zahlungsweg = positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Select(k => k.BaZahlungsweg).FirstOrDefault();
            int? personId = null;

            if (zahlungsweg != null)
            {
                personId = zahlungsweg.BaPersonID;
            }

            UpdateIsAuszahlungDritte(positionDto, personId, personenHaushaltAlle);
        }

        public void UpdateKreditorMitteilungszeile1(WshGrundbudgetPosition position)
        {
            if (position.WshGrundbudgetPositionKreditor.Count > 0 &&
                position.KbuAuszahlungArtCode == (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung)
            {
                position.WshGrundbudgetPositionKreditor[0].MitteilungZeile1 =
                    (Container.Resolve<FaFallService>()).GetFallIdNameVornameByFaLeistungId(null, position.FaLeistungID);
            }
        }

        public KissServiceResult ValidateInMemory(WshGrundbudgetPositionDTO dataToValidate)
        {
            // validation: check if the entity is consistent in itself
            var validator = new WshGrundbudgetPositionDTOValidator();
            return new KissServiceResult(validator.Validate(dataToValidate));
        }

        #endregion

        #region Private Methods

        private void SetDtoProperties(IUnitOfWork unitOfWork, WshGrundbudgetPositionDTO positionDTO)
        {
            positionDTO.SelectedZahlungsweg = GetZahlungswegDTO(unitOfWork, positionDTO.WshGrundbudgetPosition.WshGrundbudgetPositionID);
            positionDTO.SelectedDebitor = GetDebitorDTO(unitOfWork, positionDTO.WshGrundbudgetPosition.WshGrundbudgetPositionID);
            SetBetragMonatlich(positionDTO);
        }

        private void SetDtoProperties(IUnitOfWork unitOfWork, List<WshGrundbudgetPositionDTO> positionDtos)
        {
            positionDtos.ForEach(dto => SetDtoProperties(unitOfWork, dto));
        }

        #endregion

        #endregion
    }
}