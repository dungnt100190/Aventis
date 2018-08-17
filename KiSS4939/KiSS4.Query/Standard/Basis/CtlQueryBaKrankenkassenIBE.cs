using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    partial class CtlQueryBaKrankenkassenIBE : KissQueryControl
    {
        #region Constructors

        public CtlQueryBaKrankenkassenIBE()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void edtBaPersonID_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            var searchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.LookupID = null;
                    return;
                }
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg["Name"];
                edtBaPersonID.LookupID = dlg["BaPersonID"];
            }
        }

        private void edtUserID_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            var searchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        #endregion
    }
}