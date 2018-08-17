using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for BusyOverlay.xaml
    /// </summary>
    public partial class BusyOverlay
    {
        public BusyOverlay()
        {
            InitializeComponent();
            var binding = new Binding
                              {
                                  Converter = new BooleanToVisibilityConverter(),
                                  Mode = BindingMode.TwoWay,
                                  RelativeSource = RelativeSource.Self,
                                  Path = new PropertyPath("IsActive")
                              };
            SetBinding(VisibilityProperty, binding);
        }

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(BusyOverlay), new UIPropertyMetadata(false));
    }
}
