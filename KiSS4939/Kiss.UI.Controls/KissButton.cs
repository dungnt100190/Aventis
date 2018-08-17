using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    public class KissButton : Button, IAuthorizable
    {
        public static readonly DependencyProperty IsAuthorizationEnabledProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissButton>(x => x.IsAuthorizationEnabled),
                typeof(bool),
                typeof(KissButton),
                new FrameworkPropertyMetadata(true, AuthorizationPropertyChanged));

        public static readonly DependencyProperty IsAuthorizedProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissButton>(x => x.IsAuthorized),
                typeof(bool),
                typeof(KissButton),
                new FrameworkPropertyMetadata(true, AuthorizationPropertyChanged));

        public static new readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissButton>(x => x.IsEnabled),
                typeof(bool),
                typeof(KissButton),
                new FrameworkPropertyMetadata(true, IsEnabledChanged));

        static KissButton()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(KissButton), new FrameworkPropertyMetadata(typeof(KissButton)));
        }

        public KissButton()
        {
            var authorizedBinding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(RightHelper.MaskRightProperty),
                Mode = BindingMode.OneWay,
            };
            SetBinding(IsAuthorizedProperty, authorizedBinding);
        }

        public bool IsAuthorizationEnabled
        {
            get { return (bool)GetValue(IsAuthorizationEnabledProperty); }
            set { SetValue(IsAuthorizationEnabledProperty, value); }
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

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == CommandProperty)
            {
                if (e.OldValue != null)
                {
                    ((ICommand)e.OldValue).CanExecuteChanged -= Command_CanExecuteChanged;
                }

                if (e.NewValue != null)
                {
                    var command = (ICommand)e.NewValue;
                    IsEnabled = command.CanExecute(CommandParameter);
                    command.CanExecuteChanged += Command_CanExecuteChanged;
                }
            }

            base.OnPropertyChanged(e);
        }

        private static void AuthorizationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissButton)d;
            instance.EnforceAuthorize();
        }

        private static new void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissButton)d;
            instance.EnforceAuthorize();
        }

        private void Command_CanExecuteChanged(object sender, EventArgs e)
        {
            if (Command != null)
            {
                IsEnabled = Command.CanExecute(CommandParameter);
            }
        }

        private void EnforceAuthorize()
        {
            base.IsEnabled = (IsAuthorized || !IsAuthorizationEnabled) && IsEnabled;
        }
    }
}