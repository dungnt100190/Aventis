using System;
using KiSS4.DB;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlKbKostenstelleErfassung : KiSS4.Common.KissSearchUserControl
    {
        public CtlKbKostenstelleErfassung()
        {
            InitializeComponent();            
        }

        private void qryKbKostenstelle_AfterInsert(object sender, EventArgs e)
        {
            qryKbKostenstelle["ModulID"] = 3;
            qryKbKostenstelle["Aktiv"] = true;
            edtKostenstelleNr.Focus();
        }

        private void CtlKbKostenstelleErfassung_Load(object sender, EventArgs e)
        {
            this.colModul.ColumnEdit = grdKostenstelle.GetLOVLookUpEdit("Modul");
            this.tabControlSearch.SelectedTabIndex = 1;
            this.qryKbKostenstelle.EnableBoundFields(false);            
        }

        private void qryKbKostenstelle_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtKostenstelleNr, lblKostenstelleNr.Text);
            DBUtil.CheckNotNullField(edtKostenstelleName, lblKostenstelleName.Text);
        }
    }
}
