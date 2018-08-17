using System;
using System.Collections.Specialized;
using System.Windows.Forms;

using KiSS4.Gui;

namespace Kiss.UI.Container.Fa
{
    public partial class FrmFaZeitachse : KissChildForm
    {
        private readonly CtlFaZeitachse _ctlFaZeitachse;

        public FrmFaZeitachse()
        {
            InitializeComponent();

            RestoreOnLogin = false;

            _ctlFaZeitachse = new CtlFaZeitachse { Dock = DockStyle.Fill };
            _ctlFaZeitachse.TextChanged += ctlFaZeitachse_TextChanged;
            Controls.Add(_ctlFaZeitachse);
            ActiveControl = _ctlFaZeitachse;
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            return _ctlFaZeitachse.ReceiveMessage(parameters);
        }

        private void ctlFaZeitachse_TextChanged(object sender, EventArgs e)
        {
            Text = _ctlFaZeitachse.Text;
        }
    }
}
