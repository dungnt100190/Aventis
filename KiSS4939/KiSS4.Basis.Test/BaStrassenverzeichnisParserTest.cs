using System;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using KiSS4.Basis.ZH.Strassenverzeichnis;

namespace KiSS4.Basis.Test
{
    /// <summary>
    /// Summary description for BaStrassenverzeichnisParserTest
    /// </summary>
    [TestClass]
    public class BaStrassenverzeichnisParserTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const int ENCODING_CODE = 1252; // Western European

        #endregion

        #endregion

        #region Test Methods

        [TestMethod]
        public void Test_EscapedImport()
        {
            string testFile = string.Join(Environment.NewLine, new[]{"StrassenID;Strassenname;Hausnummer;Zusatz;Kreis;Quartier;Zone;Statistische_Zone;Quartiername;PLZ;Sozialzentrum;Quartierteam",
            "43;Albert-Schneider-Weg;3; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;5; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;\"Albert-Schneider",
            "-Weg\";6; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;7; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;\"Albert-\"\";Schneider;\"\"-Weg\";8; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;9; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;10; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;10;a;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;11; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;12; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;14; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;15; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;17; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;18; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;19; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;20; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;21; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;23; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;25; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "43;Albert-Schneider-Weg;25;a;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "89;Albisriederstrasse;169; ;9;1;8;9108;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "89;Albisriederstrasse;171; ;9;1;8;9108;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "89;Albisriederstrasse;180; ;9;1;7;9107;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "89;\"Albisrieder;strasse\";181; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "89;Albisriederstrasse;182; ;9;1;7;9107;Albisrieden;8047;Albisriederhaus;Albisrieden",
            "89;Albisriederstrasse;182;a;9;1;7;9107;Albisrieden;8047;Albisriederhaus;Albisrieden"});

            System.IO.Stream testStream = new System.IO.MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(testFile));

            BaStrasseHausDTO[] lines = BaStrassenverzeichnisParser.ReadStrassenverzeichnis(testStream);

            Assert.AreEqual(26, lines.Length);
            Assert.AreEqual(89, lines[25].BaStrasseID);
            Assert.AreEqual("Albert-Schneider-Weg", lines[3].StrassenName);
            Assert.AreEqual(19, lines[14].Hausnummer);
            Assert.AreEqual("a", lines[19].Suffix);
            Assert.AreEqual(9, lines[20].Kreis);
            Assert.AreEqual(1, lines[21].Quartier);
            Assert.AreEqual(7, lines[22].Zone);
            Assert.AreEqual(9106, lines[23].StatistischeZone);
            Assert.AreEqual(9107, lines[24].StatistischeZone);
            Assert.AreEqual(8047, lines[25].PLZ);
            Assert.AreEqual("Albisrieden", lines[25].QuartierTeam);

            Assert.AreEqual("Albisrieder;strasse", lines[23].StrassenName);
            Assert.AreEqual("Albert-\";Schneider;\"-Weg", lines[4].StrassenName);
            Assert.AreEqual("Albert-Schneider" + Environment.NewLine + "-Weg", lines[2].StrassenName);
        }

        [TestMethod]
        public void Test_SimpleImport()
        {
            string testFile = @"ID;Strasse;Hausnr;-Zusatz;Kreis;Quartier;Zone;StatZone;Quartiername;PLZ;Sozialzentrum;Quartierteam
            43;Albert-Schneider-Weg;3; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;5; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;6; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;7; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;8; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;9; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;10; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;10;a;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;11; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;12; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;14; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;15; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;17; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;18; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;19; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;20; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;21; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;23; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;25; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            43;Albert-Schneider-Weg;25;a;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            89;Albisriederstrasse;169; ;9;1;8;9108;Albisrieden;8047;Albisriederhaus;Albisrieden
            89;Albisriederstrasse;171; ;9;1;8;9108;Albisrieden;8047;Albisriederhaus;Albisrieden
            89;Albisriederstrasse;180; ;9;1;7;9107;Albisrieden;8047;Albisriederhaus;Albisrieden
            89;Albisriederstrasse;181; ;9;1;6;9106;Albisrieden;8047;Albisriederhaus;Albisrieden
            89;Albisriederstrasse;182; ;9;1;7;9107;Albisrieden;8047;Albisriederhaus;Albisrieden
            89;Albisriederstrasse;182;a;9;1;7;9107;Albisrieden;8047;Albisriederhaus;Albisrieden";
            System.IO.Stream testStream = new System.IO.MemoryStream(Encoding.GetEncoding(ENCODING_CODE).GetBytes(testFile));

            BaStrasseHausDTO[] lines = BaStrassenverzeichnisParser.ReadStrassenverzeichnis(testStream);

            Assert.AreEqual(26, lines.Length);
            Assert.AreEqual(89, lines[25].BaStrasseID);
            Assert.AreEqual("Albert-Schneider-Weg", lines[3].StrassenName);
            Assert.AreEqual(19, lines[14].Hausnummer);
            Assert.AreEqual("a", lines[19].Suffix);
            Assert.AreEqual(9, lines[20].Kreis);
            Assert.AreEqual(1, lines[21].Quartier);
            Assert.AreEqual(7, lines[22].Zone);
            Assert.AreEqual(9106, lines[23].StatistischeZone);
            Assert.AreEqual(9107, lines[24].StatistischeZone);
            Assert.AreEqual(8047, lines[25].PLZ);
            Assert.AreEqual("Albisrieden", lines[25].QuartierTeam);
        }

        #endregion

        #region Other

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion
    }
}