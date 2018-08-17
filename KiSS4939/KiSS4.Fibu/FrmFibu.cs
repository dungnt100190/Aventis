using System;
using System.Collections.Specialized;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.Gui;

using Kiss.Interfaces;

namespace KiSS4.Fibu
{
    public partial class FrmFibu : KissChildForm
    {
        private readonly CtlFibu _ctl;

        public FrmFibu()
        {
            InitializeComponent();

            //TODO: the return value of the constructor and thus the created Belegleser is ignored.
            new Belegleser(this);
        
            _ctl = new CtlFibu { Dock = DockStyle.Fill };
            Controls.Add(_ctl);
            ActiveControl = _ctl;
        }

        private void FrmFibu_Activated(object sender, EventArgs e)
        {
            _ctl.OnParentActivated();
        }

        private void FrmFibu_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = _ctl.OnParentClosing();
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            return _ctl.ReceiveMessage(parameters);
        }
    }
}