using System;
using System.Globalization;
using System.IO;
using System.Threading;
using KiSS4.Common;
using KiSS4.Schnittstellen.DTA_EZAG;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS4.Schnittstellen.Test
{
    [TestClass]
    public class DtaRecordFactoryTests
    {
        private readonly DtaPaymentInformation _fibuPaymentInformationBankIban = new DtaPaymentInformation(ZahlungsArt.BankUeberweisung, DtaTestCommon.IBAN, DtaTestCommon.BCN, DtaTestCommon.BETRAG, "", "", "", "", "", "", "", "", "",
            "", DtaTestCommon.BANKKONTO_NR, "", "", "", "", DtaTestCommon.ZAHLUNGSKONTO_NR, DateTime.Today);

        private readonly DtaPaymentInformation _fibuPaymentInformationBankOhneIban = new DtaPaymentInformation(ZahlungsArt.BankUeberweisung, "", DtaTestCommon.BCN, DtaTestCommon.BETRAG, "", "", "", "", "", "", "", "", "",
            "", DtaTestCommon.BANKKONTO_NR, "", "", "", "", DtaTestCommon.ZAHLUNGSKONTO_NR, DateTime.Today);

        private readonly DtaPaymentInformation _klibuPaymentInformationBankIban = new DtaPaymentInformation(Einzahlungsschein.BankzahlungSchweiz, DtaTestCommon.IBAN, DtaTestCommon.BCN, DtaTestCommon.BETRAG, "", "", "", "", "", "", "", "", "",
            "", DtaTestCommon.BANKKONTO_NR, 1, 9, 9, 0, DtaTestCommon.ZAHLUNGSKONTO_NR, DateTime.Today);

        private readonly DtaPaymentInformation _klibuPaymentInformationBankOhneIban = new DtaPaymentInformation(Einzahlungsschein.BankzahlungSchweiz, "", DtaTestCommon.BCN, DtaTestCommon.BETRAG, "", "", "", "", "", "", "", "", "",
            "", DtaTestCommon.BANKKONTO_NR, 1, 9, 9, 0, DtaTestCommon.ZAHLUNGSKONTO_NR, DateTime.Today);

        private readonly SozialDienst _sozialDienst = new SozialDienst("SD Test", "Teststrasse 23", "3000", "Bern");

        public DtaRecordFactoryTests()
        {
            // sicherstellen, dass auch mit anderen Zahlenformaten ein korrektes Resultat erzielt wird
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-de");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-de");
        }

        [TestMethod]
        public void Test_DtaRecordFactoryFibuBankIbanOK()
        {
            DtaRecord record = DTARecordFactory.CreateDTARecord(_sozialDienst, _fibuPaymentInformationBankIban, BuchhaltungsTyp.Mandatsbuchhaltung);

            Assert.IsTrue(record is DtaRecord836);
        }

        [TestMethod]
        public void Test_DtaRecordFactoryFibuBankNoIbanOK()
        {
            DtaRecord record = DTARecordFactory.CreateDTARecord(_sozialDienst, _fibuPaymentInformationBankOhneIban, BuchhaltungsTyp.Mandatsbuchhaltung);

            Assert.IsTrue(record is DtaRecord827 || record is DtaRecord826);
        }

        [TestMethod]
        public void Test_DtaRecordFactoryFibuFalsePaymentInformationNOK()
        {
            bool exceptionOccured = false;
            DtaRecord record = null;
            try
            {
                record = DTARecordFactory.CreateDTARecord(_sozialDienst, _klibuPaymentInformationBankIban, BuchhaltungsTyp.Mandatsbuchhaltung);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsNull(record);
                exceptionOccured = true;
            }
            Assert.IsTrue(exceptionOccured);
        }

        [TestMethod]
        public void Test_DtaRecordFactoryKlibuBankzahlungIbanOK()
        {
            DtaRecord record = DTARecordFactory.CreateDTARecord(_sozialDienst, _klibuPaymentInformationBankIban, BuchhaltungsTyp.Klientenbuchhaltung);

            Assert.IsTrue(record is DtaRecord836);
        }

        [TestMethod]
        public void Test_DtaRecordFactoryKlibuNOK()
        {
            bool exceptionOccured = false;
            DtaRecord record = null;
            try
            {
                record = DTARecordFactory.CreateDTARecord(_sozialDienst, _fibuPaymentInformationBankOhneIban, BuchhaltungsTyp.Klientenbuchhaltung);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsNull(record);
                exceptionOccured = true;
            }
            Assert.IsTrue(exceptionOccured);
        }

        [TestMethod]
        public void Test_DtaRecordFactoryKlibuOK()
        {
            DtaRecord record = DTARecordFactory.CreateDTARecord(_sozialDienst, _klibuPaymentInformationBankIban, BuchhaltungsTyp.Klientenbuchhaltung);

            Assert.IsTrue(record is DtaRecord836);
        }

        [TestMethod]
        public void Test_DtaRecordFactoryKlibuRecordLenghtBankIbanOK()
        {
            DtaRecord record = DTARecordFactory.CreateDTARecord(_sozialDienst, _klibuPaymentInformationBankIban, BuchhaltungsTyp.Klientenbuchhaltung);
            DtaOrder order = new DtaOrder(1, "", "", DateTime.Today, "", "");
            order.Add(record);
            File.Delete(@"testDta");
            record.WriteToDTAFile(new FileInfo(@"testDta"));
            string dtaRecordString = File.ReadAllText(@"testDta");
            File.Delete(@"testDta");

            Assert.IsNotNull(dtaRecordString);
            Assert.AreEqual(5 * 128, dtaRecordString.Length);
        }

        [TestMethod]
        public void Test_DtaRecordFactoryKlibuRecordLenghtBankNoIbanOK()
        {
            DtaRecord record = DTARecordFactory.CreateDTARecord(_sozialDienst, _klibuPaymentInformationBankOhneIban, BuchhaltungsTyp.Klientenbuchhaltung);
            DtaOrder order = new DtaOrder(1, "", "", DateTime.Today, "", "");
            order.Add(record);
            File.Delete(@"testDta");
            record.WriteToDTAFile(new FileInfo(@"testDta"));
            string dtaRecordString = File.ReadAllText(@"testDta");
            File.Delete(@"testDta");

            Assert.IsNotNull(dtaRecordString);
            Assert.AreEqual(3 * 128, dtaRecordString.Length);
        }
    }
}