using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.DB.Cache;
using KiSS4.Gui;

namespace KiSS4.Pendenzen
{
    public partial class CtlPendenzenVerwaltung : KissSearchUserControl
    {
        private const string CLASSNAME = "CtlPendenzenVerwaltung";
        private const string QRY_TASK_TYPE_DESCRIPTION = "TaskDescription";
        private const string QRY_TASK_TYPE_SUBJECT = "Subject";

        private bool _actionsEnabled;
        private EditModeType _faFallDefaultEditMode;
        private int? _fallId;
        private bool _isRowModifiedInChanging;
        private bool _isRowSelectedInChanging;
        private int? _leistungId;
        private bool _preventUpdateDetails; // do not update details (e.g. if selecting all rows)
        private RefreshNavBar _refreshNavBarItems = EmptyDelegate;
        private string _sqlFilter = "WHERE 1 = 1";
        private EditModeType _sucheReceiverDefaultEditMode;

        private string sqlModulID = @"
                SELECT Code = ModulID,
                       Text = ShortName
                FROM XModul";

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlPendenzenVerwaltung"/> class.
        /// </summary>
        public CtlPendenzenVerwaltung()
        {
            InitializeComponent();

            // show the name of the status instead of the code
            colTaskStatusCode.ColumnEdit = grdXTask.GetLOVLookUpEdit((SqlQuery)edtTaskStatusCode.Properties.DataSource, "Code", "ShortText");
            colLeistung.ColumnEdit = grdXTask.GetLOVLookUpEdit(DBUtil.OpenSQL(sqlModulID));

            ctlBearbeitungErledigt.LabelLength = 80;

            qryOrgUnit.Fill();
            edtSucheOrgUnit.LoadQuery(qryOrgUnit);

            btnBatchApply.Enabled = DBUtil.UserHasRight("CtlPendenzenverwaltung_Massenverarbeitung");
        }

        public delegate void RefreshNavBar();

        public RefreshNavBar RefreshNavBarItems
        {
            private get
            {
                return _refreshNavBarItems;
            }

            set
            {
                if (value != null)
                {
                    _refreshNavBarItems = value;
                }
            }
        }

        private bool ActionsEnabled
        {
            get { return _actionsEnabled; }
            set
            {
                _actionsEnabled = value;
                foreach (var button in panAktionen.Controls.OfType<KissButton>().Where(x => x.Tag as TaskAction != null))
                {
                    var taskAction = button.Tag as TaskAction;
                    bool erstellerDarfAusfuehren = taskAction == null || taskAction.ErstellerDarfAusfuehren;

                    button.Enabled = value &&
                                     (erstellerDarfAusfuehren ||
                                      Utils.ConvertToInt(qryXTask[DBO.XTask.SenderID]) != Session.User.UserID);
                }
            }
        }

        /// <summary>
        /// Start a custom search with a given sql filter. Should be called after initialization of the control.
        /// </summary>
        /// <param name="sqlFilter">An SQL where condition</param>
        /// <param name="parameters">Parameters which are used in the sqlFilter</param>
        /// <remarks>If sqlFilter is empty (empty string or null) a general search is prepared</remarks>
        public void CustomSearch(string sqlFilter, params object[] parameters)
        {
            qryXTask.Post();

            // reset the select statements to the original Sql statement
            qryXTask.SelectStatement = GetXTaskSelectStatement();
            kissSearch.SelectStatement = qryXTask.SelectStatement;
            kissSearch.SelectParameters = null;

            // start a general search if sqlFilter is null
            if (string.IsNullOrEmpty(sqlFilter))
            {
                NewSearch();
                tabControlSearch.SelectTab(tpgSuchen);
                _sqlFilter = "WHERE 1 = 1";

                edtSucheReceiverID.EditMode = EditModeType.Normal;
            }
            else
            {
                _sqlFilter = String.Format("WHERE ({0})", sqlFilter);
                qryXTask.SelectStatement = kissSearch.SelectStatement.Replace("WHERE 1 = 1", _sqlFilter);

                kissSearch.SelectParameters = parameters;
                kissSearch.SelectStatement = qryXTask.SelectStatement;

                //NewSearch();
                OnNewSearch();
                tabControlSearch.SelectTab(tpgListe);

                edtSucheReceiverID.EditMode = _sucheReceiverDefaultEditMode;
            }

            RefreshNavBarItems();
            SetListItemColors();
        }

        /// <summary>
        /// Init-Methode um die Maske in KiSS5 einzubinden
        /// </summary>
        /// <param name="sqlFilter">SQL-Filter für die CustomSearch-Methode</param>
        public void Init(string sqlFilter)
        {
            Init(EmptyDelegate, null, null, AccessPendenzen.Verwaltung);
            CustomSearch(sqlFilter, Session.User.UserID);
        }

        /// <summary>
        /// Initializes the control
        /// </summary>
        /// <param name="refreshNavBar">Method which is called whenever a refresh of the navigation of the hosting control should be preformed.</param>
        /// <param name="fallId">Identification number of the Fall</param>
        /// <param name="leistungId">Identification number of the Leistung</param>
        /// <param name="accessMode">Defines the calling control</param>
        public void Init(RefreshNavBar refreshNavBar, int? fallId, int? leistungId, AccessPendenzen accessMode)
        {
            RefreshNavBarItems = refreshNavBar;

            _leistungId = leistungId;
            _fallId = fallId;

            _sqlFilter = "WHERE 1 = 1";
            qryXTask.SelectStatement = GetXTaskSelectStatement();

            kissSearch.SelectStatement = qryXTask.SelectStatement;

            if (accessMode == AccessPendenzen.Leistung)
            {
                edtSucheVorname.EditMode = EditModeType.ReadOnly;
                edtSucheName.EditMode = EditModeType.ReadOnly;
                edtSucheFallID.EditMode = EditModeType.ReadOnly;
                edtFallLeistungBetrifftPerson.edtFaFall.EditMode = EditModeType.ReadOnly;
            }
            else if (accessMode == AccessPendenzen.Verwaltung)
            {
                edtSucheReceiverID.EditMode = EditModeType.ReadOnly;
            }

            _faFallDefaultEditMode = edtFallLeistungBetrifftPerson.edtFaFall.EditMode;
            _sucheReceiverDefaultEditMode = edtSucheReceiverID.EditMode;

            SetListItemColors();
        }

