using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using log4net;
using log4net.Config;

using KiSS4.DB;

namespace KiSS4.Schnittstellen.Abacus.Mitarbeiter
{
    public class KAConUtil
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog logger = LogManager.GetLogger(typeof(KAConUtil));

        #endregion

        #endregion

        #region Constructors

        static KAConUtil()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Anzahl Mitarbeiter, bei denen die Mitarbeiternummer nicht 0 ist.
        /// TODO: Gibt es solche dinger, wo die Mitarbeiternummer 0 ist?
        /// </summary>
        /// <param name="mitarbeiterListe"></param>
        /// <returns></returns>
        public static Int32 GetAmountCoWorkers(IDictionary<int, MitarbeiterDTO> mitarbeiterListe)
        {
            //var query = from x in list where x.MitarbeiterNummer != 0 select x;
            //int count = query.Count();

            return mitarbeiterListe.Keys.Count;
        }

        public static bool GetBaLandId(string land, out int? baLandId)
        {
            string sql = @"
                SELECT BaLandID
                FROM dbo.BaLand WITH (READUNCOMMITTED)
                WHERE Iso2Code = {0}";

            var qry = DBUtil.OpenSQL(sql, land);

            if (qry.Count == 1)
            {
                baLandId = qry["BaLandID"] as int?;
                return true; ;
            }

            //if we have 0 or more than 1 record, return null
            baLandId = null;
            return false;
        }

        public static bool GetBaPlzId(string plz, string ort, out int? baPlzId, out string kanton, out string bezirk)
        {
            string sql = @"
                SELECT BaPlzId          = PLZ.BaPLZID,
                       PLZ              = PLZ.PLZ,
                       Ort              = PLZ.Name,
                       Kanton           = PLZ.Kanton,
                       Bezirk           = GDE.BezirkName
                FROM dbo.BaPLZ PLZ WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaGemeinde GDE WITH (READUNCOMMITTED) ON GDE.BFSCode = PLZ.BFSCode
                WHERE PLZ.PLZ = {0}
                  AND PLZ.Name = {1}
                  AND GDE.BezirkAufhebungDatum IS NULL";

            var qry = DBUtil.OpenSQL(sql, plz, ort);

            if (qry.Count == 1)
            {
                baPlzId = qry["BaPLZID"] as int?;
                kanton = qry["Kanton"] as string;
                bezirk = qry["Bezirk"] as string;
                return true;
            }

            //if we have 0 or more than 1 record, return null
            baPlzId = null;
            kanton = null;
            bezirk = null;
            return false;
        }

        public static DateTime GetDate(Int32 idate)
        {
            //assuming: format is ddmmyyyy or dmmyyyy
            var ret = new DateTime();

            String sjahr = "";
            String smonth = "";
            String stag = "";
            String sdate = idate.ToString();

            if (sdate.Length == 8)
            {
                // ddmmyyyy
                sjahr = sdate.Substring(4, 4);
                smonth = sdate.Substring(2, 2);
                stag = sdate.Substring(0, 2);
            }
            else if (sdate.Length == 7)
            {
                // dmmyyyy
                sjahr = sdate.Substring(3, 4);
                smonth = sdate.Substring(1, 2);
                stag = sdate.Substring(0, 1);
            }

            if (sjahr != "")
            {
                // so we have a date
                ret = new DateTime(Convert.ToInt32(sjahr), Convert.ToInt32(smonth), Convert.ToInt32(stag));
            }
            else if (idate == 0)
            {
                // the exception "0" will be used for comparison, do not change here!
                throw new Exception("0");
            }
            else
            {
                throw new Exception(String.Format("Date conversion: '{0}' cannot be converted to a useful date.", idate));
            }

            return ret;
        }

        public static DataRow GetFirstAbaWorker(DataSet dsresult)
        {
            DataRow ret = null;

            if (dsresult != null)
            {
                DataTableCollection tables = dsresult.Tables;
                IEnumerator en = tables.GetEnumerator();

                if (en.MoveNext())
                {
                    var dt = (DataTable)en.Current;

                    if (dt.Rows.Count > 0)
                    {
                        ret = dt.Rows[0];
                    }
                }
            }

            return ret;
        }

        public static DataRow GetKissXUserWithId(Int32 userID)
        {
            SqlQuery sq =
                DBUtil.OpenSQL(@"
                SELECT *
                FROM dbo.XUser WITH (READUNCOMMITTED)
                WHERE UserID={0}",
                               userID);

            if (sq.Count > 1)
            {
                throw new Exception(
                    String.Format("Entry in XUser is not unique, '{0}' entries in XUser were found for UserID='{1}'.",
                                  sq.Count, userID));
            }
            else
            {
                if (sq.Count == 1)
                {
                    // return current entry of user
                    return sq.DataTable.Rows[0];
                }
            }

            // no row found
            return null;
        }

