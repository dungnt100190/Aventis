using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls
{
    public class GridColumnProzent : GridColumn
    {
        #region Constructors

        public GridColumnProzent()
        {
            EditSettings = new CalcEditSettings
            {
                Mask = "N1",
                MaskUseAsDisplayFormat = true,
                AllowDefaultButton = false
            };
        }

        #endregion
    }
}