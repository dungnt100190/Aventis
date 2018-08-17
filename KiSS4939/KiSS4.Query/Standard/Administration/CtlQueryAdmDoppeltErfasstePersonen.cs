using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryAdmDoppeltErfasstePersonen : KissQueryControl
    {
        private const string CLASSNAME = "CtlQueryAdmDoppeltErfasstePersonen";

        #region Constructors

        public CtlQueryAdmDoppeltErfasstePersonen()
        {
            InitializeComponent();

            edtNameCode.EditValue = 1;
            edtVornameCode.EditValue = 1;
            edtGeburtCode.EditValue = 2;

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = dbo.fnGetMLTextFromName({0}, 'erste5ZahlenGleich', {1})
                UNION ALL
                SELECT Code = 2, Text = dbo.fnGetMLTextFromName({0}, 'erste8ZahlenGleich', {1})
                UNION ALL
                SELECT Code = 3, Text = dbo.fnGetMLTextFromName({0}, 'genauGleich', {1})",
                CLASSNAME,
                Session.User.LanguageCode);
            System.Data.DataRow newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtAHVCode.Properties.Columns.Clear();
            edtAHVCode.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtAHVCode.Properties.ShowFooter = false;
            edtAHVCode.Properties.ShowHeader = false;
            edtAHVCode.Properties.DisplayMember = "Text";
            edtAHVCode.Properties.ValueMember = "Code";
            edtAHVCode.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtAHVCode.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = dbo.fnGetMLTextFromName({0}, 'imGleichenJahr', {1})
                UNION ALL
                SELECT Code = 2, Text = dbo.fnGetMLTextFromName({0}, 'genauGleich', {1})",
                CLASSNAME,
                Session.User.LanguageCode);
            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtGeburtCode.Properties.Columns.Clear();
            edtGeburtCode.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtGeburtCode.Properties.ShowFooter = false;
            edtGeburtCode.Properties.ShowHeader = false;
            edtGeburtCode.Properties.DisplayMember = "Text";
            edtGeburtCode.Properties.ValueMember = "Code";
            edtGeburtCode.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtGeburtCode.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = dbo.fnGetMLTextFromName({0}, 'aehnlich', {1})
                UNION ALL
                SELECT Code = 2, Text = dbo.fnGetMLTextFromName({0}, 'genauGleich', {1})",
                CLASSNAME,
                Session.User.LanguageCode);
            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtNameCode.Properties.Columns.Clear();
            edtNameCode.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtNameCode.Properties.ShowFooter = false;
            edtNameCode.Properties.ShowHeader = false;
            edtNameCode.Properties.DisplayMember = "Text";
            edtNameCode.Properties.ValueMember = "Code";
            edtNameCode.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtNameCode.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = dbo.fnGetMLTextFromName({0}, 'aehnlich', {1})
                UNION ALL
                SELECT Code = 2, Text = dbo.fnGetMLTextFromName({0}, 'genauGleich', {1})",
                CLASSNAME,
                Session.User.LanguageCode);
            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtVornameCode.Properties.Columns.Clear();
            edtVornameCode.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtVornameCode.Properties.ShowFooter = false;
            edtVornameCode.Properties.ShowHeader = false;
            edtVornameCode.Properties.DisplayMember = "Text";
            edtVornameCode.Properties.ValueMember = "Code";
            edtVornameCode.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtVornameCode.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = dbo.fnGetMLTextFromName({0}, 'erste5ZahlenGleich', {1})
                UNION ALL
                SELECT Code = 2, Text = dbo.fnGetMLTextFromName({0}, 'erste8ZahlenGleich', {1})
                UNION ALL
                SELECT Code = 3, Text = dbo.fnGetMLTextFromName({0}, 'genauGleich', {1})",
                CLASSNAME,
                Session.User.LanguageCode);
            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtVersNr.Properties.Columns.Clear();
            edtVersNr.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtVersNr.Properties.ShowFooter = false;
            edtVersNr.Properties.ShowHeader = false;
            edtVersNr.Properties.DisplayMember = "Text";
            edtVersNr.Properties.ValueMember = "Code";
            edtVersNr.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtVersNr.Properties.DataSource = qry;
        }

        #endregion

        #region EventHandlers

        private void btnDatenbereinigung_Click(object sender, EventArgs e)
        {
            int? prs1ID = (int?)qryQuery["BaPersonID_A$"];
            int? prs2ID = (int?)qryQuery["BaPersonID_B$"];

            if (prs1ID.HasValue && prs2ID.HasValue)
            {
                FormController.OpenForm("FrmDataCorrection", "Action", "ShowDoublePerson", "BaPersonID_A", prs1ID, "BaPersonID_B", prs2ID);
            }
        }

        private void btnStammdatenAB_Click(object sender, EventArgs e)
        {
            int? prs1ID = (int?)qryQuery["BaPersonID_A$"];
            int? prs2ID = (int?)qryQuery["BaPersonID_B$"];

            if (prs1ID.HasValue)
            {
                FormController.OpenForm("FrmFall", "Action", "ShowFall", "BaPersonID", prs1ID, "ModulID", ModulID.B);
            }
            if (prs2ID.HasValue)
            {
                FormController.OpenForm("FrmFall", "Action", "ShowFall", "BaPersonID", prs2ID, "ModulID", ModulID.B);
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtNameCode.EditValue = 1;
            edtVornameCode.EditValue = 1;
            edtGeburtCode.EditValue = 2;
        }

        #endregion

        #endregion
    }
}