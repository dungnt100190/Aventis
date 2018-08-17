using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.Infrastructure.Constant;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;

namespace Kiss.BL.Test.Kbu
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class KbuErwarteteEinnahmeServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly KbuErwarteteEinnahmeAusgleichHelper _ausgleichHelper = new KbuErwarteteEinnahmeAusgleichHelper();
        private readonly KbuKontoHelper _kontoHelper = new KbuKontoHelper();
        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();
        private readonly WshPositionHelper _wshPositionHelper = new WshPositionHelper();

        #endregion

        #region Private Fields

        private KbuKonto _kontoLohn;
        private KbuKonto _kontoRente;
        private FaLeistung _leistung;
        private List<BaPerson> _personen;

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

                _kontoLohn = _kontoHelper.Create(unitOfWork, "850", "Erwerbslohn", LOVsGenerated.KbuKontoklasse.Ertrag);
                _kontoRente = _kontoHelper.Create(unitOfWork, "860", "Rente", LOVsGenerated.KbuKontoklasse.Ertrag);
                _leistung = _leistungHelper.Create(unitOfWork);
                _personen = _personHelper.Create(unitOfWork, 5);

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

                _ausgleichHelper.Delete(unitOfWork);
                _wshPositionHelper.Delete(unitOfWork);
                _leistungHelper.Delete(unitOfWork);
                _kontoHelper.Delete(unitOfWork);
                _personHelper.Delete(unitOfWork);

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void Test_GetErwarteteEinnahme()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            var personDebitor = _personen[4];
            var budgetMonat = new MonthYear(2011, 3);
            var buchungsText = "Lohn von Müller & Co.";
            var einnahmePosition = _wshPositionHelper.CreateEinnahme(unitOfWork, _leistung, budgetMonat.Year, budgetMonat.Month, buchungsText, 1300m, _kontoLohn, _personen[1], personDebitor, true);
            var service = Container.Resolve<KbuErwarteteEinnahmeService>();

            // Act
            var einnahmen = service.GetOffeneErwarteteEinnahmenByFaFallID(unitOfWork, _leistung.FaFallID, true, null, null, null);

            // Assert
            Assert.IsNotNull(einnahmen);
            Assert.AreEqual(1, einnahmen.Count);
            var einnahme = einnahmen.Single();
            Assert.AreEqual(einnahmePosition.Betrag, einnahme.BetragTotal);
            Assert.AreEqual(einnahmePosition.Betrag, einnahme.BetragOffen);
            Assert.AreEqual(0m, einnahme.BetragAuszugleichen);
            Assert.AreEqual(null, einnahme.BaInstitutionIDDebitor);
            Assert.AreEqual(personDebitor.BaPersonID, einnahme.BaPersonIDDebitor);
            Assert.AreEqual(personDebitor.NameVorname, einnahme.DebitorText);
            Assert.AreEqual(_kontoLohn.KontoNr, einnahme.KontoNr);
            Assert.AreEqual(_kontoLohn.KbuKontoID, einnahme.KbuKontoID);
            Assert.AreEqual(new TimePeriod(budgetMonat), einnahme.Verwendungsperiode);
            Assert.AreEqual(einnahmePosition.WshPositionID, einnahme.WshPositionID);
            Assert.AreEqual(buchungsText, einnahme.Text);
        }

        [TestMethod]
        public void Test_GetTeilausgeglicheneErwarteteEinnahme()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            var personDebitor = _personen[4];
            var budgetMonat = new MonthYear(2011, 3);
            var buchungsText = "Lohn von Müller & Co.";
            var einnahmePosition = _wshPositionHelper.CreateEinnahme(unitOfWork, _leistung, budgetMonat.Year, budgetMonat.Month, buchungsText, 1300m, _kontoLohn, _personen[1], personDebitor, true);
            var service = Container.Resolve<KbuErwarteteEinnahmeService>();

            var ausgleiche = _ausgleichHelper.CreateAusgleich(unitOfWork, new[] { einnahmePosition, einnahmePosition }, new[] { 600m, 300m });

            // Act
            var einnahmen = service.GetOffeneErwarteteEinnahmenByFaFallID(unitOfWork, _leistung.FaFallID, true, null, null, null);

            // Assert
            Assert.IsNotNull(einnahmen);
            Assert.AreEqual(1, einnahmen.Count);
            var einnahme = einnahmen.Single();
            Assert.AreEqual(einnahmePosition.Betrag, einnahme.BetragTotal);
            Assert.AreEqual(einnahmePosition.Betrag - ausgleiche.KbuBelegPosition.Sum(a => a.BetragBrutto), einnahme.BetragOffen);
            Assert.AreEqual(0m, einnahme.BetragAuszugleichen);
            Assert.AreEqual(null, einnahme.BaInstitutionIDDebitor);
            Assert.AreEqual(personDebitor.BaPersonID, einnahme.BaPersonIDDebitor);
            Assert.AreEqual(personDebitor.NameVorname, einnahme.DebitorText);
            Assert.AreEqual(_kontoLohn.KontoNr, einnahme.KontoNr);
            Assert.AreEqual(_kontoLohn.KbuKontoID, einnahme.KbuKontoID);
            Assert.AreEqual(new TimePeriod(budgetMonat), einnahme.Verwendungsperiode);
            Assert.AreEqual(einnahmePosition.WshPositionID, einnahme.WshPositionID);
            Assert.AreEqual(buchungsText, einnahme.Text);
        }

        #endregion
    }
}