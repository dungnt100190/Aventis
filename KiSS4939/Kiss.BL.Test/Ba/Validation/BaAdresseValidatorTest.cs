using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Kiss.BL.Ba.Validation;
using Kiss.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BL.Test.Ba.Validation
{
    [TestClass]
    public class BaAdresseValidatorTest
    {
        #region Fields

        #region Private Fields

        private BaAdresseValidator _adresseValidator;

        #endregion

        #endregion

        #region Test Methods

        [TestMethod]
        public void Test_ErrorWhenBaPersonIDAndBaInstitutionIDAreNotSet()
        {
            var adresse = new BaAdresse();
            _adresseValidator.ShouldHaveValidationErrorFor(a => a.BaPersonID, adresse);
            _adresseValidator.ShouldHaveValidationErrorFor(a => a.BaInstitutionID, adresse);
        }

        [TestMethod]
        public void Test_ErrorWhenBaPersonIDAndBaInstitutionIDAreSet()
        {
            var adresse = new BaAdresse { BaPersonID = 1, BaInstitutionID = 2 };
            _adresseValidator.ShouldHaveValidationErrorFor(a => a.BaPersonID, adresse);
            _adresseValidator.ShouldHaveValidationErrorFor(a => a.BaInstitutionID, adresse);
        }

        [TestMethod]
        public void Test_ErrorWhenDatumVonBeforeDatumBis()
        {
            var adresse = new BaAdresse { DatumVon = new DateTime(1980, 01, 01), DatumBis = new DateTime(1975, 01, 01) };
            _adresseValidator.ShouldHaveValidationErrorFor(a => a.DatumBis, adresse);
        }

        [TestMethod]
        public void Test_ErrorWhenWohnStatusCodeNotInRange()
        {
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, (int?)null);
            _adresseValidator.ShouldHaveValidationErrorFor(a => a.WohnStatusCode, 0);
            _adresseValidator.ShouldHaveValidationErrorFor(a => a.WohnStatusCode, 12);
            _adresseValidator.ShouldHaveValidationErrorFor(a => a.WohnStatusCode, 13);
            _adresseValidator.ShouldHaveValidationErrorFor(a => a.WohnStatusCode, 16);
            _adresseValidator.ShouldHaveValidationErrorFor(a => a.WohnStatusCode, 19);
        }

        [TestMethod]
        public void Test_OkWhenBaInstitutionIDIsSet()
        {
            var adresse = new BaAdresse { BaInstitutionID = 2 };
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.BaPersonID, adresse);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.BaInstitutionID, adresse);
        }

        [TestMethod]
        public void Test_OkWhenBaPersonIDIsSet()
        {
            var adresse = new BaAdresse { BaPersonID = 1 };
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.BaPersonID, adresse);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.BaInstitutionID, adresse);
        }

        [TestMethod]
        public void Test_OkWhenDatumVonAfterDatumBis()
        {
            var adresse = new BaAdresse { DatumVon = new DateTime(1970, 01, 01), DatumBis = new DateTime(1975, 01, 01) };
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.DatumBis, adresse);
        }

        [TestMethod]
        public void Test_OkWhenWohnStatusCodeInRange()
        {
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 1);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 2);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 3);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 4);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 5);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 6);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 7);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 8);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 9);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 10);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 11);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 14);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 15);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 17);
            _adresseValidator.ShouldNotHaveValidationErrorFor(a => a.WohnStatusCode, 18);
        }

        [TestInitialize]
        public void TestSetup()
        {
            _adresseValidator = new BaAdresseValidator();
        }

        #endregion
    }
}