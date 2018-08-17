using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryFaDokumentAblage : KissQueryControl
    {
        #region Constructors

        public CtlQueryFaDokumentAblage()
        {
            InitializeComponent();

            SetupDataMembers();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            // focus
            edtSucheDatumVon.Focus();
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

        #region Private Methods

        private void SetupDataMembers()
        {
            ctlGotoFall.DataMember = "BaPersonID$";
            xDocument.DataMember = "DocumentID$";
        }

        #endregion

        #endregion
    }
}