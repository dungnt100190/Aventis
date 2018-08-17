using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Administration
{
    /// <summary>
    /// Summary description for FrmArchiveManagement.
    /// </summary>
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