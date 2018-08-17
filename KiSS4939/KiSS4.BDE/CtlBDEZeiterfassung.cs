using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.BDE.ExcelImport;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using log4net;
using SharpLibrary.WinControls;

namespace KiSS4.BDE
{
    public partial class CtlBDEZeiterfassung : KissUserControl
    {
        private const string CLASSNAME = "CtlBDEZeiterfassung";

        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The default forecolor of controls and rows
        /// </summary>
        private readonly Color _defaultForeColor = SystemColors.ControlText;

        /// <summary>
        /// The forecolor of the focused row
        /// </summary>
        private readonly Color _focusedRowForeColor;

        private readonly string _labelStd = "Std."; // used to store the appendix "Std." for Übersicht

        /// <summary>
        /// The forecolor of highlited negative values
        /// </summary>
        private readonly Color _negativeColor = Color.Red;

        private readonly bool _specialRightAsIfAdmin; // store if user has specialright like an admin (ADZeiterfassungAdmin)

        #endregion

        #region Private Fields

        private bool _doValidateLeistungsart; // set if editvalue_changed on edtErfassenLeistungsart shall be executed
        private bool _hasKlientChanged; // used to check if Klient has changed by user
        private bool _hasLeistungsartChanged; // used to check if Leistungsart has changed by user
        private bool _hasUserMonatslohn; // used to store if user has monatslohn or stundenlohn as lohntyp
        private bool _insertMode;
        private bool _isAdmin;
        private bool _isChiefOrRepresentative; // store if sesssion user is chief or representative of current users' oe

        // store if sesssion user has admin rights
        private bool _isDoingSearch; // used to check if search is running already

        private bool _isLoading = true; // store if control is finished loading
        private bool _isSwitchingToEmptyTab; // used to store if switching to SelectedTabIndex = -1
        private DataRow _saveRow;
        private string _sqlBody = "";
        private int _userID = -1; // store the active userID whose data has to be displayed
        private bool _userIsLocked = false;
        private int _userMemberOrgUnitID = -1; // store current user's member orgunit
        private double _workTimePerDay = 8.4; // store decimal amount of hours as worktime per day

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlBDEZeiterfassung"/> class.
        /// </summary>
        public CtlBDEZeiterfassung()
        {
            // init control
            InitializeComponent();

            // logging
            _logger.Debug("enter");

            // setup readonly members
            _focusedRowForeColor = grvBDELeistung.Appearance.FocusedRow.ForeColor;

            // set special-right
            _specialRightAsIfAdmin = DBUtil.UserHasRight("ADZeiterfassungAdmin");

            // setup fields
            _userID = Session.User.UserID;
            _userIsLocked = false;

            // setup controls
            lblAngezeigterMAFilter.Visible = HasUserAdminRights();
            edtAngezeigterMAFilter.Visible = HasUserAdminRights();
            btnAngezeigterMAFilter.Visible = HasUserAdminRights();

            var canImport = DBUtil.UserHasRight("ADZeiterfassungStundenimport");
            btnStundenimport.Visible = canImport;

            // setup panel
            panZeitrechner.Top = tabZeiterfassung.Top + 1;
            panZeitrechner.Left = tabZeiterfassung.Left + 1;
            panZeitrechner.Width = tabZeiterfassung.Width - 2;
            panZeitrechner.Height = btnZeitrechner.Top - tabZeiterfassung.Top - 1;
            panZeitrechner.Visible = false;

            // get textlabels
            _labelStd = KissMsg.GetMLMessage(CLASSNAME, "HourShortText", "Std.");

            // logging
            _logger.DebugFormat("specialRightAsIfAdmin='{0}', userID='{1}'", _specialRightAsIfAdmin, _userID);
            _logger.Debug("done");
        }

        #endregion

        #region EventHandlers

        private void btnAngezeigterMAFilter_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("edtAngezeigterMAFilter.EditValue={0}", edtAngezeigterMAFilter.EditValue));

            SqlQuery qryAngezeigterMa;
            Boolean hasFilter = false;

