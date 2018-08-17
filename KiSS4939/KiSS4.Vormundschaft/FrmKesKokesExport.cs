using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    public partial class FrmKesKokesExport : KissChildForm, IContainerForm
    {
        public FrmKesKokesExport()
        {
            InitializeComponent();

            var ctl = new CtlKesKokesExport { Dock = DockStyle.Fill };
            Controls.Add(ctl);
            ActiveControl = ctl;
        }
    }
}