using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Model.Test.PartialTest
{
    /// <summary>
    /// Tests für zusätzliche Properties in BaPerson.partial.cs
    /// </summary>
    [TestClass]
    public class VmPositionPartialTest
    {
        #region Test Methods

        [TestMethod]
        public void BetragJaehrlich_SetBetragMonatlich_BetragJaehrlichIsSet()
        {
            // Arrange
            var position = new VmPosition();

            // Act
            position.BetragJaehrlich = 120;

            // Assert
            Assert.AreEqual(10, position.BetragMonatlich);
        }

        [TestMethod]
        public void BetragMonatlich_SetBetragJaehrlich_BetragMonatlichIsSet()
        {
            // Arrange
            var position = new VmPosition();

            // Act
            position.BetragMonatlich = 10;

            // Assert
            Assert.AreEqual(120, position.BetragJaehrlich);
        }

        #endregion
    }
}