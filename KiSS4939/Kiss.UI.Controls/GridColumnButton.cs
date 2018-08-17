using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

using Kiss.Infrastructure;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// A column with a button in every row.
    /// </summary>
    public class GridColumnButton : GridColumn
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty ButtonContentProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<GridColumnButton>(x => x.ButtonContent),
                typeof(object),
                typeof(GridColumnButton),
                new PropertyMetadata(null));

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly FrameworkElementFactory _buttonFactory;

        private const string BUTTON_NAME = "GridButton";

        #endregion

        #endregion

        #region Constructors

        public GridColumnButton()
        {
            Width = 25;
            FixedWidth = true;

            _buttonFactory = new FrameworkElementFactory(typeof(KissButton), BUTTON_NAME);
            _buttonFactory.SetValue(FrameworkElement.WidthProperty, 20D);
            _buttonFactory.SetValue(FrameworkElement.HeightProperty, 20D);

            var contentBinding = new Binding(PropertyName.GetPropertyName(() => ButtonContent))
            {
                Mode = BindingMode.TwoWay,
                Source = this
            };
            _buttonFactory.SetBinding(ContentControl.ContentProperty, contentBinding);

            CellTemplate = new DataTemplate
                           {
                               VisualTree = _buttonFactory
                           };
        }

        #endregion

        #region Events

        public event RoutedEventHandler ButtonClick
        {
            add { _buttonFactory.AddHandler(ButtonBase.ClickEvent, value); }
            remove { _buttonFactory.RemoveHandler(ButtonBase.ClickEvent, value); }
        }

        #endregion

        #region Properties

        public object ButtonContent
        {
            get { return GetValue(ButtonContentProperty); }
            set { SetValue(ButtonContentProperty, value); }
        }

        #endregion
    }
}