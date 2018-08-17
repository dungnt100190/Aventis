using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kiss.Infrastructure.Testing;
using Kiss.UserInterface.ViewModel.Commanding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.UserInterface.ViewModel.Test
{
    [TestClass]
    public class AsyncTaskTest
    {
        [TestMethod]
        public void CancelTest()
        {
            // Arrange
            var asyncTask = new AsyncTask((parameter, token) => Sleep(1000, token));

            // Act
            asyncTask.StartCommand.Execute();

            var startEnabledAfterStart = asyncTask.StartCommand.IsExecutable;
            var cancelEnabledAfterStart = asyncTask.CancelCommand.IsExecutable;

            asyncTask.CancelCommand.Execute();

            var startEnabledAfterCancel = asyncTask.StartCommand.IsExecutable;
            var cancelEnabledAfterCancel = asyncTask.CancelCommand.IsExecutable;

            // Assert
            Assert.IsFalse(startEnabledAfterStart);
            Assert.IsTrue(cancelEnabledAfterStart);

            Assert.IsTrue(startEnabledAfterCancel);
            Assert.IsFalse(cancelEnabledAfterCancel);
        }

        [TestMethod]
        public void RunAsyncTest()
        {
            // Arrange
            var asyncTask = new AsyncTask((parameter, token) => Sleep(100, token)); // assert must win racing condition, but don't take too long

            // Act
            asyncTask.StartCommand.Execute();

            var startEnabledAfterStart = asyncTask.StartCommand.IsExecutable;
            var cancelEnabledAfterStart = asyncTask.CancelCommand.IsExecutable;

            Thread.Sleep(200);

            var startEnabledAfterCancel = asyncTask.StartCommand.IsExecutable;
            var cancelEnabledAfterCancel = asyncTask.CancelCommand.IsExecutable;

            // Assert
            Assert.IsFalse(startEnabledAfterStart);
            Assert.IsTrue(cancelEnabledAfterStart);

            Assert.IsTrue(startEnabledAfterCancel);
            Assert.IsFalse(cancelEnabledAfterCancel);
        }

        [TestMethod]
        public void TestCommandStateAfterStartWithoutCanExecute()
        {
            // Arrange
            var asyncTask = new AsyncTask(parameter => Task.Delay(10000)); // assert must win racing condition, but don't use too many resources

            // Act
            asyncTask.StartCommand.Execute();

            // Assert
            Assert.IsFalse(asyncTask.StartCommand.IsExecutable);
            Assert.IsFalse(asyncTask.CancelCommand.IsExecutable); // async method has no cancellation token
        }

        [TestMethod]
        public void TestCommandStateAfterStartWithoutCanExecuteWithCancellationToken()
        {
            // Arrange
            var asyncTask = new AsyncTask((parameter, token) => Task.Delay(10000)); // assert must win racing condition, but don't use too many resources

            // Act
            asyncTask.StartCommand.Execute();

            // Assert
            Assert.IsFalse(asyncTask.StartCommand.IsExecutable);
            Assert.IsTrue(asyncTask.CancelCommand.IsExecutable); // async method has cancellation token
        }

        [TestMethod]
        public void TestCommandStateAtStartWithoutCanExecute()
        {
            // Arrange
            // Act
            var asyncTask = new AsyncTask(parameter => Task.Delay(10));

            // Assert
            Assert.IsTrue(asyncTask.StartCommand.IsExecutable);
            Assert.IsFalse(asyncTask.CancelCommand.IsExecutable);
        }

        [TestMethod]
        public void TestExecuteDelegateIsMandatory()
        {
            // Arrange

            // Act/Assert
            TestHelper.AssertThrows<ArgumentNullException>(() => { new AsyncTask((Func<object, Task>)null); });
        }

        private async Task Delay(int milliseconds)
        {
            await Task.Delay(milliseconds);
        }

        private async Task Sleep(int milliseconds, CancellationToken token)
        {
            var sleepTask = Task.Delay(milliseconds);
            await sleepTask;
        }

        //[TestMethod]
        //public void TestNotifyCommandStateOnStartWithoutCanExecute()
        //{
        //    // Arrange
        //    var asyncTask = new AsyncTask(parameter => Thread.Sleep(100)); // assert must win racing condition, but don't use too many resources
        //    bool startCommandNotificationReceived = false;
        //    bool cancelCommandNotificationReceived = false;
        //    asyncTask.StartCommand.PropertyChanged += (sender, args) => { if (args.PropertyName == "IsExecutable" && !asyncTask.StartCommand.IsExecutable) startCommandNotificationReceived = true; };
        //    asyncTask.CancelCommand.PropertyChanged += (sender, args) => { if (args.PropertyName == "IsExecutable" && asyncTask.CancelCommand.IsExecutable) cancelCommandNotificationReceived = true; };

        //    // Act
        //    asyncTask.StartCommand.Execute();

        //    // Assert
        //    Assert.IsTrue(startCommandNotificationReceived);
        //    Assert.IsTrue(cancelCommandNotificationReceived);
        //}
        //[TestMethod]
        //public void TestNotifyCommandStateOnEndWithoutCanExecute()
        //{
        //    // Arrange
        //    var asyncTask = new AsyncTask(parameter => Thread.Sleep(100));
        //    var startCommandNotificationReceived = false;
        //    var cancelCommandNotificationReceived = false;

        //    // Act
        //    asyncTask.StartCommand.Execute();
        //    asyncTask.StartCommand.PropertyChanged += (sender, args) => { if (args.PropertyName == "IsExecutable" && asyncTask.StartCommand.IsExecutable) startCommandNotificationReceived = true; };
        //    asyncTask.CancelCommand.PropertyChanged += (sender, args) => { if (args.PropertyName == "IsExecutable" && !asyncTask.CancelCommand.IsExecutable) cancelCommandNotificationReceived = true; };
        //    asyncTask.Task.Wait();
        //    Thread.Sleep(100);

        //    // Assert
        //    Assert.IsTrue(startCommandNotificationReceived);
        //    Assert.IsTrue(cancelCommandNotificationReceived);
        //}
    }
}