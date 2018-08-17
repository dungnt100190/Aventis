using Kiss.BusinessLogic.Sys;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BusinessLogic.Test.System
{
    [TestClass]
    public class IbanConverterServiceTest : DatabaseTestBase
    {
        private const string CLEARING_NR = "0235";
        private const string KONTO_NR = "315.404.10C";

        [TestMethod]
        [TestCategory("Web")]
        public void ConvertToIbanWeb()
        {
            var ibanConverterService = Container.Resolve<IbanConverterService>();
            var result = ibanConverterService.ConvertToIbanWeb(KONTO_NR, CLEARING_NR);

            Assert.IsTrue(result.IsOk, result.ToString());
            Assert.AreEqual("CH480023523531540410C", result.Result);
        }

        [TestMethod]
        [TestCategory("Web")]
        public void ConvertToIbanWebInvalidBc()
        {
            var ibanConverterService = Container.Resolve<IbanConverterService>();
            var result = ibanConverterService.ConvertToIbanWeb(KONTO_NR, "x");

            Assert.IsFalse(result.IsOk);
            // In case of an error the service should return the status code from the IBAN tool
            Assert.IsTrue(result.Result.StartsWith("10"));
        }
    }
}