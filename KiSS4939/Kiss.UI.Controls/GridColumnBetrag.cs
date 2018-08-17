using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// GridColumn mit CalcEditSettings.
    /// </summary>
    public class GridColumnBetrag : GridColumn
    {
        #region Constructors

        public GridColumnBetrag()
        {
            EditSettings = new CalcEditSettings
            {
                DisplayFormat = "0.00",
                AllowDefaultButton = false
            };
        }

        #endregion
    }
}