        public static DataRow GetKissXUserWithMitarbeiterNr(Int32 mitarbeiterNr)
        {
            SqlQuery sq =
                DBUtil.OpenSQL(
                    @"
                SELECT *
                FROM dbo.XUser WITH (READUNCOMMITTED)
                WHERE MitarbeiterNr={0}",
                    mitarbeiterNr);

            if (sq.Count > 1)
            {
                throw new Exception(
                    String.Format(
                        "Entry in XUser is not unique, '{0}' entries in XUser were found for MitarbetierNr='{1}'.",
                        sq.Count, mitarbeiterNr));
            }
            else
            {
                if (sq.Count == 1)
                {
                    // return current entry of user
                    return sq.DataTable.Rows[0];
                }
            }

            // no row found
            return null;
        }

        public static Int32 GetYear(DataRow dr)
        {
            Int32 year = 0;

            if (dr != null)
            {
                year = Convert.ToInt32(dr["YEAR"]);
            }

            return year;
        }

        public static Int32 GetYear(DataSet ds)
        {
            Int32 year = 0;

            if (ds != null)
            {
                DataRow adr = GetFirstAbaWorker(ds);
                DataRow dr = GetFirstAbaWorker(ds);

                year = GetYear(dr);
            }

            return year;
        }

        public static void InsertAbaLog(Int32 userID, Int32 schnittstellenCode, String paramIn, String paramOut,
            String exceptionTxt, String remark)
        {
            try
            {
                DBUtil.ExecSQLThrowingException(
                    @"
                    INSERT INTO dbo.XAbaLog
                    (UserID, LogDate, SchnittstellenCode, ParameterIn, ParameterOut, ExceptionMsg, Remark)
                    VALUES ({0}, GETDATE(), {1}, {2}, {3}, {4}, {5})",
                    userID, schnittstellenCode, paramIn, paramOut, exceptionTxt, remark);
            }
            catch (Exception ex)
            {
                logger.Error("Error writing log in XAbaLog", ex);
                KissMsg.ShowError("KAConUtil", "FailedLoggingToDB",
                                  "Es ist ein Fehler beim Logging des Abacus-Aufrufs aufgetreten.", ex);
            }
        }

        /// <summary>
        /// Check if type of object is "System.DBNull"
        /// </summary>
        /// <param name="o">The object to check</param>
        /// <returns>True if object is "System.DBNull", otherwise false</returns>
        public static Boolean IsDBNull(Object o)
        {
            return (o.GetType().FullName == "System.DBNull");
        }

        public static DateTime RemoveOneDay(DateTime dt)
        {
            var ret = new DateTime();

            if (dt != null)
            {
                var ts = new TimeSpan(1, 0, 0, 0, 0);
                ret = dt.Subtract(ts);
            }

            return ret;
        }

        public static void SplitPostfachUndNr(string postfachUndNr, out string postfachNr, out bool postfachOhneNr)
        {
            postfachNr = null;
            postfachOhneNr = false;

            //Siehe ScalarFunction: fnXGetPostfachTextML
            string[] postfachAusdruecke = { "Postfach", "Casella postale", "Case postale" };

            if (!string.IsNullOrEmpty(postfachUndNr))
            {
                postfachUndNr = postfachUndNr.Trim();

                /* bool ob das Wort postfachAusdruck richtig geschrieben geliefert wurde */
                var postfachInStr = false;

                foreach (var postfachAusdruck in postfachAusdruecke)
                {
                    /* schauen obs überhaupt mit einem postfach... anfängt, sonst Fehlermeldung (unten) */
                    if(postfachUndNr.StartsWith(postfachAusdruck, StringComparison.CurrentCultureIgnoreCase))
                    {
                        postfachInStr = true;
                        postfachNr = postfachUndNr.Substring(postfachAusdruck.Length).Trim();
                        break;
                    }
                }

                if(postfachInStr == false)
                {
                    string errorMessage = string.Format("Unexpected value for 'Postfach'. Expected variants: {0}, effective: {1}", string.Join(",", postfachAusdruecke), postfachUndNr);
                    logger.Error(errorMessage);
                    throw new Exception(errorMessage);
                }

                /* Wenn der String postfachNr nun leer ist, hat das Postfach keine Nummer */
                if(string.IsNullOrEmpty(postfachNr))
                {
                    postfachNr = null;
                    postfachOhneNr = true;
                }
            }
            else
            {
                postfachNr = postfachUndNr;
            }
        }

        public static void SplitStrasseHausNr(string strasseHausNr, out string strasse, out string hausNr)
        {
            strasse = null;
            hausNr = null;
            if (!string.IsNullOrEmpty(strasseHausNr))
            {
                int lastSpaceIndex = strasseHausNr.LastIndexOf(' ');
                if (lastSpaceIndex != -1)
                {
                    strasse = strasseHausNr.Substring(0, lastSpaceIndex);
                    hausNr = strasseHausNr.Substring(lastSpaceIndex);

                    //make sure, the hausNr fits -> if it is too long, we don't split it
                    if (hausNr.Length > 10)
                    {
                        strasse = strasseHausNr;
                        hausNr = null;
                    }
                }
                else
                {
                    strasse = strasseHausNr;
                    hausNr = null;
                }
            }
        }

        #endregion

        #endregion
    }
}