using System;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.CAR
{
    public partial class CtlQueryBaKlientenlisteIBE : KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly string _tpgListeTitle;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryBaKlientenlisteIBE()
        {
            InitializeComponent();

            SetSektionListe();
            _tpgListeTitle = tpgListe.Title;
        }

        #endregion

        #region EventHandlers

        private void CtlQueryBaKlientenlisteIBE_Load(object sender, EventArgs e)
        {
            tpgListe.Title = _tpgListeTitle;
        }

        private void edtBaPersonID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SearchPersonOrUser(true, edtBaPersonID, "Name", "BaPersonID", e);
        }

        private void edtUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SearchPersonOrUser(false, edtUserID, "Name", "UserID", e);
        }

        private void grvQuery1_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {
                var view = (GridView)sender;
                var item = (GridColumnSummaryItem)e.Item;

                var value = view.GetRowCellValue(e.RowHandle, item.FieldName);

                //sicherstellen, dass auch wenn nur Leer-Werte vorkommen, Total = 0 angezeigt wird.
                e.TotalValue = e.TotalValue ?? 0;

                if (!DBUtil.IsEmpty(value))
                {
                    var old = (int?)e.TotalValue;
                    e.TotalValue = old + 1;
                }
            }
        }

        private void grvWohnstatus_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SetGotoFallBaPersonID(e.FocusedRowHandle);
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            SetupDataSourceAndGridColumns(grdWohnstatus, qryQuery.DataSet.Tables[1]);
            SetupDataSourceAndGridColumns(grdKlientenzahlen, qryQuery.DataSet.Tables[2]);
            SetGotoFallBaPersonID(0);
            grvWohnstatus.FocusedRowChanged += grvWohnstatus_FocusedRowChanged;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            if (tabControlSearch.IsTabSelected(tpgSuchen))
            {
                return;
            }

            qryQuery.Refresh();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            edtDatumWohnstatusBis.EditValue = DateTime.Today;
            edtStichdatum.EditValue = DateTime.Today;
            base.NewSearch();
        }

        #endregion

        #region Private Static Methods

        private static void SearchPersonOrUser(bool searchPerson, KissButtonEdit edt, string editValue, string lookupId, UserModifiedFldEventArgs e)
        {
            var searchString = edt.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edt.EditValue = null;
                    edt.LookupID = null;
                    return;
                }
            }

            var dlg = new DlgAuswahl();
            if (searchPerson)
            {
                e.Cancel = !dlg.PersonSuchen(searchString, e.ButtonClicked);
            }
            else
            {
                e.Cancel = !dlg.MitarbeiterSuchen(searchString, e.ButtonClicked);
            }

            if (!e.Cancel)
            {
                edt.EditValue = dlg[editValue];
                edt.LookupID = dlg[lookupId];
            }
        }

        #endregion

        #region Private Methods

        private void SetGotoFallBaPersonID(int rowHandle)
        {
            ctlGotoFallWohnstatus.BaPersonID = grvWohnstatus.GetRowCellValue(rowHandle, "BaPersonID$");
        }

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