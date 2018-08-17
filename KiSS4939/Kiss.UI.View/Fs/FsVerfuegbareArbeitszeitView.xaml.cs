using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using Kiss.UI.Controls;
using Kiss.UI.Controls.Converter;
using Kiss.UI.ViewModel.Fs;

namespace Kiss.UI.View.Fs
{
    /// <summary>
    /// Interaction logic for FsVerfuegbareArbeitszeitView
    /// </summary>
    public partial class FsVerfuegbareArbeitszeitView
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string REDUKTIONEN_GUELTIGEREDUKTIONZEIT = "Reduktionen({0}).GueltigeReduktionZeit";
        private const string REDUKTIONEN_ISREDUKTIONMANUALLYCHANGED = "Row.Reduktionen[{0}].IsReduktionManuallyChanged";

        #endregion

        #endregion

        #region Constructors

        public FsVerfuegbareArbeitszeitView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
            ((FsVerfuegbareArbeitszeitVM)ViewModel).Init();
            InitDevXView();
        }

        #endregion

        #region Private Static Methods

        private static void AssignCellStyle(GridColumn column, int fsReduktionID)
        {
            var style = new Style(typeof(LightweightCellEditor));
            var editableBackgroundBrush = Application.Current.Resources["brushDataGridEditableBackground"] as Brush;
            style.Setters.Add(new Setter
                                  {
                                      Property = LightweightCellEditor.BackgroundProperty,
                                      Value = editableBackgroundBrush
                                  });
            style.Setters.Add(new Setter
                                  {
                                      Property = TextElement.FontWeightProperty,
                                      Value = new Binding
                                      {
                                          Path = new PropertyPath(string.Format(REDUKTIONEN_ISREDUKTIONMANUALLYCHANGED, fsReduktionID)),
                                          Converter = new Bool2FontWeightConverter(),
                                          ConverterParameter = FontWeights.Bold,
                                          Mode = BindingMode.OneWay
                                      },
                                  });
            column.CellStyle = style;
        }

        #endregion

        #region Private Methods

        private GridColumn CreateNewColumn(string header)
        {
            return new GridColumn
            {
                Header = header,
                FixedWidth = true,
                Width = 80,
                EditSettings = new CalcEditSettings
                {
                    MaskType = DevExpress.Xpf.Editors.MaskType.Numeric,
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
            };
        }

        /// <summary>
        /// Initialisiert die dynamischen Spalten.
        /// </summary>
        private void InitDevXView()
        {
            int columnIndex = 3;
            foreach (var fsReduktion in ((FsVerfuegbareArbeitszeitVM)ViewModel).Reduktionen)
            {
                string header = string.Format("{0} [h]", fsReduktion.Name);
                var col = CreateNewColumn(header);
                col.VisibleIndex = columnIndex++;

                var path = string.Format(REDUKTIONEN_GUELTIGEREDUKTIONZEIT, fsReduktion.FsReduktionID);
                ComplexBindingHelper.SetComplexFieldName(col, path);

                AssignCellStyle(col, fsReduktion.FsReduktionID);
                grdVerfuegbareArbeitszeit.Columns.Add(col);
            }
        }

        #endregion

        #endregion
    }
}