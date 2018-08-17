using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Kiss.Infrastructure;

using Kiss.Interfaces.UI;

using KiSS.DBScheme;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Schnittstellen.Abacus.KlientenStammdaten;

namespace KiSS4.Schnittstellen.Abacus.ASCII
{
    /// <summary>
    /// Control für die Abacus-Fakturierung.
    /// TODO Achtung: Logik ist zum Teil von <see cref="CtlAbaKlientenStammdaten"/> kopiert.
    /// </summary>
    public partial class CtlAbaFakturierung : CtlAbaASCIIBase
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly DataHandler _dataHandler;

        private readonly bool _kissConfigDebugFlag;

        private readonly string _statusMessageEventAccount = KissMsg.GetMLMessage("CtlAbaFakturierung", "StatusMessageEventAccount", "Konto");

        private readonly string _statusMessageEventAddress = KissMsg.GetMLMessage("CtlAbaFakturierung", "StatusMessageEventAddress", "Adresse");

        private readonly string _statusMessageEventFakturierung = KissMsg.GetMLMessage("CtlAbaFakturierung", "StatusMessageEventFakturierung", "Fakturierung");

        private readonly string _statusMessageEventGeneral = KissMsg.GetMLMessage("CtlAbaFakturierung", "StatusMessageEventGeneral", "Allgemein");

        private readonly string _statusMessageEventSender = KissMsg.GetMLMessage("CtlAbaFakturierung", "StatusMessageEventSender_v01", "Bereich");

        private readonly string _statusText = KissMsg.GetMLMessage("CtlAbaFakturierung", "StatusText", "Status");

        private int _debugSelectedClientsCount;

        private DateTime _debugStartTime;

        private Exporter _klientenStammdatenExporter;

        private bool _preventUpdateDetails;

        // do not update details (e.g. if selecting all rows)
        private List<DataRow> _selectedRows;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlAbaFakturierung"/> class.
        /// </summary>
        public CtlAbaFakturierung()
        {
            // init components
            InitializeComponent();

            SetupGrid();

            // because of display error in designer-layout, we set datasource and fieldname here (good, because of Constants-value)
            ctlGotoFall.DataSource = qryFakturierung;
            ctlGotoFall.DataMember = Constants.colBaPersonID;

            // read config value
            _kissConfigDebugFlag = DBUtil.GetConfigBool(Constants.KissConfig_DebugFlag, false);

            // create new instance of DataHandler
            _dataHandler = new DataHandler();
        }

        // Declare a delegate to be used with BeginInvoke
        private delegate void SetStatusDelegate(String defaultMessageText);

        private enum SelectionMode
        {
            InvertSelection = -1,
            SelectNone = 0,
            SelectAll = 1,
        }

        /// <summary>
        /// Get the flag if export is still running
        /// </summary>
        private Boolean IsExportRunning
        {
            get { return _klientenStammdatenExporter != null || bgwFakturierungExport.IsBusy; }
        }

        /// <summary>
        /// LOV AbaSchnittstellenCode (für Logging verwendet)
        /// </summary>
        private int SchnittstellenCode
        {
            get { return 4; }
        }

        /// <summary>
        /// Translate this instance
        /// </summary>
        public override void Translate()
        {
            // apply translation
            base.Translate();

            // reset status (due to translated label-text)
            SetStatusLabel(null, null);
        }

        /// <summary>
        /// The event that occures when progress of export worker thread reports a new step
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // validate event arguments
            if (e == null)
            {
                throw new ArgumentNullException("e", "The event argument is empty, cannot set new progress.");
            }

            String statusMessageEvent;
            var workingPart = e.UserState as Exporter.WorkingPart?;

            if (workingPart != null)
            {
                // get status event
                switch (workingPart.Value)
                {
                    case Exporter.WorkingPart.Step1_ExportAddress:
                        statusMessageEvent = _statusMessageEventAddress;
                        break;

                    case Exporter.WorkingPart.Step2_ExportAccount:
                        statusMessageEvent = _statusMessageEventAccount;
                        break;

                    default:
                        throw new InvalidEnumArgumentException("The given working part of the new progress cannot be handled.");
                }
            }
            else
            {
                statusMessageEvent = _statusMessageEventFakturierung;
            }

            // apply new value to progressbar
            pgbExport.Value = e.ProgressPercentage;

            // set status label
            SetStatusLabel("ExportStatusPercent", "{0}% des Exports durchgeführt ({1}: {2})", e.ProgressPercentage, _statusMessageEventSender, statusMessageEvent);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // logging
            DataHandler.InsertAbaLog(String.Format("MandantNr='{0}', AbacusUser='{1}'", edtSelectMandant.Text, edtUserName.Text), null, null, "CtlAbaFakturierung.btnCancel_Click");

            // check if we have an exporter (only this can be canceled)
            if (_klientenStammdatenExporter == null)
            {
                // disable button
                btnCancel.Enabled = false;

                // logging
                DataHandler.InsertAbaLog(null, null, null, "CtlAbaFakturierung.btnCancel_Click - rised without having exporter instance");

                // do not continue
                return;
            }

            // confirm cancel export
            if (!KissMsg.ShowQuestion("CtlAbaFakturierung", "ConfirmCancelExport", "Wollen Sie den laufenden Export wirklich abbrechen?", true))
            {
                // logging
                DataHandler.InsertAbaLog(null, null, null, "CtlAbaFakturierung.btnCancel_Click - user did not cancel");

                // not canceled, do nothing more
                return;
            }

