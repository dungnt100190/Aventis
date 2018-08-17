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
    public partial class DlgKgDokumentenPool : KissDialog
    {
        public DlgKgDokumentenPool()
        {
            InitializeComponent();
        }

        public void Init(int baPersonID, int kgBuchungID, KiSS4.Vormundschaft.ZH.CtlKgDokumente.ZKBDokumentTypCode zkbDokumentTypCodeToAssign, string stichwort)
        {
            ctlDokPool.Init(baPersonID, kgBuchungID, zkbDokumentTypCodeToAssign, stichwort);
        }

        private void ctlDokPool_CloseEvent(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
