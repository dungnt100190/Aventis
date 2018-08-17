using System.Collections.Specialized;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Gui;

namespace KiSS4.Administration
{
    public partial class FrmDataCorrection : KissChildForm, IContainerForm
    {
        private readonly CtlDataCorrection _ctlDataCorrection;

        public FrmDataCorrection()
        {
            InitializeComponent();

            _ctlDataCorrection = new CtlDataCorrection { Dock = DockStyle.Fill };
            Controls.Add(_ctlDataCorrection);
            ActiveControl = _ctlDataCorrection;
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            return _ctlDataCorrection.ReceiveMessage(parameters);
        }
    }
}
