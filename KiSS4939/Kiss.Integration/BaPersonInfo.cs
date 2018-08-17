using System;
using KiSS4.DB;

namespace Kiss.Integration
{
    public class BaPersonInfo
    {
        /// <summary>
        /// Holt Daten von spBaGetPersonInfoTitel
        /// </summary>
        /// <param name="baPersonId"></param>
        /// <param name="userId"></param>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        public static BaPersonInfoDTO GetPersonInfoTitelQuery(int baPersonId, int userId, int languageCode)
        {
            // read data from database
            var sqlQuery = DBUtil.OpenSQL(@"EXEC dbo.spBaGetPersonInfoTitel {0}, {1}, {2};",

                baPersonId,
                userId,
                languageCode);
            if (sqlQuery.IsEmpty)
            {
                return null;
            }

            bool wichtigerHinweis = false;
            var sqlIcon =
                DBUtil.OpenSQL(string.Format("SELECT Name FROM XIcon WHERE XIconID = {0}", sqlQuery["ImageIndex"]));
            if (!sqlIcon.IsEmpty)
            {
                if (Convert.ToString(sqlIcon["Name"]).Contains("WichtigerHinweis"))
                {
                    wichtigerHinweis = true;
                }
            }

            return new BaPersonInfoDTO
            {
                Titel = Convert.ToString(sqlQuery["TitleText"]),
                WichtigierHinweis = wichtigerHinweis,
                Tooltip = Convert.ToString(sqlQuery["ToolTipText"])
            };
        }

        public static BaPersonInfoDTO GetPersonInfoTitelQuery(int baPersonId)
        {
            return GetPersonInfoTitelQuery(baPersonId, Session.User.UserID, Session.User.LanguageCode);
        }
    }
}