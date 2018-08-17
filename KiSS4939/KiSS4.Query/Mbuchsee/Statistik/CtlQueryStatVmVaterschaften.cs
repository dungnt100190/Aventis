using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Query.MBU
{
    public partial class CtlQueryStatVmVaterschaften : KiSS4.Common.KissQueryControl
    {
        public CtlQueryStatVmVaterschaften()
        {
            InitializeComponent();
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, "Datum von");
            DBUtil.CheckNotNullField(edtDatumBis, "Datum bis");

            base.RunSearch();
        }
    }
}
