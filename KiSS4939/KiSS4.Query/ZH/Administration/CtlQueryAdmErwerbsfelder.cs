using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query.ZH
{
    public partial class CtlQueryAdmErwerbsfelder : KissQueryControl
    {
        public CtlQueryAdmErwerbsfelder()
        {
            InitializeComponent();

            ctlGotoFall.DataMember = "BaPersonID$";
            xDocument.DataMember = "BaPersonID$";
        }

        protected override void NewSearch()
        {
            kissSearch.SelectParameters = new object[] { Session.User.LanguageCode };
            ctlOrgUnitTeamUser.NewSearch();
            edtSearchAge.EditValue = 14;
            base.NewSearch();
        }
    }
}