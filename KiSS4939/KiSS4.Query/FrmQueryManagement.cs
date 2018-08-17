using System.Windows.Forms;

using KiSS4.Gui;

using Kiss.Interfaces.UI;

namespace KiSS4.Query
{
    public partial class FrmQueryManagement : KissChildForm, IContainerForm
    {
        public FrmQueryManagement()
        {
            InitializeComponent();

            var ctlQueryManagement = new CtlQueryManagement { Dock = DockStyle.Fill };
            Controls.Add(ctlQueryManagement);
            ActiveControl = ctlQueryManagement;
        }
    }
}
