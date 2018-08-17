using System;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Helper class used for setting case information title including image and tooltip
    /// </summary>
    public class PersonInfoTitel
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string QRY_IMAGE_INDEX = "ImageIndex";
        private const string QRY_TITLE_TEXT = "TitleText";
        private const string QRY_TOOL_TIP_TEXT = "ToolTipText";

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Gets the title text for the specified person.
        /// </summary>
        /// <param name="baPersonId"></param>
        /// <returns></returns>
        public static string GetPersonInfoTitelText(int baPersonId)
        {
            var qry = GetPersonInfoTitelQuery(baPersonId);
            return qry[QRY_TITLE_TEXT].ToString();
        }

        /// <summary>
        /// Reset person information to label, picturebox and tooltip on picturebox
        /// </summary>
        /// <param name="lbl">The label containing the person information text</param>
        /// <param name="pic">The picture showing specific person state</param>
        /// <param name="ttp">The tooltip to show on the given picture</param>
        /// <exception cref="ArgumentNullException">Exception is thrown if one paramter has no valid instance</exception>
        public static void ResetPersonInfoTitel(Label lbl, PictureBox pic, ToolTip ttp)
        {
            // validate
            ValidateParameter(lbl, pic, ttp);

            // reset controls
            lbl.Text = "-";
            pic.Image = KissImageList.GetLargeImage(0);
            ttp.SetToolTip(pic, "");
        }

        /// <summary>
        /// Apply person information to label, picturebox and tooltip on picturebox
        /// </summary>
        /// <param name="lbl">The label containing the person information text</param>
        /// <param name="pic">The picture showing specific person state</param>
        /// <param name="ttp">The tooltip to show on the given picture</param>
        /// <param name="baPersonId">The id of the person used for getting person information</param>
        /// <exception cref="ArgumentNullException">Exception is thrown if one paramter has no valid instance</exception>
        public static void SetPersonInfoTitel(Label lbl, PictureBox pic, ToolTip ttp, int baPersonId)
        {
            // validate
            ValidateParameter(lbl, pic, ttp);

            // depending on value, we set information
            if (baPersonId < 1)
            {
                // reset information content
                ResetPersonInfoTitel(lbl, pic, ttp);
            }
            else
            {
                var qry = GetPersonInfoTitelQuery(baPersonId);

                // validate
                if (qry.IsEmpty)
                {
                    // reset information content
                    ResetPersonInfoTitel(lbl, pic, ttp);
                }
                else
                {
                    // apply values to controls
                    lbl.Text = Convert.ToString(qry[QRY_TITLE_TEXT]);
                    pic.Image = KissImageList.GetMediumImage(Convert.ToInt32(qry[QRY_IMAGE_INDEX]));
                    ttp.SetToolTip(pic, Convert.ToString(qry[QRY_TOOL_TIP_TEXT]));
                }
            }
        }

        #endregion

        #region Private Static Methods

        private static SqlQuery GetPersonInfoTitelQuery(int baPersonId)
        {
            // read data from database
            return DBUtil.OpenSQL(@"
                EXEC dbo.spBaGetPersonInfoTitel {0}, {1}, {2};", baPersonId, Session.User.UserID, Session.User.LanguageCode);
        }

        /// <summary>
        /// Validate label, picturebox and tooltip instances.
        /// </summary>
        /// <param name="lbl">The label containing the person information text</param>
        /// <param name="pic">The picture showing specific person state</param>
        /// <param name="ttp">The tooltip to show on the given picture</param>
        /// <exception cref="ArgumentNullException">Exception is thrown if one paramter has no valid instance</exception>
        private static void ValidateParameter(Label lbl, PictureBox pic, ToolTip ttp)
        {
            // validate parameters
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
        }

        #endregion

        #endregion
    }
}