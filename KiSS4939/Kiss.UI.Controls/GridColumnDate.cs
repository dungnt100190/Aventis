using System.Windows;

using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// GridColumn mit DateEditSettings.
    /// </summary>
    public class GridColumnDate : GridColumn
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty DisplayFormatProperty = BaseEditSettings.DisplayFormatProperty.AddOwner(
            typeof(GridColumnDate), new PropertyMetadata(DEFAULT_DISPLAY_FORMAT, DisplayFormatChanged));

        #endregion

        #region Private Constant/Read-Only Fields

        private const string DEFAULT_DISPLAY_FORMAT = "dd.MM.yyyy";

        #endregion

        #endregion

        #region Constructors

        public GridColumnDate()
        {
            EditSettings = new DateEditSettings
            {
                DisplayFormat = DEFAULT_DISPLAY_FORMAT,
                AllowDefaultButton = false
            };
        }

        #endregion

        #region Properties

        public string DisplayFormat
        {
            get { return (string)GetValue(DisplayFormatProperty); }
            set { SetValue(DisplayFormatProperty, value); }
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static void DisplayFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GridColumnDate dgc = d as GridColumnDate;
            if (dgc != null && dgc.EditSettings != null)
            {
                dgc.EditSettings.DisplayFormat = (string)e.NewValue;
            }
        }

        #endregion

        #endregion
    }
}