using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.Infrastructure.IO;

namespace KiSS.Common.Test
{
    [TestClass]
    public class WebRequestTest
    {
        #region Test Methods

        [TestMethod,
        Description("With a valid but not existing address"),
        TestCategory("LongRunning"), TestCategory("Web")]
        [ExpectedException(typeof(WebRequestException))]
        public void Test_GetStreamInvalidRemoteName()
        {
            Stream stream = WebRequest.GetStream("http://ww.six-interbank-clearing.com/dam/downloads/bc-bank-master/bcbankenstamm.zip");
            Assert.IsNotNull(stream, "webRequest stream is not null");
        }

        [TestMethod,
        Description("With an invalid format address"),
        TestCategory("LongRunning"), TestCategory("Web")]
        [ExpectedException(typeof(WebRequestException))]
        public void Test_GetStreamInvalidUriFormat()
        {
            Stream stream = WebRequest.GetStream("http:/www.six-interbank-clearing.com/tkicch_extern/download/bcbankenstamm.zip");
            Assert.IsNotNull(stream, "webRequest stream is not null");
        }

        [TestMethod,
        Description("With the a valid and existing address"),
        TestCategory("LongRunning"), TestCategory("Web")]
        public void Test_GetStreamValidUri()
        {
            Stream stream = WebRequest.GetStream("http://www.six-interbank-clearing.com/dam/downloads/bc-bank-master/bcbankenstamm.zip");
            Assert.IsNotNull(stream, "webRequest stream is not null");
        }

        #endregion
    }
}