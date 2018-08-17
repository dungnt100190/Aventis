using System;
using System.Data;

using DevExpress.XtraEditors.Mask;

using KiSS.DBScheme;
using KiSS4.DB;

namespace KiSS4.Common
{
    /// <summary>
    /// Service Funktionen für
    /// </summary>
    public static class FallUtil
    {
        public const string LV_WECHSEL_PENDENZEN_FRAGE = "Mit Wechsel der Leistungsverantwortung werden gleichzeitig die Pendenzen übergeben. \nSoll der Wechsel wirklich vorgenommen werden?";

        /// <summary>
        /// Entfernt Gastrechte für jede aktiven Leistung (aber ohne ALIM)
        /// in einem Fall.
        /// </summary>
        /// <param name="userId">Die ID des Users, für welchen Gastrechte entfernt werden</param>
        /// <param name="faFallId">Die Id des Falls</param>
        public static void GastrechteEntfernen(int userId, int faFallId)
        {
            var query = DBUtil.OpenSQL(@"
                SELECT LEZ.*
                FROM FaFall                    FAF
                  INNER JOIN FaLeistung        FAL ON FAL.FaFallID = FAF.FaFallID
                  INNER JOIN FaLeistungZugriff LEZ ON FAL.FaLeistungID = LEZ.FaLeistungID
                                                  AND LEZ.UserID = {1}
                WHERE FAL.FaFallID = {0};",
                faFallId,
                userId);

            foreach (DataRow row in query.DataTable.Rows)
            {
                var faLeistungId = (int)row[DBO.FaLeistung.FaLeistungID];
                GastrechtEntfernen(userId, faLeistungId);
            }
        }

