using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    public partial class FrmBatchKVG : KissChildForm
    {
        public FrmBatchKVG()
        {
            InitializeComponent();

            // create new belegleser instance
            new Belegleser(this);

            var ctl = new CtlBatchKVG { Dock = DockStyle.Fill };
            Controls.Add(ctl);
            ActiveControl = ctl;

        }
    }
}
