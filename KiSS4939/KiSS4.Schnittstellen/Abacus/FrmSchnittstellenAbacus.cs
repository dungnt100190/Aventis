using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Gui;

namespace KiSS4.Schnittstellen.Abacus
{
    public partial class FrmSchnittstellenAbacus : KissChildForm, IContainerForm
    {
        public FrmSchnittstellenAbacus()
        {
            InitializeComponent();

            var ctlSchnittstellenAbacus = new CtlSchnittstellenAbacus { Dock = DockStyle.Fill };
            Controls.Add(ctlSchnittstellenAbacus);
            ActiveControl = ctlSchnittstellenAbacus;
        }
    }
}