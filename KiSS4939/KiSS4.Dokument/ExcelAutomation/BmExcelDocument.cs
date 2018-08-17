using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Interop.Excel;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Dokument.Utilities;
using KiSS4.Messages;
using Workbook = Interop.Excel.Workbook;
using Worksheet = Interop.Excel.Worksheet;

namespace KiSS4.Dokument.ExcelAutomation
{
    public class BmExcelDocument
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly ExcelControl _excelControl;
        private readonly Workbook _wBook;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor with file information, excel will be shown
        /// </summary>
        /// <param name="fileInfo">The file information for the document</param>
        public BmExcelDocument(FileInfo fileInfo)
            : this(fileInfo.FullName)
        {
        }

        /// <summary>
        /// Constructor with file information and visible option
        /// </summary>
        /// <param name="fileInfo">The file information for the document</param>
        /// <param name="showExcel">Flag if excel has to be shown or hidden to user</param>
        public BmExcelDocument(FileInfo fileInfo, Boolean showExcel)
            : this(fileInfo.FullName, showExcel)
        {
        }

        /// <summary>
        /// Constructor with file path, excel will be shown
        /// </summary>
        /// <param name="filepath">The file information for the document</param>
        public BmExcelDocument(String filepath)
            : this(filepath, true)
        {
        }

