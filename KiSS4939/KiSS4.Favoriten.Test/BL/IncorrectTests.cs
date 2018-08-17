using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS4.Favoriten.Test.BL
{
    [TestClass]
    public class IncorrectTests
    {
        //TODO: CLEAN THE DB'S TABLES AFTER ALL TESTS ARE RUN.
        //TODO: QUERY THE DB TO ENSURE THE DATA WAS CORRECTLY WRITTE IN THE DB.

        //private const string ERROR_MESSAGE_RETURNED = "An unexpected error message was returned: ";
        //private const string UNEXPECTED_ERROR_RESULT = "'WasOperationSuccessful == true' expected, but was 'false' instead.";
        //private const string FAVORITE_NAME_EMPTY_DB_EXPECTED_ERROR = "Cannot insert the value NULL into column 'Name', table 'KiSS4_MasterDev.dbo.XSearchControlTemplate'; column does not allow nulls. INSERT fails.\r\nThe statement has been terminated.";
        //private const string ERROR_MESSAGE_DETAILED_EMPTY_STRING = "Invalid favorite name: the string is empty.";
        //private const string ERROR_MESSAGE_DETAILED_TOO_LONG = "Invalid favorite name: the string exceeds 100 characters.";

        //private IResult _result;
        //private string _favoriteName;

        /// <summary>
        /// Error, since favorite name > 100 characters.
        /// </summary>
        [TestMethod]
        public void Test_FavoriteNameTooLong()
        {
            //_favoriteName = new string('a', 101);
            //Favorite favorite = new Favorite();
            //_result = favorite.Save(_favoriteName);

            //// Checking results.
            //Assert.IsTrue(_result.WasOperationSuccessful == false, UNEXPECTED_ERROR_RESULT);
            //Assert.IsTrue(_result.ErrorMessage.ToUpper().Equals(ERROR_MESSAGE_DETAILED_TOO_LONG.ToUpper()), FavoriteValidator.FAVORITE_NAME_EMPTY + " was expected, but was not returned. " + ERROR_MESSAGE_RETURNED + _result.ErrorMessage);

            //FavoriteService svc = new FavoriteService();
            //_result = svc.SaveFavorite(favorite, 1);

            //// Checking results.
            //Assert.IsTrue(_result.WasOperationSuccessful == false, UNEXPECTED_ERROR_RESULT);
            //Assert.IsTrue(_result.ErrorMessage.ToUpper().Equals(FAVORITE_NAME_EMPTY_DB_EXPECTED_ERROR.ToUpper()), FavoriteValidator.FAVORITE_NAME_EMPTY + " was expected, but was not returned. " + ERROR_MESSAGE_RETURNED + _result.ErrorMessage);
        }

        /// <summary>
        /// Error, since favorite name is empty.
        /// </summary>
        [TestMethod]
        public void Test_FavoriteNameEmptyString()
        {
            //_favoriteName = string.Empty;
            //Favorite favorite = new Favorite();
            //_result = favorite.Save(_favoriteName);

            //// Checking results.
            //Assert.IsTrue(_result.WasOperationSuccessful == false, UNEXPECTED_ERROR_RESULT);
            //Assert.IsTrue(_result.ErrorMessage.ToUpper().Equals(ERROR_MESSAGE_DETAILED_EMPTY_STRING.ToUpper()), FavoriteValidator.FAVORITE_NAME_EMPTY + " was expected, but was not returned. " + ERROR_MESSAGE_RETURNED + _result.ErrorMessage);

            //FavoriteService svc = new FavoriteService();
            //_result = svc.SaveFavorite(favorite, 1);

            //// Checking results.
            //Assert.IsTrue(_result.WasOperationSuccessful == false, UNEXPECTED_ERROR_RESULT);
            //Assert.IsTrue(_result.ErrorMessage.ToUpper().Equals(FAVORITE_NAME_EMPTY_DB_EXPECTED_ERROR.ToUpper()), FavoriteValidator.FAVORITE_NAME_EMPTY + " was expected, but was not returned. " + ERROR_MESSAGE_RETURNED + _result.ErrorMessage);
        }

        /// <summary>
        /// Error, since favorite name only contains spaces.
        /// </summary>
        [TestMethod]
        public void Test_FavoriteNameOnlySpaces()
        {
            //_favoriteName = new string(' ', 85); 
            //Favorite favorite = new Favorite();
            //_result = favorite.Save(_favoriteName);

            //// Checking results.
            //Assert.IsTrue(_result.WasOperationSuccessful == false, UNEXPECTED_ERROR_RESULT);
            //Assert.IsTrue(_result.ErrorMessage.ToUpper().Equals(ERROR_MESSAGE_DETAILED_EMPTY_STRING.ToUpper()), FavoriteValidator.FAVORITE_NAME_EMPTY + " was expected, but was not returned. " + ERROR_MESSAGE_RETURNED + _result.ErrorMessage);

            //FavoriteService svc = new FavoriteService();
            //_result = svc.SaveFavorite(favorite, 1);

            //// Checking results.
            //Assert.IsTrue(_result.WasOperationSuccessful == false, UNEXPECTED_ERROR_RESULT);
            //Assert.IsTrue(_result.ErrorMessage.ToUpper().Equals(FAVORITE_NAME_EMPTY_DB_EXPECTED_ERROR.ToUpper()), FavoriteValidator.FAVORITE_NAME_EMPTY + " was expected, but was not returned. " + ERROR_MESSAGE_RETURNED + _result.ErrorMessage);
        }
    }
}