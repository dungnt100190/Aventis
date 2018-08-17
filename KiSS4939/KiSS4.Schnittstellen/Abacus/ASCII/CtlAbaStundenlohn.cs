using System;
using System.Data;
using System.IO;
using System.Web.Services.Protocols;
using System.Windows.Forms;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Schnittstellen.Abacus.KlientenStammdaten;

namespace KiSS4.Schnittstellen.Abacus.ASCII
{
    /// <summary>
    /// Control, used for generating ascii file for importing working data of hourly wages into Abacus
    /// </summary>
    public partial class CtlAbaStundenlohn : CtlAbaASCIIBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly string _statusText = KissMsg.GetMLMessage("CtlAbaStundenlohn", "StatusText", "Status"); // default text for statusbar

        #endregion

        #region Private Fields

        private int SchnittstellenCode = 2; // stundenlohn schnittstelle

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlAbaStundenlohn"/> class.
        /// </summary>
        public CtlAbaStundenlohn()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnDatenExport_Click(object sender, EventArgs e)
        {
            // disable controls to prevent double clicks
            EnableDisableControls(false);

            // store last cursor
            Cursor lastCursor = Cursor.Current;

            // create var for temp file
            string tempFile = null;

            // create flag for no-data-export
            bool hasAnyDataToExport = true;

            // logging
            InsertAbaLog("<gb_datrange>", null, null, "btnDatenExport clicked");
            InsertAbaLog(null, null, null, "Export started.");

            try
            {
                // CURSOR:
                Cursor.Current = Cursors.WaitCursor;

                // --------------------------------------------------------------------------
                // 1. VALIDATE SETTINGS/VISUM
                // --------------------------------------------------------------------------
                // set status
                SetStatusLabel("StatusExportSettingsVisum", "Einstellungen und Daten werden �berpr�ft...");

                // logging
                InsertAbaLog(null, null, null, "1. Validate settings and data");

                // check integrity
                if (!ValidateSettingsAndData())
                {
                    // error with settings or visum, message already shown

                    // logging
                    InsertAbaLog(null, null, null, "Export canceled, invalid settings or data without visa");
                    return;
                }

                if (!CheckSindStundenErfasst())
                {
                    InsertAbaLog(null, null, null, "Export canceled, active users without exporting data");
                    return;
                }

                // --------------------------------------------------------------------------
                // 2. CONFIRM CONTINUE
                // --------------------------------------------------------------------------
                // logging
                InsertAbaLog(null, null, null, "2. Confirm continue export");

                // set status
                SetStatusLabel("StatusExportConfirmContinue", "Best�tigung f�r Export abwarten...");
                if (!KissMsg.ShowQuestion("CtlAbaStundenlohn", "ConfirmExportData", "Wollen Sie den Export f�r den Gesch�ftsbereich '{0}' und den Monat '{1}' jetzt durchf�hren?", 0, 0, true, edtGeschaeftsbereich.Text, edtDatumVon.Text))
                {
                    // logging
                    InsertAbaLog(null, null, null, "Export canceled, user did not confirm continuation");

                    // canceled, do not continue
                    return;
                }

                // --------------------------------------------------------------------------
                // 3. DO BULK-VISUM
                // --------------------------------------------------------------------------
                // set status
                SetStatusLabel("StatusExportBulkVisum", "Mitarbeiter/innen ohne Daten werden automatisch visiert...");

                // logging
                InsertAbaLog(null, null, null, "3. Do bulk visa for users without entries");

                // does not matter if export failes, entries will stay in database and won't harm in any way
                InsertBulkVisum();

                // --------------------------------------------------------------------------
                // 4. GET DATA TO EXPORT
                // --------------------------------------------------------------------------
                // set status
                SetStatusLabel("StatusExportCollectData", "Daten zum Exportieren werden zusammengetragen...");

                // logging
                InsertAbaLog("<gb_datrange>", null, null, "4. Collect data to export");

                // fill query
                if (!qryLeistungExport.Fill(edtGeschaeftsbereich.EditValue, edtDatumVon.EditValue, edtDatumBis.EditValue, Session.User.LanguageCode))
                {
                    throw new Exception("Error loading data to export, cannot proceed!");
                }

                // --------------------------------------------------------------------------
                // 5. PARSE ROWS AND WRITE FILE
                // --------------------------------------------------------------------------
                // set status
                SetStatusLabel("StatusExportParseRowsWriteFile", "Daten werden ausgewertet und die Export-Datei wird geschrieben...");

                // get temp file to write data into
                tempFile = Path.GetTempFileName();

                // setup counter of lines written
                int countWrittenLines = 0;

                // setup row counter
                int countRows = 0;
                int countRowsTotal = qryLeistungExport.Count;

                // logging
                InsertAbaLog(null, null, null, string.Format("5. Start evaluating and writing file (rows found: '{0}', write to tempfile: '{1}')", countRowsTotal, tempFile));

                // loop data and parse each lohnart-hours amount
                foreach (DataRow row in qryLeistungExport.DataTable.Rows)
                {
                    // count up rows
                    countRows++;

                    // set status
                    SetStatusLabel("StatusExportParseRowsWriteFileCounting", "Daten werden ausgewertet und die Export-Datei wird geschrieben ({0} von {1} Datens�tzen)...", countRows, countRowsTotal);

                    //Wir exportieren nur Datens�tze mit KeinExport = false.
                    if (!DBUtil.IsEmpty(row["KeinExport"]) && Convert.ToBoolean(row["KeinExport"]))
                    {
                        continue;
                    }

                    // validate data (1. all following fields are must-fields)
                    if (DBUtil.IsEmpty(row["MA-Nr."]) || DBUtil.IsEmpty(row["Periodendatum$"]) ||
                        DBUtil.IsEmpty(row["Perioden-Nr."]) || DBUtil.IsEmpty(row["Kostenstelle"]) ||
                        DBUtil.IsEmpty(row["Kostentr�ger"]) || DBUtil.IsEmpty(row["Kostenart"]))
                    {
                        throw new Exception(string.Format("Invalid data, not all required fields are available (userid: '{0}')", row["UserID$"]));
                    }

                    // validate data (2. Freigabe and visum must be false, Verbucht must be empty)
                    if (!DBUtil.IsEmpty(row["Freigabe"]) && !Convert.ToBoolean(row["Freigabe"]))
                    {
                        throw new Exception(string.Format("Invalid data, 'Freigabe' is not true for given record (userid: '{0}')", row["UserID$"]));
                    }
                    if (!DBUtil.IsEmpty(row["Visum"]) && !Convert.ToBoolean(row["Visum"]))
                    {
                        throw new Exception(string.Format("Invalid data, 'Visum' is not true for given record (userid: '{0}')", row["UserID$"]));
                    }
                    if (!DBUtil.IsEmpty(row["Verbucht"]) && Convert.ToBoolean(row["Verbucht"]))
                    {
                        throw new Exception(string.Format("Invalid data, 'Verbucht' is already set (userid: '{0}')", row["UserID$"]));
                    }

                    // validate data (3. the value '-1' is not allowed for Perioden-Nr., Kostenstelle, Kostenart, Kostentr�ger
                    if (Convert.ToInt32(row["Perioden-Nr."]) < 0 || Convert.ToInt32(row["Kostenstelle"]) < 0 ||
                        Convert.ToInt32(row["Kostenart"]) < 0 || Convert.ToInt32(row["Kostentr�ger"]) < 0)
                    {
                        throw new Exception(string.Format("Invalid data, 'Perioden-Nr.', 'Kostenstelle', 'Kostenart' and/or 'Kostentr�ger' have negative values (userid: '{0}')", row["UserID$"]));
                    }

                    // check which entries we have to write
                    // lohnart 1
                    if (!DBUtil.IsEmpty(row["Lohnart 1100"]) && Convert.ToDouble(row["Lohnart 1100"]) != 0.0)
                    {
                        // lohnart 1, 1100
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format(
                                "{0},{1},{2:d},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                                "L001",
                                row["MA-Nr."],
                                row["Periodendatum$"],
                                row["Perioden-Nr."],
                                1100,
                                0,
                                null,
                                null,
                                row["Lohnart 1100"],
                                0,
                                0,
                                0,
                                row["Kostenstelle"],
                                row["Kostentr�ger"],
                                0,
                                0,
                                row["Kostenart"],
                                "L001"));

                        // update counter
                        countWrittenLines++;
                    }

                    // lohnart 2
                    if (!DBUtil.IsEmpty(row["Lohnart 1110"]) && Convert.ToDouble(row["Lohnart 1110"]) != 0.0)
                    {
                        // lohnart 2, 1110
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format(
                                "{0},{1},{2:d},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                                "L001",
                                row["MA-Nr."],
                                row["Periodendatum$"],
                                row["Perioden-Nr."],
                                1110,
                                0,
                                null,
                                null,
                                row["Lohnart 1110"],
                                0,
                                0,
                                0,
                                row["Kostenstelle"],
                                row["Kostentr�ger"],
                                0,
                                0,
                                row["Kostenart"],
                                "L001"));

                        // update counter
                        countWrittenLines++;
                    }

                    // lohnart 3
                    if (!DBUtil.IsEmpty(row["Lohnart 1120"]) && Convert.ToDouble(row["Lohnart 1120"]) != 0.0)
                    {
                        // lohnart 3, 1120
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format(
                                "{0},{1},{2:d},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                                "L001",
                                row["MA-Nr."],
                                row["Periodendatum$"],
                                row["Perioden-Nr."],
                                1120,
                                0,
                                null,
                                null,
                                row["Lohnart 1120"],
                                0,
                                0,
                                0,
                                row["Kostenstelle"],
                                row["Kostentr�ger"],
                                0,
                                0,
                                row["Kostenart"],
                                "L001"));

                        // update counter
                        countWrittenLines++;
                    }

