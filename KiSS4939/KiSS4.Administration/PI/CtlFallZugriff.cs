using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration.PI
{
    public partial class CtlFallZugriff : KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        /// <summary>
        /// Do not update details (e.g. if selecting all rows)
        /// </summary>
        private Boolean _preventUpdateDetails;

        #endregion

        #endregion

        #region Constructors

        public CtlFallZugriff()
        {
            InitializeComponent();

            // reset empty text
            repItemIcon.NullText = " "; // do not display "No Image"
        }

        #endregion

        #region EventHandlers

        private void btnAdd_Click(Object sender, EventArgs e)
        {
            // validate first
            if (!btnAdd.Enabled || qryFaLeistung.Count < 1 || qryVerfuegbar.Count < 1 || !qryZugeteilt.Post())
            {
                return;
            }

            // get all rows the user selected
            int[] rowHandles = grdVerfuegbar.View.GetSelectedRows();

            if (rowHandles == null || rowHandles.Length < 1)
            {
                return;
            }

            // get selected ids
            string selectedIDs;
            Hashtable htSelectedIDs = GetSelectedIDs(out selectedIDs);

            // add all rows the user selected to all selected items
            foreach (Int32 rowHandle in rowHandles)
            {
                int userID = Convert.ToInt32(grdVerfuegbar.View.GetRowCellValue(rowHandle, grdVerfuegbar.View.Columns["UserID"]));

                // loop selected users and loop selected items
                foreach (object faLeistungID in htSelectedIDs.Keys)
                {
                    DBUtil.ExecSQL(string.Format(@"
                        INSERT INTO dbo.FaLeistungZugriff (FaLeistungID, UserID, DarfMutieren)
                          SELECT {0}, {1}, 0
                          WHERE {0} NOT IN (SELECT FaLeistungID
                                            FROM dbo.FaLeistungZugriff WITH (READUNCOMMITTED)
                                            WHERE FaLeistungID = {0} AND
                                                  UserID = {1});", Convert.ToInt32(faLeistungID), userID));
                }
            }

            // refresh changed data
            RefreshDisplay(htSelectedIDs);

            // refresh list
            DisplayAccessUsers();

            // clear filter and set focus
            edtFilter.EditValue = null;
            edtFilter.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!btnRemove.Enabled || qryFaLeistung.Count < 1 || qryZugeteilt.Count < 1)
            {
                return;
            }

            // get selected ids
            string selectedIDs;
            Hashtable htSelectedIDs = GetSelectedIDs(out selectedIDs);

            // remove user for selected items
            DBUtil.ExecSQL(string.Format(@"
                DELETE
                FROM dbo.FaLeistungZugriff
                WHERE FaLeistungID IN ({0}) AND
                        UserID = {1};", selectedIDs, qryZugeteilt["UserID"]));

            // refresh changed data
            RefreshDisplay(htSelectedIDs);

            // refresh list
            DisplayAccessUsers();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (!btnRemoveAll.Enabled || qryFaLeistung.Count < 1 || qryZugeteilt.Count < 1)
            {
                return;
            }

            // get all users that are displayed
            string userIDs = "";

            foreach (DataRow row in qryZugeteilt.DataTable.Rows)
            {
                // add to string
                if (!userIDs.Equals(""))
                {
                    userIDs += ",";
                }

                userIDs += Convert.ToString(row["UserID"]);
            }

            // get selected ids
            string selectedIDs;
            Hashtable htSelectedIDs = GetSelectedIDs(out selectedIDs);

            // remove user for selected items
            DBUtil.ExecSQL(String.Format(@"
                DELETE
                FROM dbo.FaLeistungZugriff
                WHERE FaLeistungID IN ({0}) AND
                        UserID IN ({1});", selectedIDs, userIDs));

            // refresh changed data
            RefreshDisplay(htSelectedIDs);

            // refresh list
            DisplayAccessUsers();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            // store last cursor
            Cursor lastCursor = Cursor.Current;

            try
            {
                // check if any row is available
                if (qryFaLeistung.Count < 1)
                {
                    // no row, do not continue
                    return;
                }

                // prevent update details
                _preventUpdateDetails = true;

                // save pending changes
                qryZugeteilt.Post();

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // remove selection of all items to prevent hidden selection on grouping
                btnSelectNone_Click(this, EventArgs.Empty);

                // define vars
                int previousRowHandle = -999999;
                int counter = 0;

                // check if any row is selected
                if (grvFaLeistung.GetSelectedRows().Length < 1)
                {
                    // no row selected, select first row if none is selected
                    grvFaLeistung.MoveFirst();
                }

                // get handle of user's selection
                int selectedRowHandle = grvFaLeistung.GetSelectedRows()[0];

                // select first row to loop from top to bottom
                grvFaLeistung.MoveFirst();

                // apply rowhandle
                int rowHandle = grvFaLeistung.GetSelectedRows()[0];

                // loop through rows and update flags for visible items
                while (previousRowHandle != rowHandle)
                {
                    // check if row is visible (0=group visible, 1=datarow visible, <0 = not visible)
                    if (rowHandle >= 0 && grvFaLeistung.IsRowVisible(rowHandle) == DevExpress.XtraGrid.Views.Grid.RowVisibleState.Visible)
                    {
                        // select this row
                        grvFaLeistung.SetRowCellValue(rowHandle, colAuswahl, true);
                    }

                    // move next value
                    grvFaLeistung.MoveNext();

                    // update gui to prevent hanging
                    if (counter % 500 == 0)
                    {
                        ApplicationFacade.DoEvents();
                        counter = 0;
                    }

                    counter++;

                    // apply rowhandle
                    previousRowHandle = rowHandle;
                    rowHandle = grvFaLeistung.GetSelectedRows()[0];
                }

                // reselect last selected row (View.SelectRow() does not work...)
                Boolean foundSelectedRow = false;
                grvFaLeistung.MoveFirst();

                while (!foundSelectedRow)
                {
                    // get handle of selected row
                    rowHandle = grvFaLeistung.GetSelectedRows()[0];

                    // check if row was the row the user selected before clicking the button
                    foundSelectedRow = rowHandle == selectedRowHandle;

                    // check if found or move to next row
                    if (!foundSelectedRow)
                    {
                        grvFaLeistung.MoveNext();
                    }

                    // update gui to prevent hanging
                    if (counter % 100 == 0)
                    {
                        ApplicationFacade.DoEvents();
                        counter = 0;
                    }

                    counter++;
                }
            }
            catch (Exception ex)
            {
                // show general message
                KissMsg.ShowError("CtlFallZugriff", "ErrorSelectingItems", "Es ist ein Fehler beim Auswählen der Leistungen aufgetreten.", ex);
            }
            finally
            {
                // set last cursor
                Cursor.Current = lastCursor;

                // allow update details
                _preventUpdateDetails = false;

                // update counter label
                UpdateCounter();

                // update display user
                DisplayAccessUsers();

                // set focus
                grdFaLeistung.Focus();
            }
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            // store last cursor
            Cursor lastCursor = Cursor.Current;

            // loop through all items and remove selection
            try
            {
                // save pending changes
                qryZugeteilt.Post();

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // remove selection
                foreach (DataRow row in qryFaLeistung.DataTable.Rows)
                {
                    row["Auswahl"] = 0;
                }

                // check if row is selected
                if (grvFaLeistung.GetSelectedRows().Length > 0)
                {
                    // update selected row to have proper display for selection
                    grvFaLeistung.RefreshRow(grvFaLeistung.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                // show general message
                KissMsg.ShowError("CtlFallZugriff", "ErrorUnSelectingItems", "Es ist ein Fehler beim Aufheben der Auswahl der Leistungen aufgetreten.", ex);
            }
            finally
            {
                // set last cursor
                Cursor.Current = lastCursor;

                // update counter label
                UpdateCounter();

                // set focus
                grdFaLeistung.Focus();
            }
        }

        private void btnSetOwner_Click(object sender, EventArgs e)
        {
            if (qryVerfuegbar.Count < 1 || qryFaLeistung.Count < 1)
            {
                return;
            }

            // get selected ids
            string selectedIDs;
            Hashtable htSelectedIDs = GetSelectedIDs(out selectedIDs);

            // check if any item is selected
            if (htSelectedIDs.Count < 1)
            {
                KissMsg.ShowInfo("CtlFallZugriff", "NoItemSelected", "Es muss zuerst eine Leistung ausgewählt werden.");
                return;
            }

            // get names of owner/new owner
            string ownerName = edtOwnerMA.Text;
            string newOwnerName = Convert.ToString(qryVerfuegbar["UserName"]);
            bool multipleOwners = false;

            // check if possibly multiple owners
            if (string.IsNullOrEmpty(ownerName))
            {
                // get all owners
                SqlQuery qryMultipleOwners = DBUtil.OpenSQL(string.Format(@"
                    SELECT DISTINCT
                           UserName = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL)
                    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                    WHERE LEI.FaLeistungID IN ({0})
                    ORDER BY UserName;", selectedIDs));

                // check count
                if (qryMultipleOwners.Count < 1)
                {
                    // no owner found??
                    ownerName = "???";

                    // case should not occure, log event
                    _log.WarnFormat("no username found for owner, selectedIDs='{0}'", selectedIDs);
                }
                else if (qryMultipleOwners.Count == 1)
                {
                    // just one owner
                    ownerName = Convert.ToString(qryMultipleOwners["UserName"]);
                }
                else
                {
                    // reset owner
                    ownerName = "";

                    // expect multiple, combine
                    foreach (DataRow row in qryMultipleOwners.DataTable.Rows)
                    {
                        // check length
                        if (ownerName.Length < 1)
                        {
                            // first one
                            ownerName = Convert.ToString(row["UserName"]);
                        }
                        else if (ownerName.Length > 100)
                        {
                            // no more chars
                            ownerName += "; ...";

                            // do not continue
                            break;
                        }
                        else
                        {
                            // append next
                            ownerName = string.Format("{0}; {1}", ownerName, row["UserName"]);
                        }
                    }

                    // set flag
                    multipleOwners = true;
                }
            }

            // check if multiple owners
            if (multipleOwners)
            {
                // #5236: confirm changing owner (multiple owners)
                if (!KissMsg.ShowQuestion("CtlFallZugriff", "ConfirmChangingOwnerMultiple_v01", "Sind Sie sicher, dass Sie für die ausgewälten '{0}' Prozesse das Besitzerrecht an '{1}' vergeben wollen und somit die Besitzer '{2}' keinen Zugriff mehr haben?", true, htSelectedIDs.Count, newOwnerName, ownerName))
                {
                    // user canceled
                    return;
                }
            }
            else
            {
                // #5236: confirm changing owner (just one owner)
                if (!KissMsg.ShowQuestion("CtlFallZugriff", "ConfirmChangingOwnerOne_v01", "Sind Sie sicher, dass Sie für die ausgewälten '{0}' Prozesse das Besitzerrecht an '{1}' vergeben wollen und somit '{2}' keinen Zugriff mehr hat?", true, htSelectedIDs.Count, newOwnerName, ownerName))
                {
                    // user canceled
                    return;
                }
            }

            // update all items within selection
            DBUtil.ExecSQL(string.Format(@"
                UPDATE dbo.FaLeistung
                SET UserID = {0}, Modifier = '{1}', Modified = GetDate()
                WHERE FaLeistungID IN ({2});", qryVerfuegbar["UserID"], DBUtil.GetDBRowCreatorModifier(), selectedIDs));

            // refresh changed data
            RefreshDisplay(htSelectedIDs);
        }

        private void CtlFallZugriff_Load(object sender, EventArgs e)
        {
            // setup tooltiptexts
            ttpFallZugriff.SetToolTip(btnSelectAll, KissMsg.GetMLMessage("CtlFallZugriff", "ToolTipBtnSelectAll", "Alle sichtbaren Leistungen auswählen (nicht sichtbare Leistungen werden nicht ausgewählt)"));
            ttpFallZugriff.SetToolTip(btnSelectNone, KissMsg.GetMLMessage("CtlFallZugriff", "ToolTipBtnSelectNone", "Auswahl aufheben"));

            // remove delete question to prevent asking
            qryZugeteilt.DeleteQuestion = "";

            // get OrgUnits
            SqlQuery qryOrgUnit = DBUtil.OpenSQL(@"
                DECLARE @UserID INT;
                SET @UserID = {0};

                SELECT Code = NULL,
                        Text = ''
                UNION ALL
                SELECT Code = ORG.OrgUnitID,
                        Text = ORG.ItemName
                FROM dbo.fnGetCantonsOrgUnits(@UserID) ORG
                ORDER BY Text, Code;", Session.User.UserID);

            // setup edtSucheAbteilung
            edtSucheAbteilung.Properties.DropDownRows = Math.Min(qryOrgUnit.Count, 7);
            edtSucheAbteilung.Properties.DataSource = qryOrgUnit;

            // get modules
            SqlQuery qryModul = DBUtil.OpenSQL(@"
                DECLARE @LanguageCode INT;
                SET @LanguageCode = ISNULL({0}, 1);

                SELECT Code = NULL,
                        Text = ''
                UNION ALL
                SELECT Code = LOV.Code,
                        Text = dbo.fnGetLOVMLText('Modul', LOV.Code, @LanguageCode)
                FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                WHERE LOV.LOVName = 'Modul' AND Code IN (3, 4, 5, 6, 7, 8)
                ORDER BY Code, Text;", Session.User.LanguageCode);

            // setup edtSucheProzess
            edtSucheProzess.Properties.DropDownRows = Math.Min(qryModul.Count, 7);
            edtSucheProzess.Properties.DataSource = qryModul;

            // select search tab
            NewSearch();

            // update counter label
            UpdateCounter();

            SetupGrid();
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            qryVerfuegbar.DataTable.DefaultView.RowFilter = String.Format("UserName LIKE '%{0}%'", edtFilter.EditValue);
        }

        private void grdVerfuegbar_DoubleClick(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void grdVerfuegbar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 'A' || e.KeyChar > 'z')
            {
                return;
            }

            for (Int32 i = 0; i < qryVerfuegbar.Count; i++)
            {
                string userName = qryVerfuegbar.DataTable.Rows[i]["UserName"].ToString();

                if (userName.ToUpper().StartsWith(e.KeyChar.ToString().ToUpper()))
                {
                    qryVerfuegbar.Position = i;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void grdZugeteilt_DoubleClick(object sender, EventArgs e)
        {
            btnRemove.PerformClick();
        }

        private void grvFaLeistung_LostFocus(object sender, EventArgs e)
        {
            // update counter label
            UpdateCounter();

            // update display of detail grids
            DisplayAccessUsers();
        }

        private void qryFaLeistung_AfterFill(object sender, EventArgs e)
        {
            // update counter label
            UpdateCounter();

            // update display of detail grids
            DisplayAccessUsers();
        }

        private void qryFaLeistung_BeforePost(object sender, EventArgs e)
        {
            // discard changes always on qryFaLeistung
            qryFaLeistung.RowModified = false;
            qryFaLeistung.Row.AcceptChanges();

            // check if need to do some more actions
            if (_preventUpdateDetails)
            {
                return;
            }

            // save pending changes
            qryZugeteilt.Post();
        }

        private void qryFaLeistung_PositionChanged(object sender, EventArgs e)
        {
            // check if need to do action
            if (_preventUpdateDetails)
            {
                // do nothing
                return;
            }

            // update counter label
            UpdateCounter();

            // udpate display
            DisplayAccessUsers();
        }

        private void qryZugeteilt_BeforePost(object sender, EventArgs e)
        {
            // update for all selected items
            // get selected ids
            string selectedIDs;

            GetSelectedIDs(out selectedIDs);

            // remove user for selected items
            DBUtil.ExecSQL(String.Format(@"
                UPDATE dbo.FaLeistungZugriff
                SET DarfMutieren = {0}
                WHERE FaLeistungID IN ({1})
                  AND UserID = {2};",
                Convert.ToInt32(qryZugeteilt["DarfMutieren"]), selectedIDs, qryZugeteilt["UserID"]));

            // discard changes
            qryZugeteilt.RowModified = false;
            qryZugeteilt.Row.AcceptChanges();
        }

        private void qryZugeteilt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            qryFaLeistung.RowModified = true;
        }

        private void SetupGrid()
        {
            if (GuiConfig.Theme == GuiConfig.KissTheme.KissBlue)
            {
                grdFaLeistung.SetColumnEditable(colAuswahl, true);
                grdFaLeistung.SetColumnEditable(colKlient, false);
                grdFaLeistung.SetColumnEditable(colIcon, false);
                grdFaLeistung.SetColumnEditable(colProzess, false);
                grdFaLeistung.SetColumnEditable(colAbteilung, false);
                grdFaLeistung.SetColumnEditable(colMA, false);
                grdFaLeistung.SetColumnEditable(colMAKuerzel, false);
                grdFaLeistung.SetColumnEditable(colDatumVon, false);
                grdFaLeistung.SetColumnEditable(colDatumBis, false);
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set focus
            edtSucheKlient.Focus();
        }

        protected override void RunSearch()
        {
            // validate search
            if (DBUtil.IsEmpty(edtSucheAbteilung.EditValue) &&
                DBUtil.IsEmpty(edtSucheKlient.EditValue) &&
                DBUtil.IsEmpty(edtSucheProzess.EditValue) &&
                DBUtil.IsEmpty(edtSucheMA.EditValue) &&
                DBUtil.IsEmpty(edtSucheMAKuerzel.EditValue))
            {
                KissMsg.ShowInfo("CtlFallZugriff", "Min1Suchfeld_v01", "Es muss mindestens ein Suchfeld ausgefüllt werden.");

                // set focus
                edtSucheKlient.Focus();

                // do not continue
                throw new KissCancelException("Missing value(s), cannot continue with searching.");
            }

            // replace values where necessary
            edtSucheKlient.Text = edtSucheKlient.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
            edtSucheMA.Text = edtSucheMA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
            edtSucheMAKuerzel.Text = edtSucheMAKuerzel.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");

            // replace search parameters
            Object[] parameters = new Object[] { Session.User.LanguageCode, Session.User.UserID };
            kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void DisplayAccessUsers()
        {
            try
            {
                // check if need to do action
                if (_preventUpdateDetails)
                {
                    // do nothing
                    return;
                }

                // first save pending changes
                if (!qryZugeteilt.Post())
                {
                    return;
                }

                // get selected ids
                string selectedIDs;
                Hashtable htSelectedIDs = GetSelectedIDs(out selectedIDs);
                int firstFaLeistungID = -1;

                // check if we have at least one id
                if (htSelectedIDs.Count < 1)
                {
                    // fill with empty data
                    qryVerfuegbar.Fill(@"
                            SELECT UserID = -1,
                                   UserName = 'none',
                                   Abteilung = 'none'
                            WHERE 1 = 2;");

                    qryZugeteilt.Fill(@"
                            SELECT UserID = -1,
                                   FaLeistungID = -1,
                                   DarfMutieren = CONVERT(BIT, 0),
                                   UserName = 'none'
                            WHERE 1 = 2;");

                    // done with filling
                    return;
                }

                // get only first faleistungid in hashtable (is there an easier way??)
                foreach (Object faLeistungID in htSelectedIDs.Keys)
                {
                    firstFaLeistungID = Convert.ToInt32(faLeistungID);
                    break;
                }

                // candidates of all selected ids (nur diejenigen benutzer, welche in keinen der gewählten leistungen gastrecht haben)
                qryVerfuegbar.Fill(string.Format(@"
                    SELECT UserID = USR.UserID,
                           UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, USR.Firstname) + ' (' + USR.LogonName + ')',
                           Abteilung = ORG.ItemName
                    FROM dbo.XUser USR WITH (READUNCOMMITTED)
                      LEFT  JOIN dbo.FaLeistungZugriff FAZ WITH (READUNCOMMITTED) ON FAZ.UserID = USR.UserID AND
                                                                                     FAZ.FaLeistungID IN ({0})
                      INNER JOIN dbo.XOrgUnit_User     OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND
                                                                                     OUU.OrgUnitMemberCode = 2 -- member only
                      INNER JOIN dbo.XOrgUnit          ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                    WHERE FAZ.FaLeistungID IS NULL
                    ORDER BY UserName;", selectedIDs));

                // selected items of all selected ids (nur diejenigen benutzer, welche in allen gewählten leistungen gastrecht haben)
                qryZugeteilt.Fill(string.Format(@"
                    DECLARE @FirstFaLeistungID INT;
                    DECLARE @CountItems INT;

                    SET @FirstFaLeistungID = {1};
                    SET @CountItems = {2};

                    SELECT FLZ.UserID,
                           FLZ.FaLeistungID,
                           DarfMutieren =  CONVERT(BIT, (SELECT CASE WHEN MAX(CONVERT(INT, ISNULL(SUB.DarfMutieren, 0))) <> MIN(CONVERT(INT, ISNULL(SUB.DarfMutieren, 0))) THEN NULL
                                                                     ELSE MAX(CONVERT(INT, ISNULL(SUB.DarfMutieren, 0)))
                                                                END
                                                         FROM dbo.FaLeistungZugriff SUB WITH (READUNCOMMITTED)
                                                         WHERE SUB.UserID = USR.UserID AND
                                                               SUB.FaLeistungID IN ({0}))),
                           UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, USR.Firstname) + ' (' + USR.LogonName + ')'
                    FROM dbo.XUser USR WITH (READUNCOMMITTED)
                      INNER JOIN dbo.FaLeistungZugriff FLZ WITH (READUNCOMMITTED) ON FLZ.UserID = USR.UserID AND
                                                                                     FLZ.FaLeistungID = @FirstFaLeistungID
                    WHERE USR.UserID IN (SELECT LZ2.UserID
                                         FROM dbo.FaLeistungZugriff LZ2 WITH (READUNCOMMITTED)
                                         WHERE LZ2.FaLeistungID IN ({0}) AND
                                               @CountItems = (SELECT COUNT(1)
                                                              FROM dbo.FaLeistungZugriff LZ3 WITH (READUNCOMMITTED)
                                                              WHERE LZ3.FaLeistungID IN ({0}) AND
                                                                    LZ3.UserID = LZ2.UserID)
                                         GROUP BY LZ2.UserID)
                    ORDER BY UserName;", selectedIDs, firstFaLeistungID, htSelectedIDs.Count));

                // set or remove databinding depending on selected rows (multiple selected or one selected and focusing other row)
                if (htSelectedIDs.Count > 1 || (htSelectedIDs.Count == 1 && !htSelectedIDs.ContainsKey(qryFaLeistung["FaLeistungID"])))
                {
                    // do not display owner name due to confusing data
                    edtOwnerMA.DataMember = "Empty";
                }
                else
                {
                    // display owner name for single selected row
                    edtOwnerMA.DataMember = "MA";
                }

                // refresh binding due to changed datamember
                qryFaLeistung.BindControls();
                qryFaLeistung.RefreshDisplay();
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError("CtlFallZugriff", "ErrorDisplayAccessUsers", "Fehler beim Laden der zugehörigen Daten.", ex);
            }
        }

        private Hashtable GetSelectedIDs(out String selectedIDs)
        {
            // init vars
            selectedIDs = "";
            Hashtable htSelectedIDs = new Hashtable();

            // loop through items and count selected items
            foreach (DataRow row in qryFaLeistung.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Auswahl"]) && Convert.ToBoolean(row["Auswahl"]) && !DBUtil.IsEmpty(row["FaLeistungID"]))
                {
                    // add to string
                    if (!selectedIDs.Equals(""))
                    {
                        selectedIDs += ",";
                    }

                    selectedIDs += Convert.ToString(row["FaLeistungID"]);

                    // add to hashtable (key = faleistungid, value = null)
                    htSelectedIDs.Add(Convert.ToInt32(row["FaLeistungID"]), null);
                }
            }

            // check if we have any item selected in grid
            if (selectedIDs.Equals("") && !DBUtil.IsEmpty(qryFaLeistung["FaLeistungID"]))
            {
                // no id selected, get current focused row id (as it was before multiselection was implemented)
                selectedIDs = Convert.ToString(qryFaLeistung["FaLeistungID"]);

                // add to hashtable (key = faleistungid, value = null)
                htSelectedIDs.Add(Convert.ToInt32(qryFaLeistung["FaLeistungID"]), null);
            }

            // return values
            return htSelectedIDs;
        }

        private void RefreshDisplay(Hashtable htSelectedIDs)
        {
            // discard changes and refresh data
            qryFaLeistung.RowModified = false;
            qryFaLeistung.Row.AcceptChanges();

            qryFaLeistung.Refresh();

            // reselect ids
            ReselectIDs(htSelectedIDs);
        }

        private void ReselectIDs(Hashtable htSelectedIDs)
        {
            // validate first (if we just have one row selected, we do NOT reselect item!)
            if (htSelectedIDs == null || htSelectedIDs.Count < 2)
            {
                // do nothing
                return;
            }

            // loop through items and reselect selected items
            foreach (DataRow row in qryFaLeistung.DataTable.Rows)
            {
                if (htSelectedIDs.ContainsKey(row["FaLeistungID"]))
                {
                    row["Auswahl"] = 1;
                }
            }

            // update label
            UpdateCounter();
        }

        private void UpdateCounter()
        {
            // check if need to do action
            if (_preventUpdateDetails)
            {
                // do nothing
                return;
            }

            // init counter
            int countItems = 0;

            // loop through items and count selected items
            foreach (DataRow row in qryFaLeistung.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Auswahl"]) && Convert.ToBoolean(row["Auswahl"]))
                {
                    countItems++;
                }
            }

            // update label
            lblGewaehlteZeilen.Text = KissMsg.GetMLMessage("CtlFallZugriff", "AmountSelectedItems", "{0} von {1} Leistungen ausgewählt", KissMsgCode.MsgInfo, countItems, qryFaLeistung.Count);
        }

        #endregion

        #endregion
    }
}