        /// <summary>
        /// Starts a new search
        /// </summary>
        public override void OnSearch()
        {
            // set focus to validate fields
            edtSucheVorname.Focus();

            // let base do stuff
            base.OnSearch();
        }

        protected override void NewSearch()
        {
            tabControlSearch.SelectTab(tpgSuchen);

            edtSucheFallID.EditValue = _fallId;

            base.NewSearch();
        }

        protected override void RunSearch()
        {
            qryXTask.Fill(qryXTask.SelectStatement.Replace("WHERE 1 = 1", _sqlFilter), kissSearch.SelectParameters);
            base.RunSearch();
        }

        private static void EmptyDelegate()
        {
        }

        private void ActionButtonClick(object sender, EventArgs e)
        {
            // Aktion ausführen
            var taskAction = ((KissButton)sender).Tag as TaskAction;
            var taskResult = TaskActionUtils.PerformActionResult.Ok;

            if (taskAction != null)
            {
                //Antwort in TaskAction übernehmen
                taskAction.Antwort = qryXTask["ResponseText"] as string;

                taskResult = TaskActionUtils.PerformAction(taskAction);
            }

            // check if task can be closed
            if (taskResult == TaskActionUtils.PerformActionResult.Ok)
            {
                qryXTask[DBO.XTask.TaskStatusCode] = 3;
                qryXTask[DBO.XTask.DoneDate] = DateTime.Today;
                qryXTask[DBO.XTask.UserID_Erledigt] = Session.User.UserID;

                // save changes
                if (qryXTask.Post())
                {
                    // refresh if possible, refresh list
                    qryXTask.Refresh();

                    //Delegate to a Method of the calling Class
                    // > already done in qryXTask_AfterPost (if no post is done, no changes were made and therefore no count is required > see #5906)
                    //// RefreshNavBarItems();

                    // set focus
                    grdXTask.Focus();
                }
            }
            else if (taskResult == TaskActionUtils.PerformActionResult.Nichtunterstuetzt)
            {
                KissMsg.ShowInfo(CLASSNAME, "InvalidActionForTaskType", "Die ausgewählte Aktion wird für diesen Pendenzentyp nicht unterstützt.");
            }
        }

        private void btnBatchApply_Click(Object sender, EventArgs e)
        {
            // store last cursor
            Cursor lastCursor = Cursor.Current;

            // create list
            List<int> selectedIDs = UpdateCounter();
            List<int> successfullyUpdatedIDs = null;

            // set flag to refresh list
            Boolean refreshListAndFinish = false;

            try
            {
                // INIT:
                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // VALIDATE:
                // check if any items are selected
                if (selectedIDs.Count < 1)
                {
                    // no item selected, do not continue
                    throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME, "KeinePendenzAusgewaehlt", "Es sind keine Pendenzen ausgewählt, bitte wählen Sie mindestens eine Pendenz zum Verarbeiten.", KissMsgCode.MsgError));
                }

