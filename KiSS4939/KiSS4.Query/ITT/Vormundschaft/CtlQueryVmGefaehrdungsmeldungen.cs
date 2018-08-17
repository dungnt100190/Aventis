using KiSS4.Common;

namespace KiSS4.Query.ITT
{
    public partial class CtlQueryVmGefaehrdungsmeldungen : KissQueryControl
    {
        public CtlQueryVmGefaehrdungsmeldungen()
        {
            InitializeComponent();
        }

        protected override void RunSearch()
        {
            qryListe2.Fill();

            base.RunSearch();
        }
    }
}
