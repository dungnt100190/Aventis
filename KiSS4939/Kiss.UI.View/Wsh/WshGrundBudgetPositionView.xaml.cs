using System.Windows;
using System.Windows.Input;

using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel;
using Kiss.UI.ViewModel.Wsh;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshGrundBudgetPositionView
    /// </summary>
    public partial class WshGrundBudgetPositionView
    {
        #region Constructors

        public WshGrundBudgetPositionView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public new WshGrundBudgetPositionVM ViewModel
        {
            get { return (WshGrundBudgetPositionVM)base.ViewModel; }
        }

        #endregion

        #region EventHandlers

        private void GrundbudgetVorschlagButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ValidationResult = ViewModel.SaveData(null);
            if (!ValidationResult.IsOk)
            {
                return;
            }

            ShowGrundbudgetVorschlag(ViewModel.FaLeistungID);
        }

        private void KissView_Loaded(object sender, RoutedEventArgs e)
        {
            if(ViewModelBase.DesignMode)
            {
                return;
            }

            // ToDo (optional): asynchron, da Dauer ca 1s
            // Async CTP?
            if (!ViewModel.ExistierenGrundbudgetPositionen)
            {
                ShowGrundbudgetVorschlag(ViewModel.FaLeistungID);
            }
        }

        private void grdWshGrundbudget_FocusedRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var c = ViewModel.ShowEditPanelCommand;
            c.Execute(null);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void InitViewAndViewModel(int faLeistungId)
        {
            ViewModel.Init(faLeistungId);
        }

        #endregion

        #region Protected Methods

        protected override IViewModelCRUD GetViewModel()
        {
            return FindResource("viewModel") as IViewModelCRUD;
        }

        #endregion

        #region Private Methods

        private void ShowGrundbudgetVorschlag(int faLeistungID)
        {
            var grundbudgetvorschlag = new WshGrundbudgetVorschlagView();
            grundbudgetvorschlag.InitViewAndViewModel(faLeistungID);

            bool? resultDlg = ViewHelper.OpenModalWpfDialog(grundbudgetvorschlag, "GBL / Basisdaten", null, null, new Size(700, 500));
            if (resultDlg.HasValue && resultDlg.Value)
            {
                RefreshData();
            }
        }

        #endregion

        #endregion
    }
}