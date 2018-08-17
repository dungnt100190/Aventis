using System.Collections.Specialized;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Main
{
    public partial class FrmFallNavigator : KissChildForm
    {
        private readonly CtlFallNavigator _ctlFallNavigator;

        public FrmFallNavigator()
        {
            InitializeComponent();

            _ctlFallNavigator = new CtlFallNavigator { Dock = DockStyle.Fill };
            Controls.Add(_ctlFallNavigator);
            ActiveControl = _ctlFallNavigator;
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            return _ctlFallNavigator.ReceiveMessage(parameters);
        }

        public override object ReturnMessage(HybridDictionary parameters)
        {
            return _ctlFallNavigator.ReturnMessage(parameters);
        }
    }
}