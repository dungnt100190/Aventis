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

namespace KiSS4.Administration.ZH
{
    public partial class FrmModulConfig : KissChildForm, IContainerForm
    {
        public FrmModulConfig()
        {
            InitializeComponent();

            var ctlModulConfig = new CtlModulConfig { Dock = DockStyle.Fill };
            Controls.Add(ctlModulConfig);
            ActiveControl = ctlModulConfig;
        }
    }
}