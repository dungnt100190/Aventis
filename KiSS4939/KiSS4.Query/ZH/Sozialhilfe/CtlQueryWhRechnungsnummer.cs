using System;
using System.Data;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace KiSS4.Query.ZH
{
    public partial class CtlQueryWhRechnungsnummer : KissQueryControl
    {
        #region Constructors

        public CtlQueryWhRechnungsnummer()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnBudgetPosition_Click(object sender, EventArgs e)
        {
            string jumpToPath = string.Format(
                "ClassName=FrmFall;" +
                "BaPersonID={0};" +
                "ModulID=3;" +
                "TreeNodeID=CtlWhFinanzplan{1}\\BBG{2};" +
                "ActiveSQLQuery.Find=BgPositionID = {3};",
                qryQuery["BaPersonID_FAL"],
                qryQuery["BgFinanzplanID"],
                qryQuery["BgBudgetID"],
                qryQuery["BgPositionID"]);

            var dic = FormController.ConvertToDictionary(jumpToPath);
            FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
        }

        private void grdDocuments_DoubleClick(object sender, EventArgs e)
        {
            xDocument.OpenDoc();
        }

        private void grdQuery1_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            var view = e.View as GridView;

            if (view != null)
            {
                view.BestFitColumns();
            }
        }

        private void qryDocuments_AfterFill(object sender, EventArgs e)
        {
            grdDocuments.View.BestFitColumns();
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            var ds = qryQuery.DataSet;
            ds.EnforceConstraints = false;
            ds.Relations.Add("PositionDetail", ds.Tables[0].Columns["BgPositionID"], ds.Tables[1].Columns["BgPositionID_Parent"]);

            grdQuery1.View.BestFitColumns();
        }

        private void qryQuery_PositionChanged(object sender, EventArgs e)
        {
            qryDocuments.Fill(qryQuery["BgPositionID"]);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            //Defaultwert setzen (Heute vor einem Jahr)
            edtSucheRechnungDatum.EditValue = DateTime.Today.AddYears(-1);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Buchungsstatus laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;

            var qryStati = DBUtil.OpenSQL(@"
                 SELECT Text, Code, Value1
                 FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                 WHERE LOVName = 'KbBuchungsStatus'
                 ORDER BY SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(
                    new ImageComboBoxItem(
                        string.Empty,
                        (int)row["Code"],
                        KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }
            colDetailStatus.ColumnEdit = repositoryItemImageComboBox1;

            // Dokument-Typ LOV laden
            colTyp.ColumnEdit = grdDocuments.GetLOVLookUpEdit("BgDokumentTyp");

            // DataSource per Code setzen, da sonst vom KissQueryControl ein Fill beim RunSearch ausgeführt wird (ohne Parameter)..
            grdDocuments.DataSource = qryDocuments;
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtSucheRechnungsnummer, lblRechnungsnummer.Text);
            DBUtil.CheckNotNullField(edtSucheRechnungDatum, lblRechnungDatum.Text);

            base.RunSearch();
        }

        #endregion

        #endregion
    }
}