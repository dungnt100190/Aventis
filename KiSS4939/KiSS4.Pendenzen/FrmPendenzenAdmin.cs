using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Gui;

namespace KiSS4.Pendenzen
{
    public partial class FrmPendenzenAdmin : KissChildForm, IContainerForm
    {
        public FrmPendenzenAdmin()
        {
            InitializeComponent();

            var ctlPendenzenAdmin = new CtlPendenzenAdmin { Dock = DockStyle.Fill };
            Controls.Add(ctlPendenzenAdmin);
            ActiveControl = ctlPendenzenAdmin;
        }
    }
}