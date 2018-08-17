using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using KiSS4.Common;
using KiSS4.DB;
using System;

namespace KiSS4.Query.BSS
{
    public partial class CtlQueryStatFallentwicklungKes : KissQueryControl
    {
        public CtlQueryStatFallentwicklungKes()
        {
            InitializeComponent();
            var qry = DBUtil.OpenSQL(@"
                SELECT Code = OrgUnitID,
                       Text = ItemName
                FROM dbo.XOrgUnit WITH(READUNCOMMITTED)
                ORDER BY ItemName;");
            var newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.Add(new LookUpColumnInfo("Text", "", 75, FormatType.None, "", true, HorzAlignment.Default));
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrgUnitID.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = 'Präventionen' UNION ALL
                SELECT Code = 2, Text = 'Abklärungen/Auftrag' UNION ALL
                SELECT Code = 3, Text = 'Massnahmeführung' UNION ALL
                SELECT Code = 4, Text = 'Pflegekinderaufsicht';");
            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtProzess.Properties.Columns.Clear();
            edtProzess.Properties.Columns.Add(new LookUpColumnInfo("Text", "", 75, FormatType.None, "", true, HorzAlignment.Default));
            edtProzess.Properties.ShowFooter = false;
            edtProzess.Properties.ShowHeader = false;
            edtProzess.Properties.DisplayMember = "Text";
            edtProzess.Properties.ValueMember = "Code";
            edtProzess.Properties.DataSource = qry;
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumvon.Text);
            DBUtil.CheckNotNullField(edtDatumBis, lblbis.Text);

            base.RunSearch();
        }

        private void gridView_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            var table = sender == grvListe2 ? qryListe2.DataSet.Tables[0] : qryListe2.DataSet.Tables[1];
            var row1 = table.Rows[e.ListSourceRowIndex1];
            var row2 = table.Rows[e.ListSourceRowIndex2];
            var value1 = row1["SortKey"] as int?;
            var value2 = row2["SortKey"] as int?;
            if (value1.HasValue && value2.HasValue)
            {
                e.Result = value1.Value.CompareTo(value2.Value);
                e.Handled = true;
            }
        }

        private void qryListe2_AfterFill(object sender, EventArgs e)
        {
            grdListe3.DataSource = qryListe2.DataSet.Tables[1];
            grvListe2.BestFitColumns();
            grvListe3.BestFitColumns();
        }
    }
}