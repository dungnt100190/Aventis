using FluentValidation.TestHelper;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fs.Validation;

namespace Kiss.BL.Test.Fs.Validation
{
    [TestClass]
    public class FsDienstleistungspaketValidatorTest
    {
        #region Fields

        #region Private Fields

        private FsDienstleistungspaketValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new FsDienstleistungspaketValidator();
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
        public void Validate_LaufzeitIsGreaterThan0_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.MaximaleLaufzeit, 0);
        }

        [TestMethod]
        public void Validate_LaufzeitIsNull_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.MaximaleLaufzeit, null as decimal?);
        }

        [TestMethod]
        public void Validate_LaufzeitIsLessThan0_Error()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.MaximaleLaufzeit, -1);
        }

        #endregion
    }
}