                    // lohnart 4
                    if (!DBUtil.IsEmpty(row["Lohnart 1130"]) && Convert.ToDouble(row["Lohnart 1130"]) != 0.0)
                    {
                        // lohnart 4, 1130
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format(
                                "{0},{1},{2:d},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                                "L001",
                                row["MA-Nr."],
                                row["Periodendatum$"],
                                row["Perioden-Nr."],
                                1130,
                                0,
                                null,
                                null,
                                row["Lohnart 1130"],
                                0,
                                0,
                                0,
                                row["Kostenstelle"],
                                row["Kostentr�ger"],
                                0,
                                0,
                                row["Kostenart"],
                                "L001"));

                        // update counter
                        countWrittenLines++;
                    }

                    // lohnart 10
                    if (!DBUtil.IsEmpty(row["Lohnart 1210"]) && Convert.ToDouble(row["Lohnart 1210"]) != 0.0)
                    {
                        // lohnart 10, 1210
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format(
                                "{0},{1},{2:d},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                                "L001",
                                row["MA-Nr."],
                                row["Periodendatum$"],
                                row["Perioden-Nr."],
                                1210,
                                0,
                                null,
                                null,
                                row["Lohnart 1210"],
                                0,
                                0,
                                0,
                                row["Kostenstelle"],
                                row["Kostentr�ger"],
                                0,
                                0,
                                row["Kostenart"],
                                "L001"));

                        // update counter
                        countWrittenLines++;
                    }

                    // lohnart 11
                    if (!DBUtil.IsEmpty(row["Lohnart 1220"]) && Convert.ToDouble(row["Lohnart 1220"]) != 0.0)
                    {
                        // lohnart 11, 1220
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format(
                                "{0},{1},{2:d},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                                "L001",
                                row["MA-Nr."],
                                row["Periodendatum$"],
                                row["Perioden-Nr."],
                                1220,
                                0,
                                null,
                                null,
                                row["Lohnart 1220"],
                                0,
                                0,
                                0,
                                row["Kostenstelle"],
                                row["Kostentr�ger"],
                                0,
                                0,
                                row["Kostenart"],
                                "L001"));

                        // update counter
                        countWrittenLines++;
                    }

                    // lohnart 12
                    if (!DBUtil.IsEmpty(row["Lohnart 1230"]) && Convert.ToDouble(row["Lohnart 1230"]) != 0.0)
                    {
                        // lohnart 12, 1230
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format(
                                "{0},{1},{2:d},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                                "L001",
                                row["MA-Nr."],
                                row["Periodendatum$"],
                                row["Perioden-Nr."],
                                1230,
                                0,
                                null,
                                null,
                                row["Lohnart 1230"],
                                0,
                                0,
                                0,
                                row["Kostenstelle"],
                                row["Kostentr�ger"],
                                0,
                                0,
                                row["Kostenart"],
                                "L001"));

                        // update counter
                        countWrittenLines++;
                    }

                    // lohnart 13
                    if (!DBUtil.IsEmpty(row["Lohnart 1240"]) && Convert.ToDouble(row["Lohnart 1240"]) != 0.0)
                    {
                        // lohnart 13, 1240
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format(
                                "{0},{1},{2:d},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                                "L001",
                                row["MA-Nr."],
                                row["Periodendatum$"],
                                row["Perioden-Nr."],
                                1240,
                                0,
                                null,
                                null,
                                row["Lohnart 1240"],
                                0,
                                0,
                                0,
                                row["Kostenstelle"],
                                row["Kostentr�ger"],
                                0,
                                0,
                                row["Kostenart"],
                                "L001"));

                        // update counter
                        countWrittenLines++;
                    }

                    // lohnart 14
                    if (!DBUtil.IsEmpty(row["Lohnart 1250"]) && Convert.ToDouble(row["Lohnart 1250"]) != 0.0)
                    {
                        // lohnart 14, 1250
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format(
                                "{0},{1},{2:d},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                                "L001",
                                row["MA-Nr."],
                                row["Periodendatum$"],
                                row["Perioden-Nr."],
                                1250,
                                0,
                                null,
                                null,
                                row["Lohnart 1250"],
                                0,
                                0,
                                0,
                                row["Kostenstelle"],
                                row["Kostentr�ger"],
                                0,
                                0,
                                row["Kostenart"],
                                "L001"));

                        // update counter
                        countWrittenLines++;
                    }

                    // lohnart 15
                    if (!DBUtil.IsEmpty(row["Lohnart 1260"]) && Convert.ToDouble(row["Lohnart 1260"]) != 0.0)
                    {
                        // lohnart 15, 1260
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format(
                                "{0},{1},{2:d},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                                "L001",
                                row["MA-Nr."],
                                row["Periodendatum$"],
                                row["Perioden-Nr."],
                                1260,
                                0,
                                null,
                                null,
                                row["Lohnart 1260"],
                                0,
                                0,
                                0,
                                row["Kostenstelle"],
                                row["Kostentr�ger"],
                                0,
                                0,
                                row["Kostenart"],
                                "L001"));

                        // update counter
                        countWrittenLines++;
                    }
                }

                // logging
                InsertAbaLog(null, null, null, string.Format("Rows written to export-file: '{0}'", countWrittenLines));

                // check if any lines written
                if (countWrittenLines < 1)
                {
                    // logging
                    InsertAbaLog(null, null, null, "No data found, no file will be written. Continue with flag 'Verbucht'.");

                    // no lines written, continue export without saving file
                    KissMsg.ShowInfo("CtlAbaStundenlohn", "NoDataToExport", "Es wurden keine Daten zum Exportieren gefunden. Der Vorgang wird weiter ausgef�hrt ohne eine Exportdatei zu schreiben.");

                    // set flag to prevent saving file
                    hasAnyDataToExport = false;
                }

                // check if any data to export
                if (hasAnyDataToExport)
                {
                    // ----------------------------------------------------------------------
                    // 6. SAVE FILE
                    // ----------------------------------------------------------------------
                    // set status
                    SetStatusLabel("StatusExportStoreFile", "Export-Datei speichern...");

                    // logging
                    InsertAbaLog(null, null, null, "6. Temp file successfully writting, show dialog for user to save file");

                    // get path for root
                    string configRootDir = DBUtil.GetConfigString(@"System\Schnittstellen\Alpi\AbacusPathStundenlohn", "");

                    // logging
                    InsertAbaLog(null, null, null, string.Format("Configuration value for root directory to store export files: '{0}'", configRootDir));

                    // check if folder exists
                    if (!FolderExists(configRootDir))
                    {
                        // logging
                        InsertAbaLog(configRootDir, null, null, "Error, desired root folder to export data does not exist, trying to apply user's desktop folder");

                        // try to get home folder of user
                        configRootDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                        // recheck if folder exists
                        if (!FolderExists(configRootDir))
                        {
                            // logging
                            InsertAbaLog(configRootDir, null, null, "Error, desired desktop folder to export data does not exist");

                            // error
                            throw new Exception("Cannot access desired default directory or user's desktop, export data cannot be written");
                        }

                        // show message to user
                        KissMsg.ShowInfo("CtlAbaStundenlohn", "ExportRootFolderNotFound", "Das Standardverzeichnis f�r den Datenexport wurde nicht gefunden, stattdessen wird 'Desktop' verwendet.");
                    }

                    // logging
                    InsertAbaLog(null, null, null, string.Format("Default root directory to use for export data: '{0}'", configRootDir));

                    // create filepath/filename
                    string exportFileName = string.Format(@"S{0:000}{1:yyMM}.asc", edtGeschaeftsbereich.EditValue, Convert.ToDateTime(edtDatumBis.EditValue));
                    string exportPath = Path.Combine(configRootDir, string.Format("{0:000}", edtGeschaeftsbereich.EditValue));
                    string exportFile = Path.Combine(exportPath, exportFileName);

                    // logging
                    InsertAbaLog(exportFile, null, null, "Path recommendation to save, showing dialog");

                    // create target folder if not existing yet
                    if (!FolderExists(exportPath))
                    {
                        // logging
                        InsertAbaLog(exportPath, null, null, "Desired target folder not found, creating folder now.");

                        if (!CreateDirectory(exportPath))
                        {
                            // logging
                            InsertAbaLog(exportPath, null, null, "Target folder could not be created, export may not be saved properly!");

                            // show message to user
                            KissMsg.ShowInfo("CtlAbaStundenlohn", "ExportTargetFolderNotCreated", "Das gew�nschte Zielverzeichnis f�r den Datenexport konnte nicht erstellt werden. Bitte �berpr�fen Sie das Verzeichnis und erstellen Sie den Zielordner gegebenenfalls von Hand.\r\n\r\nZiel: '{0}'", 0, 0, exportPath);
                        }
                    }

                    // create dialog to select path and file
                    SaveFileDialog dlgSaveFile = new SaveFileDialog();

                    // apply defaults
                    dlgSaveFile.InitialDirectory = exportPath;
                    dlgSaveFile.RestoreDirectory = true;
                    dlgSaveFile.FileName = exportFileName;

                    // init dialog
                    dlgSaveFile.Filter = string.Format("{0}|*.asc|{1}|*.*", KissMsg.GetMLMessage("CtlAbaStundenlohn", "SaveFileASC", "Abacus ASCII-Datei (*.asc)"), KissMsg.GetMLMessage("CtlAbaStundenlohn", "SaveFileALL", "Alle Dateien (*.*)"));
                    dlgSaveFile.Title = KissMsg.GetMLMessage("CtlAbaStundenlohn", "SaveFileDialogTitle", "Export-Datei speichern");
                    dlgSaveFile.CheckFileExists = false;
                    dlgSaveFile.CheckPathExists = true;
                    dlgSaveFile.OverwritePrompt = true;
                    dlgSaveFile.DefaultExt = "asc";
                    dlgSaveFile.AddExtension = true;
                    dlgSaveFile.ValidateNames = true;

                    // show dialog and check if user clicked ok
                    if (dlgSaveFile.ShowDialog() != DialogResult.OK)
                    {
                        // logging
                        InsertAbaLog(null, null, null, "Export canceled, user did not save export-file");

                        // canceled, do not continue
                        return;
                    }

                    // copy temp file to desired location (temp file will be deleted afterwards)
                    if (!CopyFile(tempFile, dlgSaveFile.FileName))
                    {
                        // logging
                        InsertAbaLog(string.Format("source: '{0}', target: '{1}'", tempFile, dlgSaveFile.FileName), null, null, "Export failed, could not copy temp file to target file");

                        // file not copied, logging
                        throw new Exception(string.Format("The target file could not be created, export failed (source: '{0}', target: '{1}')", tempFile, dlgSaveFile.FileName));
                    }

                    // logging
                    InsertAbaLog(dlgSaveFile.FileName, null, null, "File successfully saved at desired location");
                } // [if (hasAnyDataToExport)]

                // --------------------------------------------------------------------------
                // 7. UPDATE VERBUCHT
                // --------------------------------------------------------------------------
                // set status
                if (hasAnyDataToExport)
                {
                    // file was written
                    SetStatusLabel("StatusExportDoSetVerbucht", "Datei erfolgreich gespeichert, Status 'Verbucht' wird gesetzt...");
                }
                else
                {
                    // no file created
                    SetStatusLabel("StatusExportDoSetVerbuchtNoFile", "Status 'Verbucht' wird gesetzt...");
                }

                // logging
                InsertAbaLog(null, null, null, "7. Update 'Verbucht' on exported data");

                // do update Verbucht for affected users, set date
                UpdateVerbucht(false);

                // --------------------------------------------------------------------------
                // X. DONE
                // --------------------------------------------------------------------------
                // if we are here, everything is ok

                // set status
                SetStatusLabel("StatusExportFileSuccessfullWritten", "Export wird abgeschlossen...");

                // logging
                InsertAbaLog(null, null, null, "Export successfully done, start cleanup and finish.");
            }
            catch (SoapException soapEx)
            {
                // logging
                InsertAbaLog("<gb_datrange>", null, soapEx, "Error occured while exporting data");

                // set status
                SetStatusLabel("StatusExportErrorOccured", "Error: Export fehlgeschlagen!");

                if (soapEx.Detail != null)
                {
                    var detail = soapEx.Detail;
                    string soapMessage = detail.InnerText;

                    throw new KlientenStammdatenException(
                        string.Format("Login Failed. Error: {0}", soapMessage));
                }
            }
            catch (Exception ex)
            {
                // logging
                InsertAbaLog("<gb_datrange>", null, ex, "Error occured while exporting data");

                // set status
                SetStatusLabel("StatusExportErrorOccured", "Error: Export fehlgeschlagen!");

                // something went wrong
                KissMsg.ShowError("CtlAbaStundenlohn", "ErrorCheckingExportData", "Es ist ein Fehler in der Verarbeitung aufgetreten, die Daten wurden nicht korrekt exportiert.", ex);
            }
            finally
            {
                // logging
                InsertAbaLog(tempFile, null, null, "Finished with export execution, deleting tempfile now");

                // set status
                SetStatusLabel("StatusExportFinishing", "Fertig, Export wird abgeschlossen...");

                try
                {
                    // delete temp file (if existing)
                    DeleteFile(tempFile);
                }
                catch (Exception ex)
                {
                    // logging
                    InsertAbaLog(null, null, ex, "Error while deleting temporary file");

                    // error deleting file
                    KissMsg.ShowError("CtlAbaStundenlohn", "ErrorDeleteTempFile", "Fehler beim L�schen der erstellten tempor�ren Datei.", ex);
                }

                // logging
                InsertAbaLog(null, null, null, "Neccessary to calculate a new date range");

                // calculating new date range
                SetupNextDatumVonBis();

                // logging
                InsertAbaLog(null, null, null, "Export finished.");

                // reset cursor
                Cursor.Current = lastCursor;

                // reset status
                SetStatusLabel(null, null);

                // enable controls again
                EnableDisableControls(true);
            }
        }

        private void btnDatenPruefen_Click(object sender, EventArgs e)
        {
            // disable controls to prevent double clicks
            EnableDisableControls(false);

            // store last cursor
            Cursor lastCursor = Cursor.Current;

            try
            {
                // CURSOR:
                Cursor.Current = Cursors.WaitCursor;

                // logging
                InsertAbaLog("<gb_datrange>", null, null, "btnVisumPruefen clicked");

                // check settings and load visum data to check
                if (ValidateSettingsAndData())
                {
                    // everything is ok
                    if (CheckSindStundenErfasst())
                    {
                        KissMsg.ShowInfo("CtlAbaStundenlohn", "CheckSettingsVisumSuccessV2",
                                         "S�mtliche zu exportierende Daten wurden visiert und sind korrekt.");
                    }
                }
            }
            catch (Exception ex)
            {
                // logging
                InsertAbaLog(null, null, ex, "Error occured while checking visa");

                // set status
                SetStatusLabel("StatusCheckVisaErrorOccured", "Error: �berpr�fen fehlgeschlagen!");

                // something went wrong
                KissMsg.ShowError("CtlAbaStundenlohn", "ErrorCheckingVisa", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = lastCursor;

                // reset status
                SetStatusLabel(null, null);

                // enable controls again
                EnableDisableControls(true);
            }
        }

        private void btnGotoBDEErfassung_Click(object sender, EventArgs e)
        {
            // validate
            if (qryValidiertNicht.Count < 1 || DBUtil.IsEmpty(qryValidiertNicht["UserID"]))
            {
                // invalid data, do nothing
                return;
            }

            // logging
            InsertAbaLog("<qrynv_useridname>", null, null, "btnGotoBDEErfassung clicked");

            // jump to form with given user
            FormController.OpenForm("FrmBDEZeiterfassung", "Action", "SelectUser",
                                    "UserID", Convert.ToInt32(qryValidiertNicht["UserID"]));
        }

        private void btnStornoExport_Click(object sender, EventArgs e)
        {
            // disable controls to prevent double clicks
            EnableDisableControls(false);

            // store last cursor
            Cursor lastCursor = Cursor.Current;

            try
            {
                // CURSOR:
                Cursor.Current = Cursors.WaitCursor;

                // logging
                InsertAbaLog("<gb_datrange>", null, null, "btnStornoExport clicked");

                // set status
                SetStatusLabel("StatusStornoLastExportPreparations", "Stornierung �berpr�fen...");

                // check settings
                if (ValidateSettings())
                {
                    // check if we have any data for current month that has Verbucht
                    DateTime nextMonthDate = GetNextDatumVon(Convert.ToInt32(edtGeschaeftsbereich.EditValue), "stunden");

                    // we always want to storno the month that is before next month
                    DateTime undoPeriodDate = nextMonthDate.AddMonths(-1);

                    if (!KissMsg.ShowQuestion("CtlAbaStundenlohn", "ConfirmStornoLastExportWithWarningWithLD", "Wollen Sie den letzten Export wirklich stornieren (Eintr�ge ab '{0:d}')?\r\n\r\nHinweis: Dadurch muss auch ein bereits erfolgter Export der Leistungsdaten-Schnittstelle f�r den aktuellen Monat wiederholt werden!\r\n\r\nAchtung: Die Verarbeitung dauert einen Moment!", 0, 0, false, undoPeriodDate))
                    {
                        // user canceled process, logging
                        InsertAbaLog("<gb_datrange>", null, null, "User canceled undo export for current period");

                        // set status
                        SetStatusLabel("StatusStornoLastExportCanceling", "Stornierung abbrechen...");
                        return;
                    }

                    // set status
                    SetStatusLabel("StatusStornoLastExport", "Letzter Export wird nun storniert...");

                    // logging
                    InsertAbaLog("<gb_datrange>", null, null, "Calculating conditions for undo export");

                    edtDatumVon.EditValue = GetFirstDayOfMonth(undoPeriodDate, false);
                    edtDatumBis.EditValue = GetLastDayOfMonth(edtDatumVon.DateTime, false);

                    // logging
                    InsertAbaLog("<gb_datrange>", null, null, "Undo export for current period");

                    // go on, remove verbucht for current values
                    UpdateVerbucht(true);
                }
            }
            catch (SoapException soapEx)
            {
                // logging
                InsertAbaLog("<gb_datrange>", null, soapEx, "Error occured while removing 'Verbucht'-date on BDELeistung for current department");

                // set status
                SetStatusLabel("StatusStornoExportErrorOccured", "Error: Stornierung des Exports fehlgeschlagen!");

                if (soapEx.Detail != null)
                {
                    var detail = soapEx.Detail;
                    string soapMessage = detail.InnerText;

                    throw new KlientenStammdatenException(
                        string.Format("Login Failed. Error: {0}", soapMessage));
                }
            }
            catch (Exception ex)
            {
                // logging
                InsertAbaLog("<gb_datrange>", null, ex, "Error occured while removing 'Verbucht'-date on BDELeistung for current department");

                // set status
                SetStatusLabel("StatusStornoExportErrorOccured", "Error: Stornierung des Exports fehlgeschlagen!");

                // something went wrong
                KissMsg.ShowError("CtlAbaStundenlohn", "ErrorStornoExport", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
            finally
            {
                // logging
                InsertAbaLog(null, null, null, "Neccessary to calculate a new date range");

                // calculating new date range
                SetupNextDatumVonBis();

                // logging
                InsertAbaLog("<gb_datrange>", null, null, "Done with undo export for current period");

                // reset cursor
                Cursor.Current = lastCursor;

                // reset status
                SetStatusLabel(null, null);

                // enable controls again
                EnableDisableControls(true);
            }
        }

        private void CtlAbaStundenlohn_Load(object sender, EventArgs e)
        {
            // logging
            InsertAbaLog(null, null, null, "Showing user interface to user");

            // set status
            SetStatusLabel("LoadingFormWait", "Bitte warten, die Schnittstelle wird vorbereitet...");

            // depending on rights, the user can see just his mandant or all
            bool userCanSeeAllMandanten = Session.User.IsUserAdmin || DBUtil.UserHasRight("ABAStundenlohnSchnittstelleGB");

            // all mandanten the user can see
            SqlQuery qryMandanten = DBUtil.OpenSQL(@"
                    SELECT [Code] = ORG.Mandantennummer,
                           [Text] = CONVERT(VARCHAR(10), ISNULL(ORG.Mandantennummer, -1)) + '   ' + ORG.ItemName
                    FROM XOrgUnit ORG
                    WHERE ORG.Mandantennummer IS NOT NULL AND
                          (1 = ISNULL({0}, 0) OR ORG.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr({1})) -- only special can select all
                    ORDER BY [Code], [Text]", userCanSeeAllMandanten, Session.User.UserID);

            // setup edtSucheGeschaeftsbereich
            edtGeschaeftsbereich.EditMode = userCanSeeAllMandanten ? EditModeType.Normal : EditModeType.ReadOnly;
            edtGeschaeftsbereich.Properties.DropDownRows = Math.Min(qryMandanten.Count, 14);
            edtGeschaeftsbereich.Properties.DataSource = qryMandanten;

            // setup default values
            edtGeschaeftsbereich.EditValue = DBUtil.ExecuteScalarSQL(@"SELECT dbo.fnOrgUnitOfUserMandantenNr({0})", Session.User.UserID);

            // check if any selected
            if (DBUtil.IsEmpty(edtGeschaeftsbereich.EditValue) || Convert.ToInt32(edtGeschaeftsbereich.EditValue) < 1)
            {
                // select first possible item
                edtGeschaeftsbereich.EditValue = qryMandanten.DataTable.Rows[0]["Code"];
            }

            // setup dates depending on selected GB (if no date found yet
            if (DBUtil.IsEmpty(edtDatumVon.EditValue) || DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                // no date set, yet, do now search a date
                SetupNextDatumVonBis();
            }

            // enable controls
            EnableDisableControls(true);

            // set focus
            edtDatumVon.Focus();

            // reset status
            SetStatusLabel(null, null);

            // logging
            InsertAbaLog(null, null, null, "Done loading user interface");
        }

        private void edtGeschaeftsbereich_EditValueChanged(object sender, EventArgs e)
        {
            // check if value given
            if (DBUtil.IsEmpty(edtGeschaeftsbereich.EditValue))
            {
                // no value given, reset dates
                edtDatumVon.EditValue = null;
                edtDatumBis.EditValue = null;

                // logging
                InsertAbaLog(null, null, null, "No value for department, reset date-range now");

                // done
                return;
            }

            // logging
            InsertAbaLog(null, null, null, "Neccessary to calculate a new date range");

            // calculating new date range
            SetupNextDatumVonBis();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void InsertAbaLog(string paramIn, string paramOut, Exception exception, string remark)
        {
            try
            {
                // replace specific tags
                if (paramIn != null)
                {
                    // paramIn
                    switch (paramIn)
                    {
                        case "<gb_datrange>":
                            // set Gesch�ftsbereich and date range
                            paramIn = string.Format("Department = '{0}', DateRange = '{1:d}' to '{2:d}'", edtGeschaeftsbereich.Text, edtDatumVon.EditValue, edtDatumBis.EditValue);
                            break;

                        case "<qrynv_useridname>":
                            // set userid, lastname, firstname from non-visa data
                            paramIn = string.Format("UserID = '{0}', LastName = '{1}', FirstName = '{2}'", qryValidiertNicht["UserID"], qryValidiertNicht["LastName"], qryValidiertNicht["FirstName"]);
                            break;
                    }
                }

                // do logging
                InsertAbaLogDB(SchnittstellenCode, paramIn, paramOut, exception, remark);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlAbaStundenlohn", "FailedLoggingToDB", "Es ist ein Fehler beim Logging des Verlaufs aufgetreten.", ex);
            }
        }

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // reset status (due to translated label-text)
            SetStatusLabel(null, null);
        }

        #endregion

        #region Private Methods

        private bool CheckSindStundenErfasst()
        {
            try
            {
                var result = DBUtil.OpenSQL(@"
                DECLARE @FirstOfMonth DATETIME, @LastOfMonth DATETIME, @Mandantennummer INT, @LanguageCode INT;
                SET @FirstOfMonth = {0};
                SET @LastOfMonth = {1};
                SET @Mandantennummer = {2};
                SET @LanguageCode = {3};

                SELECT UserID,
                       MitarbeiterNr,
                       LastName,
                       FirstName,
                       OrgUnit  = dbo.fnOrgUnitOfUser(UserID, 0),
                       Lohntyp  = dbo.fnGetLOVMLText('BenutzerLohnTyp', USR.LohnTypCode, @LanguageCode)
                FROM dbo.XUser USR WITH (READUNCOMMITTED)
                WHERE (Austrittsdatum IS NULL OR Austrittsdatum >= @FirstOfMonth)
                  AND Eintrittsdatum <= @LastOfMonth
                  AND (dbo.fnBDEGetHistMandantenNrPerDate(USR.UserID, @FirstOfMonth, NULL) = @Mandantennummer -- filter MandatenNr at first day of month
                       OR dbo.fnBDEGetHistMandantenNrPerDate(USR.UserID, @LastOfMonth, NULL) = @Mandantennummer) -- filter MandatenNr at last day of month
                  AND LohntypCode = 1 -- Monatslohn
                  AND USR.UserID NOT IN (SELECT LEI.UserID
                                         FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                         WHERE LEI.Datum BETWEEN @FirstOfMonth AND @LastOfMonth);
                ", edtDatumVon.DateTime.Date, edtDatumBis.DateTime.Date, edtGeschaeftsbereich.EditValue, Session.User.LanguageCode);

                if (result.Count > 0)
                {
                    qryValidiertNicht.Fill(DateTime.MinValue, DateTime.MinValue, 1, 1);

                    bool canInsert = qryValidiertNicht.CanInsert;
                    qryValidiertNicht.CanInsert = true;

                    foreach (DataRow row in result.DataTable.Rows)
                    {
                        qryValidiertNicht.Insert();

                        qryValidiertNicht["UserID"] = row["UserID"];
                        qryValidiertNicht["MANr"] = row["MitarbeiterNr"];
                        qryValidiertNicht["LastName"] = row["LastName"];
                        qryValidiertNicht["FirstName"] = row["FirstName"];
                        qryValidiertNicht["OrgUnit"] = row["OrgUnit"];
                        qryValidiertNicht["Lohntyp"] = row["Lohntyp"];
                        qryValidiertNicht["Freigabe"] = false;
                        // qryValidiertNicht["Visum"] = false;

                        qryValidiertNicht.RowModified = false;
                        qryValidiertNicht.Row.AcceptChanges();
                    }

                    qryValidiertNicht.CanInsert = canInsert;

                    KissMsg.ShowInfo(Name, "NochUnerfassteZeitMA", @"
            Die angezeigten Mitarbeiter sind im {0} aktiv, haben aber noch keine Zeit erfasst.
            Diese Mitarbeiter m�ssen ihre Arbeitszeit erfassen bevor die Daten exportiert werden k�nnen", edtDatumVon.Text);

                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void EnableDisableControls(bool enabled)
        {
            // enable/disable controls
            edtDatumVon.Enabled = enabled;
            edtGeschaeftsbereich.Enabled = enabled;
            grdNichtVisiert.Enabled = enabled;
            btnDatenPruefen.Enabled = enabled;
            btnDatenExport.Enabled = enabled;
            btnGotoBDEErfassung.Enabled = enabled;

            // Export stornieren (only admin can use this button)
            btnStornoExport.Enabled = enabled && Session.User.IsUserAdmin;

            // do it
            ApplicationFacade.DoEvents();
        }

        private void InsertBulkVisum()
        {
            // do inserts of bulk visum and get affected rows (-1 = err, >= 0 = ok)
            SqlQuery qryBulkVisum = new SqlQuery();
            qryBulkVisum.FillTimeOut = 300; 			// 5min due to possible timeout!

            if (!qryBulkVisum.Fill(@"
                    -- result output table
                    DECLARE @Result TABLE
                    ( [Done] INT )

                    -- execute
                    INSERT INTO @Result
                      EXEC dbo.spABAInsertBulkVisum {0}, {1}, {2}, {3}

                    -- show result
                    SELECT * FROM @Result", Session.User.LogonName, edtGeschaeftsbereich.EditValue, edtDatumVon.EditValue, edtDatumBis.EditValue))
            {
                throw new Exception("Error executing bulk-visa query, cannot proceed.");
            }

            // define result
            int countRows = -1;

            // check result
            if (!qryBulkVisum.IsEmpty && qryBulkVisum.DataTable.Columns.Contains("Done"))
            {
                qryBulkVisum.Last(); //skip VerID records
                countRows = Convert.ToInt32(qryBulkVisum["Done"]);
            }

            // logging
            InsertAbaLog(null, null, null, string.Format("Bulk visa done, affected rows: {0}", countRows));

            // check if error
            if (countRows < 0)
            {
                // something was wrong
                throw new Exception("Error: InsertBulkVisum() could not be completed successfully, database returned an error");
            }
        }

        private void SetStatusLabel(string messageName, string defaultMessageText)
        {
            SetStatusLabel(messageName, defaultMessageText, null);
        }

        private void SetStatusLabel(string messageName, string defaultMessageText, params object[] parameters)
        {
            // check if we have a valid name and text
            if (DBUtil.IsEmpty(messageName) || DBUtil.IsEmpty(defaultMessageText))
            {
                // no valid name or text, use default
                defaultMessageText = "-";
            }
            else
            {
                // get text from database
                defaultMessageText = KissMsg.GetMLMessage("CtlAbaStundenlohn", messageName, defaultMessageText, KissMsgCode.Text, parameters);
            }

            // setup text
            lblStatusBar.Text = string.Format(" {0}: {1}", _statusText, defaultMessageText);

            // do it
            ApplicationFacade.DoEvents();
        }

        private void SetupNextDatumVonBis()
        {
            try
            {
                // validate gb
                if (DBUtil.IsEmpty(edtGeschaeftsbereich.EditValue) || Convert.ToInt32(edtGeschaeftsbereich.EditValue) < 1)
                {
                    // logging
                    InsertAbaLog("<gb_datrange>", null, null, "Error: Calculating new date range not possible, invalid number given.");
                    return;
                }

                // logging
                InsertAbaLog("<gb_datrange>", null, null, "Calculating new date range...");

                edtDatumVon.EditValue = GetNextDatumVon(Convert.ToInt32(edtGeschaeftsbereich.EditValue), "stunden");
                edtDatumBis.EditValue = GetLastDayOfMonth(edtDatumVon.DateTime, false);

                // validate (von < bis)
                if (DateTime.Compare(Convert.ToDateTime(edtDatumVon.EditValue), Convert.ToDateTime(edtDatumBis.EditValue)) >= 0)
                {
                    throw new Exception("Invalid date range, cannot proceed. Start date must be smaller than end date.");
                }

                // logging
                InsertAbaLog("<gb_datrange>", null, null, "Done calculating new date range");
            }
            catch (Exception ex)
            {
                // logging
                InsertAbaLog("<gb_datrange>", null, ex, "Error occured while calculating new date range for current mandant");

                // something went wrong
                KissMsg.ShowError("CtlAbaStundenlohn", "ErrorCalculatingNewDateRange", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);

                // reset values
                edtDatumVon.EditValue = null;
                edtDatumVon.EditValue = null;
            }
        }

        private void UpdateVerbucht(bool removeVerbucht)
        {
            // do inserts of bulk visum and get affected rows (-1 = err, >= 0 = ok)
            SqlQuery qryDoSetVisum = new SqlQuery();
            qryDoSetVisum.FillTimeOut = 300; 			// 5min due to possible timeout!

            if (!qryDoSetVisum.Fill(@"
                    -- result output table
                    DECLARE @Result TABLE
                    ( [Done] INT )

                    -- execute
                    INSERT INTO @Result
                      EXEC spABAUpdateVerbucht {0}, {1}, {2}, {3}, 'stunden', {4}

                    -- show result
                    SELECT * FROM @Result", Session.User.LogonName, edtGeschaeftsbereich.EditValue, edtDatumVon.EditValue, edtDatumBis.EditValue, removeVerbucht))
            {
                throw new Exception("Error executing visa query, cannot proceed.");
            }

            // define result
            int countRows = -1;

            // check result
            if (!qryDoSetVisum.IsEmpty && qryDoSetVisum.DataTable.Columns.Contains("Done"))
            {
                qryDoSetVisum.Last(); //skip VerID records
                countRows = Convert.ToInt32(qryDoSetVisum["Done"]);
            }

            // logging
            InsertAbaLog(string.Format("RemoveVerbucht={0} (False=set date, True=remove date)", removeVerbucht), null, null, string.Format("Update 'Verbucht' done, affected rows: {0}", countRows));

            // check if error
            if (countRows < 0)
            {
                // something was wrong
                throw new Exception("Error: UpdateVerbucht() could not be completed successfully, database returned an error");
            }
        }

        /// <summary>
        /// Validiert die Usereingaben (Panel Einstellungen).
        /// - Feld Monat muss einen Wert enthalten.
        /// - Gesch�ftsbereich muss gew�hlt sein.
        /// </summary>
        /// <returns></returns>
        private bool ValidateSettings()
        {
            try
            {
                // move focus to apply datetime
                edtGeschaeftsbereich.Focus();

                // validate
                if (DBUtil.IsEmpty(edtDatumVon.EditValue))
                {
                    // no month entered, cannot continue
                    KissMsg.ShowInfo("CtlAbaStundenlohn", "MissingDateFromTo", "Das Feld 'Monat' verlangt eine Eingabe.");

                    // set focus
                    edtDatumVon.Focus();

                    // do not continue
                    throw new KissCancelException("Missing value for date, cannot continue with query.");
                }

                // calculate dates for proper searching of month
                edtDatumVon.EditValue = GetFirstDayOfMonth(Convert.ToDateTime(edtDatumVon.EditValue), false);
                edtDatumBis.EditValue = GetLastDayOfMonth(Convert.ToDateTime(edtDatumVon.EditValue), false);

                // check geschaeftsbereich
                DBUtil.CheckNotNullField(edtGeschaeftsbereich, lblGeschaeftsbereich.Text);

                // if we are here, everything is ok
                return true;
            }
            catch (Exception ex)
            {
                // logging
                InsertAbaLog("<gb_datrange>", null, ex, "Error occured in validating settings");

                // something is wrong, cannot continue
                return false;
            }
        }

        /// <summary>
        /// Validiert die Eingaben des Users und die Daten.
        /// 1. Die Eingabepr�fung pr�ft die vom User eingegebenen Daten im Panel Einstellungen.
        /// 2. Die Validierung der Daten besteht aus:
        /// 2.1 Alle BDE Leistungen der Mandantennummer im Zeitraum sind visiert.
        /// 2.2 Alle BDE Leistungen der Mandantennummer im Zeitraum stimmen im Feld 'KeinExport' mit entsprechendem XUser im Feld 'KeinBDEExport' �berein.
        /// </summary>
        /// <returns>true wenn die Daten OK sind</returns>
        private bool ValidateSettingsAndData()
        {
            // store last cursor
            Cursor lastCursor = Cursor.Current;

            try
            {
                // CURSOR:
                Cursor.Current = Cursors.WaitCursor;

                // SETTINGS:
                // validate settings
                if (!ValidateSettings())
                {
                    // invalid settings, message already shown
                    throw new Exception("Invalid settings, cannot continue loading data.");
                }

                // VISUM
                // set status
                SetStatusLabel("StatusGettingCheckData", "Daten zum �berpr�fen werden geladen...");

                // load data with no visum
                if (!qryValidiertNicht.Fill(edtDatumVon.EditValue, edtDatumBis.EditValue, edtGeschaeftsbereich.EditValue, Session.User.LanguageCode))
                {
                    throw new Exception("Error loading data to check visa!");
                }

                grvNichtVisiert.BestFitColumns();

                // validate visum (only those who entered any data are important, bulk-visum is not important here)
                if (qryValidiertNicht.Count > 0)
                {
                    // logging
                    InsertAbaLog("<gb_datrange>", null, null, string.Format("Invalid data found: {0} row(s)", qryValidiertNicht.Count));

                    // show info
                    KissMsg.ShowInfo("CtlAbaStundenlohn", "InvalidDataFound", "Es wurden Daten gefunden, welche noch korrigiert werden m�ssen. Ein Export der Stunden ist nicht m�glich.");
                    return false;
                }

                // DONE
                // logging
                InsertAbaLog("<gb_datrange>", null, null, "Success, no data without visa found");

                // if we are here, everything is ok and valid
                return true;
            }
            catch (Exception ex)
            {
                // logging
                InsertAbaLog("<gb_datrange>", null, ex, "Error occured in validating settings/visum");

                // set status
                SetStatusLabel("StatusValidateSetVisErrorOccured", "Error: �berpr�fung fehlgeschlagen!");

                // something went wrong
                KissMsg.ShowError("CtlAbaStundenlohn", "ErrorCheckingSettingsVisum", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
            finally
            {
                // reset cursor
                Cursor.Current = lastCursor;

                // reset status
                SetStatusLabel(null, null);
            }
        }

        #endregion

        #endregion
    }
}