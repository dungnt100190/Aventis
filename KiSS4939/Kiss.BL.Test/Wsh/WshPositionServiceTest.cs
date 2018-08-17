using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.Interfaces.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Testing;
using Kiss.Model;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class WshPositionServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly KbuKontoHelper _kontoHelper = new KbuKontoHelper();
        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private List<WshPosition> _entitiesPosition;
        private List<WshPositionDebitor> _entitiesPositionDebitor;
        private List<WshPositionKreditor> _entitiesPositionKreditor;
        private FaLeistung _leistung1;
        private FaLeistung _leistung2;

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
                var repositoryPosition = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
                var repositoryPositionKreditor = UnitOfWork.GetRepository<WshPositionKreditor>(unitOfWork);
                var repositoryPositionDebitor = UnitOfWork.GetRepository<WshPositionDebitor>(unitOfWork);

                _leistung1 = _leistungHelper.Create(unitOfWork);
                _leistung2 = _leistungHelper.Create(unitOfWork);
                var konto = _kontoHelper.Create(unitOfWork);
                var person = _personHelper.Create(unitOfWork);
                var person1 = _personHelper.Create(unitOfWork);

                // Create some WshPosition entities
                _entitiesPosition = new List<WshPosition>
                {
                    // Leistung 1
                    new WshPosition
                    {
                        FaLeistung = _leistung1,
                        KbuKonto = konto,

                        MonatVon = new DateTime(2011, 1, 1),
                        MonatBis = new DateTime(2011, 1, 31),

                        BaPerson = person1,
                        WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe,
                        VerwPeriodeVon = new DateTime(2011, 1, 1),
                        VerwPeriodeBis = new DateTime(2011, 1, 31),
                        WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Valuta,
                        FaelligAm = DateTime.Today,
                        Betrag = 100,
                        Text = "Erste Position",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now,
                    },
                    new WshPosition
                    {
                        FaLeistung = _leistung1,
                        KbuKonto = konto,
                        MonatVon = new DateTime(2011, 2, 1),
                        MonatBis = new DateTime(2011, 2, 28),
                        WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe,
                        VerwPeriodeVon = new DateTime(2011, 2, 1),
                        VerwPeriodeBis = new DateTime(2011, 2, 28),
                        WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Valuta,
                        FaelligAm = DateTime.Today,
                        Betrag = 100,
                        Text = "Zweite Position",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now,
                    },
                    new WshPosition
                    {
                        FaLeistung = _leistung1,
                        KbuKonto = konto,
                        MonatVon =  new DateTime(2011, 2, 1),
                        MonatBis = new DateTime(2011,2,28),
                        WshKategorieID = (int)LOVsGenerated.WshKategorie.Einnahme,
                        VerwPeriodeVon = new DateTime(2011, 2, 1),
                        VerwPeriodeBis = new DateTime(2011, 2, 28),
                        WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Valuta,
                        FaelligAm = DateTime.Today,
                        Betrag = 100,
                        Text = "Dritte Position",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now,
                    },
                    // Leistung 2
                    new WshPosition
                    {
                        FaLeistung = _leistung2,
                        KbuKonto = konto,
                        MonatVon = new DateTime(2011,1,1),
                        MonatBis = new DateTime(2011,1,31),
                        WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe,
                        VerwPeriodeVon = new DateTime(2011, 1, 1),
                        VerwPeriodeBis = new DateTime(2011, 1, 31),
                        WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Valuta,
                        FaelligAm = DateTime.Today,
                        Betrag = 100,
                        Text = "Erste Position",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now,
                    },
                    new WshPosition
                    {
                        FaLeistung = _leistung2,
                        KbuKonto = konto,
                        MonatVon = new DateTime(2011,2,1),
                        MonatBis = new DateTime(2011,2,28),
                        WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe,
                        VerwPeriodeVon = new DateTime(2011, 2, 1),
                        VerwPeriodeBis = new DateTime(2011, 2, 28),
                        WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Valuta,
                        FaelligAm = DateTime.Today,
                        Betrag = 100,
                        Text = "Zweite Position",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now,
                    },
                };

                _entitiesPosition.ForEach(repositoryPosition.ApplyChanges);
                unitOfWork.SaveChanges();
                _entitiesPosition.ForEach(x => x.AcceptChanges());

                // Create some WshPositionKreditor entities
                _entitiesPositionKreditor = new List<WshPositionKreditor>
                {
                    new WshPositionKreditor
                    {
                        WshPosition = _entitiesPosition[0],
                        MitteilungZeile1 = "mitteilung 1",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now,
                    },
                    new WshPositionKreditor
                    {
                        WshPosition = _entitiesPosition[1],
                        MitteilungZeile1 = "mitteilung 1",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now,
                    },
                };

                _entitiesPositionKreditor.ForEach(repositoryPositionKreditor.ApplyChanges);
                unitOfWork.SaveChanges();
                _entitiesPositionKreditor.ForEach(x => x.AcceptChanges());

                // Create some WshPositionDebitor entities
                _entitiesPositionDebitor = new List<WshPositionDebitor>
                {
                    new WshPositionDebitor
                    {
                        WshPosition = _entitiesPosition[2],
                        BaPerson = person,
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now,
                    },
                };

                _entitiesPositionDebitor.ForEach(repositoryPositionDebitor.ApplyChanges);
                unitOfWork.SaveChanges();
                _entitiesPositionDebitor.ForEach(x => x.AcceptChanges());

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
                var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
                var repositoryKreditor = UnitOfWork.GetRepository<WshPositionKreditor>(unitOfWork);
                var repositoryDebitor = UnitOfWork.GetRepository<WshPositionDebitor>(unitOfWork);

                // Delete the temporary test objects
                _entitiesPositionDebitor.ForEach(x => x.MarkAsDeleted());
                _entitiesPositionDebitor.ForEach(repositoryDebitor.ApplyChanges);
                unitOfWork.SaveChanges();

                _entitiesPositionKreditor.ForEach(x => x.MarkAsDeleted());
                _entitiesPositionKreditor.ForEach(repositoryKreditor.ApplyChanges);
                unitOfWork.SaveChanges();

                _entitiesPosition.ForEach(x => x.MarkAsDeleted());
                _entitiesPosition.ForEach(repository.ApplyChanges);
                unitOfWork.SaveChanges();

                _personHelper.Delete(unitOfWork);
                _kontoHelper.Delete(unitOfWork);
                _leistungHelper.Delete(unitOfWork);

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void DoPositionenExist_DatumVonEqualPosDatumBis_DatumBisIsNull_Exklusive_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            bool result = service.DoPositionenExist(null, entity.FaLeistungID, entity.BaPersonID ?? -1, new DateTime(2011, 01, 31), null, false);

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_DatumVonEqualPosDatumBis_DatumBisIsNull_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            bool result = service.DoPositionenExist(null, entity.FaLeistungID, entity.BaPersonID ?? -1, new DateTime(2011, 01, 31), null, true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_DatumVonEqualPosDatumVon_DatumBisEqualPosDatumBis_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            bool result = service.DoPositionenExist(null, entity.FaLeistungID, entity.BaPersonID ?? -1, new DateTime(2011, 01, 01), new DateTime(2011, 01, 31), true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_DatumVonIsNull_DatumBisEqualPosDatumVon_Exklusive_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            bool result = service.DoPositionenExist(null, entity.FaLeistungID, entity.BaPersonID ?? -1, null, new DateTime(2011, 01, 01), false);

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_DatumVonIsNull_DatumBisEqualPosDatumVon_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            bool result = service.DoPositionenExist(null, entity.FaLeistungID, entity.BaPersonID ?? -1, null, new DateTime(2011, 01, 01), true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_DatumVonIsNull_DatumBisGreater_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            bool result = service.DoPositionenExist(null, entity.FaLeistungID, entity.BaPersonID ?? -1, null, new DateTime(2011, 02, 28), true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_DatumVonLess_DatumBisGreater_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            bool result = service.DoPositionenExist(null, entity.FaLeistungID, entity.BaPersonID ?? -1, new DateTime(2010, 12, 15), new DateTime(2011, 02, 28), true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_DatumVonLess_DatumBisIsNull_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            bool result = service.DoPositionenExist(null, entity.FaLeistungID, entity.BaPersonID ?? -1, new DateTime(2010, 12, 15), null, true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void GetByFaLeistungID_HasPositionWithFaLeistungAndJahrMonatCheckDebitor_ReturnList()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[2];

            // Act
            var result = service.GetByFaLeistungID(null, _leistung1.FaLeistungID, 2011, 2);
            var position = result.Where(x => x.WshPositionID == entity.WshPositionID).SingleOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(x => x.WshPositionID == entity.WshPositionID));
            Assert.IsNotNull(position);
            Assert.AreEqual(0, position.WshPositionKreditor.Count());
            Assert.AreEqual(1, position.WshPositionDebitor.Count());
        }

        [TestMethod]
        public void GetByFaLeistungID_HasPositionWithFaLeistungAndJahrMonatCheckKreditor_ReturnList()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[1];

            // Act
            var result = service.GetByFaLeistungID(null, _leistung1.FaLeistungID, 2011, 2);
            var position = result.Where(x => x.WshPositionID == entity.WshPositionID).SingleOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(x => x.WshPositionID == entity.WshPositionID));
            Assert.IsNotNull(position);
            Assert.AreEqual(1, position.WshPositionKreditor.Count());
            Assert.AreEqual(0, position.WshPositionDebitor.Count());
        }

        [TestMethod]
        public void GetByFaLeistungID_HasPositionWithFaLeistungAndJahrMonat_ReturnList()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[1];

            // Act
            var result = service.GetByFaLeistungID(null, _leistung1.FaLeistungID, 2011, 2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(x => x.WshPositionID == entity.WshPositionID));
        }

        [TestMethod]
        public void GetByFaLeistungID_HasPositionWithFaLeistungCheckDebitor_ReturnList()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[2];

            // Act
            var result = service.GetByFaLeistungID(null, _leistung1.FaLeistungID);
            var position = result.Where(x => x.WshPositionID == entity.WshPositionID).SingleOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.IsTrue(result.Any(x => x.WshPositionID == entity.WshPositionID));
            Assert.IsNotNull(position);
            Assert.AreEqual(0, position.WshPositionKreditor.Count());
            Assert.AreEqual(1, position.WshPositionDebitor.Count());
        }

        [TestMethod]
        public void GetByFaLeistungID_HasPositionWithFaLeistungCheckKreditor_ReturnList()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            var result = service.GetByFaLeistungID(null, _leistung1.FaLeistungID);
            var position = result.Where(x => x.WshPositionID == entity.WshPositionID).SingleOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.IsTrue(result.Any(x => x.WshPositionID == entity.WshPositionID));
            Assert.IsNotNull(position);
            Assert.AreEqual(1, position.WshPositionKreditor.Count());
            Assert.AreEqual(0, position.WshPositionDebitor.Count());
        }

        [TestMethod]
        public void GetByFaLeistungID_HasPositionWithFaLeistung_ReturnList()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            var result = service.GetByFaLeistungID(null, _leistung1.FaLeistungID);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.IsTrue(result.Any(x => x.WshPositionID == entity.WshPositionID));
        }

        [TestMethod]
        public void GetByIdWith_ValidIdWithDebitor_ReturnAlsoDebitor()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[2];

            // Act
            var result = service.GetById(null, entity.WshPositionID);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(entity.WshPositionID, result.WshPositionID);
            Assert.AreEqual(0, result.WshPositionKreditor.Count());
            Assert.AreEqual(1, result.WshPositionDebitor.Count());
        }

        [TestMethod]
        public void GetByIdWith_ValidIdWithKreditor_ReturnAlsoKreditor()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            var result = service.GetById(null, entity.WshPositionID);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(entity.WshPositionID, result.WshPositionID);
            Assert.AreEqual(1, result.WshPositionKreditor.Count());
            Assert.AreEqual(0, result.WshPositionDebitor.Count());
        }

        [TestMethod]
        public void GetById_ValidId_IsOk()
        {
            // Arrange
            var service = Container.Resolve<WshPositionService>();
            var entity = _entitiesPosition[0];

            // Act
            var result = service.GetById(null, entity.WshPositionID);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(entity.WshPositionID, result.WshPositionID);
        }

        #endregion
    }
}