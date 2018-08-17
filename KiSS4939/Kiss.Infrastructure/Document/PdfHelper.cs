using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Kiss.Interfaces.BL;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Kiss.Infrastructure.Document
{
    public class PdfHelper
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static MergedPdfDocument MergeDocuments(IEnumerable<PdfFileInfo> documentsToMerge, string outputDocumentPath = null)
        {
            var mergedDocument = new MergedPdfDocument { SuccessedInputDocuments = new List<FileInfo>(), ErrorInputDocuments = new List<FileInfo>() };
            var outputDocument = new PdfDocument();

            foreach (var pdfPrintInfo in documentsToMerge)
            {
                var fileInfo = pdfPrintInfo.FileInfo;

                try
                {
                    // Open the document to import pages from it.
                    PdfDocument inputDocument;

                    try
                    {
                        inputDocument = PdfReader.Open(fileInfo.FullName, PdfDocumentOpenMode.Import);
                    }
                    catch (PdfReaderException)
                    {
                        // HACK workaround if pdfsharp doesn't support this pdf
                        // http://forum.pdfsharp.net/viewtopic.php?f=2&t=693#p5855
                        // https://pdfsharp.codeplex.com/workitem/8466
                        var outputStream = new MemoryStream();
                        var reader = new iTextSharp.text.pdf.PdfReader(fileInfo.FullName);
                        var pdfStamper = new iTextSharp.text.pdf.PdfStamper(reader, outputStream);
                        pdfStamper.FormFlattening = true;
                        pdfStamper.Writer.SetPdfVersion(iTextSharp.text.pdf.PdfWriter.PDF_VERSION_1_4);
                        pdfStamper.Writer.CloseStream = false;
                        pdfStamper.Close();

                        inputDocument = PdfReader.Open(outputStream, PdfDocumentOpenMode.Import);
                    }

                    // Only remove the first page if it has more than one page
                    var first = inputDocument.Pages.Count > 1;

                    // Add the pages to the output document
                    foreach (PdfPage page in inputDocument.Pages)
                    {
                        if (!pdfPrintInfo.IncludeFirstPage && first)
                        {
                            first = false;
                            continue;
                        }

                        outputDocument.AddPage(page);
                    }

                    // add the input document to the successfuly added documents
                    mergedDocument.SuccessedInputDocuments.Add(fileInfo);
                    _logger.DebugFormat("Successfully merged document: {0}", fileInfo.FullName);
                }
                catch (Exception ex)
                {
                    var message = string.Format("Fehler beim Zusammensetzen der PDF-Datei '{0}': {1}", fileInfo.FullName, ex.Message);
                    mergedDocument.MergeResult.Add(new KissServiceResult(ServiceResultType.Error, message));
                    mergedDocument.ErrorInputDocuments.Add(fileInfo);
                    _logger.Error(string.Format("error while merging document: {0}", fileInfo.FullName), ex);
                }
            }

            // save the new document to the MergedDocument property
            var saveErrorMessage = string.Empty;
            if (outputDocument.CanSave(ref saveErrorMessage) && outputDocument.PageCount > 0)
            {
                var outputStream = new MemoryStream();
                outputDocument.Save(outputStream);
                mergedDocument.MergedDocument = outputStream.ToArray();
                if (!string.IsNullOrEmpty(outputDocumentPath))
                {
                    var fileStream = File.Create(outputDocumentPath);
                    fileStream.Write(mergedDocument.MergedDocument, 0, mergedDocument.MergedDocument.Length);
                    fileStream.Close();
                }

                _logger.InfoFormat("Successfully merged documents in: {0}", outputDocumentPath);
            }
            else
            {
                //TODO Mehrsprachigkeit
                mergedDocument.MergeResult.Add(new KissServiceResult(ServiceResultType.Error, string.Format("Fehler beim Speichern des zusammengesetzten PDF: {0}", saveErrorMessage)));
                _logger.ErrorFormat("Error while saving merged PDF: {0}", saveErrorMessage);
            }

            return mergedDocument;
        }

        public static IServiceResult Print(List<PdfFileInfo> printInfos, PdfPrintOptions printOptions = null)
        {
            if (printOptions == null)
            {
                printOptions = new PdfPrintOptions();
            }

            var result = KissServiceResult.Ok();
            var pdfFileInfos = printInfos.Where(x => x.FileInfo.Extension.ToUpper() == ".PDF").ToList();
            var notPdfFileInfos = printInfos.Where(x => x.FileInfo.Extension.ToUpper() != ".PDF").ToList();

            // only print PDFs
            if (notPdfFileInfos.Any())
            {
                notPdfFileInfos.ForEach(x =>
                {
                    var message = string.Format("Die Datei '{0}' wurde nicht gedruckt da es kein PDF ist.", x.FileInfo.FullName);
                    _logger.Debug(message);
                    result.Add(new KissServiceResult(ServiceResultType.Warning, message));
                });
            }

            if (pdfFileInfos.Any())
            {
                if (printOptions.MergeBeforePrint)
                {
                    // Merge the PDFs into one PDF
                    var mergedDocumentFileInfo = GetTempFileInfo(printOptions.TempPath);
                    var mergedDocument = MergeDocuments(pdfFileInfos, mergedDocumentFileInfo.FullName);

                    if (!mergedDocument.MergeResult.IsOk)
                    {
                        result.Add(mergedDocument.MergeResult);
                    }

                    // Print the merged PDF
                    result.Add(DocumentHelper.PrintDocument(mergedDocumentFileInfo, printOptions.PrinterName));
                    DeleteDocument(printOptions, mergedDocumentFileInfo);

                    if (pdfFileInfos.Count == 1)
                    {
                        var waitTask = Task.Factory.StartNew(() => Thread.Sleep(printOptions.WaitTimeAfterPrint));
                        waitTask.Wait();
                    }
                }
            }

            return result;
        }

        private static void DeleteDocument(PdfPrintOptions printOptions, FileInfo mergedDocumentFileInfo)
        {
            if (!printOptions.DeleteMergedPdfAfterPrinting)
            {
                // Das Dokument muss nicht gelöscht werden
                return;
            }

            var countDeleteAttemptOfMergedDocument = 0;
            while (File.Exists(mergedDocumentFileInfo.FullName) && countDeleteAttemptOfMergedDocument < printOptions.MaxDeleteAttemptOfMergedDocument)
            {
                countDeleteAttemptOfMergedDocument++;

                try
                {
                    // versuchen das Dokument zu löschen
                    var deleteTask = Task.Factory.StartNew(() => WaitAndDeleteFile(printOptions, mergedDocumentFileInfo));
                    deleteTask.Wait();
                }
                catch (Exception ex)
                {
                    // Das Löschen ist fehlgeschlagen. Das Dokument ist sehr wahrscheinlich noch fürs Drucken verwendet
                    _logger.Debug(
                        string.Format("Das Löschen des zusammengesetztes Dokument ist fehlgeschlagen. Versuch = {0}", countDeleteAttemptOfMergedDocument),
                        countDeleteAttemptOfMergedDocument == 1 ? ex : null);
                }
            }

            // Log-Eintrag falls das Dokument noch vorhanden ist
            if (File.Exists(mergedDocumentFileInfo.FullName))
            {
                _logger.DebugFormat("Die Datei {0} wurde nach {1} Versuchen NICHT gelöscht!", mergedDocumentFileInfo.FullName, countDeleteAttemptOfMergedDocument);
            }
        }

        private static FileInfo GetTempFileInfo(string tempPath)
        {
            if (string.IsNullOrEmpty(tempPath) || !Directory.Exists(tempPath))
            {
                tempPath = Path.GetTempPath();
            }

            FileInfo fileInfo;

            do
            {
                fileInfo = new FileInfo(Path.Combine(tempPath, Guid.NewGuid().ToString() + ".pdf"));
            }
            while (File.Exists(fileInfo.FullName));

            return fileInfo;
        }

        private static void WaitAndDeleteFile(PdfPrintOptions printOptions, FileInfo mergedDocumentFileInfo)
        {
            // Wait before deleting the merged PDF
            Thread.Sleep(printOptions.WaitTimeAfterPrint);

            // Delete the merged PDF
            _logger.DebugFormat("Die Datei {0} wird gelöscht.", mergedDocumentFileInfo.FullName);
            mergedDocumentFileInfo.Delete();
            _logger.DebugFormat("Die Datei {0} wurde gelöscht.", mergedDocumentFileInfo.FullName);
        }
    }
}