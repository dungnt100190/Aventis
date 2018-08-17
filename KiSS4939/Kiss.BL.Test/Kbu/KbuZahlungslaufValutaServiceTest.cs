using System;
using System.Collections.Generic;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Kbu
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class KbuZahlungslaufValutaServiceTest
    {
        #region Fields

        #region Private Fields

        private List<KbZahlungslaufValuta> _entities;

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
                var repository = UnitOfWork.GetRepository<KbZahlungslaufValuta>(unitOfWork);

                _entities = new List<KbZahlungslaufValuta>
                {
                    new KbZahlungslaufValuta
                    {
                        Jahr = 2011,
                        Monat = 5,
                        DatMonatlich = new DateTime(2011, 04, 24),
                        DatTeil1 = new DateTime(2011, 04, 25),
                        DatTeil2 = new DateTime(2011, 05, 10),
                        Dat14Tage1 = new DateTime(2011, 04, 1),
                        Dat14Tage2 = new DateTime(2011, 04, 15),
                        Dat14Tage3 = new DateTime(2011, 04, 22),
                        DatWoche1 = new DateTime(2011, 04, 5),
                        DatWoche2 = new DateTime(2011, 04, 11),
                        DatWoche3 = new DateTime(2011, 04, 18),
                        DatWoche4 = new DateTime(2011, 04, 23),
                        DatWoche5 = new DateTime(2011, 04, 28),
                    },
                                        new KbZahlungslaufValuta
                    {
                        Jahr = 2011,
                        Monat = 6,
                    },
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
                var repository = UnitOfWork.GetRepository<KbZahlungslaufValuta>(unitOfWork);

                // Delete the temporary test objects
                _entities.ForEach(x => x.MarkAsDeleted());
                _entities.ForEach(x => repository.ApplyChanges(x));

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void GetValutaDatum_14Taeglich_return3Datum()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungslaufValutaService>();

            // Act
            var result = service.GetValutaDatum(null, LOVsGenerated.WshPeriodizitaet._14Taeglich, 2011, 5);

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(new DateTime(2011, 04, 1), result[0]);
            Assert.AreEqual(new DateTime(2011, 04, 15), result[1]);
            Assert.AreEqual(new DateTime(2011, 04, 22), result[2]);
        }

        [TestMethod]
        public void GetValutaDatum_1xProMonat_return1Datum()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungslaufValutaService>();

            // Act
            var result = service.GetValutaDatum(null, LOVsGenerated.WshPeriodizitaet._1xProMonat, 2011, 5);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(new DateTime(2011, 04, 24), result[0]);
        }

        [TestMethod]
        public void GetValutaDatum_1xProMonat_returnEmptyList()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungslaufValutaService>();

            // Act
            var result = service.GetValutaDatum(null, LOVsGenerated.WshPeriodizitaet._1xProMonat, 2011, 6);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetValutaDatum_2xProMonat_return2Datum()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungslaufValutaService>();

            // Act
            var result = service.GetValutaDatum(null, LOVsGenerated.WshPeriodizitaet._2xProMonat, 2011, 5);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(new DateTime(2011, 04, 25), result[0]);
            Assert.AreEqual(new DateTime(2011, 05, 10), result[1]);
        }

        [TestMethod]
        public void GetValutaDatum_Valuta_returnEmptyList()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungslaufValutaService>();

            // Act
            var result = service.GetValutaDatum(null, LOVsGenerated.WshPeriodizitaet.Valuta, 2011, 5);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetValutaDatum_Wochentag_return22Datum()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungslaufValutaService>();

            // Act
            var result = service.GetValutaDatum(null, LOVsGenerated.WshPeriodizitaet.Wochentage, 2011, 5);

            // Assert
            Assert.AreEqual(22, result.Count);
            Assert.AreEqual(new DateTime(2011, 05, 2), result[0]);
            Assert.AreEqual(new DateTime(2011, 05, 31), result[21]);
        }

        [TestMethod]
        public void GetValutaDatum_Woechentlich_return5Datum()
        {
            // Arrange
            var service = Container.Resolve<KbuZahlungslaufValutaService>();

            // Act
            var result = service.GetValutaDatum(null, LOVsGenerated.WshPeriodizitaet.Woechentlich, 2011, 5);

            // Assert
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(new DateTime(2011, 04, 5), result[0]);
            Assert.AreEqual(new DateTime(2011, 04, 11), result[1]);
            Assert.AreEqual(new DateTime(2011, 04, 18), result[2]);
            Assert.AreEqual(new DateTime(2011, 04, 23), result[3]);
            Assert.AreEqual(new DateTime(2011, 04, 28), result[4]);
        }

        #endregion
    }
}