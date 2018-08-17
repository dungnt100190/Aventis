using System.Windows.Forms;

using KiSS4.Gui;

using Kiss.Interfaces.UI;

namespace KiSS4.Administration
{
    public partial class FrmMultilanguage : KissChildForm, IContainerForm
    {
        public FrmMultilanguage()
        {
            InitializeComponent();

            var ctlMultilanguage = new CtlMultilanguage { Dock = DockStyle.Fill };
            Controls.Add(ctlMultilanguage);
            ActiveControl = ctlMultilanguage;
        }
    }
}
