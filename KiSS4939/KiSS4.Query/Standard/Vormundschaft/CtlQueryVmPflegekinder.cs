using System;

using KiSS4.Common;

namespace KiSS4.Query
{
    public partial class CtlQueryVmPflegekinder : KissQueryControl
    {
        #region Constructors

        public CtlQueryVmPflegekinder()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryVmPflegekinder_Load(object sender, EventArgs e)
        {
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void RunSearch()
        {
            qryListe2.Fill();

            base.RunSearch();
        }

        #endregion

        #endregion
    }
}