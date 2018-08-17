using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;

using Kiss.BL.Kbu;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Wsh
{
    public class WshKategorieKontoDTOService : ServiceBase, IServiceCRUD<WshKategorieKontoDTO>
    {
        #region Constructors

        private WshKategorieKontoDTOService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshKategorieKontoDTO dataToDelete, bool saveChanges = true)
        {
            return new KissServiceResult(
                KissServiceResult.ResultType.Error,
                "Konti können hier nicht gelöscht werden."
                );
        }

        public ObservableCollection<WshKategorieKontoDTO> GetData(IUnitOfWork unitOfWork)
        {
            // aus Tabelle KbuKonto_WshKateggorie
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repositoryKbuKonto = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

            var konti = repositoryKbuKonto
                .OrderBy(kti => kti.KontoNr)
                .Where(x => x.KbuKontoklasseCode == 3 || x.KbuKontoklasseCode == 4)
                .Select(
                    konto => new
                    {
                        // Konto

                        DTO = new WshKategorieKontoDTO
                        {
                            KbuKontoID = konto.KbuKontoID,
                            KontoNr = konto.KontoNr,
                            KontoName = konto.Name,
                        },
                        kategorieListe = konto.WshKategorie_KbuKonto,
                    })
                    .ToList();

            ObservableCollection<WshKategorieKontoDTO> result = new ObservableCollection<WshKategorieKontoDTO>();

            konti.ForEach(x => SetDtoProperties(x.DTO, x.kategorieListe));
            konti.ForEach(x => result.Add(x.DTO));

            return result;
        }

        public WshKategorieKontoDTO GetDataByKontoId(IUnitOfWork unitOfWork, int id)
        {
            // aus Tabelle KbuKonto_WshKateggorie
            var kontoService = Container.Resolve<KbuKontoService>();
            var konto = kontoService.GetById(unitOfWork, id);
            var kontoKategoreiService = Container.Resolve<WshKategorieKbuKontoService>();

            var kontiKat = kontoKategoreiService.GetByKontoId(unitOfWork, id);

            var item = new WshKategorieKontoDTO
            {
                // Konto
                KbuKontoID = konto.KbuKontoID,
                KontoNr = konto.KontoNr,
                KontoName = konto.Name
            };

            SetDtoProperties(item, kontiKat);
            return item;
        }

        public KissServiceResult NewData(out WshKategorieKontoDTO newData)
        {
            newData = null;
            return new KissServiceResult(
                KissServiceResult.ResultType.Error,
                "Neue Konti können hier nicht eingefügt werden."
                );
        }

        public KissServiceResult SaveData(
            IUnitOfWork unitOfWork,
            WshKategorieKontoDTO dataToSave,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            throw new NotSupportedException();
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, WshKategorieKontoDTO dataToSave)
        {
            var result = new KissServiceResult(KissServiceResult.ResultType.Ok);
            if (dataToSave.ChangeTracker.State == ObjectState.Unchanged)
            {
                return result;
            }

            using (var trx = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

                result += SaveKategorieKontoMapping(unitOfWork, (int)LOVsGenerated.WshKategorie.Ausgabe, dataToSave.KbuKontoID, dataToSave.VerfuegbarAlsAusgabe);
                result += SaveKategorieKontoMapping(unitOfWork, (int)LOVsGenerated.WshKategorie.Einnahme, dataToSave.KbuKontoID, dataToSave.VerfuegbarAlsEinnahme);
                result += SaveKategorieKontoMapping(unitOfWork, (int)LOVsGenerated.WshKategorie.Sanktion, dataToSave.KbuKontoID, dataToSave.VerfuegbarAlsSanktion);
                result += SaveKategorieKontoMapping(unitOfWork, (int)LOVsGenerated.WshKategorie.Verrechnung, dataToSave.KbuKontoID, dataToSave.VerfuegbarAlsVerrechnung);
                result += SaveKategorieKontoMapping(unitOfWork, (int)LOVsGenerated.WshKategorie.Rueckerstattung, dataToSave.KbuKontoID, dataToSave.VerfuegbarAlsRueckerstattung);
                result += SaveKategorieKontoMapping(unitOfWork, (int)LOVsGenerated.WshKategorie.Abzahlung, dataToSave.KbuKontoID, dataToSave.VerfuegbarAlsAbzahlung);
                result += SaveKategorieKontoMapping(unitOfWork, (int)LOVsGenerated.WshKategorie.Kuerzung, dataToSave.KbuKontoID, dataToSave.VerfuegbarAlsKuerzung);
                result += SaveKategorieKontoMapping(unitOfWork, (int)LOVsGenerated.WshKategorie.Vermoegen, dataToSave.KbuKontoID, dataToSave.VerfuegbarAlsVermoegen);
                result += SaveKategorieKontoMapping(unitOfWork, (int)LOVsGenerated.WshKategorie.Vorabzug, dataToSave.KbuKontoID, dataToSave.VerfuegbarAlsVorabzug);
                unitOfWork.SaveChanges();
                trx.Complete();
            }
            return result;
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, List<WshKategorieKontoDTO> dataToSave)
        {
            // TODO ValidateInMemory
            var serviceResult = KissServiceResult.Ok();
            dataToSave.ForEach(p => serviceResult += SaveData(unitOfWork, p));
            return serviceResult;
        }

        #endregion

        #region Private Methods

        private WshKategorieKbuKontoVerfuegbar IsKategorieVerfuegbar(IEnumerable<WshKategorie_KbuKonto> katListe, LOVsGenerated.WshKategorie kategorie)
        {
            var mappingEntry = katListe.SingleOrDefault(kat => kat.WshKategorieID == (int)kategorie);
            if (mappingEntry == null)
            {
                return WshKategorieKbuKontoVerfuegbar.Nein;
            }
            return mappingEntry.NurMitSpezialrecht ? WshKategorieKbuKontoVerfuegbar.JaMitSpezialrecht : WshKategorieKbuKontoVerfuegbar.Ja;
        }

        private KissServiceResult SaveKategorieKontoMapping(IUnitOfWork unitOfWork,
            int wshKategorieID,
            int kbuKontoID,
            WshKategorieKbuKontoVerfuegbar verfuegbar)
        {
            var result = KissServiceResult.Ok();

            var kategorieKontoService = Container.Resolve<WshKategorieKbuKontoService>();
            var mapping = kategorieKontoService.GetByForeignKeys(unitOfWork, wshKategorieID, kbuKontoID);
            if (verfuegbar == WshKategorieKbuKontoVerfuegbar.Nein)
            {
                if (mapping != null)
                {
                    result = kategorieKontoService.DeleteData(unitOfWork, mapping);
                }
                return result;
            }

            if (mapping == null)
            {
                kategorieKontoService.NewData(out mapping);
                mapping.KbuKontoID = kbuKontoID;
                mapping.WshKategorieID = wshKategorieID;
            }

            mapping.NurMitSpezialrecht = (verfuegbar == WshKategorieKbuKontoVerfuegbar.JaMitSpezialrecht);
            result = kategorieKontoService.SaveData(unitOfWork, mapping);
            return result;
        }

        private void SetDtoProperties(WshKategorieKontoDTO dto, IList<WshKategorie_KbuKonto> kontiKat)
        {
            // für alle Konti einzelne Kategorien zuordnen
            var katListe = kontiKat.Where(k => k.KbuKontoID == dto.KbuKontoID);
            dto.VerfuegbarAlsAusgabe = IsKategorieVerfuegbar(katListe, LOVsGenerated.WshKategorie.Ausgabe);
            dto.VerfuegbarAlsEinnahme = IsKategorieVerfuegbar(katListe, LOVsGenerated.WshKategorie.Einnahme);
            dto.VerfuegbarAlsSanktion = IsKategorieVerfuegbar(katListe, LOVsGenerated.WshKategorie.Sanktion);
            dto.VerfuegbarAlsVerrechnung = IsKategorieVerfuegbar(katListe, LOVsGenerated.WshKategorie.Verrechnung);
            dto.VerfuegbarAlsRueckerstattung = IsKategorieVerfuegbar(katListe, LOVsGenerated.WshKategorie.Rueckerstattung);
            dto.VerfuegbarAlsAbzahlung = IsKategorieVerfuegbar(katListe, LOVsGenerated.WshKategorie.Abzahlung);
            dto.VerfuegbarAlsKuerzung = IsKategorieVerfuegbar(katListe, LOVsGenerated.WshKategorie.Kuerzung);
            dto.VerfuegbarAlsVermoegen = IsKategorieVerfuegbar(katListe, LOVsGenerated.WshKategorie.Vermoegen);
            dto.VerfuegbarAlsVorabzug = IsKategorieVerfuegbar(katListe, LOVsGenerated.WshKategorie.Vorabzug);

            dto.MarkAsUnchanged();
        }

        #endregion

        #endregion
    }
}