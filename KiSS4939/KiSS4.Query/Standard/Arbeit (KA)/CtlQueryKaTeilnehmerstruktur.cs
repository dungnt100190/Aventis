using System;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryKaTeilnehmerstruktur : KissQueryControl
    {
        public CtlQueryKaTeilnehmerstruktur()
        {
            InitializeComponent();

            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumBis.EditValue = DateTime.Today;

            edtEinsatzPlatzID.LoadQuery(
                DBUtil.OpenSQL(@"
                    SELECT Code = NULL, Text = NULL
                    UNION
                    SELECT Code = KaEinsatzplatzID, Text = dbo.fnLOVText('KaAPV', APVCode)
                    FROM dbo.KaEinsatzplatz2 WITH(READUNCOMMITTED)
                    WHERE DatumBis IS NULL OR DatumBis >= GETDATE()
                    ORDER BY Text;"));
        }

        protected override void NewSearch()
        {
            base.NewSearch();

            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumBis.EditValue = DateTime.Today;
            edtEinsatzPlatzID.EditValue = null;
            edtZusatzCode.EditValue = null;
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

        private void CtlQueryKaTeilnehmerstruktur_Load(object sender, EventArgs e)
        {
            tpgListe.Title = "Zusammenfassung";
        }
    }
}