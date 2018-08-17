using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Übersicht über alle Abzüge in einem Fall.
    /// </summary>
    public class WshFalluebersichtAbzugDTOService : ServiceBase, IServiceCRUD<WshFalluebersichtAbzugDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string DATE_MASK = @"{0:d.MM.yyy}";

        #endregion

        #endregion

        #region Constructors

        private WshFalluebersichtAbzugDTOService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, WshFalluebersichtAbzugDTO dataToDelete, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<WshFalluebersichtAbzugDTO> GetData(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        public IList<WshFalluebersichtAbzugDTO> GetFalluebersichtAbzug(IUnitOfWork unitOfWork, int faFallID, bool inkAbgeschlossene)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var abzugDtoService = Container.Resolve<WshAbzugDTOService>();

            IList<WshAbzugDTO> abzuege = abzugDtoService.GetByFaFallId(unitOfWork, faFallID, inkAbgeschlossene);
            IList<WshFalluebersichtAbzugDTO> result = new List<WshFalluebersichtAbzugDTO>();

            foreach (WshAbzugDTO abzug in abzuege)
            {
                WshFalluebersichtAbzugDTO abzugDto = Convert(unitOfWork, abzug);
                result.Add(abzugDto);
            }

            return result;
        }

        public KissServiceResult NewData(out WshFalluebersichtAbzugDTO newData)
        {
            throw new NotImplementedException();
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, WshFalluebersichtAbzugDTO dataToSave)
        {
            return KissServiceResult.Ok();
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, List<WshFalluebersichtAbzugDTO> dataToSave)
        {
            throw new NotImplementedException();
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, WshFalluebersichtAbzugDTO dataToSave, Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        private WshFalluebersichtAbzugDTO Convert(IUnitOfWork unitOfWork, WshAbzugDTO abzugDTO)
        {
            WshFalluebersichtAbzugDTO result = new WshFalluebersichtAbzugDTO();

            //WshAbzugID
            result.WshAbzugID = abzugDTO.WshAbzug.WshAbzugID;

            //Kategorie
            result.Kategorie = (LOVsGenerated.WshKategorie)abzugDTO.WshAbzug.WshGrundbudgetPosition.WshKategorieID;

            //KOA
            result.Koa = abzugDTO.WshAbzug.WshGrundbudgetPosition.KbuKonto.KontoNr;

            //Text
            result.Text = abzugDTO.WshAbzug.WshGrundbudgetPosition.Text;

            //Betrifft.
            if (abzugDTO.WshAbzug.WshGrundbudgetPosition.BaPersonID.HasValue)
            {
                result.Betrifft = abzugDTO.WshAbzug.WshGrundbudgetPosition.BaPerson.NameVorname;
            }
            else
            {
                result.Betrifft = "UE";
            }

            //DatumVon
            result.DatumVon = abzugDTO.WshAbzug.WshGrundbudgetPosition.DatumVon;

            //DatumBis
            result.DatumBis = abzugDTO.WshAbzug.WshGrundbudgetPosition.DatumBis;

            //Saldo
            result.Saldo = abzugDTO.Saldo;

            //Betrag monatlich
            result.BetragMonatlich = abzugDTO.WshAbzug.WshGrundbudgetPosition.BetragMonatlich;

            //GBL %
            result.PercentageGBL = abzugDTO.GblAbzugProzent;

            //Abschluss
            result.AbschlussDatum = abzugDTO.WshAbzug.AbschlussDatum;

            //Abschluss Aktion
            result.WshAbzugAbschlussAktionCode = abzugDTO.WshAbzug.WshAbzugAbschlussAktionCode;

            //FaLeistungID
            result.FaLeistungID = abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistungID;

            //FallBaPersonID
            result.FallBaPersonID = abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.FaFall.BaPersonID;

            //FaLeistungText
            string textTemplate = "WH: {0} ({1}, {2}), {3} - {4}";
            string nameLeistung = abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.BaPerson.NameVorname;
            string geschl = "?";
            if(abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.BaPerson.GeschlechtCode.HasValue
                && abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.BaPerson.GeschlechtCode.Value == 1)
            {
                geschl = "M";
            }
            if(abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.BaPerson.GeschlechtCode.HasValue
                && abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.BaPerson.GeschlechtCode.Value == 2)
            {
                geschl = "W";
            }

            string age = "?";
            if(abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.BaPerson.Geburtsdatum.HasValue)
            {
                int years = DateTime.Today.Year - abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.BaPerson.Geburtsdatum.Value.Year;
                DateTime birthdayThisYear = abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.BaPerson.Geburtsdatum.Value.AddYears(years);
                if (DateTime.Now.CompareTo(birthdayThisYear) < 0)
                {
                    years--;
                }
                age = years.ToString();
            }

            string ab = String.Format(DATE_MASK, abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.DatumVon);

            string bis = "";
            if (abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.DatumBis.HasValue)
            {
                DateTime datumBis = abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.DatumBis.Value;
                bis = String.Format(DATE_MASK, datumBis);
            }
            result.LeistungDisplayText = string.Format(textTemplate, nameLeistung, geschl, age, ab, bis);

            //Kategorie Text
            result.KategorieText = abzugDTO.WshAbzug.WshGrundbudgetPosition.WshKategorie.Name;

            return result;
        }

        #endregion

        #endregion
    }
}