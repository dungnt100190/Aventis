using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Administration.IBE
{
    public partial class FrmAdTranslation : KissDialog
    {
        public FrmAdTranslation()
        {
            InitializeComponent();

            var ctl = new CtlAdTranslation { Dock = DockStyle.Fill };
            Controls.Add(ctl);
            ActiveControl = ctl;
        }
    }
}
