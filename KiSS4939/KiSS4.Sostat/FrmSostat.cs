using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Gui;

namespace KiSS4.Sostat
{
    public partial class FrmSostat : KissChildForm, IContainerForm
    {
        public FrmSostat()
        {
            InitializeComponent();

            var ctlSostat = new CtlSostat { Dock = DockStyle.Fill };
            Controls.Add(ctlSostat);
            ActiveControl = ctlSostat;
        }
    }
}