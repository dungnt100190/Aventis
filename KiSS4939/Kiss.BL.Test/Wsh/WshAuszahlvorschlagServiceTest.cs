using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.Infrastructure.Constant;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the WshAuszahlvorschlagService class.
    /// </summary>
    [TestClass]
    public class WshAuszahlvorschlagServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly KbuKontoHelper _kontoHelper = new KbuKontoHelper();
        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();
        private readonly WshPositionHelper _positionHelper = new WshPositionHelper();
        private readonly List<WshPosition> _positionen = new List<WshPosition>();
        private readonly DateTime _valutaDatum = DateTime.Today;
        private readonly BaZahlungswegHelper _zahlungswegHelper = new BaZahlungswegHelper();

        #endregion

        #region Private Fields

        private FaLeistung _leistung1;
        private FaLeistung _leistung2;
        private FaLeistung _leistung3;
        private FaLeistung _leistung4;
        private FaLeistung _leistung5;

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

                // Create Leistung
                _leistung1 = _leistungHelper.Create(unitOfWork);
                _leistung2 = _leistungHelper.Create(unitOfWork);
                _leistung3 = _leistungHelper.Create(unitOfWork);
                _leistung4 = _leistungHelper.Create(unitOfWork);
                _leistung5 = _leistungHelper.Create(unitOfWork);

                // Create Zahlungsweg
                var zahlungsweg1 = _zahlungswegHelper.Create(unitOfWork);
                var zahlungsweg2 = _zahlungswegHelper.Create(unitOfWork);

                // Create Konto
                var konto110 = _kontoHelper.Create(unitOfWork, "110", "GBL", LOVsGenerated.KbuKontoklasse.Aufwand);
                var konto130 = _kontoHelper.Create(unitOfWork, "130", "Miete", LOVsGenerated.KbuKontoklasse.Aufwand);
                var konto140 = _kontoHelper.Create(unitOfWork, "140", "KVG", LOVsGenerated.KbuKontoklasse.Aufwand);
                var konto870 = _kontoHelper.Create(unitOfWork, "870", "Rückerstattung", LOVsGenerated.KbuKontoklasse.Ertrag);

                // Create Person
                var person = _personHelper.Create(unitOfWork);

                // Lesitung 1 (1 Kreditor, 3 Ausgaben, 0 Einnahmen)
                // Create Ausgaben
                var position = _positionHelper.CreateAusgabe(
                    unitOfWork, _leistung1, 2011, 5, "GBL Lebensunterhalt", 500, konto110, null, zahlungsweg1, _valutaDatum);
                _positionen.Add(position);

                position = _positionHelper.CreateAusgabe(unitOfWork, _leistung1, 2011, 5, "Miete", 1100, konto130, null, zahlungsweg1, _valutaDatum);
                _positionen.Add(position);

                position = _positionHelper.CreateAusgabe(unitOfWork, _leistung1, 2011, 5, "KVG", 340, konto140, person, zahlungsweg1, _valutaDatum);
                _positionen.Add(position);

                // Lesitung 2 (1 Kreditor, 4 Ausgaben, 1 Einnahmen)
                // Create Ausgaben
                position = _positionHelper.CreateAusgabe(
                    unitOfWork, _leistung2, 2011, 4, "GBL Lebensunterhalt", 500, konto110, null, zahlungsweg1, _valutaDatum);
                _positionen.Add(position);

                position = _positionHelper.CreateAusgabe(
                    unitOfWork, _leistung2, 2011, 5, "GBL Lebensunterhalt", 500, konto110, null, zahlungsweg1, _valutaDatum);
                _positionen.Add(position);

                position = _positionHelper.CreateAusgabe(unitOfWork, _leistung2, 2011, 5, "Miete", 1100, konto130, null, zahlungsweg1, _valutaDatum);
                _positionen.Add(position);

                position = _positionHelper.CreateAusgabe(unitOfWork, _leistung2, 2011, 5, "KVG", 340, konto140, person, zahlungsweg1, _valutaDatum);
                _positionen.Add(position);

                // Create Einnahmen
                position = _positionHelper.CreateEinnahme(unitOfWork, _leistung2, 2011, 5, "Rückerstattung", 170, konto870, person);
                _positionen.Add(position);

                // Lesitung 3 (2 Kreditor, 2 + 1 Ausgaben, 0 Einnahmen)
                // Create Ausgaben
                position = _positionHelper.CreateAusgabe(unitOfWork, _leistung3, 2011, 4, "GBL Lebensunterhalt", 500, konto110, null, zahlungsweg1, _valutaDatum);
                _positionen.Add(position);

                position = _positionHelper.CreateAusgabe(unitOfWork, _leistung3, 2011, 5, "Miete", 1100, konto130, null, zahlungsweg1, _valutaDatum);
                _positionen.Add(position);

                position = _positionHelper.CreateAusgabe(unitOfWork, _leistung3, 2011, 5, "KVG", 340, konto140, person, zahlungsweg2, _valutaDatum);
                _positionen.Add(position);

                // Leistung 4 ohne Positionen

                // Leistung 5 Kreditor ohne Zahlungsweg
                position = _positionHelper.CreateAusgabe(unitOfWork, _leistung5, 2011, 4, "GBL Lebensunterhalt", 500, konto110, null, null, _valutaDatum);
                _positionen.Add(position);

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

                // Delete the temporary test objects
                _positionHelper.Delete(unitOfWork);
                _personHelper.Delete(unitOfWork);
                _zahlungswegHelper.Delete(unitOfWork);
                _kontoHelper.Delete(unitOfWork);
                _leistungHelper.Delete(unitOfWork);

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void GetAuszahlvorschlagPositionUndBeleg_LeistungMit1KreditorAusgabenUndEinnahmen_ReturnLists()
        {
            // Arrange
            var service = Container.Resolve<WshAuszahlvorschlagService>();
            var unitOfWork = UnitOfWork.GetNew;
            var faLeistungId = _leistung2.FaLeistungID;
            List<WshAuszahlvorschlagPositionDTO> offenePositionen;
            List<WshAuszahlvorschlagBelegDTO> belege;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            // Act
            var result = service.GetAuszahlvorschlagPositionUndBeleg(unitOfWork, faLeistungId, null, true, out offenePositionen, out belege);
            var verfuegbar = offenePositionen.Sum(x => x.Verfuegbar);
            var belegPositionen = belege.FirstOrDefault().BelegPositionen;
            var ausgaben = belegPositionen.Sum(x => x.Ausgabe);
            var einnahmen = belegPositionen.Sum(x => x.Einnahme);

            // Assert
            Assert.IsTrue(result, result);
            Assert.AreEqual(5, offenePositionen.Count());
            Assert.AreEqual(2270, verfuegbar);
            Assert.AreEqual(1, belege.Count());
            Assert.AreEqual(5, belege.FirstOrDefault().BelegPositionen.Count());
            Assert.AreEqual(2440, ausgaben);
            Assert.AreEqual(170, einnahmen);
            Assert.IsTrue(belege.All(b => b.Valuta == _valutaDatum));
        }

        [TestMethod]
        public void GetAuszahlvorschlagPositionUndBeleg_LeistungMit1KreditorAusgaben_ReturnLists()
        {
            // Arrange
            var service = Container.Resolve<WshAuszahlvorschlagService>();
            var unitOfWork = UnitOfWork.GetNew;
            var faLeistungId = _leistung1.FaLeistungID;
            List<WshAuszahlvorschlagPositionDTO> offenePositionen;
            List<WshAuszahlvorschlagBelegDTO> belege;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            // Act
            var result = service.GetAuszahlvorschlagPositionUndBeleg(unitOfWork, faLeistungId, null, true, out offenePositionen, out belege);
            var verfuegbar = offenePositionen.Sum(x => x.Verfuegbar);
            var belegPositionen = belege.FirstOrDefault().BelegPositionen;
            var ausgaben = belegPositionen.Sum(x => x.Ausgabe);
            var einnahmen = belegPositionen.Sum(x => x.Einnahme);

            // Assert
            Assert.IsTrue(result, result);
            Assert.AreEqual(3, offenePositionen.Count());
            Assert.AreEqual(1940, verfuegbar);
            Assert.AreEqual(1, belege.Count());
            Assert.AreEqual(3, belege.FirstOrDefault().BelegPositionen.Count());
            Assert.AreEqual(1940, ausgaben);
            Assert.AreEqual(0, einnahmen);
            Assert.IsTrue(belege.All(b => b.Valuta == _valutaDatum));
        }

        [TestMethod]
        public void GetAuszahlvorschlagPositionUndBeleg_LeistungMit1KreditorAusgaben_ReturnListsAndKreditorHasZahlungsweg()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }
            var service = Container.Resolve<WshAuszahlvorschlagService>();
            var faLeistungId = _leistung1.FaLeistungID;
            List<WshAuszahlvorschlagPositionDTO> offenePositionen;
            List<WshAuszahlvorschlagBelegDTO> belege;

            // Act
            var result = service.GetAuszahlvorschlagPositionUndBeleg(unitOfWork, faLeistungId, null, true, out offenePositionen, out belege);

            // Assert
            Assert.IsTrue(result, result);
            Assert.AreEqual(1, belege.Count());
        }

        [TestMethod]
        public void GetAuszahlvorschlagPositionUndBeleg_LeistungMit1KreditorOhneZahlungsweg_ReturnLists()
        {
            // Arrange
            var service = Container.Resolve<WshAuszahlvorschlagService>();
            var unitOfWork = UnitOfWork.GetNew;
            var faLeistungId = _leistung5.FaLeistungID;
            List<WshAuszahlvorschlagPositionDTO> offenePositionen;
            List<WshAuszahlvorschlagBelegDTO> belege;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            // Act
            var result = service.GetAuszahlvorschlagPositionUndBeleg(unitOfWork, faLeistungId, null, true, out offenePositionen, out belege);
            var verfuegbar = offenePositionen.Sum(x => x.Verfuegbar);
            var belegPositionen = belege.FirstOrDefault().BelegPositionen;
            var ausgaben = belegPositionen.Sum(x => x.Ausgabe);
            var einnahmen = belegPositionen.Sum(x => x.Einnahme);

            // Assert
            Assert.IsTrue(result, result);
            Assert.AreEqual(1, offenePositionen.Count());
            Assert.AreEqual(500, verfuegbar);
            Assert.AreEqual(1, belege.Count());
            Assert.AreEqual(1, belege.FirstOrDefault().BelegPositionen.Count());
            Assert.AreEqual(500, ausgaben);
            Assert.AreEqual(0, einnahmen);
            Assert.IsTrue(belege.All(b => b.Valuta == _valutaDatum));
        }

        [TestMethod]
        public void GetAuszahlvorschlagPositionUndBeleg_LeistungMit2KreditorAusgaben_ReturnLists()
        {
            // Arrange
            var service = Container.Resolve<WshAuszahlvorschlagService>();
            var unitOfWork = UnitOfWork.GetNew;
            var faLeistungId = _leistung3.FaLeistungID;
            List<WshAuszahlvorschlagPositionDTO> offenePositionen;
            List<WshAuszahlvorschlagBelegDTO> belege;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            // Act
            var result = service.GetAuszahlvorschlagPositionUndBeleg(unitOfWork, faLeistungId, null, true, out offenePositionen, out belege);
            var verfuegbar = offenePositionen.Sum(x => x.Verfuegbar);
            var ausgaben = belege.Sum(b => b.BelegPositionen.Sum(p => p.Ausgabe));
            var einnahmen = belege.Sum(b => b.BelegPositionen.Sum(p => p.Einnahme));

            // Assert
            Assert.IsTrue(result, result);
            Assert.AreEqual(3, offenePositionen.Count());
            Assert.AreEqual(1940, verfuegbar);
            Assert.AreEqual(2, belege.Count());
            Assert.AreEqual(3, belege[0].BelegPositionen.Count());
            Assert.AreEqual(1600, belege[0].BelegPositionen.Sum(x => x.Ausgabe));
            Assert.AreEqual(0, belege[0].BelegPositionen.Sum(x => x.Einnahme));
            Assert.AreEqual(3, belege[1].BelegPositionen.Count());
            Assert.AreEqual(340, belege[1].BelegPositionen.Sum(x => x.Ausgabe));
            Assert.AreEqual(0, belege[1].BelegPositionen.Sum(x => x.Einnahme));
            Assert.AreEqual(1940, ausgaben);
            Assert.AreEqual(0, einnahmen);
            Assert.IsTrue(belege.All(b => b.Valuta == _valutaDatum));
        }

        [TestMethod]
        public void GetAuszahlvorschlagPositionUndBeleg_LeistungOhnePositionen_ReturnEmptyLists()
        {
            // Arrange
            var service = Container.Resolve<WshAuszahlvorschlagService>();
            var unitOfWork = UnitOfWork.GetNew;
            var faLeistungId = _leistung4.FaLeistungID;
            List<WshAuszahlvorschlagPositionDTO> offenePositionen;
            List<WshAuszahlvorschlagBelegDTO> belege;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            // Act
            var result = service.GetAuszahlvorschlagPositionUndBeleg(unitOfWork, faLeistungId, null, true, out offenePositionen, out belege);

            // Assert
            Assert.IsTrue(result, result);
            Assert.AreEqual(0, offenePositionen.Count());
            Assert.AreEqual(0, belege.Count());
        }

        [TestMethod]
        public void HasOffenePositionen_LeistungMitPositionen_ReturnTrue()
        {
            // Arrange
            var service = Container.Resolve<WshAuszahlvorschlagService>();
            var unitOfWork = UnitOfWork.GetNew;
            var faLeistungId = _leistung1.FaLeistungID;

            // Act
            var hasOffenePositionen = service.HasOffenePositionen(unitOfWork, faLeistungId);

            // Assert
            Assert.IsTrue(hasOffenePositionen);
        }

        [TestMethod]
        public void HasOffenePositionen_LeistungOhnePositionen_ReturnFalse()
        {
            // Arrange
            var service = Container.Resolve<WshAuszahlvorschlagService>();
            var unitOfWork = UnitOfWork.GetNew;
            var faLeistungId = _leistung4.FaLeistungID;

            // Act
            var hasOffenePositionen = service.HasOffenePositionen(unitOfWork, faLeistungId);

            // Assert
            Assert.IsFalse(hasOffenePositionen);
        }

        #endregion
    }
}