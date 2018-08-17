using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Kiss.Infrastructure;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.BDE
{
    /// <summary>
    /// Control, used for check and visa all users within one orgunit for month/year
    /// </summary>
    public partial class CtlBDEVisumKostenstelle : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_AUSWAHL = "Auswahl";
        private const string COL_FREIGEGEBEN = "Freigegeben";
        private const string COL_USERID = "UserID";
        private const string COL_VERBUCHT = "Verbucht";
        private const string COL_VERBUCHTLD = "VerbuchtLD";
        private const string COL_VISIERT = "Visiert";
        private readonly IList<int> _counter;
        private readonly string _statustext = KissMsg.GetMLMessage("CtlBDEVisumKostenstelle", "StatusText", "Status");

        #endregion

        #region Private Fields

        private bool _specialRightKostenstelleHauptSitz;
        private bool _specialRightKostenstelleKGS;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlBDEVisumKostenstelle"/> class.
        /// </summary>
        public CtlBDEVisumKostenstelle()
        {
            // init control
            InitializeComponent();

            // setup rights
            SetupRights();

            // init vars
            _counter = new List<int>();

            // set status
            SetStatusLabel("LoadingFormWait", "Bitte warten, die Maske wird vorbereitet...");

            // setup columns
            SetupColumns();
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Event handler for the show selection button.
        /// Executes the fill command for the SQLQuery sqlAuswahl.
        /// Verifies that all necessary values are given.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnAnzeigen_Click(object sender, EventArgs e)
        {
            try
            {
                // setup grid style
                UpdateGridStyle();

                // validate (KST is only important if not special right)
                if ((!_specialRightKostenstelleHauptSitz && !_specialRightKostenstelleKGS && DBUtil.IsEmpty(edtKostenstelle.EditValue)) ||
                    DBUtil.IsEmpty(edtMonatJahr.EditValue))
                {
                    // show message
                    KissMsg.ShowInfo(Name, "InfoNoAuswahlKriteriaSelected_v01", "Bitte wählen Sie eine Kostenstelle und einen Monat für die Anzeige der Daten.");

                    // set focus
                    edtKostenstelle.Focus();

                    // cancel
                    return;
                }

                // clear counter
                _counter.Clear();

                // set status
                SetStatusLabel("LoadingData", "Die gewünschten Daten werden geladen...");

                // fill data
                qryAuswahl.Fill(@"
                    SELECT FCN.*
                    FROM dbo.fnBDEGetVisumKostenstelleView({0}, {1}, {2}, {3}, {4}, {5}) FCN
                    ORDER BY FCN.Kostenstelle, FCN.Mitarbeiter, FCN.UserID;",
                    edtKostenstelle.EditValue,
                    edtMonatJahr.EditValue,
                    Session.User.UserID,
                    Session.User.LanguageCode,
                    _specialRightKostenstelleHauptSitz,
                    _specialRightKostenstelleKGS);

                // check if any data found
                if (qryAuswahl.Count < 1)
                {
                    // no data found, show info
                    KissMsg.ShowInfo(Name, "NoDataFoundForGivenValues", "Es wurden keine Daten gefunden, bitte überprüfen Sie Ihre Auswahl.\r\n\r\nMöglicherweise sind Sie auch nicht berechtigt, die gewünschten Daten zu bearbeiten.");

                    // set focus
                    edtKostenstelle.Focus();
                }
            }
            finally
            {
                // reset gui
                ResetCounterTextAndButtons();

                // reset status
                SetStatusLabel(null, null);
            }
        }

        /// <summary>
        /// Event handler for the set "Freigabe" button.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnFreigabe_Click(object sender, EventArgs e)
        {
            if (!btnFreigabe.Enabled)
            {
                return;
            }

            SetResetFreigabe(true);
        }

        /// <summary>
        /// Event handler for the remove "Freigabe" button.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnFreigabeAufheben_Click(object sender, EventArgs e)
        {
            if (!btnFreigabeAufheben.Enabled)
            {
                return;
            }

            SetResetFreigabe(false);
        }

        /// <summary>
        /// Event handler for the invert selection button.
        /// Sets the check boxes, the counter and calls the method to reset text and buttons.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnInvertSelection_Click(object sender, EventArgs e)
        {
            int i = 0;

            _counter.Clear();

            foreach (DataRow row in qryAuswahl.DataTable.Rows)
            {
                bool select = Convert.ToBoolean(row[COL_AUSWAHL]);
                row[COL_AUSWAHL] = !select;

                if (!select)
                {
                    _counter.Add(i);
                }

                i++;
            }

            ResetCounterTextAndButtons();
        }

        /// <summary>
        /// Jump to corresponding entry in ZLE-Zeiterfassung
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnLeistungserfassung_Click(object sender, EventArgs e)
        {
            // validate
            if (qryAuswahl.Row == null)
            {
                return;
            }

            // jump to form and tab with given user
            FormController.OpenForm("FrmBDEZeiterfassung", "Action", "SelectUser",
                                    "UserID", Convert.ToInt32(qryAuswahl.Row[COL_USERID]),
                                    "TabName", "Monat");
        }

        /// <summary>
        /// Event handler for the select all button.
        /// Checks all boxes, sets the counter, text and button status accordingly.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            int i = 0;
            _counter.Clear();

            foreach (DataRow row in qryAuswahl.DataTable.Rows)
            {
                _counter.Add(i);
                i++;

                row[COL_AUSWAHL] = true;
            }

            ResetCounterTextAndButtons();
        }

        /// <summary>
        /// Event handler for the clear selection button.
        /// Unchecks all check boxes, sets the counter, text and button status accordingly.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            _counter.Clear();

            foreach (DataRow row in qryAuswahl.DataTable.Rows)
            {
                row[COL_AUSWAHL] = false;
            }

            ResetCounterTextAndButtons();
        }

        /// <summary>
        /// Event handler for the set visum button.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnVisieren_Click(object sender, EventArgs e)
        {
            if (!btnVisieren.Enabled)
            {
                return;
            }

            SetResetVisum(true);
        }

        /// <summary>
        /// Event handler for the remove visum button.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnVisumAufheben_Click(object sender, EventArgs e)
        {
            if (!btnVisumAufheben.Enabled)
            {
                return;
            }
            SetResetVisum(false);
        }

        /// <summary>
        /// Event handler for the Value changed of the Auswahl CheckBox.
        /// Updates the DataList rows (qryAuswahl) with the value from the CheckBox.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void ColumnEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (sender is CheckEdit)
            {
                qryAuswahl.Row[COL_AUSWAHL] = ((CheckEdit)sender).EditValue;

                if (Convert.ToBoolean(((CheckEdit)sender).EditValue))
                {
                    _counter.Add(qryAuswahl.Position);
                }
                else
                {
                    _counter.Remove(qryAuswahl.Position);
                }
            }

            ResetCounterTextAndButtons();
        }

        private void CtlBDEVisumKostenstelle_Load(object sender, EventArgs e)
        {
            // RIGHTS:
            // get if user has special right to select all Kostenstelle
            _specialRightKostenstelleHauptSitz = DBUtil.UserHasRight("BDEVisumKostenstelleHS");
            _specialRightKostenstelleKGS = DBUtil.UserHasRight("BDEVisumKostenstelleKGS");

            // init dropdown
            if (_specialRightKostenstelleHauptSitz)
            {
                // show all entries
                BDEUtils.InitKostenstelleDropDown(Session.User.UserID, _specialRightKostenstelleHauptSitz, _specialRightKostenstelleKGS, edtKostenstelle);
            }
            else
            {
                // set flag
                bool hasSpecialRight = _specialRightKostenstelleHauptSitz || _specialRightKostenstelleKGS || Session.User.IsUserAdmin;

                // show only assigend entries of user (KGS-specialright does only matter for empty entry, the rest is handled in function)
                SqlQuery qryKostenstelle = DBUtil.OpenSQL(@"
                    SELECT [Code] = FCN.[Code],
                           [Text] = CASE
                                      WHEN ISNULL(FCN.[Code], -1) > 0 THEN dbo.fnCombineKSTOrgUnitItemName(ORG.[Kostenstelle], ORG.[ItemName])
                                      ELSE ''
                                    END
                    FROM dbo.fnBDEGetOEOrgUnitList ({0}, {1}, 1) FCN
                      LEFT JOIN dbo.XOrgUnit                     ORG WITH (READUNCOMMITTED) ON ORG.[OrgUnitID] = FCN.[Code]",
                    Session.User.UserID, hasSpecialRight);

                // apply data and show max 14 entries at once in dropdown
                edtKostenstelle.LoadQuery(qryKostenstelle);
                edtKostenstelle.Properties.DropDownRows = Math.Min(qryKostenstelle.Count, 14);
            }

            // setup default values
            edtKostenstelle.EditValue = BaUtils.GetOrgUnitOfUser(Session.User.UserID);
            edtMonatJahr.EditValue = GetLastDayOfLastMonth();

            // setup FillTimeOut for query
            if (_specialRightKostenstelleHauptSitz)
            {
                // hauptsitz, more data expected
                qryAuswahl.FillTimeOut = 300; // 5min
            }
            else if (_specialRightKostenstelleKGS)
            {
                // hauptsitz, more data expected
                qryAuswahl.FillTimeOut = 120; // 2min
            }

            // init vars
            _counter.Clear();

            // init counter and control
            ResetCounterTextAndButtons();

            // reset status
            SetStatusLabel(null, null);
        }

        private void grvVisumKostenstelle_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                // display value-fields in red if value is negative
                if (e.Column.FieldName == colGZIstArbeitszeit.FieldName ||
                    e.Column.FieldName == colGZSollArbeitszeit.FieldName ||
                    e.Column.FieldName == colGZMonatssaldo.FieldName ||
                    e.Column.FieldName == colGZUebertragVorjahr.FieldName ||
                    e.Column.FieldName == colGZKorrekturen.FieldName ||
                    e.Column.FieldName == colGZBezUeberstunden.FieldName ||
                    e.Column.FieldName == colGZSaldo.FieldName ||
                    e.Column.FieldName == colFerienUebertragVorjahr.FieldName ||
                    e.Column.FieldName == colFerienAnspruchProJahr.FieldName ||
                    e.Column.FieldName == colFerienBisherBezogen.FieldName ||
                    e.Column.FieldName == colFerienZugabenKuerzungen.FieldName ||
                    e.Column.FieldName == colFerienKorrekturen.FieldName ||
                    e.Column.FieldName == colFerienSaldo.FieldName)
                {
                    // get current value
                    var val = grvVisumKostenstelle.GetRowCellDisplayText(e.RowHandle, e.Column);

                    // check value
                    if (!DBUtil.IsEmpty(val))
                    {
                        if (Convert.ToDouble(val) < 0)
                        {
                            // negative values are red
                            e.Appearance.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in grvVisumKostenstelle_CustomDrawCell(...) occured: {0}", ex.Message);
            }
        }

        #endregion

        #region Methods

        #region Private Static Methods

        /// <summary>
        /// Creates a WHERE condition for a given list of UserID's so that one of the UserID's has to
        /// be a match for the condition to be true.
        /// </summary>
        /// <param name="userIdList">The list of all users to use for where condition</param>
        /// <returns>The additional where condition to append for filtering</returns>
        private static string CreateUserIdWhereCondition(IEnumerable<int> userIdList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("AND (1 = 2");

            foreach (int userId in userIdList)
            {
                sb.Append(" OR UserID = ");
                sb.Append(userId);
            }

            sb.Append(")");

            return sb.ToString();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Enables or disables the Freigabe and Visum Buttons according to the selection.
        /// Enables the corresponding button if one valid row is selected.
        /// Disables the corresponding button if no valid row is selected.
        /// </summary>
        private void EnableDisableFreigabeVisumButtons()
        {
            // disable all buttons by default
            btnFreigabe.Enabled = false;
            btnFreigabeAufheben.Enabled = false;
            btnVisieren.Enabled = false;
            btnVisumAufheben.Enabled = false;

            // validate (need some data and user must have update-rights on query)
            if (_counter.Count < 1 || !UserHasUpdateRights())
            {
                return;
            }

            // init counter
            int counter = _counter.Count;

            // loop entries
            foreach (DataRow row in qryAuswahl.DataTable.Rows)
            {
                if (Convert.ToBoolean(row[COL_AUSWAHL]) &&
                    DBUtil.IsEmpty(row[COL_VERBUCHT]) &&
                    DBUtil.IsEmpty(row[COL_VERBUCHTLD]))
                {
                    counter = counter - 1;

                    if (!Convert.ToBoolean(row[COL_FREIGEGEBEN]) && !Convert.ToBoolean(row[COL_VISIERT]))
                    {
                        btnFreigabe.Enabled = true;
                    }
                    else if (Convert.ToBoolean(row[COL_FREIGEGEBEN]) && !Convert.ToBoolean(row[COL_VISIERT]))
                    {
                        btnFreigabeAufheben.Enabled = true;
                        btnVisieren.Enabled = true;
                    }
                    else if (Convert.ToBoolean(row[COL_FREIGEGEBEN]) && Convert.ToBoolean(row[COL_VISIERT]))
                    {
                        btnVisumAufheben.Enabled = true;
                    }
                }

                if (btnFreigabe.Enabled && btnFreigabeAufheben.Enabled && btnVisieren.Enabled && btnVisumAufheben.Enabled)
                {
                    break;
                }

                if (counter < 1)
                {
                    break;
                }
            } // [foreach]
        }

        /// <summary>
        /// Get last day of last month
        /// </summary>
        /// <returns>The date of the last day of last month</returns>
        private DateTime GetLastDayOfLastMonth()
        {
            // get first day of current month and subtract one day
            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
        }

        /// <summary>
        /// Resets the text about the number of selected rows.
        /// Calls the Method to enable/disable the Freigabe/Visum buttons.
        /// </summary>
        private void ResetCounterTextAndButtons()
        {
            // setup label
            lblGewaehlteZeilen.Text = KissMsg.GetMLMessage(Name, "LabelCounter_v01", "{0} von {1} Einträgen ausgewählt", _counter.Count, qryAuswahl.Count);

            // setup buttons
            EnableDisableFreigabeVisumButtons();
        }

        /// <summary>
        /// Resets the Row selection after the List has been refreshed.
        /// </summary>
        private void ResetSelectedItems()
        {
            foreach (int position in _counter)
            {
                qryAuswahl.DataTable.Rows[position][COL_AUSWAHL] = true;
            }

            ResetCounterTextAndButtons();
        }

        /// <summary>
        /// Sets or removes the "Freigabe" of a selected row.
        /// Of all selected row positions which are stored in the counter it verifies which rows can be modified
        /// and executes the according update command.
        /// </summary>
        /// <param name="setFreigabeValue">True to set the "Freigabe". False to remove the "Freigabe"</param>
        private void SetResetFreigabe(bool setFreigabeValue)
        {
            // validate (need some data and user must have update-rights on query)
            if (_counter.Count < 1 || !UserHasUpdateRights())
            {
                return;
            }

            try
            {
                // init values
                bool continueAction;

                // check mode
                if (setFreigabeValue)
                {
                    // confirm set freigabe
                    continueAction = KissMsg.ShowQuestion(Name, "BestaetigungFreigeben", "Wollen Sie Ihre Auswahl nun zum Visieren freigeben?", 0, 0, true);
                }
                else
                {
                    // confirm remove freigabe
                    continueAction = KissMsg.ShowQuestion(Name, "BestaetigungFreigabeAufheben", "Wollen Sie für Ihre Auswahl die Freigabe aufheben?", 0, 0, true);
                }

                // confirm execution
                if (continueAction)
                {
                    // check mode
                    if (setFreigabeValue)
                    {
                        // set status
                        SetStatusLabel("DoSetFreigabe", "Die Freigabe wird nun für die ausgewählten Mitarbeiter/innen gesetzt...");
                    }
                    else
                    {
                        // set status
                        SetStatusLabel("DoResetFreigabe", "Die Freigabe wird nun für die ausgewählten Mitarbeiter/innen aufgehoben...");
                    }

                    // set cursor
                    Cursor.Current = Cursors.WaitCursor;

                    // create list of all selected entries
                    IList<int> selectedUserIds = new List<int>();

                    // the list of the selected users is created. for security reasons we don't depend on the counter.
                    foreach (DataRow row in qryAuswahl.DataTable.Rows)
                    {
                        if (Convert.ToBoolean(row[COL_AUSWAHL]) &&
                            !Convert.ToBoolean(row[COL_VISIERT]) &&
                            DBUtil.IsEmpty(row[COL_VERBUCHT]) &&
                            DBUtil.IsEmpty(row[COL_VERBUCHTLD]))
                        {
                            // add a user only once to the list.
                            if (!selectedUserIds.Contains(Convert.ToInt32(row[COL_USERID])))
                            {
                                if (!Convert.ToBoolean(row[COL_FREIGEGEBEN]) && setFreigabeValue)
                                {
                                    selectedUserIds.Add(Convert.ToInt32(row[COL_USERID]));
                                }
                                else if (Convert.ToBoolean(row[COL_FREIGEGEBEN]) && !setFreigabeValue)
                                {
                                    selectedUserIds.Add(Convert.ToInt32(row[COL_USERID]));
                                }
                            }
                        }
                    }

                    // create query
                    string whereCond = CreateUserIdWhereCondition(selectedUserIds);
                    string query = @"
                        UPDATE dbo.BDELeistung
                        SET Freigegeben = {1}
                        WHERE YEAR(Datum) = YEAR({0})
                          AND MONTH(Datum) = MONTH({0})
                          " + whereCond;

                    // create new history entry and update values
                    DBUtil.NewHistoryVersion();
                    DBUtil.ExecSQLThrowingException(query, edtMonatJahr.EditValue, setFreigabeValue);

                    // refresh query and do reselection
                    qryAuswahl.Refresh();
                    ResetSelectedItems();
                }
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError(Name, "FehlerBeimFreigeben_v01", "Es ist ein Fehler beim Freigeben der Einträge der gewählten Mitarbeiter aufgetreten.", ex);
            }
            finally
            {
                // reset status
                SetStatusLabel(null, null);

                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Sets or removes the Visum of a selected row.
        /// Of all selected row positions which are stored in the counter it verifies which rows can be modified
        /// and executes the according update command.
        /// </summary>
        /// <param name="setVisumValue">True to set the Visum. False to remove the Visum.</param>
        private void SetResetVisum(bool setVisumValue)
        {
            // validate (need some data and user must have update-rights on query)
            if (_counter.Count < 1 || !UserHasUpdateRights())
            {
                return;
            }

            try
            {
                // init values
                bool continueAction;

                // check mode
                if (setVisumValue)
                {
                    // confirm set visum
                    continueAction = KissMsg.ShowQuestion(Name, "BestaetigungVisieren", "Wollen Sie Ihre Auswahl nun visieren?", 0, 0, true);
                }
                else
                {
                    // confirm remove visum
                    continueAction = KissMsg.ShowQuestion(Name, "BestaetigungVisumAufheben", "Wollen Sie für Ihre Auswahl das Visum aufheben?", 0, 0, true);
                }

                // confirm execution
                if (continueAction)
                {
                    // check mode
                    if (setVisumValue)
                    {
                        // set status
                        SetStatusLabel("DoSetVisum", "Das Visum wird nun für die ausgewählten Mitarbeiter/innen gesetzt...");
                    }
                    else
                    {
                        // set status
                        SetStatusLabel("DoResetVisum", "Das Visum wird nun für die ausgewählten Mitarbeiter/innen aufgehoben...");
                    }

                    // set cursor
                    Cursor.Current = Cursors.WaitCursor;

                    // create list of all selected entries
                    IList<int> selectedUserIds = new List<int>();

                    // the list of the selected users is created. for security reasons we don't depend on the counter.
                    foreach (DataRow row in qryAuswahl.DataTable.Rows)
                    {
                        if (Convert.ToBoolean(row[COL_AUSWAHL]) &&
                            Convert.ToBoolean(row[COL_FREIGEGEBEN]) &&
                            DBUtil.IsEmpty(row[COL_VERBUCHT]) &&
                            DBUtil.IsEmpty(row[COL_VERBUCHTLD]))
                        {
                            // add a user only once to the list.
                            if (!selectedUserIds.Contains(Convert.ToInt32(row[COL_USERID])))
                            {
                                if (setVisumValue && !Convert.ToBoolean(row[COL_VISIERT]))
                                {
                                    selectedUserIds.Add(Convert.ToInt32(row[COL_USERID]));
                                }
                                else if (!setVisumValue && Convert.ToBoolean(row[COL_VISIERT]))
                                {
                                    selectedUserIds.Add(Convert.ToInt32(row[COL_USERID]));
                                }
                            }
                        }
                    }

                    // create query
                    string whereCond = CreateUserIdWhereCondition(selectedUserIds);
                    string query = @"
                        UPDATE dbo.BDELeistung
                        SET Visiert = {1}
                        WHERE YEAR(Datum) = YEAR({0})
                          AND MONTH(Datum) = MONTH({0})
                              " + whereCond;

                    // create new history entry and update values
                    DBUtil.NewHistoryVersion();
                    DBUtil.ExecSQLThrowingException(query, edtMonatJahr.EditValue, setVisumValue);

                    // refresh query
                    qryAuswahl.Refresh();

                    // set the selection to the old values
                    ResetSelectedItems();
                }
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError(Name, "FehlerBeimVisieren_v01", "Es ist ein Fehler beim Visieren der Einträge der gewählten Mitarbeiter aufgetreten.", ex);
            }
            finally
            {
                // reset status
                SetStatusLabel(null, null);

                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Apply new status text to status label
        /// </summary>
        /// <param name="messageName">The message name to use for multilanguage message (MessageName)</param>
        /// <param name="defaultMessageText">The default message if none defined yet by translation (DefaultMessage)</param>
        /// <param name="parameters">Additional parameters to fill within default message</param>
        private void SetStatusLabel(string messageName, string defaultMessageText, params object[] parameters)
        {
            // check if we have a valid name and text (only if not already translated)
            if (DBUtil.IsEmpty(messageName) || DBUtil.IsEmpty(defaultMessageText))
            {
                // no valid name or text, use default
                defaultMessageText = "-";
            }
            else
            {
                // not translated yet, get text from database
                defaultMessageText = KissMsg.GetMLMessage(Name, messageName, defaultMessageText, KissMsgCode.Text, parameters);
            }

            // setup text
            lblStatusBar.Text = string.Format(" {0}: {1}", _statustext, defaultMessageText);

            // do it
            ApplicationFacade.DoEvents();
        }

        private void SetupColumns()
        {
            // loop columns and lock all exception selection column
            foreach (GridColumn col in grvVisumKostenstelle.Columns)
            {
                // check if selection column
                if (col == colAuswahl)
                {
                    // setup column as editable
                    col.OptionsColumn.AllowEdit = true;
                    col.AppearanceCell.BackColor = GuiConfig.GridEditable;

                    // go on with next column
                    continue;
                }

                // setup column as locked
                col.OptionsColumn.AllowEdit = false;
                col.AppearanceCell.BackColor = GuiConfig.GridReadOnly;
            }
        }

        private void SetupRights()
        {
            // VARS
            var isAdmin = Session.User.IsUserAdmin;
            bool canReadData;
            bool canInsert;
            bool canUpdate;
            bool canDelete;

            // set values
            Session.GetUserRight(Name, out canReadData, out canInsert, out canUpdate, out canDelete);

            if (!canReadData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // data-query
            qryAuswahl.CanInsert = false;
            qryAuswahl.CanUpdate = isAdmin || canUpdate;
            qryAuswahl.CanDelete = false;

            // FIELDS
            qryAuswahl.EnableBoundFields();
        }

        private void UpdateGridStyle()
        {
            // apply colors, they are fix defined in contructor of view and we need readonly behaviour in editable grid
            grvVisumKostenstelle.Appearance.FocusedCell.BackColor = GuiConfig.GridFocusedSelectionBackColor;
            grvVisumKostenstelle.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            grvVisumKostenstelle.Appearance.FocusedRow.BackColor = GuiConfig.GridFocusedSelectionBackColor;
            grvVisumKostenstelle.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            grvVisumKostenstelle.Appearance.HideSelectionRow.BackColor = GuiConfig.GridUnfocusedSelectionBackColor;
            grvVisumKostenstelle.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            grvVisumKostenstelle.Appearance.HideSelectionRow.Options.UseBackColor = true;
            grvVisumKostenstelle.Appearance.HideSelectionRow.Options.UseForeColor = true;
        }

        /// <summary>
        /// Get value if user has rights to do updates on given data
        /// </summary>
        /// <returns><c>True</c> if user has rights to do updates, otherwise <c>False</c></returns>
        private bool UserHasUpdateRights()
        {
            return qryAuswahl.CanUpdate;
        }

        #endregion

        #endregion
    }
}