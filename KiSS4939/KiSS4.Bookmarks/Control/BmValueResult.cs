using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using KiSS4.DB;

namespace KiSS4.Bookmarks.Control
{
    public class BmValueResult
    {
        #region Fields

        public readonly Int32 BookmarkCode;
        public readonly Boolean IsStandard;
        public String LOVCode;

        private object bookmarkValue;

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
        public object BookmarkValue
        {
            get { return bookmarkValue; }
            set { bookmarkValue = value; }
        }

        #endregion
    }
}