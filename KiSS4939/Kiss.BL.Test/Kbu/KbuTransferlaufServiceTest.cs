using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Transactions;

using Kiss.Interfaces.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Kbu
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class KbuTransferlaufServiceTest
    {
        #region Fields

        #region Private Fields

        private List<KbuTransferlauf> _entities;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize(DatabaseTestUtil.CONNECTION_STRING_NAME_KISS5);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;
                var repository = UnitOfWork.GetRepository<KbuTransferlauf>(unitOfWork);

                _entities = new List<KbuTransferlauf>
                {
                };

                _entities.ForEach(x => repository.ApplyChanges(x));
                unitOfWork.SaveChanges();
                _entities.ForEach(x => x.AcceptChanges());

                transaction.Complete();
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (var transaction = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;
                var repository = UnitOfWork.GetRepository<KbuTransferlauf>(unitOfWork);

                // Delete the temporary test objects
                _entities.ForEach(x => x.MarkAsDeleted());
                _entities.ForEach(x => repository.ApplyChanges(x));

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        //[TestMethod]
        //public void CreateAndStartTransferlauf_OnServer()
        //{
        //    // Test macht nur mit DB Sinn; Server kann nicht auf Mock zugreifen...
        //    if (!TestUtils.IsDbTest(null))
        //    {
        //        return;
        //    }

        //    // Arrange
        //    var service = new KbuTransferlaufService();
        //    var unitOfWork = UnitOfWork.GetNew;
        //    var belegHelper = new KbuBelegHelper();
        //    var belege = belegHelper.CreateBelegeVerbucht(unitOfWork, 3);

        //    // Act
        //    int? kbuTransferlaufID;
        //    var result = service.CreateAndStartTransferlauf(unitOfWork, new int[] { belege[0].KbuBelegID, belege[1].KbuBelegID, belege[2].KbuBelegID }, out kbuTransferlaufID);

        //    // Assert
        //    Assert.IsTrue(result.IsOk, result.ToString());
        //    Assert.IsTrue(kbuTransferlaufID.HasValue, "KbuTransferlaufID ist null");
        //}

        [TestMethod]
        public void CreateStartGetStatusCancelTransferlauf_OnServer()
        {
            // Test macht nur mit DB Sinn; Server kann nicht auf Mock zugreifen...
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<KbuTransferlaufService>();
            var unitOfWork = UnitOfWork.GetNew;
            var belegHelper = new KbuBelegHelper();
            var belege = belegHelper.CreateBelegeVerbucht(unitOfWork, 20);

            // Act
            int? kbuTransferlaufID;
            var startResult = service.CreateAndStartTransferlauf(unitOfWork, belege.Select(b => b.KbuBelegID), out kbuTransferlaufID);
            Thread.Sleep(3000);
            var state1 = service.GetVerarbeitungsProgress(unitOfWork);
            Thread.Sleep(3000);
            var state2 = service.GetVerarbeitungsProgress(unitOfWork);
            var cancelResult = service.CancelTransferlauf(unitOfWork, kbuTransferlaufID.Value);
            Thread.Sleep(3000);
            var stateEnd = service.GetVerarbeitungsProgress(unitOfWork);

            // Assert
            Assert.IsNotNull(startResult);
            Assert.IsTrue(startResult.IsOk, "Start fehlgeschlagen: " + startResult);
            Assert.IsTrue(kbuTransferlaufID.HasValue, "KbuTransferlaufID ist null");
            Assert.IsNotNull(state1);
            Assert.IsNotNull(state2);
            Assert.IsNotNull(cancelResult);
            Assert.IsNotNull(stateEnd);

            Assert.AreEqual(kbuTransferlaufID.Value, state1.KbuTransferlaufID, "Status von anderem Transferlauf erhalten");
            Assert.AreEqual(kbuTransferlaufID.Value, state2.KbuTransferlaufID, "Status von anderem Transferlauf erhalten");
            Assert.AreEqual(kbuTransferlaufID.Value, stateEnd.KbuTransferlaufID, "Status von anderem Transferlauf erhalten");
            Assert.AreEqual(belege.Count, state1.BelegCountTotal, "Anzahl Belege im Status entspricht nicht der Anzahl der gesendeten Belegen");
            Assert.IsTrue(state1.BelegCountTotal >= state1.BelegCountTransferiert + state1.BelegCountFehlerhaft, "Anzahl der übertragenen und fehlerhaften Belege ist grösser als die Gesamtanzahl");
            Assert.AreEqual(belege.Count, state2.BelegCountTotal, "Anzahl Belege im Status entspricht nicht der Anzahl der gesendeten Belegen");
            Assert.IsTrue(state2.BelegCountTotal >= state2.BelegCountTransferiert + state2.BelegCountFehlerhaft, "Anzahl der übertragenen und fehlerhaften Belege ist grösser als die Gesamtanzahl");
            Assert.IsTrue(state2.PercentProgress >= state1.PercentProgress, "Kein Fortschritt erkennbar");
            Assert.IsTrue(state2.PercentProgress == 100 || cancelResult.IsOk, "Abbrechen fehlgeschlagen: " + cancelResult);
            Assert.IsTrue(stateEnd.DoneTime.HasValue, "Kein Endzeitpunkt im Status nach dem Abbrechen");
        }

        [TestMethod]
        public void Get_TransferierbareBelege()
        {
            // Arrange
            var service = Container.Resolve<KbuTransferlaufService>();

            var unitOfWork = UnitOfWork.GetNew;
            var belegHelper = new KbuBelegHelper();
            var beleg1 = belegHelper.CreateBelegVerbucht(unitOfWork);
            var beleg2 = belegHelper.CreateBelegVerbucht(unitOfWork);
            var beleg3 = belegHelper.CreateBelegVerbucht(unitOfWork);

            // Act
            var result = service.GetTransferierbareBelege(unitOfWork, false);

            // Assert
            Assert.IsTrue(result.Count >= 3);
            Assert.IsTrue(result.SingleOrDefault(b => b.KbuBelegID == beleg1.KbuBelegID) != null);
            Assert.IsTrue(result.SingleOrDefault(b => b.KbuBelegID == beleg2.KbuBelegID) != null);
            Assert.IsTrue(result.SingleOrDefault(b => b.KbuBelegID == beleg3.KbuBelegID) != null);
        }

        #endregion
    }
}