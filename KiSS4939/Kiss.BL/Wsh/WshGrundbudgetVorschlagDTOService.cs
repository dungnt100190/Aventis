using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.Ba;
using Kiss.BL.Kbu;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage a TEntity.
    /// </summary>
    public class WshGrundbudgetVorschlagDTOService : ServiceBase, IServiceCRUD<WshGrundbudgetVorschlagDTO>
    {
        #region Constructors

        private WshGrundbudgetVorschlagDTOService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshGrundbudgetVorschlagDTO dataToDelete, bool saveChanges = true)
        {
            throw new NotSupportedException();
        }

        public ObservableCollection<WshGrundbudgetVorschlagDTO> GetData(IUnitOfWork unitOfWork)
        {
            throw new NotSupportedException();
        }

        public KissServiceResult NewData(out WshGrundbudgetVorschlagDTO newData)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Macht aus einer Liste von berechneten Grundbudgetpositionsvorschlägen Grundbudgetpositionen
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="grundbudgetVorschlagDtos"></param>
        /// <param name="faLeistungId"></param>
        /// <param name="questionsAndAnswers"></param>
        /// <returns></returns>
        public KissServiceResult SaveBerechnetePositionen(
            IUnitOfWork unitOfWork,
            IList<WshGrundbudgetVorschlagDTO> grundbudgetVorschlagDtos,
            int faLeistungId,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            KissServiceResult result = KissServiceResult.Ok();

            foreach (var vorschlagDto in grundbudgetVorschlagDtos)
            {
                //Zur Sicherheit, falls in View nicht gefiltert wird.
                if (!vorschlagDto.Selected)
                {
                    continue;
                }

                WshGrundbudgetPositionDTO position;

                result += NewData(unitOfWork, vorschlagDto, faLeistungId, out position);

                var grundbudgetService = Container.Resolve<WshGrundbudgetPositionDTOService>();
                result += grundbudgetService.SaveData(unitOfWork, position, questionsAndAnswers);
            }

            return result;
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, WshGrundbudgetVorschlagDTO dataToSave)
        {
            throw new NotSupportedException();
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, List<WshGrundbudgetVorschlagDTO> dataToSave)
        {
            throw new NotSupportedException();
        }

        public KissServiceResult SaveData(
            IUnitOfWork unitOfWork,
            WshGrundbudgetVorschlagDTO dataToSave,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Private Methods

        private KissServiceResult NewData(
            IUnitOfWork unitOfWork,
            WshGrundbudgetVorschlagDTO vorschlagDto,
            int faLeistungId,
            out WshGrundbudgetPositionDTO newData)
        {
            var grundbudgetService = Container.Resolve<WshGrundbudgetPositionDTOService>();
            var result = grundbudgetService.NewData(out newData);

            var position = newData.WshGrundbudgetPosition;

            //Datum setzen. Bei berechneten GBLs ist das Datum der aktuelle Monat, bei allen anderen Positionen der nächste
            //Monat (siehe auch NewData).
            KbuKontoService kontoService = Container.Resolve<KbuKontoService>();
            KbuKonto gbl = kontoService.GetGblKonto(unitOfWork);
            if (vorschlagDto.KontoID == gbl.KbuKontoID)
            {
                position.DatumVon = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            }

            position.Berechnet = true;
            position.FaLeistungID = faLeistungId;

            position.Bemerkung = vorschlagDto.Text;
            position.KbuKontoID = vorschlagDto.KontoID;
            position.BaPersonID = vorschlagDto.BaPersonID;

            if (string.IsNullOrEmpty(vorschlagDto.KontoText))
            {
                position.Text = UnitOfWork.GetRepository<KbuKonto>(unitOfWork)
                    .Where(k => k.KbuKontoID == position.KbuKontoID)
                    .Select(k => k.Name)
                    .SingleOrDefault();
            }
            else
            {
                position.Text = vorschlagDto.KontoText;
            }

            position.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat;

            if (vorschlagDto.Ausgaben > 0)
            {
                position.BetragMonatlich = vorschlagDto.Ausgaben;
                position.WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe;

                var grundbudgetPositionKreditorService = Container.Resolve<WshGrundbudgetPositionKreditorService>();
                WshGrundbudgetPositionKreditor kreditor;
                grundbudgetPositionKreditorService.NewData(out kreditor);
                position.WshGrundbudgetPositionKreditor.Add(kreditor);

                var standardZahlungsweg = Container.Resolve<BaZahlungswegSearchService>().GetStandardZahlungsweg(
                    unitOfWork, faLeistungId, Constant.MODULEID_W);
                if (standardZahlungsweg != null)
                {
                    kreditor.BaZahlungswegID = standardZahlungsweg.BaZahlungswegID;
                    position.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
                }
            }
            else
            {
                position.BetragMonatlich = vorschlagDto.Einnahmen;
                position.WshKategorieID = (int)LOVsGenerated.WshKategorie.Einnahme;
            }

            return result;
        }

        #endregion

        #endregion
    }
}