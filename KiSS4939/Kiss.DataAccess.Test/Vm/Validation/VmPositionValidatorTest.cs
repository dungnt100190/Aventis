using FluentValidation.TestHelper;
using Kiss.DataAccess.Vm.Validation;
using Kiss.DbContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Vm.Validation
{
    /// <summary>
    /// Tests the VmPositionValidator
    /// </summary>
    [TestClass]
    public class VmPositionValidatorTest
    {
        #region Test Methods

        [TestMethod]
        public void Validate_NameIsEmpty_HasError()
        {
            var validator = new VmPositionValidator();
            var entity = new VmPosition
                             {
                                 Name = "",
                                 VmKlientenbudgetID = 0,
                                 VmPositionsartID = 0,
                                 BetragJaehrlich = -1,
                                 BetragMonatlich = -1
                             };

            validator.ShouldHaveValidationErrorFor(x => x.Name, "");
            validator.ShouldNotHaveValidationErrorFor(x => x.VmKlientenbudgetID, entity);
            //validator.ShouldHaveValidationErrorFor(x => x.VmPositionsartID, entity);
        }

        [TestMethod]
        public void Validate_Ok()
        {
            var validator = new VmPositionValidator();
            var entity = new VmPosition
                             {
                                 Name = "Position",
                                 VmKlientenbudgetID = 1,
                                 VmPositionsartID = 1,
                                 BetragJaehrlich = 0,
                                 BetragMonatlich = 0
                             };
            validator.ShouldNotHaveValidationErrorFor(x => x.Name, entity);
            validator.ShouldNotHaveValidationErrorFor(x => x.VmKlientenbudgetID, entity);
            validator.ShouldNotHaveValidationErrorFor(x => x.VmPositionsartID, entity);
        }

        #endregion
    }
}