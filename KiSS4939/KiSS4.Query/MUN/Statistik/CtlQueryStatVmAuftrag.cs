using KiSS4.DB;

namespace KiSS4.Query.MUN
{
    public partial class CtlQueryStatVmAuftrag : KiSS4.Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryStatVmAuftrag()
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