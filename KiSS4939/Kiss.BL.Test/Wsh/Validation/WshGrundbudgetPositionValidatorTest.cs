using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Wsh.Validation;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Wsh.Validation
{
    /// <summary>
    /// Tests the TValidator
    /// </summary>
    [TestClass]
    public class WshGrundbudgetPositionValidatorTest
    {
        #region Fields

        #region Private Fields

        private WshGrundbudgetPositionValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new WshGrundbudgetPositionValidator();
        }

        [TestMethod]
        public void Validate_DatumVonIsEmpty_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.DatumVon, DateTime.MinValue);
        }

        [TestMethod]
        public void Validate_DatumVonIsSet_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.DatumVon, DateTime.Now);
        }

        [TestMethod]
        public void Validate_FaLeistungID_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.FaLeistungID, 0);
        }

        [TestMethod]
        public void Validate_FaLeistungID_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.FaLeistungID, 12);
        }

        [TestMethod]
        public void Validate_TextIsEmpty_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Text, "");
        }

        [TestMethod]
        public void Validate_TextIsSet_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Text, "Mein Positions Text");
        }

        #endregion
    }
}