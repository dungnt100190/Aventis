using System.Diagnostics;
using System.Linq;

using log4net.Config;
using log4net.Core;
using log4net.Layout;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Server.WebserviceStarter.Test
{
    [TestClass]
    public class EmailNotificationServiceTest
    {
        private readonly Log4NetMemoryAppender _memoryAppender;

        public EmailNotificationServiceTest()
        {
            _memoryAppender = new Log4NetMemoryAppender();
            _memoryAppender.Layout = new PatternLayout
            {
                ConversionPattern = "%message"
            };
            BasicConfigurator.Configure(_memoryAppender);
        }

        [TestMethod]
        public void CreateService_OverwriteSettings()
        {
            var notificationService = new EmailNotificationService();
            var originalLevel = notificationService.Level;
            notificationService.Level = EmailNotificationLevel.Always;

            Assert.AreEqual(EmailNotificationLevel.Failure, originalLevel);
            Assert.AreEqual(EmailNotificationLevel.Always, notificationService.Level);
        }

        [TestMethod]
        public void CreateService_ReadsSettings()
        {
            var notificationService = new EmailNotificationService();
            Assert.AreEqual(EmailNotificationLevel.Failure, notificationService.Level);
        }

        [TestMethod]
        public void NotifyFailure_LevelNever_WillNotSendEmail()
        {
            var notificationService = new EmailNotificationService { Level = EmailNotificationLevel.Never };
            var result = notificationService.NotifyFailure("{TEST}", "{TESTMESSAGE}");
            Assert.IsTrue(result);
            Assert.IsTrue(_memoryAppender.Log.Any(log => log.RenderedMessage.Contains("{TEST}")));
            Assert.IsTrue(_memoryAppender.Log.Any(log => log.RenderedMessage.Contains("{TESTMESSAGE}")));
        }

        [TestMethod]
        public void NotifySuccess_LevelFailure_WillNotSendEmail()
        {
            var notificationService = new EmailNotificationService { Level = EmailNotificationLevel.Failure };
            var result = notificationService.NotifySuccess("{TEST}");
            Assert.IsTrue(result);
            Assert.IsTrue(_memoryAppender.Log.Any(log => log.RenderedMessage.Contains("{TEST}")));
        }

        [TestMethod]
        public void NotifySuccess_LevelNever_WillNotSendEmail()
        {
            var notificationService = new EmailNotificationService { Level = EmailNotificationLevel.Never };
            var result = notificationService.NotifySuccess("{TEST}");
            Assert.IsTrue(result);
            Assert.IsTrue(_memoryAppender.Log.Any(log => log.RenderedMessage.Contains("{TEST}")));
        }

        [TestMethod]
        public void NotifySuccess_Log4NetLevelError_WillNotLog()
        {
            _memoryAppender.Threshold = Level.Error;

            var notificationService = new EmailNotificationService { Level = EmailNotificationLevel.Never };
            var result = notificationService.NotifySuccess("{TEST}");
            Assert.IsTrue(result);
            Assert.AreEqual(0, _memoryAppender.Log.Count);
        }

        /// <summary>
        /// Versendet effektiv E-Mails. Kann z.B. mit Papercut getestet werden (https://papercut.codeplex.com/).
        /// </summary>
        [TestMethod]
        public void NotifySuccess_SendsMail()
        {
            // do not execute on build server
            if (!Debugger.IsAttached)
            {
                return;
            }

            var notificationService = new EmailNotificationService
            {
                Level = EmailNotificationLevel.Always,
                From = "notification@webservicestarter",
                SmtpHost = "localhost",
                Recipients = "user1@domain, user2@domain"
            };
            var result = notificationService.NotifySuccess("{TEST}");
            Assert.IsTrue(result);
            var log = _memoryAppender.Log.First(l => l.Level == Level.Debug);
            Assert.IsTrue(log.RenderedMessage.ToLower().Contains("success"));
        }

        [TestMethod]
        public void NotifySuccess_SendsMail_InvalidConfiguration()
        {
            var notificationService = new EmailNotificationService
            {
                Level = EmailNotificationLevel.Always,
                From = "test@test",
                SmtpHost = "test"
            };
            var result = notificationService.NotifySuccess("{TEST}");
            Assert.IsFalse(result);
            Assert.IsTrue(_memoryAppender.Log.Any(log => log.Level == Level.Error));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _memoryAppender.Log.Clear();
            _memoryAppender.Threshold = Level.Debug;
        }
    }
}