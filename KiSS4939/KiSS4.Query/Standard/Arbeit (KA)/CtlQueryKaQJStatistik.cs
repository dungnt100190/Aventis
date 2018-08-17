using System;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryKaQJStatistik : KissQueryControl
    {
        #region Constructors

        public CtlQueryKaQJStatistik()
        {
            InitializeComponent();

            SetDate();

            SetAPVCodes();

            edtZuweiser.LoadQuery(DBUtil.OpenSQL(@"
                SELECT Code = 0, Text = ''
                UNION ALL
                SELECT Code = 1, Text = 'RAV'
                UNION ALL
                SELECT Code = 2, Text = 'SD Bern'
                UNION ALL
                SELECT Code = 3, 'alle SD exkl. SD Bern';"));
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            SetDate();

            edtZuweiser.EditValue = null;
            edtNiveauCode.EditValue = null;
        }

        private void SetAPVCodes()
        {
            /*
                SELECT Code = KaEinsatzplatzID, Text = dbo.fnLOVText('KaAPV', APVCode)
                FROM dbo.KaEinsatzplatz2 WITH (READUNCOMMITTED)
                WHERE KaEinsatzplatzID = {0}
                   OR DatumBis IS NULL
                   OR DatumBis >= GETDATE()
                ORDER BY Text");
             * */
            SqlQuery apv = DBUtil.OpenSQL(@"
                SELECT Code = APVCode, Text = dbo.fnLOVText('KaAPV', APVCode)
                FROM dbo.KaEinsatzplatz2 WITH (READUNCOMMITTED)
                WHERE DatumBis IS NULL
                   OR DatumBis >= GETDATE()
                ORDER BY Text");
            edtAPVCode.LoadQuery(apv);
        }

        private void SetDate()
        {
            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumBis.EditValue = DateTime.Today;
        }
        #endregion


    }
}