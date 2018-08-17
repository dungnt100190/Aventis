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

namespace KiSS4.Klientenbuchhaltung.ZH
{
    public partial class FrmKbPSCDSchnittstelle : KissChildForm, IContainerForm
    {
        public FrmKbPSCDSchnittstelle()
        {
            InitializeComponent();

            var ctlKbPSCDSchnittstelle = new CtlKbPSCDSchnittstelle { Dock = DockStyle.Fill };
            Controls.Add(ctlKbPSCDSchnittstelle);
            ActiveControl = ctlKbPSCDSchnittstelle;
        }
    }
}