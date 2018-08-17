using System;
using System.Linq;

using DevExpress.XtraGrid.Columns;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryKaReportingSemo : KissQueryControl
    {
        public CtlQueryKaReportingSemo()
        {
            InitializeComponent();
        }

        protected override void NewSearch()
        {
            base.NewSearch();
            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumVon.Focus();
        }

        protected override void RunSearch()
        {
            ResetSelectColumns();

            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtDatumBis, lblDatumBis.Text);

            var datumVon = (DateTime)edtDatumVon.EditValue;
            var datumBis = (DateTime)edtDatumBis.EditValue;

            if (datumVon > datumBis)
            {
                throw new KissInfoException("Das Datum von darf nicht nach dem Datum bis liegen.", lblDatumVon);
            }

            if (datumVon.Year != datumBis.Year)
            {
                // Datumsbereich ist Jahresübergreifend
                var span = datumBis - datumVon;
                var zeroTime = new DateTime(1, 1, 1);
                var differenceTime = zeroTime + span;
                var yearDifference = differenceTime.Year - 1;

                if (yearDifference > 0)
                {
                    throw new KissInfoException("Datum von und Datum bis dürfen nicht mehr als ein Jahr auseinander liegen.", edtDatumVon);
                }

                if (datumVon.Month == datumBis.Month)
                {
                    // Daten sind weniger als ein Jahr auseinander, Datum von und bis liegen aber im selben Monat
                    throw new KissInfoException("Datum von und Datum bis dürfen nicht im selben Monat liegen.", edtDatumVon);
                }
            }

            base.RunSearch();
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tpgListe)
            {
                foreach (var col in grdQuery1.View.Columns.Cast<GridColumn>().Where(col => col.DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric && col.DisplayFormat.FormatString == "n2"))
                {
                    col.DisplayFormat.FormatString = "n1";
                }
            }
        }
    }
}