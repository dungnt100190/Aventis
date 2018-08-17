using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fs.Validation;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Fs.Validation
{
    /// <summary>
    /// Tests the <see cref="FsDienstleistungValidator"/>
    /// </summary>
    [TestClass]
    public class FsDienstleistungValidatorTest
    {
        #region Fields

        #region Private Fields

        private FsDienstleistungValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new FsDienstleistungValidator();
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
        public void Validate_StandardAufwandIsGreaterThan744_Error()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.StandardAufwand, 745);
        }

        [TestMethod]
        public void Validate_StandardAufwandIsInRange_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.StandardAufwand, 0);
            _validator.ShouldNotHaveValidationErrorFor(x => x.StandardAufwand, 744);
        }

        [TestMethod]
        public void Validate_StandardAufwandIsLessThan0_Error()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.StandardAufwand, -1);
        }

        #endregion
    }
}