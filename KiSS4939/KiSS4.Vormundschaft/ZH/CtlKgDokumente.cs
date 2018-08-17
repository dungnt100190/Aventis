using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.Gui;
using KiSS.DBScheme;
using KiSS4.DB;

namespace KiSS4.Vormundschaft.ZH
{
    public partial class CtlKgDokumente : KissUserControl
    {
        public enum ZKBDokumentTypCode
        {
            Alle = 0,
            Kontoauszug = 1,
            Belastungsanzeige = 2,
            Gutschriftanzeige = 3,
            NurGutschriftenUndBelastungen = 99
        }

        private int _baPersonID = 0;
        private int _kgBuchungID = 0;
        private ZKBDokumentTypCode _zkbDokumentTypCodeToAssign = ZKBDokumentTypCode.Alle;
        private string _stichwort = "";
        public CtlKgDokumente()
        {
            InitializeComponent();
        }

        public void Init(int baPersonID)
        {
            Init(baPersonID, 0, ZKBDokumentTypCode.Alle, "");
        }

        public void Init(int baPersonID, int kgBuchungID, ZKBDokumentTypCode zkbDokumentTypCodeToAssign, string stichwort)
        {
            qryKgDokumente.CanInsert = true;
            qryKgDokumente.CanDelete = true;
            qryKgDokumente.CanUpdate = true;

            _baPersonID = baPersonID;
            _kgBuchungID = kgBuchungID;
            _zkbDokumentTypCodeToAssign = zkbDokumentTypCodeToAssign;
            _stichwort = stichwort;
 
            RefreshDoks();
        }

        private void RefreshDoks()
        {
            qryZKBDokumente.Fill(_baPersonID, _kgBuchungID);
            qryKgDokumente.Fill(_baPersonID, _kgBuchungID);
        }

        private void btnDokPool_Click(object sender, EventArgs e)
        {
            DlgKgDokumentenPool dlg = new DlgKgDokumentenPool();

            dlg.Init(_baPersonID, _kgBuchungID, _zkbDokumentTypCodeToAssign, _stichwort);

            dlg.ShowDialog();

            RefreshDoks();
        }

        private void btnDokOeffnen_Click(object sender, EventArgs e)
        {
            DokumentOeffnen();
        }

        private void DokumentOeffnen()
        {
            edtDokumentHidden.DocumentID = qryZKBDokumente["DocumentID"];
            edtDokumentHidden.OpenDoc();
        }

        private void grdZKBDokumente_DoubleClick(object sender, EventArgs e)
        {
            DokumentOeffnen();
        }

        private void btnZuordnungEntfernen_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion("Wollen Sie diese Zuordnung wirklich entfernen?", true))
            {
                DBUtil.ExecSQL("UPDATE KgDokument SET KgBuchungID = NULL WHERE KgDokumentID = {0}", qryZKBDokumente["KgDokumentID"]);
                RefreshDoks();
            }
        }

        private void qryKgDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryKgDokumente["Stichwort"] = _stichwort;
            qryKgDokumente["BaPersonID"] = _baPersonID;

            if (_kgBuchungID > 0)
            {
                qryKgDokumente["KgBuchungID"] = _kgBuchungID;
                qryKgDokumente["KgDokumentTypCode"] = 4;    // 4 = Buchung
            }
            else
            {
                qryKgDokumente["KgDokumentTypCode"] = 6;    // 6 = Mandant
            }

            edtStichwort.Focus();
        }

        private void qryKgDokumente_AfterDelete(object sender, EventArgs e)
        {
            // try to delete XDocument
            try
            {
                var documentID = (int?)qryKgDokumente["DocumentID"];
                if (documentID.HasValue)
                {
                    DBUtil.ExecSQL("DELETE FROM XDocument WHERE DocumentID = {0}", documentID.Value);
                }
            }
            catch 
            {
                // TODO: Log
            }
        }

        private void qryKgDokumente_BeforePost(object sender, EventArgs e)
        {
            if (!qryKgDokumente.IsSilentPostingFromXDocument && DBUtil.IsEmpty(qryKgDokumente["DocumentID"]))
            {
                KissMsg.ShowInfo("Erfassen sie zuerst ein Dokument.");
                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(qryKgDokumente["Stichwort"]))
            {
                qryKgDokumente["Stichwort"] = "-";
            }
        }

        private void btnNewDocument_Click(object sender, EventArgs e)
        {
            qryKgDokumente.Insert();
        }        
    }
}
