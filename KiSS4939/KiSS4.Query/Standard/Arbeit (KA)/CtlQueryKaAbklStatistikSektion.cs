using System;

using KiSS4.DB;

namespace KiSS4.Query
{
    partial class CtlQueryKaAbklStatistikSektion : Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryKaAbklStatistikSektion()
        {
            InitializeComponent();

            edtDatumVon.Focus();

            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumBis.EditValue = DateTime.Today;

            edtAuswZuweiser.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT Code = 1, Text = 'alle' UNION ALL
                    SELECT 2, 'SD Bern (alle Sektionen)' UNION ALL
                    SELECT 3, 'RAV Anmeldungen' UNION ALL
                    SELECT 4, 'SD Aussengemeinden' UNION ALL
                    SELECT 5, 'Burgergemeinde' UNION ALL
                    SELECT 6, 'EKS' UNION ALL
                    SELECT 7, 'Caritas' UNION ALL
                    SELECT 8, 'SD Ostermundigen'"));

            edtAuswAlter.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT Code = 1, Text = 'Personen jünger als 25' UNION ALL
                    SELECT 2, 'Personen älter als 25' UNION ALL
                    SELECT 3, 'altersunabhängig'"));

            edtAuswAnmeldung.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT Code = 1, Text = 'Erstanmeldung' UNION ALL
                    SELECT 2, 'Wiederanmeldung' UNION ALL
                    SELECT 3, 'Wiederbeurteilung' UNION ALL
                    SELECT 4, 'Erst- und Wiederanmeldung zusammen'"));
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumBis.EditValue = DateTime.Today;
            edtAuswZuweiser.EditValue = null;
            edtAuswAlter.EditValue = null;
            edtAuswAnmeldung.EditValue = null;
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

        #endregion
    }
}