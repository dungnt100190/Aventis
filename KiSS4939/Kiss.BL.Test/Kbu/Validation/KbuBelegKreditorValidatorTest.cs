using Kiss.BL.Kbu.Validation;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Kbu.Validation
{
    /// <summary>
    /// Tests the TValidator
    /// </summary>
    [TestClass]
    public class KbuBelegKreditorValidatorTest
    {
        #region Fields

        #region Private Fields

        private KbuBelegKreditorValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new KbuBelegKreditorValidator();
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