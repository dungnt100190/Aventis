using System;
using System.Linq;

using Kiss.DataAccess.Validation;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Validation
{
    [TestClass]
    public class ValidatorBaseTest
    {
        [TestMethod]
        public void RangeErrorDateTime()
        {
            var validator = new TestValidator();
            var model = new TestModel
            {
                Datum = new DateTime(1500, 1, 1)
            };

            var result = validator.Validate(model);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.Errors.Count);

            var error = result.Errors.First(x => x.PropertyName == "Datum");
            Assert.IsTrue(error.ErrorMessage.Contains("Das Datum"));
        }

        private class TestModel
        {
            public DateTime Datum
            {
                get;
                set;
            }
        }

        private class TestValidator : ValidatorBase<TestModel>
        {
        }
    }
}