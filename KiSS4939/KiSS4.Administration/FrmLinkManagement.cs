using System.Windows.Forms;

using KiSS4.Gui;

using Kiss.Interfaces.UI;

namespace KiSS4.Administration
{
    public partial class FrmLinkManagement : KissChildForm, IContainerForm
    {
        public FrmLinkManagement()
        {
            InitializeComponent();

            var ctlLinkManagement = new CtlLinkManagement { Dock = DockStyle.Fill };
            Controls.Add(ctlLinkManagement);
            ActiveControl = ctlLinkManagement;
        }
    }
}
