using System;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryVmFristKategorisierung : KissQueryControl
    {
        #region Constructors

        public CtlQueryVmFristKategorisierung()
        {
            InitializeComponent();

            // Modul
            //KES und V zusammen nehmen
            var qry = DBUtil.OpenSQL(@"
                SELECT [Code] = '5,29',
                       [Text] = 'KES'
                UNION ALL
                SELECT [Code] = CONVERT(VARCHAR, ModulID),
                       [Text] = [Name]
                FROM dbo.XModul WITH(READUNCOMMITTED)
                WHERE ModulID > 1
                  AND ModulID NOT IN (5, 29)
                  AND ModulTree = 1
                  AND Licensed = 1
                ORDER BY 1;");
            var newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtModulID.Properties.Columns.Clear();
            edtModulID.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo("Text", "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });
            edtModulID.Properties.ShowFooter = false;
            edtModulID.Properties.ShowHeader = false;
            edtModulID.Properties.DisplayMember = "Text";
            edtModulID.Properties.ValueMember = "Code";
            edtModulID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtModulID.Properties.DataSource = qry;

            // Sektion
            qry = DBUtil.OpenSQL(@"
                SELECT Code   = OrgUnitID,
                       [Text] = ItemName
                FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                ORDER BY ItemName");
            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo("Text", "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrgUnitID.Properties.DataSource = qry;

            edtProzess.LOVFilter = "Code<>400";
            edtProzess.ReadLOV();
        }

        #endregion

        private void edtModulID_EditValueChanged(object sender, EventArgs e)
        {
            var modulID = edtModulID.EditValue.ToString();
            string lovFilter;

            if (string.IsNullOrEmpty(modulID))
            {
                //nur ProzessCode 400: Abklärung filtern (ist gemäss Abfrage-SQL grundsätzlich unerwünscht)
                lovFilter = "Code<>400";
            }
            else
            {
                //filter analog Query
                lovFilter = "(Value3 IN ({0}) OR (4 IN ({0}) AND Code<>400 AND Value3 IS NULL))";
                lovFilter = string.Format(lovFilter, modulID);
            }

            edtProzess.LOVFilter = lovFilter;
            edtProzess.ReadLOV();
            edtProzess.EditValue = null;
        }
    }
}