using KiSS4.DB;
using KiSS4.Dokument.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiss.Integration
{
    public class ProfileReader
    {
        public static IDictionary<int, string> GetProfile()
        {
            IDictionary<int, string> profileDictionary = new Dictionary<int, string>();

            SqlQuery qry = GuiUtilities.GetSqlQueryXProfilesUserOrOrgUnit();

            foreach (System.Data.DataRow row in qry.DataTable.Rows)
            {
                profileDictionary.Add((int)row["Code"], (string)row["Text"]);
            }

            return profileDictionary;
        }
    }
}