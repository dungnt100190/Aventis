using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using Kiss.Infrastructure;

namespace Kiss.UI.Controls
{
    [ContentProperty("Content")]
    public class BusyPanel : ContentControl
    {
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register(PropertyName.GetPropertyName<BusyPanel>(x => x.IsActive), typeof(bool), typeof(BusyPanel), new UIPropertyMetadata(true));

        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register(PropertyName.GetPropertyName<BusyPanel>(x => x.IsBusy), typeof(bool), typeof(BusyPanel), new UIPropertyMetadata(false));

        static BusyPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BusyPanel), new FrameworkPropertyMetadata(typeof(BusyPanel)));
        }

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }
    }
}