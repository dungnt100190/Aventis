using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Model;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Wsh.Validation
{
    /// <summary>
    /// Tests the WshPositionValidator
    /// </summary>
    [TestClass]
    public class WshPositionValidatorTest
    {
        #region Fields

        #region Private Fields

        private WshPositionValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new WshPositionValidator();
        }

        [TestMethod]
        public void Validate_BetragIsGreaterThan0_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Betrag, 10000);
        }

        [TestMethod]
        public void Validate_BetragIsLessThan0_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Betrag, -1);
            _validator.ShouldNotHaveValidationErrorFor(x => x.Betrag, 0);
        }

        [TestMethod]
        public void Validate_PeriodizitaetSemester_KeinTotalBetrag_NotValid()
        {
            var position = CreateValidPosition();
            var result = _validator.Validate(position);
            Assert.IsTrue(result.IsValid);
            position.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Semester;
            position.BetragTotal = null;
            result = _validator.Validate(position);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_TextIsEmpty_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Text, "");
        }

        [TestMethod]
        public void Validate_TextIsSet_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Text, "Text");
        }

        [TestMethod]
        public void Validate_VerwPeriodeBisIsBetweenSqlDateTimeMinAndMax_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.VerwPeriodeBis, Constant.SqlDateTimeMin);
            _validator.ShouldNotHaveValidationErrorFor(x => x.VerwPeriodeBis, DateTime.Now);
            _validator.ShouldNotHaveValidationErrorFor(x => x.VerwPeriodeBis, Constant.SqlDateTimeMax);
        }

        [TestMethod]
        public void Validate_VerwPeriodeBisIsNotBetweenSqlDateTimeMinAndMax_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.VerwPeriodeBis, DateTime.MinValue);
            _validator.ShouldHaveValidationErrorFor(x => x.VerwPeriodeBis, DateTime.MaxValue);
        }

        [TestMethod]
        public void Validate_VerwPeriodeVonIsBetweenSqlDateTimeMinAndMax_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.VerwPeriodeVon, Constant.SqlDateTimeMin);
            _validator.ShouldNotHaveValidationErrorFor(x => x.VerwPeriodeVon, DateTime.Now);
            _validator.ShouldNotHaveValidationErrorFor(x => x.VerwPeriodeVon, Constant.SqlDateTimeMax);
        }

        [TestMethod]
        public void Validate_VerwPeriodeVonIsNotBetweenSqlDateTimeMinAndMax_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.VerwPeriodeVon, DateTime.MinValue);
            _validator.ShouldHaveValidationErrorFor(x => x.VerwPeriodeVon, DateTime.MaxValue);
        }

        [TestMethod]
        public void Validate_WshKategorieCodeIsInEnum_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshKategorieID, 1);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshKategorieID, 2);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshKategorieID, 3);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshKategorieID, 4);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshKategorieID, 5);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshKategorieID, 6);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshKategorieID, 7);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshKategorieID, 8);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshKategorieID, 9);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshKategorieID, 100);
        }

        [TestMethod]
        public void Validate_WshKategorieCodeIsNotInEnum_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.WshKategorieID, 20);
            _validator.ShouldHaveValidationErrorFor(x => x.WshKategorieID, 21);
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Erstellt eine gültige Position, welche man dann kaputtmachen kann.
        /// </summary>
        /// <returns></returns>
        private WshPosition CreateValidPosition()
        {
            int kbuKontoId = 33;
            DateTime firstOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime lastOfMonth = firstOfMonth.AddMonths(1).AddDays(-1);

            WshPosition position = new WshPosition
            {
                Betrag = 78,
                BetragTotal = 78,
                KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.CashBarauszahlung,
                WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe,
                KbuKontoID = kbuKontoId,
                Text = "text",
                WshGrundbudgetPositionID = 44,
                FaelligAm = DateTime.Today,
                MonatVon = firstOfMonth,
                MonatBis = lastOfMonth,
                VerwPeriodeVon = firstOfMonth,
                VerwPeriodeBis = lastOfMonth,
                BetragAnfrage = 3223,
                Created = DateTime.Today,
                Creator = "blabla",
                Modified = DateTime.Today,
                Modifier = "blabla",
            };

            WshPositionKreditor kreditor = new WshPositionKreditor
            {
                Created = DateTime.Today,
                Creator = "blabla",
                Modified = DateTime.Today,
                Modifier = "blabla",
            };

            position.WshPositionKreditor.Add(kreditor);

            position.ChangeTracker.State = ObjectState.Unchanged;

            KbuKonto konto = new KbuKonto
            {
                KbuKontoID = kbuKontoId,
                KontoNr = "33",
                Created = DateTime.Today,
                Creator = "blabla",
                Modified = DateTime.Today,
                Modifier = "blabla",
            };

            position.KbuKonto = konto;

            return position;
        }

        #endregion

        #endregion
    }
}