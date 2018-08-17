using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Pendenzen
{
    public partial class DlgPendenzSelektionVerarbeiten : KissDialog
    {
        // store the XTaskIDs the user selected
        private readonly List<int> _selectedIDs = new List<int>();

        private bool _specialRightUebergebenSource;

        // store the affected, updated IDs
        private List<int> _successfullyUpdatedIDs = new List<int>();

        // store the type of source for Uebergeben (1=user, 2=group)
        private int _uebergebenSourceTypeCode = -1;

        // store the type of receiver for Uebergeben (1=user, 2=group)
        private int _uebergebenTargetTypeCode = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgPendenzSelektionVerarbeiten"/> class.
        /// </summary>
        public DlgPendenzSelektionVerarbeiten()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgPendenzSelektionVerarbeiten"/> class.
        /// </summary>
        /// <param name="selectedIDs">The selected I ds.</param>
        public DlgPendenzSelektionVerarbeiten(List<int> selectedIDs)
            : this()
        {
            _selectedIDs = selectedIDs;
            qryXTask.SelectStatement = GetXTaskSelectStatement();
            qryXTask.Fill();
            UpdateActionButtons();
        }

        /// <summary>
        /// Gets the successfully updated tasks.
        /// </summary>
        /// <value>The successfully updated tasks.</value>
        public List<int> SuccessfullyUpdatedTasks
        {
            get
            {
                return _successfullyUpdatedIDs;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnPendenzenErledigen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ActionButtonClick(object sender, EventArgs e)
        {
            // store last cursor
            Cursor lastCursor = Cursor.Current;

            try
            {
                // INIT:
                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // VALIDATE:
                // validate selected ids
                ValidateSelectedIDs();

                // CONFIRM:
                // confirm first
                if (!KissMsg.ShowQuestion(Name, "btnPendenzenErledigenConfirm", "Wollen Sie die ausgewählten Pendenzen nun erledigen?\r\n\r\nAchtung: Diese Aktion kann nicht rückgängig gemacht werden."))
                {
                    // do not continue
                    return;
                }

                // DO UPDATE STATE
                // init vars
                List<int> successfullyUpdatedIDs = new List<int>(); // list successfully updated tasks

                // Aktion ausführen
                var taskActions = ((KissButton)sender).Tag as List<TaskAction>;
                foreach (var taskId in _selectedIDs)
                {
                    var taskSucceeded = TaskActionUtils.PerformActionResult.Ok;
                    if (taskActions != null)
                    {
                        var taskAction = taskActions.FirstOrDefault(x => x.XTaskId == taskId);

                        if (taskAction != null)
                        {
                            taskSucceeded = TaskActionUtils.PerformAction(taskAction);
                        }
                    }

                    // check if task can be closed
                    if (taskSucceeded == TaskActionUtils.PerformActionResult.Ok)
                    {
                        var affectedRows = Utils.ConvertToInt(
                            DBUtil.ExecuteScalarSQL(@"
                                    UPDATE XTask
                                    SET TaskStatusCode = 3,
                                        DoneDate = {0},
                                        UserID_Erledigt = {1}
                                    WHERE XTaskID = {2};
                                    SELECT ISNULL(@@ROWCOUNT, -1);",
                                DateTime.Today,
                                Session.User.UserID,
                                taskId));

                        // check if row was affected
                        if (affectedRows > 1)
                        {
                            // should not happen!!
                            throw new Exception(string.Format("More than one row was affected by update, security check has stopped execution (XTaskID='{0}', AffectedRows='{1}')", taskId, affectedRows));
                        }

                        if (affectedRows == 1)
                        {
                            // this task was updated successfully, we add it to the list
                            successfullyUpdatedIDs.Add(taskId);
                        }
                    }
                }

                // FINISH
                // set result to output
                _successfullyUpdatedIDs = successfullyUpdatedIDs;

                // show info
                KissMsg.ShowInfo(Name, "TaskCompletedInfo", "Es wurden '{0}' von '{1}' ausgewählten Pendenzen erfolgreich erledigt.", 0, 0, _successfullyUpdatedIDs.Count, _selectedIDs.Count);

                // if we are here, everything is ok
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (KissInfoException exi)
            {
                // show info
                KissMsg.ShowInfo(string.Format("{0}", exi.Message));
            }
            catch (KissCancelException exc)
            {
                // handle exception
                exc.ShowMessage();
            }
            catch (Exception ex)
            {
                // general exception occured
                KissMsg.ShowError(Name, "ErrorBatchErledigen", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
            finally
            {
                // set last cursor
                Cursor.Current = lastCursor;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnPendenzenUebergeben control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnPendenzenUebergeben_Click(object sender, EventArgs e)
        {
            Cursor lastCursor = Cursor.Current;

            try
            {
                // INIT:
                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // VALIDATE:
                // validate selected ids
                ValidateSelectedIDs();

                // check mustfields
                DBUtil.CheckNotNullField(edtUebergebenSource, lblUebergebenSource.Text);
                DBUtil.CheckNotNullField(edtUebergebenTarget, lblUebergebenTarget.Text);

                // setup vars
                int sourceIDSender = DBUtil.IsEmpty(edtUebergebenSource.LookupID) ? -1 : Convert.ToInt32(edtUebergebenSource.LookupID);
                int targetIDReceiver = DBUtil.IsEmpty(edtUebergebenTarget.LookupID) ? -1 : Convert.ToInt32(edtUebergebenTarget.LookupID);

                // must be valid
                if (sourceIDSender < 1 || _uebergebenSourceTypeCode < 1 || targetIDReceiver < 1 || _uebergebenTargetTypeCode < 1)
                {
                    // error
                    edtUebergebenTarget.Focus();
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "ErrorPendenzenUebergebenID", "Ungültige IDs oder Typen, die Übergabe kann nicht durchgeführt werden (sender={0}/{1}, receiver={2}/{3}).", sourceIDSender, _uebergebenSourceTypeCode, targetIDReceiver, _uebergebenTargetTypeCode));
                }

                // cannot be same
                if (sourceIDSender == targetIDReceiver)
                {
                    // error
                    edtUebergebenTarget.Focus();
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "ErrorPendenzenSameTarget", "Die Pendenzen können nicht an dieselbe Person übergeben werden."));
                }

                // CONFIRM:
                // confirm first
                if (!KissMsg.ShowQuestion(Name, "ConfirmTaskReassign", "Wollen Sie die ausgewählten Pendenzen von '{0}' nun an '{1}' übergeben?\r\n\r\nAchtung: Diese Aktion kann nicht rückgängig gemacht werden.", false, edtUebergebenSource.Text, edtUebergebenTarget.Text))
                {
                    // do not continue
                    return;
                }

                // DO UPDATE RECEIVER
                // init vars
                // list successfully updated tasks
                List<int> successfullyUpdatedIDs = new List<int>();

                // loop for each selectedid
                foreach (int xTaskID in _selectedIDs)
                {
                    // update XTask
                    int affectedRows = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                            UPDATE XTask
                            SET ReceiverID = {0}, TaskReceiverCode = {1}
                            WHERE XTaskID = {2} AND
                                  ((SenderID = {3} AND TaskSenderCode = {4}) OR (ReceiverID = {3} AND TaskReceiverCode = {4}))

                            SELECT ISNULL(@@ROWCOUNT, -1)", targetIDReceiver, _uebergebenTargetTypeCode, xTaskID, sourceIDSender, _uebergebenSourceTypeCode));

                    // check if row was affected
                    if (affectedRows > 1)
                    {
                        // should not happen!!
                        throw new Exception(string.Format("More than one row was affected by update, security check has stopped execution (XTaskID='{0}', AffectedRows='{1}')", xTaskID, affectedRows));
                    }

                    if (affectedRows == 1)
                    {
                        // this task was updated successfully, we add it to the list
                        successfullyUpdatedIDs.Add(xTaskID);
                    }
                }

                // FINISH
                // set result to output
                _successfullyUpdatedIDs = successfullyUpdatedIDs;

                // show info
                KissMsg.ShowInfo(Name, "InfoTaskReassignSuccess", "Es wurden '{0}' von '{1}' ausgewählten Pendenzen erfolgreich mutiert.", 0, 0, _successfullyUpdatedIDs.Count, _selectedIDs.Count);

                // if we are here, everything is ok
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (KissInfoException exi)
            {
                // show info
                KissMsg.ShowInfo(string.Format("{0}", exi.Message));
            }
            catch (KissCancelException exc)
            {
                // handle exception
                exc.ShowMessage();
            }
            catch (Exception ex)
            {
                // general exception occured
                KissMsg.ShowError("DlgPendenzSelektionVerarbeiten", "ErrorBatchUebergeben", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
            finally
            {
                // set last cursor
                Cursor.Current = lastCursor;
            }
        }

        private void btnSetBearbeitung_Click(Object sender, EventArgs e)
        {
            var ids = string.Join(", ", _selectedIDs);
            DBUtil.ExecSQL(string.Format(@"
                UPDATE XTask
                SET TaskStatusCode = 2,
                    StartDate = {{0}},
                    UserID_InBearbeitung = {{1}}
                WHERE XTaskID IN ({0});", ids), DateTime.Today, Session.User.UserID);

            DBUtil.ExecSQL(string.Format(@"
                UPDATE XTask
                SET TaskReceiverCode = 1,
                    ReceiverID = {{0}}
                WHERE TaskReceiverCode = 2
                  AND XTaskID IN ({0});", ids), Session.User.UserID);

            Close();
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

        /// <summary>
        /// Handles the Load event of the DlgPendenzSelektionVerarbeiten control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DlgPendenzSelektionVerarbeiten_Load(object sender, EventArgs e)
        {
            // validate selected ids
            ValidateSelectedIDs();

            // get current user's text
            string currentUserLogonNameVornameOrgUnit = DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL((SELECT TOP 1 USR.LogonNameVornameOrgUnit
                                   FROM vwUser USR
                                   WHERE USR.UserID = {0}), '')", Session.User.UserID) as string;

            // special rights
            _specialRightUebergebenSource = DBUtil.UserHasRight("DlgPendenzSelektionVerarbeiten_UebergebenSourceEditieren");

            // setup UebergebenSource
            _uebergebenSourceTypeCode = 1; // type of source for Uebergeben (1=user, 2=group)
            edtUebergebenSource.EditMode = _specialRightUebergebenSource ? EditModeType.Normal : EditModeType.ReadOnly;
            edtUebergebenSource.EditValue = currentUserLogonNameVornameOrgUnit;
            edtUebergebenSource.LookupID = Session.User.UserID;

            // setup controls
            edtSelectedIDsCount.EditValue = _selectedIDs.Count;
            tabPendenzenJobs.SelectTab(tpgUebergeben);
        }

        private void edtUebergebenSource_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtUebergebenSource.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            KissLookupDialog dlg = new KissLookupDialog();
            if (e.ButtonClicked || !DBUtil.IsEmpty(searchString))
            {
                if (DBUtil.IsEmpty(searchString))
                    searchString = "%";

                e.Cancel = !dlg.SearchData(@"
                    SELECT Typ = 'Benutzer', [Kürzel] = USR.LogonName, Name = USR.NameVorname, Abteilung = USR.OrgEinheitName,
                      ID$ = USR.UserID, TypeCode$ = 1, DisplayText$ = USR.DisplayText
                    FROM vwUser   USR
                    WHERE DisplayText LIKE '%' + {0} + '%'

                    UNION ALL
                    SELECT 'Gruppe', NULL, Name, NULL, FaPendenzgruppeID, TypeCode$ = 2, Name
                    FROM FaPendenzgruppe
                    WHERE Name LIKE '%' + {0} + '%'
                      AND Name NOT LIKE 'migrierte_Grp_%'

                    ORDER BY TypeCode$ DESC, Name
                    ", searchString, e.ButtonClicked);

                if (e.Cancel) return;
            }

            _uebergebenSourceTypeCode = DBUtil.IsEmpty(dlg["TypeCode$"]) ? -1 : Convert.ToInt32(dlg["TypeCode$"]);
            edtUebergebenSource.EditValue = dlg["DisplayText$"];
            edtUebergebenSource.LookupID = dlg["ID$"];
        }

        private void edtUebergebenTarget_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtUebergebenTarget.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            KissLookupDialog dlg = new KissLookupDialog();
            if (e.ButtonClicked || !DBUtil.IsEmpty(searchString))
            {
                if (DBUtil.IsEmpty(searchString))
                    searchString = "%";

                e.Cancel = !dlg.SearchData(@"
                    SELECT Typ = 'Benutzer', [Kürzel] = USR.LogonName, Name = USR.NameVorname, Abteilung = USR.OrgEinheitName,
                      ID$ = USR.UserID, TypeCode$ = 1, DisplayText$ = USR.DisplayText
                    FROM vwUser   USR
                    WHERE DisplayText LIKE '%' + {0} + '%'

                    UNION ALL
                    SELECT 'Gruppe', NULL, Name, NULL, FaPendenzgruppeID, TypeCode$ = 2, Name
                    FROM FaPendenzgruppe
                    WHERE Name LIKE '%' + {0} + '%'
                      AND Name NOT LIKE 'migrierte_Grp_%'

                    ORDER BY TypeCode$ DESC, Name
                    ", searchString, e.ButtonClicked);

                if (e.Cancel) return;
            }

            // apply values
            _uebergebenTargetTypeCode = DBUtil.IsEmpty(dlg["TypeCode$"]) ? -1 : Convert.ToInt32(dlg["TypeCode$"]);
            edtUebergebenTarget.EditValue = dlg["DisplayText$"];
            edtUebergebenTarget.LookupID = dlg["ID$"];
        }

        private string GetXTaskSelectStatement()
        {
            var IDs = String.Join(", ", _selectedIDs);
            return String.Format(@"
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
                    WHERE TSK.XTaskID IN({0})", IDs);
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
                var allTaskTypeCodes = String.Join(", ", qryXTask.DataTable.Rows.Cast<DataRow>().Select(r => r[DBO.XTask.TaskTypeCode]));
                var allActions = DBUtil.OpenSQL(@"
                    SELECT
                      XTaskTypeActionID,
                      XTaskTypeActionTypeCode,
                      TaskTypeCode,
                      BenachrichtigungAktiv,
                      BezeichnungML = dbo.fnGetMLTextByDefault(BezeichnungTID, {1}, Bezeichnung),
                      BetreffML = dbo.fnGetMLTextByDefault(BetreffTID, {1}, Betreff),
                      TextML = dbo.fnGetMLTextByDefault(TextTID, {1}, Text)
                    FROM dbo.XTaskTypeAction WITH(READUNCOMMITTED)
                    WHERE TaskTypeCode IN (" + allTaskTypeCodes + ");",
                         allTaskTypeCodes,
                        Session.User.LanguageCode);

                if (allActions.Count == 0)
                {
                    btnSetErledigt.Visible = true;
                }
                else
                {
                    btnSetErledigt.Visible = false;
                }

                foreach (DataRow task in qryXTask.DataTable.Rows)
                {
                    var qryActions = DBUtil.OpenSQL(@"
                    SELECT
                      XTaskTypeActionID,
                      XTaskTypeActionTypeCode,
                      TaskTypeCode,
                      BenachrichtigungAktiv,
                      BezeichnungML = dbo.fnGetMLTextByDefault(BezeichnungTID, {1}, Bezeichnung),
                      BetreffML = dbo.fnGetMLTextByDefault(BetreffTID, {1}, Betreff),
                      TextML = dbo.fnGetMLTextByDefault(TextTID, {1}, Text)
                    FROM dbo.XTaskTypeAction WITH(READUNCOMMITTED)
                    WHERE TaskTypeCode = {0};",
                        task[DBO.XTask.TaskTypeCode],
                        Session.User.LanguageCode);

                    // Aktionen löschen, die nicht für alle tasks gelten
                    var taskActions = qryActions.DataTable.Rows.Cast<DataRow>().Select(r => r[DBO.XTaskTypeAction.XTaskTypeActionTypeCode].ToString());
                    for (var i = 0; i < allActions.Count; i++)
                    {
                        var thisCode = allActions.DataTable.Rows[i][DBO.XTaskTypeAction.XTaskTypeActionTypeCode].ToString();
                        if (!taskActions.Contains(thisCode))
                        {
                            allActions.DataTable.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }

                foreach (DataRow row in allActions.DataTable.Rows)
                {
                    var tasks = new List<TaskAction>();
                    foreach (DataRow task in qryXTask.DataTable.Rows)
                    {
                        tasks.Add(new TaskAction
                            {
                                AktionBestaetigen = false,
                                BaPersonId = task[DBO.XTask.BaPersonID] as int?,
                                BenachrichtigungAktiv = Utils.ConvertToBool(row[DBO.XTaskTypeAction.BenachrichtigungAktiv]),
                                Betreff = row["BetreffML"] as string,
                                Bezeichnung = row["BezeichnungML"] as string,
                                CreateDate = Utils.ConvertToDateTime(task[DBO.XTask.CreateDate]),
                                FaLeistungId = task[DBO.XTask.FaLeistungID] as int?,
                                ModulId = task[DBO.FaLeistung.ModulID] as int?,
                                SenderUserID = qryXTask[DBO.XTask.SenderID] as int?,
                                TaskType = (LOVsGenerated.TaskType)Utils.ConvertToInt(task[DBO.XTask.TaskTypeCode]),
                                Text = row["TextML"] as string,
                                XTaskId = Utils.ConvertToInt(task[DBO.XTask.XTaskID]),
                                XTaskTypeActionId = Utils.ConvertToInt(row[DBO.XTaskTypeAction.XTaskTypeActionID]),
                                XTaskTypeActionType = (LOVsGenerated.XTaskTypeActionType)Utils.ConvertToInt(row[DBO.XTaskTypeAction.XTaskTypeActionTypeCode]),
                                SenderEmail = task["SenderEMail"] as string,
                                ReceiverEmail = task["ReceiverEMail"] as string,
                                PersonFT = task["PersonFT"] as string,
                                PersonBP = task["PersonBP"] as string,
                                Modul = task["LeistungModul"] as string
                            });
                    }
                    if (tasks.Count > 0)
                    {
                        var button = CreateActionButton(tasks.First().Bezeichnung, tasks);
                        panAktionen.Controls.Add(button);
                    }
                }
            }
        }

        /// <summary>
        /// Validates the selected Ids.
        /// </summary>
        /// <returns></returns>
        private void ValidateSelectedIDs()
        {
            // check if we have any ids
            if (_selectedIDs == null || _selectedIDs.Count < 1)
            {
                throw new ArgumentException("No selected ids received, cannot continue", "SelectedIDs");
            }
        }
    }
}