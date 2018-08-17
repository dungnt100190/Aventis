using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Asyl
{
    public partial class FrmAyKasse : KissChildForm
    {
        public FrmAyKasse()
        {
            InitializeComponent();

            var ctlAyKasse = new CtlAyKasse { Dock = DockStyle.Fill };
            Controls.Add(ctlAyKasse);
            ActiveControl = ctlAyKasse;
        }
    }
}