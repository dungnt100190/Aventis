using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Wsh;
using Kiss.Interfaces.IoC;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the WshPositionMonatBudgetDTOService service.
    /// </summary>
    [TestClass]
    public class WshPositionMonatBudgetDTOServiceTest
    {
        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SaveData_WithList_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshPositionMonatBudgetDTOService>();

            // Act
            service.SaveData(null, new List<WshPositionMonatBudgetDTO>());

            // Assert
            Assert.IsFalse(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SaveData_WithQuestion_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshPositionMonatBudgetDTOService>();

            // Act
            service.SaveData(null, null, null);

            // Assert
            Assert.IsFalse(true);
        }

        #endregion
    }
}