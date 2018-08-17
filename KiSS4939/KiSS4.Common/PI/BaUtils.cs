using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Helper class for basic features
    /// </summary>
    public class BaUtils
    {
        #region Enumerations

        /// <summary>
        /// Enumeration of all processes used for Pro Infirmis
        /// </summary>
        public enum ModulID
        {
            /// <summary>
            /// Person (Basis): 1
            /// </summary>
            Person = 1,

            /// <summary>
            /// FV: Fallverlauf (Fallführung): 2
            /// </summary>
            Fallverlauf = 2,

            /// <summary>
            /// SB: Sozialberatung: 3
            /// </summary>
            SozialBeratung = 3,

            /// <summary>
            /// CM: Case Management: 4
            /// </summary>
            CaseManagement = 4,

            /// <summary>
            /// BW: Begleitetes Wohnen: 5
            /// </summary>
            BegleitetesWohnen = 5,

            /// <summary>
            /// ED: Entlastungsdienst: 6
            /// </summary>
            EntlastungsDienst = 6,

            /// <summary>
            /// IN: Intake: 7
            /// </summary>
            Intake = 7,

            /// <summary>
            /// AB: Assistenzberatung: 8
            /// </summary>
            Assistenzberatung = 8,

            /// <summary>
            /// WDL: Weitere Dienstleistungen: 31
            /// </summary>
            WeitereDL = 31,
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Apply LOV settings to given control
        /// </summary>
        /// <param name="edt">The <see cref="KissLookUpEdit"/> control where settings have to be applied to</param>
        public static void ApplyLOVBaLand(KissLookUpEdit edt)
        {
            // validate
            if (edt == null)
            {
                throw new ArgumentNullException("edt", "The KissLookUpEdit is required and cannot be null.");
            }

            // apply settings
            edt.LOVName = "BaLand";
        }

        /// <summary>
        /// Get the membership orgunit id of given user
        /// </summary>
        /// <param name="userID">The user id used to get corresponding orgunit id</param>
        /// <returns>The membership orgunit id of given user</returns>
        public static int GetOrgUnitOfUser(int userID)
        {
            // validate
            if (userID < 1)
            {
                throw new ArgumentOutOfRangeException("userID", "No valid userid given, cannot proceed.");
            }

            // get current orgunitid from database
            return Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT CONVERT(INT, ISNULL(dbo.fnOrgUnitOfUser({0}, 1), -1))", userID));
        }

        /// <summary>
        /// Validate birthday date to ensure it is correct for given special PI rules
        /// </summary>
        /// <param name="birthdayDate">The bithday date to validate</param>
        /// <returns>True if date is correct, otherwise false</returns>
        public static Boolean IsBirthdayDateValid(DateTime birthdayDate)
        {
            try
            {
                // get current config value
                DateTime compareDate = DBUtil.GetConfigDateTime(@"System\Basis\MinimalesGeburtsdatum", DateTime.MinValue);

                // compare values
                if (compareDate > birthdayDate)
                {
                    // show info
                    KissMsg.ShowInfo("BaUtils", "BirthdayDateOutOfRange", "Das Geburtsdatum darf nicht kleiner als das Datum '{0}' sein.", 0, 0, compareDate.ToString("dd.MM.yyyy"));

                    // invalid date
                    return false;
                }

                // if we are here, date is valid
                return true;
            }
            catch (Exception ex)
            {
                // show message
                KissMsg.ShowError("BaUtils", "ErrorCheckIsBirthdayDateValid", "Es ist ein Fehler beim Prüfen des Geburtsdatums aufgetreten.", ex);

                // invalid
                return false;
            }
        }

        /// <summary>
        /// Convert the given ModulID enum to it's corresponding code
        /// </summary>
        /// <param name="modulID">The modulID to get code from</param>
        /// <returns>The code from the given modulID</returns>
        public static int ModulIDCode(ModulID modulID)
        {
            // get code instead of text
            return Convert.ToInt32(modulID);
        }

        /// <summary>
        /// Setup the color for a required field, depdinding on current state and update possiblities
        /// </summary>
        /// <param name="editField">The DevExpress.XtraEditors.BaseEdit edit field to handle</param>
        /// <param name="canUpdate">Flag if user can update the value of this control</param>
        public static void SetupColorOfRequiredFields(DevExpress.XtraEditors.BaseEdit editField, Boolean canUpdate)
        {
            // by default, do not ignore readonly-value
            BaUtils.SetupColorOfRequiredFields(editField, canUpdate, false);
        }

        /// <summary>
        /// Setup the color for a required field, depdinding on current state and update possiblities
        /// </summary>
        /// <param name="editField">The DevExpress.XtraEditors.BaseEdit edit field to handle</param>
        /// <param name="canUpdate">Flag if user can update the value of this control</param>
        /// <param name="ignoreReadOnly">Flag if ReadOnly value is ignored for color decision</param>
        public static void SetupColorOfRequiredFields(DevExpress.XtraEditors.BaseEdit editField, Boolean canUpdate, Boolean ignoreReadOnly)
        {
            // get calculated color (required or readonly)
            Color clrBackColor = BaUtils.GetColorOfRequiredFieldByMode(canUpdate, editField.Properties.ReadOnly, false, ignoreReadOnly);

            // check type of control
            if (editField is KissCheckEdit)
            {
                // checkedit
                ((KissCheckEdit)editField).CenterSquareColor = clrBackColor;

                // do refresh
                editField.Refresh();
            }
            else
            {
                // other baseedit
                editField.Properties.Style.BackColor = clrBackColor;
            }
        }

        /// <summary>
        /// Setup the color for a required field, depdinding on current state and update possiblities
        /// </summary>
        /// <param name="editField">The KissCheckedLookupEdit edit field to handle</param>
        /// <param name="canUpdate">Flag if user can update the value of this control</param>
        public static void SetupColorOfRequiredFields(KissCheckedLookupEdit editField, Boolean canUpdate)
        {
            // by default, do not ignore readonly-value
            BaUtils.SetupColorOfRequiredFields(editField, canUpdate, false);
        }

        /// <summary>
        /// Setup the color for a required field, depdinding on current state and update possiblities
        /// </summary>
        /// <param name="editField">The KissCheckedLookupEdit edit field to handle</param>
        /// <param name="canUpdate">Flag if user can update the value of this control</param>
        /// <param name="ignoreReadOnly">Flag if ReadOnly value is ignored for color decision</param>
        public static void SetupColorOfRequiredFields(KissCheckedLookupEdit editField, Boolean canUpdate, Boolean ignoreReadOnly)
        {
            // set calculated color (required or readonly)
            editField.Appearance.BackColor = BaUtils.GetColorOfRequiredFieldByMode(canUpdate, editField.Enabled, true, ignoreReadOnly);
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Get the color for a required field, depdinding on current state and update possiblities
        /// </summary>
        /// <param name="canUpdate">Flag if user can update the value of this control</param>
        /// <param name="isReadOnly">Flag if control is in readonly state</param>
        /// <param name="isCheckedLookupEdit">Flag if color is for a KissCheckedLookupEdit control</param>
        /// <param name="ignoreReadOnly">Flag if ReadOnly value is ignored for color decision</param>
        /// <returns>The calculated color depending on given parameters</returns>
        private static Color GetColorOfRequiredFieldByMode(Boolean canUpdate, Boolean isReadOnly, Boolean isCheckedLookupEdit, Boolean ignoreReadOnly)
        {
            // checked-lookup-edits use different readonly-color than others
            Color clrReadOnly = isCheckedLookupEdit ? Color.FromArgb(244, 240, 230) : GuiConfig.EditColorReadOnly;
            Color clrRequired = BaUtils.GetRequiredFieldColor();

            // check if CanUpdate=false (from query)
            if (!canUpdate)
            {
                // locked by query, always readonly
                return clrReadOnly;
            }

            // check if readonly and do not ignore readonly
            if (isReadOnly && !ignoreReadOnly)
            {
                // is readonly and do handle readonly
                return clrReadOnly;
            }

            // query.CanUpdate=true and (control is editable or readonly is ignored)
            return clrRequired;
        }

        /// <summary>
        /// Get the color of a required field
        /// </summary>
        /// <returns></returns>
        private static Color GetRequiredFieldColor()
        {
            return GuiConfig.EditColorRequired;    // some light yellow...
        }

        #endregion

        #endregion
    }
}