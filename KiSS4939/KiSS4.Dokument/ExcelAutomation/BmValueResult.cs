using System;
using System.Data;
using KiSS4.DB;

namespace KiSS4.Dokument.ExcelAutomation
{
    public class BmValueResult
    {
        #region Fields

        public readonly Int32 BookmarkCode;
        public readonly Boolean IsStandard;
        public String LOVCode;

        #endregion

        #region Constructors

        public BmValueResult(DataRow row)
        {
            IsStandard = Convert.ToBoolean(row["IsStd"]);
            BookmarkCode = Convert.ToInt32(row["BookmarkCode"]);
        }


        #endregion

        #region Public Properties

        /// <summary>
        /// Get and set the BookmarkValue
        /// </summary>
        public object BookmarkValue { get; set; }

        public bool IsTableValueResult
        {
            get
            {
                var qry = BookmarkValue as SqlQuery;
                return qry != null && qry.DataTable.Columns.Count > 1;
            }
        }

        /// <summary>
        ///  Der Spaltenname in der Tabelle.
        /// </summary>
        public string ColumnName { get; set; }

        #endregion
    }
}