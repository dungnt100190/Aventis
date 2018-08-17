using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using Kiss.UI.Controls.Converter;
using Kiss.UI.ViewModel.Wsh;

using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;

namespace Kiss.UI.View.Wsh.Controls
{
    public class CellTemplateSelector : DataTemplateSelector
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly UserControl _control;
        private readonly bool _isAusgabe;

        #endregion

        #endregion

        #region Constructors

        public CellTemplateSelector(UserControl control, bool isAusgabe)
        {
            _control = control;
            _isAusgabe = isAusgabe;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">The data object for which to select the template.</param>
        /// <param name="container">The data-bound object.</param>
        /// <returns>Returns a DataTemplate or null. The default value is null.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var col = item as GridCellData;

            if (col == null)
            {
                return base.SelectTemplate(item, container);
            }

            var positionVM = col.RowData.Row as WshAuszahlvorschlagPositionVM;

            if (positionVM == null)
            {
                return base.SelectTemplate(item, container);
            }

            if (positionVM.DTO.IsAusgabe == _isAusgabe)
            {
                //normal
                return null;
            }

            //readonly
            return (DataTemplate)_control.FindResource("ReadonlyDataTemplate");
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// Interaction logic for WshAuszahlvorschlagControl.xaml
    /// </summary>
    public partial class WshAuszahlvorschlagControl : UserControl
    {
        #region Constructors

        public WshAuszahlvorschlagControl()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void BelegFreigeben_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((WshAuszahlvorschlagVM)DataContext).CanExecuteBelegFreigeben(e.Parameter);
        }

        private void BelegFreigeben_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((WshAuszahlvorschlagVM)DataContext).BelegFreigeben(e.Parameter);
        }

