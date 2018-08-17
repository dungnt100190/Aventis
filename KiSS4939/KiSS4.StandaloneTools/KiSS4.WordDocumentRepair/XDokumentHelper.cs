using System.Collections.Generic;

using Kiss.Interfaces.DocumentHandling;

using KiSS4.Dokument;
using KiSS4.Dokument.ExcelAutomation;
using KiSS4.Dokument.WordAutomation;

namespace KiSS4.WordDocumentRepair
{
    public static class XDokumentHelper
    {
        #region Fields

        #region Private Static Fields

        private static ExcelControl excelControl;
        private static WordControl wordControl;

        #endregion

        #endregion

        #region Constructors

        static XDokumentHelper()
        {
            NbrOfEditedDocumentsBeforQuitApp = 10;
        }

        #endregion

        #region Properties

        public static int NbrOfEditedDocumentsBeforQuitApp
        {
            get; set;
        }

        private static int NbrOfEditedDocuments
        {
            get; set;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static List<string> ListMacrosInDocument(int documentID, string fileExtension, out DokFormat? format)
        {
            XDocFileHandler documentHandler = XDocFileHandler.GetFileHandler(documentID, fileExtension, false); //document: false

            return ListMacrosInDocumentOrTemplate(documentHandler, out format);
        }

        public static List<string> ListMacrosInTemplate(int docTemplateID, string fileExtension, out DokFormat? format)
        {
            XDocFileHandler documentHandler = XDocFileHandler.GetFileHandler(docTemplateID, fileExtension, true); //template: true

            return ListMacrosInDocumentOrTemplate(documentHandler, out format);
        }

        public static void QuitApplications()
        {
            if (wordControl != null)
            {
                wordControl.Quit();
                wordControl = null;
            }

            if (excelControl != null)
            {
                excelControl.Quit();
                excelControl = null;
            }
        }

        public static void RepairDocument(int documentID, string fileExtension, out DokFormat? format)
        {
            XDocFileHandler documentHandler = XDocFileHandler.GetFileHandler(documentID, fileExtension, false); //document: false

            RepairDocumentOrTemplate(documentHandler, out format);
        }

        public static void RepairTemplate(int docTemplateID, string fileExtension, out DokFormat? format)
        {
            XDocFileHandler documentHandler = XDocFileHandler.GetFileHandler(docTemplateID, fileExtension, true); //template: true

            RepairDocumentOrTemplate(documentHandler, out format);
        }

        #endregion

        #region Private Static Methods

        private static List<string> ListMacrosInDocumentOrTemplate(XDocFileHandler documentHandler, out DokFormat? format)
        {
            // Write the template to a temp file
            documentHandler.DBToFile(true, false, false);

            format = documentHandler.GetDokFormatCodeFromFileInfo(documentHandler.FileInfo);

            if (!format.HasValue || format.Value != DokFormat.Word)
            {
                return new List<string>(0);
            }

            // Open the document in the background
            documentHandler.OpenDocumentInExternalApplication(true, format.Value, false);
            wordControl = documentHandler.Word;

            var macros = wordControl.GetMacros();

            // Close the document again
            documentHandler.CloseDocument(format.Value);
            documentHandler.DestroyWatcherAndDeleteFileAndUnlock(true, false);

            if (NbrOfEditedDocuments++ >= NbrOfEditedDocumentsBeforQuitApp)
            {
                QuitApplications();
                NbrOfEditedDocuments = 0;
            }

            return macros;
        }

        private static void RepairDocumentOrTemplate(XDocFileHandler documentHandler, out DokFormat? format)
        {
            // Write the template to a temp file
            documentHandler.DBToFile(true, false, false);

            format = documentHandler.GetDokFormatCodeFromFileInfo(documentHandler.FileInfo);

            // Open the document in the background
            documentHandler.OpenDocumentInExternalApplication(true, format.Value, false);
            wordControl = documentHandler.Word;
            excelControl = documentHandler.Excel;

            //force a save operation in Word
            documentHandler.SaveDocumentInExternalApplication(format.Value);

            //Update the Database
            documentHandler.Post();

            // Close the document again
            documentHandler.CloseDocument(format.Value);
            documentHandler.DestroyWatcherAndDeleteFileAndUnlock(true, false);

            if (NbrOfEditedDocuments++ >= NbrOfEditedDocumentsBeforQuitApp)
            {
                QuitApplications();
                NbrOfEditedDocuments = 0;
            }
        }

        #endregion

        #endregion
    }
}