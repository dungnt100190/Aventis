using Kiss.BusinessLogic.Ba;
using Kiss.DbContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BusinessLogic.Test.Ba
{
    [TestClass]
    public class BaAdresseServiceTest
    {
        #region Test Methods

        [TestMethod]
        public void GetAddressTextMultiline_ReturnString()
        {
            // Arrange
            var baAdresse = new BaAdresse
            {
                Zusatz = "zusatz",
                Strasse = "strasse",
                HausNr = "hausnr",
                PLZ = "7897",
                Ort = "Katzenhaus",
                Postfach = "9",
                PostfachOhneNr = false
            };

            // Act
            var baAdresseService = new BaAdresseService();
            var value = baAdresseService.GetAddressTextMultiline(baAdresse);

            // Assert
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Contains("Postfach"));
            Assert.IsTrue(value.Contains("7897"));
        }

        #endregion
    }
}