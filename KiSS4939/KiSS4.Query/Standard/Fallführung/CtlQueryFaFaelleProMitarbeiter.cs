using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryFaFaelleProMitarbeiter : KissQueryControl
    {
        #region Constructors

        public CtlQueryFaFaelleProMitarbeiter()
        {
            InitializeComponent();
        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            // replace search parameters
            object[] parameters = new object[] { Session.User.LogonName, Session.User.LanguageCode };

            kissSearch.SelectParameters = parameters;

            base.RunSearch();

            qryListe2.Fill();
        }

        #endregion
    }
}