        private void DeleteBeleg_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((WshAuszahlvorschlagVM)DataContext).CanExecuteDeleteBeleg(e.Parameter);
        }

        private void DeleteBeleg_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((WshAuszahlvorschlagVM)DataContext).DeleteBeleg(e.Parameter);

        }

        private void SplitBeleg_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((WshAuszahlvorschlagVM)DataContext).CanExecuteSplitBeleg(e.Parameter);
        }


        private void AlleFreigeben_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((WshAuszahlvorschlagVM)DataContext).CanExecuteAlleBelegeFreigeben(e.Parameter);
        }

        private void SplitBeleg_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((WshAuszahlvorschlagVM)DataContext).SplitBeleg(e.Parameter);
        }


        private void AlleBelegeFreigeben_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            bool result = ((WshAuszahlvorschlagVM)DataContext).AlleBelegeFreigeben();
            if (result)
            {
                ViewHelper.CloseDialog(this, null);
            }
        }

        private void cbxInklFreigegebene_Click(object sender, RoutedEventArgs e)
        {
            InklFreigegebene = cbxInklFreigegebene.IsChecked ?? false;
        }

        private bool InklFreigegebene
        {
            set
            {
                grdAuszahlvorschlagPositionen.BeginInit();

                //http://www.devexpress.com/Support/Center/p/Q303782.aspx
                var viewModel = (WshAuszahlvorschlagVM)DataContext;

                if (viewModel != null)
                {
                    viewModel.InklFreigegebene = value;
                }
                grdAuszahlvorschlagPositionen.EndInit();
            }
        }

        private void grdAuszahlvorschlagPositionen_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            //propagate to the other scrollViewers
            scrKreditor.ScrollToHorizontalOffset(e.HorizontalOffset);
            scrAuszahlvorschlagBelegActions.ScrollToHorizontalOffset(e.HorizontalOffset);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init()
        {
            WshAuszahlvorschlagVM viewModel = (WshAuszahlvorschlagVM)DataContext;
            int belegIndex = 0;
            int columnIndex = grdAuszahlvorschlagPositionen.Columns.Aggregate(0, (current, col) => Math.Max(current, col.VisibleIndex));
            columnIndex++;

            foreach (var beleg in viewModel.AuszahlvorschlagBelege)
            {
                // visibility multibinding with converter
                var visibilityBinding = new MultiBinding();
                visibilityBinding.Bindings.Add(new Binding("InklFreigegebene"));
                visibilityBinding.Bindings.Add(new Binding(string.Format("AuszahlvorschlagBelege[{0}].IsNotFreigegeben", belegIndex)));
                var converter = new MultiBoolean2BooleanConverter { UseAndOperator = false, TrueValue = true, FalseValue = false };
                visibilityBinding.Converter = converter;

                // column "Ausgabe"
                var col = CreateNewColumn("Ausgabe");
                col.VisibleIndex = columnIndex++;

                ComplexBindingHelper.SetComplexFieldName(col, string.Format("BelegPositionen[{0}].Ausgabe", belegIndex));
                grdAuszahlvorschlagPositionen.Columns.Add(col);
                col.SetBinding(ColumnBase.VisibleProperty, visibilityBinding);

                //Binding. Belege sind nur im Status Vorbereitet editierbar. 
                SetColumnReadonlyBinding(col, beleg);

                var templateSelector = new CellTemplateSelector(this, true);
                col.CellTemplateSelector = templateSelector;

                // column "Einnahme": show only if has a value
                if (beleg.DTO.HatEinnahmePositionen)
                {
                    col = CreateNewColumn("Einnahme");
                    col.VisibleIndex = columnIndex++;

                    ComplexBindingHelper.SetComplexFieldName(col, string.Format("BelegPositionen[{0}].Einnahme", belegIndex));
                    grdAuszahlvorschlagPositionen.Columns.Add(col);

                    col.SetBinding(ColumnBase.VisibleProperty, visibilityBinding);

                    templateSelector = new CellTemplateSelector(this, false);
                    col.CellTemplateSelector = templateSelector;

                    SetColumnReadonlyBinding(col, beleg);
                }

                belegIndex++;
            }

            // column "Rest": shows the amount of money not used.
            GridColumn colRest = CreateNewColumn("Rest");
            colRest.VisibleIndex = columnIndex;
            colRest.Fixed = FixedStyle.Right;
            ComplexBindingHelper.SetComplexFieldName(colRest, "Rest");
            Style style = (Style)FindResource("RedIfNegativeStyle");
            colRest.CellStyle = style;
            grdAuszahlvorschlagPositionen.Columns.Add(colRest);

            cbxInklFreigegebene.IsChecked = true;
            InklFreigegebene = true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Nur vorbereitete Belege sind im Grid editierbar.
        /// Krediert ein Binding zum Status des Belegs.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="beleg"></param>
        private void SetColumnReadonlyBinding(GridColumn col, WshAuszahlvorschlagBelegVM beleg)
        {
            Binding readonlyColBinding = new Binding("DTO.Status");
            readonlyColBinding.Source = beleg;
            readonlyColBinding.Converter = new KbuStatusBeleg2BoolConverter();
            col.SetBinding(GridColumn.AllowEditingProperty, readonlyColBinding);
        }


        private GridColumn CreateNewColumn(string header)
        {
            var style = (Style)FindResource("EditableCellStyle");
            return new GridColumn
            {
                Header = header,
                FixedWidth = true,
                Width = 80,
                EditSettings = new CalcEditSettings
                {
                    Mask = "N2",
                    Precision = 2,
                    IsTextEditable = true,
                    AllowDefaultButton = false,
                    MaskUseAsDisplayFormat = true,
                },
                UnboundType = UnboundColumnType.Decimal,
                AllowResizing = DefaultBoolean.False,
                AllowSorting = DefaultBoolean.False,
                AllowMoving = DefaultBoolean.False,
                AllowGrouping = DefaultBoolean.False,
                AllowEditing = DefaultBoolean.True,
                AllowUnboundExpressionEditor = false,
                CellStyle = style
            };
        }

        #endregion

        #endregion
    }
}