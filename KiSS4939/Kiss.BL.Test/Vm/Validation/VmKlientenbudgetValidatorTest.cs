using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Vm.Validation;
using Kiss.Model;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Vm.Validation
{
    /// <summary>
    /// Tests the VmKlientenbudgetValidator
    /// </summary>
    [TestClass]
    public class VmKlientenbudgeVmKlientenbudgetValidatorTest
    {
        #region Fields

        #region Private Fields

        private VmKlientenbudgetValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new VmKlientenbudgetValidator();
        }

        [TestMethod]
        public void Validate_Empty_Entity()
        {
            var result = VmKlientenbudgetValidator.ValidateEntity(new VmKlientenbudget());

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_Ok()
        {
            var entity = new VmKlientenbudget
                         {
                             FaLeistungID = 1,
                             GueltigAb = DateTime.Now,
                             UserID = 1
                         };

            _validator.ShouldNotHaveValidationErrorFor(x => x.FaLeistungID, entity);
            _validator.ShouldNotHaveValidationErrorFor(x => x.GueltigAb, entity);
            _validator.ShouldNotHaveValidationErrorFor(x => x.UserID, entity);
        }

        [TestMethod]
        public void Validate_ValidationErrors()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.UserID, new VmKlientenbudget());
            _validator.ShouldHaveValidationErrorFor(x => x.FaLeistungID, new VmKlientenbudget());
            _validator.ShouldHaveValidationErrorFor(x => x.GueltigAb, new VmKlientenbudget());
        }

        #endregion
    }
}