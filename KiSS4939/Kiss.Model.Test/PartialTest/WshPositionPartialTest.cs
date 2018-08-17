using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.Infrastructure.Constant;

namespace Kiss.Model.Test.PartialTest
{
    /// <summary>
    /// Tests für zusätzliche Properties in BaPerson.partial.cs
    /// </summary>
    [TestClass]
    public class WshPositionPartialTest
    {
        #region Test Methods

        [TestMethod]
        public void Test_Ausgabe()
        {
            var pos = new WshPosition
            {
                Betrag = 100,
                WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe
            };

            Assert.AreEqual(null, pos.BetragEinnahme);
            Assert.AreEqual(100, pos.BetragAusgabe);

            pos.Betrag = 0;
            pos.WshKategorieID = (int)LOVsGenerated.WshKategorie.Vorabzug;

            Assert.AreEqual(null, pos.BetragEinnahme);
            Assert.AreEqual(0, pos.BetragAusgabe);
        }

        [TestMethod]
        public void Test_Einnahme()
        {
            var pos = new WshPosition
            {
                Betrag = 100,
                WshKategorieID = (int)LOVsGenerated.WshKategorie.Einnahme
            };

            Assert.AreEqual(100, pos.BetragEinnahme);
            Assert.AreEqual(null, pos.BetragAusgabe);
        }

        #endregion
    }
}