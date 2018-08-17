using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Administration
{
    public partial class FrmDynaMask : KissChildForm
    {
        public FrmDynaMask()
        {
            InitializeComponent();

            var ctlFrmDynaMask = new CtlFrmDynaMask { Dock = DockStyle.Fill };
            Controls.Add(ctlFrmDynaMask);
            ActiveControl = ctlFrmDynaMask;
        }
    }
}