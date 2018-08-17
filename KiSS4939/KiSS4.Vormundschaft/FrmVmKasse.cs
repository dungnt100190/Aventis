using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    public partial class FrmVmKasse : KissChildForm
    {
        public FrmVmKasse()
        {
            InitializeComponent();

            CtlVmKasse ctlVmKasse = new CtlVmKasse { Dock = DockStyle.Fill };
            Controls.Add(ctlVmKasse);
            ActiveControl = ctlVmKasse;
        }
    }
}