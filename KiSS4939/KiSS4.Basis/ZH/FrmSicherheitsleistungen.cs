using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Basis.ZH
{
    public partial class FrmSicherheitsleistungen : KissChildForm
    {
        public FrmSicherheitsleistungen()
        {
            InitializeComponent();

            var ctlSicherheitsleistungen = new CtlSicherheitsleistungen { Dock = DockStyle.Fill };
            Controls.Add(ctlSicherheitsleistungen);
            ActiveControl = ctlSicherheitsleistungen;
        }
    }
}