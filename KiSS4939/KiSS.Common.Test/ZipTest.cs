using System.IO;
using System.Text;
using Kiss.Infrastructure.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KiSS.Common.Test
{
    [TestClass]
    [DeploymentItem(@"TestFiles\bcbankenstamm.zip", @"TestFiles")]
    public class ZipTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const int ENCODING_CODE = 1252; // Western European

        #endregion

        #endregion

        #region Test Methods

        [TestMethod,
        Description("Extract the content of the zip file"),
        TestCategory("TestData")]
        public void Test_Extract()
        {
            Zip zip = new Zip(@"TestFiles\bcbankenstamm.zip");
            zip.Extract("bcbankenstamm", @"TestFiles\bc", true);

            Assert.IsTrue(File.Exists(@"TestFiles\bc\bcbankenstamm"), "file exists");
        }

        [TestMethod,
        Description("Zip file doesn't exists"),
        TestCategory("TestData")]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Test_FileNotExists()
        {
            new Zip(@"TestFiles\notExists.zip");
        }

        [TestMethod,
        Description("Get the zip file stream"),
        TestCategory("TestData")]
        public void Test_GetStream()
        {
            Zip zip = new Zip(@"TestFiles\bcbankenstamm.zip");
            Stream stream = zip.GetStream("bcbankenstamm");

            Assert.IsNotNull(stream, "Entry stream is not null");
            Assert.AreNotEqual(0, stream.Length, "stream length is not 0");

            byte[] buffer = new byte[300];
            int readByte = stream.Read(buffer, 0, buffer.Length);
            string line = Encoding.GetEncoding(ENCODING_CODE).GetString(buffer);

            Assert.AreEqual("01", line.Substring(0, 2), "line 0-2 chars compare");
            Assert.AreEqual("100  ", line.Substring(2, 5), "line 2-5 chars compare");
            Assert.AreEqual("0000", line.Substring(7, 4), "line 7-4 chars compare");
        }

        #endregion
    }
}