using DevExpress.Xpf.Editors;

namespace Kiss.UI.Controls
{
    public class KissIntEdit : KissMoneyEdit
    {
        #region Constructors

        public KissIntEdit()
        {
            MaskType = MaskType.Numeric;
            Mask = "################################";
            MaskUseAsDisplayFormat = true;

        }

        #endregion
    }
}