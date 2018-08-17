using KiSS4.DB;
using System;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Helper class for administration/system features
    /// </summary>
    public class XUtils
    {
        /// <summary>
        /// Get the orgunitid of the current user's KGS
        /// </summary>
        /// <returns>-1 if no KGS was found or the orgunitid of the user's KGS</returns>
        public static int GetUserKGSOrgUnitID()
        {
            return GetUserKGSOrgUnitID(Session.User.UserID);
        }

        /// <summary>
        /// Get the orgunitid of the given user's KGS
        /// </summary>
        /// <param name="userId">The userid to use to get KGS</param>
        /// <returns>-1 if no KGS was found or the orgunitid of the user's KGS</returns>
        public static int GetUserKGSOrgUnitID(int userId)
        {
            return Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT CONVERT(INT, ISNULL(dbo.fnGetHistKGSOfUserOrOrgUnit({0}, GETDATE(), NULL, 1, 1), -1));", userId));
        }
    }
}