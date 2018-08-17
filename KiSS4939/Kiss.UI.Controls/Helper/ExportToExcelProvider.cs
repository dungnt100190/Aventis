﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Documents;

using DevExpress.Data;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using Interop.Excel;
using Kiss.UI.Controls.Helper.Format;
using Kiss.UI.Controls.LocalResources;

using Application = Interop.Excel.Application;

namespace Kiss.UI.Controls.Helper
{
    /// <summary>
    /// Used to export data to Excel worksheet
    /// </summary>
    /// <remarks>
    /// TODO: Logik ist identisch mit KiSS4.Gui.KissExportXlsProvider
    /// </remarks>
    public class ExportToExcelProvider
    {
        /// <summary>
        /// Enumeration representing the different versions of Excel.
        /// </summary>
        private enum VersionEnum
        {
            /// <summary>
            /// Unknown version
            /// </summary>
            Unknown,

            /// <summary>
            /// Excel 2003 - Version 11.x or earlier
            /// </summary>
            Excel2003OrEarlier = 11,

            /// <summary>
            /// Excel 2007 - Version 12.x
            /// </summary>
            Excel2007 = 12,

            /// <summary>
            /// Excel 2010 - Version 14.x (Version 13 is skipped by Microsoft)
            /// </summary>
            Excel2010OrNewer,
        }

        private static readonly Color _headerColor = Color.Tan;
        private static readonly Color _summaryColor = Color.LightGray;
        private readonly int _columnCount;
        private readonly List<GridColumn> _gridColumns;
        private readonly GridControl _gridControl;
        private readonly TableView _gridView;
        private readonly int _groupedColumnCount;
        private readonly int _rowCount;
        private readonly bool _showFooter;
        private readonly string _workSheetName;

        /// <summary>
        /// Initialize a new instance to export to Excel.
        /// </summary>
        /// <param name="devXGrid">The <see cref="KissGrid"/> to use for exporting the *.View content.</param>
        public ExportToExcelProvider(GridControl devXGrid)
            : this(devXGrid, GetExportTitle())
        {
        }

        /// <summary>
        /// Initialize a new instance to export to Excel.
        /// </summary>
        /// <param name="devXGrid">The <see cref="KissGrid"/> to use for exporting the *.View content.</param>
        /// <param name="workSheetName">The name of the worksheet.</param>
        public ExportToExcelProvider(GridControl devXGrid, string workSheetName)
        {
            // validate parameters
            if (devXGrid == null)
            {
                throw new ArgumentNullException("devXGrid");
            }

            if (workSheetName == null)
            {
                throw new ArgumentNullException("workSheetName");
            }

            if (!(devXGrid.View is TableView))
            {
                throw new ArgumentOutOfRangeException("devXGrid", "The given grid-view is either null or not of the expected type");
            }

            // apply parameters to fields
            _gridControl = devXGrid;
            _gridView = (TableView)devXGrid.View;

            // we need all grouped and visible columns
            _gridColumns = new List<GridColumn>();
            foreach (var groupedColumn in _gridView.GroupedColumns)
            {
                _gridColumns.Add(groupedColumn);
            }
            foreach (var groupedColumn in _gridView.VisibleColumns)
            {
                _gridColumns.Add(groupedColumn);
            }

            _workSheetName = workSheetName;
            _columnCount = _gridColumns.Count;
            _groupedColumnCount = _gridControl.GroupCount;
            _showFooter = _gridView.ShowTotalSummary;

            _rowCount = GetActualRowCount();
        }

