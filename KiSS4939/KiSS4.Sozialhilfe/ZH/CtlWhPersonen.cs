using System;
using System.Data;
using System.Drawing;
using System.Linq;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    partial class CtlWhPersonen : KissUserControl
    {
        private readonly int _baPersonID;
        private readonly int _bgFinanzplanID;

        public CtlWhPersonen(Image titelImage, string titelText, int bgFinanzplanID, int baPersonID)
            : this()
        {
            picTitle.Image = titelImage;
            _bgFinanzplanID = bgFinanzplanID;
            _baPersonID = baPersonID;

            qryHeader.Fill(qryHeader.SelectStatement, _bgFinanzplanID, _baPersonID);
            lblTitel.Text = string.Format(lblTitel.Text, qryHeader["FinanzPlanVon"], qryHeader["FinanzPlanBis"], titelText);

            var bgBewilligungStatusCode = qryHeader["BgBewilligungStatusCode"];
            var enable = (bgBewilligungStatusCode == null || (int)bgBewilligungStatusCode < (int)BgBewilligungStatus.Erteilt);

            btnAdd.Enabled = enable;
            btnRemove.Enabled = enable;
            btnAddAll.Enabled = enable;
            btnRemoveAll.Enabled = enable;

            if (!enable)
            {
                grdHaushalt.GridStyle = GridStyleType.ReadOnly;
            }

            RefreshDisplay();
        }

        public CtlWhPersonen()
        {
            InitializeComponent();
        }

        private void RefreshDisplay()
        {
            qryWhKennzahlen.Fill(_bgFinanzplanID);

            qryKlientensystem.Fill(qryKlientensystem.SelectStatement, _bgFinanzplanID, _baPersonID);
            qryHaushalt.Fill(_bgFinanzplanID);
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            var baPersonIDs = (from DataRow row in qryKlientensystem.DataTable.Rows select Convert.ToInt32(row["BaPersonID"])).ToArray();
            if (!CheckPersonFinLeistungAndBerechnungsPerson(baPersonIDs))
            {
                return;
            }

            foreach (DataRow row in qryKlientensystem.DataTable.Rows)
            {
                DBUtil.ExecSQL("INSERT INTO BgFinanzplan_BaPerson (BgFinanzplanID, BaPersonID, IstUnterstuetzt) VALUES ({0}, {1}, {2})",
                               _bgFinanzplanID, row["BaPersonID"], row["MitFinanzLeistung"]);
            }

            DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Update {0}", _bgFinanzplanID);
            RefreshDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (qryKlientensystem.Count == 0)
            {
                return;
            }

            var baPersonID = Convert.ToInt32(qryKlientensystem["BaPersonID"]);
            if (!CheckPersonFinLeistungAndBerechnungsPerson(new[] { baPersonID }))
            {
                return;
            }

            DBUtil.ExecSQL("INSERT INTO BgFinanzplan_BaPerson (BgFinanzplanID, BaPersonID, IstUnterstuetzt) VALUES ({0}, {1}, {2})",
                           _bgFinanzplanID, baPersonID, qryKlientensystem["MitFinanzLeistung"]);

            DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Update {0}", _bgFinanzplanID);
            RefreshDisplay();
        }

        private bool CheckPersonFinLeistungAndBerechnungsPerson(int[] baPersonIDs)
        {
            // Es können nur Personen mit finanziellen Leistungen sowie reguläre
            // Berechnungspersonen in die Berechnungseinheit überführt werden.
            var query = string.Format(@"SELECT 1 FROM BaPerson
                                        WHERE PersonOhneLeistung = 1 -- MitFinanzLeistung = 0
                                            AND IstBerechnungsPerson = 0
                                            AND BaPersonID IN ({0})",
                                        string.Join(",", baPersonIDs));
            var nichtHinzufuegbarePersonen = DBUtil.ExecuteScalarSQL(query);
            if (!DBUtil.IsEmpty(nichtHinzufuegbarePersonen))
            {
                KissMsg.ShowInfo("Verwenden Sie für Personen ohne Leistung bitte die regulär zur Verfügung gestellten Berechnungspersonen.");
                return false;
            }

            return true;
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (qryHaushalt.Count == 0)
            {
                return;
            }

            DBUtil.ExecSQL("DELETE BgFinanzplan_BaPerson WHERE BgFinanzplanID = {0}"
                , _bgFinanzplanID);

            DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Update {0}", _bgFinanzplanID);
            RefreshDisplay();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (qryHaushalt.Count == 0)
            {
                return;
            }

            DBUtil.ExecSQL("DELETE BgFinanzplan_BaPerson WHERE BgFinanzplanID = {0} AND BaPersonID = {1}"
                , _bgFinanzplanID, qryHaushalt["BaPersonID"]);

            DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Update {0}", _bgFinanzplanID);
            RefreshDisplay();
        }

        private void grdHaushalt_DoubleClick(object sender, EventArgs e)
        {
            if (btnRemove.Enabled)
            {
                btnRemove.PerformClick();
            }
        }

        private void grdKlientensystem_DoubleClick(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                btnAdd.PerformClick();
            }
        }

        private void grvHaushalt_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != colIstUnterstuetzt)
            {
                return;
            }

            if (!(bool)qryHaushalt["MitFinanzLeistung"])
            {
                KissMsg.ShowInfo("Die Person " + qryHaushalt["NamePerson"] + " ist ohne finanzielle Leistung, d.h. sie wird nicht unterstützt und kann daher auch nicht selektiert werden.");
            }
        }

        private void repItemIstUnterstuetzt_CheckedChanged(object sender, EventArgs e)
        {
            if (qryHaushalt.CanUpdate && grvHaushalt.FocusedColumn.FieldName == "IstUnterstuetzt")
            {
                qryHaushalt.Post();
                DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Update {0}", _bgFinanzplanID);
                qryWhKennzahlen.Refresh();
            }
        }
    }
}