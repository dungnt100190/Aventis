using System;
using KiSS4.Common.PI;
using KiSS4.DB;

namespace KiSS4.Query.PI
{
    /// <summary>
    /// Class for query "Kein Fallverlauf"
    /// </summary>
    public partial class CtlQueryFaKeinFallverlauf : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private bool _isChiefOrRepresentative = false; // store if sesssion user is chief or representative of current users' oe
        private bool _specialRightKostenstelleHS = false; // store if user has special rights to show all orgunits (Hauptsitz)
        private bool _specialRightKostenstelleKGS = false; // store if user has special rights to show all orgunits within its KGS
        private int _userOrgUnitID = -1; // store the user's orgunitid
        private int _validateYear = -1; // store config value for validation year

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create new instance of control
        /// </summary>
        public CtlQueryFaKeinFallverlauf()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryFaKeinFallverlauf_Load(object sender, EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // SETTINGS
            this._validateYear = DBUtil.GetConfigInt(@"System\ZLE\StartJahr", -1);

            // validate
            if (this._validateYear < 2000)
            {
                // invalid value, do not continue
                throw new ArgumentOutOfRangeException("Invalid configuration value for year-validation, cannot continue.");
            }

            // DEFAULT VALUES:
            // get users member orgunit
            this._userOrgUnitID = QryUtils.GetOrgUnitOfUser(Session.User.UserID);

            // RIGHTS:
            // get if user has special right to select specified Kostenstelle/MA
            this._specialRightKostenstelleHS = DBUtil.UserHasRight("QRYKeinFallverlaufKostenstelleHS");
            this._specialRightKostenstelleKGS = DBUtil.UserHasRight("QRYKeinFallverlaufKostenstelleKGS");

            // get if user is zle chief or representative of ANY orgunit
            this._isChiefOrRepresentative = QryUtils.IsChiefOrRepresentative(Session.User.UserID, -1);

            // logging
            logger.Debug(String.Format("SpecialRightKostenstelleHS={0}, SpecialRightKostenstelleKGS={1}, IsChiefOrRepresentative={2}", this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, this._isChiefOrRepresentative));

            // SEARCH:
            // fill dropdowns data, depending on rights
            BDEUtils.InitKostenstelleDropDown(Session.User.UserID, this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, edtSucheKostenstelle);
            BDEUtils.InitMitarbeiterDropDown(Session.User.UserID, this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, this._isChiefOrRepresentative, edtSucheMitarbeiter);

            // FILLTIMEOUT:
            // setup FillTimeOut for qryQuery
            if (this._specialRightKostenstelleHS)
            {
                // hauptsitz, huge amount of data expected
                qryQuery.FillTimeOut = 1200; // 20min
            }
            else if (this._specialRightKostenstelleKGS)
            {
                // KGS, lower amount of data, still big amount
                qryQuery.FillTimeOut = 600; // 10min
            }
            else if (this._isChiefOrRepresentative)
            {
                // Chief only, lower amount
                qryQuery.FillTimeOut = 360;
            }

            // QUERIES:
            this.SetupSqlQuery(qryQuery);

            // INIT
            // start with new search
            this.NewSearch();

            // logging
            logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // apply rights and default search parameters
            QryUtils.NewSearchMitarbeiter(this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, this._isChiefOrRepresentative, edtSucheMitarbeiter);

            // default Kostenstelle (for all users the same way)
            edtSucheKostenstelle.EditValue = this._userOrgUnitID;

            // default year = current
            edtSucheJahr.EditValue = System.DateTime.Now.Year;

            // set focus
            edtSucheKostenstelle.Focus();
        }

        protected override void RunSearch()
        {
            // validate Kostenstelle and Mitarbeiter
            QryUtils.RunSearchValidateKstMa(this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, edtSucheKostenstelle, edtSucheMitarbeiter);

            // validate year
            if (DBUtil.IsEmpty(edtSucheJahr.EditValue))
            {
                // Jahr is required
                KissMsg.ShowInfo("CtlQueryFaKeinFallverlauf", "RequiredSearchYear", "Das Feld 'Jahr' wird für die Suche benötigt!");
                edtSucheJahr.Focus();

                throw new KissCancelException();
            }

            if (Convert.ToInt32(edtSucheJahr.EditValue) < this._validateYear)
            {
                // year cannot be smaller than config value
                KissMsg.ShowInfo("CtlQueryFaKeinFallverlauf", "RequiredSearchYearInvalid", "Das Feld 'Jahr' darf nicht kleiner als '{0}' sein!", 0, 0, this._validateYear);
                edtSucheJahr.Focus();

                throw new KissCancelException();
            }

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void SetupSqlQuery(SqlQuery qry)
        {
            qry.SelectStatement = @"
                    -- declare vars
                    DECLARE @OrgUnitID INT
                    DECLARE @Jahr INT
                    DECLARE @UserID INT

                    -- fill vars with search parameters (if value is given)
                    --- SET @OrgUnitID             = {edtSucheKostenstelle}
                    --- SET @Jahr                  = {edtSucheJahr}
                    --- SET @UserID                = {edtSucheMitarbeiter}

                    -- run statement
                    EXEC dbo.spQRYKeinFallverlauf " + Convert.ToString(Session.User.LanguageCode) + @",
                                                  @OrgUnitID,
                                                  @Jahr,
                                                  @UserID,
                                                  " + Convert.ToString(Session.User.UserID) + @",
                                                  " + (this._specialRightKostenstelleHS ? "1" : "0") + @",
                                                  " + (this._specialRightKostenstelleKGS ? "1" : "0");
        }

        #endregion

        #endregion
    }
}