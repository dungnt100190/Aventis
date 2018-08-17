using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Wsh;
using MessageBox = Kiss.Utilities.MessageBox;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshBudgetPositionView.xaml
    /// </summary>
    public partial class WshBudgetPositionView
    {
        #region Constructors

        public WshBudgetPositionView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public new WshBudgetPositionVM ViewModel
        {
            get { return (WshBudgetPositionVM)base.ViewModel; }
        }

        #endregion

        #region EventHandlers

        private void btnAuszahlvorschlag_Click(object sender, RoutedEventArgs e)
        {
            var currentCursor = Cursor;
            KissServiceResult result = ViewModel.SaveData(null);
            if (!result.IsOk)
            {
                MessageBox.ShowInfoMessageBox("Der Auszahlvorschlag kann erst erstellt werden, \n wenn die Position erfolgreich gespeichert wurde.");
                return;
            }
            try
            {
                Cursor = Cursors.Wait;
                var auszahlvorschlag = new WshAuszahlvorschlagView();
                auszahlvorschlag.InitViewAndViewModel(ViewModel.FaLeistungId);

                ViewHelper.OpenModalWpfDialog(auszahlvorschlag, "Auszahlvorschlag");

                ViewModel.LoadData(null);
            }
            finally
            {
                Cursor = currentCursor;
            }
        }

        private void grdWshBudgetPosition_CustomUnboundColumnData(object sender, GridColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "IconUnbound")
            {
                if (e.IsGetData)
                {
                    e.Value = ViewModel.GetPositionsStatusImage(e.ListSourceRowIndex);
                }
            }
        }

        private void grdWshBudgetPosition_FocusedRowDoubleClick(object sender, MouseButtonEventArgs e)
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

        #endregion
    }
}