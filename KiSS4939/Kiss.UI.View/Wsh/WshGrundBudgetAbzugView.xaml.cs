using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

using Kiss.Infrastructure;
using Kiss.Interfaces.ViewModel;
using Kiss.UI.Controls;
using Kiss.UI.Controls.Constant;
using Kiss.UI.Controls.Converter;
using Kiss.UI.ViewModel.Wsh;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshGrundBudgetAbzugView
    /// </summary>
    public partial class WshGrundBudgetAbzugView
    {
        #region Fields

        #region Private Fields

        private int _faLeistungId;

        #endregion

        #endregion

        #region Constructors

        public WshGrundBudgetAbzugView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public new WshGrundBudgetAbzugVM ViewModel
        {
            get { return (WshGrundBudgetAbzugVM)base.ViewModel; }
        }

        #endregion

        #region EventHandlers

        private void btnFalluebersichtAbzug_Click(object sender, RoutedEventArgs e)
        {
            var result = ViewModel.SaveData(null);

            if (!result.IsOk)
            {
                Utilities.MessageBox.ShowInfoMessageBox("Der Dialog kann erst angezeigt werden, wenn der aktuelle Eintrag erfolgreich gespeichert wurde.");
                return;
            }

            var currentCursor = Cursor;

            try
            {
                Cursor = Cursors.Wait;

                var falluebersichtAbzugView = new WshFalluebersichtAbzugView();
                falluebersichtAbzugView.InitViewAndViewModel(_faLeistungId);

                ViewHelper.OpenModalWpfDialog(falluebersichtAbzugView, "Fallübersicht Abzüge", null, null, null);

            }
            finally
            {
                Cursor = currentCursor;
            }
        }

        private void btnGblZulagen_Click(object sender, RoutedEventArgs e)
        {
            var result = ViewModel.SaveData(null);

            if (!result.IsOk)
            {
                Utilities.MessageBox.ShowInfoMessageBox("Der Dialog kann erst angezeigt werden, wenn der aktuelle Eintrag erfolgreich gespeichert wurde.");
                return;
            }

            var currentCursor = Cursor;

            try
            {
                Cursor = Cursors.Wait;

                var abzugDetails = new WshAbzugDetailView();
                abzugDetails.InitViewAndViewModel(ViewModel.SelectedEntity, ViewModel.Splittingart, _faLeistungId, ViewModel.Stichtag);

                ViewHelper.OpenModalWpfDialog(abzugDetails, GetDialogText(), null, null, new Size(500, 600));

                ViewModel.UpdateBetragGblProzent(ViewModel.SelectedEntity);
                ViewModel.SaveData(null);
            }
            finally
            {
                Cursor = currentCursor;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void InitViewAndViewModel(int faLeistungId)
        {
            _faLeistungId = faLeistungId;
            BudgetPositionView.InitViewAndViewModel();
            ViewModel.Init(faLeistungId, BudgetPositionView.ViewModel);
            AddNewButton();
        }

        #endregion

        #region Protected Methods

        protected override IViewModelCRUD GetViewModel()
        {
            return FindResource("viewModel") as IViewModelCRUD;
        }

        #endregion

        #region Private Methods

        private void AddNewButton()
        {
            var newDataCommandString = PropertyName.GetPropertyName(() => ViewModel.NewDataCommand);
            var kategorieString = PropertyName.GetPropertyName(() => ViewModel.Kategorie);
            var kategorieNameString = PropertyName.GetPropertyName(() => ViewModel.Kategorie.FirstOrDefault().Name);

            for (int i = 0; i < ViewModel.Kategorie.Count; i++)
            {
                var button = new KissButton();
                var commandBinding = new Binding(newDataCommandString);
                button.SetBinding(ButtonBase.CommandProperty, commandBinding);
                var commandParameterBinding = new Binding(string.Format("{0}[{1}]", kategorieString, i));
                button.SetBinding(ButtonBase.CommandParameterProperty, commandParameterBinding);
                var contentBinding = new Binding(string.Format("{0}[{1}].{2}", kategorieString, i, kategorieNameString));
                button.SetBinding(ContentProperty, contentBinding);
                button.Width = 100;
                button.VerticalAlignment = VerticalAlignment.Center;
                button.Margin = LayoutConstant.MarginDetailControlRight;
                button.TabIndex = i + 1;

                //Binding auf Dauerauftragaktiv.
                //Es können nur neue Positionen erstellt werden, wenn Dauerauftrag inaktiv ist.
                Binding binding = new Binding("DauerauftragAktiv");
                binding.Converter = new BoolInvertConverter();
                button.SetBinding(ButtonBase.IsEnabledProperty, binding);

                panNewButton.Children.Add(button);
            }
        }

        private void CustomSummary(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridSummaryItem item = (GridSummaryItem)e.Item;
            switch (item.FieldName)
            {
                case "Saldo":
                    ViewModel.CalculateSummary_Saldo(e);
                    break;

                case "WshAbzug.WshGrundbudgetPosition.BetragMonatlich":
                    ViewModel.CalculateSummary_BetragMonatlich(e);
                    break;

                case "GblAbzugProzent":
                    ViewModel.CalculateSummary_ProzentGbl(e);
                    break;

                default:
                    throw new ArgumentException("Unknown value for GridSummaryItem.FieldName: " + item.FieldName);
            }
        }

        private string GetDialogText()
        {
            const string dialogText = "GBL/Zulagen";

            if (ViewModel.SelectedEntity.WshAbzug.WshGrundbudgetPosition != null &&
                ViewModel.SelectedEntity.WshAbzug.WshGrundbudgetPosition.WshKategorie != null)
            {
                return string.Format("{0} - {1}", ViewModel.SelectedEntity.WshAbzug.WshGrundbudgetPosition.WshKategorie.Name, dialogText);
            }

            return dialogText;
        }

        #endregion

        #endregion
    }
}