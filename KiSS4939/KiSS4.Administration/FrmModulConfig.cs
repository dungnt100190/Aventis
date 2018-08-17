using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public partial class FrmModulConfig : KissChildForm, IContainerForm
    {
        public FrmModulConfig()
        {
            InitializeComponent();

            var ctlModulConfig = new CtlModulConfig { Dock = DockStyle.Fill };
            Controls.Add(ctlModulConfig);
            ActiveControl = ctlModulConfig;
        }
    }
}