using System;

using KiSS4.DB;

namespace KiSS4.Schnittstellen.Newod.Converter
{
    internal class LovConverter
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly int newodId;

        #endregion

        #region Private Fields

        private int? baPersonId;

        #endregion

        #endregion

        #region Constructors

        public LovConverter(int newodPersonId)
        {
            newodId = newodPersonId;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Map BFS-Code to BaGemeindeID
        /// </summary>
        /// <param name="bfsCode">BFS-Code of Gemeinde</param>
        /// <param name="fieldspecification">Specification of the field, for logging purpose only</param>
        /// <returns>BaGemeindeID</returns>
        public int? MapBfsCodeToBaGemeindeId(string bfsCodeString, string fieldspecification)
        {
            if (string.IsNullOrEmpty(bfsCodeString))
            {
                return null;
            }

            //es kann vorkommen, dass als BFSCode so etwas wie: 942.01 daherkommt. Bedeutung: Gemeinde hat mit der Gemeinde 942 fusioniert.
            //-> es ist also der Teil vor dem Punkt massgebend.
            var bfsCodeParts = bfsCodeString.Split('.');
            if (bfsCodeParts.Length > 1)
            {
                XLog.Create(
                    GetType().FullName,
                    3,
                    LogLevel.ERROR,
                    "Mapping-Fehler: Ungültiger Gemeinde-BFSCode",
                    string.Format("Unerwarteter Wert: {0} für das Feld: '{1}' erhalten. Es wird der Ganzzahl-Teil: {2} fürs Gemeinde-Mapping verwendet.", bfsCodeString, fieldspecification, bfsCodeParts[0]),
                    "BaPerson",
                    GetBaPersonId());
                bfsCodeString = bfsCodeParts[0];
            }

            int bfsCode;
            if (!Int32.TryParse(bfsCodeString, out bfsCode))
            {
                XLog.Create(
                    GetType().FullName,
                    3,
                    LogLevel.ERROR,
                    "Mapping-Fehler: Ungültiger Gemeinde-BFSCode",
                    string.Format("Für das Feld '{0}' konnte folgender ungültiger BFS-Code '{1}' nicht in eine Ganzzahl konvertiert werden", fieldspecification, bfsCodeString),
                    "BaPerson",
                    GetBaPersonId());
                return null;
            }

            var qry = DBUtil.OpenSQL(@"SELECT BaGemeindeID FROM dbo.BaGemeinde WITH (READUNCOMMITTED) WHERE BFSCode = {0} AND GemeindeAufhebungDatum IS NULL", bfsCode);

            if (qry.Count == 0)
            {
                XLog.Create(
                    GetType().FullName,
                    3,
                    LogLevel.ERROR,
                    "Mapping-Fehler: Gemeinde nicht gefunden",
                    string.Format("Für das Feld '{0}' konnte anhand des BFS-Codes '{1}' keine Gemeinde gefunden werden!", fieldspecification, bfsCode),
                    "BaPerson",
                    GetBaPersonId());
                return null;
            }

            return int.Parse(qry.DataTable.Rows[0]["BaGemeindeID"].ToString());
        }

        /// <summary>
        /// Gets BaGemeindeID of a Heimatort PLZ
        /// </summary>
        /// <param name="plz">PLZ</param>
        /// <returns>BaGemeindeID</returns>
        public int? MapHeimatortplzToBaGemeindeId(string plz)
        {
            if (string.IsNullOrWhiteSpace(plz))
            {
                return null;
            }
            string sqlGemeinde = String.Format(@"SELECT TOP 1 BaGemeindeID
                                                 FROM dbo.BaGemeinde GEM
                                                   INNER JOIN BaPLZ PLZ ON PLZ.BFSCode = GEM.BFSCode
                                                 WHERE PLZ.PLZ = {0}
                                                   AND GEM.GemeindeAufhebungDatum IS NULL", plz);
            SqlQuery qry = new SqlQuery();
            qry.Fill(sqlGemeinde);

            if (qry.Count == 0)
            {
                XLog.Create(GetType().FullName, 3, LogLevel.ERROR, "Mapping-Fehler: Zuordnung Heimatort",
                    string.Format("Die Gemeinde (Heimatort) konnte anhand der PLZ '{0}' nicht gefunden werden!", plz),
                    "BaPerson", GetBaPersonId());
                return null;
            }

            return int.Parse(qry.DataTable.Rows[0]["BaGemeindeID"].ToString());
        }

        /// <summary>
        /// Converts isocode to BaLandID
        /// </summary>
        /// <param name="isocountrycode">countrycode (iso2 || iso3)</param>
        /// <param name="fieldspecification">Specification of the field, for logging purpose only</param>
        /// <returns>BaLandID</returns>
        public int? MapIsoCountryCodeToBaLandId(string isocountrycode, string fieldspecification)
        {
            if (string.IsNullOrWhiteSpace(isocountrycode))
            {
                return null;
            }
            string isocode = "Iso2Code";

            if (isocountrycode.Length == 3)
            {
                isocode = "Iso3Code";
            }
            string sqlCountry = String.Format(@"SELECT BaLandID FROM dbo.BaLand WITH (READUNCOMMITTED) WHERE {0} = {1}",
                isocode, DBUtil.SqlLiteral(isocountrycode));
            SqlQuery qry = new SqlQuery();

            qry.Fill(sqlCountry);

            if (qry.Count == 0)
            {
                XLog.Create(GetType().FullName, 3, LogLevel.ERROR, "Mapping-Fehler: Zuordnung Land",
                    string.Format("Für das Feld '{0}' konnte anhand des Landcodes '{1}' keine Land gefunden werden!",
                    fieldspecification, isocountrycode),
                    "BaPerson", GetBaPersonId());
                return null;
            }
            return qry.DataTable.Rows[0]["BaLandID"] as int?;
        }

        /// <summary>
        /// Maps a NEWOD Attribut to LOV Value with the mapping table SstNewodMapping
        /// </summary>
        /// <param name="attribut">Name of Attribut</param>
        /// <param name="code">Code</param>
        /// <returns>LOVCode</returns>
        public int? MapNewodToLovCode(string attribut, string code)
        {
            string lovText = MapNewodToLovText(attribut, code);
            if (!string.IsNullOrWhiteSpace(lovText))
            {
                int lovValue;
                if (int.TryParse(lovText, out lovValue))
                {
                    return lovValue;
                }
                XLog.Create(GetType().FullName, 3, LogLevel.ERROR, "Mapping-Fehler: Konvertierung in Zahl nicht möglich!",
                    string.Format("Das Newod Attribut '{0}' mit dem Wert '{1}' konnte nicht in eine Zahl (KiSS-Wert) umgewandelt werden!", attribut, code),
                    "BaPerson", GetBaPersonId());
            }
            return null;
        }

        public string MapNewodToLovText(string attribut, string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return null;
            }
            string sql = String.Format(@"
                SELECT KiSSWert FROM dbo.SstNewodMapping WITH (READUNCOMMITTED)
                    WHERE Attribut = {0} AND NewodWert = {1}", DBUtil.SqlLiteral(attribut), DBUtil.SqlLiteral(code));

            SqlQuery qry = new SqlQuery();
            qry.Fill(sql);
            if (qry.Count == 0)
            {
                XLog.Create(GetType().FullName, 3, LogLevel.ERROR, "Mapping-Fehler: Wert in Tabelle SstNewodMapping nicht gefunden!",
                    string.Format("Das Newod Attribut '{0}' mit dem Wert '{1}' wurde in der Mapping-Tabelle SstNewodMapping nicht gefunden!",
                    attribut, code), "BaPerson", GetBaPersonId());
                return null;
            }
            return qry["KiSSWert"].ToString();
        }

        /// <summary>
        /// Map ortname to BaGemeindeID
        /// </summary>
        /// <param name="ortname">Name of Gemeinde</param>
        /// <param name="fieldspecification">Specification of the field, for logging purpose only</param>
        /// <returns>BaGemeindeID</returns>
        public int? MapOrtnameToBaGemeindeId(string ortname, string fieldspecification)
        {
            if (string.IsNullOrWhiteSpace(ortname))
            {
                return null;
            }
            string sqlGemeinde = String.Format(@"SELECT BaGemeindeID FROM dbo.BaGemeinde WITH (READUNCOMMITTED) WHERE Name = {0} AND GemeindeAufhebungDatum IS NULL", DBUtil.SqlLiteral(ortname));
            SqlQuery qry = new SqlQuery();
            qry.Fill(sqlGemeinde);
            if (qry.Count == 0)
            {
                XLog.Create(GetType().FullName, 3, LogLevel.ERROR, "Mapping-Fehler: Gemeinde nicht gefunden!",
                    string.Format("Für das Feld '{0}' konnte anhand des Ortnamens '{1}' keine Gemeinde gefunden werden!",
                    fieldspecification, ortname), "BaPerson", GetBaPersonId());
                return null;
            }
            if (qry.Count > 1)
            {
                XLog.Create(GetType().FullName, 3, LogLevel.ERROR, "Mapping-Fehler: Gemeinde nicht eindeutig!",
                    string.Format("Für das Feld '{0}' konnte anhand des Ortnamens '{1}' keine eindeutige Gemeinde gefunden werden!",
                    fieldspecification, ortname), "BaPerson", GetBaPersonId());
                return null;
            }
            return int.Parse(qry.DataTable.Rows[0]["BaGemeindeID"].ToString());
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get baperson id with newodpersonid
        /// Cache bapersonid for further error-messages.
        /// </summary>
        /// <returns>BaPersonId</returns>
        private int GetBaPersonId()
        {
            if (baPersonId.HasValue)
            {
                return baPersonId.Value;
            }
            string sqlBaPerson = String.Format(@"
                                SELECT
                                    BaPersonID
                                FROM BaPerson_NewodPerson
                                WHERE
                                  NewodPersonID = {0};", newodId);
            object baPersonIdObject = DBUtil.ExecuteScalarSQL(sqlBaPerson);
            if (baPersonIdObject != null)
            {
                baPersonId = (int)baPersonIdObject;
                return baPersonId.Value;
            }
            return 0;
        }

        #endregion

        #endregion
    }
}