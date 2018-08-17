using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace KiSS4.Gui
{
    public partial class KissMoneyEdit : KissCalcEdit
    {
        public KissMoneyEdit() : base()
        {
            this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Properties.DisplayFormat.FormatString = "n2";
            this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Properties.EditFormat.FormatString = "n2";
            this.Properties.EditMask = "n2";
        }

        
    }
}
