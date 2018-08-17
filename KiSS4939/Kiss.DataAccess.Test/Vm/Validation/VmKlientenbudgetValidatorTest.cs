using System;
using FluentValidation.TestHelper;
using Kiss.DataAccess.Vm.Validation;
using Kiss.DbContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Vm.Validation
{
    /// <summary>
    /// Tests the VmKlientenbudgetValidator
    /// </summary>
    [TestClass]
    public class VmKlientenbudgetValidatorTest
    {
        #region Test Methods

        [TestMethod]
        public void Validate_Empty_Entity()
        {
            // Arrange
            var validator = new VmKlientenbudgetValidator();
            var entityToValidate = new VmKlientenbudget();

            // Act
            var result = validator.Validate(entityToValidate);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_Ok()
        {
            // Arrange
            var validator = new VmKlientenbudgetValidator();
            var entityToValidate = new VmKlientenbudget
                                       {
                                           FaLeistungID = 1,
                                           GueltigAb = DateTime.Now,
                                           UserID = 1
                                       };

            // Act / Assert
            validator.ShouldNotHaveValidationErrorFor(x => x.FaLeistungID, entityToValidate);
            validator.ShouldNotHaveValidationErrorFor(x => x.GueltigAb, entityToValidate);
            validator.ShouldNotHaveValidationErrorFor(x => x.UserID, entityToValidate);
        }

        [TestMethod]
        public void Validate_ValidationErrors()
        {
            var validator = new VmKlientenbudgetValidator();
            //validator.ShouldHaveValidationErrorFor(x => x.UserID, new VmKlientenbudget());
            //validator.ShouldHaveValidationErrorFor(x => x.FaLeistungID, new VmKlientenbudget());
            validator.ShouldHaveValidationErrorFor(x => x.GueltigAb, new VmKlientenbudget());
            validator.ShouldHaveValidationErrorFor(x => x.VmKlientenbudgetMutationsgrundCode, new VmKlientenbudget());
            validator.ShouldHaveValidationErrorFor(x => x.VmKlientenbudgetStatusCode, new VmKlientenbudget());
        }

        #endregion
    }
}