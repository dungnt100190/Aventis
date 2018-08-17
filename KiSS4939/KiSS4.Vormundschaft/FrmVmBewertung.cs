using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    public partial class FrmVmBewertung : KissChildForm
    {
        private CtlFrmVmBewertung _ctlfrmVmBewertung;

        public FrmVmBewertung()
        {
            InitializeComponent();

            _ctlfrmVmBewertung = new CtlFrmVmBewertung { Dock = DockStyle.Fill };
            Controls.Add(_ctlfrmVmBewertung);
            ActiveControl = _ctlfrmVmBewertung;
        }

        //private void FrmVmBewertung_Shown(object sender, EventArgs e)
        //{
        //    _ctlfrmVmBewertung.FrmVmBewertung_Shown(sender, e);
        //}
    }
}