using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryIkAbklaerungen : KissQueryControl
    {
        #region Constructors

        public CtlQueryIkAbklaerungen()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, "Datum von");
            DBUtil.CheckNotNullField(edtDatumBis, "Datum bis");

            base.RunSearch();
        }

        #endregion

        #endregion
    }
}