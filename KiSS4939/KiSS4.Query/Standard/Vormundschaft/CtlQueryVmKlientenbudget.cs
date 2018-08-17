using System;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace KiSS4.Query
{
    public partial class CtlQueryVmKlientenbudget : KissQueryControl
    {
        #region Constructors

        public CtlQueryVmKlientenbudget()
        {
            InitializeComponent();
            SetStatusListe();
        }

        #endregion

        #region EventHandlers

        private void btnGotoVmKlientenbudget_Click(object sender, EventArgs e)
        {
            var controller = Kiss.Infrastructure.IoC.Container.Resolve<IKissFormController>();

            var pfadTreeNode = String.Format(@"CtlVmProzess{0}/50006/Kiss.UI.View.Vm.VmKlientenbudgetView.xaml", qryQuery["FaLeistungID$"]);

            controller.OpenForm(
                "FrmFall",
                "Action", "JumpToPath",
                "BaPersonID", qryQuery["BaPersonID$"],
                "ModulID", 5,
                "TreeNodeID", pfadTreeNode,
                "VmKlientenbudgetID", qryQuery["VmKlientenbudgetID$"]);
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            btnGotoVmKlientenbudget.Enabled = !qryQuery.IsEmpty;
        }

        #endregion

        #region Methods

        #region Private Methods

        private void SetStatusListe()
        {
            var qry =
                DBUtil.OpenSQL(
                    @"
                    SELECT Code = Code,
                           Text = Text
                    FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                    WHERE LOVName = 'VmKlientenbudgetStatus'
                      AND Code <> {0}
                    ORDER BY SortKey;",
                    (int)LOVsGenerated.VmKlientenbudgetStatus.Archiviert);
            var newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();

            edtKlientenbudgetStatus.Properties.Columns.Clear();
            edtKlientenbudgetStatus.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo(
                        "Text", "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });
            edtKlientenbudgetStatus.Properties.ShowFooter = false;
            edtKlientenbudgetStatus.Properties.ShowHeader = false;
            edtKlientenbudgetStatus.Properties.DisplayMember = "Text";
            edtKlientenbudgetStatus.Properties.ValueMember = "Code";
            edtKlientenbudgetStatus.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtKlientenbudgetStatus.Properties.DataSource = qry;
        }

        #endregion

        #endregion
    }
}