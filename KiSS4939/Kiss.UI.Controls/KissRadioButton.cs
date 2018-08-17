using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    public class KissRadioButton : RadioButton, IAuthorizable
    {
        public static readonly DependencyProperty IsAuthorizedProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissRadioButton>(x => x.IsAuthorized),
                typeof(bool),
                typeof(KissRadioButton),
                new UIPropertyMetadata(true, IsAuthorizedChanged));

        public static new readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissRadioButton>(x => x.IsEnabled),
                typeof(bool),
                typeof(KissRadioButton),
                new UIPropertyMetadata(true, IsEnabledChanged_KissRadioButton));

        public static readonly DependencyProperty RadioBindingProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissRadioButton>(x => x.RadioBinding),
                typeof(object),
                typeof(KissRadioButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnRadioBindingChanged));

        public static readonly DependencyProperty RadioValueProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissRadioButton>(x => x.RadioValue),
                typeof(object),
                typeof(KissRadioButton),
                new UIPropertyMetadata(null));

        static KissRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KissRadioButton), new FrameworkPropertyMetadata(typeof(KissRadioButton)));
        }

        public KissRadioButton()
        {
            var authorizedBinding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(RightHelper.MaskRightProperty),
                Mode = BindingMode.OneWay,
            };
            SetBinding(IsAuthorizedProperty, authorizedBinding);
        }

        /// <summary>
        /// Kann als Binding für RadioValue verwendet werden ({x:Static Controls:KissRadioButton.False})
        /// </summary>
        public static bool False
        {
            get { return false; }
        }

        /// <summary>
        /// Kann als Binding für RadioValue verwendet werden ({x:Static Controls:KissRadioButton.True})
        /// </summary>
        public static bool True
        {
            get { return true; }
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

        public object RadioBinding
        {
            get { return GetValue(RadioBindingProperty); }
            set { SetValue(RadioBindingProperty, value); }
        }

        public object RadioValue
        {
            get { return GetValue(RadioValueProperty); }
            set { SetValue(RadioValueProperty, value); }
        }

        public static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissRadioButton)d;
            instance.EnforceAuthorize();
        }

        public static void IsEnabledChanged_KissRadioButton(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissRadioButton)d;
            instance.EnforceAuthorize();
        }

        protected override void OnChecked(RoutedEventArgs e)
        {
            base.OnChecked(e);
            SetCurrentValue(RadioBindingProperty, RadioValue);
        }

        private static void OnRadioBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var rb = (KissRadioButton)d;
            if (rb.RadioValue.Equals(e.NewValue))
            {
                rb.SetCurrentValue(IsCheckedProperty, true);
            }
        }

        private void EnforceAuthorize()
        {
            // IsAuthorized ist stärker als IsEnabled
            base.IsEnabled = IsAuthorized && IsEnabled;
        }
    }
}