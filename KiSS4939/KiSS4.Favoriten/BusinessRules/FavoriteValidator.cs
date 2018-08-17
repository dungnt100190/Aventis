using KiSS4.DB;
using KiSS4.Favoriten.Interface;
using KiSS4.Favoriten.Model;

namespace KiSS4.Favoriten.BusinessRules
{
    public class FavoriteValidator
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string FAVORITE_NAME_EMPTY = "Ungültiger Favorit Name: Der Name kann nicht leer sein.";
        public const string FAVORITE_NAME_TOO_LONG = "Ungültiger Favorit Name: Der Name kann nicht mehr als 100 Zeichen enthalten.";

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public IResult ValidateFields(Favorite favorite)
        {
            IResult result = new Result { WasOperationSuccessful = true };

            if (favorite.Name.Trim().Length > 100)
            {
                result.WasOperationSuccessful = false;
                result.ErrorMessage = KissMsg.GetMLMessage("FavoriteValidator", "FAVORITE_NAME_TOO_LONG_v01", FAVORITE_NAME_TOO_LONG, KissMsgCode.MsgError);
                return result;
            }

            if (favorite.Name.Trim().Length == 0)
            {
                result.WasOperationSuccessful = false;
                result.ErrorMessage = KissMsg.GetMLMessage("FavoriteValidator", "FAVORITE_NAME_EMPTY_v01", FAVORITE_NAME_EMPTY, KissMsgCode.MsgError);
                return result;
            }

            return result;
        }

        #endregion

        #endregion
    }
}