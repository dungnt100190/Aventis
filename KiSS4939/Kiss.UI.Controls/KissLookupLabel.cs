using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Kiss.Infrastructure;

namespace Kiss.UI.Controls
{
    public class KissLookupLabel : ComboBox
    {
        public static readonly DependencyProperty ShowAsLabelProperty;

        public static readonly DependencyProperty ShowToolTipProperty;

        static KissLookupLabel()
        {
            ShowAsLabelProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissLookupLabel>(x => x.ShowAsLabel),
                    typeof(bool),
                    typeof(KissLookupLabel),
                    new PropertyMetadata(false));
            ShowToolTipProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissLookupLabel>(x => x.ShowToolTip),
                    typeof(bool),
                    typeof(KissLookupLabel),
                    new FrameworkPropertyMetadata(default(bool)));
        }

        public bool ShowAsLabel
        {
            get { return (bool)GetValue(ShowAsLabelProperty); }
            set { SetValue(ShowAsLabelProperty, value); }
        }

        public bool ShowToolTip
        {
            get { return (bool)GetValue(ShowToolTipProperty); }
            set { SetValue(ShowToolTipProperty, value); }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}