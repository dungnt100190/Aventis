using System;
using KiSS4.Common;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryVmErbschaftKontrolleTestament : KissQueryControl
    {
        public CtlQueryVmErbschaftKontrolleTestament()
        {
            InitializeComponent();
        }

        private void edtUser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtUser.Text, ModulID.V, e.ButtonClicked);
            if (!e.Cancel)
            {
                edtUser.LookupID = dlg["UserID"];
                edtUser.Text = Convert.ToString(dlg["Name"]);
            }
        }
    }
}
