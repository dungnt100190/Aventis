using System;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Administration.PI
{
    /// <summary>
    /// Control to edit data on FaLeistung
    /// </summary>
    public partial class CtlAdProzessBearbeiten : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlAdProzessBearbeiten";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create new instance of class
        /// </summary>
        public CtlAdProzessBearbeiten()
        {
            // init control
            InitializeComponent();

            // setup rights
            SetupRights();

            // set default tpg
            tabControlSearch.SelectTab(tpgSuchen);
        }

        #endregion

        #region EventHandlers

        private void btnAbwesenheitswochenLoeschen_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion(CLASSNAME, "FileImportAskForOverwriting", "Wollen Sie wirklich alle Einträge bei „Abwesenheitswochen“ in allen BW-Prozessen unwiderruflich löschen?"))
            {
                DBUtil.ExecSQLThrowingException("UPDATE dbo.BwAuswertungOrganisation SET AbwesenheitKlient = NULL ;");
            }
        }

        private void CtlAdProzessBearbeiten_Load(object sender, EventArgs e)
        {
            // init control with no person
            ctlFallInfo.BaPersonID = -1;

            // start with new search
            NewSearch();
        }

        private void qryBaPerson_AfterFill(object sender, EventArgs e)
        {
            // check if we have any data
            if (qryBaPerson.Count < 1)
            {
                // reset control
                ctlFallInfo.BaPersonID = -1;
            }

            // count entries
            lblCount.Text = KissMsg.GetMLMessage(this.Name, "CountEntries", "Anzahl Datensätze: {0}", qryBaPerson.Count);
        }

        private void qryBaPerson_PositionChanged(object sender, EventArgs e)
        {
            // apply new id to control
            ctlFallInfo.BaPersonID = Convert.ToInt32(qryBaPerson["BaPersonID"]);
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Initialize Controls on Search-Tabpage
        /// </summary>
        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // focus first control
            edtSuchePersonenNr.Focus();
        }

        /// <summary>
        /// Run search and get data from database
        /// </summary>
        protected override void RunSearch()
        {
            // replace search parameters
            object[] parameters = new object[] { Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check and setup rights for control
        /// </summary>
        private void SetupRights()
        {
            // init vars
            bool canReadData = false;
            bool canUserInsert = false;
            bool canUserUpdate = false;
            bool canUserDelete = false;

            // set values
            Session.GetUserRight(this.Name, out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);

            // check rights (for security reason: full access is required!)
            if (!canReadData || !canUserInsert || !canUserUpdate || !canUserDelete)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            if (DBUtil.UserHasRight("CtlAdProzessBearbeiten_AbwesenheitswochenLoeschen"))
            {
                panAbwesenheitswochenLoeschen.Visible = true;
            }
        }

        #endregion

        #endregion
    }
}