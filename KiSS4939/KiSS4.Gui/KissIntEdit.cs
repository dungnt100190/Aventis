using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace KiSS4.Gui
{
    public partial class KissIntEdit : KissCalcEdit
    {
        public KissIntEdit() : base()
        {
            this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Properties.DisplayFormat.FormatString = "################################";
            this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Properties.EditFormat.FormatString = "################################";
            this.Properties.EditMask = "################################";
        }

        
    }
}
