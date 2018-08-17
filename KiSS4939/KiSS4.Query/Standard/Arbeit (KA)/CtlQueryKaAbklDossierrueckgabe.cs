using System;

using KiSS4.Common;
using KiSS4.DB;

using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace KiSS4.Query
{
    public partial class CtlQueryKaAbklDossierrueckgabe : KissQueryControl
    {
        #region Constructors

        public CtlQueryKaAbklDossierrueckgabe()
        {
            InitializeComponent();
            ResetDatumVonBis();
        }

        #endregion

        #region EventHandlers

        private void grvRohdaten_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SetGotoFallBaPersonID(e.FocusedRowHandle, ctlGotoFallDossierrueckgabe, grvRohdaten);
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            grdRohdaten.DataSource = qryQuery.DataSet.Tables[1];
            grvRohdaten.BestFitColumns();
            SetGotoFallBaPersonID(0, ctlGotoFallDossierrueckgabe, grvRohdaten);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            ResetDatumVonBis();
        }

        protected override void RunSearch()
        {
            if (DBUtil.IsEmpty(edtDatumVon.EditValue))
            {
                edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            }

            if (DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                edtDatumBis.EditValue = DateTime.Today;
            }

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void ResetDatumVonBis()
        {
            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumBis.EditValue = DateTime.Today;
        }

        private void SetGotoFallBaPersonID(int rowHandle, CtlGotoFall gotoFall, GridView grv)
        {
            gotoFall.BaPersonID = grv.GetRowCellValue(rowHandle, "BaPersonID$");
        }

        #endregion

        #endregion
    }
}