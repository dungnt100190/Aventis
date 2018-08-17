using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// The WPF Text input control for KiSS
    /// </summary>
    public class KissTextEdit : TextBox, IKissEdit
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty IsAuthorizedProperty;
        public static readonly DependencyProperty IsRequiredProperty;

        public static new readonly DependencyProperty IsReadOnlyProperty;

        #endregion

        #endregion

        #region Constructors

        static KissTextEdit()
        {
            IsAuthorizedProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissTextEdit>(x => x.IsAuthorized),
                    typeof(bool),
                    typeof(KissTextEdit),
                    new UIPropertyMetadata(true, IsAuthorizedChanged));
            IsReadOnlyProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissTextEdit>(x => x.IsReadOnly),
                    typeof(bool),
                    typeof(KissTextEdit),
                    new UIPropertyMetadata(false, IsReadOnlyChanged));
            IsRequiredProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissTextEdit>(x => x.IsRequired),
                    typeof(bool),
                    typeof(KissTextEdit),
                    new PropertyMetadata(false));

            DefaultStyleKeyProperty.OverrideMetadata(typeof(KissTextEdit), new FrameworkPropertyMetadata(typeof(KissTextEdit)));
        }

        public KissTextEdit()
        {
            var authorizedBinding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(RightHelper.MaskRightProperty),
                Mode = BindingMode.OneWay,
            };
            SetBinding(IsAuthorizedProperty, authorizedBinding);
        }

        #endregion

        #region Properties

        public bool IsAuthorized
        {
            get { return (bool)GetValue(IsAuthorizedProperty); }
            set { SetValue(IsAuthorizedProperty, value); }
        }

        public new bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissTextEdit)d;
            instance.EnforceAuthorize();
        }

        public static void IsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissTextEdit)d;
            instance.EnforceAuthorize();
        }

        #endregion

        #region Private Methods

        private void EnforceAuthorize()
        {
            // IsAuthorized ist stärker als IsReadOnly
            base.IsReadOnly = !IsAuthorized || IsReadOnly;
        }

        #endregion

        #endregion
    }
}