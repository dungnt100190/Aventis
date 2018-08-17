using System;

using Kiss.BL.Kbu.Validation;
using Kiss.Infrastructure.Validation;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentValidation.TestHelper;
using Kiss.Model;

namespace Kiss.BL.Test.Kbu.Validation
{
    /// <summary>
    /// Tests the TValidator
    /// </summary>
    [TestClass]
    public class KbuBelegKreisValidatorTest
    {
        #region Fields

        #region Private Fields

        private KbuBelegKreisValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new KbuBelegKreisValidator();
        }

        [TestMethod]
        public void Validate_BelegKreis_OK()
        {
            //Arrange
            KbuBelegKreis belegKeis = new KbuBelegKreis
            {
                BelegNrVon = 1,
                BelegNrBis = 10,
                NaechsteBelegNr = 1,
                Creator = "UnitTest",
                Created = DateTime.Today,
                Modifier = "UnitTest",
                Modified = DateTime.Today
            };

            //Act
            var result = _validator.Validate(belegKeis);

            //Assert
            Assert.IsTrue(result.IsValid, result.GetMessage());

        }

        [TestMethod]
        public void Validate_BelegKreis_NOK()
        {
            //Arrange
            KbuBelegKreis belegKeis = new KbuBelegKreis
            {
                BelegNrVon = 1,
                BelegNrBis = 10,
                NaechsteBelegNr = 12,
                Creator = "UnitTest",
                Created = DateTime.Today,
                Modifier = "UnitTest",
                Modified = DateTime.Today
            };

            //Act
            var result = _validator.Validate(belegKeis);

            //Assert
            Assert.IsFalse(result.IsValid);

        }

        [TestMethod]
        public void Validate_NameIsEmpty_HasError()
        {
            //_validator.ShouldHaveValidationErrorFor(x => x.Name, "");
        }

        [TestMethod]
        public void Validate_NameIsSet_IsValid()
        {
            //_validator.ShouldNotHaveValidationErrorFor(x => x.Name, "Müller");

        }

        #endregion
    }
}