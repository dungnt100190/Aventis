using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;

using Kiss.BL.Kbu;
using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage a WshAbzug.
    /// </summary>
    public class WshAbzugDTOService : ServiceBase, IServiceCRUD<WshAbzugDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshAbzugDetailDTOService _abzugDetailDTOService = Container.Resolve<WshAbzugDetailDTOService>();
        private readonly WshAbzugDetailService _abzugDetailService = Container.Resolve<WshAbzugDetailService>();
        private readonly WshAbzugService _abzugService = Container.Resolve<WshAbzugService>();
        private readonly WshGrundbudgetPositionService _grundbudgetPositionService = Container.Resolve<WshGrundbudgetPositionService>();

        // to avoid endless loop SetBetragMonatlich - SetGblProzent
        private readonly List<WshAbzugDTO> _isCalculatingGblBetrag = new List<WshAbzugDTO>();
        private readonly KbuGeldbetragRundungsService _rundungsService = Container.Resolve<KbuGeldbetragRundungsService>();

        #endregion

        #endregion

        #region Constructors

        private WshAbzugDTOService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool AreAllDependingPositionsGray(IUnitOfWork unitOfWork,
            int wshGrundbudgetPositionID,
            out DateTime? firstNonGrayPosition,
            out DateTime? lastNonGrayPosition)
        {
            return _grundbudgetPositionService.AreAllDependingPositionsGray(
                unitOfWork, wshGrundbudgetPositionID, out firstNonGrayPosition, out lastNonGrayPosition, true);
        }

        public KissServiceResult CanUpdateDatumVon(WshAbzugDTO abzugDto)
        {
            var position = abzugDto.WshAbzug.WshGrundbudgetPosition;
            var datumVonPropertyName = PropertyName.GetPropertyName(() => position.DatumVon);
            var hasKey = position.OriginalValues.Any(v => v.Key == datumVonPropertyName);

            DateTime? originalDatum;
            DateTime currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            if (hasKey)
            {
                originalDatum = position.OriginalValues[datumVonPropertyName] as DateTime?;
            }
            else
            {
                originalDatum = currentMonth;
            }

            if (originalDatum.HasValue && originalDatum < currentMonth && position.DatumVon < originalDatum)
            {
                return new KissServiceResult(
                    KissServiceResult.ResultType.Error,
                    "WshAbzugDTOService_vergangenerDatumVonNichtErlaubt",
                    "Im Feld 'Gültig von' kann kein vergangener Monat eingegeben werden.");
            }

            return KissServiceResult.Ok();
        }

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshAbzugDTO dataToDelete, bool saveChanges = true)
        {
            var result = ValidateBeforeDelete(unitOfWork, dataToDelete);

            if (!result)
            {
                return result;
            }

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            using (var ts = new TransactionScope())
            {
                while (dataToDelete.WshAbzug.WshAbzugDetail.Any())
                {
                    var detail = dataToDelete.WshAbzug.WshAbzugDetail.First();
                    result += _abzugDetailDTOService.DeleteData(unitOfWork, detail, false);
                }

                if (!result)
                {
                    return result;
                }

                // Abzug
                var position = dataToDelete.WshAbzug.WshGrundbudgetPosition;
                result = _abzugService.DeleteData(unitOfWork, dataToDelete.WshAbzug, saveChanges);

                if (!result)
                {
                    return result;
                }

                // Positionen
                result += _grundbudgetPositionService.DeleteData(null, position, saveChanges);

                if (result)
                {
                    ts.Complete();
                }
            }

            return result;
        }

        /// <summary>
        /// Hohlt alle DTOs anhand der FallId.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faFallId"></param>
        /// <param name="inklAbgeschlossene"></param>
        /// <returns></returns>
        public ObservableCollection<WshAbzugDTO> GetByFaFallId(IUnitOfWork unitOfWork, int faFallId, bool inklAbgeschlossene = true)
        {
            return GetByFaFallIdOrFaLeistungId(unitOfWork, true, faFallId, inklAbgeschlossene);
        }

        public ObservableCollection<WshAbzugDTO> GetByFaLeistungId(IUnitOfWork unitOfWork, int faLeistungId, bool inklAbgeschlossene = true)
        {
            return GetByFaFallIdOrFaLeistungId(unitOfWork, false, faLeistungId, inklAbgeschlossene);
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public ObservableCollection<WshAbzugDTO> GetData(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        public LOVsGenerated.SysEditMode GetSysEditModePersonBetrifft(int kbuKontoId, DateTime? datumVon, DateTime? datumBis)
        {
            return _grundbudgetPositionService.GetSysEditModePersonBetrifft(kbuKontoId, datumVon, datumBis);
        }

        public bool NeedToSaveData(WshAbzugDTO dataToSave)
        {
            return dataToSave != null && (dataToSave.WshAbzug.ChangeTracker.State != ObjectState.Unchanged ||
                                          dataToSave.WshAbzug.WshGrundbudgetPosition.ChangeTracker.State != ObjectState.Unchanged);
        }

        public KissServiceResult NewData(out WshAbzugDTO newData)
        {
            newData = null;
            WshGrundbudgetPosition position;
            WshAbzug abzug;

            var result = _grundbudgetPositionService.NewData(out position);

            if (!result)
            {
                return result;
            }

            // aktueller Monat, da sonst nicht mehr zurückverschoben werden kann
            position.DatumVon = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            result += _abzugService.NewData(out abzug);

            abzug.WshGrundbudgetPosition = position;
            newData = new WshAbzugDTO(abzug)
            {
                HatNurGrauePositionen = true
            };

            return result;
        }

        /// <summary>
        /// Creates a copy of <paramref name="originalAbzugDto"/> into <paramref name="newData"/>
        /// </summary>
        /// <param name="originalAbzugDto">the original <see cref="WshAbzugDTO"/> to copy</param>
        /// <param name="newData">the new <see cref="WshAbzugDTO"/></param>
        /// <returns><see cref="KissServiceResult"/></returns>
        public KissServiceResult NewData(WshAbzugDTO originalAbzugDto, out WshAbzugDTO newData)
        {
            if (originalAbzugDto == null)
            {
                newData = null;
                return new KissServiceResult(
                    KissServiceResult.ResultType.Error, "WshAbzugDTOService_CopyData", "Keine Position zum Kopieren ausgewählt.");
            }

            var result = NewData(out newData);

            //copy other attributes:

            //DTO
            newData.GblAktuell = originalAbzugDto.GblAktuell;
            newData.GblAbzugProzent = originalAbzugDto.GblAbzugProzent;
            newData.Saldo = originalAbzugDto.Saldo;
            newData.VoraussichtlicheDauer = originalAbzugDto.VoraussichtlicheDauer;
            newData.HatNurGrauePositionen = true;

            //Abzug
            newData.WshAbzug.MonatlichWiederholend = originalAbzugDto.WshAbzug.MonatlichWiederholend;
            foreach (var wshAbzugDetail in originalAbzugDto.WshAbzug.WshAbzugDetail)
            {
                WshAbzugDetail newAbzugDetail;
                _abzugDetailDTOService.NewData(wshAbzugDetail, out newAbzugDetail);
                newData.WshAbzugDetailDto.Add(new WshAbzugDetailDTO(newAbzugDetail));
            }

            //WshGrundbudgetPosition
            newData.WshAbzug.WshGrundbudgetPosition.WshKategorie = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.WshKategorie;
            newData.WshAbzug.WshGrundbudgetPosition.WshKategorieID = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.WshKategorieID;

            newData.WshAbzug.WshGrundbudgetPosition.FaLeistung = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.FaLeistung;
            newData.WshAbzug.WshGrundbudgetPosition.FaLeistungID = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.FaLeistungID;

            newData.WshAbzug.WshGrundbudgetPosition.DatumEntscheid = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.DatumEntscheid;

            newData.WshAbzug.WshGrundbudgetPosition.Text = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.Text;

            newData.WshAbzug.WshGrundbudgetPosition.KbuKonto = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.KbuKonto;
            newData.WshAbzug.WshGrundbudgetPosition.KbuKontoID = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.KbuKontoID;

            newData.WshAbzug.WshGrundbudgetPosition.BaPerson = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.BaPerson;
            newData.WshAbzug.WshGrundbudgetPosition.BaPersonID = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.BaPersonID;

            newData.WshAbzug.WshGrundbudgetPosition.BetragMonatlich = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.BetragMonatlich;
            newData.WshAbzug.WshGrundbudgetPosition.BetragTotal = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.BetragTotal;

            newData.WshAbzug.WshGrundbudgetPosition.DatumVon = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.DatumVon;
            newData.WshAbzug.WshGrundbudgetPosition.DatumBis = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.DatumBis;

            newData.WshAbzug.WshGrundbudgetPosition.Bemerkung = originalAbzugDto.WshAbzug.WshGrundbudgetPosition.Bemerkung;

            return result;
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, WshAbzugDTO dataToSave)
        {
            throw new NotSupportedException();
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, WshAbzugDTO dataToSave, Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            if (!NeedToSaveData(dataToSave))
            {
                return KissServiceResult.Ok();
            }

            // Validate
            var result = ValidateInMemory(dataToSave);

            if (!result)
            {
                return result;
            }

            using (var ts = new TransactionScope())
            {
                // Wenn Abschluss, graue MB-Positionen mit Betrag > 0 löschen
                if (dataToSave.WshAbzug.IstAbgeschlossen)
                {
                    result += DeleteWshPositions(null, dataToSave);

                    if (!result)
                    {
                        return result;
                    }
                }

                // GB-Position speichern
                var inMonatsbudgetUebertragen = !dataToSave.WshAbzug.IstAbgeschlossen
                                                    && dataToSave.WshAbzug.WshGrundbudgetPosition.BetragMonatlich > 0; //falls BetragMonatlich 0.00 wäre, würden lauter 0.00-Betrag MonatsbudgetPositionen erstellt, die dann später bei einem Betrag > 0.00 nicht automatisch aktualisiert würden
                result = _grundbudgetPositionService.SaveData(
                    null, dataToSave.WshAbzug.WshGrundbudgetPosition, questionsAndAnswers, false, inMonatsbudgetUebertragen);

                if (!result)
                {
                    return result;
                }

                // Abzug speichern
                result = _abzugService.SaveData(null, dataToSave.WshAbzug, false);

                if (!result)
                {
                    return result;
                }

                // Details speichern
                result += SaveDetails(null, dataToSave);

                if (result)
                {
                    ts.Complete();
                }
            }

            if (result)
            {
                dataToSave.AcceptChanges();
            }

            return result;
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, List<WshAbzugDTO> dataToSave)
        {
            var result = KissServiceResult.Ok();
            dataToSave.ForEach(x => result += SaveData(unitOfWork, x));
            return result;
        }

        public void SetBetragMonatlich(IUnitOfWork unitOfWork, WshAbzugDTO abzugDto)
        {
            if (_isCalculatingGblBetrag.Contains(abzugDto))
            {
                return;
            }

            try
            {
                _isCalculatingGblBetrag.Add(abzugDto);

                var istRueckerstattung = abzugDto.WshAbzug.WshGrundbudgetPosition.IstRueckerstattung;

                //Berechnung anhand der AbzugDetails oder anhand GblAbzugProzent?
                //abzug ist eine Rückerstattung -> AbzugDetails berücksichtigen
                if (istRueckerstattung)
                {
                    decimal summeDetails = 0;
                    abzugDto.WshAbzugDetailDto.ToList().ForEach(d => summeDetails += d.WshAbzugDetail.Betrag);
                    abzugDto.WshAbzug.WshGrundbudgetPosition.BetragMonatlich = summeDetails;
                }
                else
                {
                    if (abzugDto.GblAktuell != null && abzugDto.GblAbzugProzent != null)
                    {
                        abzugDto.WshAbzug.WshGrundbudgetPosition.BetragMonatlich =
                            _rundungsService.GeldbetragRunden(abzugDto.GblAktuell.Value * abzugDto.GblAbzugProzent.Value / 100);
                    }
                }
            }
            finally
            {
                _isCalculatingGblBetrag.Remove(abzugDto);
            }
        }

        public void SetDtoProperties(IUnitOfWork unitOfWork, WshAbzugDTO abzugDto)
        {
            _abzugDetailDTOService.SetDtoProperties(unitOfWork, abzugDto.WshAbzugDetailDto);

            SetVoraussichtlicheDauerUndSaldo(unitOfWork, abzugDto);
            SetGblProzent(unitOfWork, abzugDto);
            SetHatNurGrauePositionen(unitOfWork, abzugDto);

            //BetragMonatlich muss nur bei Rückerstattungen aus den AbzugDetails berechnet werden
            if (abzugDto.WshAbzug.WshGrundbudgetPosition.IstRueckerstattung)
            {
                SetBetragMonatlich(unitOfWork, abzugDto);
            }
        }

        public void SetGblProzent(IUnitOfWork unitOfWork, WshAbzugDTO abzugDto)
        {
            if (_isCalculatingGblBetrag.Contains(abzugDto))
            {
                return;
            }

            try
            {
                _isCalculatingGblBetrag.Add(abzugDto);

                var istRueckerstattung = abzugDto.WshAbzug.WshGrundbudgetPosition.IstRueckerstattung;

                //Berechnung anhand der AbzugDetails oder anhand GblAbzugProzent?
                //abzug ist eine Rückerstattung -> AbzugDetails berücksichtigen
                if (istRueckerstattung)
                {
                    decimal summeDetails = 0;
                    abzugDto.WshAbzugDetailDto.ToList().ForEach(d => summeDetails += d.GblAbzugProzent ?? 0);
                    if (summeDetails > 0)
                    {
                        abzugDto.GblAbzugProzent = summeDetails;
                    }
                    else
                    {
                        abzugDto.GblAbzugProzent = null;
                    }
                }
                else if (abzugDto.GblAktuell != null) // GBL aktuell wurde bereits berechnet, nur GBL Abzug % berechnen
                {
                    abzugDto.GblAbzugProzent = GetGblAbzugProzent(abzugDto.GblAktuell.Value, abzugDto.WshAbzug.WshGrundbudgetPosition.BetragMonatlich);
                }
                else // GBL aktuell und GBL Abzug % berechnen
                {
                    unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

                    var kbuKontoService = Container.Resolve<KbuKontoService>();
                    var gblKontoIds = kbuKontoService.GetAllGblKontoIds(unitOfWork);

                    // Detail-Position holen
                    var details = _abzugDetailDTOService.GetByWshAbzugId(unitOfWork, abzugDto.WshAbzug.WshAbzugID);
                    var detail = details.FirstOrDefault(x => gblKontoIds.Contains(x.WshAbzugDetail.KbuKontoID));

                    if (detail != null)
                    {
                        abzugDto.GblAbzugProzent = detail.GblAbzugProzent;
                    }
                    else if (gblKontoIds.Contains(abzugDto.WshAbzug.WshGrundbudgetPosition.KbuKontoID))
                    {
                        // Kein Detail vorhanden, aktive GBL-Position-Konto prüfen
                        var gblPosition =
                            _grundbudgetPositionService.GetByFaLeistungIDQueryable(
                                unitOfWork, abzugDto.WshAbzug.WshGrundbudgetPosition.FaLeistungID, DateTime.Today, false, false)
                                .Where(x => gblKontoIds.Contains(x.KbuKontoID))
                                .OrderBy(x => !x.Berechnet) //berechnete Positionen zuerst, dann nach Datum
                                .ThenByDescending(x => x.DatumVon) //dann nach Datum (aktuellste zuerst)
                                .FirstOrDefault(); //es kann sein, dass es mehrere GBL-Positionen hat

                        if (gblPosition != null)
                        {
                            var totalBetrag = gblPosition.BetragMonatlich;
                            var monatBetrag = abzugDto.WshAbzug.WshGrundbudgetPosition.BetragMonatlich;

                            // Set DTO properties
                            abzugDto.GblAktuell = totalBetrag;
                            abzugDto.GblAbzugProzent = GetGblAbzugProzent(totalBetrag, monatBetrag);
                        }
                        else
                        {
                            abzugDto.GblAktuell = null;
                            abzugDto.GblAbzugProzent = null;
                        }
                    }
                }
            }
            finally
            {
                _isCalculatingGblBetrag.Remove(abzugDto);
            }
        }

        public void SetHatNurGrauePositionen(IUnitOfWork unitOfWork, WshAbzugDTO dto)
        {
            if (dto == null)
            {
                return;
            }

            DateTime? first;
            DateTime? last;
            dto.HatNurGrauePositionen = AreAllDependingPositionsGray(
                unitOfWork, dto.WshAbzug.WshGrundbudgetPositionID, out first, out last);
        }

        /// <summary>
        /// Setzt die voraussichtliche Dauer.
        /// </summary>
        /// <param name="dto"></param>
        public void SetVoraussichtlicheDauer(WshAbzugDTO dto)
        {
            var position = dto.WshAbzug.WshGrundbudgetPosition;
            var monatlich = position.BetragMonatlich;
            var total = position.BetragTotal;

            if (total != null)
            {
                if (monatlich > 0)
                {
                    int anzahlMonateAktiv = 0;
                    int anzahlMonateInaktiv = 0;

                    if (dto.WshPosition != null)
                    {
                        // Betrag alle Positionen vom total abziehen
                        decimal betragPosition = dto.WshPosition.Where(p => p.WshPosition != null).Sum(p => p.WshPosition.Betrag);
                        total = total - betragPosition;

                        // Anzahl aktive Monate
                        anzahlMonateAktiv = dto.WshPosition.Where(p => p.WshPosition != null && p.WshPosition.Betrag != 0).Count();

                        // Anzahl inaktive Monate
                        anzahlMonateInaktiv = dto.WshPosition.Where(p => p.WshPosition != null && p.WshPosition.Betrag == 0).Count();
                    }

                    // Anzahl Monate anhand BetragMonatlich definieren
                    var anzahlMonateDecimal = total.Value / monatlich;
                    int anzahlMonate = (int)Math.Truncate(anzahlMonateDecimal);
                    if (anzahlMonate != anzahlMonateDecimal)
                    {
                        anzahlMonate++;
                    }

                    anzahlMonate = anzahlMonate + anzahlMonateAktiv + anzahlMonateInaktiv;

                    // Voraussichtliche Dauer setzen
                    dto.VoraussichtlicheDauer = dto.WshAbzug.WshGrundbudgetPosition.DatumVon.AddMonths(anzahlMonate - 1);


                    //////AnzahlMonate = BetragTotal / BetragMonatlich und dann aufrunden.
                    ////decimal anzahlMonateDec = total.Value/monatlich;
                    ////int anzahlMonate = (int)Math.Truncate(anzahlMonateDec);
                    ////if (anzahlMonateDec != Math.Truncate(anzahlMonateDec))
                    ////{
                    ////    anzahlMonate++;
                    ////}

                    //////Anzahl deaktivierte Monate hinzufügen.
                    ////if (dto.WshPosition != null)
                    ////{
                    ////    int anzahlDeakivierteMonate = dto.WshPosition.Where(x => x.WshPosition != null && x.WshPosition.Betrag == 0).Count();
                    ////    anzahlMonate += anzahlDeakivierteMonate;
                    ////}

                    ////// Voraussichtliche Dauer setzen
                    ////dto.VoraussichtlicheDauer = dto.WshAbzug.WshGrundbudgetPosition.DatumVon.AddMonths(anzahlMonate - 1);
                }
                else
                {
                    dto.VoraussichtlicheDauer = null;
                }
            }
        }

        public void SetVoraussichtlicheDauerUndSaldo(IUnitOfWork unitOfWork, WshAbzugDTO dto)
        {
            SetVoraussichtlicheDauer(dto);
            SetSaldo(unitOfWork, dto);
        }

        public void UpdateNewData(WshAbzugDTO abzugDto, WshKategorie kategorie, int faLeistungId)
        {
            abzugDto.WshAbzug.WshGrundbudgetPosition.WshKategorieID = kategorie.WshKategorieID;
            abzugDto.WshAbzug.WshGrundbudgetPosition.FaLeistungID = faLeistungId;

            if (kategorie.IstSanktion)
            {
                abzugDto.WshAbzug.MonatlichWiederholend = true;
            }
        }

        public KissServiceResult ValidateBeforeDelete(IUnitOfWork unitOfWork, WshAbzugDTO dataToDelete)
        {
            // Abgeschlossene Positionen nicht löschen
            if (dataToDelete.WshAbzug.IstAbgeschlossen)
            {
                return new KissServiceResult(
                    KissServiceResult.ResultType.Error,
                    "WshAbzugDTOService_CannotDelete_Abschluss",
                    "Abgeschlossene Abzüge können nicht gelöscht werden.");
            }

            // Nicht löschen, wenn nicht-graue Positionen existieren
            SetHatNurGrauePositionen(unitOfWork, dataToDelete);

            if (dataToDelete.HatNurGrauePositionen)
            {
                return KissServiceResult.Ok();
            }

            return new KissServiceResult(
                KissServiceResult.ResultType.Error,
                "WshAbzugDTOService_CannotDelete_Positionen",
                "Der Abzug kann nicht gelöscht werden, da bereits freigegebene oder verbuchte Positionen existieren.");
        }

        public KissServiceResult ValidateInMemory(WshAbzugDTO dataToValidate)
        {
            var result = WshAbzugDTOValidator.ValidateEntity(dataToValidate);

            if (!result)
            {
                return result;
            }

            result += CanUpdateDatumVon(dataToValidate);

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Monatsbudget-Positionen löschen, die Status vorbereitet und Betrag > 0 haben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dataToSave"></param>
        /// <returns></returns>
        private KissServiceResult DeleteWshPositions(IUnitOfWork unitOfWork, WshAbzugDTO dataToSave)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var result = KissServiceResult.Ok();

            var wshPositionService = Container.Resolve<WshPositionService>();
            var positionen = wshPositionService.GetByWshGrundbudgetPositionIdQueryable(unitOfWork, dataToSave.WshAbzug.WshGrundbudgetPositionID)
                .Where(x => x.Betrag > 0);
            var resultList = wshPositionService.SummenDerWshPositionenBerechnen(unitOfWork, positionen)
                .Where(x => x.PositionsStatus <= WshPositionsstatus.Vorbereitet);

            foreach (var wshPosition in resultList)
            {
                result += wshPositionService.DeleteData(unitOfWork, wshPosition);

                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        private ObservableCollection<WshAbzugDTO> GetByFaFallIdOrFaLeistungId(IUnitOfWork unitOfWork,
            bool getByFaFallId,
            int id,
            bool inklAbgeschlossene = true)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repoWshAbzug = UnitOfWork.GetRepository<WshAbzug>(unitOfWork);

            var result = repoWshAbzug
                .Include(x => x.WshGrundbudgetPosition)
                .Include(x => x.WshAbzugDetail.SubInclude(d => d.KbuKonto))
                .Include(x => x.WshGrundbudgetPosition.BaPerson)
                .Include(x => x.WshGrundbudgetPosition.FaLeistung.FaFall.BaPerson)
                .Include(x => x.WshGrundbudgetPosition.KbuKonto)
                .Include(x => x.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.SubInclude(kred => kred.BaZahlungsweg))
                .Include(x => x.WshGrundbudgetPosition.WshGrundbudgetPositionDebitor)
                .Include(x => x.WshGrundbudgetPosition.WshKategorie)
                .Include(x => x.WshGrundbudgetPosition.KbuKonto)
                .WhereIf(getByFaFallId, x => x.WshGrundbudgetPosition.FaLeistung.FaFallID == id) // nach FaFallID suchen
                .WhereIf(!getByFaFallId, x => x.WshGrundbudgetPosition.FaLeistungID == id) // nach FaLeistungID suchen
                .Where(x => x.WshGrundbudgetPosition.WshKategorie.IstAbzug)
                .WhereIf(!inklAbgeschlossene, x => x.AbschlussDatum == null)
                .OrderBy(x => x.WshGrundbudgetPosition.WshKategorie.SortKey)
                .ThenBy(x => x.WshGrundbudgetPosition.KbuKonto.KontoNr)
                .ThenByDescending(x => x.WshGrundbudgetPosition.DatumVon)
                .ThenByDescending(x => x.AbschlussDatum)
                .ToList()
                .Select(x => new WshAbzugDTO(x))
                .ToList();

            SetDtoProperties(unitOfWork, result);

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return new ObservableCollection<WshAbzugDTO>(result);
        }

        private decimal? GetGblAbzugProzent(decimal totalBetrag, decimal monatBetrag)
        {
            return monatBetrag > 0 ? Math.Round(monatBetrag / totalBetrag * 100, 1) : (decimal?)null;
        }

        private KissServiceResult SaveDetails(IUnitOfWork unitOfWork, WshAbzugDTO dataToSave)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var result = KissServiceResult.Ok();

            foreach (var detail in dataToSave.WshAbzug.WshAbzugDetail)
            {
                result += _abzugDetailService.SaveData(unitOfWork, detail, false);

                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        private void SetDtoProperties(IUnitOfWork unitOfWork, List<WshAbzugDTO> dtoList)
        {
            dtoList.ForEach(x => SetDtoProperties(unitOfWork, x));
        }

        /// <summary>
        /// Berechnet das Saldo der Positon.
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="dto">Das <see cref="WshAbzugDTO"/> für welches das Saldo berechnet werden muss</param>
        private void SetSaldo(IUnitOfWork unitOfWork, WshAbzugDTO dto)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var position = dto.WshAbzug.WshGrundbudgetPosition;
            var total = position.BetragTotal;

            if (!total.HasValue)
            {
                dto.Saldo = 0;
                return;
            }

            var repoBelegPosition = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);

            var belege = (from pos in repoBelegPosition
                          where pos.WshPosition != null &&
                                pos.WshPosition.WshGrundbudgetPositionID == dto.WshAbzug.WshGrundbudgetPosition.WshGrundbudgetPositionID
                          select pos).ToList();

            // Vorhandene Belege abziehen
            foreach (var pos in belege)
            {
                total -= pos.BetragBrutto;
            }

            dto.Saldo = total.Value;
        }

        #endregion

        #endregion
    }
}