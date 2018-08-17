using System;

using KiSS4.DB;
using KiSS4.Favoriten.Interface;
using KiSS4.Favoriten.Model;

namespace KiSS4.Favoriten.BL
{
    internal class FavoriteQuery
    {
        #region Methods

        #region Internal Static Methods

        /// <summary>
        /// Get class usertext for current classname
        /// </summary>
        /// <param name="className">The classname to use for getting the class usertext</param>
        internal static string GetClassUserText(string className)
        {
            return Convert.ToString(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT ISNULL(dbo.fnXGetClassUserText({0}, {1}), '')", className, Session.User.LanguageCode));
        }

        #endregion

        #region Internal Methods

        internal IResult DeleteExistingFavoriteControls(Favorite favorite)
        {
            IResult result = new Result();

            try
            {
                if (favorite.FavoriteControls != null && favorite.FavoriteControls.Count > 0)
                {
                    string s = @"
                        DELETE FROM dbo.XSearchControlTemplateField
                        WHERE XSearchControlTemplateID = {0}";

                    DBUtil.ExecuteScalarSQLThrowingException(s, favorite.XSearchControlTemplateId);
                    result.WasOperationSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        internal IResult DeleteFavorite(Favorite favorite)
        {
            IResult result = new Result();

            try
            {
                if (favorite.FavoriteControls != null && favorite.FavoriteControls.Count > 0)
                {
                    string s = @"
                        DELETE FROM dbo.XSearchControlTemplateField
                        WHERE XSearchControlTemplateID = {0}";

                    DBUtil.ExecuteScalarSQLThrowingException(s, favorite.XSearchControlTemplateId);
                }

                string sb = @"
                    DELETE FROM dbo.XSearchControlTemplate
                    WHERE XSearchControlTemplateID = {0}";

                DBUtil.ExecuteScalarSQLThrowingException(sb, favorite.XSearchControlTemplateId);
                result.WasOperationSuccessful = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Get all favorites for current user
        /// </summary>
        /// <returns>All favorites for current user</returns>
        internal IResultComplex<SqlQuery> GetAllFavorites()
        {
            IResultComplex<SqlQuery> result = new ResultComplex<SqlQuery>();

            try
            {
                SqlQuery qryFavorites = GetFavoritesFromDatabase(null);

                result.WasOperationSuccessful = true;
                result.Data = qryFavorites;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Get all favorites for current user and class
        /// </summary>
        /// <param name="className">The classname used for filtering</param>
        /// <returns>All favorites for current user and given class</returns>
        internal IResultComplex<SqlQuery> GetFavoritesForClass(string className)
        {
            IResultComplex<SqlQuery> result = new ResultComplex<SqlQuery>();

            try
            {
                SqlQuery qryFavorites = GetFavoritesFromDatabase(className);

                result.WasOperationSuccessful = true;
                result.Data = qryFavorites;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        internal IResult SaveFavorite(int xSearchControlTemplateId, string className, int? moduleTreeId, string name, int? parentXSearchControlTemplateId, int sortKey, string colLayout, bool searchImmediately)
        {
            IResult result = new Result();

            try
            {
                string sb = @"UPDATE dbo.XSearchControlTemplate
                              SET [ClassName] = {1},
                                  [ModulTreeID] = {2},
                                  [Name] = {3},
                                  [ParentXSearchControlTemplateID] = {4},
                                  [SortKey] = {5},
                                  [ColLayout] = {6},
                                  [SearchImmediately] = {7}
                              WHERE XSearchControlTemplateID = {0}";

                DBUtil.ExecuteScalarSQLThrowingException(sb, xSearchControlTemplateId, className, moduleTreeId, name, parentXSearchControlTemplateId, sortKey, colLayout, searchImmediately);
                result.WasOperationSuccessful = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        internal IResult SaveFavoriteControl(int xSearchControlTemplateId, FavoriteControl favoriteControl)
        {
            IResult result = new Result();

            try
            {
                string sb = @"INSERT INTO dbo.XSearchControlTemplateField
                              ([ControlName],
                               [ControlType],
                               [Value],
                               [XSearchControlTemplateID])
                              VALUES ({0}, {1}, {2}, {3})";

                DBUtil.ExecuteScalarSQLThrowingException(sb, favoriteControl.Name, favoriteControl.Type, favoriteControl.Value, xSearchControlTemplateId);
                result.WasOperationSuccessful = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        internal IResult SaveNewFavorite(Favorite favorite, int userId)
        {
            IResult result = new Result();

            try
            {
                string sb = @"INSERT INTO dbo.XSearchControlTemplate
                              ([ClassName],
                               [UserID],
                               [ModulTreeID],
                               [Name],
                               [ParentXSearchControlTemplateID],
                               [SortKey],
                               [ColLayout],
                               [SearchImmediately])
                              VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})";

                DBUtil.ExecuteScalarSQLThrowingException(sb, favorite.ClassName, userId, favorite.ModulTreeId, favorite.Name, favorite.ParentXSearchControlTemplateId, favorite.SortKey, favorite.ColLayout, favorite.SearchImmediately);
                result.WasOperationSuccessful = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        internal IResult SaveNewFavoriteControl(Favorite favorite, FavoriteControl favoriteControl)
        {
            IResult result = new Result();

            try
            {
                string sb = @"DECLARE @xSearchControlTemplateID int

                              SELECT @xSearchControlTemplateID = XSearchControlTemplateID
                                                                 FROM XSearchControlTemplate
                                                                 WHERE SortKey = {0}
                                                                   AND ClassName = {1}
                                                                   AND Name = {2}

                              INSERT INTO dbo.XSearchControlTemplateField
                              ([ControlName],
                               [ControlType],
                               [Value],
                               [XSearchControlTemplateID])
                              VALUES ({3}, {4}, {5}, @xSearchControlTemplateID)";

                DBUtil.ExecuteScalarSQLThrowingException(sb, favorite.SortKey, favorite.ClassName, favorite.Name, favoriteControl.Name, favoriteControl.Type, favoriteControl.Value);
                result.WasOperationSuccessful = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the favorites from database
        /// </summary>
        /// <param name="className">If classname is set, only the favorites for given classname will be returned, otherwise all favorites</param>
        /// <returns>The favorites for current user and language depending on given classname</returns>
        private SqlQuery GetFavoritesFromDatabase(string className)
        {
            // TODO: do proper sorting depending on SortKey as soon as ordering in form does work
            return DBUtil.OpenSQL(@"
                    DECLARE @UserID INT;
                    DECLARE @LanguageCode INT;
                    DECLARE @ClassName VARCHAR(255);

                    SET @UserID = {0};
                    SET @LanguageCode = {1};
                    SET @ClassName = {2};

                    SELECT IsClass                        = 0,
                           XSearchControlTemplateID       = SCT.XSearchControlTemplateID * -1,
                           ParentXSearchControlTemplateID = SCT.ParentXSearchControlTemplateID,
                           Caption                        = SCT.Name,
                           SortKey                        = SCT.SortKey,
                           ClassName                      = SCT.ClassName,
                           ClassUserText                  = SCT.ClassName,
                           ColLayout                      = SCT.ColLayout,
                           SearchImmediately              = SCT.SearchImmediately,
                           ControlName                    = SCF.ControlName,
                           ControlType                    = SCF.ControlType,
                           Value                          = SCF.Value
                    FROM dbo.XSearchControlTemplate             SCT WITH (READUNCOMMITTED)
                     INNER JOIN dbo.XSearchControlTemplateField SCF WITH (READUNCOMMITTED) ON SCF.XSearchControlTemplateID = SCT.XSearchControlTemplateID
                    WHERE SCT.UserID = @UserID
                      AND (@ClassName IS NULL OR SCT.ClassName = @ClassName)

                    UNION

                    SELECT IsClass                        = 1,
                           XSearchControlTemplateID       = SCT.XSearchControlTemplateID,
                           ParentXSearchControlTemplateID = SCT.ParentXSearchControlTemplateID,
                           Caption                        = SCT.Name,
                           SortKey                        = SCT.SortKey,
                           ClassName                      = SCT.ClassName,
                           ClassUserText                  = ISNULL(dbo.fnXGetClassUserText(SCT.ClassName, @LanguageCode), SCT.ClassName),
                           ColLayout                      = SCT.ColLayout,
                           SearchImmediately              = SCT.SearchImmediately,
                           ControlName                    = NULL,
                           ControlType                    = NULL,
                           Value                          = NULL
                    FROM dbo.XSearchControlTemplate SCT WITH (READUNCOMMITTED)
                    WHERE SCT.UserID = @UserID
                      AND (@ClassName IS NULL OR SCT.ClassName = @ClassName)

                    ORDER BY IsClass DESC,
                             ClassUserText,
                             SortKey,
                             XSearchControlTemplateID DESC;", Session.User.UserID, Session.User.LanguageCode, className);
        }

        #endregion

        #endregion
    }
}