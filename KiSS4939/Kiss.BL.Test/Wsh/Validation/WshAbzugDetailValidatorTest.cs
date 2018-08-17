using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Wsh.Validation;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Wsh.Validation
{
    /// <summary>
    /// Tests the WshAbzugDetailValidator
    /// </summary>
    [TestClass]
    public class WshAbzugDetailValidatorTest
    {
        #region Fields

        #region Private Fields

        private WshAbzugDetailValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new WshAbzugDetailValidator();
        }

        [TestMethod]
        public void Validate_BaPersonID()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.BaPersonID, 0);
            _validator.ShouldNotHaveValidationErrorFor(x => x.BaPersonID, (int?)null);
        }

        [TestMethod]
        public void Validate_Betrag()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Betrag, 0);
            _validator.ShouldHaveValidationErrorFor(x => x.Betrag, -1);
            _validator.ShouldNotHaveValidationErrorFor(x => x.Betrag, 1);
        }

        [TestMethod]
        public void Validate_KbuKontoID()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.KbuKontoID, 0);
            _validator.ShouldHaveValidationErrorFor(x => x.KbuKontoID, -1);
            _validator.ShouldNotHaveValidationErrorFor(x => x.KbuKontoID, 1);
        }

        [TestMethod]
        public void Validate_WshAbzugID()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.WshAbzugID, 0);
            _validator.ShouldHaveValidationErrorFor(x => x.WshAbzugID, -1);
            _validator.ShouldNotHaveValidationErrorFor(x => x.WshAbzugID, 1);
        }

        #endregion
    }
}