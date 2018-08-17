using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// GridColumn mit CalcEditSettings.
    /// </summary>
    public class GridColumnCheckbox : GridColumn
    {
        #region Constructors

        public GridColumnCheckbox()
        {
            EditSettings = new CheckEditSettings();
        }

        #endregion
    }
}