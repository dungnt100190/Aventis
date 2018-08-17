using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiSS4.Gui;
using KiSS4.DB;

namespace KiSS4.Vormundschaft.ZH
{
    public partial class DlgKgDokumente : KissDialog
    {
        public DlgKgDokumente()
        {
            InitializeComponent();
        }

        public void Init(string caption, int baPersonID, int kgBuchungID, KiSS4.Vormundschaft.ZH.CtlKgDokumente.ZKBDokumentTypCode zkbDokumentTypCodeToAssign, string stichwort)
        {
            this.Text = caption;
            ctlDoks.Init(baPersonID, kgBuchungID, zkbDokumentTypCodeToAssign, stichwort);
        }
    }
}
