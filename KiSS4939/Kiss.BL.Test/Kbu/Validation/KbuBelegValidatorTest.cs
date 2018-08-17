using Kiss.BL.Kbu.Validation;
using Kiss.Infrastructure.Constant;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Kbu.Validation
{
    /// <summary>
    /// Tests the TValidator
    /// </summary>
    [TestClass]
    public class KbuBelegValidatorTest
    {
        #region Fields

        #region Private Fields

        private KbuBelegValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new KbuBelegValidator();
        }

        [TestMethod]
        public void Validate_NameIsEmpty_HasError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.KbuBelegartCode, 7878);
            _validator.ShouldHaveValidationErrorFor(x => x.KbuBelegstatusCode, 7878);
        }

        [TestMethod]
        public void Validate_NameIsSet_IsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.KbuBelegartCode, (int) LOVsGenerated.KbuBelegart.Einzahlung);
            _validator.ShouldNotHaveValidationErrorFor(x => x.KbuBelegstatusCode, (int)LOVsGenerated.KbuBelegstatus.Freigegeben);
        }

        #endregion
    }
}