        /// <summary>
        /// Constructor with file path and visible option
        /// </summary>
        /// <param name="filepath">The file information for the document</param>
        /// <param name="showExcel">Flag if excel has to be shown or hidden to user</param>
        public BmExcelDocument(String filepath, Boolean showExcel)
        {
            // create new instance
            _excelControl = new ExcelControl();

            // validate
            if (_excelControl == null)
            {
                // excel control is required for further handling
                throw new NullReferenceException("Could not create new instance of ExcelControl.");
            }

            // open workbook
            _excelControl.OpenWorkbook(filepath);
            _wBook = _excelControl.CurrentWorkbook;

            // validate
            if (_wBook == null)
            {
                // workbook is required for further handling
                throw new NullReferenceException("Could not open workbook, returned value is null.");
            }

            // show or hide excel-application (GUI)
            _excelControl.Visible = showExcel;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Closes the document.
        /// </summary>
        public void CloseDocument()
        {
            // logging
            _logger.Debug("enter");

            // init vars
            CultureInfo currentCi = null;

            if (_excelControl != null)
            {
                try
                {
                    // BUG: Have to set locale to en-US, store and change current culture
                    // http://support.microsoft.com/kb/320369/en
                    currentCi = System.Threading.Thread.CurrentThread.CurrentCulture;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                    try
                    {
                        // logging
                        _logger.Debug("try to show excel again");

                        // show excel again (to ensure it is visible in case of other documents open)
                        _excelControl.ExcelApplication.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        // logging
                        _logger.Warn("exception occured while trying to show excel", ex);
                    }

                    // logging
                    _logger.Debug("try to close current document");

                    // close excel document but leave excel open if any other documents are opened
                    _excelControl.CloseDocument();

                    // dispose and cleanup
                    /*
                     * TODO: CloseDocument() will not automatically close Excel due to other open workbooks.
                     *       So we have to change ExcelControl to singleton in future without any workbook handling...
                    this.excelControl.Dispose();
                    this.excelControl = null;
                     */
                }
                catch (Exception ex)
                {
                    // logging
                    _logger.Warn("exception occured while closing document", ex);

                    // throw exception further on
                    throw;
                }
                finally
                {
                    if (currentCi != null)
                    {
                        System.Threading.Thread.CurrentThread.CurrentCulture = currentCi;
                    }
                }
            }

            // logging
            _logger.Debug("done");
        }

        public void FillBookmarks(IKissContext context)
        {
            DlgProgressLog.AddLine(KissMsg.GetMLMessage("BmExcelDocument", "TextmarkenAusVorlage", "Textmarken aus der Vorlage lesen"));

            // Read bookmarks from excel
            IList<string> bookmarks = _excelControl.GetBookmarks().Distinct().ToList();
            // no bookmarks available
            if (!bookmarks.Any())
            {
                return;
            }

            SqlQuery qryXBookmark = GetQueryBookmarks(bookmarks);
            DlgProgressLog.AddLine(
                       KissMsg.GetMLMessage(
                           "WordDoc",
                           "TextmarkenErsetzen1",
                           "Textmarken mit Daten füllen: 0 von ",
                           qryXBookmark.Count.ToString(CultureInfo.InvariantCulture)
                           ));
            int count = 0;

            var bmProvider = new BmProvider(context);

            // iterating through all bookmarks
            foreach (string bookmark in bookmarks)
            {
                count++;
                DlgProgressLog.UpdateLastLine(
                       KissMsg.GetMLMessage(
                           "WordDoc",
                           "TextmarkenErsetzen2",
                           "Textmarken mit Daten füllen: {0} von {1}",
                           count.ToString(CultureInfo.InvariantCulture),
                           qryXBookmark.Count.ToString(CultureInfo.InvariantCulture)
                           ));

                //Get result
                BmValueResult valueResult = bmProvider.GetBookmarkValue(bookmark);

                // iterating through all sheets
                foreach (Worksheet wSheet in _wBook.Worksheets)
                {
                    CultureInfo currentCi = System.Threading.Thread.CurrentThread.CurrentCulture;
                    try
                    {
                        DlgProgressLog.AddLine(KissMsg.GetMLMessage("BmExcelDocument", "TextmarkenErsetzen", "Textmarken mit KiSS-Daten ersetzen für Tabelle '{0}'", KissMsgCode.Text, wSheet.Name));

                        // BUG: Have to set locale to en-US
                        // http://support.microsoft.com/kb/320369/en
                        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                        while (true)
                        {
                            Range bookmarkRange = wSheet.Cells.Find(string.Format("[[{0}]]", bookmark));
                            // No range found for this bookmark, leave while
                            if (bookmarkRange == null)
                            {
                                break;
                            }

                            var qry = valueResult.BookmarkValue as SqlQuery;

                            if (qry == null)
                            {
                                bookmarkRange.Value2 = null;
                                continue;
                            }

                            // write cell
                            // Regex ist salopp gesagt: [[*]]. c.Value2 kann mehrere Werte enthalten.
                            if (!valueResult.IsTableValueResult)
                            {
                                bookmarkRange.Value2 = GetSingleBookmarkValue(qry, valueResult);
                            }
                            else
                            {
                                //setze qry auf Anfang
                                qry.First();
                                Range currentCell = bookmarkRange.Cells;

                                //Koordinaten merken
                                int rowNumber = currentCell.Row;
                                int columnNumber = currentCell.Column;

                                currentCell.Value2 = string.Empty;

                                currentCell.EntireRow.Copy();

                                Range targetCells = currentCell.Range["A2", "A" + (qry.Count)].EntireRow;

                                targetCells.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                                //nach Hinzufügen der neuen Zeilen wieder zurück auf die Zelle springen, wo die Textmarke drin war
                                currentCell = (Range)wSheet.Cells[rowNumber, columnNumber];
                                currentCell.Activate();

                                for (int iRow = 0; iRow < qry.DataTable.Rows.Count; iRow++)
                                {
                                    Range initialCell = currentCell.Cells;

                                    for (int iCol = 0; iCol < qry.DataTable.Columns.Count; iCol++)
                                    {
                                        //nur erste spalte heisst nextcell, nächste Nextcell würde nextcell1 usw. heissen, daher hier startswith!!!
                                        if (qry.DataTable.Columns[iCol].ColumnName.StartsWith("NextCell"))
                                        {
                                            continue;
                                        }

                                        currentCell.Value2 = GetSingleBookmarkValue(qry.Row[iCol].ToString(), valueResult);
                                        currentCell = currentCell.Next;
                                    }

                                    Range nextRowStart = initialCell.Offset[1, 0];
                                    currentCell = nextRowStart;

                                    //naechste Zeile in qry
                                    qry.Next();
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        KissMsg.ShowInfo(e.ToString());
                    }
                    finally
                    {
                        // locales back to origin
                        System.Threading.Thread.CurrentThread.CurrentCulture = currentCi;
                    }
                }
            }
        }

        public void Save()
        {
            // init culture var
            CultureInfo currentCi = System.Threading.Thread.CurrentThread.CurrentCulture;

            try
            {
                // get current culture and set to us (bug in excel-com-call, see above)
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                // save document
                _wBook.Save();
            }
            catch (Exception)
            {
                // wait if debugging
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }

                // throw exception further on
                throw;
            }
            finally
            {
                // locales back to origin
                System.Threading.Thread.CurrentThread.CurrentCulture = currentCi;
            }
        }

        #endregion

        #region Private Static Methods

        private static string GetSingleBookmarkValue(SqlQuery qry, BmValueResult result)
        {
            string newValue = string.Empty;

            if (result.IsStandard)
            {
                if (qry.DataTable.Columns.Count == 1 && qry.Count == 1)
                {
                    string textmarkenValue = qry.Row[0].ToString();

                    //Ist nicht null, da das Query-Resultat aus einer Zelle besteht.
                    string columnName = result.ColumnName.ToUpper();

                    //In Excel sind die RTF Formatierungen nicht unterstützt.
                    //RTF wird durch zwei Mechanismen erkannt. Siehe auch WordDoc.cs,
                    //Methode ReplaceBookmarkByValue.
                    // 1. BookmarkCode
                    // 2. Namenskonvention Ende Column-Name: NORTF, OHNEFMT, MITFMT,
                    if (result.BookmarkCode == 3 || columnName.EndsWith("NORTF") || columnName.EndsWith("OHNEFMT") || columnName.EndsWith("MITFMT"))
                    {
                        // removes formatting.
                        // Hint: In MS-word the RTF Text is pasted from KiSS to the clipboard
                        //       (DataFormats.Rtf) and pasted (in MS-word).
                        textmarkenValue = FileUtilies.RemoveRTFFormatting(textmarkenValue);
                    }

                    newValue = textmarkenValue;
                }
                else if (qry.DataTable.Columns.Count == 0 || qry.Count == 0)
                {
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            "BmExcelDocument",
                            "BookMarkWertUngueltig_v01",
                            "FEHLER: Textmarke '{0}' - Wert ist leer oder Textmarke nicht gefunden",
                            KissMsgCode.Text,
                            newValue));
                    newValue = string.Empty;
                }
            }
            else
            {
                //Es handelt sich um eine eigene Maske. Das DynaField enthält RTF.
                if (result.BookmarkCode == 15)
                {
                    newValue = FileUtilies.RemoveRTFFormatting(result.BookmarkValue.ToString());
                }
                else
                {
                    //Dynafield ohne RTF.
                    newValue = result.BookmarkValue.ToString();
                }
            }

            return newValue;
        }

        private static string GetSingleBookmarkValue(string value, BmValueResult result)
        {
            if (result.IsStandard)
            {
                //In Excel sind die RTF Formatierungen nicht unterstützt.
                //RTF wird durch zwei Mechanismen erkannt. Siehe auch WordDoc.cs,
                //Methode ReplaceBookmarkByValue.
                // 1. BookmarkCode
                // 2. Namenskonvention Ende Column-Name: NORTF, OHNEFMT, MITFMT,
                if (result.BookmarkCode == 3 || value.StartsWith(@"{\rtf"))
                {
                    value = FileUtilies.RemoveRTFFormatting(value);
                }
            }
            else
            {
                //Es handelt sich um eine eigene Maske. Das DynaField enthält RTF.
                if (result.BookmarkCode == 15)
                {
                    value = FileUtilies.RemoveRTFFormatting(result.BookmarkValue.ToString());
                }
                else
                {
                    //Dynafield ohne RTF.
                    value = result.BookmarkValue.ToString();
                }
            }

            return value;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get sql query with the available bookmarks
        /// </summary>
        /// <param name="bookmarks">List with bookmarks we are looking at</param>
        /// <returns>SqlQuery with the queried bookmarks</returns>
        private SqlQuery GetQueryBookmarks(IEnumerable<string> bookmarks)
        {
            // add single quotes for query
            List<string> singleQuoteBookmarks = bookmarks.Select(bookmark => string.Format("'{0}'", bookmark)).ToList();
            // join to string with coma
            string bookmarkList = string.Join(", ", singleQuoteBookmarks.ToArray());
            // create default sql
            string sqlBookmarkQuery =
                    @"
                        SELECT CONVERT(BIT, 1) IsStd,
                               BookmarkName = LEFT(BookmarkName, 40),
                               BookmarkCode,
                               SQL
                        FROM dbo.XBookmark WITH (READUNCOMMITTED)
                        WHERE BookmarkName IN ({0}) AND
                              TableName IS NULL

                        UNION ALL

                        SELECT CONVERT(BIT, 1) IsStd,
                               BookmarkName = LEFT(SBO.BookmarkName, 40),
                               SBO.BookmarkCode,
                               REPLACE(CONVERT(VARCHAR(8000), SBO.SQL), '<TableColumn>', SBO.ReplaceCode)
                        FROM dbo.fnGetStandardBookmarks({1}) SBO
                        WHERE BookmarkName IN ({0})";
            string sqlBookmarkDynaMask = @"
                     UNION ALL

                        SELECT CONVERT(BIT, 0) IsStd,
                               BookmarkName = LEFT(FieldName, 40),
                               FieldCode,
                               NULL
                        FROM dbo.DynaField WITH (READUNCOMMITTED)
                        WHERE FieldName IN ({0})
                    ";
            // check if we have the table DynaField
            if (Session.SupportDynaMask)
            {
                sqlBookmarkQuery += sqlBookmarkDynaMask;
            }

            return DBUtil.OpenSQL(string.Format(
                sqlBookmarkQuery,
                bookmarkList,
                Session.User.LanguageCode));
        }

        #endregion

        #endregion
    }
}