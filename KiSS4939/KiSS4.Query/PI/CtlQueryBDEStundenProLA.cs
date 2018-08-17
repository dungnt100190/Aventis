using System;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace KiSS4.Query.PI
{
    /// <summary>
    /// Query, "Stunden pro Leistungsart" used for Pro Infirmis
    /// </summary>
    public partial class CtlQueryBDEStundenProLA : KissQueryControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private bool _isChiefOrRepresentative; // store if sesssion user is chief or representative of current users' oe
        private bool _specialRightKostenstelleHs; // store if user has special rights to show all orgunits (Hauptsitz)
        private bool _specialRightKostenstelleKgs; // store if user has special rights to show all orgunits within its KGS
        private bool _summaryItemsApplied; // flag to store if summary-items were applied after run-search
        private int _userOrgUnitID = -1; // store the user's orgunitid

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryBDEStundenProLA"/> class.
        /// </summary>
        public CtlQueryBDEStundenProLA()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryBDEStundenProLA_Load(object sender, EventArgs e)
        {
            // DEFAULT VALUES:
            // get users member orgunit
            _userOrgUnitID = QryUtils.GetOrgUnitOfUser(Session.User.UserID);

            // RIGHTS:
            // get if user has special right to select specified Kostenstelle/MA
            _specialRightKostenstelleHs = DBUtil.UserHasRight("QRYStundenProLAKostenstelleHS");
            _specialRightKostenstelleKgs = DBUtil.UserHasRight("QRYStundenProLAKostenstelleKGS");

            // get if user is zle chief or representative of ANY orgunit
            _isChiefOrRepresentative = QryUtils.IsChiefOrRepresentative(Session.User.UserID, -1);

            // SEARCH:
            // fill dropdowns data, depending on rights
            BDEUtils.InitKostenstelleDropDown(Session.User.UserID, _specialRightKostenstelleHs, _specialRightKostenstelleKgs, edtSucheKostenstelle);
            BDEUtils.InitMitarbeiterDropDown(Session.User.UserID, _specialRightKostenstelleHs, _specialRightKostenstelleKgs, _isChiefOrRepresentative, edtSucheMitarbeiter);

            // QUERIES:
            SetupSqlQuery(qryQuery, "klient/innen");
            SetupSqlQuery(qryListe2Zusammenfassung, "zusammenfassung");
            SetupSqlQuery(qryListe3ProMonat, "promonat");
            SetupSqlQuery(qryListe4Kostenstelle, "kostenstelle");

            // INIT
            // start with new search
            NewSearch();
        }

        private void edtSucheKostenstelle_EditValueChanged(object sender, EventArgs e)
        {
            // if user is zle-user and changes the orgunit-value, we have to check is user is zle-user on new selected orgunit as well
            if (!_isChiefOrRepresentative || _specialRightKostenstelleHs || _specialRightKostenstelleKgs)
            {
                // normal or hs/kgs-user, do not continue with check
                return;
            }

            // validate
            if (DBUtil.IsEmpty(edtSucheKostenstelle.EditValue) && !Session.User.IsUserAdmin)
            {
                KissMsg.ShowInfo(Name, "NoValueForKostenstelle", "Das Feld 'Kostenstelle' verlangt eine Eingabe!");
                edtSucheKostenstelle.Focus();
                return;
            }

            // get if user is zle chief or representative of current orgunit
            bool isChiefOrRepresentativeOnOrgUnit = Session.User.IsUserAdmin ||
                                                    QryUtils.IsChiefOrRepresentative(Session.User.UserID,
                                                                                     Convert.ToInt32(edtSucheKostenstelle.EditValue));

            // check value and setup Mitarbeiter
            edtSucheMitarbeiter.EditMode = isChiefOrRepresentativeOnOrgUnit ? EditModeType.Normal : EditModeType.ReadOnly;
            edtSucheMitarbeiter.EditValue = isChiefOrRepresentativeOnOrgUnit ? edtSucheMitarbeiter.EditValue : Session.User.UserID;
        }

        private void edtSucheLeistungsart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogLeistungsart(e, edtSucheLeistungsart);
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // check we are on any list-tpg after running search
            if (!tabControlSearch.IsTabSelected(tpgSuchen))
            {
                // add grid-summaries
                SetupGridSummaries();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Translate this query
        /// </summary>
        public override void Translate()
        {
            // apply translation
            base.Translate();

            // setup titles
            tpgListe.Title = KissMsg.GetMLMessage(Name, "List1Caption", "Klient/innen Mitarbeiter/innen");
            tpgZusammenfassung.Title = KissMsg.GetMLMessage(Name, "List2Caption", "Zusammenfassung");
            tpgProMonat.Title = KissMsg.GetMLMessage(Name, "List3Caption", "Pro Monat");
            tpgKostenstelle.Title = KissMsg.GetMLMessage(Name, "List4Caption", "Kostenstelle");
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Start a new search
        /// </summary>
        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // apply static search values
            edtSucheUserID.EditValue = Session.User.UserID;
            edtSucheLanguageCode.EditValue = Session.User.LanguageCode;

            // apply rights and default search parameters
            QryUtils.NewSearchMitarbeiter(_specialRightKostenstelleHs, _specialRightKostenstelleKgs, _isChiefOrRepresentative, edtSucheMitarbeiter);

            // default Kostenstelle (for all users the same way)
            edtSucheKostenstelle.EditValue = _userOrgUnitID;

            // set focus
            edtSucheKostenstelle.Focus();

            // set flag
            _summaryItemsApplied = false;
        }

        /// <summary>
        /// Run a new search
        /// </summary>
        protected override void RunSearch()
        {
            // validate Kostenstelle and Mitarbeiter
            QryUtils.RunSearchValidateKstMa(_specialRightKostenstelleHs, _specialRightKostenstelleKgs, edtSucheKostenstelle, edtSucheMitarbeiter);

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private bool DialogLeistungsart(UserModifiedFldEventArgs e, KissButtonEdit edt)
        {
            try
            {
                // check if data can be altered
                if (edt.EditMode == EditModeType.ReadOnly)
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
                        // Leistungsart Suche
                        edt.EditValue = null;
                        edt.LookupID = null;

                        return true;
                    }
                }

                KissLookupDialog dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(string.Format(@"
                    SELECT DISTINCT
                           Bezeichnung = dbo.fnGetMLTextByDefault(LEI.BezeichnungTID, {1}, LEI.Bezeichnung),
                           Gruppe      = dbo.fnGetMLTextByDefault(GRP.UserGroupNameTID, {1}, GRP.UserGroupName),
                           Code$       = LEI.BDELeistungsartID
                    FROM dbo.BDELeistungsart                      LEI WITH (READUNCOMMITTED)
                      INNER JOIN dbo.BDEUserGroup_BDELeistungsart UGL WITH (READUNCOMMITTED) ON UGL.BDELeistungsartID = LEI.BDELeistungsartID
                      INNER JOIN dbo.XUser_BDEUserGroup           UGR WITH (READUNCOMMITTED) ON UGR.BDEUserGroupID = UGL.BDEUserGroupID
                      INNER JOIN dbo.BDEUserGroup                 GRP WITH (READUNCOMMITTED) ON GRP.BDEUserGroupID = UGR.BDEUserGroupID
                    WHERE (dbo.fnGetMLTextByDefault(LEI.BezeichnungTID, {1}, LEI.Bezeichnung) LIKE '{0}%' OR
                           dbo.fnGetMLTextByDefault(GRP.UserGroupNameTID, {1}, GRP.UserGroupName) LIKE '{0}%')
                    ORDER BY Bezeichnung ASC", searchString, Session.User.LanguageCode), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // Leistungsart Suche (first EditValue, then LookupID!)
                    edt.EditValue = dlg["Bezeichnung"];
                    edt.LookupID = dlg["Code$"];

                    // success
                    return true;
                }
                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorDialogLeistungsart_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        private void SetupGridColumnForSummary(GridView view, string fieldName, string displayFormat = "{0:F}")
        {
            // validate parameters
            if (view == null)
            {
                throw new ArgumentNullException("view", "The given GridView is empty, cannot access column.");
            }

            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentOutOfRangeException("fieldName", "The given fieldName is either not valid or addresses a column that does not exist for given view.");
            }

            GridColumn column = view.Columns[fieldName];

            if (column != null)
            {
                // setup column
                column.SummaryItem.DisplayFormat = displayFormat;
                column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                // add column to group summary
                view.GroupSummary.AddRange(
                    new DevExpress.XtraGrid.GridSummaryItem[]
                    {
                        new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName, column, displayFormat)
                    });
            }
            else
            {
                _logger.WarnFormat("The FieldName {0} could not be found in the result of dbo.spQRYStundenProLeistungsart. The summary can not be calculated or displayed.", fieldName);
            }
        }

        private void SetupGridSummaries()
        {
            // check if already applied
            if (_summaryItemsApplied)
            {
                // do nothing
                return;
            }

            // set flag (already here: if error, only once per search)
            _summaryItemsApplied = true;

            try
            {
                // GRID 1: "Klient/innen Mitarbeiter/innen"
                // init gridview
                SetupGridViewForSummary(grvQuery1);

                // check if we have enough columns
                if (grvQuery1.Columns.Count > 10)
                {
                    // setup columns
                    SetupGridColumnForSummary(grvQuery1, "Stunden");            // Stunden
                    SetupGridColumnForSummary(grvQuery1, "Anzahl", "{0:F0}"); // Anzahl
                }

                // GRID 2: "Zusammenfassung"
                // init gridview
                SetupGridViewForSummary(grvZusammenfassung);

                // check if we have enough columns
                if (grvZusammenfassung.Columns.Count > 4)
                {
                    // setup columns
                    SetupGridColumnForSummary(grvZusammenfassung, "Klienten/innen", "{0:F0}"); // Klient/innen
                    SetupGridColumnForSummary(grvZusammenfassung, "Stunden");           // Stunden
                    SetupGridColumnForSummary(grvZusammenfassung, "Anzahl", "{0:F0}"); // Anzahl
                }

                // GRID 3: "Pro Monat"
                // init gridview
                SetupGridViewForSummary(grvProMonat);

                // check if we have enough columns
                if (grvProMonat.Columns.Count > 16)
                {
                    // setup columns
                    SetupGridColumnForSummary(grvProMonat, "Jan");   // Jan
                    SetupGridColumnForSummary(grvProMonat, "Feb");   // Feb
                    SetupGridColumnForSummary(grvProMonat, "Mrz");   // Mrz
                    SetupGridColumnForSummary(grvProMonat, "Apr");   // Apr
                    SetupGridColumnForSummary(grvProMonat, "Mai");   // Mai
                    SetupGridColumnForSummary(grvProMonat, "Jun");   // Jun
                    SetupGridColumnForSummary(grvProMonat, "Jul");  // Jul
                    SetupGridColumnForSummary(grvProMonat, "Aug");  // Aug
                    SetupGridColumnForSummary(grvProMonat, "Sep");  // Sep
                    SetupGridColumnForSummary(grvProMonat, "Okt");  // Okt
                    SetupGridColumnForSummary(grvProMonat, "Nov");  // Nov
                    SetupGridColumnForSummary(grvProMonat, "Dez");  // Dez
                    SetupGridColumnForSummary(grvProMonat, "Total");  // Total
                }

                // GRID 4: "Kostenstelle"
                //init gridview
                SetupGridViewForSummary(grvKostenstelle);

                // check if we have enough columns
                if (grvKostenstelle.Columns.Count > 6)
                {
                    // setup columns
                    SetupGridColumnForSummary(grvKostenstelle, "Klienten/innen", "{0:F0}"); // Klient/innen
                    SetupGridColumnForSummary(grvKostenstelle, "Stunden");           // Stunden
                    SetupGridColumnForSummary(grvKostenstelle, "Anzahl", "{0:F0}"); // Anzahl
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name,
                                  "ErrorSetupGridSummaries",
                                  "Es ist ein Fehler in der Verarbeitung aufgetreten, die Summen werden möglicherweise nicht korrekt angezeigt.",
                                  ex);
            }
        }

        private void SetupGridViewForSummary(GridView view)
        {
            // show all footers
            view.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            view.OptionsView.ShowFooter = true;

            // clear old summary-items
            view.GroupSummary.Clear();
        }

        private void SetupSqlQuery(SqlQuery qry, string resultTable)
        {
            // FILLTIMEOUT:
            // setup FillTimeOut for qryQuery
            if (_specialRightKostenstelleHs)
            {
                // hauptsitz, huge amount of data expected
                qry.FillTimeOut = 1200; // 20min
            }
            else if (_specialRightKostenstelleKgs)
            {
                // KGS, lower amount of data, still big
                qry.FillTimeOut = 600; // 10min
            }
            else if (_isChiefOrRepresentative)
            {
                // chief only, lower amount
                qry.FillTimeOut = 360;
            }

            // STATEMENT
            qry.SelectStatement = string.Format(@"
                -- declare vars
                DECLARE @OrgUnitID INT;
                DECLARE @ZeitraumVon DATETIME;
                DECLARE @ZeitraumBis DATETIME;
                DECLARE @BDELAAuswDLCode INT;
                DECLARE @BDELAAuswProduktCode INT;
                DECLARE @BDELAAuswPIAuftragCode INT;
                DECLARE @BDELAAuswFakturaCode INT;
                DECLARE @BDELeistungsartID INT;
                DECLARE @UserID INT;
                DECLARE @NurExport BIT;

                -- fill vars with search parameters (if value is given)
                --- SET @OrgUnitID                = {{edtSucheKostenstelle}};
                --- SET @ZeitraumVon              = {{edtSucheZeitraumVon}};
                --- SET @ZeitraumBis              = {{edtSucheZeitraumBis}};
                --- SET @BDELAAuswDLCode          = {{edtSucheAuswZLE}};
                --- SET @BDELAAuswProduktCode     = {{edtSucheAuswProdukt}};
                --- SET @BDELAAuswPIAuftragCode   = {{edtSucheAuswPIAuftrag}};
                --- SET @BDELAAuswFakturaCode     = {{edtSucheAuswFaktura}};
                --- SET @BDELeistungsartID        = {{edtSucheLeistungsart.LookupID}};
                --- SET @UserID                   = {{edtSucheMitarbeiter}};
                --- SET @NurExport                = {{edtNurExport}};

                EXEC dbo.spQRYStundenProLeistungsart {0},
                                                     @OrgUnitID,
                                                     @ZeitraumVon,
                                                     @ZeitraumBis,
                                                     @BDELAAuswDLCode,
                                                     @BDELAAuswProduktCode,
                                                     @BDELAAuswPIAuftragCode,
                                                     @BDELAAuswFakturaCode,
                                                     @BDELeistungsartID,
                                                     @UserID,
                                                     @NurExport,
                                                     '{1}',
                                                     {2},
                                                     {3},
                                                     {4}",
                Session.User.LanguageCode,
                resultTable,
                Session.User.UserID,
                (_specialRightKostenstelleHs ? "1" : "0"),
                (_specialRightKostenstelleKgs ? "1" : "0"));
        }

        #endregion

        #endregion
    }
}