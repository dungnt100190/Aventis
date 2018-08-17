

using DevExpress.Xpf.Grid;

using Kiss.UserInterface.ViewModel.Interfaces;
using Kiss.UserInterface.ViewModel.Vm;

namespace Kiss.UserInterface.View.Vm
{
    /// <summary>
    /// Interaction logic for VmKlientenBudgetView
    /// </summary>
    public partial class VmKlientenbudgetEditorView
    {
        #region Constructors

        public VmKlientenbudgetEditorView()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        protected override void ViewModelHasChanged(IViewModel viewModel)
        {
            var vm = viewModel as VmKlientenbudgetEditorVM;
            if (vm != null)
            {
                vm.SelectedEntityChanged += ViewModel_SelectedEntityChanged;
            }
            ((TableView)grdBudgets.View).BestFitColumns();
        }

        void ViewModel_SelectedEntityChanged(VmKlientenbudgetVM selectedEntity, VmKlientenbudgetVM deselectedEntity)
        {
            scrollViewerPosition.ScrollToVerticalOffset(0);
        }
        
        #endregion
    }
}