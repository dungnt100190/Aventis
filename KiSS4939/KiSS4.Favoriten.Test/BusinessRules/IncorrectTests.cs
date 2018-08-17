using KiSS4.Favoriten.BusinessRules;
using KiSS4.Favoriten.Interface;
using KiSS4.Favoriten.Model;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS4.Favoriten.Test.BusinessRules
{
    [TestClass]
    public class IncorrectTests
    {
        //TODO: CLEAN THE DB'S TABLES AFTER ALL TESTS ARE RUN.
        //TODO: QUERY THE DB TO ENSURE THE DATA WAS CORRECTLY WRITTE IN THE DB.

        private const string ERROR_MESSAGE_RETURNED = "The returned error message is: ";
        private const string UNEXPECTED_ERROR_RESULT = "'WasOperationSuccessful == false' expected, but was 'true' instead.";

        private readonly FavoriteValidator _validator = new FavoriteValidator();
        private IResult _result;

        /// <summary>
        /// Error, since favorite name > 100 characters.
        /// </summary>
        [TestMethod]
        public void Test_FavoriteNameTooLong()
        {
            Favorite favorite = new Favorite();
            favorite.Name = new string('a', 101);
            _result = _validator.ValidateFields(favorite);

            // Checking results.
            Assert.IsTrue(_result.WasOperationSuccessful == false, UNEXPECTED_ERROR_RESULT);
            Assert.IsTrue(_result.ErrorMessage.ToUpper().Equals(FavoriteValidator.FAVORITE_NAME_TOO_LONG.ToUpper()), FavoriteValidator.FAVORITE_NAME_TOO_LONG + " was expected, but was not returned. " + ERROR_MESSAGE_RETURNED + _result.ErrorMessage);
        }

        /// <summary>
        /// Error, since favorite name is empty.
        /// </summary>
        [TestMethod]
        public void Test_FavoriteNameEmptyString()
        {
            Favorite favorite = new Favorite();
            favorite.Name = string.Empty;
            _result = _validator.ValidateFields(favorite);

            // Checking results.
            Assert.IsTrue(_result.WasOperationSuccessful == false, UNEXPECTED_ERROR_RESULT);
            Assert.IsTrue(_result.ErrorMessage.ToUpper().Equals(FavoriteValidator.FAVORITE_NAME_EMPTY.ToUpper()), FavoriteValidator.FAVORITE_NAME_EMPTY + " was expected, but was not returned. " + ERROR_MESSAGE_RETURNED + _result.ErrorMessage);
        }

        /// <summary>
        /// Error, since favorite name only contains spaces.
        /// </summary>
        [TestMethod]
        public void Test_FavoriteNameOnlySpaces()
        {
            Favorite favorite = new Favorite();
            favorite.Name = new string(' ', 85);
            _result = _validator.ValidateFields(favorite);

            // Checking results.
            Assert.IsTrue(_result.WasOperationSuccessful == false, UNEXPECTED_ERROR_RESULT);
            Assert.IsTrue(_result.ErrorMessage.ToUpper().Equals(FavoriteValidator.FAVORITE_NAME_EMPTY.ToUpper()), FavoriteValidator.FAVORITE_NAME_EMPTY + " was expected, but was not returned. " + ERROR_MESSAGE_RETURNED + _result.ErrorMessage);
        }
    }
}