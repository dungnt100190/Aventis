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

namespace Kiss.UI.Container.Fs
{
    public partial class FrmFsFallsteuerung : KissChildForm, IContainerForm
    {
        public FrmFsFallsteuerung()
        {
            InitializeComponent();

            var ctlFsFallsteuerung = new CtlFsFallsteuerung { Dock = DockStyle.Fill };
            Controls.Add(ctlFsFallsteuerung);
            ActiveControl = ctlFsFallsteuerung;
        }
    }
}