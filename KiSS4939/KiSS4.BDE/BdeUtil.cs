using System;

using KiSS4.DB;

namespace KiSS4.BDE
{
    class BdeUtil
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Get the Kostenart for given LA at given date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bdeLeistungsartId">The LeistungsartID used for getting Kostenart</param>
        /// <param name="date">The date used for getting data</param>
        /// <returns>The Kostenart found for given date and LA or -1 if invalid</returns>
        public static int GetKostenartAtDate(int userId, int bdeLeistungsartId, DateTime date)
        {
            // get current state for Kostenart at given date for given LA
            return Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT ISNULL(dbo.fnBDEGetHistKostenartPerDate({0}, {1}, {2}), -1)", userId, bdeLeistungsartId, date));
        }

        /// <summary>
        /// Get the user's costcenter at given date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date">The date for validation</param>
        /// <param name="kostenstelleOrgUnitId">The id of the costcenter to proof</param>
        /// <returns>The costcenter for given user at given date or -1 if invalid</returns>
        public static int GetKostenstelleAtDate(int userId, DateTime date, int kostenstelleOrgUnitId)
        {
            // get current state if user has a valid costcenter at given date
            return Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT ISNULL(ISNULL(dbo.fnBDEGetHistKostenstellePerDate(NULL, {1}, {2}),
                                     dbo.fnBDEGetHistKostenstellePerDate({0}, {1}, NULL)
                                    ), -1)", userId, date, kostenstelleOrgUnitId));
        }

        /// <summary>
        /// Get the Kostentraeger for given LA or User at given date
        /// </summary>
        /// <param name="userId">The UserID used for getting Kostentraeger</param>
        /// <param name="bdeLeistungsartID">The LeistungsartID used for getting Kostentraeger</param>
        /// <param name="date">The date used for getting data</param>
        /// <returns>The Kostentraeger found for given date and LA or -1 if invalid</returns>
        public static SqlQuery GetKostentraegerAtDate(int userId, int bdeLeistungsartID, DateTime date)
        {
            // get current state for Kostentraeger at given date for given LA
            return DBUtil.OpenSQL(@"
                SELECT Kostentraeger
                FROM dbo.fnBDEGetHistKostentraegerPerDate({0}, {1}, {2});", userId, bdeLeistungsartID, date);
        }

        /// <summary>
        /// Get the Mandantennummer for given orgunit at given date
        /// </summary>
        /// <param name="date">The date used for getting data</param>
        /// <param name="orgUnitID">The id of the orgunit to use for getting Mandantennummer</param>
        /// <returns>The Mandantennummer found for given date and orgunit or -1 if invalid</returns>
        public static int GetMandantennummerAtDate(DateTime date, int orgUnitID)
        {
            return Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT ISNULL(dbo.fnBDEGetHistMandantenNrPerDate(NULL, {0}, {1}), -1)", date, orgUnitID));
        }

        /// <summary>
        /// Get the member orgunit id for given user at given date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date">The date used for getting data</param>
        /// <returns>The orgunit id of current user found for given date or -1 if invalid</returns>
        public static int GetMemberOrgUnitAtDate(int userId, DateTime date)
        {
            // get current state if user has member orgunit at given date
            return Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT ISNULL(dbo.fnOrgUnitOfUserHistoryPerDate({0}, {1}), -1)", userId, date));
        }

        #endregion

        #endregion
    }
}