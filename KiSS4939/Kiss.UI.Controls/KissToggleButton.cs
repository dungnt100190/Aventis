using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    public class KissToggleButton : ToggleButton, IAuthorizable
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty CheckedContentProperty;
        public static readonly DependencyProperty DefaultContentProperty;
        public static readonly DependencyProperty IsAuthorizedProperty;

        public static new readonly DependencyProperty IsEnabledProperty;

        #endregion

        #endregion

        #region Constructors

        static KissToggleButton()
        {
            var instance = new KissToggleButton();
            CheckedContentProperty =
                DependencyProperty.Register(PropertyName.GetPropertyName(() => instance.CheckedContent), typeof(object), typeof(KissToggleButton), new PropertyMetadata(null, CheckedContentChanged));
            DefaultContentProperty =
                DependencyProperty.Register(PropertyName.GetPropertyName(() => instance.DefaultContent), typeof(object), typeof(KissToggleButton), new PropertyMetadata(null, DefaultContentChanged));
            IsAuthorizedProperty =
                DependencyProperty.Register(PropertyName.GetPropertyName(() => instance.IsAuthorized), typeof(bool), typeof(KissToggleButton), new UIPropertyMetadata(true, IsAuthorizedChanged));
            IsEnabledProperty =
                DependencyProperty.Register(PropertyName.GetPropertyName(() => instance.IsEnabled), typeof(bool), typeof(KissToggleButton), new UIPropertyMetadata(true, IsEnabledChanged));
        }

        public KissToggleButton()
        {
            if (IsAuthorizedProperty == null)
            {
                return;
            }

            var authorizedBinding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(RightHelper.MaskRightProperty),
                Mode = BindingMode.OneWay,
            };

            Checked += UpdateContent;
            Unchecked += UpdateContent;

            SetBinding(IsAuthorizedProperty, authorizedBinding);
        }

        #endregion

        #region Properties

        public object CheckedContent
        {
            get { return GetValue(CheckedContentProperty); }
            set { SetValue(CheckedContentProperty, value); }
        }

        public object DefaultContent
        {
            get { return GetValue(DefaultContentProperty); }
            set { SetValue(DefaultContentProperty, value); }
        }

        public bool IsAuthorized
        {
            get { return (bool)GetValue(IsAuthorizedProperty); }
            set { SetValue(IsAuthorizedProperty, value); }
        }

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static void CheckedContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (ToggleButton)d;
            var isChecked = button.IsChecked.HasValue && button.IsChecked.Value;

            if (isChecked)
            {
                button.Content = e.NewValue;
            }
        }

        private static void DefaultContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (ToggleButton)d;
            var isChecked = button.IsChecked.HasValue && button.IsChecked.Value;

            if (!isChecked)
            {
                button.Content = e.NewValue;
            }
        }

        private static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissToggleButton)d;
            instance.EnforceAuthorize();
        }

        private static new void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissToggleButton)d;
            instance.EnforceAuthorize();
        }

        #endregion

        #region Private Methods

        private void EnforceAuthorize()
        {
            // IsAuthorized ist stärker als IsEnabled
            base.IsEnabled = IsAuthorized && IsEnabled;
        }

        private void UpdateContent(object sender, RoutedEventArgs e)
        {
            if (DefaultContent == null && CheckedContent == null)
            {
                // if both are null the button does not seem to use any toggling content so we do not replace the existing content.
                return;
            }

            if (IsChecked.HasValue && IsChecked.Value)
            {
                Content = CheckedContent;
            }
            else
            {
                Content = DefaultContent;
            }
        }

        #endregion

        #endregion
    }
}