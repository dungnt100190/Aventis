using System;

using KiSS4.Common;

namespace KiSS4.Query.ZH
{
    public partial class CtlQueryWhUmbuchungsjournal : KissQueryControl
    {
        public CtlQueryWhUmbuchungsjournal()
        {
            InitializeComponent();
        }

        protected override void NewSearch()
        {
            base.NewSearch();

            var first = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            edtUmbuchungVon.EditValue = first;
            edtUmbuchungBis.EditValue = first.AddMonths(1).AddDays(-1);
        }
    }
}