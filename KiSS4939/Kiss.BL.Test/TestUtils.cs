using Kiss.Interfaces.BL;

using FluentValidation.Results;

namespace Kiss.BL.Test
{
    /// <summary>
    /// Utility methods for UnitTests.
    /// </summary>
    public static class TestUtils
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Sets the test status to Inconclusive if the test is run on an actual database.
        /// </summary>
        public static void AbortIfDbTest()
        {
            if (IsDbTest(null))
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive("Test is disabled if running on a database.");
            }
        }

        /// <summary>
        /// Checks if the result is OK.
        /// </summary>
        /// <param name="result"></param>
        public static void Assert(this KissServiceResult result)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result, result);
        }

        /// <summary>
        /// Checks if the result is OK.
        /// </summary>
        /// <param name="result"></param>
        public static string GetMessageString(this ValidationResult result)
        {
            var message = string.Empty;

            foreach (var validationFailure in result.Errors)
            {
                message += string.IsNullOrEmpty(message) ? "" : ", ";
                message += validationFailure;
            }

            return message;
        }

        /// <summary>
        /// Returns true if the actual test is run against a real database.
        /// Returns false if the actual test is run aigainst an EF-mock.
        /// </summary>
        /// <returns>See summary.</returns>
        public static bool IsDbTest(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            if (unitOfWork is UnitOfWorkMock)
            {
                return false;
            }

            return true;
        }

        #endregion

        #endregion
    }
}