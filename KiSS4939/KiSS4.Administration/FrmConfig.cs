using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Administration
{
    public partial class FrmConfig : KissChildForm
    {
        public FrmConfig()
        {
            InitializeComponent();

            var ctlConfig = new CtlConfig { Dock = DockStyle.Fill };
            Controls.Add(ctlConfig);
            ActiveControl = ctlConfig;
        }
    }
}
