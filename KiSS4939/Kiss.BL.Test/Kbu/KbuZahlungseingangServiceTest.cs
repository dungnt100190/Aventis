using System;
using System.Collections.Generic;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.BL.Test.Helpers;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Kbu
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class KbuZahlungseingangServiceTest
    {
        #region Fields

        #region Private Fields

        private BaPerson _baPerson;
        private BaPersonHelper _baPersonHelper;
        private FaLeistung _faLeistung;
        private FaLeistungHelper _faLeistungHelper;
        private List<KbuZahlungseingang> _entitiesKbuZahlungseingang;
        private List<SstZahlungseingang> _entitiesSstZahlungseingang;
        private List<SstZahlungseingangLauf> _entitiesSstZahlungseingangLauf;

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

                // BaPerson
                _baPersonHelper = new BaPersonHelper();
                _baPerson = _baPersonHelper.Create(unitOfWork);

                // FaLeistung
                _faLeistungHelper = new FaLeistungHelper();
                _faLeistung = _faLeistungHelper.Create(unitOfWork);

                // KbuZahlungseingang
                var repositoryKbuZahlungseingang = UnitOfWork.GetRepository<KbuZahlungseingang>(unitOfWork);

                _entitiesKbuZahlungseingang = new List<KbuZahlungseingang>
                {
                    new KbuZahlungseingang
                    {
                        DatumZahlungseingang = DateTime.Now,
                        Betrag = 10,
                        Mitteilung = "TestZe01",
                        KbuZahlungseingangTeamCode = 1, // Krankenkasse
                        Ausgeglichen = false,
                        Creator = "TestInitialize",
                        Created = DateTime.Now,
                        Modifier = "TestInitialize",
                        Modified = DateTime.Now
                    },
                    new KbuZahlungseingang
                    {
                        DatumZahlungseingang = DateTime.Now,
                        Betrag = 20,
                        Mitteilung = "TestZe02",
                        KbuZahlungseingangTeamCode = 2, // AHV/IV
                        Ausgeglichen = true,
                        Creator = "TestInitialize",
                        Created = DateTime.Now,
                        Modifier = "TestInitialize",
                        Modified = DateTime.Now
                    },
                    new KbuZahlungseingang
                    {
                        FaFall = _faLeistung.FaFall,
                        BaPersonID_Betrifft = _baPerson.BaPersonID,
                        DatumZahlungseingang = DateTime.Now,
                        Betrag = 30,
                        Mitteilung = "TestZe03",
                        KbuZahlungseingangTeamCode = 3, // Amt für Zusatzleistungen
                        Ausgeglichen = false,
                        Creator = "TestInitialize",
                        Created = DateTime.Now,
                        Modifier = "TestInitialize",
                        Modified = DateTime.Now
                    }
                };

                _entitiesKbuZahlungseingang.ForEach(repositoryKbuZahlungseingang.ApplyChanges);
                unitOfWork.SaveChanges();
                _entitiesKbuZahlungseingang.ForEach(x => x.AcceptChanges());

                // SstZahlungseingangLauf
                var repositorySstZahlungseingangLauf = UnitOfWork.GetRepository<SstZahlungseingangLauf>(unitOfWork);

                _entitiesSstZahlungseingangLauf = new List<SstZahlungseingangLauf>
                {
                    new SstZahlungseingangLauf
                    {
                        Start = DateTime.Now,
                        Ende = DateTime.Now.AddMinutes(1),
                        AbholungErfolgreich = true,
                        EinfuegenErfolgreich = true,
                        Creator = "TestInitialize",
                        Created = DateTime.Now,
                        Modifier = "TestInitialize",
                        Modified = DateTime.Now
                    }
                };

                _entitiesSstZahlungseingangLauf.ForEach(repositorySstZahlungseingangLauf.ApplyChanges);
                unitOfWork.SaveChanges();
                _entitiesSstZahlungseingangLauf.ForEach(x => x.AcceptChanges());

                // SstZahlungseingang
                var repositorySstZahlungseingang = UnitOfWork.GetRepository<SstZahlungseingang>(unitOfWork);

                _entitiesSstZahlungseingang = new List<SstZahlungseingang>
                {
                    new SstZahlungseingang
                    {
                        SstZahlungseingangLauf = _entitiesSstZahlungseingangLauf[0],
                        KbuZahlungseingang = _entitiesKbuZahlungseingang[0],
                        PAYMENT_LOT = "AB20110828",
                        PAYMENT_LOT_POS = "1",
                        AMOUNT_LOC_CURR = 10,
                        PAYMENT_TEXT = "TestSstZe01",
                        Creator = "TestInitialize",
                        Created = DateTime.Now,
                        Modifier = "TestInitialize",
                        Modified = DateTime.Now
                    },
                    new SstZahlungseingang
                    {
                        SstZahlungseingangLauf = _entitiesSstZahlungseingangLauf[0],
                        KbuZahlungseingang = _entitiesKbuZahlungseingang[1],
                        PAYMENT_LOT = "AB20110828",
                        PAYMENT_LOT_POS = "2",
                        AMOUNT_LOC_CURR = 20,
                        PAYMENT_TEXT = "TestSstZe02",
                        Creator = "TestInitialize",
                        Created = DateTime.Now,
                        Modifier = "TestInitialize",
                        Modified = DateTime.Now
                    },
                    new SstZahlungseingang
                    {
                        SstZahlungseingangLauf = _entitiesSstZahlungseingangLauf[0],
                        KbuZahlungseingang = _entitiesKbuZahlungseingang[2],
                        PAYMENT_LOT = "WS20110828",
                        PAYMENT_LOT_POS = "1",
                        AMOUNT_LOC_CURR = 30,
                        PAYMENT_TEXT = "TestSstZe03",
                        Creator = "TestInitialize",
                        Created = DateTime.Now,
                        Modifier = "TestInitialize",
                        Modified = DateTime.Now
                    }
                };

                _entitiesSstZahlungseingang.ForEach(repositorySstZahlungseingang.ApplyChanges);
                unitOfWork.SaveChanges();
                _entitiesSstZahlungseingang.ForEach(x => x.AcceptChanges());

                // done
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
                var repositoryKbuZahlungseingang = UnitOfWork.GetRepository<KbuZahlungseingang>(unitOfWork);
                var repositorySstZahlungseingang = UnitOfWork.GetRepository<SstZahlungseingang>(unitOfWork);
                var repositorySstZahlungseingangLauf = UnitOfWork.GetRepository<SstZahlungseingangLauf>(unitOfWork);

                // Delete the temporary test objects
                _entitiesSstZahlungseingang.ForEach(x => x.MarkAsDeleted());
                _entitiesSstZahlungseingang.ForEach(repositorySstZahlungseingang.ApplyChanges);

                _entitiesSstZahlungseingangLauf.ForEach(x => x.MarkAsDeleted());
                _entitiesSstZahlungseingangLauf.ForEach(repositorySstZahlungseingangLauf.ApplyChanges);

                _entitiesKbuZahlungseingang.ForEach(x => x.MarkAsDeleted());
                _entitiesKbuZahlungseingang.ForEach(repositoryKbuZahlungseingang.ApplyChanges);

                _baPersonHelper.Delete(unitOfWork);
                _faLeistungHelper.Delete(unitOfWork);

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void Search_SearchingZahlungseingangAllData_ResultContainsAllData()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungseingangService>();

            // Act
            var result = service.SearchZahlungseingang(null, null, null, false, false);

            // Assert
            Assert.AreEqual(_entitiesKbuZahlungseingang.Count, result.Count);
        }

        [TestMethod]
        public void Search_SearchingZahlungseingangByNurNichtZugeordnet_ResultFilteredByNurNichtZugeordnet()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungseingangService>();

            // Act
            var result = service.SearchZahlungseingang(null, null, null, false, true);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(false, result[0].FaFallID.HasValue);
            Assert.AreEqual(false, result[1].FaFallID.HasValue);
        }

        [TestMethod]
        public void Search_SearchingZahlungseingangByNurOffeneZe_ResultFilteredByNurOffeneZe()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungseingangService>();

            // Act
            var result = service.SearchZahlungseingang(null, null, null, true, false);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(false, result[0].Ausgeglichen);
            Assert.AreEqual(false, result[1].Ausgeglichen);
        }

        [TestMethod]
        public void Search_SearchingZahlungseingangByZahlstapel_ResultFilteredByZahlstapel()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungseingangService>();

            // Act
            var result = service.SearchZahlungseingang(null, "WS", null, false, false);

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Search_SearchingZahlungseingangByZahlstapel_ResultFilteredByZahlstapelNoData()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungseingangService>();

            // Act
            var result = service.SearchZahlungseingang(null, "XYZ", null, false, false);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        public void Search_SearchingZahlungseingangByZahlstapel_ResultFilteredByBetrag()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungseingangService>();

            // Act
            var result = service.SearchZahlungseingang(null, "30", null, false, false);

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        public void Search_SearchingZahlungseingangByZahlstapel_ResultFilteredByBetragNoData()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungseingangService>();

            // Act
            var result = service.SearchZahlungseingang(null, "99", null, false, false);

            // Assert
            Assert.AreEqual(1, result.Count);
        }

                public void Search_SearchingZahlungseingangByZahlstapel_ResultFilteredByMitteilung()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungseingangService>();

            // Act
            var result = service.SearchZahlungseingang(null, "TestZe03", null, false, false);

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        public void Search_SearchingZahlungseingangByZahlstapel_ResultFilteredByMitteilungNoData()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungseingangService>();

            // Act
            var result = service.SearchZahlungseingang(null, "SomeNonsenseMitteilung", null, false, false);

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Search_SearchingZahlungseingangByZeTeam_ResultFilteredByZeTeam()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungseingangService>();

            // Act
            var result = service.SearchZahlungseingang(null, null, 1, false, false);

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        #endregion
    }
}