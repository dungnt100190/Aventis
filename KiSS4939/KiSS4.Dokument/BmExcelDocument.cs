using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Messages;

using Interop.Excel;
using KiSS4.Dokument.ExcelAutomation;


namespace KiSS4.Dokument
{
    public class BmExcelDocument : IBmDocument
    {
        #region Fields

        private BmProvider bmProvider;
        private ExcelControl excelControl;
        private System.Reflection.Missing missing = System.Reflection.Missing.Value;
        private Workbook wBook;

        #endregion

        #region Constructors

        public BmExcelDocument(FileInfo fileInfo)
        {
            excelControl = new ExcelControl();
            wBook = (Workbook)excelControl.OpenWorkbook(fileInfo.FullName);
            excelControl.Visible = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Closes the document.
        /// </summary>
        public void CloseDocument()
        {
            if (excelControl != null)
            {
                excelControl.CloseDoc();
            }
        }

        public void Parse(BmProvider bmProvider)
        {
            this.bmProvider = bmProvider;

            // pattern to match markter [[MARKERNAME]
            Regex regex = new Regex(@"\[\[(?<Textmarke>\w+)\]\]");

            // iterating through all sheets
            foreach (Worksheet wSheet in wBook.Worksheets)
            {
                Range c = null;
                System.Globalization.CultureInfo CurrentCI = null;

                try
                {

                    // BUG: Have to set locale to en-US
                    // http://support.microsoft.com/kb/320369/en

                    CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                    // look for cells containing [[MARKERNAME]]
                    c = wSheet.Cells.Find("[[*]]", missing, missing, missing, missing, XlSearchDirection.xlNext, missing, missing);

                    while (c != null)
                    {
                        // write cell
                        c.Value2 = regex.Replace(c.Value2.ToString(), new MatchEvaluator(regex_MatchEvaluator));

                        // next match
                        c = wSheet.Cells.FindNext(c);
                    }
                }
                catch (Exception e)
                {
                    KissMsg.ShowInfo(e.ToString());
                }
                finally
                {
                    // locales back to origin
                    System.Threading.Thread.CurrentThread.CurrentCulture = CurrentCI;
                }
            }
        }

        public void Save()
        {
            wBook.Save();
        }

        #endregion

        #region Private Methods

        private string regex_MatchEvaluator(Match m)
        {
            BmValueResult result = bmProvider.GetBookmarkValue(m.Groups["Textmarke"].Value);

            if (result == null || result.BookmarkValue == null)
            {
                return string.Empty;
            }

            if (result.IsStandard)
            {
                SqlQuery qry = (SqlQuery)result.BookmarkValue;

                if (qry.DataTable.Columns.Count == 1 && qry.Count == 1)
                {
                    return qry.Row[0].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return result.BookmarkValue.ToString();
            }
        }

        #endregion
    }
}