            // cancel export
            DoCancelExport();
        }

        /// <summary>
        /// The click event on btnDatenExport, do export all selected clients
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnDatenExport_Click(object sender, EventArgs e)
        {
            // setup waiting cursor
            Cursor.Current = Cursors.WaitCursor;
            Boolean isExporting = false;			// flag to enable/disable controls depending on export started

            try
            {
                // logging
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}', AbacusUser='{1}'", edtSelectMandant.Text, edtUserName.Text), null, null, "CtlAbaFakturierung.btnDatenExport_Click");

                // set status
                SetStatusLabel("PrepareExportDoValidations", "Der Export wird vorbereitet...");

                // disable controls but allow cancel
                EnableControls(false, true);

                // VALIDATE
                // validate if any MandantenNummer is selected
                if (DBUtil.IsEmpty(edtSelectMandant.EditValue))
                {
                    // show info, invalid MandantenNummer
                    KissMsg.ShowInfo("CtlAbaFakturierung", "NoMandantenNummerGivenOnExport", "Es ist keine gültige Mandanten-Nummer ausgwählt, der Export kann nicht durchgeführt werden.");

                    // focus
                    edtSelectMandant.Focus();

                    // cancel
                    return;
                }

                // PREPARATIONS
                _selectedRows = GetSelectedRows();

                if (_selectedRows.Count == 0)
                {
                    KissMsg.ShowInfo("CtlAbaFakturierung", "NoRowSelected", "Es ist keine Zeile zum exportieren ausgewählt.");
                    return;
                }

                // get the current selected MandantenNummer
                var mandantenNummer = Convert.ToInt32(edtSelectMandant.EditValue);

                // DO START EXPORT (ASYNC)
                // validate MandantenNummer for given range
                if (!DataHandler.IsMandantenNummerValid(mandantenNummer))
                {
                    throw new ArgumentOutOfRangeException(String.Format("The selected MandantenNummer '{0}' is invalid and out of range", mandantenNummer));
                }

                //Prüfung auf vorhandene DebitorNr in jedem Fall machen
                if (_selectedRows.Any(x => DBUtil.IsEmpty(x["DebitorNr"])))
                {
                    KissMsg.ShowInfo(
                        "CtlAbaFakturierung",
                        "MissingDebitorNr",
                        @"Es gibt Rechnungen mit fehlender Debitornummer. Ohne Debitornummer kann keine Faktura exportiert werden.
Bitte erfassen Sie eine Debitornummer.");

                    // cancel
                    return;
                }

                if (edtKSSAusfuehren.Checked)
                {
                    // Klientenstammdaten-Schnittstelle ausführen
                    if (DBUtil.IsEmpty(edtUserName.EditValue))
                    {
                        // show info, invalid MandantenNummer
                        KissMsg.ShowInfo(
                            "CtlAbaFakturierung",
                            "NoUserNameGivenOnExport",
                            "Es ist kein gültiger Abacus-Benutzer angegeben, der Export kann nicht durchgeführt werden.");

                        // focus
                        edtUserName.Focus();

                        // cancel
                        return;
                    }
                    if (DBUtil.IsEmpty(edtUserPassword.EditValue))
                    {
                        // show info, invalid MandantenNummer
                        KissMsg.ShowInfo(
                            "CtlAbaFakturierung",
                            "NoUserPasswordGivenOnExport",
                            "Es ist kein gültiges Abacus-Benutzerpasswort angegeben, der Export kann nicht durchgeführt werden.");

                        // focus
                        edtUserPassword.Focus();

                        // cancel
                        return;
                    }

                    if (!KissMsg.ShowQuestion(
                        "CtlAbaFakturierung",
                        "ConfirmStartExport",
                        "Es werden '{1}' Klienten über die Klientenstammdate-Schnittstelle exportiert. Fortfahren?{0}{0}Achtung: Die Verarbeitung kann je nach Anzahl der selektierten Einträge einen Moment dauern!",
                        0,
                        0,
                        true,
                        Environment.NewLine,
                        _selectedRows.Count))
                    {
                        // do not continue
                        return;
                    }

                    // start time messuring (used for debugging) and count of selected clients
                    _debugStartTime = DateTime.Now;
                    _debugSelectedClientsCount = _selectedRows.Count;

                    // logging
                    DataHandler.InsertAbaLog(
                        String.Format(
                            "MandantNr='{0}', AbacusUser='{1}', AmountOfClients='{2}'",
                            edtSelectMandant.Text,
                            edtUserName.Text,
                            _selectedRows.Count),
                        null,
                        null,
                        "CtlAbaFakturierung.btnDatenExport_Click - starting Abacus export");

                    // set status
                    SetStatusLabel("DoRunExport", "Der Klientenstammdaten-Export wird gestartet...");

                    // create new instance of Exporter
                    _klientenStammdatenExporter = new Exporter(Convert.ToString(edtUserName.EditValue), Convert.ToString(edtUserPassword.EditValue));

                    //Anhängen der Events des backgoundworkers der ein traken des updates ermöglicht
                    _klientenStammdatenExporter.ExportWorker.RunWorkerCompleted += KlientenStammdatenExporter_RunWorkerCompleted;
                    _klientenStammdatenExporter.ExportWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
                    _klientenStammdatenExporter.StatusChanged += KlientenStammdatenExporter_StatusChanged;

                    // get all selected clients
                    var allSelectedClients = GetSelectedClients(_selectedRows);

                    // init exporter with selected clients and mandantenNummer
                    _klientenStammdatenExporter.Init(allSelectedClients, mandantenNummer);

                    // export is initalized and therefore started
                    isExporting = true;

                    // start export thread
                    _klientenStammdatenExporter.ExportWorker.RunWorkerAsync();
                }
                else
                {
                    //KlientenStammdatenSchnittstelle is skipped
                    ExportFakturierung(_selectedRows);
                }
            }
            catch (SoapException soapEx)
            {
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
                // export failed, show error
                KissMsg.ShowError("CtlAbaFakturierung", "ErrorDoingExportOccured", "Es ist ein Fehler in der Verarbeitung aufgetreten. Der Export konnte möglicherweise nicht für alle gewählten Klienten erfolgreich durchgeführt werden.", ex);
            }
            finally
            {
                // enable/disable controls depending on export-started, still allow cancel
                EnableControls(!isExporting, true);

                // reset status
                SetStatusLabel(null, null);

                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            // select none
            SelectItems(SelectionMode.SelectNone);
        }

        private void btnInvertSelection_Click(object sender, EventArgs e)
        {
            // invert selection
            SelectItems(SelectionMode.InvertSelection);
        }

        private void btnLoadRechnungen_Click(object sender, EventArgs e)
        {
            try
            {
                // logging
                DataHandler.InsertAbaLog(null, null, null, "CtlAbaFakturierung.btnLoadRechnungen_Click");

                // disable controls
                EnableControls(false, false);

                // set appearance of grid
                SetGridAppearance();

                // remove datasource from grid
                grdFakturierung.DataSource = null;

                // validate selected MandantenNummer
                if (DBUtil.IsEmpty(edtSelectMandant.EditValue))
                {
                    // no MandantenNummer given, cannot continue
                    KissMsg.ShowError("CtlAbaFakturierung", "NoMandantenNummerSelected", "Es ist keine gültige Mandanten-Nummer ausgewählt.{0}{0}Sie sind entweder keiner Abteilung zugewiesen oder Sie besitzen zuwenig Rechte im System.", null, null, 0, 0, Environment.NewLine);
                    return;
                }

                // set status
                SetStatusLabel("LoadingDataFromMandantenNr", "Die Rechnungen für den gewählten Mandanten '{0}' werden geladen...", edtSelectMandant.Text);

                try
                {
                    // logging
                    DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", edtSelectMandant.Text), null, null, "CtlAbaFakturierung.btnLoadRechnungen_Click - try to load data for given MandantNr");

                    // load data
                    var fakturaCode = GetFakturaCode();
                    qryFakturierung.Fill(Convert.ToInt32(edtSelectMandant.EditValue), fakturaCode);
                }
                catch (Exception ex)
                {
                    // show error and cancel
                    KissMsg.ShowError("CtlAbaFakturierung", "ErrorLoadingClientsFromDatabase", "Es ist ein Fehler in der Verarbeitung aufgetreten, die Rechnungen für den gewählten Mandanten konnten nicht geladen werden.", ex);

                    // logging
                    DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", edtSelectMandant.Text), null, ex, "CtlAbaFakturierung.btnLoadRechnungen_Click - call DataHandler.FillQueryWithAllKlientenOfMandant");
                    return;
                }

                // setup query to allow selection of clients
                qryFakturierung.CanUpdate = true;
                qryFakturierung.BatchUpdate = true;

                // apply datasource again to grid
                grdFakturierung.DataSource = qryFakturierung;
            }
            catch (SoapException soapEx)
            {
                if (soapEx.Detail != null)
                {
                    var detail = soapEx.Detail;
                    string soapMessage = detail.InnerText;

                    throw new KlientenStammdatenException(
                        string.Format("Login Failed. Error: {0}", soapMessage));
                }

                // logging
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", edtSelectMandant.Text), null, soapEx, "CtlAbaFakturierung.btnLoadRechnungen_Click caught exception with loading data");
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError("CtlAbaFakturierung", "ExceptionLoadClients", "Es ist ein Fehler beim Laden der Einträge aufgetreten.", ex);

                // logging
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", edtSelectMandant.Text), null, ex, "CtlAbaFakturierung.btnLoadRechnungen_Click caught exception with loading data");
            }
            finally
            {
                // reenable controls
                EnableControls(true, false);

                // reset counter
                UpdateCounter();

                // reset status
                SetStatusLabel(null, null);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            // select all
            SelectItems(SelectionMode.SelectAll);
        }

        /// <summary>
        /// The Control_Leave event, occures when control is no longer active control on Form
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlAbaFakturierung_Leave(object sender, EventArgs e)
        {
            // if export is still running, cancel because of leaving control
            if (IsExportRunning)
            {
                // cancel export because of security reason
                DoCancelExport();

                // log this event
                DataHandler.InsertAbaLog(null, null, null, "CtlAbaFakturierung_Leave(...) - user wants to close control while export is running!");

                // show information about this event
                KissMsg.ShowError("CtlAbaFakturierung", "LeavingControlWhileExportRunning", "Bitte schliessen Sie diese Maske nicht während einem laufenden Export!{0}{0}Es wird nun gewartet, bis der Export abgebrochen wurde.", null, null, 0, 0, Environment.NewLine);

                Int32 counter = 0;

                // loop until export has finished or wait about 8min (2000*250ms)
                while (IsExportRunning || counter > 2000)
                {
                    // wait before checking again
                    System.Threading.Thread.Sleep(250);

                    // set state
                    SetStatusLabel("WaitingControlLeaveExportCancel", "Es wird gewartet, bis der Export beendet ist ('{0}')!", counter);

                    // count up
                    counter++;
                }

                // log this event
                DataHandler.InsertAbaLog(null, null, null, String.Format("CtlAbaFakturierung_Leave(...) - no longer waiting until export finished, current state is: IsExportRunning={0}, counter={1}!", IsExportRunning, counter));
            }
        }

        /// <summary>
        /// The Control_Load event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlAbaFakturierung_Load(object sender, EventArgs e)
        {
            // logging
            DataHandler.InsertAbaLog(null, null, null, "CtlAbaFakturierung_Load(...) - loading user interface");

            // set status
            SetStatusLabel("LoadingFormWait", "Bitte warten, die Schnittstelle wird vorbereitet...");

            // init dropdown for MandantenNummer
            InitDropdownMandantenNummer();

            // GUI
            // update counter label
            UpdateCounter();

            // reset status
            SetStatusLabel(null, null);

            edtKSSAusfuehren.Visible = Session.User.IsUserBIAGAdmin;
        }

        /// <summary>
        /// Do cancel current running export
        /// </summary>
        private void DoCancelExport()
        {
            // disable button because, we set as canceled and wait for finished...
            btnCancel.Enabled = false;

            // set status
            SetStatusLabel("WaitingForExportCancel", "Der laufende Export wird abgebrochen...");

            // logging
            DataHandler.InsertAbaLog(null, null, null, "CtlAbaFakturierung.DoCancelExport(...) - user did cancel export");

            // cancel export by setting flag on exporter
            _klientenStammdatenExporter.SetExportCanceled();

            bgwFakturierungExport.CancelAsync();

            // do it
            ApplicationFacade.DoEvents();
        }

        private void edtSelectMandant_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                // logging
                DataHandler.InsertAbaLog(null, null, null, "CtlAbaFakturierung.edtSelectMandant_EditValueChanging");

                // disable controls
                EnableControls(false, false);

                //Falls der Benutzer den gewählten Mandant ändert muss die Liste geleert werden
                //da dies sonst eine Dateninkosistenz zur Folge hätte.
                //Um den Benutzer jedoch davor zu warnen wird zuerst eine MessageBox angezeigt wo der
                //Benutzer entscheiden kann ob er wirklich den Mndant wechseln will falls sich
                //Einträge in der Liste befinden.

                // check if we have a datasource set
                if (grdFakturierung.DataSource == null)
                {
                    // no datasource set, do not continue
                    return;
                }

                if (((SqlQuery)grdFakturierung.DataSource).Count > 0)
                {
                    if (!KissMsg.ShowQuestion("CtlAbaFakturierung", "ConfirmRefreshMandant", "Möchten Sie wirklich den Mandanten wechseln und dabei die Liste mit den Klienten leeren?", true))
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        // set status
                        SetStatusLabel("ChangingMandantNr", "Die Liste wird aufgrund eines Mandantenwechsels zurückgesetzt...");

                        // do reset grid
                        ResetGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError("CtlAbaFakturierung", "ExceptionChangingMandant", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);

                // logging
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", edtSelectMandant.Text), null, ex, "CtlAbaFakturierung.edtSelectMandant_EditValueChanging caught exception with resetting data");
            }
            finally
            {
                // reenable controls
                EnableControls(true, false);

                // reset status
                SetStatusLabel(null, null);
            }
        }

        /// <summary>
        /// Enable or disable controls depending on flag to ensure no actions are handled while performing a task
        /// </summary>
        /// <param name="enabled">Set if controls are enabled</param>
        /// <param name="canCancelAction">Set if cancel-button is enabled, even if others are disabled</param>
        private void EnableControls(Boolean enabled, Boolean canCancelAction)
        {
            // edit mode for input-controls
            EditModeType applyEditMode = enabled ? EditModeType.Normal : EditModeType.ReadOnly;

            // enable/disable controls
            edtSelectMandant.EditMode = applyEditMode;
            edtUserName.EditMode = applyEditMode;
            edtUserPassword.EditMode = applyEditMode;

            // buttons
            btnLoadRechnungen.Enabled = enabled;
            btnSelectAll.Enabled = enabled;
            btnDeselectAll.Enabled = enabled;
            btnInvertSelection.Enabled = enabled;
            btnDatenExport.Enabled = enabled;

            // button cancel is special
            btnCancel.Enabled = !enabled && canCancelAction;

            // others
            grdFakturierung.Enabled = enabled;
            ctlGotoFall.Enabled = enabled;

            // do update gui
            ApplicationFacade.DoEvents();
        }

        private void ExportFakturierung(List<DataRow> selectedRows)
        {
            SetStatusLabel("StatusExportParseRowsWriteFile", "Daten werden ausgewertet und die Export-Datei wird geschrieben...");
            bgwFakturierungExport.RunWorkerAsync(selectedRows);
        }

        private void FakturierungExportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                InsertAbaLog("Fakturierung started.");

                var selectedRows = e.Argument as List<DataRow>;

                if (selectedRows == null)
                {
                    InsertAbaLog("List of selected rows was empty.");
                    return;
                }

                // get temp file to write data into
                var tempFile = Path.GetTempFileName();

                // setup counter of lines written
                int lineCount = 1;

                int rowIndex = 0;
                var rowCount = selectedRows.Count;

                foreach (var row in selectedRows)
                {
                    if (e.Cancel)
                    {
                        return;
                    }

                    // count up rows
                    rowIndex++;

                    // set progress bar
                    var progress = (int)(100f / rowCount * rowIndex);
                    bgwFakturierungExport.ReportProgress(progress);

                    if (!Utils.ConvertToBool(row[Constants.colDoExport]))
                    {
                        continue;
                    }

                    var bdeLeistungIds = row["BDELeistungIDs"] as string;

                    if (bdeLeistungIds != null)
                    {
                        var qryBdeLeistung = DBUtil.OpenSQL(string.Format(@"
                            SELECT BLE.Anzahl, BLE.Dauer, BLE.Datum, BLE.Bemerkung, BLA.KTRStandard, PRS.DebitorNr, BLE.BDELeistungID
                            FROM dbo.BDELeistung             BLE WITH(READUNCOMMITTED)
                              INNER JOIN dbo.BDELeistungsart BLA WITH(READUNCOMMITTED) ON BLA.BDELeistungsartID = BLE.BDELeistungsartID
                              INNER JOIN dbo.BaPerson        PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = BLE.BaPersonID
                            WHERE BLE.BDELeistungID IN ({0});", bdeLeistungIds));

                        var hatNegativBetrag =
                            qryBdeLeistung.DataTable.Rows.Cast<DataRow>()
                                .Any(x => Utils.ConvertToInt(x[DBO.BDELeistung.Anzahl]) < 0 || Utils.ConvertToDecimal(x[DBO.BDELeistung.Dauer]) < 0);

                        var auftragsart = hatNegativBetrag ? "G" : "N";
                        var sprachCode = Utils.ConvertToInt(row[DBO.BaPerson.SprachCode]);
                        var sprache = sprachCode == 3 ? "I" : sprachCode == 2 ? "F" : "D";
                        var kundennummer = qryBdeLeistung.DataTable.Rows.Cast<DataRow>()
                                .Select(x => x["DebitorNr"]).FirstOrDefault();
                        var hatErgaenzungsLeistungen = Utils.ConvertToBool(row[DBO.BaPerson.ErgaenzungsLeistungen]);
                        var ablaufnummer = hatErgaenzungsLeistungen ? 10 : 12;

                        // Kopfdaten
                        AppendToFile(
                            SchnittstellenCode,
                            tempFile,
                            string.Format("{0},Kopf_Daten,{1},{2},{3},{4},0",
                                lineCount,
                                auftragsart,
                                kundennummer,
                                ablaufnummer,
                                sprache));
                        lineCount++;

                        // Positionsdaten
                        foreach (DataRow bdeLeistungRow in qryBdeLeistung.DataTable.Rows)
                        {
                            var leistungsart = bdeLeistungRow[DBO.BDELeistungsart.KTRStandard];
                            var datum = Utils.ConvertToDateTime(bdeLeistungRow[DBO.BDELeistung.Datum]);
                            var anzahl = bdeLeistungRow[DBO.BDELeistung.Anzahl] as int?;
                            var dauer = bdeLeistungRow[DBO.BDELeistung.Dauer] as decimal?;
                            var bdeLeistungID = bdeLeistungRow[DBO.BDELeistung.BDELeistungID] as int?;

                            AppendToFile(
                                SchnittstellenCode,
                                tempFile,
                                string.Format("{0},Pos_Daten,A,{1},{2:dd.MM.yyyy},{3:0.####},{4},0",
                                    lineCount,
                                    leistungsart,
                                    datum,
                                    (decimal?)anzahl ?? dauer,
                                    bdeLeistungID));
                            lineCount++;

                            var bemerkung = bdeLeistungRow[DBO.BDELeistung.Bemerkung] as string;

                            if (bemerkung != null)
                            {
                                bemerkung = bemerkung.Replace("\"", "'\"'");
                                AppendToFile(
                                    SchnittstellenCode,
                                    tempFile,
                                    string.Format("{0},OTX_Pos,0,\"{1}\"", lineCount, bemerkung));
                                lineCount++;
                            }
                        }
                    }
                }

                // logging
                InsertAbaLog(string.Format("Rows written to export-file: '{0}'", lineCount));

                bool exportSuccessful = false;

                // check if any lines written
                if (lineCount < 1)
                {
                    // logging
                    InsertAbaLog("No data found, no file will be written. Continue with flag 'Fakturiert'.");

                    // no lines written, continue export without saving file
                    KissMsg.ShowInfo("CtlAbaStundenlohn", "NoDataToExport", "Es wurden keine Daten zum Exportieren gefunden. Der Vorgang wird weiter ausgeführt ohne eine Exportdatei zu schreiben.");
                }
                else
                {
                    // invoke on UI thread
                    Invoke((Action)(() => exportSuccessful = SaveFakturierungFile(tempFile)));
                }

                // logging
                InsertAbaLog("Update 'Fakturiert' on exported data");

                if (exportSuccessful)
                {
                    // update Fakturiert for affected persons
                    UpdateFakturiert(_selectedRows);

                    // logging
                    InsertAbaLog("Export successfully done, start cleanup and finish.");
                }
            }
            catch (Exception ex)
            {
                InsertAbaLog(null, null, null, ex);
                throw;
            }
            finally
            {
                bgwFakturierungExport.ReportProgress(100);
                _selectedRows = null;
            }
        }

        private void FakturierungExportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    SetStatusLabel("FakturierungAbgebrochen", "Der Export wurde abgebrochen.");
                }
                else if (e.Error != null)
                {
                    InsertAbaLog("Error during export", null, null, e.Error);
                    SetStatusLabel("FakturierungUnbekannterFehler", "Es ist ein unbekannter Fehler während der Fakturierung aufgetreten.");
                    KissMsg.ShowError("Error", e.Error);
                }
                else
                {
                    SetStatusLabel("FakturierungErfolgreich", "Der Export wurde erfolgreich durchgeführt.");
                }
            }
            finally
            {
                EnableControls(true, false);
            }
        }

        private int GetFakturaCode()
        {
            if (edtFakturaCode.EditValue == null || Convert.IsDBNull(edtFakturaCode.EditValue))
                return -1;

            return Convert.ToInt32(edtFakturaCode.EditValue);
        }

        private
            List<Klient> GetSelectedClients(List<DataRow> selectedRows)
        {
            var result = new List<Klient>();

            foreach (var row in selectedRows)
            {
                qryGetKlientenstammdaten.Fill(edtSelectMandant.EditValue, row[DBO.BaPerson.BaPersonID], Session.User.LanguageCode);

                foreach (DataRow klientRow in qryGetKlientenstammdaten.DataTable.Rows)
                {
                    result.Add(new Klient(klientRow));
                }
            }

            return result;
        }

        private List<DataRow> GetSelectedRows()
        {
            return qryFakturierung.DataTable.Rows
                .Cast<DataRow>()
                .Where(dataRow => Utils.ConvertToBool(dataRow[Constants.colDoExport]))
                .ToList();
        }

        private void grvKlientenStammdaten_LostFocus(object sender, EventArgs e)
        {
            // update counter label
            UpdateCounter();
        }

        /// <summary>
        /// Init dropdown for MandantenNummer
        /// </summary>
        private void InitDropdownMandantenNummer()
        {
            // remove datasource to clear dropdown
            edtSelectMandant.DataSource = null;

            // fill combobox with states that are available
            qryLoadMandanten = _dataHandler.GetAllAllowedMandantenNummern();

            // setup properties
            edtSelectMandant.Properties.DropDownRows = Math.Min(qryLoadMandanten.Count, 14);
            edtSelectMandant.Properties.DataSource = qryLoadMandanten;

            // setup default values
            edtSelectMandant.EditValue = _dataHandler.GetMandantenNummerOfUser();
        }

        private void InsertAbaLog(string remark, string paramIn = null, string paramOut = null, Exception exception = null)
        {
            try
            {
                // do logging
                InsertAbaLogDB(SchnittstellenCode, paramIn, paramOut, exception, remark);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlAbaStundenlohn", "FailedLoggingToDB", "Es ist ein Fehler beim Logging des Verlaufs aufgetreten.", ex);
            }
        }

        private void KlientenStammdatenExporter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}', AbacusUser='{1}'", edtSelectMandant.Text, edtUserName.Text), null, null, "CtlAbaFakturierung.KlientenStammdatenExporter_RunWorkerCompleted");

                if (e != null && e.Result != null && e.Result is ExporterResult)
                {
                    SetStatusLabel(((ExporterResult)e.Result).ExportMessage);

                    // reset progressbar
                    pgbExport.Value = 0;

                    #region Debug only

                    // finished with export of Address, do show consumed time only if debug=true
                    if (_kissConfigDebugFlag)
                    {
                        // TIME CALCULATIONS:
                        // set end time and calculate time consumption
                        DateTime debugEndTime = DateTime.Now;
                        TimeSpan debugTimeSpan = debugEndTime.Subtract(_debugStartTime);

                        // show message with consumed time informations (no multilanguage!)
                        KissMsg.ShowInfo(
                            String.Format(
                                "Export: Exported '{0}' selected clients in '{1}' seconds",
                                _debugSelectedClientsCount,
                                debugTimeSpan.TotalSeconds));
                    }

                    #endregion

                    // message and setup states depending on export result
                    if (ProcessExporterResult((ExporterResult)e.Result))
                    {
                        ExportFakturierung(_selectedRows);
                    }
                }
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError("CtlAbaFakturierung", "ExportRunWorkerCompleted", "Es ist ein Fehler beim Fertigstellen des Exports aufgetreten.", ex);

                // logging
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}', AbacusUser='{1}'", edtSelectMandant.Text, edtUserName.Text), null, ex, "CtlAbaFakturierung.KlientenStammdatenExporter_RunWorkerCompleted caught exception with completing export");
            }
            finally
            {
                // detach events after completion
                if (_klientenStammdatenExporter != null)
                {
                    _klientenStammdatenExporter.ExportWorker.RunWorkerCompleted -= KlientenStammdatenExporter_RunWorkerCompleted;
                    _klientenStammdatenExporter.ExportWorker.ProgressChanged -= BackgroundWorker_ProgressChanged;
                    _klientenStammdatenExporter.StatusChanged -= KlientenStammdatenExporter_StatusChanged;

                    // reset the exporter-instance, it has finished!
                    _klientenStammdatenExporter = null;
                }

                // reenable controls
                EnableControls(true, false);
            }
        }

        private void KlientenStammdatenExporter_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // validate event arguments
            if (e == null)
            {
                throw new ArgumentNullException("e", "The event argument is empty, cannot set new status.");
            }

            // definie vars
            String statusMessageEvent;

            // get status event
            switch (e.StatusMessageEvent)
            {
                case StatusChangedEventArgs.StatusMessageEvents.GeneralExport:
                    statusMessageEvent = _statusMessageEventGeneral;
                    break;

                case StatusChangedEventArgs.StatusMessageEvents.AddressExport:
                    statusMessageEvent = _statusMessageEventAddress;
                    break;

                case StatusChangedEventArgs.StatusMessageEvents.AccountExport:
                    statusMessageEvent = _statusMessageEventAccount;
                    break;

                default:
                    throw new InvalidEnumArgumentException("The given status message event argument cannot be handled.");
            }

            // create new status message
            String newStatusText = String.Format("{0} ({1}: {2})", e.StatusMessage, _statusMessageEventSender, statusMessageEvent).Trim();

            // depending on calling thread, we have to handle normal or special (otherwise we would get an error!)
            if (e.IsFromAsyncCall)
            {
                // apply status we received from exporter with BeginInvoke (see: http://weblogs.asp.net/justin_rogers/articles/126345.aspx)
                //BeginInvoke(new MethodInvoker(SetStatusLabel), newStatusText);
                Invoke(new SetStatusDelegate(SetStatusLabel), new object[] { newStatusText });
            }
            else
            {
                // apply status we received from exporter
                SetStatusLabel(newStatusText);
            }
        }

        /// <summary>
        /// Methode setzt die Stati im Grid der einzelnen Klienten und informiert über das Wieso und
        /// Warum falls ein Export nicht erfolgreich durchgeführt werden konnte
        /// </summary>
        /// <param name="exporterResult">The <see cref="ExporterResult"/> that was returned by Exporter (expect a valid instance)</param>
        private bool ProcessExporterResult(ExporterResult exporterResult)
        {
            // validate exporter
            if (_klientenStammdatenExporter == null)
            {
                throw new NullReferenceException("No exporter given, cannot continue with further handling after export finished.");
            }

            // get error messages
            List<KlientExceptionPair> errorsAddress = _klientenStammdatenExporter.KlientenMitAddressExportException;
            List<KlientExceptionPair> errorsKonto = _klientenStammdatenExporter.KlientenMitKontoExportException;

            #region Update States In Grid

            // setup states used in grid
            String stateNotExported = KissMsg.GetMLMessage("CtlAbaFakturierung", "ClientStateNotExported_v01", "(-) Nicht exportiert");
            String stateSuccessExport = KissMsg.GetMLMessage("CtlAbaFakturierung", "ClientStateSuccessfullyExported_v01", "(+) Erfolgreich exportiert");
            String stateUnknownExportFailed = KissMsg.GetMLMessage("CtlAbaFakturierung", "ClientStateExportFailed_v01", "(!) Export fehlgeschlagen, Status unbekannt");
            String stateFailedAddress = KissMsg.GetMLMessage("CtlAbaFakturierung", "ClientStateErrorAddress_v01", "(!) Fehlerhafter Adressen-Export");
            String stateFailedAccount = KissMsg.GetMLMessage("CtlAbaFakturierung", "ClientStateErrorAccount_v01", "(!) Fehlerhafter Konto-Export");
            String stateFailedAddressAndAccount = KissMsg.GetMLMessage("CtlAbaFakturierung", "ClientStateErrorAddressAndAccount_v01", "(!) Fehlerhafter Adressen- und Konto-Export");

            try
            {
                // loop datarows and setup states depending on exported and errors...
                foreach (DataRow row in qryFakturierung.DataTable.Rows)
                {
                    // check if row was exported
                    if (!Convert.ToBoolean(row[Constants.colDoExport]))
                    {
                        // this row was not exported, set state for not-exported
                        row[Constants.colStatusExportResult] = stateNotExported;
                        row[Constants.colStatusInsUpd] = stateNotExported;

                        // continue with next entry in foreach
                        continue;
                    }

                    // get id, used to compare
                    Int32? rowBaPersonID = DataHandler.GetInt32Value(row, Constants.colBaPersonID);

                    // validate id
                    if (rowBaPersonID == null)
                    {
                        throw new ArgumentOutOfRangeException("rowBaPersonID", "Invalid BaPersonID detected in row, cannot update states on grid.");
                    }

                    // init flags
                    Boolean hasAddressError = false;
                    Boolean hasAccountError = false;

                    // init error messages
                    String errorMsgAddress = "";
                    String errorMsgAccount = "";

                    // check if we have any address-errors
                    if (errorsAddress != null)
                    {
                        // try to find client wihtin address-errors
                        foreach (KlientExceptionPair kep in errorsAddress)
                        {
                            // compare id
                            if (kep.KlientWithExportError.BaPersonID != null &&
                                kep.KlientWithExportError.BaPersonID.Value == rowBaPersonID.Value)
                            {
                                // client is in error-list, set flag
                                hasAddressError = true;

                                // set error message
                                errorMsgAddress = kep.ExceptionOfExport.Message;

                                // stop loop
                                break;
                            }
                        }
                    }

                    // check if we have any account-errors
                    if (errorsKonto != null)
                    {
                        // try to find client within account-errors
                        foreach (KlientExceptionPair kep in errorsKonto)
                        {
                            // compare id
                            if (kep.KlientWithExportError.BaPersonID != null &&
                                kep.KlientWithExportError.BaPersonID.Value == rowBaPersonID.Value)
                            {
                                // client is in error-list, set flag
                                hasAccountError = true;

                                // set error message
                                errorMsgAccount = kep.ExceptionOfExport.Message;

                                // stop loop
                                break;
                            }
                        }
                    }

                    // check result
                    if (!hasAddressError && !hasAccountError)
                    {
                        // check if general error in exporter
                        if (exporterResult.IsExportFailed)
                        {
                            // unknown state
                            row[Constants.colStatusExportResult] = stateUnknownExportFailed;
                            row[Constants.colStatusInsUpd] = stateUnknownExportFailed;
                        }
                        else
                        {
                            // successfully exported
                            row[Constants.colStatusExportResult] = stateSuccessExport;
                            row[Constants.colStatusInsUpd] = stateSuccessExport;
                        }
                    }
                    else if (hasAddressError && !hasAccountError)
                    {
                        // error in address only
                        row[Constants.colStatusExportResult] = stateFailedAddress;
                        row[Constants.colStatusInsUpd] = String.Format("{0}: {1}", stateFailedAddress, errorMsgAddress);
                    }
                    else if (!hasAddressError && hasAccountError)
                    {
                        // error in account only
                        row[Constants.colStatusExportResult] = stateFailedAccount;
                        row[Constants.colStatusInsUpd] = String.Format("{0}: {1}", stateFailedAccount, errorMsgAccount);
                    }
                    else
                    {
                        // error in address and account
                        row[Constants.colStatusExportResult] = stateFailedAddressAndAccount;
                        row[Constants.colStatusInsUpd] = String.Format("{0}: {1} // {2}", stateFailedAddressAndAccount, errorMsgAddress, errorMsgAccount);
                    }
                } // [foreach row]
            }
            catch (SoapException soapEx)
            {
                if (soapEx.Detail != null)
                {
                    var detail = soapEx.Detail;
                    string soapMessage = detail.InnerText;

                    throw new KlientenStammdatenException(
                        string.Format("Login Failed. Error: {0}", soapMessage));
                }

                // log exception
                DataHandler.InsertAbaLog(null, null, soapEx, "CtlAbaFakturierung.InformAboutExport(...) caught exception");
            }
            catch (Exception ex)
            {
                // log exception
                DataHandler.InsertAbaLog(null, null, ex, "CtlAbaFakturierung.InformAboutExport(...) caught exception");

                // show error
                KissMsg.ShowError("CtlAbaFakturierung", "ErrorUpdatingStatusColumnAfterExport", "Es ist ein Fehler beim Anpassen der Export-Resultate-Spalte aufgetreten. Die Anzeige in der Liste ist möglicherweise nicht korrekt.", ex);
            }

            #endregion

            #region Export status message dialog

            // get information about the occured errors
            String technicalInfo = "";
            Boolean exportFailed = exporterResult.IsExportFailed;	// init flag with result from Exporter

            // get main-export errors
            if (exportFailed)
            {
                // add main-export error
                technicalInfo = String.Format("{0}:{1}{1}•> {2}",
                                                KissMsg.GetMLMessage("CtlAbaFakturierung", "ExportResultGeneralError", "Allgemeiner Fehler beim Exportieren"),
                                                Environment.NewLine,
                                                exporterResult.ExportException.Message);
            }

            // get address-errors
            if (errorsAddress != null && errorsAddress.Count > 0)
            {
                // export failed because of AddressException
                exportFailed = true;

                // add newlines if no more empty
                if (!DBUtil.IsEmpty(technicalInfo))
                {
                    technicalInfo = String.Format("{0}{1}{1}{1}{1}", technicalInfo, Environment.NewLine);
                }

                // add address header info
                technicalInfo = String.Format("{0}{1}:{2}",
                                                technicalInfo,
                                                KissMsg.GetMLMessage("CtlAbaFakturierung", "ExportResultAddressError", "Fehler beim Exportieren der Adressen (Anzahl: {0})", KissMsgCode.Text, errorsAddress.Count),
                                                Environment.NewLine);

                // ml-vars
                String errorAddressClientML = KissMsg.GetMLMessage("CtlAbaFakturierung", "ExportResultAddressErrorClient", "Klient");
                String errorAddressErrorML = KissMsg.GetMLMessage("CtlAbaFakturierung", "ExportResultAddressErrorError", "Fehler");
                String errorAddressErrorAtML = KissMsg.GetMLMessage("CtlAbaFakturierung", "ExportResultAddressErrorErrorAt", "bei");

                // add all client's exceptions
                foreach (KlientExceptionPair kep in errorsAddress)
                {
                    technicalInfo = String.Format("{0}{1} •> {2}: '{3}, {4} ({5})', {6}: '{7}' {8} '{9}'{1}",
                                                technicalInfo,							// 0
                                                Environment.NewLine,					// 1
                                                errorAddressClientML,					// 2
                                                kep.KlientWithExportError.Name,			// 3
                                                kep.KlientWithExportError.Vorname,		// 4
                                                kep.KlientWithExportError.BaPersonID,	// 5
                                                errorAddressErrorML,					// 6
                                                kep.ExceptionOfExport.Message,			// 7
                                                errorAddressErrorAtML,					// 8
                                                kep.ExceptionOfExport.Source);			// 9
                }
            }

            // get account errors
            if (errorsKonto != null && errorsKonto.Count > 0)
            {
                // export failed because of AccountException
                exportFailed = true;

                // add newlines if no more empty
                if (!DBUtil.IsEmpty(technicalInfo))
                {
                    technicalInfo = String.Format("{0}{1}{1}{1}{1}", technicalInfo, Environment.NewLine);
                }

                // add address header info
                technicalInfo = String.Format("{0}{1}:{2}",
                                                technicalInfo,
                                                KissMsg.GetMLMessage("CtlAbaFakturierung", "ExportResultAccountError", "Fehler beim Exportieren der Konten (Anzahl: {0})", KissMsgCode.Text, errorsKonto.Count),
                                                Environment.NewLine);

                // ml-vars
                String errorAccountClientML = KissMsg.GetMLMessage("CtlAbaFakturierung", "ExportResultAccountErrorClient", "Konto");
                String errorAccountErrorML = KissMsg.GetMLMessage("CtlAbaFakturierung", "ExportResultAccountErrorError", "Fehler");
                String errorAccountErrorAtML = KissMsg.GetMLMessage("CtlAbaFakturierung", "ExportResultAccountErrorErrorAt", "bei");

                // add all client's exceptions
                foreach (KlientExceptionPair kep in errorsKonto)
                {
                    technicalInfo = String.Format("{0}{1} •> {2}: '{3}, {4} ({5})', {6}: '{7}' {8} '{9}'{1}",
                                                technicalInfo,							// 0
                                                Environment.NewLine,					// 1
                                                errorAccountClientML,					// 2
                                                kep.KlientWithExportError.Name,			// 3
                                                kep.KlientWithExportError.Vorname,		// 4
                                                kep.KlientWithExportError.BaPersonID,	// 5
                                                errorAccountErrorML,					// 6
                                                kep.ExceptionOfExport.Message,			// 7
                                                errorAccountErrorAtML,					// 8
                                                kep.ExceptionOfExport.Source);			// 9
                }
            }

            // show message if technical info is not empty
            if (exportFailed)
            {
                // failure, show information
                KissMsg.ShowError("CtlAbaFakturierung", "ExportFailedErrorDialog_v01", "Beim Ausführen des Exports traten Fehler auf.{0}{0}Bitte schauen Sie bei den technischen Informationen, um Details zu den aufgetretenen Fehlern und allenfalls nicht korrekt exportierten Einträgen zu erhalten.", technicalInfo, null, 800, 400, Environment.NewLine);
                return false;
            }

            // success, show information
            KissMsg.ShowInfo("CtlAbaFakturierung", "ExportSuccessInfoDialog", "Klientenstammdaten-Export erfolgreich ohne Fehler abgeschlossen.");
            return true;

            #endregion
        }

        private void qryFakturierung_AfterFill(object sender, EventArgs e)
        {
            UpdateCounter();
        }

        private void qryFakturierung_PositionChanged(object sender, EventArgs e)
        {
            UpdateCounter();
        }

        /// <summary>
        /// Reset the grid after changing MandantenNummer
        /// </summary>
        private void ResetGrid()
        {
            try
            {
                // reset datasource of Klienten-grid
                grdFakturierung.DataSource = null;

                // reset query
                qryFakturierung.Fill(-1, -1);

                // refresh grid
                grdFakturierung.Refresh();
                grdFakturierung.RefreshDataSource();

                // reset counter
                UpdateCounter();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlAbaFakturierung", "ExceptionResettingGrid", "Es ist ein Fehler beim Zurücksetzen der Ansicht aufgetreten.", ex);
            }
        }

        private bool SaveFakturierungFile(string tempFile)
        {
            // logging
            InsertAbaLog("Temp file successfully written, show dialog for user to save file");

            // get path for root
            string configRootDir = DBUtil.GetConfigString(@"System\Schnittstellen\Alpi\AbacusPathFakturierung", "");

            // logging
            InsertAbaLog(string.Format("Configuration value for root directory to store export files: '{0}'", configRootDir));

            // check if folder exists
            if (!FolderExists(configRootDir))
            {
                // logging
                InsertAbaLog("Error, desired root folder to export data does not exist, trying to apply user's desktop folder", configRootDir);

                // try to get home folder of user
                configRootDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // recheck if folder exists
                if (!FolderExists(configRootDir))
                {
                    // logging
                    InsertAbaLog("Error, desired desktop folder to export data does not exist", configRootDir);

                    // error
                    throw new Exception("Cannot access desired default directory or user's desktop, export data cannot be written");
                }

                // show message to user
                KissMsg.ShowInfo("CtlAbaFakturierung", "ExportRootFolderNotFound", "Das Standardverzeichnis für den Datenexport wurde nicht gefunden, stattdessen wird 'Desktop' verwendet.");
            }

            // logging
            InsertAbaLog(string.Format("Default root directory to use for export data: '{0}'", configRootDir));

            // create filepath/filename
            string exportFileName = string.Format(@"F-{0}-{1:dd-MM-yyyy}.asc", edtSelectMandant.EditValue, DateTime.Now);
            string exportPath = Path.Combine(configRootDir, string.Format("{0:000}", edtSelectMandant.EditValue));
            string exportFile = Path.Combine(exportPath, exportFileName);

            // logging
            InsertAbaLog("Path recommendation to save, showing dialog", exportFile);

            // create target folder if not existing yet
            if (!FolderExists(exportPath))
            {
                // logging
                InsertAbaLog("Desired target folder not found, creating folder now.", exportPath);

                if (!CreateDirectory(exportPath))
                {
                    // logging
                    InsertAbaLog("Target folder could not be created, export may not be saved properly!", exportPath);

                    // show message to user
                    KissMsg.ShowInfo("CtlAbaFakturierung", "ExportTargetFolderNotCreated", "Das gewünschte Zielverzeichnis für den Datenexport konnte nicht erstellt werden. Bitte überprüfen Sie das Verzeichnis und erstellen Sie den Zielordner gegebenenfalls von Hand.\r\n\r\nZiel: '{0}'", 0, 0, exportPath);
                }
            }

            // create dialog to select path and file
            SaveFileDialog dlgSaveFile = new SaveFileDialog();

            // apply defaults
            dlgSaveFile.InitialDirectory = exportPath;
            dlgSaveFile.RestoreDirectory = true;
            dlgSaveFile.FileName = exportFileName;

            // init dialog
            dlgSaveFile.Filter = string.Format("{0}|*.asc|{1}|*.*", KissMsg.GetMLMessage("CtlAbaFakturierung", "SaveFileASC", "Abacus ASCII-Datei (*.asc)"), KissMsg.GetMLMessage("CtlAbaStundenlohn", "SaveFileALL", "Alle Dateien (*.*)"));
            dlgSaveFile.Title = KissMsg.GetMLMessage("CtlAbaFakturierung", "SaveFileDialogTitle", "Export-Datei speichern");
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
                InsertAbaLog("Export canceled, user did not save export-file");

                // canceled, do not continue
                return false;
            }

            // copy temp file to desired location (temp file will be deleted afterwards)
            if (!CopyFile(tempFile, dlgSaveFile.FileName))
            {
                // logging
                InsertAbaLog("Export failed, could not copy temp file to target file", string.Format("source: '{0}', target: '{1}'", tempFile, dlgSaveFile.FileName));

                // file not copied, logging
                throw new Exception(string.Format("The target file could not be created, export failed (source: '{0}', target: '{1}')", tempFile, dlgSaveFile.FileName));
            }

            // logging
            InsertAbaLog("File successfully saved at desired location", dlgSaveFile.FileName);

            return true;
        }

        /// <summary>
        /// Select the items within the grid
        /// </summary>
        /// <param name="selectionMode">The selection mode to apply</param>
        private void SelectItems(SelectionMode selectionMode)
        {
            _logger.Debug("enter");

            // store last cursor
            Cursor lastCursor = Cursor.Current;

            try
            {
                // reset status
                SetStatusLabel("SelectingItems", "Die gewünschten Klienten werden ausgewählt...");

                // disable controls
                EnableControls(false, false);

                // check if any row is available
                if (qryFakturierung.Count < 1)
                {
                    // no row, do not continue
                    return;
                }

                // prevent update details
                _preventUpdateDetails = true;

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // set selection
                foreach (DataRow row in qryFakturierung.DataTable.Rows)
                {
                    // do selection dependin on given mode
                    if (selectionMode == SelectionMode.SelectAll || selectionMode == SelectionMode.SelectNone)
                    {
                        // set flag depending on call (all/none)
                        row[Constants.colDoExport] = selectionMode;
                    }
                    else if (selectionMode == SelectionMode.InvertSelection)
                    {
                        // selection inverted
                        row[Constants.colDoExport] = !DBUtil.IsEmpty(row[Constants.colDoExport]) && !Convert.ToBoolean(row[Constants.colDoExport]);
                    }

                    // prevent row modified
                    row.AcceptChanges();
                }

                // prevent data changed (we did save data above)
                qryFakturierung.Row.AcceptChanges();
                qryFakturierung.RowModified = false;
                qryFakturierung.RefreshDisplay();

                // check if row is selected
                if (grvFakturierung.GetSelectedRows().Length > 0)
                {
                    // update selected row to have proper display for selection
                    grvFakturierung.RefreshRow(grvFakturierung.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError("<ClassName>", "ErrorSelectingItems", "Es ist ein Fehler beim Selektieren der Einträge aufgetreten.", ex);
            }
            finally
            {
                // set last cursor
                Cursor.Current = lastCursor;

                // allow update details
                _preventUpdateDetails = false;

                // update counter label
                UpdateCounter();

                // set focus
                grdFakturierung.Focus();

                // reenable controls
                EnableControls(true, false);

                // reset status
                SetStatusLabel(null, null);
            }

            // done
            _logger.Debug("done");
        }

        /// <summary>
        /// Set the grid appearance to fit the one-column selection
        /// </summary>
        private void SetGridAppearance()
        {
            // apply colors, they are fix defined in contructor of view and we need readonly behaviour in editable grid
            grvFakturierung.Appearance.FocusedCell.BackColor = GuiConfig.GridFocusedSelectionBackColor;
            grvFakturierung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            grvFakturierung.Appearance.FocusedRow.BackColor = GuiConfig.GridFocusedSelectionBackColor;
            grvFakturierung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            grvFakturierung.Appearance.HideSelectionRow.BackColor = GuiConfig.GridUnfocusedSelectionBackColor;
            grvFakturierung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            grvFakturierung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            grvFakturierung.Appearance.HideSelectionRow.Options.UseForeColor = true;
        }

        /// <summary>
        /// Apply new status text to status label
        /// </summary>
        /// <param name="defaultMessageText">The (translated!) default message</param>
        private void SetStatusLabel(String defaultMessageText)
        {
            SetStatusLabel(null, defaultMessageText, true, null);
        }

        /// <summary>
        /// Apply new status text to status label
        /// </summary>
        /// <param name="messageName">The message name to use for multilanguage message (MessageName)</param>
        /// <param name="defaultMessageText">The default message if none defined yet by translation (DefaultMessage)</param>
        private void SetStatusLabel(String messageName, String defaultMessageText)
        {
            SetStatusLabel(messageName, defaultMessageText, null);
        }

        /// <summary>
        /// Apply new status text to status label
        /// </summary>
        /// <param name="messageName">The message name to use for multilanguage message (MessageName)</param>
        /// <param name="defaultMessageText">The default message if none defined yet by translation (DefaultMessage)</param>
        /// <param name="parameters">Additional parameters to fill within default message</param>
        private void SetStatusLabel(String messageName, String defaultMessageText, params object[] parameters)
        {
            SetStatusLabel(messageName, defaultMessageText, false, parameters);
        }

        /// <summary>
        /// Apply new status text to status label
        /// </summary>
        /// <param name="messageName">The message name to use for multilanguage message (MessageName)</param>
        /// <param name="defaultMessageText">The default message if none defined yet by translation (DefaultMessage)</param>
        /// <param name="alreadyTranslatedMessage">Flag if message is already translated and does not need further mulitlanguage handling</param>
        /// <param name="parameters">Additional parameters to fill within default message</param>
        private void SetStatusLabel(String messageName, String defaultMessageText, Boolean alreadyTranslatedMessage, params object[] parameters)
        {
            // check if we have a valid name and text (only if not already translated)
            if ((DBUtil.IsEmpty(messageName) && !alreadyTranslatedMessage) ||
                DBUtil.IsEmpty(defaultMessageText))
            {
                // no valid name or text, use default
                defaultMessageText = "-";
            }
            else if (!alreadyTranslatedMessage)
            {
                // not translated yet, get text from database
                defaultMessageText = KissMsg.GetMLMessage("CtlAbaFakturierung", messageName, defaultMessageText, KissMsgCode.Text, parameters);
            }

            // setup text
            lblStatusBar.Text = String.Format(" {0}: {1}", _statusText, defaultMessageText);

            // do it
            ApplicationFacade.DoEvents();
        }

        private void SetupColumn(GridColumn gridColumn, bool editable)
        {
            var backColor = editable ? GuiConfig.GridEditable : GuiConfig.GridReadOnly;

            gridColumn.AppearanceCell.BackColor = backColor;
            gridColumn.AppearanceCell.Options.UseBackColor = true;

            gridColumn.OptionsColumn.AllowEdit = editable;
            gridColumn.OptionsColumn.AllowFocus = editable;
            gridColumn.OptionsColumn.ReadOnly = !editable;
        }

        private void SetupGrid()
        {
            SetupColumn(colDoExport, true);
            SetupColumn(colName, false);
            SetupColumn(colVorname, false);
            SetupColumn(colDebitorNr, false);
            SetupColumn(colAnzahlPositionen, false);
            SetupColumn(colDatumVon, false);
            SetupColumn(colDatumBis, false);
            SetupColumn(colStatusInsUpd, false);
        }

        /// <summary>
        /// Update the counter label
        /// </summary>
        private void UpdateCounter()
        {
            if (_preventUpdateDetails)
            {
                return;
            }

            var count = 0;

            foreach (DataRow row in qryFakturierung.DataTable.Rows)
            {
                if (Utils.ConvertToBool(row[Constants.colDoExport]))
                {
                    count++;
                }
            }

            lblSelectedRowsCount.Text = string.Format("{0} von {1} Einträgen ausgewählt", count, qryFakturierung.Count);
        }

        private void UpdateFakturiert(List<DataRow> selectedRows)
        {
            DBUtil.NewHistoryVersion();

            foreach (var row in selectedRows)
            {
                var bdeLeistungIds = row["BDELeistungIDs"] as string;

                try
                {
                    DBUtil.ExecSQL(string.Format(@"
                        UPDATE dbo.BDELeistung
                        SET Fakturiert = 1
                        WHERE BDELeistungID IN ({0});", bdeLeistungIds));
                }
                catch (Exception ex)
                {
                    InsertAbaLog("Error while updating 'Fakturiert' on BDELeistung", bdeLeistungIds, null, ex);
                }
            }
        }
    }
}