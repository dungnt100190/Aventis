using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Bde;
using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Bde
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class BdeLeistungsartServiceTest
    {
        #region Fields

        #region Private Fields

        private List<BDELeistungsart> _entities;

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
            // Create some temporary test objects and store the entities
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            IRepository<BDELeistungsart> repository = UnitOfWork.GetRepository<BDELeistungsart>(unitOfWork);

            SystemService.NewHistoryVersion(unitOfWork);

            _entities = new List<BDELeistungsart>
            {
                new BDELeistungsart
                {
                    Beschreibung = "Unit Beschreibung",
                    Bezeichnung = "Unit Bezeichnung",
                    DatumVon = new DateTime(1975, 01, 05),
                    DatumBis = new DateTime(2075, 01, 05)
                }
            };

            _entities.ForEach(x => repository.ApplyChanges(x));
            unitOfWork.SaveChanges();
            _entities.ForEach(x => x.AcceptChanges());
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;

            IRepository<BDELeistungsart> repository = UnitOfWork.GetRepository<BDELeistungsart>(unitOfWork);

            // Delete the temporary test objects
            _entities.ForEach(x => x.MarkAsDeleted());
            _entities.ForEach(x => repository.ApplyChanges(x));
            unitOfWork.SaveChanges();
        }

        [TestMethod]
        public void Test_GetData()
        {
            // Arrange
            var service = Container.Resolve<BdeLeistungsartService>();

            //Act
            ObservableCollection<BDELeistungsart> all = service.GetData(null);

            // Assert
            IEnumerable<BDELeistungsart> query = from x in all
                                                 where x.Bezeichnung == "Unit Bezeichnung"
                                                 where x.Beschreibung == "Unit Beschreibung"
                                                 select x;
            Assert.IsTrue(query.Count() > 0);
        }

        #endregion
    }
}