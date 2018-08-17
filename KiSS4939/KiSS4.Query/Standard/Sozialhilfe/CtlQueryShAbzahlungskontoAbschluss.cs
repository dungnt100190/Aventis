using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace KiSS4.Query
{
    public partial class CtlQueryShAbzahlungskontoAbschluss : KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string BA_PERSON_ID = "BaPersonID$";
        private const string BG_SPEZKONTO_ID = "BgSpezkontoID$";
        private const string FA_LEISTUNG_ID = "FaLeistungID$";

        #endregion

        #endregion

        #region Constructors

        public CtlQueryShAbzahlungskontoAbschluss()
        {
            InitializeComponent();

            InitializeOrgUnit();
            InitializeAbschlussgrund();
            InitializeEinzelzehlungen();

            kissSearch.SelectParameters = new object[] {Session.User.LanguageCode};
        }

        #endregion

        #region EventHandlers

        private void btnGotoSpezkonto_Click(object sender, EventArgs e)
        {
            var find = string.Format("{0} = {1}", DBO.BgSpezkonto.BgSpezkontoID, qryQuery[BG_SPEZKONTO_ID]);
            var treeNodeId = string.Format("CtlWhLeistung{0}/CtlWhSpezialkonto3", qryQuery[FA_LEISTUNG_ID]);

            FormController.OpenForm(
                "FrmFall",
                "Action", "JumpToPath",
                "ModulID", 3,
                "ActiveSQLQuery.Find", find,
                "BaPersonID", qryQuery[BA_PERSON_ID],
                "TreeNodeID", treeNodeId,
                "FaLeistungID", qryQuery[FA_LEISTUNG_ID],
                "FaFallID", qryQuery[BA_PERSON_ID],
                "BgSpezkontoID", qryQuery[BG_SPEZKONTO_ID]);
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static void InitializeLov(KissLookUpEdit edt, SqlQuery qry)
        {
            const string colText = "Text";
            var newRow = qry.DataTable.NewRow();
            newRow[colText] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edt.Properties.Columns.Clear();
            edt.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo(colText, "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });
            edt.Properties.ShowFooter = false;
            edt.Properties.ShowHeader = false;
            edt.Properties.DisplayMember = colText;
            edt.Properties.ValueMember = "Code";
            edt.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edt.Properties.DataSource = qry;
        }

        #endregion

        #region Private Methods

        private void InitializeAbschlussgrund()
        {
            var qry = DBUtil.OpenSQL(@"
                SELECT Code,
                       [Text],
                       SortKey
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'AbzahlungskontoAbschlussgrund'

                UNION ALL

                SELECT Code    = 0,
                       [Text]  = {0},
                       SortKey = MAX(SortKey) + 1
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'AbzahlungskontoAbschlussgrund'
                ORDER BY SortKey;",
                KissMsg.GetMLMessage(Name, "nochNichtAbgeschlossen", "noch nicht abgeschlossen"));

            InitializeLov(edtAbschlussgrund, qry);
        }

        private void InitializeEinzelzehlungen()
        {
            var qry = DBUtil.OpenSQL(@"
                SELECT Code   = 1, [Text] = {0}
                UNION ALL
                SELECT Code   = 2, [Text] = {1}",
                KissMsg.GetMLMessage(Name, "VerrechnungMitEinzelzahlung", "Verrechnung mit Einzelzahlung"),
                KissMsg.GetMLMessage(Name, "VerrechnungOhneEinzelzahlung", "Verrechnung ohne Einzelzahlung"));

            InitializeLov(edtEinzelzahlungen, qry);
        }

        private void InitializeOrgUnit()
        {
            var qry = DBUtil.OpenSQL(@"
                SELECT Code = OrgUnitID,
                       Text = ItemName
                FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                ORDER BY ItemName;");

            InitializeLov(edtOrgUnitID, qry);
        }

        #endregion

        #endregion
    }
}