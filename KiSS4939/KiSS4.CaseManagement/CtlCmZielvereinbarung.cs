using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.CaseManagement
{
    /// <summary>
    /// Control, used for managing Zielvereinbarungen in Case Management
    /// </summary>
    public partial class CtlCmZielvereinbarung : KissUserControl
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _handlungszielText;
        private readonly string _massnahmeText;
        private readonly string _rahmenzielText;

        private int _faLeistungID = -1;
        private bool _isSelectingDropdown;
        private int _selectedTabChangingParentID = -1;
        private string _userFullName = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlCmZielvereinbarung"/> class.
        /// </summary>
        public CtlCmZielvereinbarung()
        {
            InitializeComponent();

            // logging
            _logger.Debug("enter");

            // request strings
            _rahmenzielText = KissMsg.GetMLMessage(Name, "RahmenzielText", "Rahmenziel");
            _handlungszielText = KissMsg.GetMLMessage(Name, "HandlungszielText", "Handlungsziel");
            _massnahmeText = KissMsg.GetMLMessage(Name, "MassnahmeText", "Massnahme");

            // init with default values
            Init(null, null, -1, false);

            // logging
            _logger.Debug("done");
        }

        public override object GetContextValue(string fieldName)
        {
            // logging
            _logger.Debug("call");

            switch (fieldName.ToUpper())
            {
                case "FACASEMANAGEMENTID":
                    // validate first
                    if (qryFaCaseManagementMain.IsEmpty)
                    {
                        return -1;
                    }

                    return qryFaCaseManagementMain["FaCaseManagementID"];

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "BAPERSONID":
                    // validate first
                    if (qryFaCaseManagementMain.IsEmpty)
                    {
                        return FaUtils.GetBaPersonIDFromFaLeistungID(_faLeistungID);
                    }

                    return qryFaCaseManagementMain["BaPersonID"];
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, bool isLeistungClosed)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("faLeistungID={0}, isLeistungClosed={1}", faLeistungID, isLeistungClosed);

            // validate
            if (faLeistungID < 1)
            {
                // logging
                _logger.Debug("no valid FaLeistungID, cancel");

                // do not continue
                qryFaCaseManagementMain.CanUpdate = false;

                // handle editmode of controls
                qryFaCaseManagementMain.EnableBoundFields(qryFaCaseManagementMain.CanUpdate);
                return;
            }

            // request userfullname
            _userFullName = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                SELECT dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL)
                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                WHERE LEI.FaLeistungID = {0}", faLeistungID));

            // allow changes
            qryFaCaseManagementMain.CanUpdate = !isLeistungClosed;

            // apply values
            _faLeistungID = faLeistungID;
            picTitel.Image = titleImage;

            // fill data
            qryFaCaseManagementMain.Fill(@"
                SELECT -- all columns from CM
                       CM.*,

                       -- additional columns
                       Lebensbereich = dbo.fnGetLOVMLText('FaLebensbereich', CM.LebensbereichCode, {1}),
                       BaPersonID    = LEI.BaPersonID,
                       ZustaendigSA  = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL)
                FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = CM.FaLeistungID
                WHERE CM.FaLeistungID = {0} AND IstHaupteintrag = 1", faLeistungID, Session.User.LanguageCode);

            // insert new entry if not yet any entry found
            if (qryFaCaseManagementMain.CanUpdate && qryFaCaseManagementMain.Count < 1)
            {
                qryFaCaseManagementMain.Insert(null);
            }

            // expand all nodes and focus first tpg
            tabZielvereinbarung.SelectedTabIndex = 0;

            // load data
            InitSubQuery(-1);

            // logging
            _logger.Debug("done");
        }

        public override bool OnAddData()
        {
            // logging
            _logger.Debug("enter");

            // tpg depending message if insert is not allowed
            if (tabZielvereinbarung.IsTabSelected(tpgUebersicht))
            {
                // show info and cancel
                KissMsg.ShowInfo(Name, "CannotInsertUebersicht", "Auf dem Register 'Übersicht' können keine Daten eingefügt werden.");
                return false;
            }
            else if (qryFaCaseManagementMain.CanUpdate && !qryFaCmSub.CanInsert)
            {
                // main-query-update is allowed but insert on sub-query is disabled, show info depending on current tpg
                if (tabZielvereinbarung.IsTabSelected(tpgHandlungsziele))
                {
                    // no rahmenziel selected, cannot insert
                    KissMsg.ShowInfo(Name, "CannotInsertHandlungsziel", "Es muss zuerst ein Rahmenziel ausgewählt werden, bevor ein neues Handlungsziel erfasst werden kann.");

                    // focus
                    edtHZRahmenziel.Focus();

                    // cancel
                    return false;
                }
                if (tabZielvereinbarung.IsTabSelected(tpgMassnahmen))
                {
                    // no rahmenziel selected, cannot insert
                    KissMsg.ShowInfo(Name, "CannotInsertMassnahme", "Es muss zuerst ein Handlungsziel ausgewählt werden, bevor eine neue Massnahme erfasst werden kann.");

                    // focus
                    edtMNHandlungsziel.Focus();

                    // cancel
                    return false;
                }
            }

            // logging
            _logger.Debug("done");

            // tab depending data
            return qryFaCmSub.Insert() != null;
        }

        public override bool OnDeleteData()
        {
            // logging
            _logger.Debug("enter");

            // logging
            _logger.Debug("done");

            // tab depending data
            return qryFaCmSub.Delete();
        }

        public override void OnMoveFirst()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qryFaCmSub.First();

            // logging
            _logger.Debug("done");
        }

        public override void OnMoveLast()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qryFaCmSub.Last();

            // logging
            _logger.Debug("done");
        }

        public override void OnMoveNext()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qryFaCmSub.Next();

            // logging
            _logger.Debug("done");
        }

        public override void OnMovePrevious()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qryFaCmSub.Previous();

            // logging
            _logger.Debug("done");
        }

        public override void OnRefreshData()
        {
            // logging
            _logger.Debug("enter");

            // global data
            ActiveSQLQuery.Refresh();

            // tab depending data
            qryFaCmSub.Refresh();

            // logging
            _logger.Debug("done");
        }

        public override bool OnSaveData()
        {
            // logging
            _logger.Debug("enter");

            // insert a new row if not saved and none available
            if (ActiveSQLQuery.CanUpdate && ActiveSQLQuery.Count < 1)
            {
                ActiveSQLQuery.Insert(null);
            }

            // check if sub query is changed
            if (qryFaCmSub.RowModified)
            {
                // save data on main query
                ActiveSQLQuery.RowModified = true;
            }

            var isAdded = ActiveSQLQuery.CurrentRowState == DataRowState.Added;

            // global data
            if (!ActiveSQLQuery.Post())
            {
                // insert a new row if not saved and none available
                if (ActiveSQLQuery.CanUpdate && ActiveSQLQuery.Count < 1)
                {
                    ActiveSQLQuery.Insert(null);
                }

                throw new KissCancelException();
            }

            // tab depending data
            var result = qryFaCmSub.Post();
            if (result && isAdded)
            {
                //sicherstellen, dass Spalten via JOIN geladen sind
                ActiveSQLQuery.Refresh();
            }

            // logging
            _logger.Debug("done");

            return result;
        }

        public override void OnUndoDataChanges()
        {
            // logging
            _logger.Debug("enter");

            // global data
            ActiveSQLQuery.Cancel();

            // tab depending data
            qryFaCmSub.Cancel();

            // logging
            _logger.Debug("done");
        }

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            treUebersicht.CollapseAll();
            treUebersicht.Focus();

            // logging
            _logger.Debug("done");
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            treUebersicht.ExpandAll();
            treUebersicht.Focus();

            // logging
            _logger.Debug("done");
        }

        private void btnHZNeueMassnahme_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // check if data can be saved
                if (!OnSaveData())
                {
                    // do nothing
                    return;
                }

                // get current id of Rahmenziel
                int rahmenzielID = Convert.ToInt32(qryFaCmSub["FaCaseManagementID"]);

                // switch tab
                tabZielvereinbarung.SelectedTabIndex = 3;

                // init data
                InitSubQuery(rahmenzielID);

                // add new data if not yet done
                if (qryFaCmSub.Row != null && qryFaCmSub.Row.RowState != DataRowState.Added && qryFaCmSub.CanInsert)
                {
                    // creat a new entry
                    OnAddData();
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorNewStep", "Fehler bei der Verarbeitung.", ex);
            }

            // logging
            _logger.Debug("done");
        }

        private void btnRZNeuesHZ_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // check if data can be saved
                if (!OnSaveData())
                {
                    // do nothing
                    return;
                }

                // get current id of Handlungsziel
                int handlungszielID = Convert.ToInt32(qryFaCmSub["FaCaseManagementID"]);

                // switch tab
                tabZielvereinbarung.SelectedTabIndex = 2;

                // init data
                InitSubQuery(handlungszielID);

                // add new data if not yet done
                // The result of the expression is always 'true' since a value of type 'System.Data.DataRowState' is never equal to 'null' of type 'System.Data.DataRowState?'
                if (qryFaCmSub.Row != null && qryFaCmSub.Row.RowState != DataRowState.Added && qryFaCmSub.CanInsert)
                {
                    // creat a new entry
                    OnAddData();
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorNewTarget", "Fehler bei der Verarbeitung.", ex);
            }

            // logging
            _logger.Debug("done");
        }

        private void btnUebersichtGeheZu_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // check if we have a focused node
                if (treUebersicht.FocusedNode == null || qryFaCmSub.Count < 1)
                {
                    // do nothing
                    return;
                }

                // define vars
                Int32 selectID = -1;
                Int32 elterID = -1;

                // check type
                if (Convert.ToBoolean(treUebersicht.FocusedNode.GetValue("IstRahmenziel")))
                {
                    // set vars
                    selectID = Convert.ToInt32(treUebersicht.FocusedNode.GetValue("FaCaseManagementID"));
                    elterID = 1;	// dummy value

                    // switch to Rahmenziele
                    tabZielvereinbarung.SelectedTabIndex = 1;
                }
                else if (Convert.ToBoolean(treUebersicht.FocusedNode.GetValue("IstHandlungsziel")))
                {
                    // set vars
                    selectID = Convert.ToInt32(treUebersicht.FocusedNode.GetValue("FaCaseManagementID"));
                    elterID = Convert.ToInt32(treUebersicht.FocusedNode.GetValue("ElterID"));

                    // switch to Handlungsziele
                    tabZielvereinbarung.SelectedTabIndex = 2;

                    // switch dropdown
                    edtHZRahmenziel.EditValue = elterID;
                }
                else if (Convert.ToBoolean(treUebersicht.FocusedNode.GetValue("IstMassnahme")))
                {
                    // set vars
                    selectID = Convert.ToInt32(treUebersicht.FocusedNode.GetValue("FaCaseManagementID"));
                    elterID = Convert.ToInt32(treUebersicht.FocusedNode.GetValue("ElterID"));

                    // switch to Handlungsziele
                    tabZielvereinbarung.SelectedTabIndex = 3;

                    // switch dropdown
                    edtMNHandlungsziel.EditValue = elterID;
                }

                // check if valid
                if (selectID < 0 || elterID < 0)
                {
                    throw new Exception("No ID found to select, display may be faulty.");
                }

                // search entry
                var entryFound = qryFaCmSub.Find(string.Format("FaCaseManagementID = {0}", selectID));

                // check if found
                if (!entryFound)
                {
                    throw new Exception("Entry not found, display may be faulty.");
                }
            }
            catch (Exception ex)
            {
                // show error msg
                KissMsg.ShowError(Name, "ErrorSelectingEntry", "Fehler beim Auswählen des Eintrags.", ex);
            }

            // logging
            _logger.Debug("done");
        }

        private void CtlCmZielvereinbarung_Load(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // expand all nodes and focus first tpg
            treUebersicht.ExpandAll();
            tabZielvereinbarung.SelectedTabIndex = 0;

            // logging
            _logger.Debug("done");
        }

        private void DropDownChanged(KissLookUpEdit edt)
        {
            // logging
            _logger.Debug("enter");

            // check if need to perform action
            if (_isSelectingDropdown)
            {
                // logging
                _logger.Debug("cancel, IsSelectingDropdown=true");

                // do nothing
                return;
            }

            // init var
            Int32 parentID = -1;

            // validate data
            if (!DBUtil.IsEmpty(edt.EditValue))
            {
                // get id
                parentID = Convert.ToInt32(edt.EditValue);
            }

            // load new data
            InitSubQuery(parentID);

            // logging
            _logger.Debug("done");
        }

        private void edtHZRahmenziel_EditValueChanged(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // refresh data if possible
            DropDownChanged(edtHZRahmenziel);

            // logging
            _logger.Debug("done");
        }

        private void edtMNHandlungsziel_EditValueChanged(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // refresh data if possible
            DropDownChanged(edtMNHandlungsziel);

            // logging
            _logger.Debug("done");
        }

        private Boolean InitBinding()
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // remove datasource on each bindable control on whole tabControl
                foreach (Control ctl in UtilsGui.AllControls(tabZielvereinbarung))
                {
                    // IKissBindableEdit-Controls
                    if (typeof(IKissBindableEdit).IsAssignableFrom(ctl.GetType()))
                    {
                        // remove databinding
                        ((IKissBindableEdit)ctl).DataSource = null;
                    }
                    else if (typeof(KissGrid).IsAssignableFrom(ctl.GetType()))
                    {
                        // remove databinding
                        ((KissGrid)ctl).DataSource = null;
                    }
                }

                // setup binding depending on selected tab
                if (tabZielvereinbarung.IsTabSelected())
                {
                    foreach (Control ctl in UtilsGui.AllControls(tabZielvereinbarung.SelectedTab))
                    {
                        // check if not dropdowns
                        if (ctl == edtHZRahmenziel || ctl == edtMNHandlungsziel)
                        {
                            // do not handle these controls
                            continue;
                        }

                        // IKissBindableEdit-Controls
                        if (typeof(IKissBindableEdit).IsAssignableFrom(ctl.GetType()) && !DBUtil.IsEmpty(((IKissBindableEdit)ctl).DataMember))
                        {
                            // setup databinding
                            ((IKissBindableEdit)ctl).DataSource = qryFaCmSub;
                        }
                        else if (typeof(KissGrid).IsAssignableFrom(ctl.GetType()))
                        {
                            // setup databinding
                            ((KissGrid)ctl).DataSource = qryFaCmSub;
                        }
                    }
                }
                else
                {
                    // no tab page
                    throw new Exception("No tab page, cannot show data!");
                }

                // update binding
                qryFaCmSub.BindControls();
                qryFaCmSub.RefreshDisplay();

                // logging
                _logger.Debug("done");

                // ok
                return true;
            }
            catch (Exception ex)
            {
                // show error msg
                KissMsg.ShowError(Name, "ErrorInInitBinding", "Fehler beim Zuweisen der Datenfelder.", "Error in InitBinding():", ex);

                // not successfully
                return false;
            }
        }

        private void InitSubQuery(int parentID)
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // setup flags
                _isSelectingDropdown = true;

                // validate first
                if (_faLeistungID < 1)
                {
                    throw new Exception("Invalid FaLeistungID, cannot proceed.");
                }

                // init binding
                if (!InitBinding())
                {
                    throw new Exception("Failure in InitBinding(), cannot proceed with data handling.");
                }

                // setup vars
                bool canInsert = false;
                bool goLast = false;

                // load query depending on selected tab
                if (tabZielvereinbarung.IsTabSelected(tpgUebersicht))
                {
                    // logging
                    _logger.Debug("tpgUebersicht");

                    // Übersicht:
                    qryFaCmSub.Fill(@"
                        SELECT -- all columns from CM
                               CM.*,

                               -- additional columns
                               Lebensbereich = dbo.fnGetLOVMLText('FaLebensbereich', CM.LebensbereichCode, {4}),
                               Element       = CASE WHEN CM.IstRahmenziel = 1 AND CM.IstHandlungsziel = 0 AND CM.IstMassnahme = 0 THEN {1}
                                                    WHEN CM.IstRahmenziel = 0 AND CM.IstHandlungsziel = 1 AND CM.IstMassnahme = 0 THEN {2}
                                                    WHEN CM.IstRahmenziel = 0 AND CM.IstHandlungsziel = 0 AND CM.IstMassnahme = 1 THEN {3}
                                                    ELSE '????'
                                               END
                        FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                        WHERE CM.FaLeistungID = {0} AND
                              CM.IstHaupteintrag = 0 AND
                              (CM.IstRahmenziel = 1 OR CM.IstHandlungsziel = 1 OR CM.IstMassnahme = 1)
                        ORDER BY CM.Datum", _faLeistungID, _rahmenzielText, _handlungszielText, _massnahmeText, Session.User.LanguageCode);

                    // show all entries
                    treUebersicht.ExpandAll();

                    // show newest entry
                    goLast = true;
                }
                else if (tabZielvereinbarung.IsTabSelected(tpgRahmenziele))
                {
                    // logging
                    _logger.Debug("tpgRahmenziele");

                    // Rahmenziele:
                    qryFaCmSub.Fill(@"
                        SELECT -- all columns from CM
                               CM.*,

                               -- additional columns
                               Lebensbereich = dbo.fnGetLOVMLText('FaLebensbereich', CM.LebensbereichCode, {1})
                        FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                        WHERE CM.FaLeistungID = {0} AND
                              CM.IstHaupteintrag = 0 AND
                              CM.IstRahmenziel = 1 AND
                              CM.IstHandlungsziel = 0 AND
                              CM.IstMassnahme = 0
                        ORDER BY CM.Datum", _faLeistungID, Session.User.LanguageCode);

                    // can change data and goto last entry
                    canInsert = true;
                    goLast = true;
                }
                else if (tabZielvereinbarung.IsTabSelected(tpgHandlungsziele))
                {
                    // logging
                    _logger.Debug("tpgHandlungsziele");

                    // get all Rahmenziele
                    SqlQuery qryRZ = DBUtil.OpenSQL(@"
                        SELECT Code = NULL,
                               Text = NULL

                        UNION ALL

                        SELECT Code = CM.FaCaseManagementID,
                               Text = CM.Text
                        FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                        WHERE CM.FaLeistungID = {0} AND
                              CM.IstHaupteintrag = 0 AND
                              CM.IstRahmenziel = 1 AND
                              CM.IstHandlungsziel = 0 AND
                              CM.IstMassnahme = 0
                        ORDER BY Text", _faLeistungID);

                    // fill dropdown of Rahmenziele
                    edtHZRahmenziel.LoadQuery(qryRZ);

                    // apply parent id
                    edtHZRahmenziel.EditValue = parentID;

                    // we need a parent id
                    if (parentID > 0)
                    {
                        // logging
                        _logger.Debug("tpgHandlungsziele - parentID > 0");

                        // Handlungsziele:
                        qryFaCmSub.Fill(@"
                            SELECT -- all columns from CM
                                   CM.*
                            FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                            WHERE CM.FaLeistungID = {0} AND
                                  CM.ElterID = {1} AND
                                  CM.IstHaupteintrag = 0 AND
                                  CM.IstRahmenziel = 0 AND
                                  CM.IstHandlungsziel = 1 AND
                                  CM.IstMassnahme = 0
                            ORDER BY CM.Datum", _faLeistungID, parentID);

                        // can change data and goto last entry
                        canInsert = true;
                        goLast = true;
                    }
                    else
                    {
                        // logging
                        _logger.Debug("tpgHandlungsziele - parentID < 1");

                        // NO Handlungsziele:
                        qryFaCmSub.Fill(@"
                            SELECT -- all columns from CM
                                   CM.*
                            FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                            WHERE 1=2");
                    }
                }
                else if (tabZielvereinbarung.IsTabSelected(tpgMassnahmen))
                {
                    // logging
                    _logger.Debug("tpgMassnahmen");

                    // get all Handlungsziele
                    SqlQuery qryHZ = DBUtil.OpenSQL(@"
                        SELECT Code    = NULL,
                               Text    = NULL,
                               ElterID = NULL

                        UNION ALL

                        SELECT Code    = CM.FaCaseManagementID,
                               Text    = CM.Text,
                               ElterID = CM.ElterID
                        FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                        WHERE CM.FaLeistungID = {0} AND
                              CM.IstHaupteintrag = 0 AND
                              CM.IstRahmenziel = 0 AND
                              CM.IstHandlungsziel = 1 AND
                              CM.IstMassnahme = 0
                        ORDER BY ElterID ASC, Text", _faLeistungID);

                    // fill dropdown of Handlungsziele
                    edtMNHandlungsziel.LoadQuery(qryHZ);

                    // apply parent id
                    edtMNHandlungsziel.EditValue = parentID;

                    // we need a parent id
                    if (parentID > 0)
                    {
                        // logging
                        _logger.Debug("tpgMassnahmen - parentID > 0");

                        // Massnahmen:
                        qryFaCmSub.Fill(@"
                            SELECT -- all columns from CM
                                   CM.*
                            FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                            WHERE CM.FaLeistungID = {0} AND
                                  CM.ElterID = {1} AND
                                  CM.IstHaupteintrag = 0 AND
                                  CM.IstRahmenziel = 0 AND
                                  CM.IstHandlungsziel = 0 AND
                                  CM.IstMassnahme = 1
                            ORDER BY CM.Datum", _faLeistungID, parentID);

                        // can change data and goto last entry
                        canInsert = true;
                        goLast = true;
                    }
                    else
                    {
                        // logging
                        _logger.Debug("tpgMassnahmen - parentID < 1");

                        // NO Massnahmen:
                        qryFaCmSub.Fill(@"
                            SELECT -- all columns from CM
                                   CM.*
                            FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                            WHERE 1=2");
                    }
                }
                else
                {
                    // invalid tab page
                    throw new Exception("Invalid tab page, cannot show data!");
                }

                // handle Can's
                qryFaCmSub.CanInsert = qryFaCaseManagementMain.CanUpdate && canInsert;
                qryFaCmSub.CanUpdate = qryFaCmSub.CanInsert;
                qryFaCmSub.CanDelete = qryFaCmSub.CanInsert;

                // insert new entry if not yet any entry found
                if (qryFaCmSub.CanInsert && qryFaCmSub.Count < 1)
                {
                    qryFaCmSub.Insert();
                }
                else
                {
                    // check if need to go to last entry
                    if (goLast)
                    {
                        // goto last entry
                        qryFaCmSub.Last();
                    }
                }

                // handle editmode of controls
                qryFaCmSub.EnableBoundFields(qryFaCmSub.CanUpdate);
            }
            catch (Exception ex)
            {
                // no data, init a new query with possible fields
                qryFaCmSub.Fill(@"
                    SELECT -- all columns from CM
                           CM.*,

                           -- additional columns
                           Lebensbereich = NULL,
                           Element       = NULL
                    FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                    WHERE 1=2");

                // invalid leistung id
                qryFaCmSub.CanInsert = false;
                qryFaCmSub.CanUpdate = false;
                qryFaCmSub.CanDelete = false;

                // handle editmode of controls
                qryFaCmSub.EnableBoundFields(qryFaCmSub.CanUpdate);

                // show error msg
                KissMsg.ShowError(Name, "ErrorInInitSubQuery", "Fehler beim Laden der zugehörigen Daten.", "Error in InitSubQuery(): ", ex);
            }
            finally
            {
                // reset flags
                _isSelectingDropdown = false;
            }

            // logging
            _logger.Debug("done");
        }

        private void qryFaCaseManagementMain_AfterInsert(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // apply leistung id
            qryFaCaseManagementMain["FaLeistungID"] = _faLeistungID;

            // is main entry
            qryFaCaseManagementMain["IstHaupteintrag"] = true;

            // apply default values
            qryFaCaseManagementMain["ZustaendigSA"] = _userFullName;
            qryFaCaseManagementMain["ErstellungZV"] = DateTime.Today;

            // creator of row (if changed)
            qryFaCaseManagementMain["Creator"] = DBUtil.GetDBRowCreatorModifier();

            // logging
            _logger.Debug("done");
        }

        private void qryFaCaseManagementMain_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // validate must fields
            DBUtil.CheckNotNullField(edtErstellungZV, lblErstellungZV.Text);

            // logging
            _logger.Debug("done");
        }

        private void qryFaCmSub_AfterInsert(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // insert values depending on current tab
            if (tabZielvereinbarung.IsTabSelected(tpgRahmenziele))
            {
                // Rahmenziel:
                qryFaCmSub["IstRahmenziel"] = true;

                // ElterID
                qryFaCmSub["ElterID"] = DBNull.Value;

                // Focus
                edtRZDatum.Focus();
            }
            else if (tabZielvereinbarung.IsTabSelected(tpgHandlungsziele))
            {
                // Handlungsziel:
                qryFaCmSub["IstHandlungsziel"] = true;

                // ElterID
                qryFaCmSub["ElterID"] = edtHZRahmenziel.EditValue;

                // Focus
                edtHZDatum.Focus();
            }
            else if (tabZielvereinbarung.IsTabSelected(tpgMassnahmen))
            {
                // Massnahme:
                qryFaCmSub["IstMassnahme"] = true;

                // ElterID
                qryFaCmSub["ElterID"] = edtMNHandlungsziel.EditValue;

                // Focus
                edtMNDatum.Focus();
            }
            else
            {
                // invalid tab page
                throw new KissCancelException();
            }

            // FaLeistungID
            qryFaCmSub["FaLeistungID"] = _faLeistungID;

            // Date
            qryFaCmSub["Datum"] = DateTime.Today;

            // creator of row (if changed)
            qryFaCmSub["Creator"] = DBUtil.GetDBRowCreatorModifier();

            // logging
            _logger.Debug("done");
        }

        private void qryFaCmSub_AfterPost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // apply display-only fields depending on current tab
            if (tabZielvereinbarung.IsTabSelected(tpgRahmenziele))
            {
                // apply lookup fields
                qryFaCmSub["Lebensbereich"] = edtRZLebensbereich.Text;
            }

            // logging
            _logger.Debug("done");
        }

        private void qryFaCmSub_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // ensure valid datas in main query
            qryFaCaseManagementMain_BeforePost(this, EventArgs.Empty);

            // insert values depending on current tab
            if (tabZielvereinbarung.IsTabSelected(tpgRahmenziele))
            {
                // On Rahmenziel, we do not have a ElterID
                qryFaCmSub["ElterID"] = DBNull.Value;
            }

            // check if we have a parentID (only if not Rahmenziel)
            if (!tabZielvereinbarung.IsTabSelected(tpgRahmenziele) && DBUtil.IsEmpty(qryFaCmSub["ElterID"]))
            {
                KissMsg.ShowError(Name, "NoParentIDSet", "Fehler bei der Datenverarbeitung. Es wurde keine Datenbeziehungs-ID gefunden.");
                throw new KissCancelException();
            }

            // validate must fields depending on current tab
            if (tabZielvereinbarung.IsTabSelected(tpgRahmenziele))
            {
                // Rahmenziel:
                DBUtil.CheckNotNullField(edtRZDatum, lblRZDatum.Text);
                DBUtil.CheckNotNullField(edtRZLebensbereich, lblRZLebensbereich.Text);
                DBUtil.CheckNotNullField(edtRZText, lblRZRahmenziel.Text);
            }
            else if (tabZielvereinbarung.IsTabSelected(tpgHandlungsziele))
            {
                // Handlungsziel:
                DBUtil.CheckNotNullField(edtHZDatum, lblHZDatum.Text);
                DBUtil.CheckNotNullField(edtHZText, lblHZHandlungsziel.Text);
            }
            else if (tabZielvereinbarung.IsTabSelected(tpgMassnahmen))
            {
                // Massnahme:
                DBUtil.CheckNotNullField(edtMNDatum, lblMNDatum.Text);
                DBUtil.CheckNotNullField(edtMNText, lblMNMassnahme.Text);
            }
            else
            {
                // invalid tab page
                throw new KissCancelException();
            }

            // logging
            _logger.Debug("done");
        }

        private void tabZielvereinbarung_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // logging
            _logger.Debug("enter");

            // load data for selected tab page
            InitSubQuery(_selectedTabChangingParentID);

            // logging
            _logger.Debug("done");
        }

        private void tabZielvereinbarung_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // end edit
            qryFaCmSub.EndCurrentEdit(true);

            // try to save pending changes - if failure, do not allow changing tab page
            e.Cancel = !qryFaCmSub.Post();

            // init var
            int parentID = -1;

            // store id if possible
            if (tabZielvereinbarung.IsTabSelected(tpgRahmenziele) || tabZielvereinbarung.IsTabSelected(tpgHandlungsziele))
            {
                // we are changeing from Rahmenziele or Handlungsziele to... (store current Rahmenziel or Handlungsziel)

                // validate data
                if (!DBUtil.IsEmpty(qryFaCmSub["FaCaseManagementID"]))
                {
                    // get id
                    parentID = Convert.ToInt32(qryFaCmSub["FaCaseManagementID"]);
                }
            }

            // setup id
            _selectedTabChangingParentID = parentID;

            // logging
            _logger.Debug("done");
        }

        private void treUebersicht_DoubleClick(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // call button click
            btnUebersichtGeheZu_Click(this, EventArgs.Empty);

            // logging
            _logger.Debug("done");
        }
    }
}