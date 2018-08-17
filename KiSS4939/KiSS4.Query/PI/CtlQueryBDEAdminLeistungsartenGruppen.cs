using KiSS4.DB;

namespace KiSS4.Query.PI
{
    public partial class CtlQueryBDEAdminLeistungsartenGruppen : Common.KissQueryControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryBDEAdminLeistungsartenGruppen"/> class.
        /// </summary>
        public CtlQueryBDEAdminLeistungsartenGruppen()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // focus
            edtSucheStandardKTR.Focus();
        }

        protected override void RunSearch()
        {
            // replace search parameters
            var parameters = new object[] { Session.User.LanguageCode };
            kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #endregion
    }
}