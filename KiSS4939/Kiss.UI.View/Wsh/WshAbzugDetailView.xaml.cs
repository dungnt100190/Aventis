using System;
using System.Collections.ObjectModel;

using Kiss.Interfaces.ViewModel;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;
using Kiss.UI.ViewModel.Wsh;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshAbzugDetailView
    /// </summary>
    public partial class WshAbzugDetailView
    {
        #region Constructors

        public WshAbzugDetailView()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var result = ((WshAbzugDetailVM)ViewModel).SaveData(null);
            if(result.IsError)
            {
                Utilities.MessageBox.ShowError(result.GetWarningsAndErrors(), null);
                return;
            }

            //if we reach here, everything is ok and we can close the dialog
            ViewHelper.CloseDialog(this, null);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void InitViewAndViewModel(WshAbzugDTO wshAbzugDto, ObservableCollection<XLOVCode> splittingArt, int faLeistungId, DateTime? stichtag)
        {
            ((WshAbzugDetailVM)ViewModel).Init(wshAbzugDto, splittingArt, faLeistungId, stichtag);
        }

        #endregion

        #region Protected Methods

        protected override IViewModelCRUD GetViewModel()
        {
            return FindResource("viewModel") as IViewModelCRUD;
        }

        #endregion

        #endregion
    }
}