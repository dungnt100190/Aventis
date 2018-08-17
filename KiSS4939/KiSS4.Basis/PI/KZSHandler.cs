using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KiSS4.DB;

namespace KiSS4.Basis.PI
{
    /// <summary>
    /// Helper class for KantonalerZuschuss of persons
    /// </summary>
    internal class KZSHandler
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "KZSHandler";

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Create new entry for KantonalerZuschuss
        /// </summary>
        /// <param name="baPersonID">The id of the person who gets the new entry</param>
        /// <param name="baKantonalerZuschussID">The id of the KantonalerZuschuss to assign to person</param>
        /// <returns><c>True</c> if entry was assigned successfully, otherwise <c>False</c></returns>
        public static bool Create(int baPersonID, int baKantonalerZuschussID)
        {
            // validate
            KZSHandler.ValidateBaPersonID(baPersonID);
            KZSHandler.ValidateBaKantonalerZuschussID(baKantonalerZuschussID);

            // do execute
            SqlQuery qryResult = DBUtil.OpenSQL(@"
                EXEC dbo.spBaKantonalerZuschuss_Create {0}, {1}, {2}", baPersonID, baKantonalerZuschussID, DBUtil.GetDBRowCreatorModifier());

            // show message if failure
            if (qryResult.Count != 1 || Convert.ToInt32(qryResult["Result"]) != 1)
            {
                // show message
                KissMsg.ShowError(CLASSNAME, "ErrorCreateNewKantZuschuss", "Es ist ein Fehler beim Hinzufügen des kantonalen Zuschusses aufgetreten (BaPersonID='{0}', BaKantonalerZuschussID='{1}').", null, null, 0, 0, baPersonID, baKantonalerZuschussID);

                // not successfully added
                return false;
            }

            // if we are here, everything should be ok
            return true;
        }

        /// <summary>
        /// Delete an assigned entry of KantonalerZuschuss
        /// </summary>
        /// <param name="baPersonID">The id of the person who has the entry assigned</param>
        /// <param name="baKantonalerZuschussID">The id of the KantonalerZuschuss to delete from person</param>
        /// <returns><c>True</c> if entry was deleted successfully, otherwise <c>False</c></returns>
        public static bool Delete(int baPersonID, int baKantonalerZuschussID)
        {
            // validate
            KZSHandler.ValidateBaPersonID(baPersonID);
            KZSHandler.ValidateBaKantonalerZuschussID(baKantonalerZuschussID);

            // do execute
            SqlQuery qryResult = DBUtil.OpenSQL(@"
                EXEC dbo.spBaKantonalerZuschuss_Delete {0}, {1}", baPersonID, baKantonalerZuschussID);

            // show message if failure
            if (qryResult.Count != 1 || Convert.ToInt32(qryResult["Result"]) != 1)
            {
                // show message
                KissMsg.ShowError(CLASSNAME, "ErrorDeletingExistingKantZuschuss", "Es ist ein Fehler beim Löschen des kantonalen Zuschusses aufgetreten (BaPersonID='{0}', BaKantonalerZuschussID='{1}').", null, null, 0, 0, baPersonID, baKantonalerZuschussID);

                // not successfully added
                return false;
            }

            // if we are here, everything should be ok
            return true;
        }

        /// <summary>
        /// Retrieve the assigned entries of the given person
        /// </summary>
        /// <param name="baPersonID">The id of the person to get assigned entries from</param>
        /// <returns>The query containing the assigend entries</returns>
        public static SqlQuery RetrieveAssigned(int baPersonID)
        {
            // validate
            KZSHandler.ValidateBaPersonID(baPersonID);

            // get and return data
            return DBUtil.OpenSQL(@"
                EXEC dbo.spBaKantonalerZuschuss_Retrieve 'assigned', {0}, NULL, {1}", baPersonID, Session.User.LanguageCode);
        }

        /// <summary>
        /// Retrieve the available entries of the given person
        /// </summary>
        /// <param name="baPersonID">The id of the person to get available entries from</param>
        /// <returns>The query containing the available entries</returns>
        public static SqlQuery RetrieveAvailable(int baPersonID)
        {
            // validate
            KZSHandler.ValidateBaPersonID(baPersonID);

            // get and return data
            return DBUtil.OpenSQL(@"
                EXEC dbo.spBaKantonalerZuschuss_Retrieve 'available', {0}, NULL, {1}", baPersonID, Session.User.LanguageCode);
        }

        public static bool Update(int baPersonID, int baKantonalerZuschussID)
        {
            // this method is not required at this time
            throw new NotImplementedException("The Update() method is not supported at this time.");
        }

        #endregion

        #region Private Static Methods

        private static void ValidateBaKantonalerZuschussID(int baKantonalerZuschussID)
        {
            // validate
            if (baKantonalerZuschussID < 1)
            {
                throw new ArgumentOutOfRangeException("baKantonalerZuschussID", "Invalid BaKantonalerZuschussID, cannot perform operation.");
            }
        }

        private static void ValidateBaPersonID(int baPersonID)
        {
            // validate
            if (baPersonID < 1)
            {
                throw new ArgumentOutOfRangeException("baPersonID", "Invalid BaPersonID, cannot perform operation.");
            }
        }

        #endregion

        #endregion
    }
}