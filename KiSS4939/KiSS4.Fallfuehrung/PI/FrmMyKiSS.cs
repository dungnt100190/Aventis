using System;
using System.Data;
using System.Drawing;
using System.Security;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Base;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.PI
{
    public partial class FrmMyKiSS : KissChildForm
    {
        private CtlMyKiSS ctlMyKiSS;

        public FrmMyKiSS()
        {
            InitializeComponent();

            ctlMyKiSS = new CtlMyKiSS { Dock = DockStyle.Fill };
            ctlMyKiSS.TextChanged += ctlMyKiSS_TextChanged;
            Text = ctlMyKiSS.Text;
            Controls.Add(ctlMyKiSS);
            ActiveControl = ctlMyKiSS;
        }

        public override void Translate()
        {
            ctlMyKiSS.Translate();
        }

        private void ctlMyKiSS_TextChanged(object sender, EventArgs e)
        {
            Text = ctlMyKiSS.Text;
        }
    }
}