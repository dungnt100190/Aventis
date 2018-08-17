using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    public class KissCheckBox : CheckBox, IAuthorizable
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty IsAuthorizedProperty = 
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissCheckBox>(x => x.IsAuthorized),
                typeof(bool),
                typeof(KissCheckBox),
                new UIPropertyMetadata(true, IsAuthorizedChanged));
        public static readonly DependencyProperty LabelWidthProperty = 
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissCheckBox>(x => x.LabelWidth),
                typeof(int),
                typeof(KissCheckBox));

        public static new readonly DependencyProperty IsEnabledProperty = 
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissCheckBox>(x => x.IsEnabled),
                typeof(bool),
                typeof(KissCheckBox),
                new UIPropertyMetadata(true, IsEnabledChanged_KissCheckBox));
        
        public static readonly DependencyProperty IsCheckBoxVisibleProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<KissCheckBox>(x => x.IsCheckBoxVisible),
                typeof(bool), 
                typeof(KissCheckBox), 
                new UIPropertyMetadata(true));

        #endregion

        #endregion

        #region Constructors

        static KissCheckBox()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(KissCheckBox), new FrameworkPropertyMetadata(typeof(KissCheckBox)));
        }

        public KissCheckBox()
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

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public int LabelWidth
        {
            get { return (int)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        public bool IsCheckBoxVisible
        {
            get { return (bool)GetValue(IsCheckBoxVisibleProperty); }
            set { SetValue(IsCheckBoxVisibleProperty, value); }
        }

        #endregion

        #region EventHandlers

        public static void IsEnabledChanged_KissCheckBox(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissCheckBox)d;
            instance.EnforceAuthorize();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissCheckBox)d;
            instance.EnforceAuthorize();
        }

        #endregion

        #region Private Methods

        private void EnforceAuthorize()
        {
            // IsAuthorized ist stärker als IsEnabled
            base.IsEnabled = IsAuthorized && IsEnabled;
        }

        #endregion

        #endregion
    }
}