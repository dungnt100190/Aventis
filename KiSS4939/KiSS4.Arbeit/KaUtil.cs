using System;

using KiSS.DBScheme;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Arbeit
{
    public class KaUtil
    {
        #region Fields

        #region Public Static Fields

        public static System.Drawing.Color ColNormal = System.Drawing.Color.AliceBlue;
        public static System.Drawing.Color ColReadOnly = System.Drawing.Color.FromArgb(247, 239, 231);
        public static System.Drawing.Color ColRed = System.Drawing.Color.LightSalmon;
        public static System.Drawing.Color ColRemarks = System.Drawing.Color.PaleTurquoise;
        public static System.Drawing.Color ColSelectedBackColor = System.Drawing.SystemColors.Highlight;
        public static System.Drawing.Color ColSelectedForeColor = System.Drawing.SystemColors.HighlightText;
        public static System.Drawing.Color ColStatistics = System.Drawing.Color.FromArgb(255, 255, 192);
        public static System.Drawing.Color ColWeekend = System.Drawing.Color.LightGray;

        // Specially used for KA
        public static System.Drawing.Color ColYellow = System.Drawing.Color.Yellow;

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Returns the right value ({1}) for the where clause '(PersonSichtbarSDFlag = {1} or PersonSichtbarSDFlag = 1)'
        /// 0 = User can see person
        /// 1 = User can not see person
        /// </summary>
        public static int GetPersonSichtbarSDFlag(int BaPersonID)
        {
            int rslt = 0;

            if (!Session.User.IsUserKA)
            {
                if (!IsPersonVisibleSD(BaPersonID))
                    rslt = 1;
            }

            return rslt;
        }

        /// <summary>
        /// Gets the name of the User (Sozialarbeiter, SAR) responsible for der Modul F
        /// of a Customer with the corresponding Modul K.
        /// </summary>
        /// <param name="faLeistungID_Ka">FaLeistungID for the Modul K</param>
        /// <returns>Name, Vorname of the User</returns>
        public static string GetSARModulF(int faLeistungID_Ka)
        {
            string result = string.Empty;

            result = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                SELECT
                  SARModulF = ISNULL(USR.LastName + ', ', '') + ISNULL(USR.FirstName, '')
                FROM FaLeistung LEIK
                  LEFT JOIN BaPerson PRS ON PRS.BaPersonID = LEIK.BaPersonID
                  LEFT JOIN FaLeistung LEIF ON LEIF.BaPersonID = LEIK.BaPersonID AND LEIF.ModulID = 2
                  LEFT JOIN XUser USR ON USR.UserID = LEIF.UserID
                WHERE LEIK.ModulID = 7 AND LEIK.FaLeistungID = {0}
                  AND ((LEIK.DatumBis IS NULL AND LEIF.DatumBis IS NULL)
                        OR (LEIK.DatumBis >= LEIF.DatumVon AND (LEIF.DatumBis IS NULL OR LEIK.DatumBis < DATEADD(day, 1, LEIF.DatumBis))))", faLeistungID_Ka));

            return result;
        }

        /// <summary>
        /// Returns the right value ({1}) for the where clause '(SichtbarSDFlag = {1} or SichtbarSDFlag = 1)'
        /// 0 = User can see all data
        /// 1 = User can not see all data
        /// </summary>
        public static int GetSichtbarSDFlag(int BaPersonID)
        {
            int rslt = 0;

            if (!Session.User.IsUserKA)
            {
                if (!IsVisibleSD(BaPersonID))
                    rslt = 1;
            }

            return rslt;
        }

        /// <summary>
        /// Checks if the Austrittdatum is part of an Arbeitsrapport date range.
        /// </summary>
        /// <param name="faLeistungId">FaLeistungID</param>
        /// <param name="austrittDatum">Date to check</param>
        /// <returns>
        ///          0 if the date is NOT part of any range
        ///          1 if the date is part of any range
        ///          1 if there is no Arbeitsrapport
        /// </returns>
        public static bool IsDatePartOfAnArbeitsRapportRange(int faLeistungId, DateTime? austrittDatum)
        {
            var hatEinsatz = DBUtil.OpenSQL(@"
                SELECT TOP 1 1
                FROM dbo.KaEinsatz EIN WITH (READUNCOMMITTED)
                WHERE EIN.FaLeistungID = {0}
                  AND EIN.AnweisungCode <> 1;", faLeistungId);

            if (hatEinsatz.HasRow)
            {
                var letzteAnweisung = DBUtil.OpenSQL(@"
                    SELECT TOP 1 DatumVon, DatumBis
                    FROM dbo.KaEinsatz EIN WITH (READUNCOMMITTED)
                    WHERE EIN.FaLeistungID = {0}
                      AND EIN.AnweisungCode <> 1
                    ORDER BY EIN.DatumBis DESC;", faLeistungId);

                var datumVon = (DateTime)letzteAnweisung[DBO.KaEinsatz.DatumVon];
                var datumBis = (DateTime)letzteAnweisung[DBO.KaEinsatz.DatumBis];
                austrittDatum = austrittDatum ?? datumBis;

                return austrittDatum >= datumVon && austrittDatum <= datumBis;
            }

            return true;
        }

        /// <summary>
        /// Has user right of SD to see person
        /// </summary>
        public static bool IsPersonVisibleSD(int BaPersonID)
        {
            bool rslt;

            rslt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"select PersonSichtbarSDFlag from BaPerson where BaPersonID = {0}", BaPersonID)) == 1;

            return rslt;
        }

        /// <summary>
        /// Has user right of SD to see data
        /// </summary>
        public static bool IsVisibleSD(int BaPersonID)
        {
            bool rslt;

            rslt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"select SichtbarSDFlag from BaPerson where BaPersonID = {0}", BaPersonID)) == 1;

            return rslt;
        }

        public static void UpdateDatumBisAllgemein(int baPersonId)
        {
            var alleProzesseAbgeschlossen = DBUtil.ExecuteScalarSQL(@"
                IF (EXISTS(SELECT TOP 1 1
                           FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                           WHERE BaPersonID = {0}
                             AND ModulID = 7
                             AND FaProzessCode BETWEEN 701 AND 720
                             AND DatumBis IS NULL))
                BEGIN
                  SELECT CONVERT(BIT, 0);
                END
                ELSE
                BEGIN
                  SELECT CONVERT(BIT, 1);
                END;",
                baPersonId) as bool? ?? false;

            DateTime? datumBis = null;
            if (alleProzesseAbgeschlossen)
            {
                datumBis = DateTime.Today;
            }

            DBUtil.ExecSQL(@"
                UPDATE dbo.FaLeistung
                  SET DatumBis = {1},
                      Modifier = {2},
                      Modified = GETDATE()
                WHERE BaPersonID = {0}
                  AND ModulID = 7
                  AND FaProzessCode = 700;",
                baPersonId,
                datumBis,
                DBUtil.GetDBRowCreatorModifier());
        }

        public static void UpdateKaArbeitsRapportRecords(int faLeistungId)
        {
            //lösche Arbeitsrapport Records ausserhalb des zugehörigen Einsatzes
            DBUtil.ExecSQLThrowingException(@"
                    DELETE KAR
                    FROM KaArbeitsrapport KAR
                      INNER JOIN KaEinsatz EIN ON EIN.KaEinsatzID = KAR.KaEinsatzID
                      OUTER APPLY dbo.fnKaGetAustrittDatumCode(EIN.FaLeistungID, EIN.KaEinsatzID) AUS
                    WHERE EIN.FaLeistungID = {0}
                    AND (KAR.Datum < EIN.DatumVon
                      OR KAR.Datum > IsNull(AUS.AustrittDatum, EIN.DatumBis));",
                faLeistungId);

            //lösche Arbeitsrapport Recods an inaktiven Wochenend-Tagen inner halb des zugehörigen Einsatzes
            DBUtil.ExecSQLThrowingException(@"
                    DECLARE @Saturday INT;
                    DECLARE @Sunday INT;
                    DECLARE @NumberFirstDayOfWeek INT;

                    SET @NumberFirstDayOfWeek = @@DATEFIRST;

                    -- Die Nummer des Samstags gemäss Einstellung der DB holen
                    SET @Saturday = CASE @NumberFirstDayOfWeek
                                    WHEN 1 THEN 6
                                    WHEN 2 THEN 5
                                    WHEN 3 THEN 4
                                    WHEN 4 THEN 3
                                    WHEN 5 THEN 2
                                    WHEN 6 THEN 1
                                    ELSE 7
                                    END;

                    -- Die Nummer des Sonntags gemäss Einstellung der DB holen
                    SET @Sunday = CASE @NumberFirstDayOfWeek
                                    WHEN 1 THEN 7
                                    WHEN 2 THEN 6
                                    WHEN 3 THEN 5
                                    WHEN 4 THEN 4
                                    WHEN 5 THEN 3
                                    WHEN 6 THEN 2
                                    ELSE 1
                                END;

                    DELETE KAR
                    FROM KaArbeitsrapport KAR
                        INNER JOIN KaEinsatz EIN ON EIN.KaEinsatzID = KAR.KaEinsatzID
                        OUTER APPLY dbo.fnKaGetAustrittDatumCode(EIN.FaLeistungID, EIN.KaEinsatzID) AUS
                    WHERE EIN.FaLeistungID = {0}
                    AND KAR.Datum <= IsNull(AUS.AustrittDatum, EIN.DatumBis)
                    AND KAR.Datum >= EIN.DatumVon
                    AND (EIN.SamstagAktiv = 0 AND DATEPART(dw, KAR.Datum) = @Saturday
                            OR EIN.SonntagAktiv = 0 AND DATEPART(dw, KAR.Datum) = @Sunday) --Sonntag
                    ;",
                faLeistungId);

            //ermittle Arbeitsrapport-/Einsatz-Daten
            var qryDate = DBUtil.OpenSQL(@"
                SELECT KaArbeitsrapportVon=MIN(KAR.Datum), KaArbeitsrapportBis=MAX(KAR.datum),
                       KaEinsatzDatumVon=MIN(EIN.DatumVon), KaEinsatzDatumBis=MAX(ISNULL(AUS.AustrittDatum, EIN.DatumBis)),
                       EIN.KaEinsatzID,
                       EIN.SamstagAktiv,
                       EIN.SonntagAktiv
                FROM KaEinsatz EIN
                  LEFT JOIN KaArbeitsrapport KAR ON KAR.KaEinsatzID = EIN.KaEinsatzID
                  OUTER APPLY dbo.fnKaGetAustrittDatumCode(EIN.FaLeistungID, EIN.KaEinsatzID) AUS
                WHERE EIN.FaLeistungID = {0}
                  AND EIN.AnweisungCode <> 1 --1: Zuweisung
                GROUP BY EIN.KaEinsatzID,
                         EIN.SamstagAktiv,
                         EIN.SonntagAktiv;",
                    faLeistungId);
            if (qryDate.IsEmpty)
            {
                //nothing to do
                return;
            }

            do
            {
                int? kaEinsatzId = qryDate["KaEinsatzID"] as int?;

                DateTime? arbeitsrapportFromDate = qryDate["KaArbeitsrapportVon"] as DateTime?;
                DateTime? arbeitsrapportToDate = qryDate["KaArbeitsrapportBis"] as DateTime?;

                DateTime? einsatzFromDate = qryDate["KaEinsatzDatumVon"] as DateTime?; /*.AddDays(1)*/
                DateTime? einsatzToDate = qryDate["KaEinsatzDatumBis"] as DateTime?; /*.AddDays(1)*/

                bool samstagAktiv = qryDate["SamstagAktiv"] as bool? ?? false;
                bool sonntagAktiv = qryDate["SonntagAktiv"] as bool? ?? false;

                if (!kaEinsatzId.HasValue || !einsatzFromDate.HasValue || !einsatzToDate.HasValue)
                {
                    //wir haben noch keinen Einsatz
                    //--> do nothing
                    return;
                }

                //Erstelle KaArbeitsrapport Records für die Periode <einsatzFromDate>:<einsatzToDate>
                DateTime actDate = einsatzFromDate.Value;
                DateTime toDate = einsatzToDate.Value;
                while (actDate <= toDate)
                {
                    if (IsWorkday(actDate, samstagAktiv, sonntagAktiv))
                    {
                        InsertRow(kaEinsatzId.Value, actDate);
                    }

                    actDate = actDate.AddDays(1);
                }
            } while (qryDate.Next());
        }

        public static bool WouldKaArbeitsRapportRecordsBeDeleted(int kaEinsatzId, DateTime einsatzDatumVon, DateTime einsatzDatumBis)
        {
            var qryDate =
                DBUtil.OpenSQL(@"
                    SELECT KAR.Datum,
                           EIN.SamstagAktiv,
                           EIN.SonntagAktiv
                    FROM KaArbeitsrapport KAR
                      INNER JOIN KaEinsatz EIN ON EIN.KaEinsatzID = KAR.KaEinsatzID
                      OUTER APPLY dbo.fnKaGetAustrittDatumCode(EIN.FaLeistungID, EIN.KaEinsatzID) AUS
                    WHERE EIN.KaEinsatzID = {0}
                    AND EIN.AnweisungCode <> 1 --1: Zuweisung
                    AND (KAR.AM_AnwCode <> -1 OR KAR.PM_AnwCode <> -1)
                    AND (KAR.Datum < CONVERT(DATETIME, {1}, 104)
                      OR KAR.Datum > IsNull(AUS.AustrittDatum, CONVERT(DATETIME, {2}, 104)));",
                    kaEinsatzId, einsatzDatumVon, einsatzDatumBis);

            if (qryDate.IsEmpty)
            {
                //nothing to do
                return false;
            }

            do
            {
                DateTime datum = Convert.ToDateTime(qryDate["Datum"]);
                bool samstagAktiv = Convert.ToBoolean(qryDate["SamstagAktiv"]);
                bool sonntagAktiv = Convert.ToBoolean(qryDate["SonntagAktiv"]);

                if (IsWorkday(datum, samstagAktiv, sonntagAktiv))
                {
                    return true;
                }
            } while (qryDate.Next());

            return false;
        }

        public static bool WouldKaArbeitsRapportRecordsBeDeleted(int faLeistungId, DateTime? austrittDatum, out DateTime? datumVon, out DateTime? datumBis)
        {
            var qryDate =
                DBUtil.OpenSQL(@"
                    SELECT KAR.Datum, EIN.DatumVon, DatumBis=IsNull(CONVERT(DATETIME, {1}, 104), EIN.DatumBis), EIN.SamstagAktiv, EIN.SonntagAktiv
                    FROM KaArbeitsrapport KAR
                      INNER JOIN KaEinsatz EIN ON EIN.KaEinsatzID = KAR.KaEinsatzID
                    WHERE EIN.FaLeistungID = {0}
                    AND EIN.AnweisungCode <> 1 --1: Zuweisung
                    AND (KAR.AM_AnwCode <> -1 OR KAR.PM_AnwCode <> -1)
                    AND (KAR.Datum < EIN.DatumVon
                      OR KAR.Datum > IsNull(CONVERT(DATETIME, {1}, 104), EIN.DatumBis));",
                    faLeistungId, austrittDatum);

            if (qryDate.IsEmpty)
            {
                //nothing to do
                datumVon = null;
                datumBis = null;
                return false;
            }

            do
            {
                DateTime datum = Convert.ToDateTime(qryDate["Datum"]);
                bool samstagAktiv = Convert.ToBoolean(qryDate["SamstagAktiv"]);
                bool sonntagAktiv = Convert.ToBoolean(qryDate["SonntagAktiv"]);

                if (IsWorkday(datum, samstagAktiv, sonntagAktiv))
                {
                    datumVon = qryDate["DatumVon"] as DateTime?;
                    datumBis = qryDate["DatumBis"] as DateTime?;
                    return true;
                }
            } while (qryDate.Next());

            datumVon = null;
            datumBis = null;
            return false;
        }

        public static bool WouldKaArbeitsRapportRecordsBeDeleted(int kaEinsatzId, bool samstagAktiv, bool sonntagAktiv)
        {
            var nbrRecordsToDelete =
                DBUtil.ExecuteScalarSQL(@"
                    DECLARE @Saturday INT;
                    DECLARE @Sunday INT;
                    DECLARE @NumberFirstDayOfWeek INT;

                    SET @NumberFirstDayOfWeek = @@DATEFIRST;

                    -- Die Nummer des Samstags gemäss Einstellung der DB holen
                    SET @Saturday = CASE @NumberFirstDayOfWeek
                                    WHEN 1 THEN 6
                                    WHEN 2 THEN 5
                                    WHEN 3 THEN 4
                                    WHEN 4 THEN 3
                                    WHEN 5 THEN 2
                                    WHEN 6 THEN 1
                                    ELSE 7
                                    END;

                    -- Die Nummer des Sonntags gemäss Einstellung der DB holen
                    SET @Sunday = CASE @NumberFirstDayOfWeek
                                    WHEN 1 THEN 7
                                    WHEN 2 THEN 6
                                    WHEN 3 THEN 5
                                    WHEN 4 THEN 4
                                    WHEN 5 THEN 3
                                    WHEN 6 THEN 2
                                    ELSE 1
                                END;

                    SELECT COUNT(1)
                    FROM KaArbeitsrapport KAR
                      INNER JOIN KaEinsatz EIN ON EIN.KaEinsatzID = KAR.KaEinsatzID
                      OUTER APPLY dbo.fnKaGetAustrittDatumCode(EIN.FaLeistungID, EIN.KaEinsatzID) AUS
                    WHERE EIN.KaEinsatzID = {0}
                    AND EIN.AnweisungCode <> 1 --1: Zuweisung
                    AND (KAR.AM_AnwCode <> -1 OR KAR.PM_AnwCode <> -1)
                    AND ({1} = 0 AND DATEPART(dw, KAR.Datum) = @Saturday
                         OR {2} = 0 AND DATEPART(dw, KAR.Datum) = @Sunday)
                    ;",
                    kaEinsatzId, samstagAktiv, sonntagAktiv) as int?;

            return nbrRecordsToDelete > 0;
        }

        #endregion

        #region Private Static Methods

        private static void InsertRow(int kaEinsatzId, DateTime aDate)
        {
            //make sure, we don't insert a record if it already exists
            var cntExisting = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.KaArbeitsrapport KAR WITH (READUNCOMMITTED)
                  INNER JOIN dbo.KaEinsatz EIN WITH (READUNCOMMITTED) ON EIN.KaEinsatzID = {0}
                                                                     AND EIN.BaPersonID = KAR.BaPersonID
                WHERE Datum = CONVERT(DATETIME, {1}, 104);", kaEinsatzId, aDate));

            if (cntExisting > 0)
            {
                return;
            }

            DBUtil.ExecSQL(@"
                INSERT INTO dbo.KaArbeitsrapport (BaPersonID, KaEinsatzID, Datum, AM_AnwCode, PM_AnwCode, SichtbarSDFlag)
                SELECT PER.BaPersonID, EIN.KaEinsatzID, CONVERT(DATETIME, {1}, 104), -1, -1, PER.PersonSichtbarSDFlag
                FROM KaEinsatz EIN WITH (READUNCOMMITTED)
                  INNER JOIN BaPerson PER WITH (READUNCOMMITTED) ON PER.BaPersonID = EIN.BaPersonID
                WHERE EIN.KaEinsatzID = {0}",
                kaEinsatzId,
                aDate);
        }

        private static bool IsWorkday(DateTime actDate, bool samstagAktiv, bool sonntagAktiv)
        {
            switch (actDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return samstagAktiv;

                case DayOfWeek.Sunday:
                    return sonntagAktiv;

                default:
                    return true;
            }
        }

        #endregion

        #endregion
    }
}