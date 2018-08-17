using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Gui;

namespace KiSS4.Administration.PI
{
    public partial class FrmAdAnwendungsdatenVerwalten : KissChildForm, IContainerForm
    {
        public FrmAdAnwendungsdatenVerwalten()
        {
            InitializeComponent();

            var ctlAdAnwendungsdatenVerwalten = new CtlAdAnwendungsdatenVerwalten { Dock = DockStyle.Fill };
            Controls.Add(ctlAdAnwendungsdatenVerwalten);
            ActiveControl = ctlAdAnwendungsdatenVerwalten;
        }
    }
}