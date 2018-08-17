using System;
using System.Windows.Controls;

using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Wsh;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshGrundBudgetView
    /// </summary>
    public partial class WshGrundBudgetView
    {
        #region Fields

        #region Private Fields

        private bool _handleSelectionChanged = true;

        #endregion

        #endregion

        #region Constructors

        public WshGrundBudgetView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public new WshGrundBudgetVM ViewModel
        {
            get { return (WshGrundBudgetVM)base.ViewModel; }
        }

        #endregion

        #region EventHandlers

        private void KissTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (!_handleSelectionChanged)
                {
                    return;
                }

                if (!CanChangeTabPage() &&
                    e.RemovedItems != null && e.RemovedItems.Count == 1 && e.RemovedItems[0] is TabItem)
                {
                    try
                    {
                        _handleSelectionChanged = false;
                        tabGrundbudget.SelectedItem = e.RemovedItems[0];    // reset to previous selected tpg
                    }
                    finally
                    {
                        _handleSelectionChanged = true;
                    }

                    Utilities.MessageBox.ShowInfoMessageBox("Der Eintrag konnte nicht gespeichert werden, bitte korrigieren Sie zuerst die Angaben.");
                    e.Handled = true;
                    return;
                }

                IViewModelCRUD detailViewModel = null;

                if (tpgGrundbudget.IsSelected)
                {
                    detailViewModel = PositionView.ViewModel;
                }
                else if (tpgAbzug.IsSelected)
                {
                    detailViewModel = AbzugView.ViewModel;
                }

                if (ViewModel.DetailViewModel == null || ViewModel.DetailViewModel != detailViewModel)
                {
                    ViewModel.DetailViewModel = detailViewModel;
                }
            }
        }

        public override bool JumpToPath(System.Collections.Specialized.HybridDictionary parameters)
        {
            //determine which tab to activate
            if (parameters.Contains("WshAbzugID"))
            {
                //activate AbzugView
                tabGrundbudget.SelectedItem = tpgAbzug;
                return ViewModel.DetailViewModel.JumpToPath(parameters);
            }
            else if (parameters.Contains("WshGrundbudgetPositionID"))
            {
                //activate PositionView
                tabGrundbudget.SelectedItem = tpgGrundbudget;
                return ViewModel.DetailViewModel.JumpToPath(parameters);
            }

            //nothing to do here
            return base.JumpToPath(parameters);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void InitViewAndViewModel(int faLeistungId)
        {
            PositionView.InitViewAndViewModel(faLeistungId);
            AbzugView.InitViewAndViewModel(faLeistungId);
            ViewModel.RegisterChildrenVM(PositionView.ViewModel, AbzugView.ViewModel);
        }

        #endregion

        #region Protected Methods

        protected override IViewModelCRUD GetViewModel()
        {
            return FindResource("viewModel") as IViewModelCRUD;
        }

        #endregion

        #region Private Methods

        private bool CanChangeTabPage()
        {
            if (ViewModel == null || ViewModel.DetailViewModel == null)
            {
                return true;
            }

            // TODO: maybe remove try-catch if KiSS does not crash anymore in case of error
            try
            {
                return ViewModel.DetailViewModel.SaveData(null).IsOk;
            }
            catch (Exception ex)
            {
                Utilities.MessageBox.ShowError("Es ist ein Fehler beim Speichern der Änderungen aufgetreten.", ex);
                return false;
            }
        }

        #endregion

        #endregion
    }
}