        /// <summary>
        /// Fügt Gastrechte für jede aktiven Leistung (aber ohne ALIM)
        /// in einem Fall hinzu.
        /// </summary>
        /// <param name="userId">Die ID des Users, für welchen Gastrechte erstellt werden.</param>
        /// <param name="faFallId">Die Id des Falls</param>
        /// <param name="darfMutieren">Ob nur lesend oder sogar mutierend auf die Leistungen zugegriffen werden darf </param>
        /// <param name="datumVon">Anfang der Zugriffgültigkeit</param>
        /// <param name="datumBis">End der Zugriffgültigkeit (am Tag des datumBis ist die Gültigkeit nicht mehr gültig)</param>
        /// <param name="isWithCheckExistsFaLeistungIDUserID">Prüft ob schon eine FaLeistungZugriff mit diesen (UserId, FaLeistungID) gibt. Nötig nur für Zürich weil die Tabelle nicht geschützt ist</param>
        /// ///
        public static void GastrechteHinzufuegen(int userId, int faFallId, bool darfMutieren, DateTime? datumVon, DateTime? datumBis, bool isWithCheckExistsFaLeistungIDUserID)
        {
            var query = DBUtil.OpenSQL(@"
                SELECT
                    LEI.FaLeistungID
                FROM FaLeistung LEI
                WHERE
                    LEI.DatumBis IS NULL -- Noch nicht abgeschlossen
                    AND IsNull(LEI.FaProzessCode, 0) <> 201 -- ohne FaAlim
                    AND LEI.FaFallID = {0};
            ", faFallId);

            foreach (DataRow row in query.DataTable.Rows)
            {
                var faLeistungId = (int)row[DBO.FaLeistung.FaLeistungID];
                GastrechtHinzufuegen(userId, faLeistungId, darfMutieren, datumVon, datumBis, isWithCheckExistsFaLeistungIDUserID);
            }
        }

        /// <summary>
        /// Fügt das Gastrecht für einen User zu eienr Leistung hinzu.
        /// Für ZH wird die aktion in FaJournal geloggt.
        /// </summary>
        /// <param name="userId">Userid, welcher neu das Gastrecht haben sollte</param>
        /// <param name="faLeistungId">Die Id der Leistung</param>
        /// <param name="darfMutieren">Ob nur lesend oder sogar mutierend auf die Leistung zugegriffen werden darf</param>
        /// <param name="datumVon">Anfang der Zugriffgültigkeit</param>
        /// <param name="datumBis">End der Zugriffgültigkeit (am Tag des datumBis ist die Gültigkeit nicht mehr gültig)</param>
        /// <param name="isWithCheckExistsFaLeistungIDUserID">Prüft ob schon eine FaLeistungZugriff mit diesen (UserId, FaLeistungID) gibt. Nötig nur für Zürich weil die Tabelle nicht geschützt ist</param>
        public static void GastrechtHinzufuegen(int userId, int faLeistungId, bool darfMutieren, DateTime? datumVon, DateTime? datumBis, bool isWithCheckExistsFaLeistungIDUserID)
        {
            var darfMutierenAsInt = darfMutieren ? 1 : 0;

            var inserted = DBUtil.ExecSQL(@"
                        INSERT INTO FaLeistungZugriff (FaLeistungID, UserID, DarfMutieren, datumVon, datumBis)
                          SELECT {0}, {1}, {2}, {3}, {4}
                          WHERE 1=1
                          AND ({5}=0 OR
                                            {0} NOT IN (SELECT FaLeistungID
                                            FROM FaLeistungZugriff
                                            WHERE FaLeistungID = {0} AND UserID = {1}))",
                                                                                       faLeistungId,
                                                                                       userId,
                                                                                       darfMutierenAsInt,
                                                                                       (datumVon == null) ? null : (object)datumVon,
                                                                                       (datumBis == null) ? null : (object)datumBis,
                                                                                       isWithCheckExistsFaLeistungIDUserID);

            if (inserted > 0)
            {
                InsertFaJournal(userId, //User, der neu das Gastrecht hat
                                faLeistungId,
                                "Gastrecht hinzugefügt für Teilleistungserbringer/in ");
            }
        }

        /// <summary>
        /// DatumBis für eine neue Periode für die Tabelle FaLeistungZugriff
        /// </summary>
        public static DateTime GetFaLeistungZugriffNewDatumBis()
        {
            return DateTime.Today.AddMonths((int)DBUtil.GetConfigValue(@"System\Allgemein\GastrechtAnzahlMonate", 6));
        }

        /// <summary>
        /// DatumVon für eine neue Periode für die Tabelle FaLeistungZugriff
        /// </summary>
        public static DateTime GetFaLeistungZugriffNewDatumVon()
        {
            return DateTime.Today;
        }

        /// <summary>
        ///  Hohlt die FallId einer Leistung.
        /// </summary>
        /// <param name="faLeistungId">Die Id der Leistung</param>
        /// <returns>FallNummer. Im Standard ist die Fallnummer identisch mit der Personennummer.</returns>
        public static int GetFallIdFromLeistungId(int faLeistungId)
        {
            return (int)DBUtil.ExecuteScalarSQL(
                @"SELECT
                    LEI.FaFallID
                  FROM FaLeistung LEI
                  WHERE
                     LEI.FaLeistungID = {0}", faLeistungId);
        }

        private static void GastrechtEntfernen(int userId, int faLeistungId)
        {
            var deleted = DBUtil.ExecSQL(string.Format(@"
                        DELETE FROM FaLeistungZugriff
                        WHERE FaLeistungID = {0}
                          AND UserID       = {1};", faLeistungId, userId));

            if (deleted > 0)
            {
                InsertFaJournal(userId, //User, der neu das Gastrecht hat
                                faLeistungId,
                                "Gastrecht entfernt für Teilleistungserbringer/in ");
            }
        }

        private static void InsertFaJournal(int userId, int faLeistungId, string text)
        {
            //Nur Züri hat FaJournal.
            var tableFaJournalExists = (int)DBUtil.ExecuteScalarSQL(
                @"SELECT COUNT(1) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FaJournal]') AND type in (N'U')");

            //Nur Züri hat FaJournal.
            if (tableFaJournalExists > 0)
            {
                DBUtil.ExecSQL(
                    @"
                DECLARE @UserIdEingeloggt INT;
                DECLARE @UserIdMitNeuemGastrecht INT;
                DECLARE @FaLeistungId INT;

                SET @UserIdEingeloggt        =   {0};
                SET @UserIdMitNeuemGastrecht =   {1};
                SET @FaLeistungId            =   {2};

                INSERT INTO FaJournal
                (
                    FaFallID,
                    FaLeistungID,
                    BaPersonID,
                    UserID,
                    [Text],
                    OrgUnitID
                )
                SELECT
                    LEI.FaFallID,        -- FaFallID
                    LEI.FaLeistungID,    -- FaLeistugnID
                    NULL,                -- BaPersonId
                    USR_ADMIN.UserID,    -- UserId
                    {3} + ' ' + ISNULL(USR_LEI.LogonName, '') + ' - ' + USR_LEI.NameVorname + ' (' + ISNULL(USR_LEI.OrgEinheitName, '-') + ')', -- Text
                    USR_ADMIN.OrgUnitId
                FROM vwUser     USR_ADMIN,
                     FaLeistung LEI,
                     vwUser     USR_LEI
                WHERE
                    USR_ADMIN.UserID = @UserIdEingeloggt
                    AND USR_LEI.UserID  = @UserIdMitNeuemGastrecht
                    AND LEI.FaLeistungID = @FaLeistungId;",
                    Session.User.UserID, //Eingeloggter User
                    userId, //User, der neu das Gastrecht hat
                    faLeistungId, //Leistung
                    text);
            }
        }
    }
}