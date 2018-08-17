using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XmlConfiguration;
using KiSS4.Common;
using KiSS4.Schnittstellen.DTA_EZAG;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS4.Schnittstellen.Test
{
    [TestClass]
    public class Iso20022RecordTests
    {
        public Iso20022RecordTests()
        {
            // sicherstellen, dass auch mit anderen Zahlenformaten ein korrektes Resultat erzielt wird
        }

        [TestMethod]
        public void Test_Create_1_ESR_Zahlung_Klibu()
        {
            DateTime valutaDatum = DateTime.Today.AddDays(1);

            var sozialDienst = new SozialDienst("SozialdienstName_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstAdresse_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstPLZ_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstOrt_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ");
            var paymentInformation = new Iso20022PaymentInformation(Einzahlungsschein.OrangerEinzahlungsschein, "CH22 0023 5235 6991 3540 B", "235", "UBS AG_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", 100.35m, "BeguenstigterName_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BeguenstigterStrasse_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BegHausNr_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BegPLZ_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BeguenstigterOrt_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile1_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile2_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile3_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile4_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "80-2-2", "699135.40B", 12345, "1111111111111111", "CH44 3199 9123 0008 8901 2", valutaDatum);

            var order = new Iso20022Order(
                "_",
                "1",
                valutaDatum);

            var record = Iso20022RecordFactory.CreateTransferTransactionRecord(sozialDienst, paymentInformation, BuchhaltungsTyp.Klientenbuchhaltung);

            var paymentInstruction = order.GetOrCreatePaymentInstruction("CH44 3199 9123 0008 8901 2", "319");

            order.Add(paymentInstruction, record);

            FileInfo file = new FileInfo(Path.GetTempFileName());
            order.GenerateFile(file);

            //XSD-Validate
            AssertIsValidXml(file);
        }

        [TestMethod]
        public void Test_Create_2_1_ES_1_stufig()
        {
            DateTime valutaDatum = DateTime.Today.AddDays(1);

            var sozialDienst = new SozialDienst("SozialdienstName_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstAdresse_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstPLZ_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstOrt_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ");
            var paymentInformation = new Iso20022PaymentInformation(Einzahlungsschein.RoterEinzahlungsscheinPost, "CH22 0023 5235 6991 3540 B", "235", "UBS AG_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", 100.35m, "BeguenstigterName_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BeguenstigterStrasse_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BegHausNr_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BegPLZ_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BeguenstigterOrt_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile1_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile2_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile3_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile4_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "80-2-2", "699135.40B", 12345, "1111111111111111", "CH44 3199 9123 0008 8901 2", valutaDatum);

            var order = new Iso20022Order(
                "_",
                "1",
                valutaDatum);

            var record = Iso20022RecordFactory.CreateTransferTransactionRecord(sozialDienst, paymentInformation, BuchhaltungsTyp.Klientenbuchhaltung);

            var paymentInstruction = order.GetOrCreatePaymentInstruction("CH44 3199 9123 0008 8901 2", "319");

            order.Add(paymentInstruction, record);

            FileInfo file = new FileInfo(Path.GetTempFileName());
            order.GenerateFile(file);

            //XSD-Validate
            AssertIsValidXml(file);
        }

        [TestMethod]
        public void Test_Create_2_2_ES_2_stufig()
        {
            DateTime valutaDatum = DateTime.Today.AddDays(1);

            var sozialDienst = new SozialDienst("SozialdienstName_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstAdresse_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstPLZ_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstOrt_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ");
            var paymentInformation = new Iso20022PaymentInformation(Einzahlungsschein.RoterEinzahlungsscheinPost, "CH22 0023 5235 6991 3540 B", "235", "UBS AG_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", 100.35m, "BeguenstigterName_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BeguenstigterStrasse_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BegHausNr_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BegPLZ_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BeguenstigterOrt_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile1_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile2_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile3_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile4_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "80-2-2", "699135.40B", 12345, "1111111111111111", "CH44 3199 9123 0008 8901 2", valutaDatum);

            var order = new Iso20022Order(
                "_",
                "1",
                valutaDatum);

            var record = Iso20022RecordFactory.CreateTransferTransactionRecord(sozialDienst, paymentInformation, BuchhaltungsTyp.Klientenbuchhaltung);

            var paymentInstruction = order.GetOrCreatePaymentInstruction("CH44 3199 9123 0008 8901 2", "319");

            order.Add(paymentInstruction, record);

            FileInfo file = new FileInfo(Path.GetTempFileName());
            order.GenerateFile(file);

            //XSD-Validate
            AssertIsValidXml(file);
        }

        [TestMethod]
        public void Test_Create_3_Bankzahlung_Schweiz()
        {
            DateTime valutaDatum = DateTime.Today.AddDays(1);

            var sozialDienst = new SozialDienst("SozialdienstName_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstAdresse_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstPLZ_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstOrt_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ");
            var paymentInformation = new Iso20022PaymentInformation(Einzahlungsschein.RoterEinzahlungsscheinPost, "CH22 0023 5235 6991 3540 B", "235", "UBS AG_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", 100.35m, "BeguenstigterName_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BeguenstigterStrasse_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BegHausNr_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BegPLZ_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BeguenstigterOrt_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile1_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile2_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile3_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile4_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "80-2-2", "699135.40B", 12345, "1111111111111111", "CH44 3199 9123 0008 8901 2", valutaDatum);

            var order = new Iso20022Order(
                "_",
                "1",
                valutaDatum);

            var record = Iso20022RecordFactory.CreateTransferTransactionRecord(sozialDienst, paymentInformation, BuchhaltungsTyp.Klientenbuchhaltung);

            var paymentInstruction = order.GetOrCreatePaymentInstruction("CH44 3199 9123 0008 8901 2", "319");

            order.Add(paymentInstruction, record);

            FileInfo file = new FileInfo(Path.GetTempFileName());
            order.GenerateFile(file);

            //XSD-Validate
            AssertIsValidXml(file);
        }

        [TestMethod]
        public void Test_Create_6_Ausland()
        {
            DateTime valutaDatum = DateTime.Today.AddDays(1);

            var sozialDienst = new SozialDienst("SozialdienstName_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstAdresse_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstPLZ_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "SozialdienstOrt_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ");
            var paymentInformation = new Iso20022PaymentInformation(Einzahlungsschein.RoterEinzahlungsscheinPost, "CH22 0023 5235 6991 3540 B", "235", "UBS AG_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", 100.35m, "BeguenstigterName_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BeguenstigterStrasse_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BegHausNr_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BegPLZ_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "BeguenstigterOrt_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile1_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile2_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile3_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "MitteilungZeile4_ẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃ", "80-2-2", "699135.40B", 12345, "1111111111111111", "CH44 3199 9123 0008 8901 2", valutaDatum);

            var order = new Iso20022Order(
                "_",
                "1",
                valutaDatum);

            var record = Iso20022RecordFactory.CreateTransferTransactionRecord(sozialDienst, paymentInformation, BuchhaltungsTyp.Klientenbuchhaltung);

            var paymentInstruction = order.GetOrCreatePaymentInstruction("CH44 3199 9123 0008 8901 2", "319");

            order.Add(paymentInstruction, record);

            FileInfo file = new FileInfo(Path.GetTempFileName());
            order.GenerateFile(file);

            //XSD-Validate
            AssertIsValidXml(file);
        }

        [TestMethod]
        public void Test_EnsureLatinCharacterSet()
        {
            string stringWithInvalidCharacters = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z/A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z/0,1,2,3,4,5,6,7,8,9/.,:'+-/()? /!\"#%&*<>÷=@_$£[]{}\\`´~/àáâäçéèêëìíîïñòóôöùúûüýß/ÀÁÂÄÇÈÉÊËÌÍÎÏÒÓÔÖÙÚÛÜÑ/«ABC»/ãåõøÃÅÕØ/¢¤¥¦§¨©ª¬®°±²³¶¹¼½¾¿";
            string stringExpectedCharacters = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z/A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z/0,1,2,3,4,5,6,7,8,9/.,:'+-/()? /!\"#%&*<>÷=@_$£[]{}\\`´~/àáâäçéèêëìíîïñòóôöùúûüýß/ÀÁÂÄÇÈÉÊËÌÍÎÏÒÓÔÖÙÚÛÜÑ/ABC//";

            string corrected = Utilities.EnsureLatinCharacterSet(stringWithInvalidCharacters);

            Assert.IsNotNull(corrected);

            Assert.AreEqual(stringExpectedCharacters, corrected);
        }

        [TestMethod]
        public void Test_EnsureSWIFTCharacterSet_RemoveInvalidPunctuation()
        {
            string stringWithInvalidCharacters = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z/A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z/0,1,2,3,4,5,6,7,8,9/.,:'+-/()? /<abc>/«ABC»/[DEF]/{GHI}/äöüÄÖÜ/àáâãåéèêëñòóôõøùúûÀÁÂÃÅÉÈÊËÌÍÎÏÑÒÓÔÕØÙÚÛ/\"*Çç%\\=$£/ČčĎďĚěŇňŘřŠšŤťŮůŽžŒœËëẼẽĨĩŨũỸỹG̃g̃ŐőŰűḂḃĊċḊḋḞḟĠġṀṁṠṡṪṫĀāĒēĪīŌōŪūĂăȘșȚțŢţĞğŞşẀẁẂẃŴŵŶŷ/¢£¤¥¦§¨©ª¬®°±²³´¶¹¼½¾¿";
            string stringExpectedCharacters = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z/A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z/0,1,2,3,4,5,6,7,8,9/.,:'+-/()? /abc/ABC/DEF/GHI/aeoeueAEOEUE/aaaaaeeeenoooouuuAAAAAEEEEIIIINOOOOUUU/Cc/CcDdEeNnRrSsTtUuZzEeEeIiUuYyGgOoUuBbCcDdFfGgMmSsTtAaEeIiOoUuAaSsTtTtGgSsWwWwWwYy/";

            string corrected = Utilities.EnsureSWIFTCharacterSet(stringWithInvalidCharacters);

            Assert.IsNotNull(corrected);

            Assert.AreEqual(stringExpectedCharacters, corrected);
        }

        private void AssertIsValidXml(FileInfo file)
        {
            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema | XmlSchemaValidationFlags.ProcessSchemaLocation | XmlSchemaValidationFlags.ReportValidationWarnings,
            };
            settings.Schemas.Add("http://www.six-interbank-clearing.com/de/pain.001.001.03.ch.02.xsd",
                @"pain.001.001.03.ch.02.xsd");
            settings.ValidationEventHandler += (sender, args) =>
            {
                Assert.Fail($@"Validierung fehlgeschlagen!
Meldung: {args.Message}
Exception: {args.Exception}");
            };

            XmlReader reader = XmlReader.Create(file.Open(FileMode.Open), settings);
            while (reader.Read()) ;
        }
    }
}