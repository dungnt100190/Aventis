using System;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryKaStatistikGEF : KissQueryControl
    {
        public CtlQueryKaStatistikGEF()
        {
            InitializeComponent();

            edtAuswAngebot.LoadQuery(DBUtil.OpenSQL(@"
                SELECT Code = 0, Text = '' UNION ALL
                SELECT Code = 3, Text = 'BI' UNION ALL
                SELECT Code = 4, Text = 'BIP' UNION ALL
                SELECT Code = 5, Text = 'SI'"));

            NewSearch();
        }

        protected override void NewSearch()
        {
            base.NewSearch();

            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumBis.EditValue = null;
            edtAuswAngebot.EditValue = null;
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtDatumBis, lblDatumBis.Text);

            base.RunSearch();
        }
    }
}