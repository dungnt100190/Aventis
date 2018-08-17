using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fs.Validation;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Fs.Validation
{
    /// <summary>
    /// Tests the FsReduktionValidator
    /// </summary>
    [TestClass]
    public class FsReduktionValidatorTest
    {
        #region Fields

        #region Private Fields

        private FsReduktionValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new FsReduktionValidator();
        }

        [TestMethod]
        public void Validate_NameIsEmpty_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Name, "");
        }

        [TestMethod]
        public void Validate_NameIsSet_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Name, "Name");
        }

        [TestMethod]
        public void Validate_StandardAufwandIsGreaterThan8760_Error()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.StandardAufwand, 8761);
        }

        [TestMethod]
        public void Validate_StandardAufwandIsInRange_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.StandardAufwand, 0);
            _validator.ShouldNotHaveValidationErrorFor(x => x.StandardAufwand, 8760);
        }

        [TestMethod]
        public void Validate_StandardAufwandIsLessThan0_Error()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.StandardAufwand, -1);
        }

        #endregion
    }
}