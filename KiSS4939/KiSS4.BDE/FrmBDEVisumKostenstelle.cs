using System.Windows.Forms;

using KiSS4.Gui;

using Kiss.Interfaces.UI;

namespace KiSS4.BDE
{
    public partial class FrmBDEVisumKostenstelle : KissChildForm, IContainerForm
    {
        public FrmBDEVisumKostenstelle()
        {
            InitializeComponent();

            var ctlFrmBDEVisumKostenstelle = new CtlFrmBDEVisumKostenstelle { Dock = DockStyle.Fill };
            Controls.Add(ctlFrmBDEVisumKostenstelle);
            ActiveControl = ctlFrmBDEVisumKostenstelle;
        }
    }
}
