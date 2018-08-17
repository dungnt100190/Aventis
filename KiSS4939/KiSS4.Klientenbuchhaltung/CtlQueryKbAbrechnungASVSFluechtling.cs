using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlQueryKbAbrechnungASVSFluechtling : KissQueryControl
    {
        #region Fields

        #region Private Fields

        private int _kbPeriodeID;
        private DateTime _periodeBis;
        private DateTime _periodeVon;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryKbAbrechnungASVSFluechtling()
        {
            InitializeComponent();
            SetSektionListe();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryKbAbrechnungASVS_Load(object sender, EventArgs e)
        {
            _kbPeriodeID = (int)FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID");

            _periodeVon = Utils.ConvertToDateTime(
                DBUtil.ExecuteScalarSQL(
                    @"SELECT PeriodeVon
                      FROM KbPeriode
                      WHERE KbPeriodeID = {0};",
                    _kbPeriodeID));
            _periodeBis = Utils.ConvertToDateTime(
                DBUtil.ExecuteScalarSQL(
                    @"SELECT PeriodeBis
                      FROM KbPeriode
                      WHERE KbPeriodeID = {0};",
                    _kbPeriodeID));

            kissSearch.SelectParameters = new object[] { _kbPeriodeID, Session.User.LanguageCode };
            grdQuery1.DataSource = null;

            NewSearch();
        }

        private void grdQuery1_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtBelegDatumVonX.Text, edtBelegDatumBisX.Text);
            grdQuery1.SetHeaderAndFooterText(
                e,
                KissMsg.GetMLMessage("CtlQueryKbAbrechnungASVSFluechtling", "KbAbrechnungASVFluechtling", "Abrechnung ASV Flüchtling"),
                footerTextLeft
                );
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            grdQuery1.DataSource = qryQuery;
            SetupGridColumns(grdQuery1);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            tabControlSearch.SelectedTabIndex = 1;

            edtBelegDatumVonX.EditValue = _periodeVon;
            edtBelegDatumBisX.EditValue = _periodeBis;
        }

        #endregion

        #region Private Methods

        private void SetSektionListe()
        {
            var qry =
                DBUtil.OpenSQL(
                    @"
                    SELECT Code = OrgUnitID,
                           Text = ItemName
                    FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                    ORDER BY ItemName");
            var newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();

            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo(
                        "Text", "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrgUnitID.Properties.DataSource = qry;
        }

        #endregion

        #endregion
    }
}