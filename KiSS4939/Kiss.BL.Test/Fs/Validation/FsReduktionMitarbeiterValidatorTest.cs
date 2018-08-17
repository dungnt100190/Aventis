using Kiss.BL.Fs.Validation;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Fs.Validation
{
    /// <summary>
    /// Tests the TValidator
    /// </summary>
    [TestClass]
    public class FsReduktionMitarbeiterValidatorTest
    {
        #region Fields

        #region Private Fields

        private FsReduktionMitarbeiterValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new FsReduktionMitarbeiterValidator();
        }

        [TestMethod]
        public void Validate_NameIsEmpty_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Jahr, 0);
            _validator.ShouldHaveValidationErrorFor(x => x.Monat, 0);
            _validator.ShouldHaveValidationErrorFor(x => x.Monat, 13);
            _validator.ShouldHaveValidationErrorFor(x => x.UserID, 0);
            _validator.ShouldHaveValidationErrorFor(x => x.FsReduktionID, 0);
        }

        [TestMethod]
        public void Validate_NameIsSet_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Jahr, 2010);
            _validator.ShouldNotHaveValidationErrorFor(x => x.Monat, 8);
            _validator.ShouldNotHaveValidationErrorFor(x => x.UserID, 12);
            _validator.ShouldNotHaveValidationErrorFor(x => x.FsReduktionID, 12);
        }

        #endregion
    }
}