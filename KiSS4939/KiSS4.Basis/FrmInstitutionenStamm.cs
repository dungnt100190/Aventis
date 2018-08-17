using System.Collections.Specialized;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Basis
{
    public partial class FrmInstitutionenStamm : KissChildForm
    {
        private readonly CtlInstitutionenStamm _ctlInstitutionenStamm;

        public FrmInstitutionenStamm()
        {
            InitializeComponent();

            _ctlInstitutionenStamm = new CtlInstitutionenStamm { Dock = DockStyle.Fill };
            Controls.Add(_ctlInstitutionenStamm);
            ActiveControl = _ctlInstitutionenStamm;
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            return _ctlInstitutionenStamm.ReceiveMessage(parameters);
        }

        public override object ReturnMessage(HybridDictionary parameters)
        {
            return _ctlInstitutionenStamm.ReturnMessage(parameters);
        }

        private void FrmInstitutionenStamm_Shown(object sender, System.EventArgs e)
        {
            _ctlInstitutionenStamm.SetFocusNewSearch();
        }
    }
}