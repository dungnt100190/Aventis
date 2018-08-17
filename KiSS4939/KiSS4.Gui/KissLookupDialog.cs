using DevExpress.Utils;
using KiSS4.DB;
using KiSS4.Gui.Layout;
using System;
using System.Data;
using System.Windows.Forms;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissLookupDialog.
    /// </summary>
    public partial class KissLookupDialog : KissDialog
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly bool _doNotUseTranslatedTitle;

        /// <summary>
        /// Initializes a new instance of the <see cref="KissLookupDialog"/> class.
        /// </summary>
        public KissLookupDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KissLookupDialog"/> class.
        /// </summary>
        /// <param name="dialogCaption">string to show in the caption of the dialog. Note that you need to localize this string before passing to the c'tor here.</param>
        public KissLookupDialog(string dialogCaption)
            : this()
        {
            Text = dialogCaption;
            _doNotUseTranslatedTitle = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KissLookupDialog"/> class.
        /// </summary>
        /// <param name="dialogCaption">string to show in the caption of the dialog. Note that you need to localize this string before passing to the c'tor here.</param>
        /// <param name="selectionCondition">string to find the first row which meets this SQL-based condition. The found row will then be selected</param>
        public KissLookupDialog(string dialogCaption, string selectionCondition)
            : this(dialogCaption)
        {
            SelectionCondition = selectionCondition;
        }

        /// <summary>
        /// Timeout in seconds on the SqlQuery object
        /// </summary>
        public int FillTimeout
        {
            get
            {
                return qry.FillTimeOut;
            }
            set
            {
                qry.FillTimeOut = value;
            }
        }

        /// <summary>
        /// Gets the selected result row.
        /// </summary>
        public DataRow ResultRow
        {
            get;
            protected set;
        }

        public string SelectionCondition
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the <see cref="System.Object"/> with the specified column name.
        /// </summary>
        /// <value></value>
        public object this[String columnName]
        {
            get
            {
                if (ResultRow == null)
                {
                    return DBNull.Value;
                }

                try
                {
                    return ResultRow[columnName];
                }
                catch
                {
                    return DBNull.Value;
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="System.Object"/> with the specified column index.
        /// </summary>
        /// <value></value>
        public object this[Int32 columnIndex]
        {
            get
            {
                if (ResultRow == null)
                {
                    return DBNull.Value;
                }

                try
                {
                    return ResultRow[columnIndex];
                }
                catch
                {
                    return DBNull.Value;
                }
            }
        }

        /// <summary>
        /// Convert a value to a literal that can be used in a search query.
        /// Replaces "*", "," and " " by "%" and "?" by "_"
        /// </summary>
        /// <param name="searchString">The search string to prepare</param>
        /// <returns>Prepared search string with replaced characters</returns>
        public static string PrepareSearchString(string searchString)
        {
            // validate parameter
            if (searchString == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(searchString))
            {
                return "";
            }

            // replace characters
            return searchString.Replace("*", "%").Replace("?", "_").Replace(",", "%").Replace(" ", "%");
        }

        /// <summary>
        /// Starts the search.
        /// </summary>
        /// <param name="lookupSql">The lookup SQL.</param>
        /// <param name="searchString">The search string.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public Boolean SearchData(String lookupSql, String searchString, Boolean openDialog)
        {
            return SearchData(lookupSql, searchString, openDialog, null, null, null, null, null, null);
        }

        /// <summary>
        /// Starts the search.
        /// </summary>
        /// <param name="lookupSql">The lookup SQL.</param>
        /// <param name="searchString">The search string.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <param name="contextValue1">The context value1.</param>
        /// <returns></returns>
        public Boolean SearchData(String lookupSql, String searchString, Boolean openDialog, Object contextValue1)
        {
            return SearchData(lookupSql, searchString, openDialog, contextValue1, null, null, null, null, null);
        }

        /// <summary>
        /// Starts the search.
        /// </summary>
        /// <param name="lookupSql">The lookup SQL.</param>
        /// <param name="searchString">The search string.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <param name="contextValue1">The context value1.</param>
        /// <param name="contextValue2">The context value2.</param>
        /// <returns></returns>
        public Boolean SearchData(String lookupSql, String searchString, Boolean openDialog, Object contextValue1, Object contextValue2)
        {
            return SearchData(lookupSql, searchString, openDialog, contextValue1, contextValue2, null, null, null, null);
        }

        /// <summary>
        /// Starts the search.
        /// </summary>
        /// <param name="lookupSql">The lookup SQL.</param>
        /// <param name="searchString">The search string.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <param name="contextValue1">The context value1.</param>
        /// <param name="contextValue2">The context value2.</param>
        /// <param name="contextValue3">The context value3.</param>
        /// <returns></returns>
        public Boolean SearchData(String lookupSql, String searchString, Boolean openDialog, Object contextValue1, Object contextValue2, Object contextValue3)
        {
            return SearchData(lookupSql, searchString, openDialog, contextValue1, contextValue2, contextValue3, null, null, null);
        }

        /// <summary>
        /// Starts the search.
        /// </summary>
        /// <param name="lookupSql">The lookup SQL.</param>
        /// <param name="searchString">The search string.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <param name="contextValue1">The context value1.</param>
        /// <param name="contextValue2">The context value2.</param>
        /// <param name="contextValue3">The context value3.</param>
        /// <param name="contextValue4">The context value4.</param>
        /// <returns></returns>
        public Boolean SearchData(String lookupSql, String searchString, Boolean openDialog, Object contextValue1, Object contextValue2, Object contextValue3, Object contextValue4)
        {
            return SearchData(lookupSql, searchString, openDialog, contextValue1, contextValue2, contextValue3, contextValue4, null, null);
        }

        /// <summary>
        /// Starts the search.
        /// </summary>
        /// <param name="lookupSql">The lookup SQL.</param>
        /// <param name="searchString">The search string.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <param name="contextValue1">The context value1.</param>
        /// <param name="contextValue2">The context value2.</param>
        /// <param name="contextValue3">The context value3.</param>
        /// <param name="contextValue4">The context value4.</param>
        /// <param name="contextValue5">The context value5.</param>
        /// <returns></returns>
        public Boolean SearchData(String lookupSql, String searchString, Boolean openDialog, Object contextValue1, Object contextValue2, Object contextValue3, Object contextValue4, Object contextValue5)
        {
            return SearchData(lookupSql, searchString, openDialog, contextValue1, contextValue2, contextValue3, contextValue4, contextValue5, null);
        }

        /// <summary>
        /// Starts the search.
        /// </summary>
        /// <param name="lookupSql">The lookup SQL.</param>
        /// <param name="searchString">The search string.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <param name="contextValue1">The context value1.</param>
        /// <param name="contextValue2">The context value2.</param>
        /// <param name="contextValue3">The context value3.</param>
        /// <param name="contextValue4">The context value4.</param>
        /// <param name="contextValue5">The context value5.</param>
        /// <param name="contextValue6">The context value6.</param>
        /// <returns></returns>
        public Boolean SearchData(String lookupSql, String searchString, Boolean openDialog, Object contextValue1, Object contextValue2, Object contextValue3, Object contextValue4, Object contextValue5, Object contextValue6)
        {
            // fill query
            if (!qry.Fill(lookupSql, searchString, contextValue1, contextValue2, contextValue3, contextValue4, contextValue5, contextValue6))
            {
                // fill() failed due to unknown reason, show message and cancel
                KissMsg.ShowInfo("KissLookupDialog", "ErrorFillInSearchData", "Die Daten konnten nicht geladen werden, die Suche wird abgebrochen.");
                return false;
            }

            if (qry.Count == 0)
            {
                // no data found
                KissMsg.ShowInfo("KissLookupDialog", "KeineDatensaetze", "Keine zutreffenden Datensätze gefunden.");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                // return single row found
                ResultRow = qry.DataTable.Rows[0];
                return true;
            }

            // apply datasource
            grd.DataSource = qry;

            // show dialog with best sized columns
            return DisplayDialog(true);
        }

        /// <summary>
        /// Adds the grid column.
        /// </summary>
        /// <param name="caption">The caption for the column</param>
        /// <param name="fieldName">Name of the field for databinding of column</param>
        /// <param name="width">The width of the column</param>
        protected void AddGridColumn(String caption, String fieldName, Int32 width)
        {
            AddGridColumn(caption, fieldName, width, HorzAlignment.Default);
        }

        /// <summary>
        /// Adds the grid column.
        /// </summary>
        /// <param name="caption">The caption for the column</param>
        /// <param name="fieldName">Name of the field for databinding of column</param>
        /// <param name="width">The width of the column</param>
        /// <param name="alignment">The alignment of the text within the column</param>
        protected void AddGridColumn(String caption, String fieldName, Int32 width, HorzAlignment alignment)
        {
            DevExpress.XtraGrid.Columns.GridColumn col = grv.Columns.Add();

            col.Caption = caption;
            col.FieldName = fieldName;
            col.Name = fieldName;
            col.VisibleIndex = grv.Columns.Count - 1;
            col.Width = width;
            col.AppearanceCell.Options.UseTextOptions = true;
            col.AppearanceCell.TextOptions.HAlignment = alignment;
        }

        /// <summary>
        /// Displays the dialog.
        /// Columns with the ending "$" will not be displayed.
        /// </summary>
        /// <returns></returns>
        protected Boolean DisplayDialog()
        {
            return DisplayDialog(false);
        }

        /// <summary>
        /// Displays the dialog.
        /// Columns with the ending "$" will not be displayed.
        /// </summary>
        /// <param name="bestFitColumns"><c>true</c> if columns shall be autopopulated (if none defined) and have its best width, <c>false</c> (default) if width is fixed and predefined</param>
        /// <returns></returns>
        protected Boolean DisplayDialog(Boolean bestFitColumns)
        {
            // check if autosize columns
            if (bestFitColumns)
            {
                // autosize all columns
                grv.BestFitColumns();
            }

            // enlarge modal Dialog to display all columns
            Int32 gridWidth = grd.Left + SystemInformation.VerticalScrollBarWidth; // Border + Scrollspace

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
            {
                if (!DBUtil.IsEmpty(col.FieldName) && col.FieldName.EndsWith("$"))
                {
                    // Hide Columns ending with $
                    col.VisibleIndex = -1;
                }
                else
                {
                    gridWidth += col.Width + 1; // vertical line;
                }
            }

            // set form width
            Width += gridWidth - grd.Width; // grd.Width set automatically by anchoring

            // maximum width is 900
            if (Width > 900)
            {
                Width = 900;
            }

            // minimum width
            // cgl: Musste massiv verbreitern.
            // User waren nicht zufrieden, dass Labels "Anzahl Datensätze" + Wert durch
            // die Buttons Ok und Abbrechen verdeckt war. Feedback von ZH, Claudia Corrodi
            if (Width < 370)
            {
                Width = 370;
            }

            // If a SelectionCondition is specified, use it for selecting the first found entry
            if (!string.IsNullOrEmpty(SelectionCondition))
            {
                try
                {
                    qry.Find(SelectionCondition);
                }
                catch (Exception ex)
                {
                    _logger.Warn("Error finding a row to select. SelectionCondition=" + SelectionCondition, ex);
                }
            }

            // handle caption given by constructor
            if (_doNotUseTranslatedTitle && Translation != null && Translation.Components != null && Translation.Components.ContainsKey(Name))
            {
                // remove translation of "Text" property of dialog to have own title displayed
                Translation.Components.Remove(Name);
            }

            // show dialog and check if user clicked ok
            var mainWindow = KissMsg.GetMainWindow();
            if (ShowDialog(mainWindow) == DialogResult.OK)
            {
                // apply
                ResultRow = qry.Row;
                return true;
            }

            // reset
            ResultRow = null;
            return false;
        }

        /// <summary>
        /// Stores the window's Left, Top, Width, Hight properties, then raises the GettingLayout event.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>Note to inheritors: base implementation must be called.</remarks>
        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            // prevent getting last Layout
        }

        /// <summary>
        /// Stores the window's Left, Top, Width, Hight properties, then raises the SettingLayout event.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>Note to inheritors: base implementation must be called.</remarks>
        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            // prevent setting Layout
        }

        /// <summary>
        /// Handles the DoubleClick event of the grd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void grd_DoubleClick(Object sender, System.EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void qry_AfterFill(Object sender, EventArgs e)
        {
            // setup counter
            lblCount.Text = KissMsg.GetMLMessage("KissLookupDialog", "RowCounter", "Anzahl Datensätze: {0}", KissMsgCode.Text, qry.Count);
        }
    }
}