        /// <summary>
        /// Exports this instance to Excel.
        /// </summary>
        public void Export()
        {
            // check if we have any visible columns
            if (_gridColumns.Count == 0)
            {
                // no columns, cannot do export
                throw new InvalidOperationException("The given view does not contain any columns, the export cannot be performed.");
            }

            // BUG: Have to set locale to en-US
            // http://support.microsoft.com/kb/320369/en
            // save current culture
            var currentCi = Thread.CurrentThread.CurrentCulture;
            Application excelApp = null;

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                // init vars
                excelApp = CreateExcelApplication();

                // init excel for data-transfer
                excelApp.ScreenUpdating = false;
                excelApp.Cursor = XlMousePointer.xlWait;

                // show excel-gui
                excelApp.Visible = true;

                // open new workbook
                var ws = CreateExcelWorksheet(excelApp, _workSheetName);

                var watch = new Stopwatch();
                watch.Reset();
                watch.Start();

                // HEADER
                ExportColumnHeaders(ws, _gridColumns);

                // DATA
                var excelVersion = GetVersion(excelApp);
                ExportDataToWorksheet(excelVersion, ws);

                // FOOTER
                var hasSummary = ExportColumnFooter(excelVersion, ws, _gridColumns);

                watch.Stop();
                Debug.WriteLine("Consumed time for Excel-export: {0}ms", watch.ElapsedMilliseconds.ToString());

                // set autofit, borders, etc.
                FinalizeExcelWorksheet(ws, hasSummary);

                // Apply Subtotal Excel function
                ApplySubtotalFunction(ws);
            }
            finally
            {
                // refresh excel and reset cursor
                if (excelApp != null)
                {
                    excelApp.ScreenUpdating = true;
                    excelApp.Cursor = XlMousePointer.xlDefault;
                }

                // locales back to origin
                Thread.CurrentThread.CurrentCulture = currentCi;
            }
        }

        /// <summary>
        /// Convert the specified Color into an RGB value and mimics VBA's RGB function.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <remarks>This method does not the same as c.ToArgb()</remarks>
        /// <returns></returns>
        private static int ConvertToRgb(Color c)
        {
            // convert color to rgb-values
            return c.R + (c.G << 8) + (c.B << 16);
        }

