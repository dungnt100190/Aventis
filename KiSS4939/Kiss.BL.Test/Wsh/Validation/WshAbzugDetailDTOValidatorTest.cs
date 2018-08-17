using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Wsh.Validation;
using Kiss.Model.DTO.Wsh;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Wsh.Validation
{
    /// <summary>
    /// Tests the WshAbzugDetailDTOValidator
    /// </summary>
    [TestClass]
    public class WshAbzugDetailDTOValidatorTest
    {
        #region Fields

        #region Private Fields

        private WshAbzugDetailDTOValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new WshAbzugDetailDTOValidator();
        }

        [TestMethod]
        public void Validate_NameIsEmpty_HasError()
        {
            var entity = new WshAbzugDetailDTO();
            _validator.ShouldHaveValidationErrorFor(x => x.WshAbzugDetail, entity);
        }

        #endregion
    }
}