                // save pending changes
                if (!qryXTask.Post())
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME, "FehlerBeimSpeichernKannNichtFortfahren", "Die Daten konnten nicht gespeichert werden, es kann nicht fortgefahren werden.", KissMsgCode.MsgError));
                }

                // PROCESS:
                // set flag
                refreshListAndFinish = true;

                // show dialog to let the user do the action he wants
                DlgPendenzSelektionVerarbeiten dlg = new DlgPendenzSelektionVerarbeiten(selectedIDs);
                dlg.ShowDialog(this);

                // let dialog close
                ApplicationFacade.DoEvents();

                // get successfully updated tasks
                successfullyUpdatedIDs = dlg.SuccessfullyUpdatedTasks;
            }
            catch (KissInfoException exi)
            {
                // show info
                KissMsg.ShowInfo(exi.Message);
            }
            catch (KissCancelException exc)
            {
                // handle exception
                exc.ShowMessage();
            }
            catch (Exception ex)
            {
                // general exception occured
                KissMsg.ShowError(CLASSNAME, "ErrorBatchUebergeben", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
            finally
            {
                // set last cursor
                Cursor.Current = lastCursor;

                // check if needed
                if (refreshListAndFinish)
                {
                    // refresh list
                    qryXTask.Refresh();

                    // reselected process-failed-tasks
                    ReselectProcessFailedTasks(selectedIDs, successfullyUpdatedIDs);

                    //Delegate to a Method of the calling Class
                    RefreshNavBarItems();
                }

                // set focus
                grdXTask.Focus();
            }
        }

        private void btnForward_Click(Object sender, EventArgs e)
        {
            DlgPendenzWeiterleiten dlg = new DlgPendenzWeiterleiten();

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                qryXTask[DBO.XTask.ReceiverID] = dlg.ReceiverID;
                qryXTask[DBO.XTask.TaskReceiverCode] = dlg.TaskReceiverCode;

                var description = KissMsg.GetMLMessage(CLASSNAME, "ForwardDescription", "WG: {0}, {1:d}\r\n{2}---\r\n{3}");
                qryXTask[DBO.XTask.TaskDescription] = String.Format(description,
                        qryXTask["Receiver"], DateTime.Now,
                        DBUtil.IsEmpty(dlg.TaskDescription) ? String.Empty : dlg.TaskDescription + Environment.NewLine,
                        qryXTask[DBO.XTask.TaskDescription]);

                qryXTask["Receiver"] = dlg.DisplayText;

                qryXTask.Post();
            }
        }

        private void btnJump_Click(Object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryXTask[DBO.XTask.JumpToPath]))
            {
                string tmp = Convert.ToString(qryXTask[DBO.XTask.JumpToPath]);
                System.Collections.Specialized.HybridDictionary dic = FormController.ConvertToDictionary(tmp);
                string className = Convert.ToString(dic["ClassName"]);
                dic.Add("Action", "JumpToPath");
                var result = FormController.OpenForm(className, dic);

                if (!result)
                {
                    // show info due to failure of call!!
                    KissMsg.ShowInfo(CLASSNAME, "JumpToPathFailure", "Es ist ein Fehler beim Aufrufen der gewünschten Maske aufgetreten. Wahrscheinlich werden nicht die richtigen Daten angezeigt.");
                }
            }
        }

        private void btnSelectAll_Click(Object sender, EventArgs e)
        {
            SelectItems(true);
        }

        private void btnSelectNone_Click(Object sender, EventArgs e)
        {
            SelectItems(false);
        }

        private void btnSetBearbeitung_Click(Object sender, EventArgs e)
        {
            qryXTask[DBO.XTask.TaskStatusCode] = 2;                     // in Bearbeitung
            qryXTask[DBO.XTask.StartDate] = DateTime.Today;
            qryXTask[DBO.XTask.UserID_InBearbeitung] = Session.User.UserID;

            if (Convert.ToInt32(qryXTask[DBO.XTask.TaskReceiverCode]) == 2)
            {
                qryXTask[DBO.XTask.TaskReceiverCode] = 1;               // empfängertyp "Person"
                qryXTask[DBO.XTask.ReceiverID] = Session.User.UserID;   // empfänger "ich selber"
                qryXTask["Receiver"] = DBUtil.ExecuteScalarSQL("SELECT DisplayText FROM dbo.vwUser WHERE UserID = {0}", Session.User.UserID);
            }

            qryXTask.Post();
        }

        private KissButton CreateActionButton(string text, object tag)
        {
            var btn = new KissButton
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Width = 100,
                Height = 24,
                Text = text ?? "",
                Tag = tag,
                Margin = new Padding(0, 0, 6, 6)
            };

            btn.Click += ActionButtonClick;
            return btn;
        }

        private void CtlPendenzenVerwaltung_Load(object sender, EventArgs e)
        {
            //Make sure, the columns appear readonly (except the one for selection)
            SetupColumns();
        }

        private void edtReceiver_UserModifiedFld(Object sender, UserModifiedFldEventArgs e)
        {
            // create a new dialog and show it
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PendenzEmpfaengerSuchen(edtReceiver.Text, false, e.ButtonClicked);

            // if not canceled, apply values
            if (!e.Cancel)
            {
                qryXTask["Receiver"] = dlg["DisplayText$"];
                qryXTask[DBO.XTask.ReceiverID] = dlg["ID$"];
                qryXTask[DBO.XTask.TaskReceiverCode] = dlg["TypeCode$"];
            }
        }

        private void edtSucheReceiverID_UserModifiedFld(Object sender, UserModifiedFldEventArgs e)
        {
            // create a new dialog and show it
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PendenzEmpfaengerSuchen(edtSucheReceiverID.Text, false, e.ButtonClicked);

            // if not canceled, apply values
            if (!e.Cancel)
            {
                edtSucheReceiverID.EditValue = dlg["DisplayText$"];
                edtSucheReceiverID.LookupID = dlg["ID$"];
                edtSucheTaskReceiverCode.EditValue = dlg["TypeCode$"];
            }
        }

        private void edtSucheSAR_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // create a new dialog and show it
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtSucheSAR.Text, e.ButtonClicked);

            // if not canceled, apply values
            if (!e.Cancel)
            {
                edtSucheSAR.EditValue = dlg["DisplayText$"];
                edtSucheSAR.LookupID = dlg["UserID"];
            }
        }

        private void edtSucheSenderID_UserModifiedFld(Object sender, UserModifiedFldEventArgs e)
        {
            // create a new dialog and show it
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PendenzEmpfaengerSuchen(edtSucheSenderID.Text, false, e.ButtonClicked);

            // if not canceled, apply values
            if (!e.Cancel)
            {
                edtSucheSenderID.EditValue = dlg["DisplayText$"];
                edtSucheSenderID.LookupID = dlg["ID$"];
                edtSucheTaskSenderCode.EditValue = dlg["TypeCode$"];
            }
        }

        private void edtTaskTypeCode_EditValueChanged(object sender, EventArgs e)
        {
            qryXTaskDetails.Fill(edtTaskTypeCode.EditValue, Session.User.LanguageCode);

            var subject = qryXTaskDetails[QRY_TASK_TYPE_SUBJECT];
            var description = qryXTaskDetails[QRY_TASK_TYPE_DESCRIPTION];

            //only apply value if it is different
            if (Utils.ConvertToInt(qryXTask[DBO.XTask.TaskTypeCode]) != Utils.ConvertToInt(edtTaskTypeCode.EditValue))
            {
                qryXTask[DBO.XTask.TaskTypeCode] = edtTaskTypeCode.EditValue;
            }

            // nur ersetzen, wenn leer oder neuer Datensatz, sonst gehen evtl. Benutzereingaben verloren
            var added = qryXTask.CurrentRowState == DataRowState.Added;

            if (!DBUtil.IsEmpty(subject) &&
                (DBUtil.IsEmpty(qryXTask[DBO.XTask.Subject]) || added))
            {
                qryXTask[DBO.XTask.Subject] = subject;
                //edtSubject.EditValue = subject;
            }

            if (!DBUtil.IsEmpty(description) &&
                (DBUtil.IsEmpty(qryXTask[DBO.XTask.TaskDescription]) || added))
            {
                qryXTask[DBO.XTask.TaskDescription] = description;
                //edtBeschreibung.EditValue = description;
            }
        }

        private string GetXTaskSelectStatement()
        {
            return @"
                SELECT
                      TSK.XTaskID,
                      TSK.FaFallID,
                      TSK.FaLeistungID,
                      TSK.BaPersonID,

                      TSK.TaskTypeCode,
                      TSK.TaskStatusCode,
                      TSK.CreateDate,
                      TSK.StartDate,
                      TSK.UserID_InBearbeitung,
                      TSK.ExpirationDate,
                      TSK.DoneDate,
                      TSK.UserID_Erledigt,
                      TSK.Subject,
                      TSK.TaskDescription,
                      TSK.SenderID,
                      TSK.TaskSenderCode,
                      TSK.ReceiverID,
                      TSK.TaskReceiverCode,
                      TSK.ResponseText,
                      TSK.TaskResponseCode,
                      TSK.JumpToPath,

                      Sender            = IsNull(UTR.DisplayText, GTR.Name),
                      Receiver          = IsNull(URX.DisplayText, GRX.Name),

                      FaFall            = PRS.Name + IsNull(', ' + PRS.Vorname, '') + ' (' + CONVERT(VARCHAR, FAL.FaFallID) + ')',
                      Fallnummer        = FAL.FaFallID,

                      UserID         = USR.UserID,
                      SAR            = USR.DisplayText,

                      FAL_BaPersonID = FAL.BaPersonID,
                      PersonFT       = PRS.Name + ISNULL(', ' + PRS.Vorname, ''),
                      PersonBP       = PRB.NameVorname,
                      ModulID        = LEI.ModulID,
                      LeistungModul  = MOD.ShortName,

                      OrgUnitID      = OUU.OrgUnitID,

                      Auswahl        = CONVERT(BIT, 0),
                      DatumVon       = CONVERT(INT, YEAR(TSK.CreateDate)),
                      SenderEMail    = UTR.EMail,
                      ReceiverEMail  = URX.EMail,
                      TSK.XTaskTS
                    FROM XTask                    TSK
                      LEFT  JOIN vwUser           UTR ON UTR.UserID = TSK.SenderID AND TSK.TaskSenderCode = 1
                      LEFT  JOIN FaPendenzgruppe  GTR ON GTR.FaPendenzgruppeID = TSK.SenderID AND TSK.TaskSenderCode = 2
                      LEFT  JOIN vwUser           URX ON URX.UserID = TSK.ReceiverID AND TSK.TaskReceiverCode = 1
                      LEFT  JOIN FaPendenzgruppe  GRX ON GRX.FaPendenzgruppeID = TSK.ReceiverID AND TSK.TaskReceiverCode = 2

                      LEFT  JOIN FaLeistung       LEI ON LEI.FaLeistungID = TSK.FaLeistungID
                      LEFT  JOIN FaFall           FAL ON FAL.FaFallID = IsNull(LEI.FaFallID, TSK.FaFallID)
                      LEFT  JOIN BaPerson         PRS ON PRS.BaPersonID = IsNull(LEI.BaPersonID, FAL.BaPersonID)
                      LEFT  JOIN vwUser           USR ON USR.UserID = IsNull(LEI.UserID, FAL.UserID)
                      LEFT  JOIN XOrgUnit_User    OUU ON OUU.UserID = USR.UserID
                                                     AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
                      LEFT  JOIN XModul           MOD ON MOD.ModulID = LEI.ModulID

                      LEFT  JOIN vwPersonSimple   PRB ON PRB.BaPersonID = TSK.BaPersonID
                    WHERE 1 = 1
                    ---  AND TSK.TaskStatusCode = {edtSucheTaskStatusCode}
                    ---  AND TSK.TaskTypeCode = {edtSucheTaskTypeCode}

                    ---  AND TSK.Subject LIKE '%' + {edtSucheSubject} + '%'

                    ---  AND TSK.SenderID = {edtSucheSenderID.LookupID} AND TSK.TaskSenderCode = {edtSucheTaskSenderCode}
                    ---  AND TSK.ReceiverID = {edtSucheReceiverID.LookupID} AND TSK.TaskReceiverCode = {edtSucheTaskReceiverCode}

                    ---  AND TSK.CreateDate >= {edtSucheCreateDateVon}
                    ---  AND TSK.CreateDate <= {edtSucheCreateDateBis}

                    ---  AND TSK.ExpirationDate >= {edtSucheExpirationDateVon}
                    ---  AND TSK.ExpirationDate <= {edtSucheExpirationDateBis}

                    ---  AND TSK.StartDate >= {edtSucheStartDateVon}
                    ---  AND TSK.StartDate <= {edtSucheStartDateBis}

                    ---  AND TSK.DoneDate >= {edtSucheDoneDateVon}
                    ---  AND TSK.DoneDate <= {edtSucheDoneDateBis}

                    ---  AND PRS.Name LIKE {edtSucheName} + '%'
                    ---  AND PRS.Vorname LIKE {edtSucheVorname} + '%'

                    ---  AND FAL.FaFallID = {edtSucheFallID}
                    ---  AND USR.UserID = {edtSucheSAR.LookupID}
                    ---  AND OUU.OrgUnitID = {edtSucheOrgUnit}
                    ---  AND LEI.FaLeistungID = {edtSucheLeistungID}";
        }

        /// <summary>
        /// Handles the LostFocus event of the grvXTask control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void grvXTask_LostFocus(Object sender, EventArgs e)
        {
            UpdateCounter();
        }

        private void qryXTask_AfterDelete(object sender, EventArgs e)
        {
            RefreshNavBarItems();
        }

        private void qryXTask_AfterFill(Object sender, EventArgs e)
        {
            if (qryXTask.Count == 0)
            {
                btnJump.Enabled = false;
                btnSetBearbeitung.Enabled = false;
                btnSetErledigt.Enabled = false;
                btnForward.Enabled = false;
                ActionsEnabled = false;
            }
            else
            {
                qryXTask.Last();
            }

            // update counter label
            UpdateCounter();
        }

        private void qryXTask_AfterInsert(Object sender, EventArgs e)
        {
            edtTaskTypeCode.EditMode = EditModeType.Normal;

            qryXTask[DBO.XTask.TaskStatusCode] = 1;				// Status "Pendent"
            qryXTask[DBO.XTask.TaskTypeCode] = 6;				// Pendenz Typ "Anfrage"
            qryXTask[DBO.XTask.TaskSenderCode] = 1;				// Erstellertyp "Person"
            qryXTask[DBO.XTask.SenderID] = Session.User.UserID;	// Ersteller "ich selber"

            //Wenn Control in FallBearbeitung geöffnet wird, ist die FaLeistungID bereits klar
            qryXTask[DBO.XTask.FaLeistungID] = _leistungId;

            qryXTask["Sender"] = DBUtil.ExecuteScalarSQL("SELECT DisplayText FROM dbo.vwUser WHERE UserID = {0}", Session.User.UserID);

            if (_fallId.HasValue)
            {
                string nameVorname = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                    SELECT TOP 1 PRS.Name + ISNull(', ' + PRS.Vorname, '')
                    FROM dbo.BaPerson PRS
                    LEFT JOIN dbo.FaFall FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = PRS.BaPersonID
                    WHERE FAL.FaFallID = {0}", _fallId));

                edtFallLeistungBetrifftPerson.edtFaFall.EditValue = nameVorname;
                qryXTask["FaFall"] = nameVorname;
                qryXTask[DBO.XTask.BaPersonID] = null;
            }

            edtFallLeistungBetrifftPerson.Init(_fallId, null);

            qryXTask[DBO.XTask.TaskReceiverCode] = 1; // Empfängertyp "Person"
            qryXTask["Auswahl"] = 0; // Auswahl = false

            edtTaskTypeCode.Focus();
        }

        private void qryXTask_AfterPost(Object sender, EventArgs e)
        {
            //Delegate to a Method of the calling Class
            RefreshNavBarItems();
            qryXTask_PositionChanged(sender, EventArgs.Empty);
        }

        private void qryXTask_BeforeDeleteQuestion(Object sender, EventArgs e)
        {
            bool isSender = Utils.ConvertToInt(qryXTask[DBO.XTask.SenderID]) == Session.User.UserID;
            bool isPendent = Utils.ConvertToInt(qryXTask[DBO.XTask.TaskStatusCode]) == 1;
            bool isAnfrage = Utils.ConvertToInt(qryXTask[DBO.XTask.TaskTypeCode]) == 6;
            bool isReceiver = Utils.ConvertToInt(qryXTask[DBO.XTask.ReceiverID]) == Session.User.UserID;

            var baPersonId = qryXTask[DBO.XTask.BaPersonID];
            int count = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(*)
                FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                WHERE BaPersonID = {0}",
                baPersonId);

            bool isLeistungVorhanden = !DBUtil.IsEmpty(baPersonId) && count > 0;

            // Ersteller muss angemeldeter Benutzer sein und muss Pendent sein,
            // oder Benutzer ist Empfänger und kein F-Modul vorhanden. (Wegen Personen-Löschen)
            // Dann kann Datensatz gelöscht werden.)
            if ((!isSender || !isPendent || !isAnfrage) && (!isReceiver || isLeistungVorhanden))
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "NurEigenePendLoeschen_v06",
                    "Sie können nur eigene Pendenzen mit Status 'pendent' löschen.{0}{0}(Ausser die betreffende Person besitzt keine Leistung mehr.)",
                    Environment.NewLine);

                throw new KissCancelException();
            }
        }

        private void qryXTask_BeforePost(Object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtTaskTypeCode, lblTaskTypeCode.Text);
            DBUtil.CheckNotNullField(edtSubject, lblSubject.Text);
            DBUtil.CheckNotNullField(edtReceiver, lblReceiver.Text);

            qryXTaskDetails.Fill(qryXTask[DBO.XTask.TaskTypeCode], Session.User.LanguageCode);
            if (qryXTaskDetails.Count == 0)
            {
                //Code ist gelöscht worden, gebe Fehlermeldung aus
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "CodeWurdeGeloescht",
                    "Der Code {0} wurde zwischenzeitlich gelöscht.",
                    edtTaskTypeCode.Text);

                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(qryXTask[DBO.XTask.FaLeistungID]))
            {
                //FaLeistungID ist leer, wir müssen FaFallID abspeichern
                qryXTask[DBO.XTask.FaFallID] = qryXTask["Fallnummer"];
            }
            else
            {
                //wenn wir einen Wert für FaLeistungID haben, müssen wir nicht noch FaFallID speichern
                //(Information wäre redundant, da bereits in FaLeistung enthalten)
                qryXTask[DBO.XTask.FaFallID] = null;
            }

            //Berechnete Felder aktualisieren
            qryXTask["ModulID"] = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT ModulID
                FROM dbo.FaLeistung
                WHERE FaLeistungID = {0}",
                qryXTask[DBO.XTask.FaLeistungID]);

            qryXTask["PersonFT"] = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT NameVorname
                FROM dbo.vwPersonSimple
                WHERE BaPersonID = {0}",
                qryXTask[DBO.XTask.BaPersonID]);

            qryXTask["SAR"] = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT USR.DisplayText
                FROM dbo.vwUser USR
                  LEFT  JOIN FaLeistung       LEI ON LEI.FaLeistungID = {0}
                  LEFT  JOIN FaFall           FAL ON FAL.FaFallID = {1}
                WHERE USR.UserID = IsNull(LEI.UserID, FAL.UserID)",
                qryXTask[DBO.XTask.FaLeistungID], qryXTask[DBO.XTask.FaFallID]);

            if (_preventUpdateDetails)
            {
                // discard changes
                qryXTask.RowModified = false;
                qryXTask.Row.AcceptChanges();
            }
        }

        /// <summary>
        /// Handles the ColumnChanged event of the qryXTask control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Data.DataColumnChangeEventArgs"/> instance containing the event data.</param>
        private void qryXTask_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            // get new states
            Boolean isRowModifiedInChanged = qryXTask.RowModified;
            Boolean isRowSelectedInChanged = !DBUtil.IsEmpty(qryXTask["Auswahl"]) && Convert.ToBoolean(qryXTask["Auswahl"]);

            // check if only selection changed, so we do not want to save changes in database
            if (!_isRowModifiedInChanging && isRowModifiedInChanged &&
                ((_isRowSelectedInChanging && !isRowSelectedInChanged) || (!_isRowSelectedInChanging && isRowSelectedInChanged)))
            {
                // ATTENTION: prevent post, only selection has changed, so reset row modified and prevent Post on query
                qryXTask.Row.AcceptChanges();
                qryXTask.RowModified = false;
                qryXTask.RefreshDisplay();
            }
        }

        /// <summary>
        /// Handles the ColumnChanging event of the qryXTask control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Data.DataColumnChangeEventArgs"/> instance containing the event data.</param>
        private void qryXTask_ColumnChanging(Object sender, DataColumnChangeEventArgs e)
        {
            _isRowModifiedInChanging = qryXTask.RowModified;
            _isRowSelectedInChanging = !DBUtil.IsEmpty(qryXTask["Auswahl"]) && Convert.ToBoolean(qryXTask["Auswahl"]);
        }

        private void qryXTask_PositionChanged(Object sender, EventArgs e)
        {
            // check if need to do action
            if (_preventUpdateDetails)
            {
                // prevent update CtlGotoFall
                ctlGotoFall.DataSource = null;

                // do nothing more
                return;
            }

            // apply datasource again if not defined
            if (ctlGotoFall.DataSource == null)
            {
                // set datasource again
                ctlGotoFall.DataSource = qryXTask;
            }

            // update counter label
            UpdateCounter();

            UpdateActionButtons();

            if (qryXTask.Row == null)
            {
                // do nothing
            }
            else if (qryXTask.Row.RowState == DataRowState.Added)
            {
                btnJump.Enabled = false;
                btnSetBearbeitung.Enabled = false;
                btnSetErledigt.Enabled = false;
                btnForward.Enabled = false;
                ActionsEnabled = false;

                edtTaskTypeCode.EditMode = EditModeType.Normal;
                edtTaskTypeCode.LOVFilter = "Value3 IS NULL";
                edtTaskTypeCode.LOVName = "TaskType";

                edtSubject.EditMode = EditModeType.Normal;
                edtBeschreibung.EditMode = EditModeType.Normal;

                edtReceiver.EditMode = EditModeType.Normal;
                // If the default edit mode is readonly (set in init), the edit mode is never changed
                if (_faFallDefaultEditMode != EditModeType.ReadOnly)
                {
                    edtFallLeistungBetrifftPerson.edtFaFall.EditMode = EditModeType.Normal;
                }

                edtFallLeistungBetrifftPerson.edtFaLeistungID.EditMode = EditModeType.Normal;
                edtFallLeistungBetrifftPerson.edtBaPersonID.EditMode = EditModeType.Normal;

                edtExpirationDate.EditMode = EditModeType.Normal;

                edtResponseText.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                //Absprung ist möglich wenn:
                //-JumpToPath vorhanden
                btnJump.Enabled = !DBUtil.IsEmpty(qryXTask[DBO.XTask.JumpToPath]);

                //Bearbeitung (inkl. erledigen + weiterleiten) ist möglich wenn:
                //-aktueller User ist Empfänger oder LV oder hat schreibendes Gastrecht in Leistung
                // oder ist Mitglieder oder Gastmitglied der OE des LV der Empfängers

                bool userIsReceiver = (Utils.ConvertToInt(qryXTask[DBO.XTask.TaskReceiverCode]) == 1 /*1:Person*/
                                       && Utils.ConvertToInt(qryXTask[DBO.XTask.ReceiverID]) == Session.User.UserID);
                bool userIsLV = (Utils.ConvertToInt(qryXTask["UserID"]) == Session.User.UserID);
                bool userHasSchreibendesGastrecht = DBUtil.ExecuteScalarSQL(@"
                    SELECT DarfMutieren
                    FROM FaLeistungZugriff
                    WHERE FaLeistungID = {0}
                      AND UserID = {1}",
                        qryXTask[DBO.XTask.FaLeistungID],
                        Session.User.UserID) as bool? ?? false;
                bool userIsSchreibendesMitglied = DBUtil.ExecuteScalarSQL(@"
                    SELECT CONVERT(BIT, MAX(CONVERT(INT, OUU_CurrentUser.MayUpdate)))
                    FROM XOrgUnit_User OUU_LV_Receiver
                      LEFT JOIN XOrgUnit_User OUU_CurrentUser ON OUU_CurrentUser.OrgUnitID = OUU_LV_Receiver.OrgUnitID
                    WHERE OUU_LV_Receiver.UserID IN ({0}, {1})
                      AND OUU_LV_Receiver.OrgUnitMemberCode = 2 --2: Mitglied
                      AND OUU_CurrentUser.UserID = {2}",
                        qryXTask["UserID"],
                        qryXTask["ReceiverID"],
                        Session.User.UserID) as bool? ?? false;

                bool modificationAllowed = qryXTask.CanUpdate && (userIsReceiver || userIsLV || userHasSchreibendesGastrecht || userIsSchreibendesMitglied);

                //Task kann erledigt werden wenn:
                //-Task noch nicht erledigt und Benutzer hat Recht zur Bearbeitung
                //-Ausnahme: Visum-Task kann nicht erledigt werden. (Jump auf Maske und Visum erteilen)

                ActionsEnabled = Utils.ConvertToInt(qryXTask[DBO.XTask.TaskStatusCode]) < 3 /*3:erledigt*/
                                         && modificationAllowed
                                         && !(btnJump.Enabled && Utils.ConvertToInt(qryXTask[DBO.XTask.TaskTypeCode]) == 2 /*2:Visum*/);
                btnSetErledigt.Enabled = ActionsEnabled;

                //Bearbeiten ist möglich wenn:
                //-Task ist pendent UND
                //  -aktueller User ist Empfänger oder LV oder hat schreibendes Gastrecht in Leistung
                //  ODER
                //  -aktueller User ist Mitglieder oder GastMitglied der OE des LV oder Empfängers mit M-Recht
                btnSetBearbeitung.Enabled = Utils.ConvertToInt(qryXTask[DBO.XTask.TaskStatusCode]) == 1 /*1:pendent*/
                                            && modificationAllowed;

                //Weiterleiten ist möglich wenn:
                //-Task noch nicht erledigt
                btnForward.Enabled = Utils.ConvertToInt(qryXTask[DBO.XTask.TaskStatusCode]) < 3 /*3:erledigt*/
                                     && modificationAllowed;

                //TaskTyp kann grundsätzlich nicht verändert werden, wenn der Task mal gespeichert wurde
                edtTaskTypeCode.EditMode = EditModeType.ReadOnly;

                if (!DBUtil.IsEmpty(edtTaskTypeCode.LOVFilter))
                {
                    edtTaskTypeCode.LOVFilter = "";
                    edtTaskTypeCode.LOVName = "TaskType";
                }

                //Subject/Beschreibung/Receiver/BetrifftPerson/Leistung/Fälligkeit kann angepasst werden wenn:
                //-Task kommt von aktuellem Benutzer
                //-Task ist pendent
                EditModeType editMode = EditModeType.ReadOnly;
                bool userIsSender = Utils.ConvertToInt(qryXTask[DBO.XTask.SenderID]) == Session.User.UserID &&
                                    Utils.ConvertToInt(qryXTask[DBO.XTask.TaskSenderCode]) == 1;
                if (userIsSender
                    && Utils.ConvertToInt(qryXTask[DBO.XTask.TaskStatusCode]) == 1
                    && qryXTask.CanUpdate)
                {
                    editMode = EditModeType.Normal;
                }

                edtSubject.EditMode = editMode;
                edtBeschreibung.EditMode = editMode;
                edtReceiver.EditMode = editMode;

                if (_faFallDefaultEditMode != EditModeType.ReadOnly)
                {
                    // If the default edit mode is readonly (set in init), the edit mode is never changed
                    edtFallLeistungBetrifftPerson.edtFaFall.EditMode = editMode;
                }

                edtFallLeistungBetrifftPerson.edtBaPersonID.EditMode = editMode;

                //falls ConfigWert aktiv und Empfanger dann darf edtExpirationDate ändern, sonst analog editMode
                edtExpirationDate.EditMode =
                        DBUtil.GetConfigBool(@"System\Pendenzen\Pendenzenverwaltung\FaelligkeitsdatumVomEmpfaengerEditierbar", false) && Session.IsKiss5Mode
                        ? (userIsReceiver || userIsSender)
                                && qryXTask.CanUpdate
                                && (Utils.ConvertToInt(qryXTask[DBO.XTask.TaskStatusCode]) == 1)
                                ? EditModeType.Normal
                                : EditModeType.ReadOnly
                            : editMode;

                //Leistung ist editierbar wenn Benutzer das Recht zu bearbeiten hat
                edtFallLeistungBetrifftPerson.edtFaLeistungID.EditMode = modificationAllowed ? EditModeType.Normal : EditModeType.ReadOnly;

                //ResponseText ist editierbar wenn Button 'Erledigt' aktiv ist
                edtResponseText.EditMode = btnSetErledigt.Enabled ? EditModeType.Normal : EditModeType.ReadOnly;
            }

            edtFallLeistungBetrifftPerson.Init(qryXTask["Fallnummer"] as int?, qryXTask[DBO.XTask.BaPersonID] as int?);
            qryXTask.EnableBoundFields();
            ctlBearbeitungErledigt.ShowInfo();
        }

        /// <summary>
        /// Reselects the process failed tasks.
        /// </summary>
        /// <param name="selectedIDs">The selected I ds.</param>
        /// <param name="successfullyUpdatedIDs">The successfully updated I ds.</param>
        private void ReselectProcessFailedTasks(List<int> selectedIDs, List<int> successfullyUpdatedIDs)
        {
            // validate lists
            if (selectedIDs == null || selectedIDs.Count < 1 || successfullyUpdatedIDs == null)
            {
                // do nothing, invalid parameters
                return;
            }

            try
            {
                // check if any row is available
                if (qryXTask.Count < 1)
                {
                    // no row, do not continue
                    return;
                }

                // prevent update details
                _preventUpdateDetails = true;

                // save pending changes
                if (!qryXTask.Post())
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME, "FehlerBeimSpeichernAuswahlNichtVeraendern", "Die Daten konnten nicht gespeichert werden, die Auswahl kann nicht verändert werden."));
                }

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // set selection
                foreach (DataRow row in qryXTask.DataTable.Rows)
                {
                    // check if item was selected before processing
                    if (!DBUtil.IsEmpty(row["XTaskID"]) && selectedIDs.Contains(Convert.ToInt32(row["XTaskID"])))
                    {
                        // set flag depending on update success
                        row["Auswahl"] = successfullyUpdatedIDs.Contains(Convert.ToInt32(row["XTaskID"])) ? 0 : 1;

                        // prevent row modified
                        row.AcceptChanges();
                    }
                }

                // prevent data changed (we did save data above)
                qryXTask.Row.AcceptChanges();
                qryXTask.RowModified = false;
                qryXTask.RefreshDisplay();

                // check if row is selected
                if (grvXTask.GetSelectedRows().Length > 0)
                {
                    // update selected row to have proper display for selection
                    grvXTask.RefreshRow(grvXTask.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError(
                    CLASSNAME,
                    "ErrorReSelectingItems",
                    "Es ist ein Fehler beim Wiederauswählen der Pendenzen aufgetreten.",
                    ex);
            }
            finally
            {
                // allow update details
                _preventUpdateDetails = false;

                // update counter label
                UpdateCounter();

                // update states
                qryXTask_PositionChanged(this, EventArgs.Empty);

                // set focus
                grdXTask.Focus();
            }
        }

        /// <summary>
        /// Selects the items.
        /// </summary>
        /// <param name="selected">if set to <c>true</c> [selected].</param>
        private void SelectItems(Boolean selected)
        {
            // store last cursor
            Cursor lastCursor = Cursor.Current;

            try
            {
                // check if any row is available
                if (qryXTask.Count < 1)
                {
                    // no row, do not continue
                    return;
                }

                // prevent update details
                _preventUpdateDetails = true;

                // save pending changes
                if (!qryXTask.Post())
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME, "FehlerBeimSpeichernAuswahlNichtVeraendern", "Die Daten konnten nicht gespeichert werden, die Auswahl kann nicht verändert werden."));
                }

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // set selection
                foreach (DataRow row in qryXTask.DataTable.Rows)
                {
                    // set flag
                    row["Auswahl"] = selected ? 1 : 0;

                    // prevent row modified
                    row.AcceptChanges();
                }

                // prevent data changed (we did save data above)
                qryXTask.Row.AcceptChanges();
                qryXTask.RowModified = false;
                qryXTask.RefreshDisplay();

                // check if row is selected
                if (grvXTask.GetSelectedRows().Length > 0)
                {
                    // update selected row to have proper display for selection
                    grvXTask.RefreshRow(grvXTask.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                // show error message
                if (selected)
                {
                    // did select
                    KissMsg.ShowError(
                        CLASSNAME,
                        "ErrorSelectingItems",
                        "Es ist ein Fehler beim Auswählen der Pendenzen aufgetreten.",
                        ex);
                }
                else
                {
                    // did unselect
                    KissMsg.ShowError(
                        CLASSNAME,
                        "ErrorUnSelectingItems",
                        "Es ist ein Fehler beim Abwählen der Pendenzen aufgetreten.",
                        ex);
                }
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
                qryXTask_PositionChanged(this, EventArgs.Empty);

                // set focus
                grdXTask.Focus();
            }
        }

        private void SetListItemColors()
        {
            // apply colors to grid
            grvXTask.Appearance.FocusedCell.BackColor = GuiConfig.GridFocusedSelectionBackColor;
            grvXTask.Appearance.FocusedCell.ForeColor = Color.White;
            grvXTask.Appearance.FocusedRow.BackColor = GuiConfig.GridFocusedSelectionBackColor;
            grvXTask.Appearance.FocusedRow.ForeColor = Color.White;
            grvXTask.Appearance.HideSelectionRow.BackColor = GuiConfig.GridUnfocusedSelectionBackColor;
            grvXTask.Appearance.HideSelectionRow.ForeColor = SystemColors.WindowText;
            grvXTask.Appearance.HideSelectionRow.Options.UseBackColor = true;
            grvXTask.Appearance.HideSelectionRow.Options.UseForeColor = true;
        }

        private void SetupColumns()
        {
            grdXTask.SetColumnEditable(colAuswahl, true);
            grdXTask.SetColumnEditable(colBaPerson, false);
            grdXTask.SetColumnEditable(colDoneDate, false);
            grdXTask.SetColumnEditable(colErfasst, false);
            grdXTask.SetColumnEditable(colExpirationDate, false);
            grdXTask.SetColumnEditable(colFaFall, false);
            grdXTask.SetColumnEditable(colFallnummer, false);
            grdXTask.SetColumnEditable(colLeistung, false);
            grdXTask.SetColumnEditable(colReceiver, false);
            grdXTask.SetColumnEditable(colResponseText, false);
            grdXTask.SetColumnEditable(colSender, false);
            grdXTask.SetColumnEditable(colStartDate, false);
            grdXTask.SetColumnEditable(colSubject, false);
            grdXTask.SetColumnEditable(colTaskStatusCode, false);

            grdXTask.SetSelectionColor(false);
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // save pending changes on current query
            if (!OnSaveData())
            {
                // failed, cancel
                // return;
            }
        }

        private void UpdateActionButtons()
        {
            // Remove existing buttons
            var actionButtons = panAktionen.Controls.OfType<KissButton>().Where(btn => btn.Tag != null).ToList();
            foreach (var actionButton in actionButtons)
            {
                actionButton.Click -= ActionButtonClick;
                panAktionen.Controls.Remove(actionButton);
            }

            // Add buttons
            if (!qryXTask.IsEmpty)
            {
                var qryActions = DBUtil.OpenSQL(@"
                    SELECT
                      XTaskTypeActionID,
                      XTaskTypeActionTypeCode,
                      TaskTypeCode,
                      BenachrichtigungAktiv,
                      ErstellerDarfAusfuehren,
                      BezeichnungML = dbo.fnGetMLTextByDefault(BezeichnungTID, {1}, Bezeichnung),
                      BetreffML = dbo.fnGetMLTextByDefault(BetreffTID, {1}, Betreff),
                      TextML = dbo.fnGetMLTextByDefault(TextTID, {1}, Text)
                    FROM dbo.XTaskTypeAction WITH(READUNCOMMITTED)
                    WHERE TaskTypeCode = {0};",
                    qryXTask[DBO.XTask.TaskTypeCode],
                    Session.User.LanguageCode);

                if (qryActions.IsEmpty)
                {
                    btnSetErledigt.Visible = true;
                }
                else
                {
                    btnSetErledigt.Visible = false;
                    foreach (DataRow row in qryActions.DataTable.Rows)
                    {
                        var taskAction = new TaskAction
                        {
                            BaPersonId = qryXTask[DBO.XTask.BaPersonID] as int?,
                            BenachrichtigungAktiv = Utils.ConvertToBool(row[DBO.XTaskTypeAction.BenachrichtigungAktiv]),
                            Betreff = row["BetreffML"] as string,
                            Bezeichnung = row["BezeichnungML"] as string,
                            CreateDate = Utils.ConvertToDateTime(qryXTask[DBO.XTask.CreateDate]),
                            FaLeistungId = qryXTask[DBO.XTask.FaLeistungID] as int?,
                            ModulId = qryXTask[DBO.FaLeistung.ModulID] as int?,
                            SenderUserID = qryXTask[DBO.XTask.SenderID] as int?,
                            TaskType = (LOVsGenerated.TaskType)Utils.ConvertToInt(qryXTask[DBO.XTask.TaskTypeCode]),
                            Text = row["TextML"] as string,
                            XTaskId = Utils.ConvertToInt(qryXTask[DBO.XTask.XTaskID]),
                            XTaskTypeActionId = Utils.ConvertToInt(row[DBO.XTaskTypeAction.XTaskTypeActionID]),
                            XTaskTypeActionType = (LOVsGenerated.XTaskTypeActionType)Utils.ConvertToInt(row[DBO.XTaskTypeAction.XTaskTypeActionTypeCode]),
                            SenderEmail = qryXTask["SenderEMail"] as string,
                            ReceiverEmail = qryXTask["ReceiverEMail"] as string,
                            PersonFT = qryXTask["PersonFT"] as string,
                            PersonBP = qryXTask["PersonBP"] as string,
                            Modul = qryXTask["LeistungModul"] as string,
                            ErstellerDarfAusfuehren = Utils.ConvertToBool(row[DBO.XTaskTypeAction.ErstellerDarfAusfuehren])
                        };

                        var button = CreateActionButton(taskAction.Bezeichnung, taskAction);
                        panAktionen.Controls.Add(button);
                    }
                }
            }
        }

        /// <summary>
        /// Updates the counter.
        /// </summary>
        /// <returns></returns>
        private List<int> UpdateCounter()
        {
            // init list
            List<int> selectedIDs = new List<int>();

            // check if need to do action
            if (_preventUpdateDetails)
            {
                // do nothing
                return selectedIDs;
            }

            // loop through items and count selected items
            foreach (DataRow row in qryXTask.DataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted && row.RowState != DataRowState.Detached &&
                        !DBUtil.IsEmpty(row["Auswahl"]) && Convert.ToBoolean(row["Auswahl"]))
                {
                    // validate XTaskID
                    if (!DBUtil.IsEmpty(row["XTaskID"]))
                    {
                        // add id to list
                        selectedIDs.Add(Convert.ToInt32(row["XTaskID"]));
                    }
                }
            }

            // get count
            /*
            int totalAmount = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1) FROM XTask"));
            */

            // update label
            var textAnzahlPendenAusgewaehlt = KissMsg.GetMLMessage(CLASSNAME, "AnzahlPendenAusgewaehlt", "{0} von {1} Pendenzen ausgewählt");
            lblGewaehlteZeilen.Text = String.Format(textAnzahlPendenAusgewaehlt, selectedIDs.Count, qryXTask.Count);

            // return selected items
            return selectedIDs;
        }
    }
}