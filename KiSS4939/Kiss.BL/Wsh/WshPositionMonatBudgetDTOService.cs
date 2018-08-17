using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.Ba;
using Kiss.BL.Kbu;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Interfaces.ViewModel;
using Kiss.Model;
using Kiss.Model.DTO.BA;
using Kiss.Model.DTO.Kbu;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage a TEntity.
    /// </summary>
    public class WshPositionMonatBudgetDTOService : ServiceBase, IServiceCRUD<WshPositionMonatBudgetDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshPositionService _wshPositionService;

        #endregion

        #endregion

        #region Constructors

        private WshPositionMonatBudgetDTOService()
        {
            _wshPositionService = Container.Resolve<WshPositionService>();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static bool GetPeriodizitaet(int? wshPeriodizitaetCode, out LOVsGenerated.WshPeriodizitaet wshPeriodizitaet)
        {
            const LOVsGenerated.WshPeriodizitaet defaultValue = LOVsGenerated.WshPeriodizitaet.Valuta;

            // code is null
            if (!wshPeriodizitaetCode.HasValue)
            {
                wshPeriodizitaet = defaultValue;
                return false;
            }

            // code is not defined in the enum
            if (!Enum.IsDefined(typeof(LOVsGenerated.WshPeriodizitaet), wshPeriodizitaetCode))
            {
                wshPeriodizitaet = defaultValue;
                return false;
            }

            // cast code to enum
            wshPeriodizitaet = (LOVsGenerated.WshPeriodizitaet)wshPeriodizitaetCode;
            return true;
        }

        #endregion

        #region Public Methods

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshPositionMonatBudgetDTO dataToDelete, bool saveChanges = true)
        {
            return _wshPositionService.DeleteData(unitOfWork, dataToDelete.WshPosition, saveChanges);
        }

        public List<WshBudgetmonatDTO> GetBudgetmonate(IUnitOfWork unitOfWork, int faLeistungID, MonthYear from, int numerOfMonths)
        {
            return _wshPositionService.GetBudgetmonate(unitOfWork, faLeistungID, from, numerOfMonths);
        }

        public IList<WshPositionMonatBudgetDTO> GetByFaLeistungID(IUnitOfWork unitOfWork, int faLeistungId, int year, int month)
        {
            var positionDtos = _wshPositionService
                .GetByFaLeistungID(unitOfWork, faLeistungId, year, month)
                .Select(p => new WshPositionMonatBudgetDTO { WshPosition = p })
                .ToList();

            SetDtoProperties(unitOfWork, positionDtos);

            return positionDtos;
        }

        public ObservableCollection<WshPositionMonatBudgetDTO> GetData(IUnitOfWork unitOfWork)
        {
            var positionDtos = _wshPositionService
                    .GetData(unitOfWork)
                    .Select(p => new WshPositionMonatBudgetDTO { WshPosition = p })
                    .ToList();

            SetDtoProperties(unitOfWork, positionDtos);

            return new ObservableCollection<WshPositionMonatBudgetDTO>(positionDtos);
        }

        public BaDebitorDTO GetDebitorDTO(IUnitOfWork unitOfWork, int wshPositionID)
        {
            return _wshPositionService.GetDebitorDTO(unitOfWork, wshPositionID);
        }

        public LOVsGenerated.SysEditMode GetSysEditModePersonBetrifft(int kbuKontoId, DateTime? datumVon, DateTime? datumBis)
        {
            var kontoService = Container.Resolve<WshKbuKontoService>();
            return kontoService.GetSysEditModeBetrifftPerson(null, kbuKontoId, datumVon, datumBis);
        }

        public BaZahlungswegDTO GetZahlungswegDTO(IUnitOfWork unitOfWork, int positionID)
        {
            return _wshPositionService.GetZahlungswegDTO(unitOfWork, positionID);
        }

        public bool IsSelectedEntityTreeModified(WshPositionMonatBudgetDTO selectedEntity)
        {
            if (selectedEntity.ChangeTracker.State != ObjectState.Unchanged)
            {
                return true;
            }

            if (selectedEntity.WshPosition.WshPositionKreditor.Count == 1)
            {
                if (selectedEntity.WshPosition.WshPositionKreditor.Single().ChangeTracker.State != ObjectState.Unchanged)
                {
                    return true;
                }
            }

            if (selectedEntity.WshPosition.WshPositionDebitor.Count == 1)
            {
                if (selectedEntity.WshPosition.WshPositionDebitor.Single().ChangeTracker.State != ObjectState.Unchanged)
                {
                    return true;
                }
            }

            return false;
        }

        public bool NeedToSaveData(WshPositionMonatBudgetDTO positionDTO)
        {
            if (positionDTO == null)
            {
                return false;
            }

            var kreditor = positionDTO.WshPosition.WshPositionKreditor.FirstOrDefault();
            var debitor = positionDTO.WshPosition.WshPositionDebitor.FirstOrDefault();

            // Check kreditor and debitor if position is unchanged
            if (positionDTO.WshPosition.ChangeTracker.State == ObjectState.Unchanged)
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

        public KissServiceResult NewData(out WshPositionMonatBudgetDTO newData)
        {
            newData = new WshPositionMonatBudgetDTO();
            WshPosition wshPosition;

            var serviceResult = _wshPositionService.NewData(out wshPosition);
            newData.WshPosition = wshPosition;

            return serviceResult;
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, List<WshPositionMonatBudgetDTO> dataToSave)
        {
            throw new NotSupportedException();
        }

        public KissServiceResult SaveData(
            IUnitOfWork unitOfWork,
            WshPositionMonatBudgetDTO dataToSave,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            throw new NotSupportedException();
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, WshPositionMonatBudgetDTO positionDto)
        {
            // return if there is no need to save
            if (!NeedToSaveData(positionDto))
            {
                return KissServiceResult.Ok();
            }

            //TODO ValidateInMemory
            KissServiceResult result = ValidateOnDatabase(unitOfWork, positionDto);
            if(!result.IsOk)
            {
                return result;
            }

            return _wshPositionService.SaveData(unitOfWork, positionDto.WshPosition);
        }

        private KissServiceResult ValidateOnDatabase(IUnitOfWork unitOfWork, WshPositionMonatBudgetDTO dataToValidate)
        {
            if(dataToValidate.WshPosition.ChangeTracker.State == ObjectState.Added)
            {
                KbuKontoValidationDTO validationDTO = new KbuKontoValidationDTO
                {
                    DatumVon = dataToValidate.WshPosition.MonatVon,
                    DatumBis = dataToValidate.WshPosition.MonatBis,
                    LeistungWsh = true,
                    Monatsbudget = true,
                    KbuKontoID = dataToValidate.WshPosition.KbuKontoID,
                    WshKategorieID = dataToValidate.WshPosition.WshKategorieID,
                    PersonAusgewaehlt = dataToValidate.WshPosition.BaPersonID.HasValue && dataToValidate.WshPosition.BaPersonID.Value > 0,
                };
                var kontoService = Container.Resolve<WshKbuKontoService>();
                var serviceResult = kontoService.IsValidKbuKontoWshKategorieKombination(unitOfWork, validationDTO);
                if (serviceResult.IsError)
                {
                    return serviceResult;
                }

            }
            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Berechnet den monatlichen Betrag der Position.
        /// </summary>
        /// <param name="positionDTO"></param>
        public void SetBetragMonatlich(WshPositionMonatBudgetDTO positionDTO)
        {
            var periodizitaet = (LOVsGenerated.WshPeriodizitaet?)positionDTO.WshPosition.WshPeriodizitaetCode;
            var kbuRundungsService = Container.Resolve<KbuGeldbetragRundungsService>();

            //Quartal oder Semester
            if (periodizitaet.HasValue && periodizitaet == LOVsGenerated.WshPeriodizitaet.Quartal ||
                periodizitaet.HasValue && periodizitaet == LOVsGenerated.WshPeriodizitaet.Semester)
            {
                if (!positionDTO.WshPosition.BetragTotal.HasValue)
                {
                    positionDTO.WshPosition.BetragTotal = positionDTO.WshPosition.Betrag;//todo exception werfen
                    //throw new Exception("BetragTotal muss einen Wert enthalten, wenn Periodizität Quartal ist");
                }
                positionDTO.HasTotalBetrag = true;

                double numMonth = MonthYear.GetSpanningMonthCount(
                    new MonthYear(positionDTO.WshPosition.MonatVon),
                    new MonthYear(positionDTO.WshPosition.MonatBis));

                positionDTO.BetragMonatlich = kbuRundungsService.GeldbetragRunden((double)positionDTO.WshPosition.BetragTotal / numMonth);
            }

            else
            {
                positionDTO.BetragMonatlich = positionDTO.WshPosition.Betrag;
            }
        }

        /// <summary>
        /// Überträgt den ausgewählten Debitor in WshPositionDebitor.
        /// </summary>
        public void SetDebitor(WshPositionMonatBudgetDTO positionDTO, BaDebitorDTO selectedDebitor)
        {
            // Es existiert noch kein Debitor, wir erzeugen einen neuen.
            if (selectedDebitor != null && positionDTO.WshPosition.WshPositionDebitor.Count == 0)
            {
                var debitorService = Container.Resolve<WshPositionDebitorService>();
                WshPositionDebitor debitor;
                debitorService.NewData(out debitor);
                positionDTO.WshPosition.WshPositionDebitor.Add(debitor);
            }

            // Übertragen der Daten
            if (selectedDebitor != null)
            {
                var debitor = positionDTO.WshPosition.WshPositionDebitor.First();

                if (selectedDebitor.Type == DebitorType.Person)
                {
                    debitor.BaInstitutionID = null;
                    debitor.BaPersonID = selectedDebitor.BaPersonId;
                }
                else if (selectedDebitor.Type == DebitorType.Institution)
                {
                    debitor.BaInstitutionID = selectedDebitor.BaInstitutionId;
                    debitor.BaPersonID = null;
                }
            }
            else if (positionDTO.WshPosition.WshPositionDebitor.Count > 0)
            {
                var debitor = positionDTO.WshPosition.WshPositionDebitor.First();
                debitor.BaPersonID = debitor.BaInstitutionID = null;
            }
        }

        public KissServiceResult SetKreditor(WshPositionMonatBudgetDTO positionDto)
        {
            var grundbudgetPositionKreditorService = Container.Resolve<WshPositionKreditorService>();
            WshPositionKreditor kreditor;
            var result = grundbudgetPositionKreditorService.NewData(out kreditor);

            if (!result.IsOk)
            {
                return result;
            }

            positionDto.WshPosition.WshPositionKreditor.Add(kreditor);

            return result;
        }

        /// <summary>
        /// Überträgt die Daten vom DTO in WshPositonKreditor
        /// </summary>
        public void SetZahlungsweg(WshPositionMonatBudgetDTO positionDTO,
            BaZahlungswegDTO selectedZahlungsweg,
            ObservableCollection<BaPerson> personenHaushaltAlle)
        {
            // TODO delete param selectedZahlungsweg

            //Es existiert noch kein Kreditor, wir erzeugen einen neuen.
            if (positionDTO.WshPosition.WshPositionKreditor.Count == 0 && selectedZahlungsweg != null)
            {
                var positionKreditorService = Container.Resolve<WshPositionKreditorService>();
                WshPositionKreditor kreditor;
                positionKreditorService.NewData(out kreditor);
                positionDTO.WshPosition.WshPositionKreditor.Add(kreditor);
            }

            //Übertragen der Daten vom DTO in WshPositionKreditor.
            if (selectedZahlungsweg != null)
            {
                WshPositionKreditor kred = positionDTO.WshPosition.WshPositionKreditor.First();
                kred.BaZahlungswegID = selectedZahlungsweg.BaZahlungswegID;
            }
            else if (positionDTO.WshPosition.WshPositionKreditor.Count == 1)
            {
                WshPositionKreditor kred = positionDTO.WshPosition.WshPositionKreditor.First();
                kred.BaZahlungsweg = null;
            }

            if (selectedZahlungsweg != null)
            {
                UpdateIsAuszahlungDritte(positionDTO, selectedZahlungsweg.BaPersonId, personenHaushaltAlle);
            }
            else
            {
                UpdateIsAuszahlungDritte(positionDTO, null, personenHaushaltAlle);
            }
        }

        public void SetZahlungswegStandard(WshPositionMonatBudgetDTO positionDto)
        {
            var standardZahlungsweg = Container.Resolve<BaZahlungswegSearchService>().GetStandardZahlungsweg(
                null, positionDto.WshPosition.FaLeistungID, Constant.MODULEID_W);
            if (standardZahlungsweg != null)
            {
                positionDto.SelectedZahlungsweg = standardZahlungsweg;
                positionDto.WshPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            }
            else
            {
                positionDto.WshPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.CashBarauszahlung;
            }

            positionDto.WshPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat;
        }

        // Setzen des Properties Auszahlung Dritte auf einer gegebenen Position.
        // Dies damit im Grid in der Spalte S/D die Werte angezeigt werden.
        public void UpdateIsAuszahlungDritte(WshPositionMonatBudgetDTO position, int? personId, ObservableCollection<BaPerson> personenHaushaltAlle)
        {
            if (position.WshPosition.KbuAuszahlungArtCode == (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung)
            {
                position.IsAuszahlungDritte = true;

                if (personId.HasValue && personenHaushaltAlle.Any(person => person.BaPersonID == personId))
                {
                    position.IsAuszahlungDritte = false;
                }
            }
        }

        public void UpdateIsAuszahlungDritte(WshPositionMonatBudgetDTO position, ObservableCollection<BaPerson> personenHaushaltAlle)
        {
            var zahlungsweg = position.WshPosition.WshPositionKreditor.Select(k => k.BaZahlungsweg).FirstOrDefault();
            int? personId = null;

            if (zahlungsweg != null)
            {
                personId = zahlungsweg.BaPersonID;
            }

            UpdateIsAuszahlungDritte(position, personId, personenHaushaltAlle);
        }

        public void UpdateIsAuszahlungDritte(ObservableCollection<WshPositionMonatBudgetDTO> entityList,
            ObservableCollection<BaPerson> personenHaushaltAlle)
        {
            foreach (var position in entityList)
            {
                UpdateIsAuszahlungDritte(position, personenHaushaltAlle);
            }
        }

        public void UpdatePeriodizitaet(IUnitOfWork unitOfWork, WshPositionMonatBudgetDTO positionDTO)
        {
            positionDTO.AuszahlTermine = GetAuszahlTermine(null, positionDTO);
            if (positionDTO.WshPosition.WshPeriodizitaetCode == (int)LOVsGenerated.WshPeriodizitaet.Semester
                || positionDTO.WshPosition.WshPeriodizitaetCode == (int)LOVsGenerated.WshPeriodizitaet.Quartal)
            {
                positionDTO.HasTotalBetrag = true;
            }
            else
            {
                positionDTO.HasTotalBetrag = false;
            }
        }

        #endregion

        #region Private Static Methods

        private static string GetAuszahlTermine(IUnitOfWork unitOfWork, WshPositionMonatBudgetDTO positionDTO)
        {
            // Get Enum form WshPeriodizitaet if it's possible
            LOVsGenerated.WshPeriodizitaet wshPeriodizitaet;
            var hasPeriodizitaet = GetPeriodizitaet(positionDTO.WshPosition.WshPeriodizitaetCode, out wshPeriodizitaet);

            // WshPeriodizitaetCode is null or not valide
            if (!hasPeriodizitaet)
            {
                return string.Empty;
            }

            // WshPeriodizitaet = Valuta
            if (wshPeriodizitaet == LOVsGenerated.WshPeriodizitaet.Valuta)
            {
                if (positionDTO.WshPosition.FaelligAm.HasValue)
                {
                    return positionDTO.WshPosition.FaelligAm.Value.ToString("d.M");
                }

                return string.Empty;
            }

            var zahlungslaufValutaService = Container.Resolve<KbuZahlungslaufValutaService>();
            var datum = zahlungslaufValutaService.GetValutaDatum(
                unitOfWork, wshPeriodizitaet, positionDTO.WshPosition.MonatVon.Year, positionDTO.WshPosition.MonatVon.Month);

            return string.Join(", ", datum.Select(d => d.ToString("d.M")));
        }

        #endregion

        #region Private Methods

        private void SetDtoProperties(IUnitOfWork unitOfWork, WshPositionMonatBudgetDTO positionDTO)
        {
            positionDTO.SelectedZahlungsweg = GetZahlungswegDTO(unitOfWork, positionDTO.WshPosition.WshPositionID);
            positionDTO.SelectedDebitor = GetDebitorDTO(unitOfWork, positionDTO.WshPosition.WshPositionID);
            positionDTO.AuszahlTermine = GetAuszahlTermine(unitOfWork, positionDTO);

            //Betrag Monatlich berechnen.
            //Bei Semester und Quartal wird der Totalbetrag durch 3 respektive durch 6 geteilt.
            SetBetragMonatlich(positionDTO);
        }

        private void SetDtoProperties(IUnitOfWork unitOfWork, List<WshPositionMonatBudgetDTO> positionDtos)
        {
            positionDtos.ForEach(dto => SetDtoProperties(unitOfWork, dto));
        }

        #endregion

        #endregion

        #region Other

        //TODO ValidateInMemory
        ////public override KissServiceResult ValidateInMemory(WshPositionMonatBudgetDTO dataToValidate)
        ////{
        ////    // validation: check if the entity is consistent in itself
        ////    var validator = new TValidator();
        ////    var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));
        ////    return serviceResult + base.ValidateInMemory(dataToValidate);
        ////}

        #endregion
    }
}