using System;

using Kiss.BL.Wsh.Validation;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Wsh.Validation
{
    /// <summary>
    /// Tests the <see cref="WshHaushaltPersonValidator"/>
    /// </summary>
    [TestClass]
    public class WshHaushaltPersonValidatorTest
    {
        #region Fields

        #region Private Fields

        private WshHaushaltPersonValidator _validator;

#pragma warning disable 649 //Field is never initialized
        private DateTime _uninitializedDateValue;
#pragma warning restore 649

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new WshHaushaltPersonValidator();
        }

        [TestMethod]
        public void Validate_FaLeistungID_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.FaLeistungID, 0);
        }

        [TestMethod]
        public void Validate_BaPersonID_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.BaPersonID, 0);
        }

        [TestMethod]
        public void Validate_DatumVon_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.DatumVon, _uninitializedDateValue);
        }

        [TestMethod]
        public void Validate_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.FaLeistungID, 1);
            _validator.ShouldNotHaveValidationErrorFor(x => x.BaPersonID, 1);
            _validator.ShouldNotHaveValidationErrorFor(x => x.DatumVon, DateTime.Now);
        }

        #endregion
    }
}