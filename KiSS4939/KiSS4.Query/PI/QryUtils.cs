using System;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.PI
{
    public class QryUtils
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Get the membership orgunit id of given user
        /// </summary>
        /// <param name="userID">The user id used to get corresponding orgunit id</param>
        /// <returns>The membership orgunit id of given user</returns>
        public static int GetOrgUnitOfUser(int userID)
        {
            // TODO: this call should be done directly
            return Common.PI.BaUtils.GetOrgUnitOfUser(userID);
        }

        /// <summary>
        /// Check if user is chief or representative on any (orgunitid smaller 1) or on given orgunit (orgunitid smaller or equals 1)
        /// </summary>
        /// <param name="userID">The id of the user to check</param>
        /// <param name="orgUnitID">The id of the orgunit to check</param>
        /// <returns><c>True</c> if user is chief or representative, otherwise <c>False</c></returns>
        public static bool IsChiefOrRepresentative(int userID, int orgUnitID)
        {
            // validate
            if (userID < 1)
            {
                throw new ArgumentOutOfRangeException("userID", "No valid userid given, cannot proceed.");
            }

            // get flag if user is chief or representative
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQL(@"
                DECLARE @UserID INT
                DECLARE @OrgUnitID INT
                DECLARE @isChief INT

                SET @UserID = {0}
                SET @OrgUnitID = {1}

                -- check if user is admin (and therefore also chief)
                IF (dbo.fnIsUserAdmin(@UserID) = 1)
                BEGIN
                  -- user is admin
                  SET @isChief = 1
                END
                ELSE
                BEGIN
                  -- user is not admin
                  SELECT @isChief = ORG.OrgUnitID
                  FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                  WHERE (ORG.ChiefID = @UserID OR ORG.RepresentativeID = @UserID) AND
                        (@OrgUnitID < 1 OR ORG.OrgUnitID = @OrgUnitID)

                  SET @isChief = ISNULL(@isChief, 0)

                  IF(@isChief > 1)
                  BEGIN
                    SET @isChief = 1
                  END
                END

                SELECT ISNULL(@isChief, 0)", userID, orgUnitID));
        }

        public static void NewSearchMitarbeiter(Boolean specialRightKostenstelleHS, Boolean specialRightKostenstelleKGS, Boolean isChiefOrRepresentative, KissLookUpEdit edtSucheMitarbeiter)
        {
            // validate first
            if (edtSucheMitarbeiter == null)
            {
                // error
                throw new ArgumentNullException("edtSucheMitarbeiter", "The given control is empty, cannot proceed.");
            }

            // apply rights and default search parameters
            if (!specialRightKostenstelleHS && !specialRightKostenstelleKGS)
            {
                // user has no special rights, setup depending on representative-state
                edtSucheMitarbeiter.EditMode = isChiefOrRepresentative ? EditModeType.Normal : EditModeType.ReadOnly;
                edtSucheMitarbeiter.EditValue = isChiefOrRepresentative ? null : (Object)Session.User.UserID;
            }
            else
            {
                // kgs-user, no restrictions to user-field
                edtSucheMitarbeiter.EditMode = EditModeType.Normal;
                edtSucheMitarbeiter.EditValue = null;
            }
        }

        public static void RunSearchValidateKstMa(Boolean specialRightKostenstelleHS, Boolean specialRightKostenstelleKGS, KissLookUpEdit edtSucheKostenstelle, KissLookUpEdit edtSucheMitarbeiter)
        {
            // validate first
            if (edtSucheKostenstelle == null)
            {
                // error
                throw new ArgumentNullException("edtSucheKostenstelle", "The given control is empty, cannot proceed.");
            }

            if (edtSucheMitarbeiter == null)
            {
                // error
                throw new ArgumentNullException("edtSucheMitarbeiter", "The given control is empty, cannot proceed.");
            }

            // move focus to apply possible datetime
            edtSucheMitarbeiter.Focus();

            // check required fields
            if (!specialRightKostenstelleHS && !specialRightKostenstelleKGS && DBUtil.IsEmpty(edtSucheKostenstelle.EditValue))
            {
                // Kostenstelle is required
                KissMsg.ShowInfo("QryUtils", "RequiredSearchKostenstelle", "Das Feld 'Kostenstelle' wird für die Suche benötigt!");
                edtSucheKostenstelle.Focus();

                // cancel runsearch
                throw new KissCancelException();
            }

            // check EditMode on user
            if (edtSucheMitarbeiter.EditMode == EditModeType.ReadOnly)
            {
                // value is required
                if (DBUtil.IsEmpty(edtSucheMitarbeiter.EditValue))
                {
                    // user is required
                    KissMsg.ShowInfo("QryUtils", "RequiredSearchMitarbeiter", "Das Feld 'Mitarbeiter' wird für die Suche benötigt!");
                    edtSucheMitarbeiter.Focus();

                    // cancel runsearch
                    throw new KissCancelException();
                }

                // value must be equal to current user
                if (Convert.ToInt32(edtSucheMitarbeiter.EditValue) != Session.User.UserID)
                {
                    // current user is required
                    KissMsg.ShowInfo("QryUtils", "NotEqualSearchMitarbeiter", "Das Feld 'Mitarbeiter' entspricht nicht dem angemeldeten Mitarbeiter!");
                    edtSucheMitarbeiter.Focus();

                    // cancel runsearch
                    throw new KissCancelException();
                }
            }
        }

        #endregion

        #endregion
    }
}