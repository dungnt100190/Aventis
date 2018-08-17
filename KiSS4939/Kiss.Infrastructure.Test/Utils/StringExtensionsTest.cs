using Kiss.Infrastructure.Utils;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Infrastructure.Test.Utils
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void Truncate_StringIsAsLongAsMaxLenght_ReturnOriginalString()
        {
            // Arrange
            var str = "my string.";

            // Act
            var result = str.Truncate(10);

            // Assert
            Assert.AreEqual(str, result);
        }

        [TestMethod]
        public void Truncate_StringIsLongerAsMaxLenght_ReturnTruncatedString()
        {
            // Arrange
            var str = "my string..";

            // Act
            var result = str.Truncate(10);

            // Assert
            Assert.AreEqual("my string.", result);
        }

        [TestMethod]
        public void Truncate_StringIsLongerAsMaxLenght_TruncatedStringLengthIsMaxLength()
        {
            // Arrange
            var str = "my string..";

            // Act
            var result = str.Truncate(10);

            // Assert
            Assert.AreEqual(10, result.Length);
        }

        [TestMethod]
        public void Truncate_StringIsShorterAsMaxLenght_ReturnOriginalString()
        {
            // Arrange
            var str = "my string";

            // Act
            var result = str.Truncate(10);

            // Assert
            Assert.AreEqual(str, result);
        }
    }
}