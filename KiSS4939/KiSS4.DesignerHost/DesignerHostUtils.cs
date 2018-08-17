using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for DesignerHostUtils.
    /// </summary>
    public class DesignerHostUtils
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Fill lookupedit with non-system-modules from table XModul including an empty row.
        /// </summary>
        /// <param name="loopUpEdit">Referenced lookupedit to fill</param>
        public static void FillLookUpEditWithModules(KissLookUpEdit loopUpEdit)
        {
            FillLookUpEditWithModules(loopUpEdit, true);
        }

        /// <summary>
        /// Fill lookupedit with non-system-modules from table XModul
        /// </summary>
        /// <param name="loopUpEdit">Referenced lookupedit to fill</param>
        /// <param name="emptyEntry">True if an empty row has to be added</param>
        public static void FillLookUpEditWithModules(KissLookUpEdit loopUpEdit, bool emptyEntry)
        {
            if (loopUpEdit == null)
            {
                return;
            }

            loopUpEdit.Properties.DisplayMember = "Text";
            loopUpEdit.Properties.ValueMember = "Code";
            loopUpEdit.Properties.DataSource = GetNonSystemModuls(emptyEntry);
        }

        /// <summary>
        /// Get all non-system-moduls from table XModul including an empty row.
        /// Code-Column is "Code" and Text-Column is "Text"
        /// </summary>
        /// <returns>SqlQuery containing an empty row and all non-system-modules</returns>
        public static SqlQuery GetNonSystemModuls()
        {
            return GetNonSystemModuls(true);
        }

        /// <summary>
        /// Get all non-system-moduls from table XModul.
        /// Code-Column is "Code" and Text-Column is "Text"
        /// </summary>
        /// <param name="emptyEntry">True if an empty row has to be added</param>
        /// <returns>SqlQuery containing optionally an empty row and all non-system-modules</returns>
        public static SqlQuery GetNonSystemModuls(bool emptyEntry)
        {
            string sql = @"
                SELECT Text = Name,
                       Code = ModulID
                FROM dbo.XModul
                WHERE ModulID > 0;";

            if (emptyEntry)
            {
                sql = @"--SQLCHECK_IGNORE--
                    SELECT Text = '',
                           Code = NULL" +
                    " UNION ALL " + // SqlSyntaxCheck..
                    sql;
            }

            return DBUtil.OpenSQL(sql);
        }

        #endregion

        #endregion
    }
}