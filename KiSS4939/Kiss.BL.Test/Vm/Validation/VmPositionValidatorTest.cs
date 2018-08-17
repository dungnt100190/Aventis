using FluentValidation.TestHelper;
using Kiss.BL.Vm.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BL.Test.Vm.Validation
{
    /// <summary>
    /// Tests the VmPositionValidator
    /// </summary>
    [TestClass]
    public class VmPositionValidatorTest
    {
        #region Fields

        #region Private Fields

        private VmPositionValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new VmPositionValidator();
        }

        [TestMethod]
        public void Validate_NameIsEmpty_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Name, "");
            _validator.ShouldNotHaveValidationErrorFor(x => x.VmKlientenbudgetID, 0);
            _validator.ShouldHaveValidationErrorFor(x => x.VmPositionsartID, 0);
        }

        [TestMethod]
        public void Validate_Ok()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Name, "Position");
            _validator.ShouldNotHaveValidationErrorFor(x => x.VmKlientenbudgetID, 1);
            _validator.ShouldNotHaveValidationErrorFor(x => x.VmPositionsartID, 1);
        }

        #endregion
    }
}