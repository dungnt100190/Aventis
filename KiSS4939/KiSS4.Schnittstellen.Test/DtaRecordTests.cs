using System;
using System.Globalization;
using System.IO;
using System.Threading;
using KiSS4.Schnittstellen.DTA_EZAG;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS4.Schnittstellen.Test
{
    [TestClass]
    public class DtaRecordTests
    {
        /// <summary>
        /// "790"
        /// </summary>
        private const string BCN = "790";

        /// <summary>
        /// 8. 55
        /// </summary>
        private const Decimal BETRAG = (Decimal)8.55;

        /// <summary>
        /// 123. 4500
        /// </summary>
        private const Decimal BETRAG_4_DEC = (Decimal)123.4500;

        /// <summary>
        /// 198
        /// </summary>
        private const Decimal BETRAG_NO_DEC = 198;

        /// <summary>
        /// "CH5800790042400007725"
        /// </summary>
        private const string IBAN = "CH5800790042400007725";

        /// <summary>
        /// "16244552204"
        /// </summary>
        private const string KONTO_NR = "16244552204";

        /// <summary>
        /// "302000287"
        /// </summary>
        private const string PC_KONTO_NR = "302000287";

        /// <summary>
        /// "1111111111111111"
        /// </summary>
        private const string REF_NR = "1111111111111111";

        public DtaRecordTests()
        {
            // sicherstellen, dass auch mit anderen Zahlenformaten ein korrektes Resultat erzielt wird
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-de");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-de");
        }

        [TestMethod]
        public void Test_Length826()
        {
            DtaRecord826 record827 = new DtaRecord826(KONTO_NR, BETRAG, "", "", "", "", PC_KONTO_NR, "", "", "", "", REF_NR, DateTime.Today);
            DtaOrder order = new DtaOrder(1, "", "", DateTime.Today, "", "");
            order.Add(record827);
            File.Delete(@"testDta");
            record827.WriteToDTAFile(new FileInfo(@"testDta"));
            string dtaRecordString = File.ReadAllText(@"testDta");
            File.Delete(@"testDta");

            Assert.IsNotNull(dtaRecordString);
            Assert.AreEqual(3 * 128, dtaRecordString.Length);
        }

        [TestMethod]
        public void Test_Length827()
        {
            DtaRecord827 record827 = new DtaRecord827(BCN, KONTO_NR, BETRAG, "", "", "", "", "", "", "", "", "", "", "", "", "", DateTime.Today);
            DtaOrder order = new DtaOrder(1, "", "", DateTime.Today, "", "");
            order.Add(record827);
            File.Delete(@"testDta");
            record827.WriteToDTAFile(new FileInfo(@"testDta"));
            string dtaRecordString = File.ReadAllText(@"testDta");
            File.Delete(@"testDta");

            Assert.IsNotNull(dtaRecordString);
            Assert.AreEqual(3 * 128, dtaRecordString.Length);
        }

        [TestMethod]
        public void Test_Length836_Mitteilungstext()
        {
            DtaRecord836 record836 = new DtaRecord836(BCN, KONTO_NR, BETRAG, "SozialDienst Test", "Teststrasse 66", "3445 Testianien", IBAN, "Testbegzüger", "Teststrasse 2", "2222 Testdorf", "Bla bla Zeile1", "Bla bla Zeile2", "Bla bla Zeile3", DateTime.Now);
            DtaOrder order = new DtaOrder(1, "", "", DateTime.Today, "", "");
            order.Add(record836);
            string dtaRecordString = record836.CreateDTAString();

            Assert.AreEqual(5 * 128, dtaRecordString.Length);
        }

        [TestMethod]
        public void Test_Length836_MitteilungstextZuLang()
        {
            DtaRecord836 record836 = new DtaRecord836(BCN, KONTO_NR, BETRAG, "SozialDienst Test", "Teststrasse 66", "3445 Testianien", IBAN, "Testbegzüger", "Teststrasse 2", "2222 Testdorf", "Bla bla Zeile1__12345678901234567890", "Bla bla Zeile2__12345678901234567890", "Bla bla Zeile3__12345678901234567890", DateTime.Now);
            DtaOrder order = new DtaOrder(1, "", "", DateTime.Today, "", "");
            order.Add(record836);
            string dtaRecordString = record836.CreateDTAString();

            Assert.AreEqual(5 * 128, dtaRecordString.Length);
        }

        [TestMethod]
        public void Test_Length836_Referenzzeile()
        {
            DtaRecord836 record836 = new DtaRecord836(BCN, KONTO_NR, BETRAG, "SozialDienst Test", "Teststrasse 66", "3445 Testianien", IBAN, "Testbegzüger", "Teststrasse 2", "2222 Testdorf", "12345678901234567890", DateTime.Now);
            DtaOrder order = new DtaOrder(1, "", "", DateTime.Today, "", "");
            order.Add(record836);
            string dtaRecordString = record836.CreateDTAString();

            Assert.AreEqual(5 * 128, dtaRecordString.Length);
        }

        [TestMethod]
        public void Test_Verguetungsbetrag827()
        {
            DtaRecord827 record827 = new DtaRecord827("", "", BETRAG, "", "", "", "", "", "", "", "", "", "", "", "", "", DateTime.Today);
            Assert.AreEqual("      CHF8,55        ", record827.VerguetungsbetragToDTA);
        }

        [TestMethod]
        public void Test_Verguetungsbetrag836()
        {
            DtaRecord836 record836 = new DtaRecord836("", "", BETRAG, "", "", "", "", "", "", "", "", DateTime.Today);
            Assert.AreEqual(DateTime.Today.ToString("yyMMdd") + "CHF8,55           ", record836.VerguetungsbetragToDTA);
        }

        [TestMethod]
        public void Test_Verguetungsbetrag836FourDecimals()
        {
            DtaRecord836 record836 = new DtaRecord836("", "", BETRAG_4_DEC, "", "", "", "", "", "", "", "", DateTime.Today);
            Assert.AreEqual(DateTime.Today.ToString("yyMMdd") + "CHF123,45         ", record836.VerguetungsbetragToDTA);
        }

        [TestMethod]
        public void Test_Verguetungsbetrag836FourDecimalsNok()
        {
            DtaRecord836 record836 = new DtaRecord836("", "", BETRAG_4_DEC, "", "", "", "", "", "", "", "", DateTime.Today);
            Assert.AreNotEqual(DateTime.Today.ToString("yyMMdd") + "CHF123,4500       ", record836.VerguetungsbetragToDTA);
        }

        [TestMethod]
        public void Test_Verguetungsbetrag836NoDecimals()
        {
            DtaRecord836 record836 = new DtaRecord836("", "", BETRAG_NO_DEC, "", "", "", "", "", "", "", "", DateTime.Today);
            Assert.AreEqual(DateTime.Today.ToString("yyMMdd") + "CHF198,00         ", record836.VerguetungsbetragToDTA);
        }
    }
}