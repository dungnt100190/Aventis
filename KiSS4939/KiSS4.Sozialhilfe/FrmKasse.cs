using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    public partial class FrmKasse : KissChildForm
    {
        public FrmKasse()
        {
            InitializeComponent();

            var ctlKasse = new CtlKasse { Dock = DockStyle.Fill };
            Controls.Add(ctlKasse);
            ActiveControl = ctlKasse;
        }
    }
}