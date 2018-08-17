using System;
using System.ComponentModel;
using System.Windows;

using Kiss.Infrastructure.Constant;
using Kiss.Model.DTO.Vm;
using Kiss.UI.ViewModel.Vm;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.View.Vm
{
    /// <summary>
    /// Interaction logic for VmKlientenbudgetKategorieView.xaml
    /// </summary>
    public partial class VmKlientenbudgetKategorieView
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(VmKlientenbudgetKategorieView), new PropertyMetadata(false, IsReadonlyChanged));
        public static readonly DependencyProperty VmKategorieProperty =
            DependencyProperty.Register("VmKategorie", typeof(LOVsGenerated.VmKategorie), typeof(VmKlientenbudgetKategorieView), new PropertyMetadata(InitViewModelHandler));
        public static readonly DependencyProperty VmKlientenbudgetDTOProperty =
            DependencyProperty.Register("VmKlientenbudgetDTO", typeof(VmKlientenbudgetDTO), typeof(VmKlientenbudgetKategorieView), new PropertyMetadata(InitViewModelHandler));

        #endregion

        #endregion

        #region Constructors

        public VmKlientenbudgetKategorieView()
        {
            DataControlBase.AllowInfiniteGridSize = true;
            InitializeComponent();
        }

        #endregion

        #region Properties

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public new VmKlientenbudgetKategorieVM ViewModel
        {
            get { return (VmKlientenbudgetKategorieVM)base.ViewModel; }
        }

        public LOVsGenerated.VmKategorie VmKategorie
        {
            get { return (LOVsGenerated.VmKategorie)GetValue(VmKategorieProperty); }
            set { SetValue(VmKategorieProperty, value); }
        }

        public VmKlientenbudgetDTO VmKlientenbudgetDTO
        {
            get { return (VmKlientenbudgetDTO)GetValue(VmKlientenbudgetDTOProperty); }
            set { SetValue(VmKlientenbudgetDTOProperty, value); }
        }

        #endregion

        #region EventHandlers

        private void ColImport_ButtonClick(object sender, RoutedEventArgs e)
        {
            ViewModel.ImportData();
        }

        private void ColLoeschen_ButtonClick(object sender, RoutedEventArgs e)
        {
            DeleteData();
        }

        private void KissView_Loaded(object sender, RoutedEventArgs e)
        {
            // (DevExpress) Wenn Visibility einer Column ändert, werden alle VisibleIndexes neu berechnet, also nach vorne verschoben
            colBemerkungen.VisibleIndex = 5;
        }

        private void TableView_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            // prevent editing of certain rows
            var dto = e.Row as VmPositionDTO;

            if (dto != null)
            {
                if (!(e.Column == colBemerkungen && dto.CanEditBemerkung) &&
                    !dto.CanEdit)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ViewModel_MoveCommandExecuted(object sender, EventArgs e)
        {
            grdPositionen.RefreshData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // focus on first column
            grdPositionen.Focus();
            ((TableView)grdPositionen.View).FocusedColumn = colName;
        }

        private void grdPositionen_CustomSummary(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            e.TotalValue = "Total " + ViewModel.Title;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
            InitViewModel();
        }

        #endregion

        #region Private Static Methods

        private static void InitViewModelHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = (VmKlientenbudgetKategorieView)d;
            view.InitViewModel();
        }

        private static void IsReadonlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = (VmKlientenbudgetKategorieView)d;
            view.ViewModel.IsReadOnly = (bool)e.NewValue;
        }

        #endregion

        #region Private Methods

        private void InitViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            ViewModel.MoveCommandExecuted += ViewModel_MoveCommandExecuted;
            ViewModel.Init(VmKategorie, VmKlientenbudgetDTO);
        }

        #endregion

        #endregion
    }
}