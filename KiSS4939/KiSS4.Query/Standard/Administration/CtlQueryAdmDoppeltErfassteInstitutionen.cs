using System;
using System.Data;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryAdmDoppeltErfassteInstitutionen : KissQueryControl
    {
        private const string CLASSNAME = "CtlQueryAdmDoppeltErfassteInstitutionen";

        #region Constructors

        public CtlQueryAdmDoppeltErfassteInstitutionen()
        {
            InitializeComponent();

            string qrystr = @"
                SELECT Code = 1, Text = dbo.fnGetMLTextFromName({0}, 'aehnlich', {1})
                UNION ALL
                SELECT CODE = 2, Text = dbo.fnGetMLTextFromName({0}, 'genauGleich', {1})";

            var qry = DBUtil.OpenSQL(qrystr, CLASSNAME, Session.User.LanguageCode);

            DataRow newRow = qry.DataTable.NewRow();
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

            qry = DBUtil.OpenSQL(qrystr, CLASSNAME, Session.User.LanguageCode);

            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtOrtCode.Properties.Columns.Clear();
            edtOrtCode.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtOrtCode.Properties.ShowFooter = false;
            edtOrtCode.Properties.ShowHeader = false;
            edtOrtCode.Properties.DisplayMember = "Text";
            edtOrtCode.Properties.ValueMember = "Code";
            edtOrtCode.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrtCode.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(qrystr, CLASSNAME, Session.User.LanguageCode);

            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtStrasseCode.Properties.Columns.Clear();
            edtStrasseCode.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtStrasseCode.Properties.ShowFooter = false;
            edtStrasseCode.Properties.ShowHeader = false;
            edtStrasseCode.Properties.DisplayMember = "Text";
            edtStrasseCode.Properties.ValueMember = "Code";
            edtStrasseCode.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtStrasseCode.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(qrystr, CLASSNAME, Session.User.LanguageCode);

            newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtTelefonCode.Properties.Columns.Clear();
            edtTelefonCode.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtTelefonCode.Properties.ShowFooter = false;
            edtTelefonCode.Properties.ShowHeader = false;
            edtTelefonCode.Properties.DisplayMember = "Text";
            edtTelefonCode.Properties.ValueMember = "Code";
            edtTelefonCode.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtTelefonCode.Properties.DataSource = qry;
        }

        #endregion

        #region EventHandlers

        private void btnDatenbereinigung_Click(object sender, EventArgs e)
        {
            int? inst1ID = (int?)qryQuery["BaInstitutionID_A$"];
            int? inst2ID = (int?)qryQuery["BaInstitutionID_B$"];

            if (inst1ID.HasValue && inst2ID.HasValue)
            {
                FormController.OpenForm("FrmDataCorrection", "Action", "ShowDoubleOrganisation", "BaInstitutionID_A", inst1ID, "BaInstitutionID_B", inst2ID);
            }
        }

        #endregion
    }
}