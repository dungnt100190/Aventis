using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test
{
    [TestClass]
    public class ServiceCRUDBaseTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private List<FsDienstleistung> _dienstleistungen;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
        }

        [TestInitialize]
        public void TestSetup()
        {
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;

                // Create some FsDienstleistung entities
                var repositoryDienstleistung = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);

                _dienstleistungen = new List<FsDienstleistung>
                {
                    GetNewDienstleistung("Test Dienstleistung 1", (decimal)1.5),
                    GetNewDienstleistung("Test Dienstleistung 2", (decimal)2.75),
                    GetNewDienstleistung("Test Dienstleistung 3", 3)
                };

                _dienstleistungen.ForEach(x => repositoryDienstleistung.ApplyChanges(x));

                unitOfWork.SaveChanges();
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
                IUnitOfWork unitOfWork = UnitOfWork.GetNew;
                var repositoryDienstleistung = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);

                // delete the entities that have not been deleted yet
                var dienstleistungenToDelete = _dienstleistungen.Where(dl => dl.ChangeTracker.State != ObjectState.Deleted).ToList();

                // Delete all Dienstleistungen
                dienstleistungenToDelete.ForEach(x => x.MarkAsDeleted());
                dienstleistungenToDelete.ForEach(x => repositoryDienstleistung.ApplyChanges(x));

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void DeleteData_Ok()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var service = new RelationTableServiceCRUDBase<FsDienstleistung>(); //Since ServiceCRUDBase was made abstract, we have to use RelationTableServiceCRUDBase

            // Act
            int count = CountDienstleistungen();
            var result = service.DeleteData(unitOfWork, _dienstleistungen[0]);
            count = CountDienstleistungen() - count;

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(-1, count);
        }

        [TestMethod]
        public void SaveData_validDienstleistung_returnOk()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var service = new RelationTableServiceCRUDBase<FsDienstleistung>(); //Since ServiceCRUDBase was made abstract, we have to use RelationTableServiceCRUDBase
            var dl = GetNewDienstleistungAndAddToList("Dienstleistung 1", 1);

            // Act
            int count = CountDienstleistungen();
            var serviceResult = service.SaveData(unitOfWork, dl);
            count = CountDienstleistungen() - count;

            // Assert
            Assert.IsTrue(serviceResult.IsOk);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void SaveData_validListOfDienstleistungen_returnOk()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var service = new RelationTableServiceCRUDBase<FsDienstleistung>(); //Since ServiceCRUDBase was made abstract, we have to use RelationTableServiceCRUDBase
            var dls = new List<FsDienstleistung>
            {
                GetNewDienstleistungAndAddToList("Dienstleistung 1", 1),
                GetNewDienstleistungAndAddToList("Dienstleistung 2", 2)
            };

            // Act
            int count = CountDienstleistungen();
            var serviceResult = service.SaveData(unitOfWork, dls);
            unitOfWork.SaveChanges();
            count = CountDienstleistungen() - count;

            // Assert
            Assert.IsTrue(serviceResult.IsOk);
            Assert.AreEqual(2, count);
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static int CountDienstleistungen()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var repository = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            return repository.Count();
        }

        private static FsDienstleistung GetNewDienstleistung(string name, decimal aufwand)
        {
            return new FsDienstleistung
            {
                Name = name,
                StandardAufwand = aufwand,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };
        }

        #endregion

        #region Private Methods

        private FsDienstleistung GetNewDienstleistungAndAddToList(string name, decimal aufwand)
        {
            var dl = GetNewDienstleistung(name, aufwand);
            _dienstleistungen.Add(dl);
            return dl;
        }

        #endregion

        #endregion
    }
}