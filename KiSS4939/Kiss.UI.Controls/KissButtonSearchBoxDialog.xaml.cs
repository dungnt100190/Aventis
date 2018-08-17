using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for KissButtonSearchDialog.xaml
    /// </summary>
    public partial class KissButtonSearchBoxDialog
    {
        #region Constructors

        public KissButtonSearchBoxDialog(IList<object> aEntity, IEnumerable<GridColumnDefinition> cols)
        {
            InitializeComponent();

            grdSearch.ItemsSource = aEntity;

            grdSearch.Columns.Clear();
            foreach (var col in cols)
            {
                var gridCol = new GridColumn { FieldName = col.Fieldname, Header = col.Title };
                grdSearch.Columns.Add(gridCol);
            }

            btnOk.IsEnabled = (grdSearch.VisibleRowCount > 0);

            grdSearch.Focus();
        }

        #endregion

        #region Properties

        public object SelectedItem { get; private set; }

        #endregion

        #region EventHandlers

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            SelectedItem = grdSearch.View.FocusedRow;
            DialogResult = true;
        }

        private void grdSearch_FilterChanged(object sender, RoutedEventArgs e)
        {
            btnOk.IsEnabled = (grdSearch.GetFocusedRow() != null);
        }

        private void grdSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnOk_Click(sender, null);
        }

        public new bool? ShowDialog()
        {
            ControlsHelper.HideMinimizeAndMaximizeButtons(this);
            return base.ShowDialog();
        }

        #endregion
    }
}