using System;
using System.Collections;
using System.Data;
using System.Linq;

using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.PI
{
    public partial class CtlQueryFaAktiveNeueDossiersBase : Common.KissQueryControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlQueryBaAktiveNeueDossiersBase";
        private const string RESULT_BSVBEHINDERUNG = "bsv-behinderung";
        private const string RESULT_HAUPTBEHINDERUNG = "hauptbehinderung";
        private const string RESULT_IVBERECHTIGUNG = "iv-berechtigung";
        private const string RESULT_KLIENT = "klient";
        private const string RESULT_KLIENT_COL_BAPERSONID = "BaPersonID$";
        private const string RESULT_KOSTENSTELLE = "kostenstelle";
        private const string RESULT_MITARBEITER = "mitarbeiter";

        #endregion

        #region Private Fields

        // rights
        private bool _isChiefOrRepresentative; // store if sesssion user is chief or representative of current users' oe

        // rights
        private string _rightNameKostenstelleHauptsitz = string.Empty; // store the name of the special right for KostenstelleHS
        private string _rightNameKostenstelleKGS = string.Empty; // store the name of the special right for KostenstelleKGS
        private bool _specialRightKostenstelleHauptsitz; // store if user has special rights to show all orgunits (Hauptsitz)
        private bool _specialRightKostenstelleKGS; // store if user has special rights to show all orgunits within its KGS

        // default search settings
        private int _userOrgUnitID = -1; // store the user's orgunitid

        // others
        private int _validateYear = -1; // store config value for validation year

        #endregion

        #endregion

        #region Constructors

        public CtlQueryFaAktiveNeueDossiersBase()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Set and get if only new clients have to be displayed in result grids
        /// </summary>
        internal bool OnlyNewClients
        {
            get;
            set;
        }

        /// <summary>
        /// Set and get the name of the special right for KostenstelleHS
        /// </summary>
        internal string RightNameKostenstelleHS
        {
            get
            {
                // validate
                if (string.IsNullOrEmpty(_rightNameKostenstelleHauptsitz))
                {
                    throw new ArgumentNullException("The value was not set and cannot be returned therefore.");
                }

                // return value
                return _rightNameKostenstelleHauptsitz;
            }
            set
            {
                // set the given value as property
                _rightNameKostenstelleHauptsitz = value;
            }
        }

        /// <summary>
        /// Get the name of the special right for KostenstelleKGS
        /// </summary>
        internal string RightNameKostenstelleKGS
        {
            get
            {
                // validate
                if (string.IsNullOrEmpty(_rightNameKostenstelleKGS))
                {
                    throw new ArgumentNullException("The value was not set and cannot be returned therefore.");
                }

                // return value
                return _rightNameKostenstelleKGS;
            }
            set
            {
                // set the given value as property
                _rightNameKostenstelleKGS = value;
            }
        }

        #endregion

        #region EventHandlers

        private void CtlQueryBaAktiveNeueDossiersBase_Load(object sender, EventArgs e)
        {
            // check if designer
            if (DesignerMode)
            {
                // currently in designer, do nothing
                return;
            }

            // remove datasource of first grid and bound controls
            if (xDocument.DataSource != null)
            {
                xDocument.DataSource.UnbindControls();
                xDocument.DataSource = null;
            }

            grdQuery1.DataSource = null;

            // append event to have feature of databinding on gotofall again
            grvQuery1.FocusedRowChanged += grvQuery1_FocusedRowChanged;

            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("RightNameKostenstelleHS='{0}', RightNameKostenstelleKGS='{1}', OnlyNewClients='{2}'",
                RightNameKostenstelleHS, RightNameKostenstelleKGS, OnlyNewClients);

            // SETTINGS
            _validateYear = DBUtil.GetConfigInt(@"System\ZLE\StartJahr", -1);

            // validate
            if (_validateYear < 2000)
            {
                // invalid value, do not continue
                throw new ArgumentOutOfRangeException("Invalid configuration value for year-validation, cannot continue.");
            }

            // DEFAULT VALUES:
            // get users member orgunit
            _userOrgUnitID = QryUtils.GetOrgUnitOfUser(Session.User.UserID);

            // RIGHTS:
            // get if user has special right to select specified Kostenstelle/MA
            _specialRightKostenstelleHauptsitz = DBUtil.UserHasRight(RightNameKostenstelleHS);
            _specialRightKostenstelleKGS = DBUtil.UserHasRight(RightNameKostenstelleKGS);

            // get if user is zle chief or representative of ANY orgunit
            _isChiefOrRepresentative = QryUtils.IsChiefOrRepresentative(Session.User.UserID, -1);

            // logging
            _logger.Debug(String.Format("SpecialRightKostenstelleHS={0}, SpecialRightKostenstelleKGS={1}, IsChiefOrRepresentative={2}",
                _specialRightKostenstelleHauptsitz, _specialRightKostenstelleKGS, _isChiefOrRepresentative));

            // SEARCH:
            // fill dropdowns data, depending on rights
            BDEUtils.InitKostenstelleDropDown(Session.User.UserID, _specialRightKostenstelleHauptsitz, _specialRightKostenstelleKGS, edtSucheKostenstelle);
            BDEUtils.InitMitarbeiterDropDown(Session.User.UserID, _specialRightKostenstelleHauptsitz, _specialRightKostenstelleKGS, _isChiefOrRepresentative, edtSucheMitarbeiter);

            // QUERIES:
            SetupSqlQuery(qryQuery,
                          string.Format("{0};{1};{2};{3};{4};{5}", RESULT_KLIENT,
                                                                   RESULT_MITARBEITER,
                                                                   RESULT_KOSTENSTELLE,
                                                                   RESULT_HAUPTBEHINDERUNG,
                                                                   RESULT_BSVBEHINDERUNG,
                                                                   RESULT_IVBERECHTIGUNG));

            // INIT
            // start with new search
            NewSearch();

            // logging
            _logger.Debug("done");
        }

        private void edtSucheZeitraumBis_EditValueChanged(object sender, EventArgs e)
        {
            // check if there is a date-value to parse
            if (DBUtil.IsEmpty(edtSucheZeitraumBis.EditValue))
            {
                // no value, so reset first date
                edtSucheZeitraumVon.EditValue = null;
            }
            else
            {
                // we have a date
                edtSucheZeitraumVon.EditValue = new DateTime(Convert.ToDateTime(edtSucheZeitraumBis.EditValue).Year, 1, 1);
            }
        }

        private void grvQuery1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var focusedRow = grvQuery1.GetDataRow(e.FocusedRowHandle);
            var baPersonID = (focusedRow == null || DBUtil.IsEmpty(focusedRow[RESULT_KLIENT_COL_BAPERSONID]))
                                 ? -1
                                 : Convert.ToInt32(focusedRow[RESULT_KLIENT_COL_BAPERSONID]);

            // Apply BaPersonID to enable GotoFall as we don't have any databinding capabilities this way
            // NOTE: setting BaPersonID without any databinding results in strange error (Diesem Command ist bereits ein geöffneter DataReader zugeordnet, der zuerst geschlossen werden muss.), so we use original query and do positioning by bapersonid
            if (!qryQuery.Find(string.Format("[{0}] = {1}", RESULT_KLIENT_COL_BAPERSONID, baPersonID)))
            {
                ctlGotoFall.BaPersonID = null;
            }
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            ApplyDataSourceToGrid(grdQuery1, qryQuery.DataSet.Tables, RESULT_KLIENT);
            ApplyDataSourceToGrid(grdListe2Mitarbeiter, qryQuery.DataSet.Tables, RESULT_MITARBEITER);
            ApplyDataSourceToGrid(grdListe3Kostenstelle, qryQuery.DataSet.Tables, RESULT_KOSTENSTELLE);
            ApplyDataSourceToGrid(grdListe4Hauptbehinderung, qryQuery.DataSet.Tables, RESULT_HAUPTBEHINDERUNG);
            ApplyDataSourceToGrid(grdListe5BSVBehinderung, qryQuery.DataSet.Tables, RESULT_BSVBEHINDERUNG);
            ApplyDataSourceToGrid(grdListe6IVBerechtigung, qryQuery.DataSet.Tables, RESULT_IVBERECHTIGUNG);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // do sorting of LOVs
            edtSucheHauptbehinderungsart.SortByFirstColumn();
            edtSucheBSVBehinderungsart.SortByFirstColumn();

            // setup titles
            tpgListe.Title = KissMsg.GetMLMessage(CLASSNAME, "Liste1TitelKlient", "Klient/innen");
            tpgListe2.Title = KissMsg.GetMLMessage(CLASSNAME, "Liste2TitelMitarbeiter", "Mitarbeiter/innen");
            tpgListe3.Title = KissMsg.GetMLMessage(CLASSNAME, "Liste3TitelKostenstelle", "Kostenstelle");
            tpgListe4.Title = KissMsg.GetMLMessage(CLASSNAME, "Liste4TitelHauptbehinderung", "Hauptbehinderung");
            tpgListe5.Title = KissMsg.GetMLMessage(CLASSNAME, "Liste5TitelBSVBehinderung", "BSV-Behinderungsart");
            tpgListe6.Title = KissMsg.GetMLMessage(CLASSNAME, "Liste6TitelIVBerechtigung", "IV-Berechtigung");
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // apply rights and default search parameters
            QryUtils.NewSearchMitarbeiter(_specialRightKostenstelleHauptsitz, _specialRightKostenstelleKGS, _isChiefOrRepresentative, edtSucheMitarbeiter);

            // default Kostenstelle (for all users the same way)
            edtSucheKostenstelle.EditValue = _userOrgUnitID;

            // date range
            edtSucheZeitraumBis.EditValue = new DateTime(DateTime.Now.Year, 12, 31); // DatumVon will be calculated automatically

            // only SB
            chkSucheNurSozialberatung.Checked = true;

            // set focus
            edtSucheKostenstelle.Focus();
        }

        protected override void RunSearch()
        {
            // validate Kostenstelle and Mitarbeiter
            QryUtils.RunSearchValidateKstMa(_specialRightKostenstelleHauptsitz, _specialRightKostenstelleKGS, edtSucheKostenstelle, edtSucheMitarbeiter);

            // check DatumVon
            edtSucheZeitraumBis_EditValueChanged(this, EventArgs.Empty);

            // validate dates
            if (DBUtil.IsEmpty(edtSucheZeitraumVon.EditValue))
            {
                // DatumVon is required
                KissMsg.ShowInfo(CLASSNAME, "RequiredSearchZeitraumVon_v01", "Das Feld 'Zeitraum von' wird für die Suche benötigt!");
                edtSucheZeitraumVon.Focus();

                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(edtSucheZeitraumBis.EditValue))
            {
                // DatumBis is required
                KissMsg.ShowInfo(CLASSNAME, "RequiredSearchZeitraumBis", "Das Feld 'Zeitraum bis' wird für die Suche benötigt!");
                edtSucheZeitraumBis.Focus();

                throw new KissCancelException();
            }

            // validate dates
            if (Convert.ToDateTime(edtSucheZeitraumVon.EditValue).Year < _validateYear || Convert.ToDateTime(edtSucheZeitraumBis.EditValue).Year < _validateYear)
            {
                // year cannot be smaller than config value
                KissMsg.ShowInfo(CLASSNAME, "RequiredSearchDatesInvalid_v01", "Das Jahr von 'Zeitraum von' oder 'Zeitraum bis' darf nicht kleiner als '{0}' sein!", 0, 0, _validateYear);
                edtSucheZeitraumBis.Focus();

                throw new KissCancelException();
            }

            if (Convert.ToDateTime(edtSucheZeitraumVon.EditValue).Year != Convert.ToDateTime(edtSucheZeitraumBis.EditValue).Year)
            {
                // years cannot be different
                KissMsg.ShowInfo(CLASSNAME, "SearchYearsInvalid_v01", "Die Werte aus 'Zeitraum von' und 'Zeitraum bis' müssen innerhalb desselben Jahres liegen!");
                edtSucheZeitraumVon.Focus();

                throw new KissCancelException();
            }

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Static Methods

        private static DataTable FindDataTableForResult(IEnumerable dataTables, string resultTableName)
        {
            return dataTables.Cast<DataTable>()
                .Where(dataTable => dataTable.Columns.Contains(string.Format("ResultTable_{0}$", resultTableName))).FirstOrDefault();
        }

        #endregion

        #region Private Methods

        private void ApplyDataSourceToGrid(KissGrid grd, IEnumerable dataTables, string resultTableToApply)
        {
            var dataTable = FindDataTableForResult(dataTables, resultTableToApply);

            if (dataTable == null)
            {
                KissMsg.ShowInfo(CLASSNAME, "ErrorApplyDataSourceToGrid", "Es ist ein Fehler beim Anwenden der Datenquelle '{0}' aufgetreten.{1}{1}Die Anzeige der Daten ist möglicherweise fehlerhaft oder nicht vollständig.", resultTableToApply);
                return;
            }

            SetupDataSourceAndGridColumns(grd, dataTable);
        }

        private void SetupSqlQuery(SqlQuery qry, String resultTable)
        {
            qry.SelectStatement = @"
            -- declare vars
            DECLARE @OrgUnitID INT
            DECLARE @ZeitraumBis DATETIME
            DECLARE @UserID INT
            DECLARE @HauptbehinderungsartCode INT
            DECLARE @BSVBehinderungsartCode INT
            DECLARE @IVBerechtigungsCode INT
            DECLARE @GeburtVon DATETIME
            DECLARE @GeburtBis DATETIME
            DECLARE @NurSozialberatung BIT

            -- fill vars with search parameters (if value is given)
            --- SET @OrgUnitID                = {edtSucheKostenstelle}
            --- SET @ZeitraumBis              = {edtSucheZeitraumBis}
            --- SET @UserID                   = {edtSucheMitarbeiter}
            --- SET @HauptbehinderungsartCode = {edtSucheHauptbehinderungsart}
            --- SET @BSVBehinderungsartCode   = {edtSucheBSVBehinderungsart}
            --- SET @IVBerechtigungsCode      = {edtSucheIVBerechtigung}
            --- SET @GeburtVon                = {edtSucheGeburtVon}
            --- SET @GeburtBis                = {edtSucheGeburtBis}
            --- SET @NurSozialberatung        = {chkSucheNurSozialberatung}

            EXEC dbo.spQRYAktiveNeueDossiers " + Convert.ToString(Session.User.LanguageCode) + @",
                                                @OrgUnitID,
                                                @ZeitraumBis,
                                                @UserID,
                                                @HauptbehinderungsartCode,
                                                @BSVBehinderungsartCode,
                                                @IVBerechtigungsCode,
                                                @GeburtVon,
                                                @GeburtBis,
                                                @NurSozialberatung,
                                                '" + resultTable + @"',
                                                " + Convert.ToString(Session.User.UserID) + @",
                                                " + (_specialRightKostenstelleHauptsitz ? "1" : "0") + @",
                                                " + (_specialRightKostenstelleKGS ? "1" : "0") + @",
                                                " + (OnlyNewClients ? "1" : "0");
        }

        #endregion

        #endregion
    }
}