using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Wsh.Validation;
using Kiss.Model;

namespace Kiss.BL.Test.Wsh.Validation
{
    /// <summary>
    /// Tests the TValidator
    /// </summary>
    [TestClass]
    public class WshGrundbudgetPositionKreditorValidatorTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CREATOR = "UnitTest";

        #endregion

        #region Private Fields

        private WshGrundbudgetPositionKreditorValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new WshGrundbudgetPositionKreditorValidator();
        }

        [TestMethod]
        public void Dalid_CheckDbConstraint_NotValid()
        {
            var kreditor = CreateWshGrundbudgetPositionKreditor();
            var result = _validator.Validate(kreditor);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Dalid_CheckDbConstraint_Valid()
        {
            var kreditor = CreateWshGrundbudgetPositionKreditor();
            kreditor.MitteilungZeile1 = "Hello";
            var result = _validator.Validate(kreditor);
            Assert.IsTrue(result.IsValid);
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

        #region Methods

        #region Private Methods

        private WshGrundbudgetPositionKreditor CreateWshGrundbudgetPositionKreditor()
        {
            var kreditor = new WshGrundbudgetPositionKreditor();

            kreditor.Creator = CREATOR;
            kreditor.Created = DateTime.Today;
            kreditor.Modifier = CREATOR;
            kreditor.Modified = DateTime.Today;

            return kreditor;
        }

        #endregion

        #endregion
    }
}