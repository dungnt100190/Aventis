using System.Windows;
using DevExpress.Xpf.Grid;
using Kiss.DbContext;
using Kiss.UserInterface.ViewModel.Vm;

namespace Kiss.UserInterface.View.Vm
{
    /// <summary>
    /// Interaction logic for VmKlientenbudgetKategorieView.xaml
    /// </summary>
    public partial class VmKlientenbudgetKategorieView
    {
        #region Constructors

        public VmKlientenbudgetKategorieView()
        {
            DataControlBase.AllowInfiniteGridSize = true;
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // focus on first column
            grdPositionen.Focus();
            ((TableView)grdPositionen.View).FocusedColumn = colName;
        }

        private void grdPositionen_CustomSummary(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            var vm = ViewModel as VmKlientenbudgetKategorieVM;
            if (vm != null)
            {
                e.TotalValue = "Total " + vm.Title;
            }
            else
            {
                e.TotalValue = "Total";
            }
        }

        private void KissView_Loaded(object sender, RoutedEventArgs e)
        {
            // (DevExpress) Wenn Visibility einer Column ändert, werden alle VisibleIndexes neu berechnet, also nach vorne verschoben
            colBemerkungen.VisibleIndex = 5;
        }

        private void TableView_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            // prevent editing of certain rows
            var dto = e.Row as VmPosition;

            if (dto != null)
            {
                if (!(e.Column == colBemerkungen && dto.CanEditBemerkung()) &&
                    !dto.CanEdit())
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        #endregion

        #endregion
    }
}