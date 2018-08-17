using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fa;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Fa
{
    /// <summary>
    /// Tests the FaKategorisierungService service.
    /// </summary>
    [TestClass]
    public class FaKategorisierungServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BaPersonHelper _baPersonHelper = new BaPersonHelper();
        private readonly XUserHelper _xUserHelper = new XUserHelper();

        #endregion

        #region Private Fields

        private BaPerson _baPerson;
        private List<FaKategorisierung> _entities;
        private XUser _xUser;

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
                var repository = UnitOfWork.GetRepository<FaKategorisierung>(unitOfWork);

                _baPerson = _baPersonHelper.Create(unitOfWork);
                _xUser = _xUserHelper.GetOrCreate(unitOfWork);

                _entities = new List<FaKategorisierung>
                {
                    new FaKategorisierung
                    {
                        BaPerson = _baPerson,
                        BaPersonID = _baPerson.BaPersonID,
                        XUser = _xUser,
                        UserID = _xUser.UserID,
                        Datum = new DateTime(2013,1,1),
                        Creator = "unittest",
                        Created = DateTime.Now,
                        Modifier = "unittest",
                        Modified = DateTime.Now
                    },
                    new FaKategorisierung
                    {
                        BaPerson = _baPerson,
                        BaPersonID = _baPerson.BaPersonID,
                        XUser = _xUser,
                        UserID = _xUser.UserID,
                        Datum = new DateTime(2012,1,1),
                        Creator = "unittest",
                        Created = DateTime.Now,
                        Modifier = "unittest",
                        Modified = DateTime.Now
                    },
                };

                _entities.ForEach(repository.ApplyChanges);
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
                var repository = UnitOfWork.GetRepository<FaKategorisierung>(unitOfWork);

                // Delete the temporary test objects
                _entities.ForEach(x => x.MarkAsDeleted());
                _entities.ForEach(repository.ApplyChanges);

                _baPersonHelper.Delete(unitOfWork);

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void Test_Abschluss()
        {
            // Arrange
            var service = Container.Resolve<FaKategorisierungService>();
            var entity = service.GetById(null, _entities[0].FaKategorisierungID);

            // Act
            // Abschlussdatum ohne Abschlussgrund
            entity.Abschlussdatum = new DateTime(2013, 12, 31);
            var result = service.SaveData(null, entity);
            Assert.IsTrue(result.IsError, result);

            // Abschlussgrund ohne Abschlussdatum
            entity.Abschlussdatum = null;
            entity.FaKategorisierungAbschlussgrundCode = 1;
            result = service.SaveData(null, entity);
            Assert.IsTrue(result.IsError, result);

            // Abschlussdatum vor Beginn
            entity.Abschlussdatum = new DateTime(2000, 1, 1);
            entity.FaKategorisierungAbschlussgrundCode = 1;
            result = service.SaveData(null, entity);
            Assert.IsTrue(result.IsError, result);
        }

        [TestMethod]
        public void Test_GetByBaPersonId()
        {
            // Arrange
            var service = Container.Resolve<FaKategorisierungService>();

            // Act
            var list = service.GetByBaPersonId(null, _baPerson.BaPersonID);

            // Assert
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list[0].BaPersonID == _baPerson.BaPersonID);
            Assert.IsTrue(list[1].BaPersonID == _baPerson.BaPersonID);
            Assert.IsTrue(list[0].UserID == _xUser.UserID);
            Assert.IsTrue(list[1].UserID == _xUser.UserID);
            Assert.IsTrue(list.Any(x => x.Datum == new DateTime(2012, 1, 1)));
            Assert.IsTrue(list.Any(x => x.Datum == new DateTime(2013, 1, 1)));
        }

        #endregion
    }
}