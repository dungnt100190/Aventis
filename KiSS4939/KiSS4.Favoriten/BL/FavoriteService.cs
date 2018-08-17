using System;
using System.Collections.Generic;
using System.Data;

using KiSS4.DB;
using KiSS4.Favoriten.BusinessRules;
using KiSS4.Favoriten.Interface;
using KiSS4.Favoriten.Model;

namespace KiSS4.Favoriten.BL
{
    public class FavoriteService
    {
        #region Methods

        #region Internal Static Methods

        /// <summary>
        /// Get class usertext for current classname
        /// </summary>
        /// <param name="className">The classname to use for getting the class usertext</param>
        internal static string GetClassUserText(string className)
        {
            // get class usertext from query class
            return FavoriteQuery.GetClassUserText(className);
        }

        #endregion

        #region Internal Methods

        internal IResult DeleteFavorite(Favorite favorite)
        {
            FavoriteQuery query = new FavoriteQuery();
            return query.DeleteFavorite(favorite);
        }

        internal IDictionary<int, Favorite> GetAllFavorites()
        {
            FavoriteQuery query = new FavoriteQuery();
            IResultComplex<SqlQuery> q = query.GetAllFavorites();
            IDictionary<int, Favorite> favorites = CreateFavorites(q.Data);

            return favorites;
        }

        internal IDictionary<int, Favorite> GetFavoritesForClass(string className)
        {
            FavoriteQuery query = new FavoriteQuery();
            IResultComplex<SqlQuery> q = query.GetFavoritesForClass(className);
            IDictionary<int, Favorite> favorites = CreateFavorites(q.Data);

            return favorites;
        }

        internal IResult SaveExistingFavorite(Favorite favorite)
        {
            FavoriteValidator validator = new FavoriteValidator();
            IResult result = validator.ValidateFields(favorite);

            if (result.WasOperationSuccessful)
            {

                FavoriteQuery query = new FavoriteQuery();
                result = query.SaveFavorite(favorite.XSearchControlTemplateId, favorite.ClassName, favorite.ModulTreeId, favorite.Name, favorite.ParentXSearchControlTemplateId, favorite.SortKey, favorite.ColLayout, favorite.SearchImmediately);

                if (result.WasOperationSuccessful)
                {
                    result = query.DeleteExistingFavoriteControls(favorite);

                    if (result.WasOperationSuccessful)
                    {
                        foreach (FavoriteControl favoriteControl in favorite.FavoriteControls)
                        {
                            result = query.SaveFavoriteControl(favorite.XSearchControlTemplateId, favoriteControl);

                            if (result.WasOperationSuccessful == false)
                            {
                                return result;
                            }
                        }
                    }
                }

                return result;
            }

            return result;
        }

        internal IResult SaveFavorite(Favorite favorite, int userId)
        {
            FavoriteValidator validator = new FavoriteValidator();
            IResult result = validator.ValidateFields(favorite);

            if (result.WasOperationSuccessful)
            {
                FavoriteQuery query = new FavoriteQuery();

                if (favorite.XSearchControlTemplateId < 0)
                {
                    result = query.SaveNewFavorite(favorite, userId);

                    if (result.WasOperationSuccessful)
                    {
                        foreach (FavoriteControl favoriteControl in favorite.FavoriteControls)
                        {
                            result = query.SaveNewFavoriteControl(favorite, favoriteControl);

                            if (result.WasOperationSuccessful == false)
                            {
                                return result;
                            }
                        }
                    }
                    else
                    {
                        return result;
                    }
                }

                result = query.SaveFavorite(favorite.XSearchControlTemplateId, favorite.ClassName, favorite.ModulTreeId, favorite.Name, favorite.ParentXSearchControlTemplateId, favorite.SortKey, favorite.ColLayout, favorite.SearchImmediately);
                return result;
            }

            return result;
        }

        #endregion

        #region Private Methods

        private IDictionary<int, Favorite> CreateFavorites(SqlQuery qry)
        {
            IDictionary<int, Favorite> favorites = new Dictionary<int, Favorite>();
            Favorite favorite;

            foreach (DataRow row in qry.DataTable.Rows)
            {
                // get current id for class
                int xSearchControlTemplateID = Convert.ToInt32(row[FavoriteColumns.XSearchControlTemplateID]);

                // set flag
                bool addFavorite = true;

                // check if favorite already exists in dictionary
                if (favorites.ContainsKey(Math.Abs(xSearchControlTemplateID)))
                {
                    // set flag
                    addFavorite = false;

                    // we use the instance within the dictionary
                    favorite = favorites[Math.Abs(xSearchControlTemplateID)];
                }
                else
                {
                    // set flag
                    addFavorite = true;

                    // create new favorite as it does not exist already
                    favorite = new Favorite();
                }

                // add all classes
                if (xSearchControlTemplateID > 0)
                {
                    // apply values for class
                    favorite.XSearchControlTemplateId = xSearchControlTemplateID;
                    favorite.ParentXSearchControlTemplateId = Convert.ToInt32(row[FavoriteColumns.ParentXSearchControlTemplateID].ToString().Equals(string.Empty) ? @"-1" : row[1].ToString());
                    favorite.Name = row[FavoriteColumns.Caption].ToString();
                    favorite.SortKey = Convert.ToInt32(row[FavoriteColumns.SortKey].ToString());
                    favorite.ClassName = row[FavoriteColumns.ClassName].ToString();
                    favorite.ClassUserText = row[FavoriteColumns.ClassUserText].ToString();
                    favorite.ColLayout = row[FavoriteColumns.ColLayout].ToString();
                    favorite.SearchImmediately = Convert.ToBoolean(row[FavoriteColumns.SearchImmediately].ToString());
                    favorite.UserId = Session.User.UserID;
                }
                else
                {
                    // control for given favorite class, create new instance for control
                    FavoriteControl favoriteControl = new FavoriteControl();

                    // apply values for control
                    favoriteControl.Name = row[FavoriteColumns.ControlName].ToString();
                    favoriteControl.Type = row[FavoriteColumns.ControlType].ToString();
                    favoriteControl.Value = row[FavoriteColumns.Value].ToString();

                    // add control to favorite
                    favorite.FavoriteControls.Add(favoriteControl);
                }

                // check if need to add entry
                if (addFavorite)
                {
                    favorites.Add(Math.Abs(xSearchControlTemplateID), favorite);
                }
            }

            // return list of favorites
            return favorites;
        }

        #endregion

        #endregion

        #region Nested Types

        /// <summary>
        /// Store the column names used in FavoriteQuery.GetFavoritesFromDatabase(...)
        /// </summary>
        private static class FavoriteColumns
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const string Caption = "Caption";
            public const string ClassName = "ClassName";
            public const string ClassUserText = "ClassUserText";
            public const string ColLayout = "ColLayout";
            public const string ControlName = "ControlName";
            public const string ControlType = "ControlType";
            public const string ParentXSearchControlTemplateID = "ParentXSearchControlTemplateID";
            public const string SearchImmediately = "SearchImmediately";
            public const string SortKey = "SortKey";
            public const string Value = "Value";
            public const string XSearchControlTemplateID = "XSearchControlTemplateID";

            #endregion

            #endregion
        }

        #endregion
    }
}