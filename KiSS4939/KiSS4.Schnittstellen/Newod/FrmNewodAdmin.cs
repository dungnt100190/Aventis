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

namespace KiSS4.Schnittstellen.Newod
{
    public partial class FrmNewodAdmin : KissChildForm, IContainerForm
    {
        public FrmNewodAdmin()
        {
            InitializeComponent();

            var ctlNewodAdmin = new CtlNewodAdmin { Dock = DockStyle.Fill };
            Controls.Add(ctlNewodAdmin);
            ActiveControl = ctlNewodAdmin;
        }
    }
}