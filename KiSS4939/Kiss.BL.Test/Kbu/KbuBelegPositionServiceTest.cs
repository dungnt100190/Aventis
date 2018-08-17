using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.Infrastructure.Testing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.Infrastructure;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Kbu
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class KbuBelegPositionServiceTest
    {
        #region Fields

        #region Private Fields

        private List<KbuBelegPosition> _entities;

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
            /*
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;
                var repository = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);

                _entities = new List<KbuBelegPosition>
                {
                    new KbuBelegPosition()
                };

                _entities.ForEach(x => repository.ApplyChanges(x));
                unitOfWork.SaveChanges();
                _entities.ForEach(x => x.AcceptChanges());

                transaction.Complete();
            }*/
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            /*
            using (var transaction = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;
                var repository = UnitOfWork.GetRepository<TEntity>(unitOfWork);

                // Delete the temporary test objects
                _entities.ForEach(x => x.MarkAsDeleted());
                _entities.ForEach(x => repository.ApplyChanges(x));

                unitOfWork.SaveChanges();
                transaction.Complete();
            }*/
        }

        [TestMethod]
        public void Test_Rename_Me()
        {
            /*
            // Arrange
            var service = new TService();
            var entity = _entities[0];

            // Act
            var result = service.DoSomething();

            // Assert
            Assert.IsFalse(true);*/
        }

        #endregion
    }
}