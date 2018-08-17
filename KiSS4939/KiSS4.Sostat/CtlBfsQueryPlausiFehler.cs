using System;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Sostat
{
    public partial class CtlBfsQueryPlausiFehler : KiSS4.Common.KissQueryControl
    {
        public CtlBfsQueryPlausiFehler()
        {
            this.InitializeComponent();
        }

        protected override void NewSearch()
        {
            base.NewSearch();
            this.edtErhebungsjahr.Text = DBUtil.GetConfigValue(@"System\Sostat\Erhebungsjahr", DateTime.Now.Year).ToString();
        }

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(edtBaPersonID.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg["Name"];      ///TODO über db-Schema, aber nicht für Release-patch! (ändern möglich für R4.1.27)
                edtBaPersonID.LookupID = dlg["BaPersonID"]; ///TODO über db-Schema, aber nicht für Release-patch! (ändern möglich für R4.1.27)
            }
        }

        private void edtSARX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtSARX.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSARX.EditValue = dlg["Name"];  ///TODO über db-Schema, aber nicht für Release-patch! (ändern möglich für R4.1.27)
                edtSARX.LookupID = dlg["UserID"]; ///TODO über db-Schema, aber nicht für Release-patch! (ändern möglich für R4.1.27)
            }
        }
    }
}