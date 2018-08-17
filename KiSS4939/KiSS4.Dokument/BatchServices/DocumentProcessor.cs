//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows.Forms;
//using KiSS4.Messages;
//using System.IO;
//using KiSS4.Gui;
//using KiSS4.DB;
//using KiSS4.Dokument.WordAutomation;

//namespace KiSS4.Dokument.BatchServices
//{
//   internal class DocumentProcessor
//   {

//      /// <summary>
//      /// Creates the documents for context list.
//      /// </summary>
//      /// <param name="templateId">The template id.</param>
//      /// <param name="listOfKisKontexts">The list of kis kontexts.</param>
//      internal void CreateDocumentsForContextList(object templateId, IList<IKissContext> listOfKisKontexts)
//      {
//         foreach (IKissContext context in listOfKisKontexts)
//         {
//            WordDoc wordDoc = null;
//            bool dlgShowBookmarkErrors = false;
//            try
//            {
//               DlgProgressLog.ShowTopMost();
//               DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "VorlageLaden", "Word-Vorlage laden"));
//               XDocFileHandler template = XDocFileHandler.GetFileHandler_XDocTemplate(templateId);
//               template.DBToFile(false, false);
//               template.FileInfo.Attributes &= ~FileAttributes.ReadOnly;

//               // Create new Word doc, get bookmarks filled according to given context
//               DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "DokumentErzeugen", "Word-Dokument erzeugen"));

//               String name = template.FileInfo.FullName;
//               name = name.Replace(".dot", ".doc");
//               FileInfo docFi = new FileInfo(name);
//               wordDoc = new WordDoc(template.FileInfo, docFi, context);
//               Application.DoEvents();

//               // Save new Word doc in DB
//               DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "DokumentSpeichern", "Word-Dokument speichern"));


//               XDocFileHandler doc = new XDocFileHandler();
//               DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "DokumentInDb", "Word-Dokument in Datenbank schreiben"));
//               doc.FileToDB(wordDoc.DocFileInfo);
//               doc["DocTemplateID"] = templateId;
//               doc.Post();

//               template.WatchFile();
//               Application.DoEvents();

//               DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "DokumentClose", "Word-Dokument schliessen"));
//               wordDoc.CloseDocument();
//               DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "DokumentWaitForPrc", "Auf Prozessfreigabe warten ..."));

//               Application.DoEvents();

//               //Word wird geschlossen, ist aber ein separates Prozess. Alle andere offene Dokumente sind davon nicht betroffen.
//               wordDoc.QuitWord();

//               try
//               {
//                  template.WaitForDocToBeRemovedFromFilesystem();
//               }
//               catch
//               {
//               }

//               DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "TempDokumentLöschen", "Temporäres dokument von Filesystem löschen"));
//               try
//               {
//                  wordDoc.RemoveDocumentFromFileSystem();
//                  Application.DoEvents();
//               }
//               catch (Exception e)
//               {
//                  DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "FehlerBeimLoeschen", "Fehler beim Löschen des Temporären Dokuments") + e);
//               }
//               if (!dlgShowBookmarkErrors || !DlgProgressLog.HasErrors)
//               {
//                  // Close Progress dialog
//                  DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "DialogSchliessen", "Dialog wird geschlossen ... "));
//                  DlgProgressLog.CloseDialog();
//               }
//               else
//               {
//                  // Keep Progress dialog open and display the new doc after the user quits the dialog
//                  DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "ErledigtMitFehler", "Erledigt (Es sind Fehler aufgetreten)"));
//                  DlgProgressLog.EndProgress();
//                  DlgProgressLog.ShowTopMost();
//               }

//               try
//               {
//                  doc.DBToFile(true, true);
//               }
//               catch (ZipException ex)
//               {
//                  KissMsg.ShowInfo(ex.Message);
//                  return;
//               }
//               catch (Exception ex)
//               {
//                  KissMsg.ShowError("Xdokument", "FehlerDokumentOeffnen", "Fehler beim Öffnen des Dokuments\r\n\r\n", ex.Message, ex);
//                  return;
//               }

//            }
//            catch (CancelledByUserException)
//            {
//               if (wordDoc != null) wordDoc.CloseDocument();
//               DlgProgressLog.CloseDialog();
//               return;
//            }
//            catch (ZipException ex)
//            {
//               if (wordDoc != null) wordDoc.CloseDocument();
//               DlgProgressLog.CloseDialog();
//               KissMsg.ShowInfo(ex.Message);
//               return;
//            }
//            catch (Exception ex)
//            {
//               if (wordDoc != null) wordDoc.CloseDocument();
//               DlgProgressLog.CloseDialog();
//               KissMsg.ShowError("Xdokument", "FehlerDokumentErzeugen", "Fehler beim Erzeugen des neuen Word-Dokuments\r\n\r\n", ex.Message, ex);
//               return;
//            }
//            finally
//            {
//               Cursor.Current = Cursors.Default;
//            }

//         }
//      }

//      /// <summary>
//      /// Signs the documents.
//      /// </summary>
//      /// <param name="signText">The sign text.</param>
//      /// <param name="listOfDocumentIds">The list of document ids.</param>
//      internal void SignDocuments(IKissContext context, IList<String> listOfDocumentIds)
//      {
//         foreach (String documentId in listOfDocumentIds)
//         {
//            XDocFileHandler fileHandler = XDocFileHandler.GetFileHandler_XDocument(documentId);
//            fileHandler.DBToFile(true, false);
//            fileHandler.WatchFile();

//            WordDoc dc = new WordDoc(fileHandler.FileInfo, context);
//            dc.MakeWordVisible();
//         }
//      }
//   }
//}
