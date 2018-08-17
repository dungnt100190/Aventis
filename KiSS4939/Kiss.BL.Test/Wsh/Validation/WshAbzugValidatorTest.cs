using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Wsh.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Model;

using FluentValidation.TestHelper;

namespace Kiss.BL.Test.Wsh.Validation
{
    /// <summary>
    /// Tests the WshAbzugValidator
    /// </summary>
    [TestClass]
    public class WshAbzugValidatorTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private WshAbzugValidator _validator;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void TestSetup()
        {
            _validator = new WshAbzugValidator();
        }

        [TestMethod]
        public void Validate_Abschluss_AllOrNone()
        {
            var entity = new WshAbzug
            {
                WshGrundbudgetPositionID = 1,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };

            // Nothing set: OK
            var result = _validator.Validate(entity);
            Assert.IsTrue(result.IsValid, result.GetMessageString());

            // Set one and validate
            entity.AbschlussDatum = DateTime.Today;
            result = _validator.Validate(entity);
            Assert.IsFalse(result.IsValid, result.GetMessageString());

            entity.AbschlussDatum = null;
            entity.AbschlussGrund = "Grundlos";
            result = _validator.Validate(entity);
            Assert.IsFalse(result.IsValid, result.GetMessageString());

            entity.AbschlussGrund = null;
            entity.WshAbzugAbschlussAktionCode = (int)LOVsGenerated.WshAbzugAbschlussAktion.Schuldanerkennung;
            result = _validator.Validate(entity);
            Assert.IsFalse(result.IsValid, result.GetMessageString());

            // Set all three: OK
            entity.AbschlussDatum = DateTime.Today;
            entity.AbschlussGrund = "Peace on Earth";
            entity.WshAbzugAbschlussAktionCode = (int)LOVsGenerated.WshAbzugAbschlussAktion.Keine;
            result = _validator.Validate(entity);
            Assert.IsTrue(result.IsValid, result.GetMessageString());
        }

        #endregion
    }
}