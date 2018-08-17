using System;
using System.Data;
using KiSS4.DB;

namespace KiSS4.Query.ZH
{
    public partial class CtlQuerySiLeiVerjaehrteLoeschen : KiSS4.Common.KissQueryControl
    {
        public CtlQuerySiLeiVerjaehrteLoeschen()
        {
            InitializeComponent();

            edtJahr.EditValue = DateTime.Today.Year - 10;
            grvQuery1.OptionsBehavior.Editable = true;
        }

        protected override void RunSearch()
        {
            if (!(edtJahr.EditValue is int))
            {
                throw new KissErrorException(KissMsg.GetMLMessage("CtlQuerySiLeiVerjaehrteLoeschen", "Keine Zahl", "Bitte geben Sie ein gültiges Jahr ein"));
            }
            if ((int)edtJahr.EditValue > DateTime.Today.Year - 10)
            {
                throw new KissErrorException(KissMsg.GetMLMessage("CtlQuerySiLeiVerjaehrteLoeschen", "WenigerAls10Jahre", "Es dürfen nur Sicherheitsleistungen gelöscht werden, deren letzte Buchung mehr als 10 Jahre zurückliegen"));
            }

            base.RunSearch();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DataRow[] selectedRows = qryQuery.DataTable.Select("Selected = 1");
            if (selectedRows == null || selectedRows.Length == 0)
            {
                KissMsg.ShowInfo("CtlQuerySiLeiVerjaehrteLoeschen", "KeineSiLeiSelektiert", "Es sind keine Sicherheitsleistungen selektiert.");
                return;
            }

            int count = selectedRows.Length;
            if (!KissMsg.ShowQuestion("CtlQuerySiLeiVerjaehrteLoeschen", "WirklichAlleLoeschen", "Wollen Sie wirklich die angezeigten {0} Sicherheitsleistungen löschen?", true, count))
                return;

            foreach (DataRow row in selectedRows)
            {
                int baSicherheitsleistungID = (int)row["BaSicherheitsleistungID$"];
                DBUtil.ExecSQL(@"UPDATE BaSicherheitsleistung
                                 SET Geloescht = 1
                                 WHERE BaSicherheitsleistungID = {0}", baSicherheitsleistungID);
            }
            KissMsg.ShowInfo("CtlQuerySiLeiVerjaehrteLoeschen", "ErfolgreichGeloescht", "{0} Sicherheitsleistungen wurden erfolgreich gelöscht", count);
            qryQuery.Refresh();
        }

        private void btnAlle_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryQuery.DataTable.Rows)
                row["Selected"] = 1;
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryQuery.DataTable.Rows)
                row["Selected"] = 0;
        }
    }
}
