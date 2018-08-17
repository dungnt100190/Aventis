using System;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Class for helper functionality of BDE module
    /// </summary>
    public class BDEUtils
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Initialize dropdown used for selecting Kostenstelle where given user has rights to show
        /// </summary>
        /// <param name="userID">The id of the user who wants to use dropdown</param>
        /// <param name="specialRightHauptsitz"><c>True</c> if user has special right to show items as head office, otherwise <c>False</c></param>
        /// <param name="specialRightKGS"><c>True</c> if user has special right to show items as cantons orgunit, otherwise <c>False</c></param>
        /// <param name="lookUpEdit">The instance of the dropdown lookupedit control</param>
        public static void InitKostenstelleDropDown(int userID, bool specialRightHauptsitz, bool specialRightKGS, KissLookUpEdit lookUpEdit)
        {
            // validate
            if (userID < 1)
            {
                throw new ArgumentOutOfRangeException("userID", "No valid userid given, cannot proceed.");
            }

            if (lookUpEdit == null)
            {
                // error
                throw new ArgumentNullException("lookUpEdit", "The given control is empty, cannot proceed.");
            }

            // init query and load data
            SqlQuery qryKostenstelle = DBUtil.OpenSQL(@"
                SELECT [Code],
                       [Text],
                       [Kostenstelle$]
                FROM dbo.fnQryGetKostenstelleDropDown({0}, {1}, {2})", userID, specialRightHauptsitz, specialRightKGS);

            // setup lookupedit
            lookUpEdit.Properties.DropDownRows = Math.Min(qryKostenstelle.Count, 14);
            lookUpEdit.Properties.DataSource = qryKostenstelle;
        }

        /// <summary>
        /// Initialize dropdown used for selecting users where given user has rights to show
        /// </summary>
        /// <param name="userID">The id of the user who wants to use dropdown</param>
        /// <param name="specialRightHauptsitz"><c>True</c> if user has special right to show items as head office, otherwise <c>False</c></param>
        /// <param name="specialRightKGS"><c>True</c> if user has special right to show items as cantons orgunit, otherwise <c>False</c></param>
        /// <param name="allowNull"><c>True</c> if an empty entry has to be added, otherwise <c>False</c></param>
        /// <param name="lookUpEdit">The instance of the dropdown lookupedit control</param>
        public static void InitMitarbeiterDropDown(int userID, bool specialRightHauptsitz, bool specialRightKGS, bool allowNull, KissLookUpEdit lookUpEdit)
        {
            // validate
            if (userID < 1)
            {
                throw new ArgumentOutOfRangeException("userID", "No valid userid given, cannot proceed.");
            }

            if (lookUpEdit == null)
            {
                // error
                throw new ArgumentNullException("lookUpEdit", "The given control is empty, cannot proceed.");
            }

            // init query and load data
            SqlQuery qryUsers = DBUtil.OpenSQL(@"
                SELECT [Code],
                       [Text]
                FROM dbo.fnQryGetMitarbeiterDropDown({0}, {1}, {2}, {3})", userID, specialRightHauptsitz, specialRightKGS, allowNull);

            // setup lookupedit
            lookUpEdit.Properties.DropDownRows = Math.Min(qryUsers.Count, 14);
            lookUpEdit.Properties.DataSource = qryUsers;
        }

        #endregion

        #endregion
    }
}