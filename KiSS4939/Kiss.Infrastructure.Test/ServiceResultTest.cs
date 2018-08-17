using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Infrastructure.Test
{
    [TestClass]
    public class ServiceResultTest
    {
        [TestMethod]
        public void AddEntry_ErrorAddError_SetServiceResultEntries()
        {
            // Arrange
            var result = ServiceResult.Error("my 1st error");

            // Act
            result.AddEntry(Interfaces.BL.ServiceResultType.Error);

            // Assert
            Assert.AreEqual(2, result.ServiceResultEntries.Count);
        }

        [TestMethod]
        public void AddEntry_OkAddError_IsError()
        {
            // Arrange
            var result = ServiceResult.Ok();

            // Act
            result.AddEntry(Interfaces.BL.ServiceResultType.Error);

            // Assert
            Assert.IsTrue(result.IsError);
        }

        [TestMethod]
        public void AddEntry_OkAddError_SetServiceResultEntries()
        {
            // Arrange
            var result = ServiceResult.Ok();

            // Act
            result.AddEntry(Interfaces.BL.ServiceResultType.Error);

            // Assert
            Assert.AreEqual(2, result.ServiceResultEntries.Count);
        }

        [TestMethod]
        public void Error_DefaultMessage_IsError()
        {
            // Arrange

            // Act
            var result = ServiceResult.Error("defaultMessage");

            // Assert
            Assert.IsTrue(result.IsError);
        }

        [TestMethod]
        public void Error_DefaultMessage_IsNotOk()
        {
            // Arrange

            // Act
            var result = ServiceResult.Error("defaultMessage");

            // Assert
            Assert.IsFalse(result.IsOk);
        }

        [TestMethod]
        public void Error_DefaultMessage_IsNotWarning()
        {
            // Arrange

            // Act
            var result = ServiceResult.Error("defaultMessage");

            // Assert
            Assert.IsFalse(result.IsWarning);
        }

        [TestMethod]
        public void Error_DefaultMessage_SetMessage()
        {
            // Arrange

            // Act
            var result = ServiceResult.Error("defaultMessage");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("defaultMessage", entry.Message);
        }

        [TestMethod]
        public void Error_DefaultMessage_SetServiceResultEntries()
        {
            // Arrange

            // Act
            var result = ServiceResult.Error("defaultMessage");

            // Assert
            Assert.AreEqual(1, result.ServiceResultEntries.Count);
        }

        [TestMethod]
        public void Error_DefaultMessageWithIntParam_SetMessage()
        {
            // Arrange

            // Act
            var result = ServiceResult.Error("defaultMessage: {0}", 1);
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("defaultMessage: {0}", entry.Message);
        }

        [TestMethod]
        public void Error_DefaultMessageWithIntParam_SetMessageParameters()
        {
            // Arrange

            // Act
            var result = ServiceResult.Error("defaultMessage: {0}", 1);
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual(1, entry.MessageParameters[0]);
        }

        [TestMethod]
        public void Error_DefaultMessageWithStringParam_SetMessage()
        {
            // Arrange

            // Act
            var result = ServiceResult.Error("defaultMessage: {0}", "1");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("defaultMessage: {0}", entry.Message);
        }

        [TestMethod]
        public void Error_DefaultMessageWithStringParam_SetMessageParameters()
        {
            // Arrange

            // Act
            var result = ServiceResult.Error("defaultMessage: {0}", "1");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("1", entry.MessageParameters[0]);
        }

        [TestMethod]
        public void ErrorWithId_MessageIdAndDefaultMessage_SetMessage()
        {
            // Arrange

            // Act
            var result = ServiceResult.ErrorWithId("MessageId", "defaultMessage");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("defaultMessage", entry.Message);
        }

        [TestMethod]
        public void ErrorWithId_MessageIdAndDefaultMessage_SetMessageID()
        {
            // Arrange

            // Act
            var result = ServiceResult.ErrorWithId("MessageId", "defaultMessage");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("MessageId", entry.MessageID);
        }

        [TestMethod]
        public void ErrorWithId_MessageIdAndDefaultMessageWithStringParam_SetMessage()
        {
            // Arrange

            // Act
            var result = ServiceResult.ErrorWithId("MessageId", "defaultMessage: {0}", "1");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("defaultMessage: {0}", entry.Message);
        }

        [TestMethod]
        public void ErrorWithId_MessageIdAndDefaultMessageWithStringParam_SetMessageParameters()
        {
            // Arrange

            // Act
            var result = ServiceResult.ErrorWithId("MessageId", "defaultMessage: {0}", "1");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("1", entry.MessageParameters[0]);
        }

        [TestMethod]
        public void Ok_IsOk()
        {
            // Arrange

            // Act
            var result = ServiceResult.Ok();

            // Assert
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void Warning_DefaultMessage_IsNotError()
        {
            // Arrange

            // Act
            var result = ServiceResult.Warning("defaultMessage");

            // Assert
            Assert.IsFalse(result.IsError);
        }

        [TestMethod]
        public void Warning_DefaultMessage_IsNotOk()
        {
            // Arrange

            // Act
            var result = ServiceResult.Warning("defaultMessage");

            // Assert
            Assert.IsFalse(result.IsOk);
        }

        [TestMethod]
        public void Warning_DefaultMessage_IsWarning()
        {
            // Arrange

            // Act
            var result = ServiceResult.Warning("defaultMessage");

            // Assert
            Assert.IsTrue(result.IsWarning);
        }

        [TestMethod]
        public void Warning_DefaultMessage_SetMessage()
        {
            // Arrange

            // Act
            var result = ServiceResult.Warning("defaultMessage");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("defaultMessage", entry.Message);
        }

        [TestMethod]
        public void Warning_DefaultMessage_SetServiceResultEntries()
        {
            // Arrange

            // Act
            var result = ServiceResult.Warning("defaultMessage");

            // Assert
            Assert.AreEqual(1, result.ServiceResultEntries.Count);
        }

        [TestMethod]
        public void Warning_DefaultMessageWithIntParam_SetMessage()
        {
            // Arrange

            // Act
            var result = ServiceResult.Warning("defaultMessage: {0}", 1);
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("defaultMessage: {0}", entry.Message);
        }

        [TestMethod]
        public void Warning_DefaultMessageWithIntParam_SetMessageParameters()
        {
            // Arrange

            // Act
            var result = ServiceResult.Warning("defaultMessage: {0}", 1);
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual(1, entry.MessageParameters[0]);
        }

        [TestMethod]
        public void Warning_DefaultMessageWithStringParam_SetMessage()
        {
            // Arrange

            // Act
            var result = ServiceResult.Warning("defaultMessage: {0}", "1");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("defaultMessage: {0}", entry.Message);
        }

        [TestMethod]
        public void Warning_DefaultMessageWithStringParam_SetMessageParameters()
        {
            // Arrange

            // Act
            var result = ServiceResult.Warning("defaultMessage: {0}", "1");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("1", entry.MessageParameters[0]);
        }

        [TestMethod]
        public void WarningWithId_MessageIdAndDefaultMessage_SetMessage()
        {
            // Arrange

            // Act
            var result = ServiceResult.WarningWithId("MessageId", "defaultMessage");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("defaultMessage", entry.Message);
        }

        [TestMethod]
        public void WarningWithId_MessageIdAndDefaultMessage_SetMessageID()
        {
            // Arrange

            // Act
            var result = ServiceResult.WarningWithId("MessageId", "defaultMessage");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("MessageId", entry.MessageID);
        }

        [TestMethod]
        public void WarningWithId_MessageIdAndDefaultMessageWithStringParam_SetMessage()
        {
            // Arrange

            // Act
            var result = ServiceResult.WarningWithId("MessageId", "defaultMessage: {0}", "1");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("defaultMessage: {0}", entry.Message);
        }

        [TestMethod]
        public void WarningWithId_MessageIdAndDefaultMessageWithStringParam_SetMessageParameters()
        {
            // Arrange

            // Act
            var result = ServiceResult.WarningWithId("MessageId", "defaultMessage: {0}", "1");
            var entry = result.ServiceResultEntries[0];

            // Assert
            Assert.AreEqual("1", entry.MessageParameters[0]);
        }
    }
}