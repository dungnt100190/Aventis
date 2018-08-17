using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Kiss.BusinessLogic.Sys;
using Kiss.Infrastructure;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument.Utilities;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Query.ZH
{
    public partial class CtlQueryAdmDokumenteArchivierenUndLoeschen : KissQueryControl
    {
        private const string CLASSNAME = "CtlQueryAdmDokumenteArchivierenUndLoeschen";
        private const string CONFIG_KEY_ARCHIVIERUNGSPFAD = @"System\Dokumentemanagement\Archivierungspfad";
        private string _filePath;

        public CtlQueryAdmDokumenteArchivierenUndLoeschen()
        {
            InitializeComponent();

            kissSearch.SelectParameters = new object[] { Session.User.LanguageCode };

            _filePath = DBUtil.GetConfigValue(CONFIG_KEY_ARCHIVIERUNGSPFAD, string.Empty).ToString();
        }

        protected override void NewSearch()
        {
            base.NewSearch();
            edtSucheDatumVon.EditValue = DateTime.Today.AddMonths(-12);
            edtSucheKlibuRelevant.EditValue = true;
            edtSucheNichtKlibuRelevant.EditValue = true;
        }

        private static string GetFaDokumentFileNameArchiviert(DataRow queryFaDokumentRow, int filePathLength)
        {
            var faFallId = Convert.ToString(queryFaDokumentRow["FallNummer"]);
            var stichwort = FileUtilies.RemoveInvalidFileNameChars(Convert.ToString(queryFaDokumentRow["Stichwort"]));
            var userId = Convert.ToString(queryFaDokumentRow["ErstellerIn_User"]);
            var erstelldatum = Convert.ToString(queryFaDokumentRow["Erstelldatum"]);
            var faDokumenteId = Convert.ToString(queryFaDokumentRow["FaDokumentID$"]);

            //generate the file name
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("F{0}_", faFallId);
            stringBuilder.Append("Stichwort_{0}_");
            stringBuilder.AppendFormat("UserID_{0}_", userId);
            stringBuilder.AppendFormat("Erstelldatum_{0}_", erstelldatum);
            stringBuilder.AppendFormat("FaDokID_{0}", faDokumenteId);

            var fileName = stringBuilder.ToString();
            fileName = FileUtilies.ReplaceParamInFileName(fileName, stichwort, filePathLength);

            return fileName;
        }

        private void btnAlle_Click(object sender, EventArgs e)
        {
            SelectUnselectAll(true);
        }

        private void btnArchivieren_Click(object sender, EventArgs e)
        {
            if (!KissMsg.ShowQuestion(
                    CLASSNAME,
                    "ConfirmArchiveActionSelectedArchiviertenDokumenten",
                    "Wollen Sie die selektierten Dokumente archivieren? Für die Umwandlung von Excel-Dokumenten muss Excel geschlossen werden.",
                    true
                ))
            {
                return;
            }

            //Dialog öffnen
            DlgProgressLog.Show("Document archivieren", ProgressStart, ProgressEnd, Session.MainForm);

            RefreshGrid();
            RefreshDisplayButtons();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Liste der Dokumente die zu achrivieren sind erstellen
            var selectedNotArchivedRows = qryQuery.DataTable.Rows.Cast<DataRow>().Where(row => (bool)row["Selected"] && (bool)row["Archiviert"]).ToList();

            if (!KissMsg.ShowQuestion(
                    CLASSNAME,
                    "ConfirmDeleteSelectedArchiviertenDokumenten",
                    "Wollen Sie die {0} selektierten Dokumente definitiv aus KiSS löschen?",
                    true,
                    selectedNotArchivedRows.Count()))
            {
                return;
            }

            var deleteNbSuccess = 0;
            var deleteNbError = 0;

            foreach (var row in selectedNotArchivedRows)
            {
                //store the data before we delete the row
                var faDokumenteID = row["FaDokumentID$"];
                var dokumentFileName = GetFaDokumentFileNameArchiviert(row, _filePath.Length);

                //prepare var for delete
                var exceptionText = string.Empty;
                bool isDeleteSuccess;

                try
                {
                    //Delete
                    var sqlNbRow = DBUtil.ExecSQL(@"
                        DELETE
                        FROM dbo.FaDokumente
                        WHERE Archiviert = 1
                          AND FaDokumenteID = {0};",
                        faDokumenteID);

                    isDeleteSuccess = sqlNbRow >= 1;
                }
                catch (Exception ex)
                {
                    isDeleteSuccess = false;
                    exceptionText = ex.Message;
                }

                if (isDeleteSuccess)
                {
                    deleteNbSuccess++;

                    XLog.Create(
                        GetType().FullName,
                        LogLevel.INFO,
                        "Archiviertes Dokument gelöscht",
                        string.Format(
                            "Der Eintrag in der Tabelle FaDokumente mit FaDokumenteID = {0}, DokumentFilename = {1} wurde erfolgreich gelöscht. ",
                            faDokumenteID,
                            dokumentFileName),
                        "FaDokumente",
                        (int)faDokumenteID);
                }
                else
                {
                    deleteNbError++;

                    var xLogText = string.Format(
                        "Der Eintrag in der Tabelle FaDokumente mit FaDokumenteID = {0} konnte nicht gelöscht werden. ",
                        faDokumenteID);
                    if (!string.IsNullOrEmpty(exceptionText))
                    {
                        xLogText += string.Format("Fehlermeldung: {0} ", exceptionText);
                    }

                    XLog.Create(
                        GetType().FullName,
                        LogLevel.ERROR,
                        "Archiviertes Dokument konnte nicht gelöscht werden.",
                        xLogText,
                        "FaDokumente",
                        (int)faDokumenteID);
                }
            }

            qryQuery.Refresh();

            var param = new object[2];
            param[0] = deleteNbSuccess;
            param[1] = deleteNbError;

            KissMsg.ShowInfo(
                CLASSNAME,
                "DeleteResult",
                "{0} Dokument(e) wurde(n) erfolgreich gelöscht. {1} Dokument(e) konnte(n) nicht gelöscht werden.",
                param);

            RefreshDisplayButtons();
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            SelectUnselectAll(false);
        }

        private void edtSuchePerson_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtSuchePerson.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSuchePerson.EditValue = DBNull.Value;
                    edtSuchePerson.LookupID = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT DISTINCT
                  ID           = PRS.BaPersonID,
                  DisplayText  = PRS.DisplayText,
                  BaPersonID$  = PRS.BaPersonID,
                  NameVorname$ = PRS.NameVorname
                FROM dbo.vwPerson             PRS
                  INNER JOIN dbo.FaFallPerson FAP WITH (READUNCOMMITTED) ON FAP.BaPersonID = PRS.BaPersonID
                WHERE (PRS.NameVorname LIKE '%' + {0} + '%' OR CAST(PRS.BaPersonID as varchar) = {0})
                ORDER BY NameVorname$",
                searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSuchePerson.EditValue = dlg["NameVorname$"];
                edtSuchePerson.LookupID = dlg["BaPersonID$"];
            }
        }

        private void gridedtSel_CheckedChanged(object sender, EventArgs e)
        {
            grvFaDokumente.PostEditor();
            RefreshDisplayButtons();
        }

        private void ProgressEnd()
        {
        }

        private void ProgressStart()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                ApplicationFacade.DoEvents();

                //First message
                DlgProgressLog.AddLine("Start der Archivierung");
                ApplicationFacade.DoEvents();

                //Get and check KeyPath im Config
                if (!Directory.Exists(_filePath))
                {
                    DlgProgressLog.AddLine(
                        string.Format(
                            "Fehler: Der Ordner {0} existiert nicht. Bitte im Configwert {1} einen gültigen Pfad angeben.",
                            _filePath,
                            CONFIG_KEY_ARCHIVIERUNGSPFAD));

                    DlgProgressLog.EndProgress();
                    return;
                }

                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.SelectedPath = _filePath;
                dlg.Description = "Bitte wählen Sie das Verzeichis für die archivierten Dokumente";

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    DlgProgressLog.AddLine("Es wurde kein Archiv Verzeichnis ausgewählt.");
                    DlgProgressLog.AddLine("Die Verarbeitung wurde abgebrochen.");

                    DlgProgressLog.EndProgress();
                    return;
                }

                _filePath = dlg.SelectedPath;

                DlgProgressLog.AddLine(string.Format("Der Archvierungspfad ist {0}.", _filePath));

                //prepare foreach
                var documentService = Kiss.Infrastructure.IoC.Container.Resolve<XDocumentService>();
                var nbSuccess = 0;
                var nbError = 0;
                var selectedRows = qryQuery.DataTable.Rows.Cast<DataRow>().Where(row => (bool)row["Selected"]).ToList();
                var nbSelected = selectedRows.Count();

                //foreach row
                foreach (var row in selectedRows)
                {
                    var messagePrefix = string.Format(
                        "Dokument {0} von {1} - FaDokumenteID = {2} - ",
                        nbSuccess + nbError + 1,
                        nbSelected,
                        row["FaDokumentID$"]);

                    DlgProgressLog.AddLine(messagePrefix + "In PDF konvertieren und im Archivierungspfad ablegen ");

                    try
                    {
                        //Dokument nach PDF konvertieren und speichern
                        var documentID = row["DocumentID"];
                        if (DBUtil.IsEmpty(documentID))
                        {
                            throw new Exception(
                                string.Format(
                                    "Das Dokument konnte nicht gefunden werden. An diesem Datensatz ist wahrscheinlich kein Dokument angehängt. FallNummer = {0} ",
                                    row["FallNummer"]));
                        }

                        var document = documentService.GetByDocumentID((int)documentID);
                        if (document == null)
                        {
                            throw new Exception(
                                string.Format(
                                    "Das Dokument konnte in der Tabelle xDocument nicht gefunden werden. Bitte den Datensatz prüfen. DocumentID = {0} FallNummer = {1} ",
                                    documentID,
                                    row["FallNummer"]));
                        }

                        var fileName = GetFaDokumentFileNameArchiviert(row, _filePath.Length);
                        var completeFilePathWithoutExtension = Path.Combine(_filePath, fileName);

                        if (documentService.CanSaveAsPdf(document))
                        {
                            var serviceResult = documentService.SaveDocumentAsPdf(document, completeFilePathWithoutExtension + ".pdf", true);
                            if (!serviceResult.IsOk)
                            {
                                throw new Exception(
                                    string.Format(
                                        "Das Dokument konnte nicht als PDF gespeichert werden. FileName ist {0} . {1}",
                                        fileName,
                                        serviceResult
                                        ));
                            }
                        }
                        else
                        {
                            var serviceResult = documentService.SaveDocumentAs(document, completeFilePathWithoutExtension + document.FileExtension);
                            if (!serviceResult.IsOk)
                            {
                                throw new Exception(
                                    string.Format(
                                        "Das Dokument konnte nicht ins Archivverzeichnis verschoben werden. FileName ist {0} . {1}",
                                        fileName,
                                        serviceResult
                                        ));
                            }
                        }

                        DlgProgressLog.UpdateLastLine(messagePrefix + "Dokument wurde erfolgreich in den Zielordner kopiert.");

                        //update Archiviert in DB
                        var sqlNbRow = DBUtil.ExecSQL(@"
                            UPDATE dbo.FaDokumente
                              SET Archiviert = 1
                            WHERE FaDokumenteID = {0};",
                            row["FaDokumentID$"]);

                        row["Archiviert"] = 1;

                        if (sqlNbRow == 1)
                        {
                            DlgProgressLog.UpdateLastLine(messagePrefix + "wurde erfolgreich archiviert.");
                        }
                        else
                        {
                            DlgProgressLog.UpdateLastLine(
                                messagePrefix + "Dokument wurde erfolgreich in den Zielordner gespeichert. Der Datensatz in der DB konnte aber nicht aktualisiert werden.");
                        }

                        nbSuccess++;
                    }
                    catch (Exception ex)
                    {
                        if (ex is CancelledByUserException)
                        {
                            Cursor = Cursors.Default;
                            return;
                        }

                        var exceptionMessage = ex.Message;
                        DlgProgressLog.UpdateLastLine(messagePrefix + "Es ist ein Fehler beim Archivieren aufgetreten. Die Fehlermeldung lautet: " + exceptionMessage);

                        nbError++;
                    }
                }

                DlgProgressLog.AddLine(string.Format("{0} Dokumente wurden erfolgreich archiviert.", nbSuccess));
                DlgProgressLog.AddLine(string.Format("{0} Dokumente konnten nicht archiviert werden.", nbError));

                DlgProgressLog.AddLine("Archivierung abgeschlossen.");

                DlgProgressLog.EndProgress();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void qryQuery_PositionChanged(object sender, EventArgs e)
        {
            RefreshDisplayButtons();
        }

        private void RefreshDisplayButtons()
        {
            btnArchivieren.Visible = qryQuery.DataTable.Rows.Cast<DataRow>().Any(row => (bool)row["Selected"]);

            //Das Löschen ein noch nicht archiviertes Dokument vermeiden
            if (qryQuery.DataTable.Rows.Cast<DataRow>().Any((row => ((bool)row["Selected"] && !(bool)row["Archiviert"]))))
            {
                btnDelete.Visible = false;
            }
            else
            {
                btnDelete.Visible = qryQuery.DataTable.Rows.Cast<DataRow>().Any((row => ((bool)row["Selected"] && (bool)row["Archiviert"])));
            }
        }

        private void RefreshGrid()
        {
            grdFaDokumente.Refresh();
        }

        private void SelectUnselectAll(bool isSelected)
        {
            var isOneUpdated = false;

            int visibleIndex = 0;
            int currentRowHandle = grvFaDokumente.GetVisibleRowHandle(visibleIndex);
            while (currentRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                DataRow row = grvFaDokumente.GetDataRow(currentRowHandle);
                row["Selected"] = isSelected;
                isOneUpdated = true;

                visibleIndex = grvFaDokumente.GetNextVisibleRow(visibleIndex);
                currentRowHandle = grvFaDokumente.GetVisibleRowHandle(visibleIndex);
            }

            if (isOneUpdated)
            {
                RefreshDisplayButtons();
            }
        }
    }
}