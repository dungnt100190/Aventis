using System.Windows;
using System.Windows.Media;

using Kiss.Infrastructure;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// GridColumn mit einem Image. Mit FieldName wird auf ein bool-Feld gebunden. Liefert das Feld <c>true</c>, wird das Image angezeigt.
    /// Das angezeigte Image wird mittels ImageSource-property definiert.
    /// </summary>
    public class GridColumnImageOnOff : GridColumn
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty ImageSourceProperty = 
            DependencyProperty.Register(
                PropertyName.GetPropertyName<GridColumnImageOnOff>(x => x.ImageSource), typeof(ImageSource), typeof(GridColumnImageOnOff));

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Definiert, welches Image in der Spalte angezeigt wird. Dies ist ein dependency property.
        /// </summary>
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        #endregion
    }
}