using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Administration.ZH
{
    public partial class FrmArchiveManagement : KissChildForm
    {
        public FrmArchiveManagement()
        {
            InitializeComponent();

            var ctlArchiveManagement = new CtlArchiveManagement { Dock = DockStyle.Fill };
            Controls.Add(ctlArchiveManagement);
            ActiveControl = ctlArchiveManagement;
        }
    }
}