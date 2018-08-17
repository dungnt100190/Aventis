using System.Windows.Forms;

using KiSS4.Gui;

using Kiss.Interfaces.UI;

namespace KiSS4.Administration
{
    public partial class FrmFallVerwaltung : KissChildForm, IContainerForm
    {
        public FrmFallVerwaltung()
        {
            InitializeComponent();


            var ctlFallVerwaltung = new CtlFallVerwaltung { Dock = DockStyle.Fill };
            Controls.Add(ctlFallVerwaltung);
            ActiveControl = ctlFallVerwaltung;
        }
    }
}
