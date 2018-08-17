using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using KiSS.KliBu.BL.DTO;

namespace KiSS.KliBu.BL.Test.UnitTest
{
    [TestClass]
    public class BankTest
    {
        #region Test Methods

        [TestMethod,
        Description("Test every Bank property")]
        public void Test_GetPropertyTest()
        {
            Bank bank = new Bank("Schweizerische Nationalbank", "100", 0000, new DateTime(2006, 03, 24));
            bank.Gruppe = 1;
            bank.ClearingNrNeu = null;
            bank.SicNr = 001008;
            bank.HauptsitzBCL = "100";
            bank.BcArt = 1;
            bank.TeilnahmecodeCHF = 1;
            bank.TeilnahmecodeEuro = 3;
            bank.Sprachcode = 1;
            bank.Kurzbezeichnung = "SNB";
            bank.Strasse = "Börsenstrasse 15";
            bank.Postadresse = "Postfach 2800";
            bank.PLZ = "8022";
            bank.Ort = "Zürich";
            bank.Telefon = "044 631 31 11";
            bank.Fax = "";
            bank.LandesVorwahl = "";
            bank.Landcode = "";
            bank.PCKontoNr = "30-5-5";
            bank.SwiftAdresse = "SNBZCHZZXXX";
            Assert.AreEqual(1, bank.Gruppe, "Group");
            Assert.AreEqual("100", bank.ClearingNr, "BC No");
            Assert.AreEqual(0, bank.FilialeNr, "Branch ID");
            Assert.IsNull(bank.ClearingNrNeu, "BcNoNew");
            Assert.AreEqual(001008, bank.SicNr, "SicNo");
            Assert.AreEqual("100", bank.HauptsitzBCL, "Headquarter");
            Assert.AreEqual(1, bank.BcArt, "BcType");
            Assert.AreEqual(new DateTime(2006, 03, 24), bank.GueltigAb, "ValidFrom");
            Assert.AreEqual(1, bank.TeilnahmecodeCHF, "Sic");
            Assert.AreEqual(3, bank.TeilnahmecodeEuro, "SicEuro");
            Assert.AreEqual(1, bank.Sprachcode, "Language");
            Assert.AreEqual("SNB", bank.Kurzbezeichnung, "ShortName");
            Assert.AreEqual("Schweizerische Nationalbank", bank.Name, "BankInstitution");
            Assert.AreEqual("Börsenstrasse 15", bank.Strasse, "Address");
            Assert.AreEqual("Postfach 2800", bank.Postadresse, "PostalAddress");
            Assert.AreEqual("8022", bank.PLZ, "ZipCode");
            Assert.AreEqual("Zürich", bank.Ort, "Place");
            Assert.AreEqual("044 631 31 11", bank.Telefon, "Phone");
            Assert.AreEqual("", bank.Fax, "Fax");
            Assert.AreEqual("", bank.LandesVorwahl, "DialingCode");
            Assert.AreEqual("", bank.Landcode, "CountryCode");
            Assert.AreEqual("30-5-5", bank.PCKontoNr, "Account");
            Assert.AreEqual("SNBZCHZZXXX", bank.SwiftAdresse, "Swift");
        }

        #endregion
    }
}