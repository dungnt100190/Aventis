using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using KiSS.KliBu.BL.DTO;
using KiSS.KliBu.BL.Parser;

namespace KiSS.KliBu.BL.Test.UnitTest
{
    [TestClass]
    public class BankParserTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const int ENCODING_CODE = 1252; // Western European

        #endregion

        #endregion

        #region Test Methods

        [TestMethod,
        Description("Get the bank list after parsing"),
        TestCategory("Local")]
        public void Test_GetBankList()
        {
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes("01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
        }

        [TestMethod,
        Description("Parse another correct bank record"),
        TestCategory("Local")]
        public void Test_ParseAnotherCorrectRecord()
        {
            // Parse another correct bank record
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes("08193  0000193  001933193  120020829031SECB           SECB Swiss Euro Clearing Bank                               Solmsstrasse 18                                                       60486     Frankfurt am Main                  69 97 98 98 0     69 97 98 98 98    ++49 DE            SECGDEFFXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(1, bankList.Count, "Has 1 bank");

            Bank bank = bankList[0];
            Assert.AreEqual(8, bank.Gruppe, "Group");
            Assert.AreEqual("193", bank.ClearingNr, "BC No");
            Assert.AreEqual(0, bank.FilialeNr, "Branch ID");
            Assert.AreEqual("193", bank.ClearingNrNeu, "BcNoNew");
            Assert.AreEqual(001933, bank.SicNr, "SicNo");
            Assert.AreEqual("193", bank.HauptsitzBCL, "Headquarter");
            Assert.AreEqual(1, bank.BcArt, "BcType");
            Assert.AreEqual(new DateTime(2002, 08, 29), bank.GueltigAb, "ValidFrom");
            Assert.AreEqual(0, bank.TeilnahmecodeCHF, "Sic");
            Assert.AreEqual(3, bank.TeilnahmecodeEuro, "SicEuro");
            Assert.AreEqual(1, bank.Sprachcode, "Language");
            Assert.AreEqual("SECB", bank.Kurzbezeichnung, "ShortName");
            Assert.AreEqual("SECB Swiss Euro Clearing Bank", bank.Name, "BankInsitution");
            Assert.AreEqual("Solmsstrasse 18", bank.Strasse, "Address");
            Assert.AreEqual("", bank.Postadresse, "PostalAddress");
            Assert.AreEqual("60486", bank.PLZ, "ZipCode");
            Assert.AreEqual("Frankfurt am Main", bank.Ort, "Place");
            Assert.AreEqual("69 97 98 98 0", bank.Telefon, "Phone");
            Assert.AreEqual("69 97 98 98 98", bank.Fax, "Fax");
            Assert.AreEqual("++49", bank.LandesVorwahl, "DialingCode");
            Assert.AreEqual("DE", bank.Landcode, "CountryCode");
            Assert.AreEqual("", bank.PCKontoNr, "Account");
            Assert.AreEqual("SECGDEFFXXX", bank.SwiftAdresse, "Swift");
        }

        [TestMethod,
        Description("Parse a correct length bank record but incorrect data, no bank in the list"),
        TestCategory("Local")]
        public void Test_ParseAnotherIncorrectDataRecord()
        {
            // Parse a correct length bank record but incorrect data, no bank in the list
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes("01100  0000     001008100  120063024131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(0, bankList.Count, "Has 0 bank");
        }

        [TestMethod,
        Description("Parse a correct bank record"),
        TestCategory("Local")]
        public void Test_ParseCorrectRecord()
        {
            // Parse a correct bank record
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes("01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(1, bankList.Count, "Has 1 bank");

            Bank bank = bankList[0];
            Assert.AreEqual(1, bank.Gruppe, "Group");
            Assert.AreEqual("100", bank.ClearingNr, "BC No");
            Assert.AreEqual(0, bank.FilialeNr, "Branch ID");
            Assert.AreEqual(null, bank.ClearingNrNeu, "BcNoNew");
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
            Assert.AreEqual("CH", bank.Landcode, "CountryCode");
            Assert.AreEqual("30-5-5", bank.PCKontoNr, "Account");
            Assert.AreEqual("SNBZCHZZXXX", bank.SwiftAdresse, "Swift");
        }

        [TestMethod,
        Description("Parse an empty bank record"),
        TestCategory("Local")]
        public void Test_ParseEmptyRecord()
        {
            // Parse an empty bank record
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(""));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(0, bankList.Count, "Has 0 bank");
        }

        [TestMethod,
        Description("Parse a bank record that doesn't contains all datas"),
        TestCategory("Local")]
        public void Test_ParseIncompletRecord()
        {
            // Parse a bank record that doesn't contains all datas
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes("1"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(0, bankList.Count, "Has 0 bank");
        }

        [TestMethod,
        Description("Parse a correct length bank record but incorrect data, no bank in the list"),
        TestCategory("Local")]
        public void Test_ParseIncorrectDataRecord()
        {
            // Parse a correct length bank record but incorrect data, no bank in the list
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes("AA100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(0, bankList.Count, "Has 0 bank");
        }

        [TestMethod,
        Description("Parse a too long bank record"),
        TestCategory("Local")]
        public void Test_ParseRecordTooLong()
        {
            // Parse a too long bank record
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes("01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   tooLong\r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(0, bankList.Count, "Has 0 bank");
        }

        [TestMethod,
        Description("Parse bank record length is too long, and starts with incorrect data, no bank in the list"),
        TestCategory("Local")]
        public void Test_ParseRecordTooLongAndIncorrect()
        {
            // Parse bank record length is too long, and starts with incorrect data, no bank in the list
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(
                "aaaaaaaa01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(0, bankList.Count, "Has 0 bank");
        }

        [TestMethod,
        Description("Parse a too long bank record without '\r\n'"),
        TestCategory("Local")]
        public void Test_ParseRecordTooLongWithoutEndLine()
        {
            // Parse a too long bank record without '\r\n'
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes("01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   fartooLong"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(0, bankList.Count, "Has 0 bank");
        }

        [TestMethod,
        Description("Parse a correct length bank record without group number, no bank in the list"),
        TestCategory("Local")]
        public void Test_ParseRecordWithoutGroup()
        {
            // Parse a correct length bank record but incorrect data, no bank in the list
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes("  100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(0, bankList.Count, "Has 0 bank");
        }

        [TestMethod,
        Description("Parse 3 bank record where the second one is too short, add only the first and the third one in the list"),
        TestCategory("Local")]
        public void Test_ParseThreeRecordSecondTooShort()
        {
            // Parse 3 bank record where the second one is too short, add only the first and the third one in the list
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(
                "08193  0000     001933193  120020829031SECB           SECB Swiss Euro Clearing Bank                               Solmsstrasse 18                                                       60486     Frankfurt am Main                  69 97 98 98 0     69 97 98 98 98    ++49 DE            SECGDEFFXXX   \r\n" +
                "aaaaaaaaaaaaaa\r\n" +
                "01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(2, bankList.Count, "Has 2 bank");

            Bank bank = bankList[0];
            Assert.AreEqual(8, bank.Gruppe, "Group");
            Assert.AreEqual("193", bank.ClearingNr, "BC No");
            Assert.AreEqual(0, bank.FilialeNr, "Branch ID");
            Assert.AreEqual(null, bank.ClearingNrNeu, "BcNoNew");
            Assert.AreEqual(001933, bank.SicNr, "SicNo");
            Assert.AreEqual("193", bank.HauptsitzBCL, "Headquarter");
            Assert.AreEqual(1, bank.BcArt, "BcType");
            Assert.AreEqual(new DateTime(2002, 08, 29), bank.GueltigAb, "ValidFrom");
            Assert.AreEqual(0, bank.TeilnahmecodeCHF, "Sic");
            Assert.AreEqual(3, bank.TeilnahmecodeEuro, "SicEuro");
            Assert.AreEqual(1, bank.Sprachcode, "Language");
            Assert.AreEqual("SECB", bank.Kurzbezeichnung, "ShortName");
            Assert.AreEqual("SECB Swiss Euro Clearing Bank", bank.Name, "BankInsitution");
            Assert.AreEqual("Solmsstrasse 18", bank.Strasse, "Address");
            Assert.AreEqual("", bank.Postadresse, "PostalAddress");
            Assert.AreEqual("60486", bank.PLZ, "ZipCode");
            Assert.AreEqual("Frankfurt am Main", bank.Ort, "Place");
            Assert.AreEqual("69 97 98 98 0", bank.Telefon, "Phone");
            Assert.AreEqual("69 97 98 98 98", bank.Fax, "Fax");
            Assert.AreEqual("++49", bank.LandesVorwahl, "DialingCode");
            Assert.AreEqual("DE", bank.Landcode, "CountryCode");
            Assert.AreEqual("", bank.PCKontoNr, "Account");
            Assert.AreEqual("SECGDEFFXXX", bank.SwiftAdresse, "Swift");

            bank = bankList[1];
            Assert.AreEqual(1, bank.Gruppe, "Group");
            Assert.AreEqual("100", bank.ClearingNr, "BC No");
            Assert.AreEqual(0, bank.FilialeNr, "Branch ID");
            Assert.AreEqual(null, bank.ClearingNrNeu, "BcNoNew");
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
            Assert.AreEqual("CH", bank.Landcode, "CountryCode");
            Assert.AreEqual("30-5-5", bank.PCKontoNr, "Account");
            Assert.AreEqual("SNBZCHZZXXX", bank.SwiftAdresse, "Swift");
        }

        [TestMethod,
        Description("Parse 3 bank records where the two first one aren't correct, only the third bank is in the list"),
        TestCategory("Local")]
        public void Test_ParseThreeRecordTwoFirstIncorrect()
        {
            // Parse 3 bank records where the two first one aren't correct, only the third bank is in the list
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\r\n" +
                "bbbbbbbbbbbb\r\n" +
                "01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(1, bankList.Count, "Has 1 bank");

            Bank bank = bankList[0];
            Assert.AreEqual(1, bank.Gruppe, "Group");
            Assert.AreEqual("100", bank.ClearingNr, "BC No");
            Assert.AreEqual(0, bank.FilialeNr, "Branch ID");
            Assert.AreEqual(null, bank.ClearingNrNeu, "BcNoNew");
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
            Assert.AreEqual("CH", bank.Landcode, "CountryCode");
            Assert.AreEqual("30-5-5", bank.PCKontoNr, "Account");
            Assert.AreEqual("SNBZCHZZXXX", bank.SwiftAdresse, "Swift");
        }

        [TestMethod,
        Description("Parse 3 bank records where the two first one aren't correct, only the third bank is in the list"),
        TestCategory("Local")]
        public void Test_ParseThreeRecordTwoFirstIncorrectAndTooShort()
        {
            // Parse 3 bank records where the two first one aren't correct, only the third bank is in the list
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(
                "aaaaaaaaaaaaaa\r\n" +
                "bbbbbbbbbbbb\r\n" +
                "01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(1, bankList.Count, "Has 1 bank");

            Bank bank = bankList[0];
            Assert.AreEqual(1, bank.Gruppe, "Group");
            Assert.AreEqual("100", bank.ClearingNr, "BC No");
            Assert.AreEqual(0, bank.FilialeNr, "Branch ID");
            Assert.AreEqual(null, bank.ClearingNrNeu, "BcNoNew");
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
            Assert.AreEqual("CH", bank.Landcode, "CountryCode");
            Assert.AreEqual("30-5-5", bank.PCKontoNr, "Account");
            Assert.AreEqual("SNBZCHZZXXX", bank.SwiftAdresse, "Swift");
        }

        [TestMethod,
        Description("Parse 2 correct bank record"),
        TestCategory("Local")]
        public void Test_ParseTwoCorrectRecord()
        {
            // Parse 2 correct bank record
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(
                "08193  0000     001933193  120020829031SECB           SECB Swiss Euro Clearing Bank                               Solmsstrasse 18                                                       60486     Frankfurt am Main                  69 97 98 98 0     69 97 98 98 98    ++49 DE            SECGDEFFXXX   \r\n" +
                "01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(2, bankList.Count, "Has 2 bank");
        }

        [TestMethod,
        Description("Parse 2 bank records where the first one isn't correct, only the second bank is in the list"),
        TestCategory("Local")]
        public void Test_ParseTwoRecordFirstIncorrectAndTooShort()
        {
            // Parse 2 bank records where the first one isn't correct, only the second bank is in the list
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(
                "aaaaaaaaaaaaaa\r\n" +
                "01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(1, bankList.Count, "Has 1 bank");

            Bank bank = bankList[0];
            Assert.AreEqual(1, bank.Gruppe, "Group");
            Assert.AreEqual("100", bank.ClearingNr, "BC No");
            Assert.AreEqual(0, bank.FilialeNr, "Branch ID");
            Assert.AreEqual(null, bank.ClearingNrNeu, "BcNoNew");
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
            Assert.AreEqual("CH", bank.Landcode, "CountryCode");
            Assert.AreEqual("30-5-5", bank.PCKontoNr, "Account");
            Assert.AreEqual("SNBZCHZZXXX", bank.SwiftAdresse, "Swift");
        }

        [TestMethod,
        Description("Parse a too long bank record and a second correct one. Only the seccond has to be in the list"),
        TestCategory("Local")]
        public void Test_ParseTwoRecordFirstTooLong()
        {
            // Parse a too long bank record and a second correct one
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(
                "01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   tooLong\r\n" +
                "08193  0000     001933193  120020829031SECB           SECB Swiss Euro Clearing Bank                               Solmsstrasse 18                                                       60486     Frankfurt am Main                  69 97 98 98 0     69 97 98 98 98    ++49 DE            SECGDEFFXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(1, bankList.Count, "Has 1 bank");
        }

        [TestMethod,
        Description("Parse a too long bank record and a second correct one without '\r\n'"),
        TestCategory("Local")]
        public void Test_ParseTwoRecordFirstTooLongSecondCorrectWithoutEndLine()
        {
            // Parse a too long bank record and a second correct one without '\r\n'
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(
                "01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   tooLong\r\n" +
                "08193  0000     001933193  120020829031SECB           SECB Swiss Euro Clearing Bank                               Solmsstrasse 18                                                       60486     Frankfurt am Main                  69 97 98 98 0     69 97 98 98 98    ++49 DE            SECGDEFFXXX   \r\n"));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(1, bankList.Count, "Has 1 bank");
        }

        [TestMethod,
        Description("Parse a too long bank records, and a second correct one without \r\n."),
        TestCategory("Local")]
        public void Test_ParseTwoRecordFirstTooLongSecondWithoutEndLine()
        {
            // Parse a too long bank records
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(
                "01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   fartooLong\r\n" +
                "08193  0000     001933193  120020829031SECB           SECB Swiss Euro Clearing Bank                               Solmsstrasse 18                                                       60486     Frankfurt am Main                  69 97 98 98 0     69 97 98 98 98    ++49 DE            SECGDEFFXXX   "));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(0, bankList.Count, "Has 0 bank");
        }

        [TestMethod,
        Description("Parse 2 correct bank record where the last record doesn't end with '\r\n', the 2 banks have to be in the list"),
        TestCategory("Local")]
        public void Test_ParseTwoRecordLastWithoutEndLine()
        {
            // Parse 2 correct bank record where the last record doesn't end with '\r\n', the 2 banks have to be in the list
            Stream stream = new MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(
                "08193  0000     001933193  120020829031SECB           SECB Swiss Euro Clearing Bank                               Solmsstrasse 18                                                       60486     Frankfurt am Main                  69 97 98 98 0     69 97 98 98 98    ++49 DE            SECGDEFFXXX   \r\n" +
                "01100  0000     001008100  120060324131SNB            Schweizerische Nationalbank                                 Börsenstrasse 15                   Postfach 2800                      8022      Zürich                             044 631 31 11                              30-5-5      SNBZCHZZXXX   "));
            BankParser bankParser = new BankParser(stream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();
            Assert.IsNotNull(bankList, "bank list is not null");
            Assert.AreEqual(2, bankList.Count, "Has 2 bank");
        }

        #endregion
    }
}