        /// <summary>
        /// Creates a new instance of Excel application. Access running Excel or create a new application.
        /// </summary>
        /// <returns>An Excel application</returns>
        private static Application CreateExcelApplication()
        {
            try
            {
                return (Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                return new Application();
            }
        }

        /// <summary>
        /// Creates a new worksheet within given Excel application
        /// </summary>
        /// <param name="excelApplication">The Excel application to use</param>
        /// <param name="worksheetName">The name of the worksheet to use</param>
        /// <returns>A new worksheet within given Excel application</returns>
        private static Worksheet CreateExcelWorksheet(Application excelApplication, string worksheetName)
        {
            // validate
            if (excelApplication == null)
            {
                throw new ArgumentNullException("excelApplication", "Empty instance to Excel Application.");
            }

            if (worksheetName == null)
            {
                throw new ArgumentNullException("worksheetName", "Empty name of new worksheet to create.");
            }

            var workBook = excelApplication.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            var workSheet = (Worksheet)workBook.Sheets[1];

            // apply name to worksheet
            workSheet.Name = worksheetName;

            // return worksheet
            return workSheet;
        }

        private static string GetExportTitle()
        {
            /* ----------------------------------------------------------------
             * Make sure that:
             * - The name that you type does not exceed 31 characters.
             * - The name does not contain any of the following characters:  :  \  /  ?  *
             * - You did not leave the name blank.
             * ---------------------------------------------------------------- */
            return string.Format("KiSS Export, {0:dd}.{0:MM}.{0:yy} {0:t}", DateTime.Now).Replace(":", ".");
        }

        /// <summary>
        /// Gets the <see cref="VersionEnum"/> describing the version of the specified Excel <see cref="Interop.Excel.Application"/>.
        /// </summary>
        /// <param name="excelApp">The excel app.</param>
        /// <returns></returns>
        private static VersionEnum GetVersion(Application excelApp)
        {
            var version = excelApp.Version;

            //extract the major version (##.x)
            var index = version.IndexOf(".");

            if (index > 0)
            {
                version = version.Substring(0, index);
            }

            int majorVersion;

            if (!int.TryParse(version, out majorVersion))
            {
                return VersionEnum.Unknown;
            }

            if (majorVersion <= 11)
            {
                return VersionEnum.Excel2003OrEarlier;
            }

            if (majorVersion == 12)
            {
                return VersionEnum.Excel2007;
            }

            return VersionEnum.Excel2010OrNewer;
        }

        /// <summary>
        /// Convert the given cell value to it's type specific format value
        /// </summary>
        /// <param name="excelVersion">The excel version to use</param>
        /// <param name="cellValue">The cell value to prepare as specific object</param>
        /// <returns>The cell value as prepared and formated object</returns>
        private static object PrepareCellValue(VersionEnum excelVersion, object cellValue)
        {
            // type-depending format
            if (cellValue == null || cellValue is DBNull)
            {
                return String.Empty;
            }

            if (cellValue is DateTime)
            {
                var dateTime = (DateTime)cellValue;
                if (dateTime.Year < 1900)
                {
                    //#8855: Excel does not support dates earlier than 01.01.1900
                    //As a workaround, we have to convert it to a string, though we cannot properly sort
                    //the dates (#8664) then.
                    return ((DateTime)cellValue).ToString("dd.MM.yyyy");
                }

                return (DateTime)cellValue;
            }

            if (cellValue is decimal)
            {
                return (decimal)cellValue;
            }

            if (cellValue is bool)
            {
                return Convert.ToBoolean(cellValue) ? "x" : string.Empty;
            }

            if (cellValue is int)
            {
                return (int)cellValue;
            }

            var text = Convert.ToString(cellValue);

            // do we have rich-text?
            if (text.StartsWith(@"{\rtf"))
            {
                // Solution for Ticket 3847 (now done in WPF)
                var rtfBox = new RichTextBox();
                rtfBox.AppendText(text);
                text = new TextRange(rtfBox.Document.ContentStart, rtfBox.Document.ContentEnd).Text;
            }

            // Excel does only use LF (ALT + RETURN), CR would be displayed as specialchar
            text = text.Replace("\r\n", "\n").Trim();

            // Solution for Ticket 5790:
            // According to KB818808 (http://support.microsoft.com/kb/818808):
            // Excel <= 2003 does not support more than 911 characters to be added to a cell through COM (in an array)
            if (excelVersion == VersionEnum.Unknown || excelVersion == VersionEnum.Excel2003OrEarlier)
            {
                if (text.Length > 911)
                {
                    text = text.Substring(0, 911);
                }
            }

            return text;    // see below for further information
        }

        /// <summary>
        /// Applies the excel subtotal function to the worksheet
        /// </summary>
        /// <param name="worksheet"></param>
        private void ApplySubtotalFunction(Worksheet worksheet)
        {
            if (_gridControl.GroupCount <= 0)
            {
                return;
            }

            // with A1, A1 the datarange is automatically selected
            var range = worksheet.Range["A1", "A1"];

            var subTotalColumns = GetGroupSummaryList();

            if (!subTotalColumns.Any())
            {
                return;
            }

            foreach (var groupedColum in _gridView.GroupedColumns)
            {
                // For better illustration we call subtotal only once for each grouped column and consolidation function.
                foreach (var consFunction in subTotalColumns.Select(a => a.ConsolidationFunctionType).Distinct().ToList())
                {
                    var consolidationFunction = consFunction;
                    var sortcriteria = subTotalColumns.Where(b => b.ConsolidationFunctionType == consolidationFunction).Select(b => b.ColumnIndex);
                    range.Subtotal(CalculateColumnIndex(groupedColum), consFunction, sortcriteria.ToArray(), false);
                }
            }
        }

        private int CalculateColumnIndex(GridColumn column)
        {
            // Excel start count = 1
            var columnIndex = 1;
            foreach (var gridColumn in _gridColumns)
            {
                if (gridColumn.Equals(column))
                {
                    return columnIndex;
                }
                columnIndex++;
            }
            return -1;
        }

        /// <summary>
        /// Convert SummaryItemType to XlConsolidationFunction
        /// </summary>
        /// <param name="summaryType">SummaryItemType</param>
        /// <returns>XlConsolidationFunction</returns>
        private XlConsolidationFunction ConvertSummaryType(SummaryItemType summaryType)
        {
            switch (summaryType)
            {
                case SummaryItemType.Sum:
                    return XlConsolidationFunction.xlSum;
                case SummaryItemType.Min:
                    return XlConsolidationFunction.xlMin;
                case SummaryItemType.Max:
                    return XlConsolidationFunction.xlMax;
                case SummaryItemType.Count:
                    return XlConsolidationFunction.xlCount;
                case SummaryItemType.Average:
                    return XlConsolidationFunction.xlAverage;
                default:
                    return XlConsolidationFunction.xlUnknown;
            }
        }

        private bool ExportColumnFooter(VersionEnum excelVersion, Worksheet worksheet, List<GridColumn> columns)
        {
            if (!_showFooter)
            {
                return false;
            }

            var dataArray = new object[columns.Count];
            var hasSummary = false;

            // fill data array
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].TotalSummaries == null)
                {
                    continue;
                }

