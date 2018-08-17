using KiSS4.Dokument.Utilities;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS4.Dokument.Test
{
    [TestClass]
    public class FileUtiliesTest
    {
        [TestMethod]
        public void CleanFileName_FileNameIsTooLong_FileNameEndsWithExtension()
        {
            // Arrange
            var fileName = @"FileName with a very long name_aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbcccccccccccccccccccccccccccccccccccccccccccccccccccdddddddddddddddddddddddddddddddddddeeeeeeeeeeeeeeeeeeeeeeeeee.pdf";

            // Act
            var result = FileUtilies.CleanFileName(fileName);

            // Assert
            Assert.IsTrue(result.EndsWith(".pdf"));
        }

        [TestMethod]
        public void CleanFileName_FileNameIsTooLong_FileNameLength250()
        {
            // Arrange
            var fileName = @"FileName with a very long name_aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbcccccccccccccccccccccccccccccccccccccccccccccccccccdddddddddddddddddddddddddddddddddddeeeeeeeeeeeeeeeeeeeeeeeeee.pdf";

            // Act
            var result = FileUtilies.CleanFileName(fileName);

            // Assert
            Assert.AreEqual(250, result.Length);
        }

        [TestMethod]
        public void CleanFileName_FileNameWithInvalidChars_ReturnFileNameWithoutInvalidChars()
        {
            // Arrange
            var fileName = @"FileName with invalid chars [a] + {b} + 1/2\3<4>5:6?7""8*9.pdf";

            // Act
            var result = FileUtilies.CleanFileName(fileName);

            // Assert
            Assert.AreEqual(@"FileName with invalid chars [a] + {b} + 123456789.pdf", result);
        }

        [TestMethod]
        public void CleanFileName_FileNameWithoutExtensionIsTooLong_FileNameLength250()
        {
            // Arrange
            var fileName = @"FileName with a very long name_aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbcccccccccccccccccccccccccccccccccccccccccccccccccccdddddddddddddddddddddddddddddddddddeeeeeeeeeeeeeeeeeeeeeeeeee";

            // Act
            var result = FileUtilies.CleanFileName(fileName);

            // Assert
            Assert.AreEqual(250, result.Length);
        }

        [TestMethod]
        public void CleanFileName_ValidFileName_ReturnSameFileName()
        {
            // Arrange
            var fileName = "ValidFileName.pdf";

            // Act
            var result = FileUtilies.CleanFileName(fileName);

            // Assert
            Assert.AreEqual(fileName, result);
        }

        [TestMethod]
        public void RemoveInvalidFileNameChars_StringWithInvalidChars_ReturnStringWithoutInvalidChars()
        {
            // Arrange
            var str = @"string with invalid chars [a] + {b} + 1/2\3<4>5:6?7""8*9";

            // Act
            var result = FileUtilies.RemoveInvalidFileNameChars(str);

            // Assert
            Assert.AreEqual(@"string with invalid chars [a] + {b} + 123456789", result);
        }

        [TestMethod]
        public void RemoveInvalidFileNameChars_StringWithValidChars_ReturnSameString()
        {
            // Arrange
            var str = @"valid string [a] + {b}";

            // Act
            var result = FileUtilies.RemoveInvalidFileNameChars(str);

            // Assert
            Assert.AreEqual(str, result);
        }

        [TestMethod]
        public void ReplaceParamInFileName_FilenameAndParamAndPathAreTooLong_FilenameLength210MinusPathLength()
        {
            // Arrange
            var fileName = @"FileName with a very long name_{0}.pdf";
            var path = @"C:\Temp";
            var param = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbcccccccccccccccccccccccccccccccccccccccccccccccccccdddddddddddddddddddddddddddddddddddeeeeeeeeeeeeeeeeeeeeeeeeee";

            // Act
            var result = FileUtilies.ReplaceParamInFileName(fileName, param, path.Length);

            // Assert
            Assert.AreEqual(210 - path.Length, result.Length);
        }

        [TestMethod]
        public void ReplaceParamInFileName_FilenameAndParamAreNotTooLong_ReturnFilenameWithParam()
        {
            // Arrange
            var fileName = "ValidFileName_{0}.pdf";
            var param = "param";

            // Act
            var result = FileUtilies.ReplaceParamInFileName(fileName, param, 0);

            // Assert
            Assert.AreEqual(string.Format(fileName, param), result);
        }

        [TestMethod]
        public void ReplaceParamInFileName_FilenameAndParamAreTooLong_FileNameEndsWithExtension()
        {
            // Arrange
            var fileName = @"FileName with a very long name_{0}.pdf";
            var param = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbcccccccccccccccccccccccccccccccccccccccccccccccccccdddddddddddddddddddddddddddddddddddeeeeeeeeeeeeeeeeeeeeeeeeee";

            // Act
            var result = FileUtilies.ReplaceParamInFileName(fileName, param, 0);

            // Assert
            Assert.IsTrue(result.EndsWith(".pdf"));
        }

        [TestMethod]
        public void ReplaceParamInFileName_FilenameAndParamAreTooLong_FilenameLength210()
        {
            // Arrange
            var fileName = @"FileName with a very long name_{0}.pdf";
            var param = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbcccccccccccccccccccccccccccccccccccccccccccccccccccdddddddddddddddddddddddddddddddddddeeeeeeeeeeeeeeeeeeeeeeeeee";

            // Act
            var result = FileUtilies.ReplaceParamInFileName(fileName, param, 0);

            // Assert
            Assert.AreEqual(210, result.Length);
        }
    }
}