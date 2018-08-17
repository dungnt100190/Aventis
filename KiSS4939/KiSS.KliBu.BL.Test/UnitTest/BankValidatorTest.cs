using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using KiSS.KliBu.BL.DTO;
using KiSS.KliBu.BL.Validation;

using FluentValidation.Results;
using FluentValidation.TestHelper;

namespace KiSS.KliBu.BL.Test.UnitTest
{
    [TestClass]
    public class BankValidatorTest
    {
        #region Fields

        #region Private Fields

        private BankValidator _bankValidator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void Setup()
        {
            _bankValidator = new BankValidator();
        }

        [TestMethod,
        Description("Should have a validation error when the ClearingNr is not in the range"),
        TestCategory("Local")]
        public void Test_ErrorWhenClearingNrNotInRange()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.ClearingNr, (string)null);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.ClearingNr, "");
        }

        [TestMethod,
        Description("Should have a validation error when the FilialeNr is not in the range"),
        TestCategory("Local")]
        public void Test_ErrorWhenFilialeNrNotInRange()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.FilialeNr, -1);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.FilialeNr, 10000);
        }

        [TestMethod,
        Description("Should have a validation error when the GueltigAb is null"),
        TestCategory("Local")]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_ErrorWhenGueltigAbIsNull()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.GueltigAb, null);
        }

        [TestMethod,
        Description("Should have a validation error when the name is empty"),
        TestCategory("Local")]
        public void Test_ErrorWhenNameEmpty()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.Name, "");
        }

        [TestMethod,
        Description("Should not have a validation error when the ClearingNr is in the range"),
        TestCategory("Local")]
        public void Test_OkWhenClearingNrInRange()
        {
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.ClearingNr, "100");
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.ClearingNr, "1000");
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.ClearingNr, "99999");
        }

        [TestMethod,
        Description("Should not have a validation error when the FilialeNr is in the range"),
        TestCategory("Local")]
        public void Test_OkWhenFilialeNrInRange()
        {
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.FilialeNr, 0);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.FilialeNr, 1000);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.FilialeNr, 9999);
        }

        [TestMethod,
        Description("Should not have a validation error when the FilialeNr is in the range"),
        TestCategory("Local")]
        public void Test_OkWhenGueltigAbIsNotNull()
        {
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.GueltigAb, new DateTime(2009, 12, 30));
        }

        [TestMethod,
        Description("Should not have a validation error when the name is not empty"),
        TestCategory("Local")]
        public void Test_OkWhenNameNotEmpty()
        {
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.Name, "Bank Name");
        }

        [TestMethod,
        Description("Test the rule for BcArt"),
        TestCategory("Local")]
        public void Test_RuleBcArt()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.BcArt, 0);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.BcArt, 4);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.BcArt, 1);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.BcArt, 3);
        }

        [TestMethod,
        Description("Test the rule for ClearingNr"),
        TestCategory("Local")]
        public void Test_RuleClearingNr()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.ClearingNr, (string)null);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.ClearingNr, "");
        }

        [TestMethod,
        Description("Test the rule for ClearingNr_NEU"),
        TestCategory("Local")]
        public void Test_RuleClearingNrNEU()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.ClearingNrNeu, "");
        }

        [TestMethod,
        Description("Test the rule for FilialeNr"),
        TestCategory("Local")]
        public void Test_RuleFilialeNr()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.FilialeNr, -1);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.FilialeNr, 10000);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.FilialeNr, 0);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.FilialeNr, 9999);
        }

        [TestMethod,
        Description("Test the rule for Gruppe"),
        TestCategory("Local")]
        public void Test_RuleGruppe()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.Gruppe, 0);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.Gruppe, 10);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.Gruppe, 1);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.Gruppe, 9);
        }

        [TestMethod,
        Description("Test the rule for GueltigAb"),
        TestCategory("Local")]
        public void Test_RuleGueltigAb()
        {
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.GueltigAb, new DateTime(2009, 1, 1));
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.GueltigAb, new DateTime());
        }

        [TestMethod,
        Description("Test the rule for HauptsitzBCL"),
        TestCategory("Local")]
        public void Test_RuleHauptsitzBcl()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.HauptsitzBCL, "");
        }

        [TestMethod,
        Description("Test the rule for Landcode"),
        TestCategory("Local")]
        public void Test_RuleLandcode()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.Landcode, "D");
            _bankValidator.ShouldHaveValidationErrorFor(b => b.Landcode, "DEU");
            _bankValidator.ShouldHaveValidationErrorFor(b => b.Landcode, "ch");
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.Landcode, "DE");
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.Landcode, "");
        }

        [TestMethod,
        Description("Test the rule for Name"),
        TestCategory("Local")]
        public void Test_RuleName()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.Name, "");
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.Name, "name");
        }

        [TestMethod,
        Description("Test the rule for PCKontoNr"),
        TestCategory("Local")]
        public void Test_RulePcKontoNr()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.PCKontoNr, "a");
            _bankValidator.ShouldHaveValidationErrorFor(b => b.PCKontoNr, "*1-1-1");
            _bankValidator.ShouldHaveValidationErrorFor(b => b.PCKontoNr, "1-1-1");
            _bankValidator.ShouldHaveValidationErrorFor(b => b.PCKontoNr, "11-12-11");
            _bankValidator.ShouldHaveValidationErrorFor(b => b.PCKontoNr, "11-123456789-1");
            _bankValidator.ShouldHaveValidationErrorFor(b => b.PCKontoNr, "11--1");
            _bankValidator.ShouldHaveValidationErrorFor(b => b.PCKontoNr, "*11-1-1");
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.PCKontoNr, "11-1-1");
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.PCKontoNr, "11-123456-1");
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.PCKontoNr, "");
        }

        [TestMethod,
        Description("Test the rule for SicNr"),
        TestCategory("Local")]
        public void Test_RuleSicNr()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.SicNr, -1);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.SicNr, 1000000);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.SicNr, 0);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.SicNr, 999999);
        }

        [TestMethod,
        Description("Test the rule for Sprachcode"),
        TestCategory("Local")]
        public void Test_RuleSprachcode()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.Sprachcode, 0);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.Sprachcode, 4);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.Sprachcode, 1);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.Sprachcode, 3);
        }

        [TestMethod,
        Description("Test the rule for SwiftAdresse"),
        TestCategory("Local")]
        public void Test_RuleSwiftAdresse()
        {
            _bankValidator.ShouldHaveValidationErrorFor(b => b.SwiftAdresse, "12345678910_ZuLang");
            _bankValidator.ShouldHaveValidationErrorFor(b => b.SwiftAdresse, "zuKurz");
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.SwiftAdresse, "12345678910");
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.SwiftAdresse, "");
        }

        [TestMethod,
        Description("Test the rule for TeilnahmecodeCHF"),
        TestCategory("Local")]
        public void Test_RuleTeilnahmecodeChf()
        {
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.TeilnahmecodeCHF, default(int?)); // null
            _bankValidator.ShouldHaveValidationErrorFor(b => b.TeilnahmecodeCHF, -1);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.TeilnahmecodeCHF, 4);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.TeilnahmecodeCHF, 0);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.TeilnahmecodeCHF, 3);
        }

        [TestMethod,
        Description("Test the rule for TeilnahmecodeEuro"),
        TestCategory("Local")]
        public void Test_RuleTeilnahmecodeEuro()
        {
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.TeilnahmecodeEuro, default(int?)); // null
            _bankValidator.ShouldHaveValidationErrorFor(b => b.TeilnahmecodeEuro, -1);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.TeilnahmecodeEuro, 2);
            _bankValidator.ShouldHaveValidationErrorFor(b => b.TeilnahmecodeEuro, 4);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.TeilnahmecodeEuro, 0);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.TeilnahmecodeEuro, 1);
            _bankValidator.ShouldNotHaveValidationErrorFor(b => b.TeilnahmecodeEuro, 3);
        }

        [TestMethod,
        Description("Validate a valid Bank"),
        TestCategory("Local")]
        public void Test_ValidateBankOk()
        {
            Bank bank = new Bank("bank name", "100", 0, new DateTime(2009, 1, 1));
            ValidationResult result = _bankValidator.Validate(bank);
            Assert.IsTrue(result.IsValid, "Is valid");
        }

        [TestMethod,
        Description("Validate Bank with Clearing not in range"),
        TestCategory("Local")]
        public void Test_ValidateBankWithClearingNrNotInRange()
        {
            Bank bank = new Bank("bank name", "", 0, new DateTime(2009, 1, 1));
            ValidationResult result = _bankValidator.Validate(bank);
            Assert.IsFalse(result.IsValid, "Is valid with empty ClearingNr");
            Assert.AreEqual(1, result.Errors.Count, "Has one error");

            //bank = new Bank("bank name", "100000", 0, new DateTime(2009, 1, 1));
            //result = _bankValidator.Validate(bank);
            //Assert.IsFalse(result.IsValid, "Is valid with ClearingNr = 100000");
            //Assert.AreEqual(1, result.Errors.Count, "Has one error");
        }

        [TestMethod,
        Description("Validate Bank with Clearing not in range"),
        TestCategory("Local")]
        public void Test_ValidateBankWithInvalidMustField()
        {
            Bank bank = new Bank("", "", -1, new DateTime(2009, 1, 1));
            ValidationResult result = _bankValidator.Validate(bank);
            Assert.IsFalse(result.IsValid, "Is valid with empty ClearingNr");
            Assert.AreEqual(3, result.Errors.Count, "Has one error");

            //bank = new Bank("", "100000", 10000, new DateTime(2009, 1, 1));
            //result = _bankValidator.Validate(bank);
            //Assert.IsFalse(result.IsValid, "Is valid with ClearingNr = 100000");
            //Assert.AreEqual(3, result.Errors.Count, "Has one error");
        }

        [TestMethod,
        Description("Validate a whole Bank"),
        TestCategory("Local")]
        public void Test_ValidateWholeBankOk()
        {
            Bank bank = new Bank("bank name", "100", 0, new DateTime(2009, 1, 1));
            bank.Gruppe = 1;
            bank.BcArt = 1;
            bank.ClearingNrNeu = "123";
            bank.Fax = "032";
            bank.HauptsitzBCL = "100";
            bank.Kurzbezeichnung = "B";
            bank.Landcode = "";
            bank.LandesVorwahl = "+41";
            bank.Ort = "ort";
            bank.PCKontoNr = "11-1-1";
            bank.PLZ = "3018";
            bank.Sprachcode = 1;
            bank.Strasse = "str";
            bank.SwiftAdresse = "123456789AB";
            bank.TeilnahmecodeCHF = 1;
            bank.TeilnahmecodeEuro = 1;
            bank.Telefon = "031";

            ValidationResult result = _bankValidator.Validate(bank);
            Assert.IsTrue(result.IsValid, "Is valid");
        }

        [TestMethod,
        Description("Validate a whole incorrect Bank"),
        TestCategory("Local")]
        public void Test_ValidateWholeBankWithInvalidField()
        {
            Bank bank = new Bank("bank name", "99", 0, new DateTime(2009, 1, 1));
            bank.Gruppe = 0;
            bank.BcArt = 10;
            bank.ClearingNrNeu = "";
            bank.HauptsitzBCL = "";
            bank.Sprachcode = 10;
            bank.TeilnahmecodeCHF = 10;
            bank.TeilnahmecodeEuro = 2;
            bank.Landcode = "S";
            bank.PCKontoNr = "11-1234567-1";
            bank.SwiftAdresse = "123456789AB_ZuLang";

            ValidationResult result = _bankValidator.Validate(bank);
            Assert.IsFalse(result.IsValid, "Is valid");
            Assert.AreEqual(10, result.Errors.Count, "Has 10 error");
        }

        #endregion
    }
}