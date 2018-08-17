using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;

using Kiss.Infrastructure;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// DevExpress KiSS-Grid.
    /// </summary>
    /// <remarks>
    /// XAML kann nicht verwendet werden, da offenbar bereits die Basisklasse (GridControl) XAML verwendet
    /// und XAML-Vererbung momentan nicht funktioniert.
    /// http://connect.microsoft.com/VisualStudio/feedback/details/483024/wpf-error-message-cannot-set-name-attribute-value-0-on-element-1-1-is-under-the-scope-of-element-2-which-already-had-a-name-registered-when-it-was-defined-in-another-scope
    /// </remarks>
    [TemplatePart(Name = ELEMENT_ROOTPANEL, Type = typeof(ContentControl))]
    [TemplatePart(Name = ELEMENT_THEMESLOADER, Type = typeof(DXGridThemesLoader))]
    public class KissGrid : GridControl
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(GridControl), new PropertyMetadata(null, SelectedItemChanged));

        #endregion

        #region Private Constant/Read-Only Fields

        private const string ELEMENT_ROOTPANEL = "PART_RootPanel";
        private const string ELEMENT_THEMESLOADER = "PART_ThemesLoader";

        #endregion

        #region Private Fields

        private BarButtonItem _btnExcelExport;
        private BarButtonItem _btnPrintPreview;

        #endregion

        #endregion

        #region Constructors

        public KissGrid()
        {
            ResourceUtil.CreateStaticResourcesForDesigner(this);
            AllowInfiniteGridSize = true;
            DefaultSelectedRow = DefaultSelectedRow.Custom;
            /*
             * TODO: Wenn Lokalisierung mittels sattellite assemblies von DevExpress OK, kann KissGridLocalizer entfernt werden.
            GridControlLocalizer.Active = KissGridLocalizer.Instance;
            */
        }

        #endregion

        #region Events

        public event MouseButtonEventHandler FocusedRowDoubleClick;

        public event EventHandler SelectingDefaultRow;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the default selected row type.
        /// The default value is <see cref="Kiss.Infrastructure.DefaultSelectedRow.Custom"/>, which triggers the <see cref="SelectingDefaultRow"/>-event only.
        /// Normally you should use the DefaultSelectedRow property on ViewModelList.
        /// </summary>
        public DefaultSelectedRow DefaultSelectedRow
        {
            get;
            set;
        }

        public ContentControl RootPanel
        {
            get { return Template.FindName(ELEMENT_ROOTPANEL, this) as ContentControl; }
        }

        /// <summary>
        /// Gets or sets the currently selected item
        /// </summary>
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public DXGridThemesLoader ThemesLoader
        {
            get { return Template.FindName(ELEMENT_THEMESLOADER, this) as DXGridThemesLoader; }
        }

        #endregion

        #region EventHandlers

        private void _btnExcelExport_Click(object sender, RoutedEventArgs e)
        {
            ExcelExport();
        }

        private void _btnPrintPreview_Click(object sender, RoutedEventArgs e)
        {
            PrintPreview();
        }

        /// <summary>
        /// Used to prevent other selection in case validation fails.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_BeforeLayoutRefresh(object sender, CancelRoutedEventArgs e)
        {
            // Validation from ViewModel
            //e.Cancel = IsRowChangeAllowed();
            //_lastAcceptedEntity = entity;
        }

        private void View_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var newSelectedItem = e.NewRow;

            if (newSelectedItem != SelectedItem)
            {
                SelectedItem = newSelectedItem;

                // if row change was rejected (because of validation in VM), re-focus the previously focused row
                if (SelectedItem != newSelectedItem)
                {
                    View.FocusedRow = SelectedItem;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissGrid)d;

            if (instance.View != null)
            {
                if (instance.View.FocusedRow == e.NewValue)
                {
                    return;
                }

                instance.View.FocusedRow = e.NewValue;
            }
        }

        #endregion

        #region Protected Methods

        protected virtual void OnFocusedRowDoubleClick(MouseButtonEventArgs e)
        {
            if (FocusedRowDoubleClick != null)
            {
                FocusedRowDoubleClick(this, e);
            }
        }

        protected override void OnLoaded(object sender, RoutedEventArgs e)
        {
            base.OnLoaded(sender, e);

            if (View != null)
            {
                View.BeforeLayoutRefresh += View_BeforeLayoutRefresh;
                View.FocusedRowChanged += View_FocusedRowChanged;

                // Best fit columns initially
                ((TableView)View).BestFitMaxRowCount = 30;
                ((TableView)View).BestFitColumns();

                switch (DefaultSelectedRow)
                {
                    case DefaultSelectedRow.First:
                        View.MoveFirstRow();
                        break;

                    case DefaultSelectedRow.Last:
                        View.MoveLastRow();
                        break;

                    case DefaultSelectedRow.Custom:
                        if (SelectingDefaultRow != null)
                        {
                            SelectingDefaultRow(this, EventArgs.Empty);
                        }
                        break;
                }

                InitPopupMenu();
            }
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (View != null)
            {
                var handle = View.GetRowHandleByMouseEventArgs(e);

                if (handle != InvalidRowHandle && handle == View.FocusedRowHandle)
                {
                    OnFocusedRowDoubleClick(e);
                }
            }
        }

        protected override void OnPreviewMouseDoubleClick(MouseButtonEventArgs e)
        {
            var obj = e.OriginalSource as DependencyObject;

            // suppress event?
            if (!IsWithinGridRow(obj))
            {
                e.Handled = true;
                return;
            }

            base.OnPreviewMouseDoubleClick(e);
        }

        #endregion

        #region Private Methods

        private void AddPopupMenuEntry(ref BarButtonItem btn, string caption, IconHelper.Icons icon, ItemClickEventHandler clickEvent)
        {
            if (btn == null)
            {
                btn = new BarButtonItem();
            }

            btn.Content = caption;
            btn.Glyph = IconHelper.IconImageSmall(icon).Source;

            btn.ItemClick -= clickEvent;
            btn.ItemClick += clickEvent;

            View.RowCellMenuCustomizations.Remove(btn);
            View.RowCellMenuCustomizations.Add(btn);
        }

        private void ExcelExport()
        {
            Cursor = Cursors.Wait;

            try
            {
                var xlsExporter = new ExportToExcelProvider(this);
                xlsExporter.Export();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error ExcelExport from grid: {0}", ex.Message);

                // TODO....
                MessageBox.Show(string.Format("Es ist ein Fehler beim Exportieren nach Excel aufgetreten:{0}{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //KissMsg.ShowError("KissGrid", "FehlerExcelExport", "Fehler beim Exportieren nach Excel.", ex);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void InitPopupMenu()
        {
            // show popup only on TableView itself (see also: http://www.devexpress.com/Support/Center/e/E1558.aspx)
            if (View == null || !(View is TableView))
            {
                return;
            }

            AddPopupMenuEntry(ref _btnPrintPreview, "Drucken...", IconHelper.Icons.Print, _btnPrintPreview_Click);
            AddPopupMenuEntry(ref _btnExcelExport, "Excel Export", IconHelper.Icons.Excel, _btnExcelExport_Click);
        }

        private bool IsWithinGridRow(DependencyObject obj)
        {
            while (obj != null)
            {
                if (obj is GridRow)
                {
                    return true;
                }

                obj = VisualTreeHelper.GetParent(obj);
            }

            return false;
        }

        private void PrintPreview()
        {
            Cursor = Cursors.Wait;

            try
            {
                // see: http://www.devexpress.com/Support/Center/e/E1669.aspx
                // see: http://documentation.devexpress.com/#WPF/CustomDocument6160

                // TODO: This a very basic printing - see code below from KissGrid what we should do more...
                var link = new PrintableControlLink((TableView)View)
                {
                    Landscape = true,
                    PaperKind = PaperKind.A4,
                    Margins = new Margins(40, 40, 40, 40)
                };

                link.ShowPrintPreviewDialog(null);

                /*
                // ------- <KissGrid> -------
                View.OptionsPrint.AutoWidth = false;
                View.OptionsPrint.UsePrintStyles = true;
                View.OptionsPrint.ExpandAllGroups = false;

                View.PrintStyles["Row"].Font = new Font("Arial", 8f, FontStyle.Regular);

                PrintingSystem ps = new PrintingSystem();
                PrintableComponentLink plink = new PrintableComponentLink();

                if (ps == null || plink == null)
                {
                    return;
                }

                plink.PrintingSystem = ps;
                plink.Component = this;
                plink.CreateDocument();

                PageHeaderFooter HeaderFooter = (PageHeaderFooter)plink.PageHeaderFooter;

                HeaderFooter.Header.Font = new Font("Arial", 10f, FontStyle.Bold);
                HeaderFooter.Footer.Font = new Font("Arial", 8f, FontStyle.Regular);

                HeaderFooter.Footer.Content.Clear();
                HeaderFooter.Footer.Content.Add(KissMsg.GetMLMessage("KissGrid", "PrintDateFooter", "Druckdatum: {0}", KissMsgCode.Text, DateTime.Today.ToString("dd.MM.yyyy")));
                HeaderFooter.Footer.Content.Add("KiSS4");
                HeaderFooter.Footer.Content.Add(KissMsg.GetMLMessage("KissGrid", "PageFooter", "Seite [Page #]"));

                HeaderFooter.Header.Content.Clear();
                HeaderFooter.Header.Content.Add(KissMsg.GetMLMessage("KissGrid", "PrintOfTableHeader", "Ausdruck der Tabelle {0}", KissMsgCode.Text, this.HeaderString));

                PrintPreviewFormEx previewForm = ps.PreviewFormEx;

                ps.PageSettings.Landscape = true;
                ps.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
                ps.PageSettings.LeftMargin = 40;
                ps.PageSettings.RightMargin = 40;
                ps.PageSettings.TopMargin = 40;
                ps.PageSettings.BottomMargin = 40;

                OnXtraPrint(this, new XtraPrintEventArgs(plink));

                plink.CreateDocument();

                previewForm.Show();
                // ------- </KissGrid> -------
                */
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Printing from grid: {0}", ex.Message);

                // TODO....
                MessageBox.Show(string.Format("Es ist ein Fehler beim Erstellen der Druckvorschau aufgetreten:{0}{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //KissMsg.ShowError("KissGrid", "FehlerDrucken", "Fehler beim Drucken.", ex);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        #endregion

        #endregion
    }
}