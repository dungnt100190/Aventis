using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Schnittstellen.Abacus.ASCII;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    /// <summary>
    /// Control used for transferring client data to Abacus.
    /// TODO Achtung: Logik ist zum Teil nach <see cref="CtlAbaFakturierung"/> kopiert, bei Änderungen auch dort anpassen.
    /// </summary>
    public partial class CtlAbaKlientenStammdaten : KissUserControl
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly DataHandler _dataHandler;

        private readonly bool _kissConfigDebugFlag;

        private readonly string _statusMessageEventAccount = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "StatusMessageEventAccount", "Konto");

        private readonly string _statusMessageEventAddress = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "StatusMessageEventAddress", "Adresse");

        private readonly string _statusMessageEventGeneral = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "StatusMessageEventGeneral", "Allgemein");

        private readonly string _statusMessageEventSender = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "StatusMessageEventSender_v01", "Bereich");

        private readonly string _statusText = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "StatusText", "Status");

        private int _debugSelectedClientsCount;

        private DateTime _debugStartTime;

        private Exporter _exporter;

        // do not update details (e.g. if selecting all rows)
        private bool _preventUpdateDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlAbaKlientenStammdaten"/> class.
        /// </summary>
        public CtlAbaKlientenStammdaten()
        {
            // init components
            InitializeComponent();

            SetupGrid();

            // because of display error in designer-layout, we set datasource and fieldname here (good, because of Constants-value)
            ctlGotoFall.DataSource = qryLoadKlientenByMandantID;
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
            SelectByStateAll = 2,
            SelectByStateNone = 3
        }

        /// <summary>
        /// Get the flag if export is still running
        /// </summary>
        public Boolean IsExportRunning
        {
            get { return _exporter != null; }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // logging
            DataHandler.InsertAbaLog(String.Format("MandantNr='{0}', AbacusUser='{1}'", edtSelectMandant.Text, edtUserName.Text), null, null, "CtlAbaKlientenStammdaten.btnCancel_Click");

            // check if we have an exporter (only this can be canceled)
            if (_exporter == null)
            {
                // disable button
                btnCancel.Enabled = false;

                // logging
                DataHandler.InsertAbaLog(null, null, null, "CtlAbaKlientenStammdaten.btnCancel_Click - rised without having exporter instance");

                // do not continue
                return;
            }

            // confirm cancel export
            if (!KissMsg.ShowQuestion("CtlAbaKlientenStammdaten", "ConfirmCancelExport", "Wollen Sie den laufenden Export wirklich abbrechen?", true))
            {
                // logging
                DataHandler.InsertAbaLog(null, null, null, "CtlAbaKlientenStammdaten.btnCancel_Click - user did not cancel");

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
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}', AbacusUser='{1}'", edtSelectMandant.Text, edtUserName.Text), null, null, "CtlAbaKlientenStammdaten.btnDatenExport_Click");

                // set status
                SetStatusLabel("PrepareExportDoValidations", "Der Export wird vorbereitet...");

                // disable controls but allow cancel
                EnableControls(false, true);

                // VALIDATE
                // validate if any MandantenNummer is selected
                if (DBUtil.IsEmpty(edtSelectMandant.EditValue))
                {
                    // show info, invalid MandantenNummer
                    KissMsg.ShowInfo("CtlAbaKlientenStammdaten", "NoMandantenNummerGivenOnExport", "Es ist keine gültige Mandanten-Nummer ausgwählt, der Export kann nicht durchgeführt werden.");

                    // focus
                    edtSelectMandant.Focus();

                    // cancel
                    return;
                }
                if (DBUtil.IsEmpty(edtUserName.EditValue))
                {
                    // show info, invalid MandantenNummer
                    KissMsg.ShowInfo("CtlAbaKlientenStammdaten", "NoUserNameGivenOnExport", "Es ist kein gültiger Abacus-Benutzer angegeben, der Export kann nicht durchgeführt werden.");

                    // focus
                    edtUserName.Focus();

                    // cancel
                    return;
                }
                if (DBUtil.IsEmpty(edtUserPassword.EditValue))
                {
                    // show info, invalid MandantenNummer
                    KissMsg.ShowInfo("CtlAbaKlientenStammdaten", "NoUserPasswordGivenOnExport", "Es ist kein gültiges Abacus-Benutzerpasswort angegeben, der Export kann nicht durchgeführt werden.");

                    // focus
                    edtUserPassword.Focus();

                    // cancel
                    return;
                }

                // PREPARATIONS
                // get the current selected MandantenNummer
                Int32 mandantenNummer = Convert.ToInt32(edtSelectMandant.EditValue);

                // get all selected clients
                List<Klient> allSelectedClients = UpdateCounter();

                // DO START EXPORT (ASYNC)
                // validate if some clients are selected
                if (allSelectedClients == null)
                {
                    throw new NullReferenceException("The object of all selected clients is empty, cannot start the export.");
                }
                if (allSelectedClients.Count < 1)
                {
                    throw new ArgumentOutOfRangeException("allSelectedClients.Count", "No clients selected, cannot start the export without any selection.");
                }

                // validate MandantenNummer for given range
                if (!DataHandler.IsMandantenNummerValid(mandantenNummer))
                {
                    throw new ArgumentOutOfRangeException(String.Format("The selected MandantenNummer '{0}' is invalid and out of range", mandantenNummer));
                }

                // confirm and warn
                if (!KissMsg.ShowQuestion("CtlAbaKlientenStammdaten", "ConfirmStartExport_v01", "Wollen Sie die '{1}' gewählten Einträge für den Mandanten '{2}' nun exportieren?{0}{0}Achtung: Die Verarbeitung kann je nach Anzahl der selektierten Einträge einen Moment dauern!", 0, 0, true, Environment.NewLine, allSelectedClients.Count, edtSelectMandant.Text))
                {
                    // do not continue
                    return;
                }

                // start time messuring (used for debugging) and count of selected clients
                _debugStartTime = DateTime.Now;
                _debugSelectedClientsCount = allSelectedClients.Count;

                // logging
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}', AbacusUser='{1}', AmountOfClients='{2}'", edtSelectMandant.Text, edtUserName.Text, allSelectedClients.Count), null, null, "CtlAbaKlientenStammdaten.btnDatenExport_Click - starting Abacus export");

                // set status
                SetStatusLabel("DoRunExport", "Der Export wird gestartet...");

                // create new instance of Exporter
                _exporter = new Exporter(Convert.ToString(edtUserName.EditValue), Convert.ToString(edtUserPassword.EditValue));

                //Anhängen der Events des backgoundworkers der ein traken des updates ermöglicht
                _exporter.ExportWorker.RunWorkerCompleted += ExportWorker_RunWorkerCompleted;
                _exporter.ExportWorker.ProgressChanged += ExportWorker_ProgressChanged;
                _exporter.StatusChanged += Exporter_StatusChanged;

                // init exporter with selected clients and mandantenNummer
                _exporter.Init(allSelectedClients, mandantenNummer);

                // export is initalized and therefore started
                isExporting = true;

                // start export thread
                _exporter.ExportWorker.RunWorkerAsync();
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
                KissMsg.ShowError("CtlAbaKlientenStammdaten", "ErrorDoingExportOccured", "Es ist ein Fehler in der Verarbeitung aufgetreten. Der Export konnte möglicherweise nicht für alle gewählten Klienten erfolgreich durchgeführt werden.", ex);
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

        private void btnDeselectState_Click(object sender, EventArgs e)
        {
            // select by state none
            SelectItems(SelectionMode.SelectByStateNone);
        }

        private void btnInvertSelection_Click(object sender, EventArgs e)
        {
            // invert selection
            SelectItems(SelectionMode.InvertSelection);
        }

        private void btnLoadKlienten_Click(object sender, EventArgs e)
        {
            try
            {
                // logging
                DataHandler.InsertAbaLog(null, null, null, "CtlAbaKlientenStammdaten.btnLoadKlienten_Click");

                // disable controls
                EnableControls(false, false);

                // set appearance of grid
                SetGridAppearance();

                // remove datasource from grid
                grdKlientenStammdaten.DataSource = null;

                // validate selected MandantenNummer
                if (DBUtil.IsEmpty(edtSelectMandant.EditValue))
                {
                    // no MandantenNummer given, cannot continue
                    KissMsg.ShowError("CtlAbaKlienetenStammdaten", "NoMandantenNummerSelected", "Es ist keine gültige Mandanten-Nummer ausgewählt.{0}{0}Sie sind entweder keiner Abteilung zugewiesen oder Sie besitzen zuwenig Rechte im System.", null, null, 0, 0, Environment.NewLine);
                    return;
                }

                // set status
                SetStatusLabel("LoadingDataFromMandantenNr", "Die Klienten für den gewählten Mandanten '{0}' werden geladen...", edtSelectMandant.Text);

                try
                {
                    // logging
                    DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", edtSelectMandant.Text), null, null, "CtlAbaKlientenStammdaten.btnLoadKlienten_Click - try to load data for given MandantNr");

                    // load clients from database for given MandantenNummer
                    _dataHandler.FillQueryWithAllKlientenOfMandant(Convert.ToInt32(edtSelectMandant.EditValue), ref qryLoadKlientenByMandantID);
                }
                catch (Exception ex)
                {
                    // show error and cancel
                    KissMsg.ShowError("CtlAbaKlienetenStammdaten", "ErrorLoadingClientsFromDatabase", "Es ist ein Fehler in der Verarbeitung aufgetreten, die Klienten für den gewählten Mandanten konnten nicht geladen werden.", ex);

                    // logging
                    DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", edtSelectMandant.Text), null, ex, "CtlAbaKlientenStammdaten.btnLoadKlienten_Click - call DataHandler.FillQueryWithAllKlientenOfMandant");
                    return;
                }

                // setup query to allow selection of clients
                qryLoadKlientenByMandantID.CanUpdate = true;
                qryLoadKlientenByMandantID.BatchUpdate = true;

                // apply datasource again to grid
                grdKlientenStammdaten.DataSource = qryLoadKlientenByMandantID;

                // init dropdown for selections (from lov)
                InitDropdownSelectModes(false, false);
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
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", edtSelectMandant.Text), null, soapEx, "CtlAbaKlientenStammdaten.btnLoadKlienten_Click caught exception with loading data");
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError("CtlAbaKlientenStammdaten", "ExceptionLoadClients", "Es ist ein Fehler beim Laden der Einträge aufgetreten.", ex);

                // logging
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", edtSelectMandant.Text), null, ex, "CtlAbaKlientenStammdaten.btnLoadKlienten_Click caught exception with loading data");
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

        private void btnSelectState_Click(object sender, EventArgs e)
        {
            // select by state all
            SelectItems(SelectionMode.SelectByStateAll);
        }

        /// <summary>
        /// The Control_Leave event, occures when control is no longer active control on Form
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlAbaKlientenStammdaten_Leave(object sender, EventArgs e)
        {
            // if export is still running, cancel because of leaving control
            if (IsExportRunning)
            {
                // cancel export because of security reason
                DoCancelExport();

                // log this event
                DataHandler.InsertAbaLog(null, null, null, "CtlAbaKlientenStammdaten_Leave(...) - user wants to close control while export is running!");

                // show information about this event
                KissMsg.ShowError("CtlAbaKlientenStammdaten", "LeavingControlWhileExportRunning", "Bitte schliessen Sie diese Maske nicht während einem laufenden Export!{0}{0}Es wird nun gewartet, bis der Export abgebrochen wurde.", null, null, 0, 0, Environment.NewLine);

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
                DataHandler.InsertAbaLog(null, null, null, String.Format("CtlAbaKlientenStammdaten_Leave(...) - no longer waiting until export finished, current state is: IsExportRunning={0}, counter={1}!", IsExportRunning, counter));
            }
        }

        /// <summary>
        /// The Control_Load event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlAbaKlientenStammdaten_Load(object sender, EventArgs e)
        {
            // logging
            DataHandler.InsertAbaLog(null, null, null, "CtlAbaKlientenStammdaten_Load(...) - loading user interface");

            // set status
            SetStatusLabel("LoadingFormWait", "Bitte warten, die Schnittstelle wird vorbereitet...");

            // init dropdown for MandantenNummer
            InitDropdownMandantenNummer();

            // GUI
            // update counter label
            UpdateCounter();

            // reset status
            SetStatusLabel(null, null);
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
            DataHandler.InsertAbaLog(null, null, null, "CtlAbaKlientenStammdaten.DoCancelExport(...) - user did cancel export");

            // cancel export by setting flag on exporter
            _exporter.SetExportCanceled();

            // do it
            ApplicationFacade.DoEvents();
        }

        private void edtSelectMandant_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                // logging
                DataHandler.InsertAbaLog(null, null, null, "CtlAbaKlientenStammdaten.edtSelectMandant_EditValueChanging");

                // disable controls
                EnableControls(false, false);

                //Falls der Benutzer den gewählten Mandant ändert muss die Liste geleert werden
                //da dies sonst eine Dateninkosistenz zur Folge hätte.
                //Um den Benutzer jedoch davor zu warnen wird zuerst eine MessageBox angezeigt wo der
                //Benutzer entscheiden kann ob er wirklich den Mndant wechseln will falls sich
                //Einträge in der Liste befinden.

                // check if we have a datasource set
                if (grdKlientenStammdaten.DataSource == null)
                {
                    // no datasource set, do not continue
                    return;
                }

                if (((SqlQuery)grdKlientenStammdaten.DataSource).Count > 0)
                {
                    if (!KissMsg.ShowQuestion("CtlAbaKlientenStammdaten", "ConfirmRefreshMandant", "Möchten Sie wirklich den Mandanten wechseln und dabei die Liste mit den Klienten leeren?", true))
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
                KissMsg.ShowError("CtlAbaKlientenStammdaten", "ExceptionChangingMandant", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);

                // logging
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", edtSelectMandant.Text), null, ex, "CtlAbaKlientenStammdaten.edtSelectMandant_EditValueChanging caught exception with resetting data");
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
            edtSelectMode.EditMode = applyEditMode;

            // buttons
            btnLoadKlienten.Enabled = enabled;
            btnSelectAll.Enabled = enabled;
            btnDeselectAll.Enabled = enabled;
            btnInvertSelection.Enabled = enabled;
            btnSelectState.Enabled = enabled;
            btnDeselectState.Enabled = enabled;
            btnDatenExport.Enabled = enabled;

            // button cancel is special
            btnCancel.Enabled = !enabled && canCancelAction;

            // others
            grdKlientenStammdaten.Enabled = enabled;
            ctlGotoFall.Enabled = enabled;

            // do update gui
            ApplicationFacade.DoEvents();
        }

        private void Exporter_StatusChanged(object sender, StatusChangedEventArgs e)
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
        /// The event that occures when progress of export worker thread reports a new step
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void ExportWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // validate event arguments
            if (e == null)
            {
                throw new ArgumentNullException("e", "The event argument is empty, cannot set new progress.");
            }

            // definie vars
            String statusMessageEvent;

            // get status event
            switch ((Exporter.WorkingPart)e.UserState)
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

            // apply new value to progressbar
            pgbExport.Value = e.ProgressPercentage;

            // set status label
            SetStatusLabel("ExportStatusPercent", "{0}% des Exports durchgeführt ({1}: {2})", e.ProgressPercentage, _statusMessageEventSender, statusMessageEvent);
        }

        private void ExportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                // logging
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}', AbacusUser='{1}'", edtSelectMandant.Text, edtUserName.Text), null, null, "CtlAbaKlientenStammdaten.ExportWorker_RunWorkerCompleted");

                // check if we have result
                if (e == null || e.Result == null || !(e.Result is ExporterResult))
                {
                    // invalid result
                    throw new NullReferenceException("The expected export result is empty or invalid, cannot decide success or failure.");
                }

                // set status (and keep it as long as user does not click anything)
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
                    KissMsg.ShowInfo(String.Format("Export: Exported '{0}' selected clients in '{1}' seconds", _debugSelectedClientsCount, debugTimeSpan.TotalSeconds));
                }

                #endregion

                // message and setup states depending on export result
                InformAboutExport((ExporterResult)e.Result);
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError("CtlAbaKlientenStammdaten", "ExportRunWorkerCompleted", "Es ist ein Fehler beim Fertigstellen des Exports aufgetreten.", ex);

                // logging
                DataHandler.InsertAbaLog(String.Format("MandantNr='{0}', AbacusUser='{1}'", edtSelectMandant.Text, edtUserName.Text), null, ex, "CtlAbaKlientenStammdaten.ExportWorker_RunWorkerCompleted caught exception with completing export");
            }
            finally
            {
                // reenable controls
                EnableControls(true, false);

                // detach events after completion
                _exporter.ExportWorker.RunWorkerCompleted -= ExportWorker_RunWorkerCompleted;
                _exporter.ExportWorker.ProgressChanged -= ExportWorker_ProgressChanged;
                _exporter.StatusChanged -= Exporter_StatusChanged;

                // reset the exporter-instance, it has finished!
                _exporter = null;
            }
        }

        private void grvKlientenStammdaten_LostFocus(object sender, EventArgs e)
        {
            // update counter label
            UpdateCounter();
        }

        /// <summary>
        /// Methode setzt die Stati im Grid der einzelnen Klienten und informiert über das Wieso und
        /// Warum falls ein Export nicht erfolgreich durchgeführt werden konnte
        /// </summary>
        /// <param name="exporterResult">The <see cref="ExporterResult"/> that was returned by Exporter (expect a valid instance)</param>
        private void InformAboutExport(ExporterResult exporterResult)
        {
            // validate exporter
            if (_exporter == null)
            {
                throw new NullReferenceException("No exporter given, cannot continue with further handling after export finished.");
            }

            // get error messages
            List<KlientExceptionPair> errorsAddress = _exporter.KlientenMitAddressExportException;
            List<KlientExceptionPair> errorsKonto = _exporter.KlientenMitKontoExportException;

            #region Update States In Grid

            // setup states used in grid
            String stateNotExported = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ClientStateNotExported_v01", "(-) Nicht exportiert");
            String stateSuccessExport = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ClientStateSuccessfullyExported_v01", "(+) Erfolgreich exportiert");
            String stateUnknownExportFailed = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ClientStateExportFailed_v01", "(!) Export fehlgeschlagen, Status unbekannt");
            String stateFailedAddress = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ClientStateErrorAddress_v01", "(!) Fehlerhafter Adressen-Export");
            String stateFailedAccount = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ClientStateErrorAccount_v01", "(!) Fehlerhafter Konto-Export");
            String stateFailedAddressAndAccount = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ClientStateErrorAddressAndAccount_v01", "(!) Fehlerhafter Adressen- und Konto-Export");

            try
            {
                // loop datarows and setup states depending on exported and errors...
                foreach (DataRow row in qryLoadKlientenByMandantID.DataTable.Rows)
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
                DataHandler.InsertAbaLog(null, null, soapEx, "CtlAbaKlientenStammdaten.InformAboutExport(...) caught exception");
            }
            catch (Exception ex)
            {
                // log exception
                DataHandler.InsertAbaLog(null, null, ex, "CtlAbaKlientenStammdaten.InformAboutExport(...) caught exception");

                // show error
                KissMsg.ShowError("CtlAbaKlientenStammdaten", "ErrorUpdatingStatusColumnAfterExport", "Es ist ein Fehler beim Anpassen der Export-Resultate-Spalte aufgetreten. Die Anzeige in der Liste ist möglicherweise nicht korrekt.", ex);
            }
            finally
            {
                // update states of selection-dropdown
                InitDropdownSelectModes(true, false);
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
                                                KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ExportResultGeneralError", "Allgemeiner Fehler beim Exportieren"),
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
                                                KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ExportResultAddressError", "Fehler beim Exportieren der Adressen (Anzahl: {0})", KissMsgCode.Text, errorsAddress.Count),
                                                Environment.NewLine);

                // ml-vars
                String errorAddressClientML = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ExportResultAddressErrorClient", "Klient");
                String errorAddressErrorML = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ExportResultAddressErrorError", "Fehler");
                String errorAddressErrorAtML = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ExportResultAddressErrorErrorAt", "bei");

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
                                                KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ExportResultAccountError", "Fehler beim Exportieren der Konten (Anzahl: {0})", KissMsgCode.Text, errorsKonto.Count),
                                                Environment.NewLine);

                // ml-vars
                String errorAccountClientML = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ExportResultAccountErrorClient", "Konto");
                String errorAccountErrorML = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ExportResultAccountErrorError", "Fehler");
                String errorAccountErrorAtML = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", "ExportResultAccountErrorErrorAt", "bei");

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
                KissMsg.ShowError("CtlAbaKlientenStammdaten", "ExportFailedErrorDialog_v01", "Beim Ausführen des Exports traten Fehler auf.{0}{0}Bitte schauen Sie bei den technischen Informationen, um Details zu den aufgetretenen Fehlern und allenfalls nicht korrekt exportierten Einträgen zu erhalten.", technicalInfo, null, 800, 400, Environment.NewLine);
            }
            else
            {
                // success, show information
                KissMsg.ShowInfo("CtlAbaKlientenStammdaten", "ExportSuccessInfoDialog", "Export erfolgreich ohne Fehler abgeschlossen.");
            }

            #endregion
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

        /// <summary>
        /// Init dropdown for selection modes
        /// </summary>
        /// <param name="statesFromGrid">Read states from grid (after done export)</param>
        /// <param name="clearDropDown">Clear dropdown content</param>
        private void InitDropdownSelectModes(Boolean statesFromGrid, Boolean clearDropDown)
        {
            try
            {
                // remove datasource to clear dropdown
                edtSelectMode.DataSource = null;

                // fill edtSelectMode with states that are available
                if (statesFromGrid)
                {
                    // load states from grid, clear query data-rows
                    qryLoadAllClientStatus.DataTable.Rows.Clear();

                    // create a list of all states that are currently in qry (to have distinct)
                    List<String> exportStates = new List<String>();

                    // loop datarows and setup states depending on exported and errors...
                    foreach (DataRow row in qryLoadKlientenByMandantID.DataTable.Rows)
                    {
                        // get current grid-state
                        String statusExportResult = DataHandler.GetStringValue(row, Constants.colStatusExportResult);

                        // check if state is already in list
                        if (!exportStates.Contains(statusExportResult))
                        {
                            // add item to list to prevent multiple entries
                            exportStates.Add(statusExportResult);
                        }
                    }

                    // sort data
                    exportStates.Sort();

                    // add all export-states to states-query
                    foreach (String exportState in exportStates)
                    {
                        // add to states-query (code = -1, -2, -3, ... and text as in list)
                        qryLoadAllClientStatus.DataTable.Rows.Add(-(qryLoadAllClientStatus.Count + 1), exportState);
                    }
                }
                else
                {
                    // load states from database
                    qryLoadAllClientStatus = _dataHandler.GetAllClientUpdateStatus(clearDropDown);
                }

                // setup properties
                edtSelectMode.Properties.DropDownRows = Math.Min(qryLoadAllClientStatus.Count, 7);
                edtSelectMode.Properties.DataSource = qryLoadAllClientStatus;

                // setup default value
                edtSelectMode.EditValue = qryLoadAllClientStatus.Count > 0 ? qryLoadAllClientStatus["Code"] : null; // select first value if any
            }
            catch (SoapException soapEx)
            {
                // logging
                DataHandler.InsertAbaLog(null, null, soapEx, "CtlAbaKlientenStammdaten.InitDropdownSelectModes(...) caught an exception");

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
                DataHandler.InsertAbaLog(null, null, ex, "CtlAbaKlientenStammdaten.InitDropdownSelectModes(...) caught an exception");

                // show error
                KissMsg.ShowError("CtlAbaKlientenStammdaten", "ErrorInitDropdownSelectModes", "Fehler in der Verarbeitung, die Auswahl nach Status konnte nicht geladen werden.", ex);
            }
        }

        private void qryLoadKlientenByMandantID_AfterFill(object sender, EventArgs e)
        {
            // update counter label
            UpdateCounter();
        }

        private void qryLoadKlientenByMandantID_PositionChanged(object sender, EventArgs e)
        {
            // update counter label
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
                grdKlientenStammdaten.DataSource = null;

                // get current mandantennr
                Int32 mandant = Convert.ToInt32(edtSelectMandant.EditValue);

                // reset query
                _dataHandler.FillQueryWithAllKlientenOfMandant(-1, ref qryLoadKlientenByMandantID);

                // refresh grid
                grdKlientenStammdaten.Refresh();
                grdKlientenStammdaten.RefreshDataSource();

                // reset counter
                UpdateCounter();

                // reset dropdown
                InitDropdownSelectModes(false, true);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlAbaKlientenStammdaten", "ExceptionResettingGrid", "Es ist ein Fehler beim Zurücksetzen der Ansicht aufgetreten.", ex);
            }
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
                if (qryLoadKlientenByMandantID.Count < 1)
                {
                    // no row, do not continue
                    return;
                }

                // prevent update details
                _preventUpdateDetails = true;

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // set selection
                foreach (DataRow row in qryLoadKlientenByMandantID.DataTable.Rows)
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
                    else if (selectionMode == SelectionMode.SelectByStateAll || selectionMode == SelectionMode.SelectByStateNone)
                    {
                        // check mode
                        if (DBUtil.IsEmpty(edtSelectMode.Text))
                        {
                            throw new ArgumentOutOfRangeException("edtSelectMode.Text", "Cannot select any item by state if no state is given.");
                        }

                        // check if select all or none by state
                        Boolean isSelected = selectionMode == SelectionMode.SelectByStateAll;

                        // select all/none only those who are within state (!StartWith!)
                        if (Convert.ToString(row[Constants.colStatusInsUpd]).StartsWith(edtSelectMode.Text))
                        {
                            row[Constants.colDoExport] = isSelected;
                        }
                    }

                    // prevent row modified
                    row.AcceptChanges();
                }

                // prevent data changed (we did save data above)
                qryLoadKlientenByMandantID.Row.AcceptChanges();
                qryLoadKlientenByMandantID.RowModified = false;
                qryLoadKlientenByMandantID.RefreshDisplay();

                // check if row is selected
                if (grvKlientenStammdaten.GetSelectedRows().Length > 0)
                {
                    // update selected row to have proper display for selection
                    grvKlientenStammdaten.RefreshRow(grvKlientenStammdaten.GetSelectedRows()[0]);
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

                // update states
                qryLoadKlientenByMandantID_PositionChanged(this, EventArgs.Empty);

                // set focus
                grdKlientenStammdaten.Focus();

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
            grvKlientenStammdaten.Appearance.FocusedCell.BackColor = GuiConfig.GridFocusedSelectionBackColor;
            grvKlientenStammdaten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            grvKlientenStammdaten.Appearance.FocusedRow.BackColor = GuiConfig.GridFocusedSelectionBackColor;
            grvKlientenStammdaten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            grvKlientenStammdaten.Appearance.HideSelectionRow.BackColor = GuiConfig.GridUnfocusedSelectionBackColor;
            grvKlientenStammdaten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            grvKlientenStammdaten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            grvKlientenStammdaten.Appearance.HideSelectionRow.Options.UseForeColor = true;
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
                defaultMessageText = KissMsg.GetMLMessage("CtlAbaKlientenStammdaten", messageName, defaultMessageText, KissMsgCode.Text, parameters);
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
            SetupColumn(colPlzOrt, false);
            SetupColumn(colOrgUnit, false);
            SetupColumn(colSachbearbeiter, false);
            SetupColumn(colKlientenkontoNr, false);
            SetupColumn(colDebitorUpdate, false);
            SetupColumn(colStatusInsUpd, false);
        }

        /// <summary>
        /// Update the counter label and return all selected clients
        /// </summary>
        /// <returns>All selected clients as <see cref="Klient"/></returns>
        private List<Klient> UpdateCounter()
        {
            _logger.Debug("enter");

            // create a new list
            List<Klient> allSelectedClients = new List<Klient>();

            // check if need to do action
            if (_preventUpdateDetails)
            {
                // do nothing
                return allSelectedClients;
            }

            // loop through items and count selected items
            foreach (DataRow row in qryLoadKlientenByMandantID.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row[Constants.colDoExport]) && Convert.ToBoolean(row[Constants.colDoExport]))
                {
                    // check if client is selected
                    if (!DBUtil.IsEmpty(row[Constants.colDoExport]) && Convert.ToBoolean(row[Constants.colDoExport]))
                    {
                        // client is selected
                        allSelectedClients.Add(new Klient(row));
                    }
                }
            }

            // update label
            lblSelectedRowsCount.Text = String.Format("{0} von {1} Einträgen ausgewählt", allSelectedClients.Count, qryLoadKlientenByMandantID.Count);

            _logger.Debug("done");

            // return selected items
            return allSelectedClients;
        }
    }
}