using System;
using System.Data;

using KiSS4.Common;
using KiSS4.DB;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace KiSS4.Query.ITT
{
    public partial class CtlQueryVmSaldoabfrage : KissQueryControl
    {
        #region Constructors

        public CtlQueryVmSaldoabfrage()
        {
            InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT Code, Text
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'FbPeriodeStatus'
                UNION ALL
                SELECT Code = 9999, Text = 'aktiv oder inaktiv'; --- dummy code");
            DataRow newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();

            edtFbPeriodeStatusCode.Properties.Columns.Clear();
            edtFbPeriodeStatusCode.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo("Text", "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });

            edtFbPeriodeStatusCode.Properties.ShowFooter = false;
            edtFbPeriodeStatusCode.Properties.ShowHeader = false;
            edtFbPeriodeStatusCode.Properties.DisplayMember = "Text";
            edtFbPeriodeStatusCode.Properties.ValueMember = "Code";
            edtFbPeriodeStatusCode.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtFbPeriodeStatusCode.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(@"
                SELECT Code = FbTeamID, Text = Name
                FROM dbo.FbTeam WITH(READUNCOMMITTED)
                UNION ALL
                SELECT Code = 9999, Text = 'Alle ohne Erbschaftsbuchhaltung' --- dummy code
                ORDER BY Name;");
            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();

            edtFbTeamID.Properties.Columns.Clear();
            edtFbTeamID.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo("Text", "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });

            edtFbTeamID.Properties.ShowFooter = false;
            edtFbTeamID.Properties.ShowHeader = false;
            edtFbTeamID.Properties.DisplayMember = "Text";
            edtFbTeamID.Properties.ValueMember = "Code";
            edtFbTeamID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtFbTeamID.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = 'Aktiven'
                UNION ALL
                SELECT Code = 2, Text = 'Passiven'
                UNION ALL
                SELECT Code = 3, Text = 'Aktiven + Passiven'
                UNION ALL
                SELECT Code = 4, Text = 'Depot-Konti'
                UNION ALL
                SELECT Code = 5, Text = 'Transfer-Konti'
                UNION ALL
                SELECT Code = 6, Text = 'Aktiven ohne Depot-Konti'
                UNION ALL
                SELECT Code = 7, Text = 'nur Konto 110000 Kasse'
                UNION ALL
                SELECT Code = 8, Text = 'nur Konto 110001 Post'
                UNION ALL
                SELECT Code = 9, Text = 'Monatssaldo Post';");
            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();

            edtKontoGruppeCode.Properties.Columns.Clear();
            edtKontoGruppeCode.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo("Text", "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });

            edtKontoGruppeCode.Properties.ShowFooter = false;
            edtKontoGruppeCode.Properties.ShowHeader = false;
            edtKontoGruppeCode.Properties.DisplayMember = "Text";
            edtKontoGruppeCode.Properties.ValueMember = "Code";
            edtKontoGruppeCode.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtKontoGruppeCode.Properties.DataSource = qry;
        }

        #endregion
    }
}