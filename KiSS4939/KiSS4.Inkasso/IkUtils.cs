using System;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Inkasso
{
    public static class IkUtils
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Zum Prüfen ob ein aktives Verrechnungskonto für eine Person in einer gegebene Zeitdauer vorhanden ist.
        /// </summary>
        /// <param name="ikVerrechnungskontoID">ID des Verrechnungskonto dass es nicht mit sich selber vergleicht</param>
        /// <param name="baPersonID">ID der Person</param>
        /// <param name="ikRechtstitelID">ID des Rechtstitels</param>
        /// <param name="datumVon">DatumVon des Verrechnungskonto</param>
        /// <param name="datumBis">DatumBis des Verrechnungskonto</param>
        /// <returns>true wenn ein aktives Verrechnungskonto vorhanden ist</returns>
        public static bool AlreadyHasAccountForGivenPerson(
            int ikVerrechnungskontoID,
            int baPersonID,
            int ikRechtstitelID,
            DateTime datumVon,
            DateTime datumBis)
        {
            // check if any other account exists for same person with crossing dates
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                IF (EXISTS(SELECT TOP 1 1
                           FROM dbo.IkVerrechnungskonto VRK WITH (READUNCOMMITTED)
                           WHERE VRK.IkVerrechnungskontoID <> {0}
                             AND VRK.BaPersonID = {1}
                             AND VRK.IkRechtstitelID = {2}
                             AND VRK.IstAnnulliert = 0 --nur aktive Konti interessieren uns
                             AND VRK.IstErledigt = 0   --nur aktive Konti interessieren uns
                             AND (dbo.fnFirstDayOf({3}) BETWEEN dbo.fnFirstDayOf(VRK.DatumVon) AND dbo.fnLastDayOf(ISNULL(VRK.AnnulliertAm, VRK.DatumBis))
                               OR dbo.fnLastDayOf({4}) BETWEEN dbo.fnFirstDayOf(VRK.DatumVon) AND dbo.fnLastDayOf(ISNULL(VRK.AnnulliertAm, VRK.DatumBis))
                               OR (dbo.fnFirstDayOf({3}) < dbo.fnFirstDayOf(VRK.DatumVon) AND dbo.fnLastDayOf({4}) > dbo.fnLastDayOf(ISNULL(VRK.AnnulliertAm, VRK.DatumBis)))
                                 )))
                BEGIN
                  -- already has account for given person
                  SELECT 1;
                END
                ELSE
                BEGIN
                  -- no account for given person
                  SELECT 0;
                END;", ikVerrechnungskontoID, baPersonID, ikRechtstitelID, datumVon, datumBis));
        }

        /// <summary>
        /// Get the corresponding value of IkLandesindex for given parameters
        /// </summary>
        /// <param name="ikIndexTypCode">The XLOVCode.Code of the lov IkIndexTyp used for mapping to IkLandesindexID</param>
        /// <param name="jahr">The year to use for getting the value of the corresponding IkLandesindex</param>
        /// <param name="monat">The month to use for getting the value of the corresponding IkLandesindex</param>
        /// <returns>The IkLandesindexWert.Wert or null if none matching data was found</returns>
        public static decimal? GetLandesIndexWert(int ikIndexTypCode, int jahr, int monat)
        {
            var landesindexWert = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnIkGetLandesindexWert({0}, {1}, {2});", ikIndexTypCode, jahr, monat);

            if (landesindexWert != null && !DBUtil.IsEmpty(landesindexWert))
            {
                return Convert.ToDecimal(landesindexWert);
            }

            return null;
        }

        /// <summary>
        /// Check if there are booked positions for given parameters
        /// </summary>
        /// <param name="ikRechtstitelID">The id of the IkRechtstitel</param>
        /// <param name="baPersonID">The id of the BaPerson</param>
        /// <param name="datumVon">The start date to use for checking (begin of month)</param>
        /// <param name="datumBis">The end date to use for checking (end of month)</param>
        /// <returns><c>True</c> if booked positions exist, otherwise <c>False</c></returns>
        public static bool HavingBookedPositions(int ikRechtstitelID, int baPersonID, DateTime datumVon, DateTime datumBis)
        {
            datumVon = Utils.firstDayOfMonth(datumVon);
            datumBis = Utils.lastDayOfMonth(datumBis);

            // check if there are entries within current account
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                IF (EXISTS(SELECT TOP 1 1
                           FROM dbo.IkPosition IPO WITH (READUNCOMMITTED)
                           WHERE IPO.IkRechtstitelID = {0}
                             AND IPO.BaPersonID = {1}
                             AND IPO.ErledigterMonat = 1    -- only Erledigt
                             AND IPO.Einmalig = 0           -- only Periodisch
                             AND dbo.fnLastDayOf(dbo.fnDateSerial(IPO.Jahr, IPO.Monat, 1)) BETWEEN {2} AND {3}))
                BEGIN
                  -- there are entries
                  SELECT 1;
                END
                ELSE
                BEGIN
                  -- there are no entries
                  SELECT 0;
                END;", ikRechtstitelID, baPersonID, datumVon, datumBis));
        }

        #endregion

        #endregion
    }
}