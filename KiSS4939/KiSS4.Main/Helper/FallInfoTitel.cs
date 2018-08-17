using System;
using System.Text;
using System.Windows.Forms;

using KiSS4.DB;

namespace KiSS4.Main.Helper
{
    /// <summary>
    /// Helper class used for setting case information title including image and tooltip
    /// </summary>
    internal class FallInfoTitel
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Apply case information to label, picturebox and tooltip on picturebox
        /// </summary>
        /// <param name="lbl">The label containing the case information text</param>
        /// <param name="pic">The picture showing specific case state</param>
        /// <param name="ttp">The tooltip to show on the given picture</param>
        /// <param name="baPersonID">The id of the person used for getting case information</param>
        public static void SetFallInfoTitel(Label lbl, PictureBox pic, ToolTip ttp, int baPersonID)
        {
            // validate
            if (lbl == null)
            {
                throw new ArgumentNullException("lbl", "The label for case information text is empty, cannot appyl data.");
            }

            if (pic == null)
            {
                throw new ArgumentNullException("pic", "The picturebox for case information image is empty, cannot appyl data.");
            }

            if (ttp == null)
            {
                throw new ArgumentNullException("ttp", "The tooltip for case information tip is empty, cannot appyl data.");
            }

            // depending on value, we set information
            if (baPersonID < 1)
            {
                // reset information content
                lbl.Text = "-";
                pic.Image = KiSS4.Gui.KissImageList.GetLargeImage(0);
                ttp.SetToolTip(pic, "");
            }
            else
            {
                // read data from database
                SqlQuery qry = DBUtil.OpenSQL(@"
                    EXEC dbo.spFaGetFallInfoTitel {0}, {1}", baPersonID, Session.User.LanguageCode);
            }
        }

        #endregion

        #endregion
    }
}