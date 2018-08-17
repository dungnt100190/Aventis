using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public partial class FrmDocTemplate : KissChildForm, IContainerForm
    {
        public FrmDocTemplate()
        {
            InitializeComponent();

            var ctl = new CtlFrmDocTemplate { Dock = DockStyle.Fill };
            Controls.Add(ctl);
        }
    }
}