                var summary = columns[i].TotalSummaries.FirstOrDefault();
                object value;

                if (summary != null && summary.Item.SummaryType != SummaryItemType.None)
                {
                    value = summary.Value;
                    hasSummary = true;
                }
                else
                {
                    value = string.Empty;
                }

                dataArray[i] = PrepareCellValue(excelVersion, value);
            }

            // export to the worksheet
            var footerOffset = 3;
            var range = worksheet.Range[worksheet.Cells[_rowCount + footerOffset, 1], worksheet.Cells[_rowCount + footerOffset, _columnCount]];
            range.Value = dataArray;

            // set background color
            range.Interior.Color = ConvertToRgb(_summaryColor);

            return hasSummary;
        }

        /// <summary>
        /// Export column headers into given Excel worksheet
        /// </summary>
        /// <param name="workSheet">The Excel worksheet to use</param>
        /// <param name="visibleColumns">The visible columns within given gridview</param>
        private void ExportColumnHeaders(Worksheet workSheet, List<GridColumn> visibleColumns)
        {
            // validate
            if (workSheet == null)
            {
                throw new ArgumentNullException("workSheet", "Empty worksheet, cannot export column headers.");
            }

            if (visibleColumns == null)
            {
                throw new ArgumentNullException("visibleColumns", "Empty visibleColumns, cannot export column headers.");
            }

            if (visibleColumns.Count < 1)
            {
                throw new ArgumentOutOfRangeException("visibleColumns", "No columns within visibleColumns, cannot export column headers.");
            }

            // get range for column headers within worksheet
            var colHeaders = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, visibleColumns.Count]];

            // set background color
            colHeaders.Interior.Color = ConvertToRgb(_headerColor);

            // get format converter
            var efc = ExcelFormatConverter.GetConverter();

            // loop columns
            for (int colIx = 0; colIx < visibleColumns.Count; colIx++)
            {
                // set columns and cell
                var column = visibleColumns[colIx];
                var cell = (Range)colHeaders.Cells[1, colIx + 1];

                var fieldTypeWithoutNullable = Nullable.GetUnderlyingType(column.FieldType) ?? column.FieldType;

                //set numberformat of columns either to datetime, number or text
                if (fieldTypeWithoutNullable == typeof(DateTime))
                {
                    cell.EntireColumn.NumberFormat = efc.ToExcelDateTimeFormat("dd/MM/yyyy");
                }
                else if (fieldTypeWithoutNullable == typeof(decimal))
                {
                    cell.EntireColumn.NumberFormat = efc.ToExcelNumberFormat("0.00");
                }
                else if (fieldTypeWithoutNullable == typeof(int))
                {
                    cell.EntireColumn.NumberFormat = efc.ToExcelNumberFormat("0");
                }
                else
                {
                    cell.EntireColumn.NumberFormat = "@";
                }
                // set column caption (escaped in Excel)
                cell.Value2 = "'" + column.Header;
            }
        }

        /// <summary>
        /// Export the data to the given worksheet
        /// </summary>
        /// <param name="excelVersion">The excel version to use</param>
        /// <param name="workSheet">The worksheet where the data has to be exported into</param>
        /// <remarks>See source at http://www.codeproject.com/KB/office/FastExcelExporting.aspx</remarks>
        private void ExportDataToWorksheet(VersionEnum excelVersion, Worksheet workSheet)
        {
            // validate
            if (workSheet == null)
            {
                throw new ArgumentNullException("workSheet", "Empty worksheet, cannot export data.");
            }

            // copy the data to an array
            var dataArray = new object[_rowCount, _columnCount];

            // loop foreach row
            for (int rowCounter = 0; rowCounter < _rowCount; rowCounter++)
            {
                // loop foreach column within current row
                for (int columnCounter = 0; columnCounter < _columnCount; columnCounter++)
                {
                    try
                    {
                        // get current value
                        object cellValue = _gridControl.GetCellValue(rowCounter, _gridColumns[columnCounter]);

                        // RepositoryItemLookUpEdit (LOVs)
                        if (cellValue is int && _gridColumns[columnCounter].ActualEditSettings is LookUpEditSettingsBase)
                        {
                            cellValue = _gridControl.GetCellDisplayText(rowCounter, _gridColumns[columnCounter]);
                        }

                        dataArray[rowCounter, columnCounter] = PrepareCellValue(excelVersion, cellValue);
                    }
                    catch (Exception ex)
                    {
                        // error within single cell
                        dataArray[rowCounter, columnCounter] = string.Format(ExportToExcelProviderRes.CellExportError, ex.Message);

                        if (Debugger.IsAttached)
                        {
                            Debugger.Break();
                        }
                    }
                }
            }

            // do the export with just one single call
            workSheet.Range[workSheet.Cells[2, 1], workSheet.Cells[_rowCount + 1, _columnCount]].Value = dataArray;
        }

        /// <summary>
        /// Finalize Excel worksheet with autofit, borders, etc.
        /// </summary>
        /// <param name="workSheet">The worksheet to finalize</param>
        /// <param name="hasSummary">Indicates whether the grid has a total summary</param>
        private void FinalizeExcelWorksheet(Worksheet workSheet, bool hasSummary)
        {
            // validate
            if (workSheet == null)
            {
                throw new ArgumentNullException("workSheet", "Empty worksheet, cannot export column headers.");
            }

            // get whole data-range including header- and footer-row
            var gridRows = _rowCount + 1;
            var all = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[hasSummary ? gridRows + 2 : gridRows, _columnCount]];

            // column witdh: optimal
            all.Columns.AutoFit();

            // rows height: optimal
            all.Rows.AutoFit();

            // grid borders
            var brdIxs = (XlBordersIndex[])Enum.GetValues(typeof(XlBordersIndex));

            foreach (var brdIx in brdIxs)
            {
                try
                {
                    var brd = all.Borders[brdIx];
                    switch (brdIx)
                    {
                        case XlBordersIndex.xlEdgeLeft:
                        case XlBordersIndex.xlEdgeRight:
                        case XlBordersIndex.xlEdgeTop:
                        case XlBordersIndex.xlEdgeBottom:
                        case XlBordersIndex.xlInsideHorizontal:
                        case XlBordersIndex.xlInsideVertical:
                            brd.LineStyle = XlLineStyle.xlContinuous;
                            brd.Weight = XlBorderWeight.xlThin;
                            brd.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                            break;

                        default:
                            brd.LineStyle = XlLineStyle.xlLineStyleNone;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception occured in FinalizeExcelWorksheet: {0}", ex.Message);
                }
            }
        }

        private int GetActualRowCount()
        {
            var count = 0;
            for (int i = 0; i < _gridControl.VisibleRowCount; i++)
            {
                var rowHandle = _gridControl.GetRowHandleByVisibleIndex(i);
                if (_gridControl.IsValidRowHandle(rowHandle) && !_gridControl.IsGroupRowHandle(rowHandle))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Get list with SubTotalColumns, which are visible in the grid
        /// </summary>
        /// <returns></returns>
        private List<SubTotalColumn> GetGroupSummaryList()
        {
            var subTotalColumns = new List<SubTotalColumn>();
            foreach (GridSummaryItem groupSummaryItem in _gridControl.GroupSummary)
            {
                var column = _gridControl.Columns[groupSummaryItem.FieldName];
                var xlConsolidationFunction = ConvertSummaryType(groupSummaryItem.SummaryType);
                if (IsColumnVisible(column) && xlConsolidationFunction != XlConsolidationFunction.xlUnknown)
                {
                    subTotalColumns.Add(new SubTotalColumn
                    {
                        // Interop.Excel index starts with 1
                        ColumnIndex = CalculateColumnIndex(column),
                        ConsolidationFunctionType = xlConsolidationFunction
                    });
                }
            }
            return subTotalColumns;
        }

        private bool IsColumnVisible(GridColumn column)
        {
            return _gridView.VisibleColumns.Contains(column);
        }

        private class SubTotalColumn
        {
            public int ColumnIndex
            {
                get;
                set;
            }

            public XlConsolidationFunction ConsolidationFunctionType
            {
                get;
                set;
            }
        }
    }
}