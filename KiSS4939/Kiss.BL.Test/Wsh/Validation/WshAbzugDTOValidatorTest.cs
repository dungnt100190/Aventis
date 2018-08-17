using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Wsh;
using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.IoC;
using Kiss.Model.DTO.Wsh;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Wsh.Validation
{
    /// <summary>
    /// Tests the WshAbzugDTOValidator
    /// </summary>
    [TestClass]
    public class WshAbzugDTOValidatorTest
    {
        #region Fields

        #region Private Fields

        private WshAbzugDTO _dto;
        private WshAbzugDTOValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize(DatabaseTestUtil.CONNECTION_STRING_NAME_KISS5);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _validator = new WshAbzugDTOValidator();

            var svc = Container.Resolve<WshAbzugDTOService>();
            svc.NewData(out _dto);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestMethod]
        public void Validate_WshAbzug_IsNotInitialized_HasError()
        {
            var entity = new WshAbzugDTO();
            _validator.ShouldHaveValidationErrorFor(x => x.WshAbzug, entity);
        }

        [TestMethod]
        public void Validate_WshGrundbudgetPosition_BetragTotal_HasError()
        {
            _dto.WshAbzug.WshGrundbudgetPosition.BetragTotal = 0;
            var result = _validator.Validate(_dto);
            Assert.IsFalse(result.IsValid, result.GetMessageString());
        }

        #endregion
    }
}