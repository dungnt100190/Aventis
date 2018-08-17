using System;

using KiSS4.Common;

namespace KiSS4.Query.PI
{
    public partial class CtlQueryBDEMaAustritt : KissQueryControl
    {
        #region Constructors

        public CtlQueryBDEMaAustritt()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtAustrittsdatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
        }

        #endregion

        #endregion
    }
}