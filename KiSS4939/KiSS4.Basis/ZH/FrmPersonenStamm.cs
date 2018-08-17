using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KiSS4.Basis.ZH
{
    public partial class FrmPersonenStamm : KiSS4.Gui.KissChildForm
    {
        public FrmPersonenStamm()
        {
            InitializeComponent();

            var ctlPersonenStamm = new CtlPersonenStamm { Dock = DockStyle.Fill };
            Controls.Add(ctlPersonenStamm);
            ActiveControl = ctlPersonenStamm;
        }
    }
}