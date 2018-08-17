#region Header

/*
 * Copyright (c) 2010 Manuel De Leon
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in the
 * Software without restriction, including without limitation the rights to use, copy,
 * modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
 * and to permit persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

#endregion

using System.Linq;

using Kiss.Interfaces.DocumentHandling;

using ClosedXML.Excel;

namespace KiSS4.Dokument
{
    public class ExcelDocument : IExcelDocument
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly XLWorkbook _workbook;

        #endregion

        #endregion

        #region Constructors

        public ExcelDocument(string filename)
        {
            _workbook = new XLWorkbook(filename, XLEventTracking.Disabled);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            if (_workbook != null)
            {
                _workbook.Dispose();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public string GetValue(string worksheetName, string cellReference)
        {
            IXLWorksheet worksheet;

            if (_workbook.Worksheets.TryGetWorksheet(worksheetName, out worksheet))
            {
                var cell = worksheet.Cell(cellReference);
                return GetCellValue(cell);
            }

            return null;
        }

        public string GetValue(string worksheetName, int row, int column)
        {
            IXLWorksheet worksheet;

            if (_workbook.Worksheets.TryGetWorksheet(worksheetName, out worksheet))
            {
                var cell = worksheet.Cell(row, column);
                return GetCellValue(cell);
            }

            return null;
        }

        public string GetValue(int workSheetIndex, string cellReference)
        {
            var worksheet = _workbook.Worksheet(workSheetIndex);
            var cell = worksheet.Cell(cellReference);
            return GetCellValue(cell);
        }

        public string GetValue(int workSheetIndex, int row, int column)
        {
            var worksheet = _workbook.Worksheet(workSheetIndex);
            var cell = worksheet.Cell(row, column);
            return GetCellValue(cell);
        }

        public string GetValueByNamedRange(string namedRange)
        {
            if (_workbook.NamedRanges.All(x => x.Name != namedRange))
            {
                return null;
            }

            var valueCached = _workbook.Cell(namedRange).ValueCached;
            if (valueCached != null)
            {
                return valueCached;
            }

            return _workbook.Cell(namedRange).Value.ToString();
        }

        #endregion

        #region Private Static Methods

        private static string GetCellValue(IXLCell cell)
        {
            if (cell != null && cell.Value != null)
            {
                return cell.GetString();
            }

            return null;
        }

        #endregion

        #endregion
    }
}