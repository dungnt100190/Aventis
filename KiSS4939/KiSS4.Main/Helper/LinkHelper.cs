using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

using DevExpress.XtraBars;

namespace KiSS4.Main.Helper
{
    /// <summary>
    /// Provides static methods for creating a dynamic link menu.
    /// </summary>
    public static class LinkHelper
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// The name of the XHyperlinkContext that is used for defining the dynamic link items.
        /// </summary>
        public const string XHYPERLINK_CONTEXT_LINKS = "LinkMenu";

        /// <summary>
        /// The XIcon ID of the icon to use for the dynamic link items.
        /// </summary>
        public const int XICON_LINK = 126;

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Gets an array of <see cref="BarButtonItem"/>s that work as links.
        /// </summary>
        /// <param name="parent">The parent of the link items.</param>
        public static void PopulateDynamicLinkItems(BarSubItem parent)
        {
            // Get all links for the LinkMenu context
            var qryLinks = DBUtil.OpenSQL(@"
                SELECT HYP.XHyperlinkID
                FROM dbo.XHyperlink                          HYP WITH(READUNCOMMITTED)
                  INNER JOIN dbo.XHyperlinkContext_Hyperlink HYH WITH(READUNCOMMITTED) ON HYH.XHyperlinkID = HYP.XHyperlinkID
                  INNER JOIN dbo.XHyperlinkContext           HYC WITH(READUNCOMMITTED) ON HYC.XHyperlinkContextID = HYH.XHyperlinkContextID
                WHERE HYC.Name = {0}
                ORDER BY HYH.SortKey;", XHYPERLINK_CONTEXT_LINKS);

            if (qryLinks.Count > 0)
            {
                do
                {
                    // Create the menu links
                    var item = new KissHyperlinkBarButtonItem(parent, (int)qryLinks[DBO.XHyperlink.XHyperlinkID]);
                    item.ImageIndex = KissImageList.GetImageIndex(XICON_LINK);
                }
                while (qryLinks.Next());
            }
        }

        #endregion

        #endregion
    }
}