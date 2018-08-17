using System;
using System.Data;
using KiSS4.DB;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    public class DataHandler
    {
        /// <summary>
        /// If possible, get Int32 value from datarow
        /// </summary>
        /// <param name="row">The datarow to get value from</param>
        /// <param name="columnName">The column name to use within given datarow</param>
        /// <returns>Int32 value or null if nothing found in datarow</returns>
        public static Int32? GetInt32Value(DataRow row, String columnName)
        {
            // check if any data contained
            if (DBUtil.IsEmpty(row[columnName]))
            {
                return null;
            }

            // return value as Int32
            return Convert.ToInt32(row[columnName]);
        }

        /// <summary>
        /// If possible, get String value from datarow
        /// </summary>
        /// <param name="row">The datarow to get value from</param>
        /// <param name="columnName">The column name to use within given datarow</param>
        /// <returns>String value or null if nothing found in datarow</returns>
        public static String GetStringValue(DataRow row, String columnName)
        {
            // check if any data contained
            if (DBUtil.IsEmpty(row[columnName]))
            {
                return null;
            }

            // return value as String
            return Convert.ToString(row[columnName]);
        }

        /// <summary>
        /// Insert new log entry into database
        /// </summary>
        /// <param name="paramIn">The input parameter used for call</param>
        /// <param name="paramOut">The output parameter given by call</param>
        /// <param name="exception">The exception that occured on call</param>
        /// <param name="remark">Any remarks or comments to log</param>
        public static void InsertAbaLog(String paramIn, String paramOut, Exception exception, String remark)
        {
            // do logging
            DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO dbo.XAbaLog (UserID, LogDate, SchnittstellenCode, ParameterIn, ParameterOut, ExceptionMsg, Remark)
                    VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})", Session.User.UserID, DateTime.Now, 1, paramIn, paramOut, exception == null ? "" : exception.Message, remark);
        }

        /// <summary>
        /// Validate the desired MandantenNummer
        /// </summary>
        /// <param name="mandantenNummer">The MandantenNummer to validate</param>
        /// <returns>True if MandantenNummer is valid or false if MandantenNummer is invalid</returns>
        public static Boolean IsMandantenNummerValid(Int32 mandantenNummer)
        {
            bool debugMode = DBUtil.GetConfigBool(Constants.KissConfig_DebugFlag, false);

            // validate MandantenNummer for given range
            if ((mandantenNummer >= 11 && mandantenNummer <= 261)
                || (debugMode && mandantenNummer >= 9011 && mandantenNummer <= 9261))  //if debug-mode is enabled, we also accept 'Test-Mandanten' (9000 + MandantenNr)
            {
                // valid
                return true;
            }
            // invalid and out of range
            return false;
        }

        /// <summary>
        /// Return the SQL-statement to execute to get all clients for given MandantenNummer
        /// </summary>
        /// <param name="mandantenNummer">The MandantenNummer to use for searching clients (has to be valid or -1=reset)</param>
        public void FillQueryWithAllKlientenOfMandant(Int32 mandantenNummer, ref SqlQuery qryToFill)
        {
            // validate parameter
            if (mandantenNummer != -1 && !IsMandantenNummerValid(mandantenNummer))
            {
                throw new ArgumentOutOfRangeException(String.Format("The given MandantenNummer '{0}' is invalid and out of range", mandantenNummer));
            }
            if (qryToFill == null)
            {
                throw new ArgumentNullException("qryToFill", "Empty SqlQuery to fill, cannot run statement.");
            }

            // SQL-Statement for Klientenstammdaten-data where,
            //   {0}=MandantenNr,
            //   {1}=LanguageCode (Session.User.LanguageCode)
            // Check if Fill() is really working
            if (!qryToFill.Fill(@"EXEC dbo.spABAGetKlientenstammdatenData {0}, NULL, {1}", mandantenNummer, Session.User.LanguageCode))
            {
                throw new KlientenStammdatenException("Could not fill the given SqlQuery with data, Fill() returned as false.");
            }
        }

        /// <summary>
        /// Return a SqlQuery containing all allowed MandantenNummern for current user in LOV-style
        /// </summary>
        /// <returns>A SqlQuery containing all allowed MandantenNummern for current user in LOV-style</returns>
        public SqlQuery GetAllAllowedMandantenNummern()
        {
            // depending on rights, the user can see just his mandant or all
            Boolean userCanSeeAllMandanten = Session.User.IsUserAdmin || DBUtil.UserHasRight("ABAKlientenStammDatenSchnittstelleGB");

            // create SQLQuery
            return DBUtil.OpenSQL(@"
                    SELECT [Code] = ORG.Mandantennummer,
                           [Text] = CONVERT(VARCHAR(10), ISNULL(ORG.Mandantennummer, -1)) + '   ' + ORG.ItemName
                    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                    WHERE ORG.Mandantennummer IS NOT NULL AND
                          (1 = ISNULL({0}, 0) OR ORG.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr({1})) -- only special can select all
                    ORDER BY [Code], [Text]", userCanSeeAllMandanten, Session.User.UserID);
        }

        /// <summary>
        /// Return a SqlQuery containing all client-update-status in LOV-style
        /// </summary>
        /// <param name="emptyData">True means only dataset without data will be returned, else with given data</param>
        /// <returns>A SqlQuery containing all client-update-status in LOV-style</returns>
        public SqlQuery GetAllClientUpdateStatus(Boolean emptyData)
        {
            // create SQLQuery
            return DBUtil.OpenSQL(@"
                    SELECT [Code] = LOV.Code,
                           [Text] = dbo.fnLOVMLText(LOV.LOVName, LOV.Code, {0})
                    FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                    WHERE ISNULL({1}, 0)=0 AND                                 -- no data if 1
                          LOV.LOVName = 'AbaKlientenstammdatenKlientenStatus'  -- only for given LOV
                    ORDER BY LOV.SortKey, LOV.Code", Session.User.LanguageCode, emptyData);
        }

        /// <summary>
        /// Return the MandantenNummer of current user
        /// </summary>
        /// <returns>The MandantenNummer of current user or -1 if none defined</returns>
        public Int32 GetMandantenNummerOfUser()
        {
            return Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT ISNULL(dbo.fnOrgUnitOfUserMandantenNr({0}), -1)", Session.User.UserID));
        }
    }
}