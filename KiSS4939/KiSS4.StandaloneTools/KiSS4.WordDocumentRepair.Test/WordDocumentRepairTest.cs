using Kiss.Interfaces.DocumentHandling;
using KiSS4.DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS4.WordDocumentRepair.Test
{
    [TestClass]
    public class WordDocumentRepairTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const int EXCEL_DOKUMENT_AUTOSTART_MACRO_ID = 147545;
        private const int EXCEL_DOKUMENT_NORMAL_ID = 139028;
        private const int EXCEL_DOKUMENT_PASSWORD_ID = 147546;
        private const int EXCEL_DOKUMENT_XLT_ID = 117104;
        private const int EXCEL_VORLAGE_AUTOSTART_MACRO_ID = 140593;
        private const int EXCEL_VORLAGE_PASSWORD_ID = 140594;
        private const int WORD_DOKUMENT_AUTOSTART_MACRO_ID = 147545;
        private const int WORD_DOKUMENT_DOT_ID = 124392;
        private const int WORD_DOKUMENT_NORMAL_ID = 145484;
        private const int WORD_DOKUMENT_PASSWORD_ID = 166593;
        private const int WORD_VORLAGE_AUTOSTART_MACRO_ID = 140593;
        private const int WORD_VORLAGE_PASSWORD_ID = 140592;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void SetupDb()
        {
            Env env = new Env(".: KiSS_Standard_R4939 :.", EnvType.Dev, "server=sql2014.diartislocal.local\\sql2014;initial catalog=KiSS_Standard_R4939;user id=kiss_tfs;password=kiss2012;");

            // do login with given values
            Session.Open(env, "diag_admin", "Ki$$2013");

            // check if success
            if (!Session.Active)
            {
                // failed, set focus to username
                Assert.IsTrue(false, "Unable to connect to the DB.");
            }

            // Make sure, the DB-Extensions exist
            DBUtil.ExecSQLThrowingException(@"
                IF (NOT EXISTS(SELECT TOP 1 1 FROM sys.tables WHERE name = '_tmp_RepairXDocument'))
                BEGIN
                    CREATE TABLE _tmp_RepairXDocument
                    (
                        DocumentID INT NOT NULL PRIMARY KEY CLUSTERED,
                        Fehler BIT DEFAULT 0,
                        Bemerkung VARCHAR(200)
                    );
                END;

                IF (NOT EXISTS(SELECT TOP 1 1 FROM sys.tables WHERE name = '_tmp_RepairXDocTemplate'))
                BEGIN
                    CREATE TABLE _tmp_RepairXDocTemplate
                    (
                        DocTemplateID INT NOT NULL PRIMARY KEY CLUSTERED,
                        Fehler BIT DEFAULT 0,
                        Bemerkung VARCHAR(200)
                    );
                END;");
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T01_Word_Dokument_Normal()
        {
            DokFormat? dokFormat;
            XDokumentHelper.RepairDocument(WORD_DOKUMENT_NORMAL_ID, ".doc", out dokFormat);

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T02_Excel_Dokument_Normal()
        {
            DokFormat? dokFormat;
            XDokumentHelper.RepairDocument(EXCEL_DOKUMENT_NORMAL_ID, ".xls", out dokFormat);

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T03_Word_Dokument_DOT()
        {
            DokFormat? dokFormat;
            XDokumentHelper.RepairDocument(WORD_DOKUMENT_DOT_ID, ".dot", out dokFormat);

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T04_Excel_Dokument_XLT()
        {
            DokFormat? dokFormat;
            XDokumentHelper.RepairDocument(EXCEL_DOKUMENT_XLT_ID, ".xlt", out dokFormat);

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T05_StressTest_Word_Dokument_Normal()
        {
            DokFormat? dokFormat;
            for (int i = 0; i < XDokumentHelper.NbrOfEditedDocumentsBeforQuitApp + 1; i++)
            {
                XDokumentHelper.RepairDocument(WORD_DOKUMENT_NORMAL_ID, ".doc", out dokFormat);
            }

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T06_StressTest_Excel_Dokument_Normal()
        {
            DokFormat? dokFormat;
            for (int i = 0; i < XDokumentHelper.NbrOfEditedDocumentsBeforQuitApp + 1; i++)
            {
                XDokumentHelper.RepairDocument(EXCEL_DOKUMENT_NORMAL_ID, ".xls", out dokFormat);
            }

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T07_StressTest_Word_Dokument_DOT()
        {
            DokFormat? dokFormat;
            for (int i = 0; i < XDokumentHelper.NbrOfEditedDocumentsBeforQuitApp + 1; i++)
            {
                XDokumentHelper.RepairDocument(WORD_DOKUMENT_DOT_ID, ".dot", out dokFormat);
            }

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T08_StressTest_Excel_Dokument_XLT()
        {
            DokFormat? dokFormat;
            for (int i = 0; i < XDokumentHelper.NbrOfEditedDocumentsBeforQuitApp + 1; i++)
            {
                XDokumentHelper.RepairDocument(EXCEL_DOKUMENT_XLT_ID, ".xlt", out dokFormat);
            }

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T09_PasswordProtected_Vorlage_Word()
        {
            DokFormat? dokFormat;
            XDokumentHelper.RepairTemplate(WORD_VORLAGE_PASSWORD_ID, ".dot", out dokFormat);

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T10_PasswordProtected_Dokument_Word()
        {
            DokFormat? dokFormat;
            XDokumentHelper.RepairDocument(WORD_DOKUMENT_PASSWORD_ID, ".doc", out dokFormat);

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T11_PasswordProtected_Vorlage_Excel()
        {
            DokFormat? dokFormat;
            XDokumentHelper.RepairTemplate(EXCEL_VORLAGE_PASSWORD_ID, ".xlt", out dokFormat);

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T12_PasswordProtected_Dokument_Excel()
        {
            DokFormat? dokFormat;
            XDokumentHelper.RepairDocument(EXCEL_DOKUMENT_PASSWORD_ID, ".xls", out dokFormat);

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T13_AutostartMacro_Vorlage_Word()
        {
            DokFormat? dokFormat;
            XDokumentHelper.RepairTemplate(WORD_VORLAGE_AUTOSTART_MACRO_ID, ".dot", out dokFormat);

            XDokumentHelper.QuitApplications();
        }

        [TestMethod]
        [TestCategory("Word")]
        public void T14_AutostartMacro_Dokument_Word()
        {
            DokFormat? dokFormat;
            XDokumentHelper.RepairDocument(WORD_DOKUMENT_AUTOSTART_MACRO_ID, ".doc", out dokFormat);

            XDokumentHelper.QuitApplications();
        }

        [TestCleanup]
        public void TearDown()
        {
        }

        #endregion
    }
}