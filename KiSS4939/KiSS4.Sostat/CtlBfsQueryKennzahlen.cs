using System;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Sostat
{
    public partial class CtlBfsQueryKennzahlen : KissQueryControl
    {
        #region Constructors

        public CtlBfsQueryKennzahlen()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtErhebungsjahr.Text = DBUtil.GetConfigValue(@"System\Sostat\Erhebungsjahr", DateTime.Now.Year).ToString();
            edtNettobedarf.Checked = true;
        }

        protected override void RunSearch()
        {
            grdQuery1.MainView = edtProDossier.Checked ? grvGeneric : grvQuery1;
        }

        #endregion

        #endregion
    }
}