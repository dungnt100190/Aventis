using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
    public partial class FrmDesigner : KissChildForm
    {
        private readonly CtlFrmDesigner _ctl;

        public FrmDesigner()
        {
            InitializeComponent();
            _ctl = new CtlFrmDesigner { Dock = DockStyle.Fill };
            Controls.Add(_ctl);
            ActiveControl = _ctl;
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            return _ctl.ReceiveMessage(param);
        }
    }
}