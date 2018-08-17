using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KiSS4.DB;

namespace Kiss.Integration
{
    public class PermissionGroupReader
    {
        public static IDictionary<int, string> GetPermissionGroup()
        {
            IDictionary<int, string> permissionGroupDictionary = new Dictionary<int, string>();

            SqlQuery qry = DBUtil.OpenSQL(
                                            string.Format(@"
                                                               SELECT   PermissionGroupID,
                                                                        PermissionGroupName
                                                               FROM dbo.XPermissionGroup PMG  WITH (READUNCOMMITTED)
                                                               ORDER BY PermissionGroupName;"
                                                            )
                                           );

            foreach (System.Data.DataRow row in qry.DataTable.Rows)
            {
                permissionGroupDictionary.Add((int)row["PermissionGroupID"], (string)row["PermissionGroupName"]);
            }

            return permissionGroupDictionary;
        }
    }
}