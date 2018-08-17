using System;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Ba;
using Kiss.Infrastructure.IoC;
using Kiss.Model;
using Kiss.Model.DTO.BA;

namespace Kiss.BL.Test.Ba
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class BaDebitorSearchServiceTest
    {
        #region Fields

        #region Private Fields

        private BaAdresse _baAdresseInstitution;
        private BaAdresse _baAdressePerson;
        private BaInstitution _baInstitution;
        private BaPerson _baPerson;

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
            using (var ts = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;

                var personService = Container.Resolve<BaPersonService>();
                var institutionService = Container.Resolve<BaInstitutionService>();
                var adresseService = Container.Resolve<BaAdresseService>();

                // Person
                personService.NewData(out _baPerson);
                _baPerson.Name = "Person";
                _baPerson.Vorname = "Test";
                personService.SaveData(unitOfWork, _baPerson);

                // Adresse
                adresseService.NewData(out _baAdressePerson);
                _baAdressePerson.AdresseCode = 1;
                _baAdressePerson.BaPerson = _baPerson;
                _baAdressePerson.DatumVon = new DateTime(2010, 1, 1);
                _baAdressePerson.HausNr = "123";
                _baAdressePerson.Ort = "Bern";
                _baAdressePerson.PLZ = "3000";
                _baAdressePerson.Strasse = "Strasse";
                adresseService.SaveData(unitOfWork, _baAdressePerson);

                // Institution
                institutionService.NewData(out _baInstitution);
                _baInstitution.Name = "Test-Institution";
                _baInstitution.Debitor = true;
                institutionService.SaveData(unitOfWork, _baInstitution);

                // Adresse
                adresseService.NewData(out _baAdresseInstitution);
                _baAdresseInstitution.AdresseCode = 1;
                _baAdresseInstitution.BaInstitution = _baInstitution;
                _baAdresseInstitution.DatumVon = new DateTime(2010, 1, 1);
                _baAdresseInstitution.HausNr = "321";
                _baAdresseInstitution.Ort = "Zürich";
                _baAdresseInstitution.PLZ = "8000";
                _baAdresseInstitution.Strasse = "Weg";
                adresseService.SaveData(unitOfWork, _baAdresseInstitution);

                ts.Complete();
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

                var adresseService = Container.Resolve<BaAdresseService>();
                adresseService.DeleteData(unitOfWork, _baAdresseInstitution);
                adresseService.DeleteData(unitOfWork, _baAdressePerson);

                var institutionService = Container.Resolve<BaInstitutionService>();
                institutionService.DeleteData(unitOfWork, _baInstitution);

                var personService = Container.Resolve<BaPersonService>();
                personService.DeleteData(unitOfWork, _baPerson);

                transaction.Complete();
            }
        }

        [TestMethod]
        public void Test_Empty_Result()
        {
            var service = Container.Resolve<BaDebitorSearchService>();

            var result = service.SearchDebitor(null, "$!1234");

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Test_GetInstitution_ById()
        {
            // Arrange
            var service = Container.Resolve<BaDebitorSearchService>();

            // Act
            var debitor = service.GetDebitorInstitution(null, _baInstitution.BaInstitutionID);

            // Assert
            Assert.IsNotNull(debitor);
            Assert.AreEqual(_baInstitution.BaInstitutionID, debitor.BaInstitutionId);
            Assert.IsNull(debitor.BaPersonId);
            Assert.AreEqual(_baAdresseInstitution.HausNr, debitor.HausNr);
            Assert.AreEqual(_baInstitution.Name, debitor.InstitutionName);
            Assert.AreEqual(_baInstitution.Name, debitor.Name);
            Assert.AreEqual(_baAdresseInstitution.Ort, debitor.Ort);
            Assert.AreEqual(_baAdresseInstitution.PLZ, debitor.Plz);
            Assert.AreEqual(_baAdresseInstitution.Strasse, debitor.Strasse);
            Assert.AreEqual(debitor.Type, DebitorType.Institution);
        }

        [TestMethod]
        public void Test_GetPerson_ById()
        {
            // Arrange
            var service = Container.Resolve<BaDebitorSearchService>();

            // Act
            var debitor = service.GetDebitorPerson(null, _baPerson.BaPersonID);

            // Assert
            Assert.IsNotNull(debitor);
            Assert.AreEqual(debitor.BaPersonId, _baPerson.BaPersonID);
            Assert.IsNull(debitor.BaInstitutionId);
            Assert.AreEqual(_baAdressePerson.HausNr, debitor.HausNr);
            Assert.IsNull(debitor.InstitutionName);
            Assert.AreEqual(_baPerson.Name, debitor.Nachname);
            Assert.AreEqual(_baAdressePerson.Ort, debitor.Ort);
            Assert.AreEqual(_baAdressePerson.PLZ, debitor.Plz);
            Assert.AreEqual(_baAdressePerson.Strasse, debitor.Strasse);
            Assert.AreEqual(debitor.Type, DebitorType.Person);
            Assert.AreEqual(_baPerson.Vorname, debitor.Vorname);
        }

        [TestMethod]
        public void Test_Search_Institution()
        {
            var service = Container.Resolve<BaDebitorSearchService>();

            var result = service.SearchDebitor(null, "Test-Institution");

            Assert.AreEqual(1, result.Count);

            var inst = result[0];
            Assert.AreEqual(_baInstitution.BaInstitutionID, inst.BaInstitutionId);
            Assert.IsNull(inst.BaPersonId);
        }

        [TestMethod]
        public void Test_Search_Person()
        {
            var service = Container.Resolve<BaDebitorSearchService>();

            var result = service.SearchDebitor(null, "Person, Test");

            Assert.AreEqual(1, result.Count);

            var inst = result[0];
            Assert.AreEqual(_baPerson.BaPersonID, inst.BaPersonId);
            Assert.IsNull(inst.BaInstitutionId);
        }

        #endregion
    }
}