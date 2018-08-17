using System;

using KiSS4.DB;

namespace KiSS4.BL
{
    public class BaPersonService
    {
        #region Methods

        #region Public Static Methods

        public static string GetBaPersonNameVornameByBaPersonId(int? baPersonId)
        {
            return (string)DBUtil.ExecuteScalarSQLThrowingException(@"
                DECLARE @NameVorname VARCHAR(MAX);

                SELECT @NameVorname = NameVorname
                FROM dbo.vwPersonSimple WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0};

                SELECT ISNULL(@NameVorname, '');",
                baPersonId);
        }

        /// <summary>
        /// Get Name + Vorname of client of current <paramref name="faLeistungId"/>
        /// </summary>
        /// <param name="faLeistungId">The FaLeistungID to use for getting name of client</param>
        /// <returns>Name + Vorname or empty string</returns>
        public static string GetKlientNameVorname(int faLeistungId)
        {
            return Convert.ToString(DBUtil.ExecuteScalarSQLThrowingException(@"
                DECLARE @NameVorname VARCHAR(200);

                SELECT @NameVorname = PRS.NameVorname
                FROM dbo.vwPerson PRS
                WHERE PRS.BaPersonID = (SELECT LEI.BaPersonID
                                        FROM dbo.FaLeistung LEI
                                        WHERE LEI.FaLeistungID = {0});

                SELECT ISNULL(@NameVorname, '');", faLeistungId));
        }

        #endregion

        #endregion
    }
}