using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Validation;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh.Validation
{
    /// <summary>
    /// Tests the TValidator
    /// </summary>
    [TestClass]
    public class WshGrundbudgetPositionDTOValidatorTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CREATOR = "UnitTest";

        #endregion

        #region Private Fields

        private WshGrundbudgetPositionDTOValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new WshGrundbudgetPositionDTOValidator();
        }

        [TestMethod]
        public void Validate_AusgabeOhneKreditor_NotValid()
        {
            var position = CreatePositionOhneKreditor();
            position.WshGrundbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            var result = _validator.Validate(position);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_Auszahlung_OhneKreditor_NotValid()
        {
            var position = CreatePositionMitKreditor();
            position.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Single().MarkAsDeleted();
            position.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Clear();
            position.WshGrundbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            var result = _validator.Validate(position);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_ElektronischeAuszahlung_MitZahlungsweg_Valid()
        {
            var position = CreatePositionMitKreditor();
            position.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Single().BaZahlungswegID = 22;
            position.WshGrundbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            var result = _validator.Validate(position);
            Assert.IsTrue(result.IsValid, result.GetMessage());
        }

        [TestMethod]
        public void Validate_ElektronischeAuszahlung_OhneZahlungsweg_NotValid()
        {
            var position = CreatePositionMitKreditor();
            position.WshGrundbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            var result = _validator.Validate(position);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_NonPlanwert_Kreditor_NotValid()
        {
            var position = CreatePositionOhneKreditor();
            position.WshGrundbudgetPosition.Planwert = false;
            position.WshGrundbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            var result = _validator.Validate(position);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_NonPlanwert_OhnePeriodizitaet_NotValid()
        {
            var position = CreatePositionMitKreditor();
            position.WshGrundbudgetPosition.Planwert = false;
            position.WshGrundbudgetPosition.WshPeriodizitaetCode = null;
            var result = _validator.Validate(position);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_PeriodizitaetSemester_KeinTotalBetrag_NotValid()
        {
            var position = CreatePositionMitKreditor();
            position.WshGrundbudgetPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Semester;
            position.WshGrundbudgetPosition.BetragTotal = null;
            var result = _validator.Validate(position);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_Planwert_OhneKreditor_Valid()
        {
            var position = CreatePositionOhneKreditor();
            position.WshGrundbudgetPosition.Planwert = true;
            position.WshGrundbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            var result = _validator.Validate(position);
            Assert.IsTrue(result.IsValid, result.GetMessage());
        }

        [TestMethod]
        public void Validate_Planwert_OhnePeriodizitaet_Valid()
        {
            var position = CreatePositionMitKreditor();
            position.WshGrundbudgetPosition.Planwert = true;
            position.WshGrundbudgetPosition.WshPeriodizitaetCode = null;
            var result = _validator.Validate(position);
            Assert.IsTrue(result.IsValid, result.GetMessage());
        }

        [TestMethod]
        public void Validate_Planwert_OhneZahlungsart_Valid()
        {
            var position = CreatePositionMitKreditor();
            position.WshGrundbudgetPosition.Planwert = true;
            position.WshGrundbudgetPosition.KbuAuszahlungArtCode = null;
            var result = _validator.Validate(position);
            Assert.IsTrue(result.IsValid, result.GetMessage());
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static WshGrundbudgetPositionDTO AddKreditorToPosition(WshGrundbudgetPositionDTO positionDto)
        {
            var kreditor = new WshGrundbudgetPositionKreditor();

            kreditor.WshGrundbudgetPosition = positionDto.WshGrundbudgetPosition;
            kreditor.Creator = CREATOR;
            kreditor.Created = DateTime.Today;
            kreditor.Modifier = CREATOR;
            kreditor.Modified = DateTime.Today;

            positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Add(kreditor);
            return positionDto;
        }

        #endregion

        #region Private Methods

        private WshGrundbudgetPositionDTO CreatePositionMitKreditor()
        {
            var position = CreatePositionOhneKreditor();
            position = AddKreditorToPosition(position);
            return position;
        }

        /// <summary>
        /// Kreiert einen neuen Position mit einem Kreditor. 
        /// Validiert. Kann dan in den Tests absichtlich kaputt
        /// gemacht werden.
        /// </summary>
        /// <returns></returns>
        private WshGrundbudgetPositionDTO CreatePositionOhneKreditor()
        {
            WshGrundbudgetPosition position = new WshGrundbudgetPosition();
            position.Text = "Hello";
            position.FaLeistungID = 33;
            position.KbuKontoID = 3;
            position.DatumVon = DateTime.Today;
            position.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.CashBarauszahlung;
            position.WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe;
            position.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat;
            position.BetragMonatlich = (decimal)123.45;

            position.Creator = CREATOR;
            position.Created = DateTime.Today;
            position.Modifier = CREATOR;
            position.Modified = DateTime.Today;

            var dto = new WshGrundbudgetPositionDTO
            {
                WshGrundbudgetPosition = position,
            };

            return dto;
        }

        #endregion

        #endregion
    }
}