            // filter data
            if (DBUtil.IsEmpty(edtAngezeigterMAFilter.EditValue))
            {
                // default query
                qryAngezeigterMa = DBUtil.OpenSQL(@"
                        SELECT *
                        FROM dbo.fnBDEGetOEUserListExtended({0}, 0, {1})", Session.User.UserID, HasUserAdminRights());
            }
            else
            {
                // default query including filter for users
                qryAngezeigterMa = DBUtil.OpenSQL(@"
                        SELECT *
                        FROM dbo.fnBDEGetOEUserListExtended({0}, 0, {1})
                        WHERE [Text] LIKE {2} + '%'", Session.User.UserID, HasUserAdminRights(), edtAngezeigterMAFilter.EditValue);

                // setup flag
                hasFilter = true;
            }

            // setup edtAngezeigterMitarbeiter
            edtAngezeigterMitarbeiter.Properties.DataSource = null;
            edtAngezeigterMitarbeiter.Properties.DropDownRows = Math.Min(qryAngezeigterMa.Count, 14);
            edtAngezeigterMitarbeiter.Properties.DataSource = qryAngezeigterMa;

            // check if filter defined
            if (!hasFilter)
            {
                // no filter, select current user
                edtAngezeigterMitarbeiter.EditValue = Session.User.UserID;
            }
            else
            {
                // check if any row found
                if (qryAngezeigterMa.Count > 0)
                {
                    // apply first user-id found
                    edtAngezeigterMitarbeiter.EditValue = qryAngezeigterMa["Code"];
                }
                else
                {
                    // apply invalid user-id to prevent wrong data (constraints will prevent saving wrong data)
                    edtAngezeigterMitarbeiter.EditValue = -1;
                }
            }

            // logging
            _logger.Debug("done");
        }

        private void btnErfassungKopie_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor = Cursors.WaitCursor;

            try
            {
                // ensure valid data
                if (!qryData.Post() || qryData.Count < 1)
                {
                    return;
                }

                // show dialog to let the user select the dates he want to create copies to
                var dlg = new DlgMehrfacheintrag();

                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    // do not continue
                    return;
                }

                // get selected dates from dialog
                DateTime[] selectedDates = dlg.GetSelectedDates();

                // validate
                if (selectedDates == null || selectedDates.Length < 1)
                {
                    // do not continue
                    return;
                }

                // create validation queries for LA/LohnArt/KS
                SqlQuery qryLa = DBUtil.OpenSQL(GetAvailableLaSql(null, ""));
                SqlQuery qryKs = GetAvailableKsQuery();

                // loop through array
                for (Int32 i = 0; i < selectedDates.Length; i++)
                {
                    // copy each value into a new row
                    DataRow newRow = qryData.DataTable.NewRow();

                    foreach (DataColumn col in qryData.DataTable.Columns)
                    {
                        if (!col.AutoIncrement)
                        {
                            newRow[col.ColumnName] = qryData.Row[col.ColumnName];
                        }
                    }

                    // VALIDATE DATE
                    // check if user can update data with this Datum
                    if (IsDateAlreadyLocked(selectedDates[i]))
                    {
                        // no more changes on this month are allowed
                        KissMsg.ShowError(CLASSNAME, "MonthCanNotBeUsedAnymore", "Das Datum '{0}' kann nicht mehr verwendet werden. Dieser Monat wurde bereits freigegeben oder visiert.", null, null, 0, 0, selectedDates[i].ToShortDateString());

                        // do not continue
                        qryData.RowModified = false;
                        return;
                    }

                    // check if LA, LohnArt and KS are still valid
                    // LA
                    if (!qryLa.Find(String.Format("Code$ = ISNULL({0}, -1)", newRow["BDELeistungsartID"])))
                    {
                        // LA is no more available, do not continue
                        KissMsg.ShowError(CLASSNAME, "CopyLANoMoreAvailable", "Die verwendete Leistungsart steht heute nicht mehr zur Verfügung, dieser Datensatz kann nicht nach Datum '{0}' kopiert werden.", null, null, 0, 0, selectedDates[i].ToShortDateString());

                        // do not continue
                        qryData.RowModified = false;
                        return;
                    }

                    // LohnArt
                    if (!qryLohnArt.Find(String.Format("Code = ISNULL({0}, -1)", newRow["LohnartCode"])))
                    {
                        // LohnArt is no more available, do not continue
                        KissMsg.ShowError(CLASSNAME, "CopyLohnArtNoMoreAvailable", "Die verwendete Lohnart steht heute nicht mehr zur Verfügung, dieser Datensatz kann nicht nach Datum '{0}' kopiert werden.", null, null, 0, 0, selectedDates[i].ToShortDateString());

                        // do not continue
                        qryData.RowModified = false;
                        return;
                    }

                    // KS
                    if (!qryKs.Find(String.Format("Code = ISNULL({0}, -1)", newRow["KostenstelleOrgUnitID"])))
                    {
                        // KS is no more available, do not continue
                        KissMsg.ShowError(CLASSNAME, "CopyKSNoMoreAvailable", "Die verwendete Kostenstelle steht heute nicht mehr zur Verfügung, dieser Datensatz kann nicht nach Datum '{0}' kopiert werden.", null, null, 0, 0, selectedDates[i].ToShortDateString());

                        // do not continue
                        qryData.RowModified = false;
                        return;
                    }

                    // TODO KTR
                    var qryKtr = BdeUtil.GetKostentraegerAtDate(_userID, Convert.ToInt32(qryData["BDELeistungsartID"]), selectedDates[i].Date);
                    if (!qryKtr.Find(String.Format("Kostentraeger = ISNULL({0}, -1)", newRow[DBO.BDELeistung.HistKostentraeger])))
                    {
                        // KS is no more available, do not continue
                        KissMsg.ShowError(CLASSNAME, "CopyKTRNoMoreAvailable", "Der verwendete Kostenträger steht am {0} nicht mehr zur Verfügung, dieser Datensatz kann nicht kopiert werden.", null, null, 0, 0, selectedDates[i].ToShortDateString());

                        // do not continue
                        qryData.RowModified = false;
                        return;
                    }

                    // CONTINUE
                    // modify copied values!
                    newRow[DBO.BDELeistung.Datum] = selectedDates[i].Date;
                    newRow[DBO.BDELeistung.Freigegeben] = 0;
                    newRow[DBO.BDELeistung.Visiert] = 0;
                    newRow[DBO.BDELeistung.Verbucht] = DBNull.Value;
                    newRow[DBO.BDELeistung.VerbuchtLD] = DBNull.Value;
                    newRow[DBO.BDELeistung.KeinExport] = CheckKeinExport();

                    // add new row to query and save data
                    qryData.RowModified = false;		// somehow he thinks, he has changed the current row...
                    qryData.DataTable.Rows.Add(newRow);
                    qryData.RowModified = true;

                    // save data to database
                    if (!qryData.Post())
                    {
                        throw new Exception("Post has failed, data could not be inserted.");
                    }
                } // [end for]
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(CLASSNAME, "ErrorCopyEntryToNewDate_v01", "Es ist ein Fehler beim Kopieren der Einträge aufgetreten.", ex);
            }
            finally
            {
                // refresh query
                qryData.Refresh();

                // refresh fields
                CalcAndUpdateDayFields();

                // update states
                HandleErfassenUpdateAllowed();

                // set focus
                edtErfassungDatum.Focus();

                // reset cursor
                Cursor = currentCursor;
            }
        }

        private void btnErfassungTag05_Click(object sender, EventArgs e)
        {
            if (qryData.Count > 0 && edtErfassungStunden.EditMode == EditModeType.Normal && edtErfassungMinuten.EditMode == EditModeType.Normal)
            {
                ApplyDurationTime(0.5);
            }
        }

        private void btnErfassungTag1_Click(object sender, EventArgs e)
        {
            if (qryData.Count > 0 && edtErfassungStunden.EditMode == EditModeType.Normal && edtErfassungMinuten.EditMode == EditModeType.Normal)
            {
                ApplyDurationTime(1.0);
            }
        }

        private void btnKeinExportUmschalten_Click(object sender, EventArgs e)
        {
            if (!qryData.Post())
            {
                return;
            }

            try
            {
                Session.BeginTransaction();

                var today = DateTime.Today;

                // Überprüfen, ob das Feld gesetzt ist.
                var keinExportCount = Utils.ConvertToInt(
                    DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(1)
                        FROM dbo.BDELeistung
                        WHERE UserID = {0}
                          AND Verbucht IS NULL
                          AND KeinExport = 1;",
                        _userID));

                DBUtil.NewHistoryVersion();

                // Wenn kein Eintrag mit KeinExport=1 existiert, werden alle auf KeinExport=1 gesetzt, sonst auf 0
                DBUtil.ExecSQL(@"
                    UPDATE dbo.BDELeistung
                    SET KeinExport = {0}
                    WHERE UserID = {1}
                      AND Verbucht IS NULL;",
                    (keinExportCount == 0),
                    _userID);

                Session.Commit();

                OnRefreshData();

                qryData.Last();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(CLASSNAME, "MonatUmschaltenFehler", "Der Vorgang konnte nicht durchgeführt werden.", ex);
            }
        }

        private void btnMonatFakturiertEntfernen_Click(object sender, EventArgs e)
        {
            // check if enabled
            if (!btnMonatFakturiertEntfernen.Enabled)
            {
                return;
            }

            // set visum
            SetResetMonthFakturiert(false);
        }

        private void btnMonatFakturiertSetzen_Click(object sender, EventArgs e)
        {
            // check if enabled
            if (!btnMonatFakturiertSetzen.Enabled)
            {
                return;
            }

            // set visum
            SetResetMonthFakturiert(true);
        }

        private void btnMonatFreigabeAufheben_Click(object sender, EventArgs e)
        {
            // check if enabled
            if (!btnMonatFreigabeAufheben.Enabled)
            {
                return;
            }

            // remove freigabe
            SetResetMonthFreigabe(false);
        }

        private void btnMonatFreigeben_Click(object sender, EventArgs e)
        {
            // check if enabled
            if (!btnMonatFreigeben.Enabled)
            {
                return;
            }

            // set freigabe
            SetResetMonthFreigabe(true);
        }

        private void btnMonatVisieren_Click(object sender, EventArgs e)
        {
            // check if enabled
            if (!btnMonatVisieren.Enabled)
            {
                return;
            }

            // set visum
            SetResetMonthVisum(true);
        }

        private void btnMonatVisumAufheben_Click(object sender, EventArgs e)
        {
            // check if enabled
            if (!btnMonatVisumAufheben.Enabled)
            {
                return;
            }

            // remove visum
            SetResetMonthVisum(false);
        }

        private void btnStundenimport_Click(object sender, EventArgs e)
        {
            if (!OnSaveData())
            {
                return;
            }

            if (ofdExcelImport.ShowDialog(this) == DialogResult.OK)
            {
                using (var importer = new BdeExcelImporter(ofdExcelImport.FileName))
                {
                    if (importer.Load() && importer.BdeLeistungDTOList.Count > 0)
                    {
                        var writer = new BdeImportWriter(importer.BdeLeistungDTOList);
                        writer.WriteToDatabase();

                        OnRefreshData();
                    }
                }
            }
        }

        private void btnUebersichtHeute_Click(object sender, EventArgs e)
        {
            // udpate fields (with end of current month)
            UpdateUebersichtFields(null);
        }

        private void btnUebersichtNachmonat_Click(object sender, EventArgs e)
        {
            // get current displayed month
            var shownDate = edtUebersichtMonat.EditValue as DateTime?;

            // check if we have a date
            if (shownDate.HasValue)
            {
                // get first day of given month
                shownDate = new DateTime(shownDate.Value.Year, shownDate.Value.Month, 1);

                // add one month to given date and show month
                shownDate = shownDate.Value.AddMonths(1);
            }

            // udpate fields (with end of next month)
            UpdateUebersichtFields(shownDate);
        }

        private void btnUebersichtVormonat_Click(object sender, EventArgs e)
        {
            // get current displayed month
            var shownDate = edtUebersichtMonat.EditValue as DateTime?;

            // check if we have a date
            if (shownDate.HasValue)
            {
                // get first day of given month
                shownDate = new DateTime(shownDate.Value.Year, shownDate.Value.Month, 1);

                // subtract one month to given date and show month
                shownDate = shownDate.Value.AddMonths(-1);
            }

            // udpate fields (with end of previous month)
            UpdateUebersichtFields(shownDate);

            // focus tab
            edtUebersichtMonat.Focus();
        }

        private void btnWocheAufklappen_Click(object sender, EventArgs e)
        {
            // show all data
            grdWoche.View.ExpandAllGroups();
        }

        private void btnWocheZuklappen_Click(object sender, EventArgs e)
        {
            // collapse view
            grdWoche.View.CollapseAllGroups();
        }

        private void btnZeitrechner_Click(object sender, EventArgs e)
        {
            // check if need to proceed
            if (panZeitrechner.Visible)
            {
                grdZeitrechner.Focus();
                return;
            }

            // save pending data on tab
            if (!SavePendingChanges())
            {
                // cancel button click
                tabZeiterfassung.Focus();
                return;
            }

            // setup data
            qryZeitrechner.Fill(@"
                    SELECT *
                    FROM dbo.BDEZeitrechner WITH (READUNCOMMITTED)
                    WHERE UserID = {0}
                    ORDER BY Datum ASC, ZeitVon ASC, ZeitBis ASC", _userID);

            ActiveSQLQuery = qryZeitrechner;

            // setup button (focused)
            btnZeitrechner.BackColor = tabZeiterfassung.FlatStyleSelectedTabColor;
            btnZeitrechner.FlatAppearance.BorderColor = tabZeiterfassung.FlatStyleSelectedTabBorderColor;
            btnZeitrechner.FlatAppearance.MouseDownBackColor = btnZeitrechner.BackColor;
            btnZeitrechner.FlatAppearance.MouseOverBackColor = btnZeitrechner.BackColor;

            // hide other tabs
            tabZeiterfassung.SelectedTabIndex = -1;

            // show panel
            panZeitrechner.Visible = true;
            panZeitrechner.BringToFront();

            // select last entry
            qryZeitrechner.Last();

            // set focus
            grdZeitrechner.Focus();
        }

        private void CtlBDEZeiterfassung_KeyDown(Object sender, KeyEventArgs e)
        {
            // catch keys only if tpgErfassung is selected
            if (tabZeiterfassung.SelectedTabIndex == 0 && e.Alt && !e.Shift && !e.Control)
            {
                // set var for label
                KissLabel lbl = null;

                if (e.KeyCode == Keys.D1)
                {
                    // Datum
                    lbl = lblErfassungDatum;
                }
                else if (e.KeyCode == Keys.D2)
                {
                    // Klient
                    lbl = lblErfassungKlient;
                }
                else if (e.KeyCode == Keys.D3)
                {
                    // Leistungsart
                    lbl = lblErfassungLeistungsart;
                }
                else if (e.KeyCode == Keys.D4)
                {
                    // Anzahl
                    lbl = lblErfassungAnzahl;
                }
                else if (e.KeyCode == Keys.D5)
                {
                    // Kostenstelle
                    lbl = lblErfassungKostenstelle;
                }
                else if (e.KeyCode == Keys.D6)
                {
                    // Lohnart
                    lbl = lblErfassungLohnart;
                }
                else if (e.KeyCode == Keys.D7)
                {
                    // Dauer
                    lbl = lblErfassungDauer;
                }
                else if (e.KeyCode == Keys.D8)
                {
                    // Bemerkungen
                    lbl = lblErfassungBemerkungen;
                }

                // simulate click on label if any set
                if (lbl != null)
                {
                    Label_Click(lbl, EventArgs.Empty);
                }
            }
        }

        private void CtlBDEZeiterfassung_Load(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // fill dropdown of users
            btnAngezeigterMAFilter_Click(this, EventArgs.Empty);

            // logging
            _logger.Debug("call FillDataAndInit");

            // load data of current user
            FillDataAndInit();

            // setup flags
            _doValidateLeistungsart = true;
            _isLoading = false;

            // manually refresh enabled of fields
            qryData_PositionChanged(this, EventArgs.Empty);

            // logging
            _logger.Debug("done");
        }

        private void edtAngezeigterMitarbeiter_EditValueChanged(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("starting with current userid={0}", _userID);

            // check if need to go on
            if (_isLoading)
            {
                // logging
                _logger.Debug("isLoading=true, do nothing!");

                // is still loading, do nothing
                return;
            }

            // store current tabpage
            TabPageEx lastSelectedTab = tabZeiterfassung.SelectedTab;

            // validate
            if (DBUtil.IsEmpty(edtAngezeigterMitarbeiter.EditValue))
            {
                // invalid, reset
                _userID = Session.User.UserID;
                _userIsLocked = false;
                edtAngezeigterMitarbeiter.EditValue = _userID;

                // logging
                _logger.Debug("edtAngezeigterMitarbeiter.EditValue is empty, reset userid to logon-userid");
            }
            else
            {
                // apply new user id
                _userID = Convert.ToInt32(edtAngezeigterMitarbeiter.EditValue);
                var mitarbeiterQuery = edtAngezeigterMitarbeiter.Properties.DataSource as SqlQuery;
                if (mitarbeiterQuery != null)
                {
                    var rows = mitarbeiterQuery.DataTable.Select(string.Format("Code = {0}", _userID));
                    if (rows.Length > 0)
                    {
                        _userIsLocked = Utils.ConvertToBool(rows[0]["IsLocked"]);
                    }
                    else
                    {
                        _userIsLocked = false; //default: allow
                    }
                }
                else
                {
                    _userIsLocked = false; //default: allow
                }

                // logging
                _logger.Debug("applied new userid as given in editvalue");

                // check if not admin (admin has no restrictions)
                if (!HasUserAdminRights())
                {
                    // check if current user is allowed to view data of userID (use fnBDEGetOEUserList due to no-admin-call)
                    Int32 countAccessUser = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                            SELECT COUNT(1)
                            FROM dbo.fnBDEGetOEUserList({0}, 0)
                            WHERE [Code] = {1}", Session.User.UserID, _userID));

                    // check access
                    if (countAccessUser < 1)
                    {
                        // user has no access to other user's data, reset
                        try
                        {
                            // prevent reloading
                            _isLoading = true;

                            // apply userid of current user for security reason
                            _userID = Session.User.UserID;
                            _userIsLocked = false;
                            edtAngezeigterMitarbeiter.EditValue = _userID;

                            // show info
                            KissMsg.ShowInfo(CLASSNAME, "AccessToUserDataDenied", "Der Zugriff auf die ZLE-Daten des gewünschten Mitarbeiters ist nicht gestattet.");

                            // logging
                            _logger.Debug("user has no access to other user's data, reset userid");
                        }
                        finally
                        {
                            // reset falg
                            _isLoading = false;
                        } // [try]
                    } // [countAccessUser < 1]
                } // [!HasUserAdminRights()]
            } // [else of DBUtil.IsEmpty(edtAngezeigterMitarbeiter.EditValue)]

            // logging
            _logger.DebugFormat("we now have userid={0}", _userID);

            // do not validate leistungsart
            _doValidateLeistungsart = false;

            // logging
            _logger.Debug("call FillDataAndInit()");

            // load data of new user
            FillDataAndInit();

            // logging
            _logger.Debug("done call FillDataAndInit()");

            // do validate leistungsart
            _doValidateLeistungsart = true;

            // logging
            _logger.Debug("call qryData_PositionChanged(...)");

            // manually refresh enabled of fields (including depending on selected LA)
            qryData_PositionChanged(this, EventArgs.Empty);

            // reselect last tab-page if any defined and not yet selected
            if (lastSelectedTab != null && !tabZeiterfassung.IsTabSelected(lastSelectedTab))
            {
                // select last used tab
                tabZeiterfassung.SelectTab(lastSelectedTab);

                // logging
                _logger.Debug("selected last used tabpage");
            }

            // logging
            _logger.DebugFormat("finishing with current userid={0}", _userID);
            _logger.Debug("done");
        }

        private void edtAngezeigterMitarbeiter_EditValueChanging(Object sender, ChangingEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // check if we are in loading
            if (!_isLoading)
            {
                // value can only switch if data can be saved!
                e.Cancel = !SavePendingChanges();
            }

            // logging
            _logger.Debug("done");
        }

        private void edtErfassungKlient_EditValueChanged(object sender, EventArgs e)
        {
            // set flag that Klient has changed
            _hasKlientChanged = true;

            // set flag that Leistungsart has changed to validate if this Leistungsart is valid
            _hasLeistungsartChanged = true;
        }

        private void edtErfassungKlient_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogKlient((KissButtonEdit)sender, e);
        }

        private void edtErfassungLeistungsart_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                // check if need to set flag
                if (_doValidateLeistungsart)
                {
                    // data has changed
                    _hasLeistungsartChanged = true;
                }

                // validate first
                if (!_doValidateLeistungsart || DBUtil.IsEmpty(qryData["BDELeistungsart"]))
                {
                    // check if we have a new row
                    if (_doValidateLeistungsart && qryData.Count > 0 && qryData.Row.RowState == DataRowState.Added)
                    {
                        // enable and disable fields
                        edtErfassungKlient.EditMode = EditModeType.Normal;
                        edtErfassungAnzahl.EditMode = EditModeType.ReadOnly;
                        edtErfassungKlient.TabStop = true;
                        edtErfassungAnzahl.TabStop = false;
                    }
                    else
                    {
                        // disable fields
                        edtErfassungKlient.EditMode = EditModeType.ReadOnly;
                        edtErfassungAnzahl.EditMode = EditModeType.ReadOnly;
                        edtErfassungKlient.TabStop = false;
                        edtErfassungAnzahl.TabStop = false;
                    }

                    // cancel
                    return;
                }

                // get values
                bool isKlientZwingend = true;
                bool isKlientOptional = true;
                bool isAnzahlZwingend = false;
                bool isAnzahlOptional = false;

                // get values if possible
                if (!DBUtil.IsEmpty(qryData["IstKlientZwingend"]) && !DBUtil.IsEmpty(qryData["IstKlientOptional"]) &&
                    !DBUtil.IsEmpty(qryData["IstAnzahlZwingend"]) && !DBUtil.IsEmpty(qryData["IstAnzahlOptional"]))
                {
                    isKlientZwingend = Convert.ToBoolean(qryData["IstKlientZwingend"]);
                    isKlientOptional = Convert.ToBoolean(qryData["IstKlientOptional"]);
                    isAnzahlZwingend = Convert.ToBoolean(qryData["IstAnzahlZwingend"]);
                    isAnzahlOptional = Convert.ToBoolean(qryData["IstAnzahlOptional"]);
                }

                // setup controls
                if (isKlientZwingend || isKlientOptional)
                {
                    // can enter a Klient --> enable control
                    edtErfassungKlient.EditMode = EditModeType.Normal;
                    edtErfassungKlient.TabStop = true;
                }
                else
                {
                    // cannot enter a Klient --> disable control
                    edtErfassungKlient.EditMode = EditModeType.ReadOnly;
                    edtErfassungKlient.TabStop = false;
                }

                if (isAnzahlZwingend || isAnzahlOptional)
                {
                    // can enter a Anzahl --> enable control
                    edtErfassungAnzahl.EditMode = EditModeType.Normal;
                    edtErfassungAnzahl.TabStop = true;
                }
                else
                {
                    // cannot enter a Anzahl --> disable control
                    edtErfassungAnzahl.EditMode = EditModeType.ReadOnly;
                    edtErfassungAnzahl.TabStop = false;
                }
            }
            catch (Exception ex)
            {
                // disable fields
                edtErfassungKlient.EditMode = EditModeType.ReadOnly;
                edtErfassungAnzahl.EditMode = EditModeType.ReadOnly;
                edtErfassungKlient.TabStop = false;
                edtErfassungAnzahl.TabStop = false;

                // show error
                KissMsg.ShowError(Name, "ErrorSetupFieldEditValues", "Fehler bei der Verarbeitung.", "Error in EditValueChanged: ", ex);
            }
        }

        private void edtErfassungLeistungsart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // let the user select any LA
            e.Cancel = !DialogLeistungsart((KissButtonEdit)sender, e);

            // set flag for setting focus
            if (!e.Cancel)
            {
                // (re)set focus to control
                edtErfassungLeistungsart.Focus();

                InitAndSetKostentraegerDropDown();
            }
        }

        private void edtErfassungStunden_Leave(Object sender, EventArgs e)
        {
            try
            {
                // setup value
                edtErfassungStunden.DoValidate();

                // validate
                if (DBUtil.IsEmpty(edtErfassungStunden.EditValue) || !qryData.CanUpdate)
                {
                    // do nothing if no value or locked
                    return;
                }

                // get hours and minutes
                double hours = Convert.ToDouble(edtErfassungStunden.EditValue);
                bool isNegative = false;

                if (hours < 0)
                {
                    isNegative = true;
                    hours = -hours;
                }

                double minutes = hours - Math.Floor(hours);

                if (minutes >= 0)
                {
                    // calulate new values
                    hours = isNegative ? -Math.Floor(hours) : Math.Floor(hours);
                    minutes = Convert.ToInt32(60 * minutes);

                    // check minutes changed
                    bool hasMinuteChanged = DBUtil.IsEmpty(edtErfassungMinuten.EditValue) ||
                                            Convert.ToString(edtErfassungStunden.EditValue).IndexOf(".", StringComparison.Ordinal) > -1;

                    // apply to query and controls
                    edtErfassungStunden.EditValue = hours;
                    edtErfassungMinuten.EditValue = hasMinuteChanged ? minutes : edtErfassungMinuten.EditValue;	// change if modified or keep current value

                    qryData["Stunden"] = hours;
                    qryData["Minuten"] = hasMinuteChanged ? minutes : qryData["Minuten"];	// change if modified or keep current value
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "DezimalStundenNachMinuten", "Die Stunden konnten nicht nach Stunden und Minuten konvertiert werden.", ex);
            }
        }

        private void edtSucheKlient_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogKlient((KissButtonEdit)sender, e);
        }

        private void edtSucheLeistungsart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogLeistungsart((KissButtonEdit)sender, e);
        }

        private void grvBDELeistung_CustomDrawCell(Object sender, RowCellCustomDrawEventArgs e)
        {
            try
            {
                // get values
                string stdMin = Convert.ToString(grvBDELeistung.GetRowCellValue(e.RowHandle, grvBDELeistung.Columns[colErfassungDauer.FieldName]));
                string amount = Convert.ToString(grvBDELeistung.GetRowCellValue(e.RowHandle, grvBDELeistung.Columns[colErfassungAnzahl.FieldName]));

                // handle duration
                if (!string.IsNullOrEmpty(stdMin))
                {
                    stdMin = stdMin.Replace(":", ".");

                    if (Convert.ToDouble(stdMin) < 0.0)
                    {
                        // negative values are red
                        e.Appearance.ForeColor = _negativeColor;
                    }
                }

                // handle amount
                if (e.Column.FieldName == colErfassungAnzahl.FieldName)
                {
                    if (!string.IsNullOrEmpty(amount) && Convert.ToInt32(amount) < 0)
                    {
                        // negative values are always red
                        e.Appearance.ForeColor = _negativeColor;
                    }
                    else
                    {
                        // set default forecolor depending on focused row and control
                        if (e.RowHandle != grvBDELeistung.FocusedRowHandle || !grvBDELeistung.GridControl.Focused)
                        {
                            e.Appearance.ForeColor = _defaultForeColor;
                        }
                        else
                        {
                            e.Appearance.ForeColor = _focusedRowForeColor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }
        }

        private void grvMonat_CustomDrawCell(Object sender, RowCellCustomDrawEventArgs e)
        {
            try
            {
                // display value-fields in red if value is negative
                if (e.Column.FieldName == "GZIstArbeitszeitProMonat" || e.Column.FieldName == "GZSollArbeitszeitProMonat" || e.Column.FieldName == "GZMonatsSaldo" ||
                    e.Column.FieldName == "GZUebertragVorjahr" || e.Column.FieldName == "GZKorrekturen" || e.Column.FieldName == "GZAusbezahlteUeberstunden" ||
                    e.Column.FieldName == "GZSaldo" || e.Column.FieldName == "FerienUebertragVorjahr" || e.Column.FieldName == "FerienAnspruchProJahr" ||
                    e.Column.FieldName == "FerienBisherBezogen" || e.Column.FieldName == "FerienZugabenKuerzungen" || e.Column.FieldName == "FerienKorrekturen" ||
                    e.Column.FieldName == "FerienSaldo")
                {
                    // get value (GetRowCellValue() does not work...)
                    string val = Convert.ToString(grvMonat.GetRowCellDisplayText(e.RowHandle, e.Column));

                    // check value
                    if (!string.IsNullOrEmpty(val) && Convert.ToDouble(val) < 0.0)
                    {
                        // negative values are red
                        e.Appearance.ForeColor = _negativeColor;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }
        }

        private void grvWoche_CustomDrawCell(Object sender, RowCellCustomDrawEventArgs e)
        {
            try
            {
                // display Tages-Ist and Differenz in red if value is negative
                if (e.Column.FieldName == "TagesIst" || e.Column.FieldName == "Differenz")
                {
                    // get value
                    string val = Convert.ToString(grvWoche.GetRowCellValue(e.RowHandle, e.Column));

                    // check value
                    if (!string.IsNullOrEmpty(val) && Convert.ToDouble(val) < 0.0)
                    {
                        // negative values are red
                        e.Appearance.ForeColor = _negativeColor;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }
        }

        private void grvWoche_CustomDrawFooterCell(Object sender, FooterCellCustomDrawEventArgs e)
        {
            try
            {
                // display summary Tages-Ist and Differenz in red if value is negative
                if (e.Column.FieldName == "TagesIst" || e.Column.FieldName == "Differenz")
                {
                    // get value
                    string val = Convert.ToString(grvWoche.GetRowFooterCellText(e.RowHandle, e.Column));

                    // check value
                    if (!string.IsNullOrEmpty(val) && Convert.ToDouble(val) < 0.0)
                    {
                        // negative values are red
                        e.Appearance.ForeColor = _negativeColor;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (!(sender is KissLabel))
            {
                return;
            }

            var lbl = (KissLabel)sender;
            lbl.Font = new Font(GuiConfig.LabelFontName, GuiConfig.LabelFontSize, lbl.Font.Underline ? FontStyle.Regular : FontStyle.Underline, GuiConfig.LabelFontGraphicUnit);
        }

        private void qryData_AfterFill(object sender, EventArgs e)
        {
            // manually refresh enabled of fields
            qryData_PositionChanged(this, EventArgs.Empty);
        }

        private void qryData_AfterInsert(object sender, EventArgs e)
        {
            // update fields
            CalcAndUpdateDayFields();

            // default value for "Datum"
            if (lblErfassungDatum.Font.Underline)
            {
                qryData["Datum"] = _saveRow["Datum"];
            }
            else
            {
                qryData["Datum"] = DateTime.Today;
            }

            // default value for "Klient"
            if (lblErfassungKlient.Font.Underline)
            {
                qryData["Klient"] = _saveRow["Klient"];
                qryData["BaPersonID"] = _saveRow["BaPersonID"];
                _hasKlientChanged = false;
            }

            // default value for "Leistungsart"
            if (lblErfassungLeistungsart.Font.Underline)
            {
                qryData["BDELeistungsartID"] = _saveRow["BDELeistungsartID"];
                qryData["BDELeistungsart"] = _saveRow["BDELeistungsart"];
                qryData["IstKlientZwingend"] = _saveRow["IstKlientZwingend"];
                qryData["IstKlientOptional"] = _saveRow["IstKlientOptional"];
                qryData["IstAnzahlZwingend"] = _saveRow["IstAnzahlZwingend"];
                qryData["IstAnzahlOptional"] = _saveRow["IstAnzahlOptional"];
                //if(edtErfassungKostentraeger.Properties.DataSource)
                qryData[DBO.BDELeistung.HistKostentraeger] = _saveRow[DBO.BDELeistung.HistKostentraeger];
                _hasLeistungsartChanged = false;
            }

            // default value for "Anzahl"
            if (lblErfassungAnzahl.Font.Underline)
            {
                qryData["Anzahl"] = _saveRow["Anzahl"];
            }

            // default value for "Dauer"
            if (lblErfassungDauer.Font.Underline)
            {
                qryData["Stunden"] = _saveRow["Stunden"];
                qryData["Minuten"] = _saveRow["Minuten"];
            }

            // default for "Kostenstelle"
            if (lblErfassungKostenstelle.Font.Underline && !DBUtil.IsEmpty(_saveRow["KostenstelleOrgUnitID"]) && Convert.ToInt32(_saveRow["KostenstelleOrgUnitID"]) > 0)
            {
                // take copied value
                qryData["KostenstelleOrgUnitID"] = _saveRow["KostenstelleOrgUnitID"];
            }
            else
            {
                // take default Kostenstelle of user's member orgunit
                qryData["KostenstelleOrgUnitID"] = _userMemberOrgUnitID;
            }

            //TODO Defaultwert für Kostenträger setzen?

            // default value for "Lohnart"
            if (lblErfassungLohnart.Font.Underline)
            {
                qryData["LohnartCode"] = _saveRow["LohnartCode"];
            }

            // check if we have a value and the user can modify field
            if (_hasUserMonatslohn && DBUtil.IsEmpty(qryData["LohnartCode"]))
            {
                // set default value as Monatslohn for user
                qryData["LohnartCode"] = -1;
            }
            else if (qryLohnArt.Count == 1)
            {
                qryLohnArt.First();
                qryData["LohnartCode"] = qryLohnArt["Code"];
            }

            // default value for "Bemerkungen"
            if (lblErfassungBemerkungen.Font.Underline)
            {
                qryData["Bemerkung"] = _saveRow["Bemerkung"];
            }

            // KeinExport-Flag
            qryData[DBO.BDELeistung.KeinExport] = CheckKeinExport();

            // refresh and focus
            qryData.RefreshDisplay();

            // update enabled state of controls
            edtErfassungLeistungsart_EditValueChanged(this, EventArgs.Empty);
            btnErfassungTag05.Enabled = _workTimePerDay > 0;
            btnErfassungTag1.Enabled = _workTimePerDay > 0;

            // setup focus
            edtErfassungDatum.Focus();
        }

        private void qryData_AfterPost(object sender, EventArgs e)
        {
            // refresh display
            CalcAndUpdateDayFields();
            InitKostentraegerDropDown();

            // update content
            qryData["KostenstelleName"] = edtErfassungKostenstelle.Text;
            qryData["Lohnart"] = edtErfassungLohnart.Text;

            // store latest row
            if (_insertMode)
            {
                _saveRow = qryData.Row;
            }
        }

        private void qryData_BeforeDelete(object sender, EventArgs e)
        {
            // make new history version
            DBUtil.NewHistoryVersion();
        }

        private void qryData_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryData["Verbucht"]))
            {
                throw new KissInfoException("Diese Erfassung ist bereits verbucht und kann nicht mehr gelöscht werden.");
            }
        }

        private void qryData_BeforePost(object sender, EventArgs e)
        {
            // EVAL FIELDS
            // force calculating double hours to hours and minutes
            edtErfassungStunden_Leave(this, EventArgs.Empty);

            qryData.EndCurrentEdit();

            // do validate
            edtErfassungDatum.DoValidate();
            edtErfassungKlient.DoValidate();
            edtErfassungLeistungsart.DoValidate();
            edtErfassungAnzahl.DoValidate();
            edtErfassungStunden.DoValidate();
            edtErfassungMinuten.DoValidate();
            edtErfassungKostenstelle.DoValidate();
            memErfassungBemerkungen.DoValidate();

            // VALIDATE MUST FIELDS
            DBUtil.CheckNotNullField(edtErfassungDatum, lblErfassungDatum.Text);
            DBUtil.CheckNotNullField(edtErfassungLeistungsart, lblErfassungLeistungsart.Text);
            DBUtil.CheckNotNullField(edtErfassungKostenstelle, lblErfassungKostenstelle.Text);
            DBUtil.CheckNotNullField(edtErfassungKostentraeger, lblErfassungKostentraeger.Text);

            // check if valid Kostenstelle
            if (Convert.ToInt32(edtErfassungKostenstelle.EditValue) < 1)
            {
                // negative value is not allowed for Kostenstelle
                edtErfassungKostenstelle.Focus();
                KissMsg.ShowError(CLASSNAME, "InvalidKostenstelleOnBeforePost", "Es muss eine gültige Kostenstelle angegeben werden.");
                throw new KissCancelException();
            }

            // LOHNART
            // lohnart is a must field
            DBUtil.CheckNotNullField(edtErfassungLohnart, lblErfassungLohnart.Text);

            // only monatslohn can have a value < 1
            if (!_hasUserMonatslohn && Convert.ToInt32(edtErfassungLohnart.EditValue) < 1)
            {
                // invalid value for Lohnart
                edtErfassungLohnart.Focus();
                KissMsg.ShowError(CLASSNAME, "InvalidLohnartValueOnBeforePost", "Das Feld 'Lohnart' hat keinen gültigen Wert für die Stundenlohn-Erfassung.");
                throw new KissCancelException();
            }

            // check if db-value in SqlQuery is valid and same as in edit-field
            if (DBUtil.IsEmpty(qryData["LohnartCode"]) || Convert.ToInt32(qryData["LohnartCode"]) != Convert.ToInt32(edtErfassungLohnart.EditValue))
            {
                // invalid value for Lohnart
                edtErfassungLohnart.Focus();
                KissMsg.ShowError(CLASSNAME, "InvalidLohnartDBValueOnBeforePost", "Das Feld 'Lohnart' hat keinen gültigen Datenbank-Wert.");
                throw new KissCancelException();
            }

            // VALIDATE BUTTONEDITS
            if (_hasLeistungsartChanged && !DialogLeistungsart(edtErfassungLeistungsart, new UserModifiedFldEventArgs(false, false)))
            {
                // invalid Leistungsart
                edtErfassungLeistungsart.Focus();
                throw new KissCancelException();
            }
            _hasLeistungsartChanged = false;

            if (_hasKlientChanged && !DialogKlient(edtErfassungKlient, new UserModifiedFldEventArgs(false, false)))
            {
                // invalid Klient
                edtErfassungKlient.Focus();
                throw new KissCancelException();
            }
            _hasKlientChanged = false;

            bool isKlientZwingend = true;
            bool isKlientOptional = true;

            // get values if possible
            if (!DBUtil.IsEmpty(qryData["IstKlientZwingend"]) && !DBUtil.IsEmpty(qryData["IstKlientOptional"]))
            {
                isKlientZwingend = Convert.ToBoolean(qryData["IstKlientZwingend"]);
                isKlientOptional = Convert.ToBoolean(qryData["IstKlientOptional"]);
            }

            // setup controls
            if (!(isKlientZwingend || isKlientOptional))
            {
                // no data allowed
                qryData["BaPersonID"] = DBNull.Value;
            }
            else if (isKlientZwingend)
            {
                // data needed
                DBUtil.CheckNotNullField(edtErfassungKlient, lblErfassungKlient.Text);
            }

            if (edtErfassungAnzahl.EditMode == EditModeType.ReadOnly)
            {
                // no data allowed
                qryData["Anzahl"] = DBNull.Value;
            }
            else if (Convert.ToBoolean(qryData["IstAnzahlZwingend"]))
            {
                // data needed
                DBUtil.CheckNotNullField(edtErfassungAnzahl, lblErfassungAnzahl.Text);
            }

            // VALIDATE DATE
            DateTime dateOfEntry = Convert.ToDateTime(qryData["Datum"]);

            // check if user can update data with this Datum
            var visumPruefungNoetig = false;
            foreach (DataColumn column in qryData.DataTable.Columns)
            {
                if (column.ColumnName != "Fakturiert" && qryData.ColumnModified(column.ColumnName))
                {
                    visumPruefungNoetig = true;
                    break;
                }
            }

            if (visumPruefungNoetig && IsDateAlreadyLocked(dateOfEntry))
            {
                // no more changes on this month are allowed
                KissMsg.ShowError(CLASSNAME, "MonthCanNotBeUsedAnymore", "Das Datum '{0}' kann nicht mehr verwendet werden. Dieser Monat wurde bereits freigegeben oder visiert.", null, null, 0, 0, dateOfEntry.ToShortDateString());
                edtErfassungDatum.Focus();
                throw new KissCancelException();
            }

            // VALIDATE MEMBERSHIP
            int memberOrgUnit = BdeUtil.GetMemberOrgUnitAtDate(_userID, dateOfEntry);

            if (memberOrgUnit < 1)
            {
                // date cannot be uses, no memberhip at given date
                KissMsg.ShowError(CLASSNAME, "NoMembershipAtGivenDate", "Das Datum '{0}' kann nicht verwendet werden, da zu diesem Zeitpunkt kein Mitgliedschaft zu einer Abteilung besteht.", null, null, 0, 0, dateOfEntry.ToShortDateString());
                edtErfassungDatum.Focus();
                throw new KissCancelException();
            }

            // VALIDATE KOSTENSTELLE/KOSTENART/KOSTENTRÄGER
            // kostenstelle
            int kostenstelle = BdeUtil.GetKostenstelleAtDate(_userID, dateOfEntry, Convert.ToInt32(qryData["KostenstelleOrgUnitID"]));

            if (kostenstelle < 1)
            {
                // date cannot be uses, no Kostenstelle at given date
                KissMsg.ShowError(CLASSNAME, "NoKostenstelleAtGivenDate", "Das Datum '{0}' kann nicht verwendet werden, da zu diesem Zeitpunkt keine Kostenstelle definiert ist.", null, null, 0, 0, dateOfEntry.ToShortDateString());
                edtErfassungDatum.Focus();
                throw new KissCancelException();
            }

            // Kostenträger
            var histKostentraegerQry = BdeUtil.GetKostentraegerAtDate(_userID, Convert.ToInt32(qryData[DBO.BDELeistung.BDELeistungsartID]), dateOfEntry);
            var histKostentraeger = histKostentraegerQry.IsEmpty ? -1 : Convert.ToInt32(histKostentraegerQry["Kostentraeger"]);

            if (histKostentraeger <= 0)
            {
                // date cannot be uses, no Kostenstelle at given date
                KissMsg.ShowError(CLASSNAME, "NoKostentraegerAtGivenDate", "Das Datum '{0}' kann nicht verwendet werden, da zu diesem Zeitpunkt kein Kostenträger definiert ist.", null, null, 0, 0, dateOfEntry.ToShortDateString());
                edtErfassungDatum.Focus();
                throw new KissCancelException();
            }

            if (!histKostentraegerQry.Find(string.Format("Kostentraeger = ISNULL({0}, -1)", qryData[DBO.BDELeistung.HistKostentraeger])))
            {
                KissMsg.ShowInfo(CLASSNAME, "KostentraegerWirdGeaendert", "Am {0} kann der Kostenträger '{1}' nicht mehr verwendet werden und wird automatisch angepasst.", dateOfEntry.ToShortDateString(), qryData[DBO.BDELeistung.HistKostentraeger]);
                qryData[DBO.BDELeistung.HistKostentraeger] = histKostentraeger;
            }

            // kostenart
            int kostenart = BdeUtil.GetKostenartAtDate(_userID, Convert.ToInt32(qryData["BDELeistungsartID"]), dateOfEntry);

            if (kostenart < 1)
            {
                // date cannot be uses, no Kostenart at given date
                KissMsg.ShowError(CLASSNAME, "NoKostenartAtGivenDate", "Das Datum '{0}' kann nicht verwendet werden, da zu diesem Zeitpunkt keine Kostenart definiert ist (Leistungsart und Benutzer).", null, null, 0, 0, dateOfEntry.ToShortDateString());
                edtErfassungDatum.Focus();
                throw new KissCancelException();
            }

            // APPLY HISTORY VALUES
            qryData["HistKostenstelle"] = kostenstelle;
            qryData["HistKostenart"] = kostenart;
            qryData["HistMandantNr"] = BdeUtil.GetMandantennummerAtDate(dateOfEntry, memberOrgUnit);

            // HOURS AND MINUTES
            // get vars
            bool isStundenEmpty = DBUtil.IsEmpty(qryData["Stunden"]);
            bool isMinutenEmpty = DBUtil.IsEmpty(qryData["Minuten"]);

            // only one "Dauer" field must have a value
            if (isStundenEmpty && isMinutenEmpty)
            {
                DBUtil.CheckNotNullField(edtErfassungStunden, lblErfassungDauer.Text);
            }

            try
            {
                // fill other "Dauer" field with "0" if empty
                if (isStundenEmpty)
                {
                    qryData["Stunden"] = 0;
                }
                else if (isMinutenEmpty)
                {
                    qryData["Minuten"] = 0;
                }

                // apply userid if not yet set
                if (DBUtil.IsEmpty(qryData["UserID"]))
                {
                    // apply userid only if not yet set - to prevent changing userid in case of unknown bug...
                    qryData["UserID"] = _userID;
                }

                // setup weekday
                if (DBUtil.IsEmpty(qryData["Datum"]))
                {
                    qryData["WT"] = DBNull.Value;
                }
                else
                {
                    // get "So", "Mo", ... from date
                    qryData["WT"] = DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT dbo.fnBDEGetWeekDayFromDate({0}, {1})", qryData["Datum"], Session.User.LanguageCode);
                }

                // handle Stunden, Minuten and Dauer
                bool isNegativeDuration = false;
                int stunden = Convert.ToInt32(qryData["Stunden"]);
                int minuten = Convert.ToInt32(qryData["Minuten"]);

                // handle negative minutes
                if (minuten < 0)
                {
                    // minutes cannot be negative, but hours
                    minuten = -minuten;
                    stunden = stunden < 0 ? stunden : -stunden;

                    /* TODO: negative minutes
                    isNegativeDuration = true;
                    minuten = -minuten;

                    if (stunden > 0)
                    {
                        // make hours negative if not yet done
                        stunden = -stunden;
                    }
                    */
                }

                if (stunden < 0)
                {
                    // invert hours and set flag for later
                    isNegativeDuration = true;
                    stunden = -stunden;
                }

                // calculate dauer, stunden, minuten
                double dauer = Convert.ToDouble(stunden) + Convert.ToDouble(minuten) / 60;

                stunden = Convert.ToInt32(Math.Floor(dauer));
                minuten = Convert.ToInt32(Math.Round((dauer - Math.Floor(dauer)) * 60, 0));

                dauer = isNegativeDuration ? -dauer : dauer;
                stunden = isNegativeDuration ? -stunden : stunden;

                // apply data
                qryData["StdMin"] = ConvertDurationToTimeString(dauer, false);
                qryData["Dauer"] = dauer;
                qryData["Stunden"] = stunden;
                qryData["Minuten"] = minuten;

                // DEBUG ONLY: MessageBox.Show(string.Format("stdmin={0}, dauer={1}, stunden={2}, minuten={3}", qryData["StdMin"], qryData["Dauer"], qryData["Stunden"], qryData["Minuten"]));

                // FREIGABE (if user has month freigegeben, then set flag if adding a new value to existing data)
                qryData["Freigegeben"] = DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT dbo.fnBDEIsMonatFreigegeben({0}, {1})", qryData["UserID"], qryData["Datum"]);

                // setup insertMode
                _insertMode = qryData.Row.RowState == DataRowState.Added;

                // new history entry
                if (qryData.RowModified)
                {
                    // make new history version
                    DBUtil.NewHistoryVersion();
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSNAME, "SpeichernFehlgeschlagen", "Die Daten können nicht gespeichert werden.", ex);
                throw new KissCancelException();
            }
        }

        private void qryData_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "Datum")
            {
                CalcAndUpdateDayFields();
            }
        }

        private void qryData_PositionChanged(object sender, EventArgs e)
        {
            // udpate day-fields
            CalcAndUpdateDayFields();

            // check if any data found
            if (qryData.Count > 0)
            {
                InitKostentraegerDropDown();

                // enable fields depending on "Verbucht"-state
                qryData.EnableBoundFields(DBUtil.IsEmpty(qryData["Verbucht"]));

                // udpate fields
                HandleErfassenUpdateAllowed();

                lblKeinExport.Visible = !HasUserAdminRights() && (qryData[DBO.BDELeistung.KeinExport] as bool? ?? false);
            }
            else
            {
                // do not allow update fields
                qryData.EnableBoundFields(false);

                lblKeinExport.Visible = !HasUserAdminRights();
            }
            //KPI-408: Gesperrte Benutzer dürfen nicht Zeiterfassen oder -Importieren
            qryData.CanInsert = !_userIsLocked;

            // reset flags
            _hasKlientChanged = false;
            _hasLeistungsartChanged = false;

            // get saved row
            _saveRow = qryData.Row;
        }

        private void qryMonat_PositionChanged(object sender, EventArgs e)
        {
            HandleButtonsFreigabeVisum();
        }

        private void qryZeitrechner_AfterInsert(object sender, EventArgs e)
        {
            // today as default
            qryZeitrechner["Datum"] = DateTime.Today;

            // focus
            edtZeitrechnerDatum.Focus();
        }

        private void qryZeitrechner_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryData["Verbucht"]))
            {
                throw new KissInfoException("Diese Erfassung ist bereits verbucht und kann nicht mehr gelöscht werden.");
            }
        }

        private void qryZeitrechner_BeforePost(object sender, EventArgs e)
        {
            // EVAL FIELDS
            edtZeitrechnerDatum.DoValidate();
            edtZeitrechnerZeitVon.DoValidate();
            edtZeitrechnerZeitBis.DoValidate();

            // MUST FIELDS
            // validate must fields
            DBUtil.CheckNotNullField(edtZeitrechnerDatum, lblZeitrechnerDatum.Text);
            DBUtil.CheckNotNullField(edtZeitrechnerZeitVon, lblZeitrechnerZeitVon.Text);

            // VALIDATE RANGE
            // validate range - check if any entry at this date is already in use
            if (DBUtil.IsEmpty(edtZeitrechnerZeitBis.EditValue))
            {
                // we only have a ZeitVon
            }
            else
            {
                // we have a ZeitVon and ZeitBis, validate if Bis > Von
                if (Convert.ToDateTime(edtZeitrechnerZeitVon.EditValue) >= Convert.ToDateTime(edtZeitrechnerZeitBis.EditValue))
                {
                    // invalid range
                    throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME, "InvalidTimeOrder", "Der Wert 'Zeit bis' ist ungültig - er darf nicht kleiner oder gleich 'Zeit von' sein."), edtZeitrechnerZeitBis);
                }
            }

            // validate if range is not yet in use (both cases are handled: only ZeitVon and ZeitVon/ZeitBis
            if (!Convert.ToBoolean(DBUtil.ExecuteScalarSQL(@"SELECT dbo.fnBDEIsZeitrechnerRangeValid({0}, {1}, {2}, {3}, {4})", _userID, edtZeitrechnerDatum.EditValue, edtZeitrechnerZeitVon.EditValue, edtZeitrechnerZeitBis.EditValue, qryZeitrechner["BDEZeitrechnerID"])))
            {
                // invalid range
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME, "InvalidTimeRange", "Der Wert 'Zeit von' und/oder 'Zeit bis' ist ungültig. Die Werte dürfen sich nicht mit bereits erfassten Zeiten überschneiden."), edtZeitrechnerZeitBis);
            }

            // VALIDATE DATE
            // check if user can update data with this Datum
            if (IsDateAlreadyLocked(Convert.ToDateTime(qryZeitrechner["Datum"])))
            {
                // no more changes on this month are allowed
                KissMsg.ShowError(CLASSNAME, "MonthCanNotBeUsedAnymore", "Das Datum '{0}' kann nicht mehr verwendet werden. Dieser Monat wurde bereits freigegeben oder visiert.", null, null, 0, 0, Convert.ToDateTime(qryZeitrechner["Datum"]).ToShortDateString());
                throw new KissCancelException();
            }

            // SETUP FINALY DATA
            // apply userid if not yet set
            if (DBUtil.IsEmpty(qryZeitrechner["UserID"]))
            {
                // apply userid only if not yet set - to prevent changing userid in case of unknown bug...
                qryZeitrechner["UserID"] = _userID;
            }
        }

        private void qryZeitrechner_PositionChanged(object sender, EventArgs e)
        {
            // check if added a new row
            if (qryZeitrechner.Row.RowState == DataRowState.Added)
            {
                // do nothing, handled in afterinsert
                return;
            }

            // check if we have a ZeitBis
            if (DBUtil.IsEmpty(qryZeitrechner["ZeitBis"]))
            {
                // set focus to ZeitBis
                edtZeitrechnerZeitBis.Focus();
            }
            else
            {
                // set focus to Datum
                edtZeitrechnerDatum.Focus();
            }
        }

        private void tabErfassung_SelectedTabChanged(TabPageEx page)
        {
            // panel depending action
            if (tabErfassung.IsTabSelected(tpgErfassungListe))
            {
                // run search
                DoSearch();
            }
        }

        private void tabZeiterfassung_SelectedTabChanged(TabPageEx page)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // we have to do the saving here, too because of the selectedtabindex = -1 (will not raise the changed event)
            if (!SavePendingChanges())
            {
                // check if we are in Zeitrechner
                if (panZeitrechner.Visible)
                {
                    try
                    {
                        // unselect selected tab again
                        _isSwitchingToEmptyTab = true;
                        tabZeiterfassung.SelectedTabIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        // logging
                        _logger.Debug(String.Format("!SavePendingChanges() = true, exception occured (ex={0})", ex));

                        throw;
                    }
                    finally
                    {
                        _isSwitchingToEmptyTab = false;
                    }
                }

                // logging
                _logger.Debug("!SavePendingChanges() = true, cancel request");

                return;
            }

            // hide panel
            if (panZeitrechner.Visible)
            {
                panZeitrechner.Visible = false;

                // setup button (not focused)
                btnZeitrechner.BackColor = tabZeiterfassung.BackColor;
                btnZeitrechner.FlatAppearance.BorderColor = tabZeiterfassung.TabsLineColor;
                btnZeitrechner.FlatAppearance.MouseDownBackColor = btnZeitrechner.BackColor;
                btnZeitrechner.FlatAppearance.MouseOverBackColor = btnZeitrechner.BackColor;
            }

            // logging
            _logger.DebugFormat("tabZeiterfassung.SelectedTabIndex={0}", tabZeiterfassung.SelectedTabIndex);

            // panel depending action
            switch (tabZeiterfassung.SelectedTabIndex)
            {
                case 0:
                    // Erfassen

                    // logging
                    _logger.Debug("erfassen start");

                    // won't work in every case: qryData.Refresh();
                    NewSearch();
                    tabErfassung.SelectTab(tpgErfassungListe); // simulate DoSearch()

                    ActiveSQLQuery = qryData;
                    CalcAndUpdateDayFields();		// update labels due to possibly changed Zeitrechner values
                    HandleErfassenUpdateAllowed();	// update allowed update or not

                    // logging
                    _logger.Debug("erfassen finished");
                    break;

                case 1:
                    // Woche

                    // logging
                    _logger.Debug("woche start");

                    ActiveSQLQuery = null;
                    grdWoche.DataSource = DBUtil.OpenSQL("EXEC spBDEGetLeistungWoche {0}, {1}", _userID, Session.User.LanguageCode);
                    grdWoche.View.CollapseAllGroups();
                    //grdWoche.View.MoveLastVisible();
                    grdWoche.View.ExpandGroupRow(grdWoche.View.FocusedRowHandle);

                    // logging
                    _logger.Debug("woche finished");
                    break;

                case 2:
                    // Monat

                    // logging
                    _logger.Debug("monat start");

                    ActiveSQLQuery = null;
                    qryMonat.Fill(@"
                            SELECT *
                            FROM dbo.fnBDEGetLeistungMonatView({0}, {1})", _userID, Session.User.LanguageCode);
                    //grdMonat.View.MoveLast();
                    HandleButtonsFreigabeVisum();
                    ActiveSQLQuery = qryMonat;

                    // logging
                    _logger.Debug("monat finished");
                    break;

                case 3:
                    // Übersicht

                    // logging
                    _logger.Debug("übersicht start");

                    ActiveSQLQuery = null;

                    // udpate fields (with end of current month)
                    UpdateUebersichtFields(null);

                    // logging
                    _logger.Debug("übersicht finished");
                    break;
            }

            // logging
            _logger.Debug("done");
        }

        private void tabZeiterfassung_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // check if not switching to an empty tab
            if (!_isSwitchingToEmptyTab)
            {
                e.Cancel = !SavePendingChanges();
            }

            // logging
            _logger.Debug(String.Format("e.Cancel={0}", e.Cancel));
            _logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static DateTime GetLastDayOfMonth(DateTime? date, Boolean takeCurrentMonth)
        {
            // validate
            if (!date.HasValue || takeCurrentMonth)
            {
                // get current date
                date = DateTime.Today;
            }

            // get first day of month
            date = new DateTime(date.Value.Year, date.Value.Month, 1);

            // add one month
            date = date.Value.AddMonths(1);

            // return first day of next month - 1 day = last day of current month
            return date.Value.AddDays(-1);
        }

        #endregion

        #region Public Methods

        public override object GetContextValue(String fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "SELECTEDUSERID":
                    return _userID;						// current selected user of which data is displayed

                case "LANGUAGECODE":
                    return Session.User.LanguageCode;

                case "OVERVIEWMONTH":
                    return edtUebersichtMonat.EditValue;	// current month of tpg "übersicht"
            }

            return base.GetContextValue(fieldName);
        }

        public override void OnSearch()
        {
            try
            {
                NewSearch();
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Containing all necessary parameters as key/value pairs</param>
        /// <returns>True, if successfully handles message or nothing done, false if something went wrong</returns>
        public override Boolean ReceiveMessage(HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as String)
            {
                case "SelectUser":
                    // select the user in dropdown (if possible)
                    if (!DBUtil.IsEmpty(param["UserID"]))
                    {
                        // reset filter to apply proper value
                        if (!DBUtil.IsEmpty(edtAngezeigterMAFilter.EditValue))
                        {
                            // user had gui open with filter active, reset filter and reload list
                            edtAngezeigterMAFilter.EditValue = null;

                            // reload list
                            btnAngezeigterMAFilter_Click(null, EventArgs.Empty);
                        }

                        // apply value (switching is done in editvaluechanged...)
                        edtAngezeigterMitarbeiter.EditValue = Convert.ToInt32(param["UserID"]);

                        // do it first
                        ApplicationFacade.DoEvents();

                        // check tabname and is value the correct type
                        if (!DBUtil.IsEmpty(param["TabName"]) && param["TabName"] is string)
                        {
                            // try select tabpage and return success status
                            return SelectTabPageByName(Convert.ToString(param["TabName"]));
                        }

                        // if we are here, everything is ok (tabpage not changed)
                        return true;
                    }

                    // invalid userid
                    return false;
            }

            // did not understand message
            return false;
        }

        #endregion

        #region Protected Methods

        protected virtual void NewSearch()
        {
            // only if tpgErfassung is selected
            if (!tabZeiterfassung.IsTabSelected(tpgErfassung))
            {
                return;
            }

            if (!tabErfassung.IsTabSelected(tpgErfassungListe))
            {
                // apply search
                DoSearch();
            }
            else
            {
                // start new search
                if (qryData.Post())
                {
                    // switch to "Suche"
                    tabErfassung.SelectTab(tpgErfassungSuche);

                    // erase editvalues of controls and set focus
                    foreach (Control c in UtilsGui.AllControls(tpgErfassungSuche))
                    {
                        if (c is BaseEdit)
                        {
                            ((BaseEdit)c).EditValue = null;
                        }
                    }

                    // reset Klient
                    edtSucheKlient.EditValue = null;
                    edtSucheKlient.LookupID = null;

                    // reset Leistungsart
                    edtSucheLeistungsart.EditValue = null;
                    edtSucheLeistungsart.LookupID = null;

                    // set focus
                    edtSucheDatumVon.Focus();
                }
            }
        }

        #endregion

        #region Private Methods

        private void ApplyDurationTime(Double factor)
        {
            if (_workTimePerDay > 0 && edtErfassungStunden.EditMode == EditModeType.Normal && edtErfassungMinuten.EditMode == EditModeType.Normal)
            {
                // 100% = 4h 15min --> 80% = ... etc. (use already implemented functionality for calculation of hours and minutes)
                edtErfassungStunden.EditValue = _workTimePerDay * factor;
                edtErfassungStunden_Leave(this, EventArgs.Empty);
            }
        }

        private void CalcAndUpdateDayFields()
        {
            // init vars
            Double tagessaldo = 0.0;
            Double zeitrechnertotal = -1.0;

            // check if we have data
            if (qryData.Count > 0 && !DBUtil.IsEmpty(qryData["Datum"]))
            {
                // Tagessaldo (erfasst als Leistung) (1=Gleitzeitsaldo; 2=Gleitzeitkorrektur; 3=Feriensaldo, 4=Ferienkorrektur)
                tagessaldo = Convert.ToDouble(DBUtil.ExecuteScalarSQL(@"
                        DECLARE @sum MONEY

                        SELECT @sum = SUM(LEI.Dauer)
                        FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                          INNER JOIN dbo.BDELeistungsart ART WITH (READUNCOMMITTED) ON ART.BDELeistungsartID = LEI.BDELeistungsartID AND
                                                                                       ART.LeistungsartTypCode IN (1, 3)
                        WHERE LEI.UserID = {0} AND
                              LEI.Datum = {1}

                        SELECT ISNULL(@sum, 0.0)", _userID, qryData["Datum"]));

                // Zeitrechnertotal
                zeitrechnertotal = Convert.ToDouble(DBUtil.ExecuteScalarSQL(@"
                        DECLARE @sum MONEY

                        SELECT @sum = SUM(DATEDIFF(SECOND, ZeitVon ,ZeitBis))
                        FROM dbo.BDEZeitrechner WITH (READUNCOMMITTED)
                        WHERE ZeitBis IS NOT NULL AND
                              UserID = {0} AND
                              Datum = {1}

                        SELECT ISNULL(@sum / 3600, -1.0)", _userID, qryData["Datum"]));
            }

            // update lables
            lblErfassungTagesIst.Text = ConvertDurationToTimeString(tagessaldo, false);
            lblErfassungZeitrechnerTotal.Text = ConvertDurationToTimeString(zeitrechnertotal, false);
            lblErfassungDifferenz.Text = ConvertDurationToTimeString(zeitrechnertotal - tagessaldo, false);

            // show hide labels depending on existing values
            lblErfassungTagesIstC.Visible = true; //tagessaldo > -1;
            lblErfassungTagesIst.Visible = lblErfassungTagesIstC.Visible;

            lblErfassungZeitrechnerTotalC.Visible = zeitrechnertotal > 0;
            lblErfassungZeitrechnerTotal.Visible = lblErfassungZeitrechnerTotalC.Visible;

            panErfassungLineDifferenz.Visible = lblErfassungTagesIstC.Visible;

            lblErfassungDifferenzC.Visible = lblErfassungZeitrechnerTotalC.Visible && lblErfassungTagesIstC.Visible;
            lblErfassungDifferenz.Visible = lblErfassungDifferenzC.Visible;

            // check times and show info error
            /*
            24h limit on Erfassung is no more needed
            if (tagessaldo > 24.0 && !this.isLoading)
            {
                KissMsg.ShowInfo(CLASSNAME, "InvalidTagessaldoSum", "Das Tages-Ist ist grösser als 24h, bitte überprüfen Sie die Eingaben.");
            }
            */
            if (zeitrechnertotal > 24.0 && !_isLoading)
            {
                KissMsg.ShowInfo(CLASSNAME, "InvalidZeitrechnerSum", "Das Zeitrechner-Total ist grösser als 24h, bitte überprüfen Sie die Eingaben.");
            }
        }

        private bool CheckKeinExport()
        {
            var user = DBUtil.OpenSQL(@"
                SELECT KeinBDEExport,
                       LohntypCode
                FROM dbo.XUser WITH(READUNCOMMITTED)
                WHERE UserID = {0};", _userID);

            var keinExport = (bool)user[DBO.XUser.KeinBDEExport];
            var lohnTyp = Utils.ConvertToInt(user[DBO.XUser.LohntypCode]);

            if (!DBUtil.IsEmpty(user))
            {
                if (keinExport && lohnTyp == 2)
                {
                    return true;
                }

                return keinExport;
            }

            return false;
        }

        private String ConvertDurationToTimeString(Double duration, Boolean negativIsInvalid)
        {
            // check if negative
            Boolean isNegative = duration < 0;

            // validate
            if (negativIsInvalid && isNegative)
            {
                // invalid or unknown
                return "?:??";
            }

            if (isNegative)
            {
                // invert due to calculation
                duration = -duration;
            }

            // get hours and minutes from decimal duration
            Int32 hours = Convert.ToInt32(Math.Floor(duration));
            Int32 minutes = Convert.ToInt32(Math.Round((duration - Math.Floor(duration)) * 60, 0));

            // correct e.g. 2h 60min to 3h 0min
            if (minutes == 60)
            {
                // 60min = 1h
                minutes = 0;
                hours++;
            }

            // convert hours minutes to good format
            return String.Format("{0}{1:##0}:{2:00}", isNegative ? "-" : "", hours, minutes);
        }

        private bool DialogKlient(KissButtonEdit edt, UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if ((edt.DataSource != null && !qryData.CanUpdate) || edt.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        if (edt == edtErfassungKlient)
                        {
                            // Klient
                            qryData["BaPersonID"] = DBNull.Value;
                            qryData["Klient"] = DBNull.Value;
                            return true;
                        }

                        if (edt == edtSucheKlient)
                        {
                            // Klient Suche
                            edt.EditValue = null;
                            edt.LookupID = null;
                        }
                        else
                        {
                            // unknown
                            return false;
                        }
                    }
                }

                var dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(string.Format(@"
                    SELECT *
                    FROM dbo.fnBDESucheKlientZeiterfassung({0}, {2}, '{1}') FCN
                    WHERE FCN.Name LIKE '{1}%'", _userID, searchString, Session.User.LanguageCode),
                                           searchString,
                                           e.ButtonClicked,
                                           null,
                                           null,
                                           null);

                if (!e.Cancel)
                {
                    // apply new value
                    if (edt == edtErfassungKlient)
                    {
                        // Klient
                        qryData["BaPersonID"] = dlg["BaPersonID$"];
                        qryData["Klient"] = dlg["Name"];

                        // reset flags
                        _hasKlientChanged = false;
                    }
                    else if (edt == edtSucheKlient)
                    {
                        // Klient Suche  (first EditValue, then LookupID!)
                        edt.EditValue = dlg["Name"];
                        edt.LookupID = dlg["BaPersonID$"];
                    }
                    else
                    {
                        // invalid control
                        return false;
                    }

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorDialogKlient_v01", "Es ist ein Fehler in der Verarbeitung auftetreten.", ex);
                return false;
            }
        }

        private bool DialogLeistungsart(KissButtonEdit edt, UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if ((edt.DataSource != null && !qryData.CanUpdate) || edt.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                String searchString = "";

                // set compared Klient edit
                KissButtonEdit edtKlient;

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        if (edt == edtErfassungLeistungsart)
                        {
                            // Leistungsart (null values)
                            qryData["IstKlientZwingend"] = 1;
                            qryData["IstKlientOptional"] = 0;
                            qryData["IstAnzahlZwingend"] = 1;
                            qryData["IstAnzahlOptional"] = 0;
                            qryData["BDELeistungsartID"] = DBNull.Value;
                            qryData["BDELeistungsart"] = DBNull.Value;
                            qryData["LeistungsartTypCode"] = DBNull.Value;
                            return true;
                        }

                        if (edt == edtSucheLeistungsart)
                        {
                            // Leistungsart Suche
                            edt.EditValue = null;
                            edt.LookupID = null;
                            return true;
                        }

                        // invalid control
                        return false;
                    }
                }

                // setup edit to compare
                if (edt == edtErfassungLeistungsart)
                {
                    // Leistungsart
                    edtKlient = edtErfassungKlient;
                }
                else if (edt == edtSucheLeistungsart)
                {
                    // Leistungsart Suche
                    edtKlient = edtSucheKlient;
                }
                else
                {
                    // invalid control
                    return false;
                }

                var dlg = new KissLookupDialog();
                e.Cancel = !dlg.SearchData(GetAvailableLaSql(edtKlient.EditValue, searchString), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // apply new value
                    if (edt == edtErfassungLeistungsart)
                    {
                        // Leistungsart
                        qryData["IstKlientZwingend"] = dlg["IstKlientZwingend$"];
                        qryData["IstKlientOptional"] = dlg["IstKlientOptional$"];
                        qryData["IstAnzahlZwingend"] = dlg["IstAnzahlZwingend$"];
                        qryData["IstAnzahlOptional"] = dlg["IstAnzahlOptional$"];
                        qryData["BDELeistungsartID"] = dlg["Code$"];
                        qryData["BDELeistungsart"] = dlg["Bezeichnung"];
                        qryData["LeistungsartTypCode"] = dlg["LeistungsartTypCode$"];

                        // reset flags
                        _hasLeistungsartChanged = false;
                    }
                    else if (edt == edtSucheLeistungsart)
                    {
                        // Leistungsart Suche (first EditValue, then LookupID!)
                        edt.EditValue = dlg["Bezeichnung"];
                        edt.LookupID = dlg["Code$"];
                    }
                    else
                    {
                        // invalid control
                        return false;
                    }

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSNAME, "ErrorDialogLeistungsart_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        private void DoSearch()
        {
            // check if we are searching already
            if (_isDoingSearch)
            {
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _isDoingSearch = true;

                String sql = _sqlBody;

                // Datum
                if (!DBUtil.IsEmpty(edtSucheDatumVon.EditValue))
                {
                    sql += " AND LEI.Datum >= " + DBUtil.SqlLiteral(edtSucheDatumVon.DateTime);
                }
                if (!DBUtil.IsEmpty(edtSucheDatumBis.EditValue))
                {
                    sql += " AND LEI.Datum <= " + DBUtil.SqlLiteral(edtSucheDatumBis.DateTime);
                }

                // Klient
                if (!DBUtil.IsEmpty(edtSucheKlient.EditValue))
                {
                    sql += " AND LEI.BaPersonID = " + DBUtil.SqlLiteral(edtSucheKlient.LookupID);
                }

                // Leistungsart
                if (!DBUtil.IsEmpty(edtSucheLeistungsart.LookupID))
                {
                    sql += " AND LEI.BDELeistungsartID = " + DBUtil.SqlLiteral(edtSucheLeistungsart.LookupID);
                }

                // Bemerkung
                if (edtSucheBemerkung.Text != "")
                {
                    sql += " AND LEI.Bemerkung LIKE " + DBUtil.SqlLiteral("%" + edtSucheBemerkung.Text.Replace("*", "%") + "%");
                }

                // Verbucht
                if (!chkSucheVerbucht.Checked)
                {
                    sql += " AND LEI.Verbucht IS NULL";
                }

                qryData.Fill(sql + " ORDER BY LEI.Datum", _userID, Session.User.LanguageCode);
                qryData.Last();

                tabErfassung.SelectTab(tpgErfassungListe);
            }
            finally
            {
                // done searching
                _isDoingSearch = false;

                Cursor.Current = Cursors.Default;
            }
        }

        private void FillDataAndInit()
        {
            _isAdmin = HasUserAdminRights();

            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("userid='{0}', HasUserAdminRights()='{1}'", _userID, _isAdmin);

            // SEARCH SQL:
            // prepare sql-string for DoSearch for Erfassung
            _sqlBody = @"
                    DECLARE @UserID INT
                    DECLARE @LanguageCode INT

                    SET @UserID = {0}
                    SET @LanguageCode = {1}

                    SELECT LEI.*,
                           BDELeistungsart     = dbo.fnGetMLTextByDefault(LAR.BezeichnungTID, @LanguageCode, LAR.Bezeichnung),
                           LeistungsartTypCode = LAR.LeistungsartTypCode,
                           IstKlientZwingend   = CASE WHEN LAR.KlientErfassungCode = 3 THEN 1 ELSE 0 END,
                           IstKlientOptional   = CASE WHEN LAR.KlientErfassungCode = 2 THEN 1 ELSE 0 END,
                           IstAnzahlZwingend   = CASE WHEN LAR.AnzahlCode = 3 THEN 1 ELSE 0 END,
                           IstAnzahlOptional   = CASE WHEN LAR.AnzahlCode = 2 THEN 1 ELSE 0 END,
                           StdMin              = dbo.fnBDEConvertMoneyToHHMM(LEI.Dauer, 'hh:mm'),
                           Stunden             = dbo.fnBDEConvertMoneyToHHMM(LEI.Dauer, 'hours'),
                           Minuten             = dbo.fnBDEConvertMoneyToHHMM(LEI.Dauer, 'minutes'),
                           Klient              = ISNULL(PRS.Name + ', ', '') + PRS.Vorname,
                           WT                  = dbo.fnBDEGetWeekDayFromDate(Datum, @LanguageCode),
                           KostenstelleName    = ORG.ItemName + ISNULL(' (' + CONVERT(VARCHAR(50), ORG.Kostenstelle) + ')',  ''),
                           Lohnart             = dbo.fnBDEGetLohnartText(LEI.UserID, LEI.Datum, LEI.LohnartCode, @LanguageCode)
                    FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                      LEFT  JOIN dbo.XOrgUnit        ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = LEI.KostenstelleOrgUnitID
                      INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = LEI.BDELeistungsartID
                      LEFT  JOIN dbo.BaPerson        PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                    WHERE UserID = @UserID";

            // TABS AND NEW SEARCH:
            // select the desired tabs and run new search on startup or if Erfassung is selected
            if (_isLoading || tabZeiterfassung.IsTabSelected(tpgErfassung))
            {
                tabZeiterfassung.SelectTab(tpgErfassung);
                NewSearch();
                tabErfassung.SelectTab(tpgErfassungListe); // simulate DoSearch()

                // logging
                _logger.Debug("NewSearch() called");
            }

            // Kein Export
            lblKeinExport.Visible = !_isAdmin;
            edtKeinExport.Visible = _isAdmin;
            btnKeinExportUmschalten.Visible = _isAdmin;
            edtFakturiert.EditMode = _isAdmin ? EditModeType.Normal : EditModeType.ReadOnly;

            // WORKTIME PER DAY:
            // get worktime per day of current user
            _workTimePerDay = Convert.ToDouble(DBUtil.ExecuteScalarSQL(@"SELECT dbo.fnBDEGetSollProTag({0}, GETDATE())", _userID));

            // setup controls first depending on value
            btnErfassungTag05.Enabled = _workTimePerDay > 0;
            btnErfassungTag1.Enabled = _workTimePerDay > 0;
            lblTagessoll.Text = ConvertDurationToTimeString(_workTimePerDay, true);

            // show error if invalid
            if (_workTimePerDay < 0.0)
            {
                KissMsg.ShowInfo(CLASSNAME, "InvalidWorkingTimePerDayInfo", "Das Tages-Soll konnte nicht ermittelt werden. Einige Funktionalitäten stehen deshalb nicht zur Verfügung.");
            }

            // CHIEF OR REPRESENTATIVE
            _isChiefOrRepresentative = _isAdmin || Convert.ToBoolean(DBUtil.ExecuteScalarSQL(@"
                    DECLARE @isChief INT

                    SELECT @isChief = OrgUnitID
                    FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                    WHERE (ChiefID = {0} OR RepresentativeID = {0}) AND
                          OrgUnitID = dbo.fnOrgUnitOfUser({1}, 1)

                    SET @isChief = ISNULL(@isChief, 0)

                    IF(@isChief > 1)
                    BEGIN
                      SET @isChief = 1
                    END

                    SELECT @isChief", Session.User.UserID, _userID));

            // logging
            _logger.Debug(String.Format("isChiefOrRepresentative={0}", _isChiefOrRepresentative));

            // KOSTENSTELLE
            // init control
            edtErfassungKostenstelle.Properties.DataSource = null;

            // get KS orgunits
            SqlQuery qryKs = GetAvailableKsQuery();

            // setup edtErfassungKostenstelle
            edtErfassungKostenstelle.Properties.DropDownRows = Math.Min(qryKs.Count, 7);
            edtErfassungKostenstelle.Properties.DataSource = qryKs;

            // logging
            _logger.DebugFormat("Kostenstelle: qryKS.Count='{0}'", qryKs.Count);

            // get current user's member orgunit
            _userMemberOrgUnitID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT ISNULL(dbo.fnOrgUnitOfUser({0}, 1), -1)", _userID));

            // LOHNART
            // init control
            edtErfassungLohnart.Properties.DataSource = null;

            // get lohnart values
            qryLohnArt.Fill(_userID, Session.User.LanguageCode);

            // setup control
            edtErfassungLohnart.Properties.DropDownRows = Math.Min(qryLohnArt.Count, 7);
            edtErfassungLohnart.Properties.DataSource = qryLohnArt;

            // logging
            _logger.Debug(String.Format("Lohnart: qryLA.Count={0}", qryLohnArt.Count));

            // LOHNTYP
            _hasUserMonatslohn = Convert.ToBoolean(DBUtil.ExecuteScalarSQL(@"
                    DECLARE @HasMonatslohn BIT

                    SELECT @HasMonatslohn = CASE WHEN LohntypCode = 1 THEN 1  -- monatslohn
                                                 ELSE 0                       -- NULL or stundenlohn
                                            END
                    FROM dbo.XUser WITH (READUNCOMMITTED)
                    WHERE UserID = {0}

                    SELECT ISNULL(@HasMonatslohn, 0)", _userID));

            // logging
            _logger.DebugFormat("hasUserMonatslohn={0}", _hasUserMonatslohn);

            // FINISH
            // logging
            _logger.Debug("call qryData_PositionChanged(...)");

            // manually refresh enabled of fields (do this anyway)
            qryData_PositionChanged(this, EventArgs.Empty);

            // reset flags
            _hasKlientChanged = false;
            _hasLeistungsartChanged = false;

            // load data for specific tab if not Erfassung (this is already done above)
            if (!tabZeiterfassung.IsTabSelected(tpgErfassung))
            {
                // not Erfassung, simulate change
                tabZeiterfassung_SelectedTabChanged(tabZeiterfassung.SelectedTab);
            }

            // logging
            _logger.DebugFormat("finishing with current userid={0}", _userID);
            _logger.Debug("done");
        }

        private SqlQuery GetAvailableKsQuery()
        {
            // get all available KS orgunits for current user
            return DBUtil.OpenSQL(@"
                    SELECT *
                    FROM dbo.fnBDEGetOEOrgUnitListZLE({0}, 0, 'OrgUnitKS', 'Kostenstelle')", _userID);
        }

        private string GetAvailableLaSql(object selectedBaPersonID, string searchString)
        {
            // create sql-statme
            return string.Format(@"
                SELECT DISTINCT
                       Bezeichnung          = dbo.fnGetMLTextByDefault(LEI.BezeichnungTID, {3}, LEI.Bezeichnung),
                       Gruppe               = dbo.fnGetMLTextByDefault(GRP.UserGroupNameTID, {3}, GRP.UserGroupName),
                       Code$                = LEI.BDELeistungsartID,
                       IstKlientZwingend$   = CASE WHEN LEI.KlientErfassungCode = 3 THEN 1 ELSE 0 END,
                       IstKlientOptional$   = CASE WHEN LEI.KlientErfassungCode = 2 THEN 1 ELSE 0 END,
                       IstAnzahlZwingend$   = CASE WHEN LEI.AnzahlCode = 3 THEN 1 ELSE 0 END,
                       IstAnzahlOptional$   = CASE WHEN LEI.AnzahlCode = 2 THEN 1 ELSE 0 END,
                       LeistungsartTypCode$ = LEI.LeistungsartTypCode,
                       SortKey$             = LEI.SortKey,
                       SortSortKey$         = CASE
                                                WHEN LEI.SortKey IS NOT NULL THEN 0
                                                ELSE 1
                                              END
                FROM dbo.BDELeistungsart LEI WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BDEUserGroup_BDELeistungsart UGL WITH (READUNCOMMITTED) ON UGL.BDELeistungsartID = LEI.BDELeistungsartID
                  INNER JOIN dbo.XUser_BDEUserGroup           UGR WITH (READUNCOMMITTED) ON UGR.BDEUserGroupID = UGL.BDEUserGroupID
                  INNER JOIN dbo.BDEUserGroup                 GRP WITH (READUNCOMMITTED) ON GRP.BDEUserGroupID = UGR.BDEUserGroupID
                WHERE LEI.DatumVon <= GETDATE() AND
                      ISNULL(LEI.DatumBis, GETDATE()) >= GETDATE() AND
                      (ISNULL({0}, '+++') = '+++' OR (LEI.KlientErfassungCode = 3 OR LEI.KlientErfassungCode = 2)) AND
                      (dbo.fnGetMLTextByDefault(LEI.BezeichnungTID, {3}, LEI.Bezeichnung) LIKE '{2}%' OR
                       dbo.fnGetMLTextByDefault(GRP.UserGroupNameTID, {3}, GRP.UserGroupName) LIKE '{2}%') AND
                      UGR.UserID = {1}
                ORDER BY SortSortKey$ ASC, SortKey$ ASC, Bezeichnung ASC",
                DBUtil.IsEmpty(selectedBaPersonID) ? "NULL" : "N'withClient'",
                _userID,
                searchString,
                Session.User.LanguageCode);
        }

        private void HandleButtonsFreigabeVisum()
        {
            // vars
            var isFreigegeben = false;
            var isVisiert = false;
            var isVerbucht = false;
            var isFakturiert = false;
            var hasData = false;

            // validate
            if (qryMonat.Count > 0)
            {
                hasData = true;

                // get "Freigegeben" and "Visieren" and "Verbucht"
                isFreigegeben = Convert.ToBoolean(qryMonat["Freigegeben"]);
                isVisiert = Convert.ToBoolean(qryMonat["Visiert"]);
                isVerbucht = Convert.ToBoolean(qryMonat["IstVerbucht"]);
                isFakturiert = Convert.ToBoolean(qryMonat["Fakturiert"]);
            }

            // setup buttons
            btnMonatFreigeben.Enabled = !isFreigegeben && !isVisiert && !isVerbucht;
            btnMonatFreigabeAufheben.Enabled = isFreigegeben && !isVisiert && !isVerbucht;
            btnMonatVisieren.Enabled = _isChiefOrRepresentative && isFreigegeben && !isVisiert;
            btnMonatVisumAufheben.Enabled = _isChiefOrRepresentative && isVisiert && !isVerbucht;
            btnMonatFakturiertSetzen.Enabled = hasData && _isAdmin && !isFakturiert;
            btnMonatFakturiertEntfernen.Enabled = hasData && _isAdmin && isFakturiert;
        }

        private void HandleErfassenUpdateAllowed()
        {
            // check if we have any data
            if (qryData.Count > 0)
            {
                // manually refresh state on edtErfassenLeistungsart
                edtErfassungLeistungsart_EditValueChanged(this, EventArgs.Empty);

                // can update
                bool bitCanUpdate = !Convert.ToBoolean(qryData["Freigegeben"]) || (_isChiefOrRepresentative && !Convert.ToBoolean(qryData["Visiert"]));

                qryData.CanUpdate = bitCanUpdate || _isAdmin;
                qryData.CanDelete = bitCanUpdate;

                edtErfassungDatum.EditMode = bitCanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
                edtErfassungKlient.EditMode = bitCanUpdate ? edtErfassungKlient.EditMode : EditModeType.ReadOnly;	// keep, handled in other method
                edtErfassungLeistungsart.EditMode = bitCanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
                edtErfassungAnzahl.EditMode = bitCanUpdate ? edtErfassungAnzahl.EditMode : EditModeType.ReadOnly;	// keep, handled in other method
                edtErfassungStunden.EditMode = bitCanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
                edtErfassungMinuten.EditMode = bitCanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
                edtErfassungKostenstelle.EditMode = bitCanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
                edtErfassungLohnart.EditMode = bitCanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
                memErfassungBemerkungen.EditMode = bitCanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
                btnErfassungTag05.Enabled = bitCanUpdate && _workTimePerDay > 0;
                btnErfassungTag1.Enabled = bitCanUpdate && _workTimePerDay > 0;
                edtKeinExport.EditMode = bitCanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;

                edtFakturiert.EditMode = _isAdmin ? EditModeType.Normal : EditModeType.ReadOnly;
            }
        }

        /// <summary>
        /// Check if user has administrator rights for CRUD
        /// </summary>
        /// <returns><c>True</c> if user has administrator rights, otherwise <c>False</c></returns>
        private bool HasUserAdminRights()
        {
            // user has admin right either if he is real admin or has special right
            return Session.User.IsUserAdmin || _specialRightAsIfAdmin;
        }

        private void InitAndSetKostentraegerDropDown()
        {
            InitKostentraegerDropDown();
            if (!((SqlQuery)edtErfassungKostentraeger.Properties.DataSource).IsEmpty)
            {
                var editMode = edtErfassungKostentraeger.EditMode;
                edtErfassungKostentraeger.EditMode = EditModeType.Normal;
                edtErfassungKostentraeger.EditValue = DBNull.Value;
                edtErfassungKostentraeger.ItemIndex = 0;
                edtErfassungKostentraeger.EditMode = editMode;
                qryData[DBO.BDELeistung.HistKostentraeger] = edtErfassungKostentraeger.EditValue;
            }
        }

        private void InitKostentraegerDropDown()
        {
            edtErfassungKostentraeger.Properties.DataSource = null;
            var datum = Convert.ToDateTime(qryData["Datum"]);
            var qryKtr = DBUtil.OpenSQL(@"
                SELECT Code = Kostentraeger, Text = Kostentraeger
                FROM dbo.fnBDEGetHistKostentraegerPerDate({0}, {1}, {2})
                WHERE Kostentraeger <> -1;", _userID, qryData[DBO.BDELeistung.BDELeistungsartID], datum);
            edtErfassungKostentraeger.Properties.DropDownRows = Math.Min(qryKtr.Count, 7);
            edtErfassungKostentraeger.Properties.DataSource = qryKtr;

            edtErfassungKostentraeger.EditMode = qryKtr.Count == 1 ? EditModeType.ReadOnly : EditModeType.Normal;

            if (qryKtr.IsEmpty && !DBUtil.IsEmpty(qryData[DBO.BDELeistung.BDELeistungsartID]))
            {
                KissMsg.ShowError(CLASSNAME, "NoKostentraegerAtGivenDate", "Das Datum '{0}' kann nicht verwendet werden, da zu diesem Zeitpunkt kein Kostenträger definiert ist.", null, null, 0, 0, datum.ToShortDateString());
            }
        }

        private bool IsDateAlreadyLocked(DateTime date)
        {
            // get current state if month used for Datum is Freigegeben or Visiert
            var qryFreigegebenVisiert = new SqlQuery();

            qryFreigegebenVisiert.Fill(@"
                    SELECT TOP 1 Freigegeben, Visiert
                    FROM dbo.BDELeistung WITH (READUNCOMMITTED)
                    WHERE YEAR(Datum) = YEAR({0}) AND
                          MONTH(Datum) = MONTH({0}) AND
                          UserID = {1}
                    ORDER BY Visiert DESC, Freigegeben DESC", date, _userID);

            // init vars
            bool isMonthFreigegeben = false;
            bool isMonthVisiert = false;

            // check query and set vars
            if (qryFreigegebenVisiert.Count > 0)
            {
                isMonthFreigegeben = Convert.ToBoolean(qryFreigegebenVisiert["Freigegeben"]);
                isMonthVisiert = Convert.ToBoolean(qryFreigegebenVisiert["Visiert"]);
            }

            // check if user can update data with this Datum
            if ((isMonthFreigegeben && !_isChiefOrRepresentative) || (isMonthFreigegeben && isMonthVisiert))
            {
                // no more changes on this month are allowed
                return true;
            }

            // date is allowed
            return false;
        }

        private bool SavePendingChanges()
        {
            if (ActiveSQLQuery != null)
            {
                return ActiveSQLQuery.Post();
            }

            // no problem if no query
            return true;
        }

        /// <summary>
        /// Select tabpage by name
        /// </summary>
        /// <param name="tabPageName">The name of the tabpage (tpg.Name)</param>
        /// <returns><c>True</c> if tabpage was selected correctly, otherwise <c>False</c></returns>
        private bool SelectTabPageByName(string tabPageName)
        {
            // validate
            if (string.IsNullOrEmpty(tabPageName))
            {
                // invalid name, cannot select
                return false;
            }

            // loop all tabpages and check name
            foreach (TabPageEx tab in tabZeiterfassung.TabPages)
            {
                if (tab.Name.Contains(tabPageName))
                {
                    // select tabpage
                    tabZeiterfassung.SelectTab(tab);

                    // success
                    return true;
                }
            }

            // failed to select tabpage, tabpagename not found
            return false;
        }

        private void SetResetMonthFakturiert(bool setFakturiertValue)
        {
            try
            {
                // init values
                bool continueAction;
                var monat = Convert.ToString(qryMonat["MonatText"]);
                var jahr = Convert.ToInt32(qryMonat["Jahr"]);

                if (setFakturiertValue)
                {
                    // confirm set visum
                    continueAction = KissMsg.ShowQuestion(CLASSNAME, "BestaetigungMonatFakturieren", "Wollen Sie den gewählten Monat '{0} {1}' als fakturiert markieren?", 0, 0, true, monat, jahr);
                }
                else
                {
                    // confirm remove visum
                    continueAction = KissMsg.ShowQuestion(CLASSNAME, "BestaetigungMonatFakturiertAufheben", "Wollen Sie für den gewählten Monat '{0} {1}' die Fakturierung aufheben?", 0, 0, true, monat, jahr);
                }

                // confirm execution
                if (continueAction)
                {
                    // create new history entry and update values
                    DBUtil.NewHistoryVersion();
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE dbo.BDELeistung
                        SET Fakturiert = {3}
                        WHERE UserID = {0}
                          AND Datum BETWEEN {1} AND {2}", _userID, qryMonat["MonatStartDatum"], qryMonat["MonatEndDatum"], setFakturiertValue);

                    // refresh query and do reposition (no primary key, cannot automatically)
                    qryMonat.Refresh();
                    qryMonat.Find(string.Format(@"Jahr = {0} AND MonatText = '{1}'", jahr, monat));
                }

                //DEBUG ONLY: DBUtil.ExecSQL(@"UPDATE BDELeistung SET Freigegeben = 0, Visiert = 0 WHERE USerID = 2");
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSNAME, "FehlerBeimFakturieren", "Fehler beim Fakturieren des gewählten Monats.", ex);
            }
        }

        private void SetResetMonthFreigabe(Boolean setFreigabeValue)
        {
            try
            {
                // init values
                Boolean continueAction;
                String monat = Convert.ToString(qryMonat["MonatText"]);
                Int32 jahr = Convert.ToInt32(qryMonat["Jahr"]);

                if (setFreigabeValue)
                {
                    // confirm set freigabe
                    continueAction = KissMsg.ShowQuestion(CLASSNAME, "BestaetigungMonatFreigeben", "Wollen Sie den gewählten Monat '{0} {1}' nun zum Visieren freigeben?", 0, 0, true, monat, jahr);
                }
                else
                {
                    // confirm remove freigabe
                    continueAction = KissMsg.ShowQuestion(CLASSNAME, "BestaetigungMonatFreigabeAufheben", "Wollen Sie für den gewählten Monat '{0} {1}' die Freigabe aufheben?", 0, 0, true, monat, jahr);
                }

                // confirm execution
                if (continueAction)
                {
                    // create new history entry and update values
                    DBUtil.NewHistoryVersion();
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE dbo.BDELeistung
                        SET Freigegeben = {3}
                        WHERE UserID = {0} AND
                              Datum BETWEEN {1} AND {2}", _userID, qryMonat["MonatStartDatum"], qryMonat["MonatEndDatum"], setFreigabeValue);

                    // refresh query and do reposition (no primary key, cannot automatically)
                    qryMonat.Refresh();
                    qryMonat.Find(String.Format(@"Jahr = {0} AND MonatText = '{1}'", jahr, monat));
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSNAME, "FehlerBeimFreigeben", "Fehler beim Freigeben des gewählten Monats.", ex);
            }
        }

        private void SetResetMonthVisum(Boolean setVisumValue)
        {
            try
            {
                // init values
                Boolean continueAction;
                String monat = Convert.ToString(qryMonat["MonatText"]);
                Int32 jahr = Convert.ToInt32(qryMonat["Jahr"]);

                if (setVisumValue)
                {
                    // confirm set visum
                    continueAction = KissMsg.ShowQuestion(CLASSNAME, "BestaetigungMonatVisieren", "Wollen Sie den gewählten Monat '{0} {1}' nun visieren?", 0, 0, true, monat, jahr);
                }
                else
                {
                    // confirm remove visum
                    continueAction = KissMsg.ShowQuestion(CLASSNAME, "BestaetigungMonatVisumAufheben", "Wollen Sie für den gewählten Monat '{0} {1}' das Visum aufheben?", 0, 0, true, monat, jahr);
                }

                // confirm execution
                if (continueAction)
                {
                    // create new history entry and update values
                    DBUtil.NewHistoryVersion();
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE dbo.BDELeistung
                        SET Visiert = {3}
                        WHERE UserID = {0} AND
                              Datum BETWEEN {1} AND {2}", _userID, qryMonat["MonatStartDatum"], qryMonat["MonatEndDatum"], setVisumValue);

                    // refresh query and do reposition (no primary key, cannot automatically)
                    qryMonat.Refresh();
                    qryMonat.Find(String.Format(@"Jahr = {0} AND MonatText = '{1}'", jahr, monat));
                }

                //DEBUG ONLY: DBUtil.ExecSQL(@"UPDATE BDELeistung SET Freigegeben = 0, Visiert = 0 WHERE USerID = 2");
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSNAME, "FehlerBeimVisieren", "Fehler beim Visieren des gewählten Monats.", ex);
            }
        }

        private void UpdateUebersichtFields(DateTime? monthToShow)
        {
            // check if month is valid
            if (!monthToShow.HasValue)
            {
                // set end of current month
                monthToShow = GetLastDayOfMonth(null, true);
            }
            else
            {
                // get last day of given month
                monthToShow = GetLastDayOfMonth(monthToShow, false);
            }

            // apply shown month
            edtUebersichtMonat.EditValue = monthToShow;

            // load new data for given month
            qryUebersicht.Fill(@"
                    SELECT *
                    FROM dbo.fnBDEGetUebersicht({0}, dbo.fnLastDayOf({1}), {2}, 0)", _userID, monthToShow, Session.User.LanguageCode); // for last day of given month!
            // query will always return a row (if valid parameters given)

            // setup year and month
            lblAktuellerMonat.Text = qryUebersicht["MonatJahrText"] as String;

            // setup labels
            UpdateUebersichtLabel(lblUebersichtBeschaeftigungsgrad, qryUebersicht["PensumProzent"], "%", false, false);
            UpdateUebersichtLabel(lblUebersichtSollProTag, qryUebersicht["SollArbeitszeitProTag"], _labelStd, true, false);

            UpdateUebersichtLabel(lblUebersichtGleitzeitIstArbeitszeit, qryUebersicht["GZIstArbeitszeitProMonat"], _labelStd, true, false);
            UpdateUebersichtLabel(lblUebersichtGleitzeitSollMonat, qryUebersicht["GZSollArbeitszeitProMonat"], _labelStd, true, false);
            UpdateUebersichtLabel(lblUebersichtGleitzeitMonatSaldo, qryUebersicht["GZMonatsSaldo"], _labelStd, true, true);
            UpdateUebersichtLabel(lblUebersichtGleitzeitUebertragJahr, qryUebersicht["GZUebertragVorjahr"], _labelStd, true, true);
            UpdateUebersichtLabel(lblUebersichtGleitzeitSaldoUebertragMonate, qryUebersicht["GZUebertragVormonate"], _labelStd, true, true);
            UpdateUebersichtLabel(lblUebersichtGleitzeitKorrekturen, qryUebersicht["GZKorrekturen"], _labelStd, true, true);
            UpdateUebersichtLabel(lblUebersichtGleitzeitBezUeberstunden, qryUebersicht["GZAusbezahlteUeberstunden"], _labelStd, true, true);
            UpdateUebersichtLabel(lblUebersichtGleitzeitSaldo, qryUebersicht["GZSaldo"], _labelStd, true, true);

            UpdateUebersichtLabel(lblUebersichtStundenlohnIstArbeitszeit, qryUebersicht["SLIstArbeitszeitProMonat"], _labelStd, true, true);

            UpdateUebersichtLabel(lblUebersichtFerienUebertrag, qryUebersicht["FerienUebertragVorjahr"], _labelStd, true, true);
            UpdateUebersichtLabel(lblUebersichtFerienAnspruch, qryUebersicht["FerienAnspruchProJahr"], _labelStd, true, true);
            UpdateUebersichtLabel(lblUebersichtFerienBezogen, qryUebersicht["FerienBisherBezogen"], _labelStd, true, true);
            UpdateUebersichtLabel(lblUebersichtFerienZugabenKuerzungen, qryUebersicht["FerienZugabenKuerzungen"], _labelStd, true, true);
            UpdateUebersichtLabel(lblUebersichtFerienKorrekturen, qryUebersicht["FerienKorrekturen"], _labelStd, true, true);
            UpdateUebersichtLabel(lblUebersichtFerienSaldo, qryUebersicht["FerienSaldo"], _labelStd, true, true);
        }

        private void UpdateUebersichtLabel(KissLabel lbl, Object dbValue, String appendix, Boolean showTwoCommaNulls, Boolean canBeNegative)
        {
            // vars
            String caption = "-";		// init caption with default value (unnkown state)
            Double fieldValue = 0.0;	// inti with zero value

            // validate first
            if (!DBUtil.IsEmpty(dbValue) && (canBeNegative || Convert.ToDouble(dbValue) >= 0))
            {
                // set field value
                fieldValue = Convert.ToDouble(dbValue);

                // value is ok, return proper formated string
                if (showTwoCommaNulls)
                {
                    caption = String.Format("{0:0.00} {1}", fieldValue, appendix);
                }
                else
                {
                    caption = String.Format("{0} {1}", Math.Round(fieldValue, 2), appendix);
                }
            }

            // apply caption
            lbl.Text = caption;

            // apply color if negative is possible
            if (canBeNegative && fieldValue < 0.0)
            {
                // negative values are red
                lbl.ForeColor = _negativeColor;
            }
            else
            {
                // field is black (default)
                lbl.ForeColor = _defaultForeColor;
            }
        }

        #endregion

        #endregion
    }
}