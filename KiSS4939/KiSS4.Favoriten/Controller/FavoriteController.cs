using System;
using System.Collections.Generic;
using System.Linq;

using KiSS4.Favoriten.BL;
using KiSS4.Favoriten.Interface;
using KiSS4.Favoriten.Model;

namespace KiSS4.Favoriten.Controller
{
    public class FavoriteController
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Set class usertext for current classname
        /// </summary>
        /// <param name="favorite">The favorite where class usertext has to be applied</param>
        /// <exception cref="ArgumentNullException">Thrown if favorite instance is null</exception>
        public static void SetClassUserText(Favorite favorite)
        {
            // validate
            if (favorite == null)
            {
                throw new ArgumentNullException("favorite", "The given favorite instance is null, cannot apply class usertext");
            }

            // apply class usertext
            favorite.ClassUserText = FavoriteService.GetClassUserText(favorite.ClassName);
        }

        #endregion

        #region Public Methods

        public IDictionary<int, Favorite> GetAllFavorites()
        {
            FavoriteService svc = new FavoriteService();
            return svc.GetAllFavorites();
        }

        public IDictionary<int, Favorite> GetFavoritesForClass(string className)
        {
            FavoriteService svc = new FavoriteService();
            return svc.GetFavoritesForClass(className);
        }

        public IResult Save(IDictionary<int, Favorite> favorites, int userId)
        {
            IResult result = new Result();
            bool processingOccurred = false;
            FavoriteService svc = new FavoriteService();

            foreach (Favorite favorite in favorites.Values.Reverse())
            {
                if (favorite.HasBeenModified && favorite.HasBeenDeleted == false)
                {
                    processingOccurred = true;

                    // TODO: Obtain the newly created PK and use it to set a Favorite if its property "ParentSerchControlId" is < 0
                    /*****
                    if (favorite.XParentSearch < 0)
                        favorite.XParentSearch = parentPK;

                    int parentPK = query.SaveNewFavorite(favorite, userId);
                    ******/

                    result = svc.SaveFavorite(favorite, userId);

                    if (result.WasOperationSuccessful == false)
                    {
                        break;
                    }
                }
                else if (favorite.HasBeenDeleted)
                {
                    processingOccurred = true;

                    // Since the business rules validation was OK, write to the DB.
                    result = svc.DeleteFavorite(favorite);

                    if (result.WasOperationSuccessful == false)
                    {
                        break;
                    }
                }
            }

            if (processingOccurred == false)
            {
                result.WasOperationSuccessful = true;
            }

            return result;
        }

        public IResult SaveExistingFavorite(Favorite favorite)
        {
            FavoriteService svc = new FavoriteService();
            return svc.SaveExistingFavorite(favorite);
        }

        #endregion

        #endregion
    }
}