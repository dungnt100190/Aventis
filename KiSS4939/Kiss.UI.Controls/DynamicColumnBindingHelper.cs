using System.Windows;
using System.Windows.Data;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Used when creating dynamic columns for setting the DisplayMemberBinding.
    /// </summary>
    public class GridColumnBindingHelper
    {
        public static readonly DependencyProperty ColumnBindingProperty =
            DependencyProperty.RegisterAttached("ColumnBinding", typeof(object), typeof(GridColumnBindingHelper),
                new PropertyMetadata(null, (d, e) =>
                {
                    ((GridColumn)d).DisplayMemberBinding = (BindingBase)e.NewValue;
                }));

        public static object GetColumnBinding(DependencyObject obj)
        {
            return obj.GetValue(ColumnBindingProperty);
        }

        public static void SetColumnBinding(DependencyObject obj, object value)
        {
            obj.SetValue(ColumnBindingProperty, value);
        }
    }
}