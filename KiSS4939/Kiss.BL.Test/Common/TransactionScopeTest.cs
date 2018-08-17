using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Ba;
using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Common
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class TransactionScopeTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private List<BaPerson> _entities;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;
                var repository = UnitOfWork.GetRepository<BaPerson>(unitOfWork);

                SystemService.NewHistoryVersion(unitOfWork);

                _entities = new List<BaPerson>
                {
                    new BaPerson
                    {
                        Name = "NameTest",
                        Vorname = "VornameTest",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now,
                    }
                };

                _entities.ForEach(x => repository.ApplyChanges(x));
                unitOfWork.SaveChanges();
                _entities.ForEach(x => x.AcceptChanges());

                transaction.Complete();
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (var transaction = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;
                var repository = UnitOfWork.GetRepository<BaPerson>(unitOfWork);

                // Delete the temporary test objects
                _entities.ForEach(x => x.MarkAsDeleted());
                _entities.ForEach(x => repository.ApplyChanges(x));

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void SaveData_withTransactionNoError_stateAfterIsUnchanged()
        {
            // Arrange
            var service = Container.Resolve<BaPersonService>();
            var entity = _entities[0];
            entity.Name = "new name";
            var stateBefore = entity.ChangeTracker.State;

            // Act
            var result = KissServiceResult.Ok();
            using (var transaction = new TransactionScope())
            {
                result += service.SaveData(null, entity);

                if(result.IsOk)
                {
                    transaction.Complete();
                }
            }

            var stateAfter = entity.ChangeTracker.State;

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(ObjectState.Modified, stateBefore);
            Assert.AreEqual(ObjectState.Unchanged, stateAfter);
        }

        [TestMethod]
        public void SaveData_withoutTransactionNoError_stateAfterIsUnchanged()
        {
            // Arrange
            var service = Container.Resolve<BaPersonService>();
            var entity = _entities[0];
            entity.Name = "new name";
            var stateBefore = entity.ChangeTracker.State;

            // Act
            var result = service.SaveData(null, entity);
            var stateAfter = entity.ChangeTracker.State;

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(ObjectState.Modified, stateBefore);
            Assert.AreEqual(ObjectState.Unchanged, stateAfter);
        }

        #endregion
    }
}