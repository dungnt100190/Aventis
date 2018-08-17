using DevExpress.Xpf.Editors;

namespace Kiss.UI.Controls
{
    public class KissMoneyEdit : KissCalcEdit
    {
        #region Constructors

        public KissMoneyEdit()
        {
            MaskType = MaskType.Numeric;
            Mask = "n2";
            MaskUseAsDisplayFormat = true;
        }

        #endregion
    }
}