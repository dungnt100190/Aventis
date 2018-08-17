using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Query.WOH
{
    public partial class CtlQueryCTRLFallzahlen : KiSS4.Common.KissQueryControl
    {
        public CtlQueryCTRLFallzahlen()
        {
            InitializeComponent();
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, "Zeitraum von");
            DBUtil.CheckNotNullField(edtDatumBis, "Zeitraum bis");

            base.RunSearch();
        }
    }
}