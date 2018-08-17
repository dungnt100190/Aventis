using System;
using System.Drawing;
using System.Linq;

using KiSS4.Common;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlKbBilanzErfolg : KissSearchUserControl
    {
        #region Constructors

        public CtlKbBilanzErfolg()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlKbBilanzErfolg_Load(object sender, EventArgs e)
        {
            lblMandant.Text = "";
            NewSearch();
        }

        private void grvBilanz_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (((e.Column.FieldName == "Saldo") || (e.Column.FieldName == "KontoName")) &&
                (grvBilanz.GetRowCellValue(e.RowHandle, grvBilanz.Columns["KontoNr"]) == DBNull.Value))
            {
                e.Appearance.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            }
            else
            {
                e.Appearance.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel, 0);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "KBPERIODEID":
                    return qryPeriodeX.Count > 0 ? qryPeriodeX["KbPeriodeID"] : DBNull.Value;

                case "NURMITBUCHUNGEN":
                    return edtNurMitBuchungen.Checked;

                case "PERDATUM":
                    return edtPerDatum.EditValue;
            }

            return base.GetContextValue(fieldName);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            tabControlSearch.SelectedTabIndex = 1;
            qryPeriodeX.DataTable.Rows.Clear();

            foreach (var ctl in tpgSuchen.Controls.OfType<BaseEdit>())
            {
                (ctl).EditValue = null;
            }

            edtNurMitBuchungen.Checked = true;
        }

        #endregion

        #endregion
    }
}