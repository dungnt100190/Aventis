using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace Kiss.Integration
{
    public class ModulTreeFacade
    {
        public static UserControl CreateModulTree(int modulID, int baPersonID, int faFallID, Panel detailPanel)
        {
            return AssemblyLoader.GetKissModulTree(modulID, baPersonID, faFallID, detailPanel);
        }

        public static IEnumerable<ModulTreeDescription> GetModulTreeDescriptions(int baPersonID, int? faFallID = null)
        {
            var qry = DBUtil.OpenSQL("EXECUTE spFaGetModulIcon {0}, {1}, 1", baPersonID, faFallID == -1 ? null : faFallID);
            return qry.DataTable.Rows.Cast<DataRow>().Select(row => new ModulTreeDescription
                                                                        {
                                                                            ModulID = (int)row["ModulID"],
                                                                            ShortName = row["ShortName"] as string,
                                                                            IconID = (int)row["IconID"]
                                                                        });
        }

        public static void ShowCurrentDetailControl(Control modultree)
        {
            var modulTreeCasted = modultree as KissModulTree;
            if (modulTreeCasted != null)
            {
                modulTreeCasted.ShowDetail();
            }
        }
    }
}