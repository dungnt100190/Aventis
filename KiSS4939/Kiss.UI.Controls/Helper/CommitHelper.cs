using System;
using System.Windows;
using System.Windows.Threading;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls.Helper
{
    /// <summary>
    /// Immediately commits changes when editing a grid cell (similar to UpdateSourceTrigger.PropertyChanged).
    /// https://www.devexpress.com/Support/Center/Example/Details/E4155
    /// </summary>
    public class CommitHelper
    {
        public static readonly DependencyProperty CommitOnValueChangedProperty = DependencyProperty.RegisterAttached("CommitOnValueChanged", typeof(bool), typeof(CommitHelper), new PropertyMetadata(CommitOnValueChangedPropertyChanged));

        public static bool GetCommitOnValueChanged(GridColumn element)
        {
            return (bool)element.GetValue(CommitOnValueChangedProperty);
        }

        public static void SetCommitOnValueChanged(GridColumn element, bool value)
        {
            element.SetValue(CommitOnValueChangedProperty, value);
        }

        private static void CommitOnValueChangedPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var col = (GridColumn)source;

            if (col.View == null)
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action<GridColumn, bool>(ToggleCellValueChanging), col, (bool)e.NewValue);
            }
            else
            {
                ToggleCellValueChanging(col, (bool)e.NewValue);
            }
        }

        private static void ToggleCellValueChanging(GridColumn col, bool subscribe)
        {
            var view = col.View as TableView;

            if (view == null)
            {
                return;
            }

            if (subscribe)
            {
                view.CellValueChanging += view_CellValueChanging;
            }
            else
            {
                view.CellValueChanging -= view_CellValueChanging;
            }
        }

        private static void view_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            var view = (TableView)sender;

            if ((bool)e.Column.GetValue(CommitOnValueChangedProperty))
            {
                view.PostEditor();
            }
        }
    }
}