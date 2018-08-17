using System;
using System.Data.SqlTypes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Vm.Validation;
using Kiss.Model;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test
{
    [TestClass]
    public class ValidatorBaseTest
    {
        #region Fields

        #region Private Fields

        private ValidatorBase<VmPosition, VmPositionValidator> _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new ValidatorBase<VmPosition, VmPositionValidator>();
        }

        [TestMethod]
        public void Validate_CreatedIsInRange_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Created, DateTime.Now);
        }

        [TestMethod]
        public void Validate_CreatedIsLessThanSqlDateTimeMin_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Created, new DateTime());
        }

        [TestMethod]
        public void Validate_CreatorIsEmpty_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Creator, "");
        }

        [TestMethod]
        public void Validate_CreatorIsSet_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Creator, "anyCreator");
        }

        [TestMethod]
        public void Validate_ModifiedIsInRange_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Modified, DateTime.Now);
        }

        [TestMethod]
        public void Validate_ModifiedIsLessThanSqlDateTimeMin_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Modified, new DateTime());
        }

        [TestMethod]
        public void Validate_ModifierIsEmpty_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Modifier, "");
        }

        [TestMethod]
        public void Validate_ModifierIsSet_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Modifier, "anyModifier");
        }

        [TestMethod]
        public void Validate_NullableDecimalIsNotInRange_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.BetragMonatlich, (decimal?)SqlMoney.MaxValue + 1);
            _validator.ShouldHaveValidationErrorFor(x => x.BetragMonatlich, (decimal?)SqlMoney.MinValue - 1);
        }

        [TestMethod]
        public void Validate_NullableDecimalIsInRange_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.BetragMonatlich, (decimal?)SqlMoney.MaxValue);
            _validator.ShouldNotHaveValidationErrorFor(x => x.BetragMonatlich, (decimal?)SqlMoney.MinValue);
        }

        #endregion
    }
}