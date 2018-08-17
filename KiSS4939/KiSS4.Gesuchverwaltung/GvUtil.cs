using System;

using Kiss.Infrastructure.Constant;

using KiSS4.DB;

namespace KiSS4.Gesuchverwaltung
{
    public class GvUtil
    {
        #region Methods

        #region Public Static Methods

        public static void InsertGvBewilligung(int gvGesuchId, LOVsGenerated.GvBewilligung gvBewilligungCode)
        {
            var creator = DBUtil.GetDBRowCreatorModifier();
            var created = DateTime.Now;

            DBUtil.ExecSQL(@"
                INSERT INTO dbo.GvBewilligung (GvGesuchID, UserID, GvBewilligungCode, Creator, Created, Modifier, Modified)
                VALUES ({0}, {1}, {2}, {3}, {4}, {3}, {4});",
                gvGesuchId,
                Session.User.UserID,
                gvBewilligungCode,
                creator,
                created);
        }

        public static void UpdateGvGesuchStatus(int gvGesuchId, LOVsGenerated.GvStatus gvStatusCode)
        {
            var modifier = DBUtil.GetDBRowCreatorModifier();
            var modified = DateTime.Now;

            DBUtil.ExecSQL(@"
                UPDATE dbo.GvGesuch
                SET GvStatusCode = {1},
                    Modifier     = {2},
                    Modified     = {3}
                WHERE GvGesuchID = {0};",
                gvGesuchId,
                gvStatusCode,
                modifier,
                modified);
        }

        #endregion

        #endregion
    }
}