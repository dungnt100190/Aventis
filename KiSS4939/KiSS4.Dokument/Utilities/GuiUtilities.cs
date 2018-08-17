using System;
using System.Linq;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraEditors;

namespace KiSS4.Dokument.Utilities
{
    #region Enumerations

    /// <summary>
    /// Profile codes as used in table XProfile.XProfileTypeCode
    /// </summary>
    public enum XProfileType
    {
        /// <summary>
        /// Profile of User or OrgUnit (=1)
        /// </summary>
        UserOrOrgUnitProfile = 1,

        /// <summary>
        /// Profile of document template (=2)
        /// </summary>
        TemplateProfile = 2
    }

    #endregion

    /// <summary>
    /// Class contains common used helper methods for document handling
    /// </summary>
    public class GuiUtilities
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Get SqlQuery used to fill dropdown for selecting available userprofiles (XProfile)
        /// </summary>
        /// <returns>The SqlQuery containing the desired profiles including empty row</returns>
        public static SqlQuery GetSqlQueryXProfilesUserOrOrgUnit()
        {
            return GetSqlQueryXProfiles(XProfileType.UserOrOrgUnitProfile);
        }

        /// <summary>
        /// Get SqlQuery used to fill dropdown for selecting available userprofiles (XProfile)
        /// </summary>
        /// <param name="xProfileType">The XProfileType type to use for getting data</param>
        /// <returns>The SqlQuery containing the desired profiles including empty row</returns>
        public static SqlQuery GetSqlQueryXProfiles(XProfileType xProfileType)
        {
            return DBUtil.OpenSQL(@"
                SELECT [Code] = -1,
                       [Text] = ''

                UNION ALL

                SELECT [Code] = PRF.XProfileID,
                       [Text] = dbo.fnGetMLTextByDefault(PRF.NameTID, {0}, PRF.Name)
                FROM dbo.XProfile PRF WITH (READUNCOMMITTED)
                WHERE PRF.XProfileTypeCode = {1}
                ORDER BY [Text];", Session.User.LanguageCode, Convert.ToInt32(xProfileType));
        }

        /// <summary>
        /// Spezialfall DokuSperre:
        /// Falls es ein Control mit AppCode [DokuSperre] und nicht leerem Inhalt gibt:
        /// Alle XDokument-Controls auf ReadOnly setzen und das Control selbst auch
        /// ausser: bei admin
        /// </summary>
        /// <param name="canUpdate">
        /// <c>True</c> if user is allowed to modify data, otherwise <c>False</c>.
        /// In case of <c>False</c>, the method won't change anything.
        /// </param>
        /// <param name="userControl">The user control containing the controls to enable/disable</param>
        /// <param name="editControl">The edit control to validate for value</param>
        /// <param name="isEmpty">Flag, if the control/datasource has a value in the desired field</param>
        public static void HandleDokuSperre(bool canUpdate, Control userControl, BaseEdit editControl, bool isEmpty)
        {
            if (!canUpdate)
            {
                // if user cannot update data, we expect this to be handled on main user control -> do nothting here
                return;
            }

            // init vars
            var isAdmin = Session.User.IsUserAdmin;
            var editMode = EditModeType.Normal;

            if (!isEmpty && !isAdmin)
            {
                editMode = EditModeType.ReadOnly;
            }

            // handle all document controls
            foreach (var ctl in UtilsGui.AllControls(userControl).OfType<XDokument>())
            {
                ctl.EditMode = editMode;
            }

            // handle editControl
            if (editControl is IKissEditable)
            {
                ((IKissEditable)editControl).EditMode = editMode;
            }
        }

        #endregion

        #endregion
    }
}
