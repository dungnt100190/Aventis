using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Ba.Validation;
using Kiss.Model;

using FluentValidation.Results;
using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Ba.Validation
{
    [TestClass]
    public class BaPersonValidatorTest
    {
        #region Fields

        #region Private Fields

        private BaPersonValidator _personValidator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _personValidator = new BaPersonValidator();
        }

        [TestMethod]
        public void Test_ErrorWhenSterbedatumBeforeGeburtsdatum()
        {
            var person = new BaPerson { Geburtsdatum = new DateTime(1980, 01, 01), Sterbedatum = new DateTime(1975, 01, 01) };
            _personValidator.ShouldHaveValidationErrorFor(p => p.Sterbedatum, person);
        }

        [TestMethod]
        public void Test_OkWhenSterbedatumAfterGeburtsdatum()
        {
            var person = new BaPerson { Geburtsdatum = new DateTime(1970, 01, 01), Sterbedatum = new DateTime(1975, 01, 01) };
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.Sterbedatum, person);
        }

        [TestMethod]
        public void Test_ErrorWhenKonfessionCodeNotInRange()
        {
            _personValidator.ShouldHaveValidationErrorFor(p => p.KonfessionCode, 0);
            _personValidator.ShouldHaveValidationErrorFor(p => p.KonfessionCode, 10);
        }

        [TestMethod]
        public void Test_OkWhenKonfessionCodeInRange()
        {
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.KonfessionCode, 1);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.KonfessionCode, 2);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.KonfessionCode, 3);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.KonfessionCode, 4);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.KonfessionCode, 5);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.KonfessionCode, 6);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.KonfessionCode, 7);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.KonfessionCode, 8);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.KonfessionCode, 9);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.KonfessionCode, 99999);
        }

        [TestMethod]
        public void Test_ErrorWhenGeschlechtCodeNotInRange()
        {
            _personValidator.ShouldHaveValidationErrorFor(p => p.GeschlechtCode, 0);
            _personValidator.ShouldHaveValidationErrorFor(p => p.GeschlechtCode, 3);
        }

        [TestMethod]
        public void Test_OkWhenGeschlechtCodeInRange()
        {
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.GeschlechtCode, 1);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.GeschlechtCode, 2);
        }

        [TestMethod]
        public void Test_ErrorWhenZivilstandCodeNotInRange()
        {
            _personValidator.ShouldHaveValidationErrorFor(p => p.ZivilstandCode, 0);
            _personValidator.ShouldHaveValidationErrorFor(p => p.ZivilstandCode, 8);
        }

        [TestMethod]
        public void Test_OkWhenZivilstandCodeInRange()
        {
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.ZivilstandCode, 1);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.ZivilstandCode, 2);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.ZivilstandCode, 3);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.ZivilstandCode, 4);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.ZivilstandCode, 5);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.ZivilstandCode, 6);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.ZivilstandCode, 7);
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.ZivilstandCode, 99999);
        }

        [TestMethod]
        public void Test_ErrorWhenNameIsEmpty()
        {
            _personValidator.ShouldHaveValidationErrorFor(p => p.Name, "");
        }

        [TestMethod]
        public void Test_ErrorWhenVornameIsEmpty()
        {
            _personValidator.ShouldHaveValidationErrorFor(p => p.Vorname, "");
        }

        [TestMethod]
        public void Test_OkWhenNameIsNotEmpty()
        {
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.Name, "Meier");
        }

        [TestMethod]
        public void Test_OkWhenVornameIsNotEmpty()
        {
            _personValidator.ShouldNotHaveValidationErrorFor(p => p.Vorname, "Hans");
        }

        #endregion
    }
}