using System;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryIkFallfuehrungGesamt : KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly string _tpgListeTitle;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryIkFallfuehrungGesamt()
        {
            InitializeComponent();
            _tpgListeTitle = tpgListe.Title;
        }

        #endregion

        #region EventHandlers

        private void CtlQueryIkFallfuehrungGesamt_Load(object sender, EventArgs e)
        {
            tpgListe.Title = _tpgListeTitle;
            InitializeDropDown();
        }

        private void edtAbschlussImZaitraum_CheckedChanged(object sender, EventArgs e)
        {
            if (edtAbschlussImZeitraum.Checked)
            {
                edtInkassoVon.EditMode = EditModeType.Required;
                edtInkassoBis.EditMode = EditModeType.Required;
            }
            else
            {
                edtInkassoVon.EditMode = EditModeType.Normal;
                edtInkassoBis.EditMode = EditModeType.Normal;
            }
        }

        private void edtIkFaelleOrGlaeubiger_EditValueChanged(object sender, EventArgs e)
        {
            SetVisibleTab();
        }

        private void edtUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        private void grvGlaeubiger_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SetGotoFallBaPersonID(e.FocusedRowHandle);
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            SetupDataSourceAndGridColumns(grdQuery2, qryQuery.DataSet.Tables[1]);
            SetGotoFallBaPersonID(0);
            grvGlaeubiger.FocusedRowChanged += grvGlaeubiger_FocusedRowChanged;
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page.HideTab && page == tpgListe)
            {
                tabControlSearch.SelectTab(tpgListe2);
            }

            if (page.HideTab && page == tpgListe2)
            {
                tabControlSearch.SelectTab(tpgListe);
            }

            if (page == tpgSuchen)
            {
                qryQuery.DataSet.Clear();
                qryQuery.AfterFill -= qryQuery_AfterFill;
                qryQuery.AfterFill += qryQuery_AfterFill;
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void RunSearch()
        {
            // Daten von vorherige Suche löschen
            ClearDataSourceAndColumns();
            grdQuery1.DataSource = qryQuery;

            // Mussfeldern prüfen
            if (edtAbschlussImZeitraum.Checked)
            {
                DBUtil.CheckNotNullField(edtInkassoVon, lblZeitraumInkasso.Text);
                DBUtil.CheckNotNullField(edtInkassoBis, lblZeitraumInkasso.Text);
            }

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void ClearDataSourceAndColumns()
        {
            grdQuery1.DataSource = null;
            grdQuery2.DataSource = null;
            grvQuery1.Columns.Clear();
            grvGlaeubiger.Columns.Clear();

            foreach (DataTable table in qryQuery.DataSet.Tables)
            {
                table.Columns.Clear();
            }
        }

        private void InitializeDropDown()
        {
            var qry = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = {0} UNION ALL
                SELECT Code = 2, Text = {1};",
                tpgListe.Title,
                tpgListe2.Title);

            const string colText = "Text";

            if (edtIkFaelleOrGlaeubiger.AllowNull)
            {
                var newRow = qry.DataTable.NewRow();
                newRow[colText] = "";
                qry.DataTable.Rows.InsertAt(newRow, 0);
                newRow.AcceptChanges();
            }

            edtIkFaelleOrGlaeubiger.Properties.Columns.Clear();
            edtIkFaelleOrGlaeubiger.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo(colText, "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });
            edtIkFaelleOrGlaeubiger.Properties.ShowFooter = false;
            edtIkFaelleOrGlaeubiger.Properties.ShowHeader = false;
            edtIkFaelleOrGlaeubiger.Properties.DisplayMember = colText;
            edtIkFaelleOrGlaeubiger.Properties.ValueMember = "Code";
            edtIkFaelleOrGlaeubiger.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtIkFaelleOrGlaeubiger.Properties.DataSource = qry;
        }

        private void SetGotoFallBaPersonID(int rowHandle)
        {
            ctlGotoFallGlaeubiger.BaPersonID = grvGlaeubiger.GetRowCellValue(rowHandle, "BaPersonID$");
        }

        private void SetVisibleTab()
        {
            if (DBUtil.IsEmpty(edtIkFaelleOrGlaeubiger.EditValue))
            {
                tpgListe.HideTab = false;
                tpgListe2.HideTab = false;
            }
            else if (edtIkFaelleOrGlaeubiger.EditValue as int? == 1)
            {
                tpgListe.HideTab = false;
                tpgListe2.HideTab = true;
            }
            else if (edtIkFaelleOrGlaeubiger.EditValue as int? == 2)
            {
                tpgListe.HideTab = true;
                tpgListe2.HideTab = false;
            }
        }

        #endregion

        private void lblIkFaelleOrGlaeubiger_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}