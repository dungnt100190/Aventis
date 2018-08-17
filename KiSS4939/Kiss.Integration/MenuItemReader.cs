using System.Collections.Generic;
using System.Data;
using KiSS4.DB;

namespace Kiss.Integration
{
    public class Hyperlink
    {
        public int HyperlinkID;
        public string Name;
        public string Url;
    }

    public class MenuItem
    {
        public string Caption;
        public string ClassName;
        public bool Enabled;
        public int ID;
        public bool IsFolder;
        public bool IsWinForms;
        public string NamespaceExtension;
        public int ParentID;
        public string Type;
        public bool UserHasRight;
        public bool Visible;
    }

    public class MenuItemReader
    {
        public static IEnumerable<MenuItem> GetDataExplorerItems()
        {
            var menuItems = new List<MenuItem>();

            var qry = DBUtil.OpenSQL(@"
            ;WITH MenuCte (MenuItemID, ParentMenuItemID, Caption, MenuTID, SortKey, ClassName)
            AS
            (
                SELECT  MenuItemID,
                        ParentMenuItemID,
                        Caption = CONVERT(VARCHAR(MAX), Caption),
                        MenuTID,
                        SortKey,
                        ClassName
                FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED)
                WHERE ClassName = 'FrmDataExplorer'

                UNION ALL

                SELECT  MNU.MenuItemID,
                        MNU.ParentMenuItemID,
                        Caption = CONVERT(VARCHAR(MAX),MNU.Caption),
                        MNU.MenuTID,
                        MNU.SortKey,
                        MNU.ClassName
                FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED)
                INNER JOIN MenuCte CTE ON CTE.MenuItemID = MNU.ParentMenuItemID
                WHERE MNU.Visible = 1
            )

            SELECT
                ID = CTE.MenuItemID,
                ParentID = CASE WHEN MNU.ClassName = 'FrmDataExplorer' THEN -1 ELSE CTE.ParentMenuItemID END,
                Caption = CONVERT(VARCHAR(MAX), ISNULL(LAN.Text, CTE.Caption)),
                ClassName = CLS.ClassName,
                IsWinForms = CONVERT(BIT, CASE WHEN CLS.ClassNameViewModel IS NULL THEN 1 ELSE 0 END)
            FROM MenuCte CTE
                LEFT JOIN dbo.XMenuItem MNU WITH (READUNCOMMITTED) ON MNU.MenuItemID = CTE.ParentMenuItemID
                LEFT JOIN dbo.XClass CLS WITH (READUNCOMMITTED) ON CLS.ClassName = CTE.ClassName
                LEFT JOIN dbo.XLangText LAN WITH (READUNCOMMITTED) ON LAN.TID = CTE.MenuTID
                                                                AND LAN.LanguageCode = {0}
            WHERE CTE.ClassName <> 'FrmDataExplorer'
                OR CTE.ClassName IS NULL
            ORDER BY ParentID, CTE.SortKey;", Session.User.LanguageCode);

            foreach (DataRow row in qry.DataTable.Rows)
            {
                menuItems.Add(new MenuItem
                {
                    ID = (int)row["ID"],
                    ParentID = (int)row["ParentID"],
                    Caption = (string)row["Caption"],
                    ClassName = row["ClassName"] as string,
                    Type = row["ClassName"] as string,
                    IsWinForms = (bool)row["IsWinForms"],
                    IsFolder = string.IsNullOrEmpty(row["ClassName"] as string),
                    UserHasRight = DBUtil.UserHasRight(row["ClassName"] as string)
                });
            }

            return menuItems;
        }

        public static IEnumerable<Hyperlink> GetHyperlinks()
        {
            var menuItems = new List<Hyperlink>();

            var qry = DBUtil.OpenSQL(@"
                SELECT HYP.XHyperlinkID, HYP.Hyperlink, HYP.Name
                FROM dbo.XHyperlink                          HYP WITH(READUNCOMMITTED)
                  INNER JOIN dbo.XHyperlinkContext_Hyperlink HYH WITH(READUNCOMMITTED) ON HYH.XHyperlinkID = HYP.XHyperlinkID
                  INNER JOIN dbo.XHyperlinkContext           HYC WITH(READUNCOMMITTED) ON HYC.XHyperlinkContextID = HYH.XHyperlinkContextID
                WHERE HYC.Name = 'LinkMenu'
                ORDER BY HYH.SortKey;");

            foreach (DataRow row in qry.DataTable.Rows)
            {
                menuItems.Add(new Hyperlink
                {
                    HyperlinkID = (int)row["XHyperlinkID"],
                    Name = row["Name"].ToString(),
                    Url = row["Hyperlink"].ToString(),
                });
            }

            return menuItems;
        }

        public static IEnumerable<MenuItem> GetMenuItems()
        {
            var menuItems = new List<MenuItem>();

            var qry = DBUtil.OpenSQL(@"
                -- Filtert die Masken für KiSS5 SysRibbon - ClassName die mit Frm beginnen sind als CtlFrm oder Ctl umgewandelt
                SELECT  ClassName = RES.ClassName,
                        NamespaceExtension = CLS.NamespaceExtension,
                        [Enabled] = RES.[Enabled],
                        [Visible] = RES.Visible
                FROM (
                            SELECT  ClassName = MNU.ClassName,
                                    [Enabled] = MNU.[Enabled],
                                    Visible = MNU.Visible
                            FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED)
                            WHERE MNU.ClassName IS NOT NULL
                            AND (MNU.OnlyBIAGAdminVisible = 0 OR {0} = 1)
                        ) RES
                  LEFT JOIN dbo.XClass CLS ON CLS.ClassName = RES.ClassName;", Session.User.IsUserBIAGAdmin);

            foreach (DataRow row in qry.DataTable.Rows)
            {
                string className = row["ClassName"].ToString();

                menuItems.Add(new MenuItem
                {
                    ClassName = className,
                    NamespaceExtension = DBUtil.IsEmpty(row["NamespaceExtension"]) ? null : row["NamespaceExtension"].ToString(),
                    Enabled = (bool)row["Enabled"],
                    Visible = (bool)row["Visible"],
                    UserHasRight = DBUtil.UserHasRight(className)
                });
            }

            return menuItems;
        }
    }
}