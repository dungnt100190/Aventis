using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    partial class CtlQueryKaEinsaetzeJobtimal : KiSS4.Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryKaEinsaetzeJobtimal()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void CtlQueryKaEinsaetzeJobtimal_Load(object sender, System.EventArgs e)
        {
            tpgListe.Title = "Einsatz Jobtimal";
        }

        private void edtNameSTESID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtNameSTESID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtNameSTESID.EditValue = null;
                    edtNameSTESID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtNameSTESID.EditValue = dlg["Name"];
                edtNameSTESID.LookupID = dlg["BaPersonID"];
            }
        }

        #endregion
    }
}