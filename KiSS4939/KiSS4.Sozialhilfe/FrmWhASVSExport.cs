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
    public partial class FrmWhASVSExport : KissChildForm
    {
        public FrmWhASVSExport()
        {
            InitializeComponent();

            var ctlWhASVSExport = new CtlWhASVSExport { Dock = DockStyle.Fill };
            Controls.Add(ctlWhASVSExport);
            ActiveControl = ctlWhASVSExport;
        }
    }
}