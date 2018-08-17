using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Ba;
using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Test.Ba
{
    /// <summary>
    /// Summary description for BaPersonServiceTest
    /// </summary>
    [TestClass]
    public class BaPersonServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private int _personID;
        private IRepository<BaAdresse> _repositoryAdresse;
        private IRepository<BaPerson> _repositoryPerson;

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
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            _repositoryPerson = Container.Resolve<IRepository<BaPerson>>(unitOfWork);
            _repositoryAdresse = Container.Resolve<IRepository<BaAdresse>>(unitOfWork);

            SystemService.NewHistoryVersion(unitOfWork);

            var person = new BaPerson
            {
                Name = "NameTest",
                Vorname = "VornameTest",
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };
            _repositoryPerson.ApplyChanges(person);

            var adresse = new BaAdresse
            {
                BaPersonID = person.BaPersonID,
                PLZ = "3018",
                Ort = "Bern",
                Strasse = "Bahnhofstrasse",
                Creator = "test",
                Created = DateTime.Now,
                Modifier = "test",
                Modified = DateTime.Now
            };
            adresse.BaPerson = person;
            _repositoryAdresse.ApplyChanges(adresse);

            unitOfWork.SaveChanges();

            _personID = person.BaPersonID;
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
            _repositoryPerson = Container.Resolve<IRepository<BaPerson>>(unitOfWork);
            _repositoryAdresse = UnitOfWork.GetRepository<BaAdresse>(unitOfWork);

            // Delete BaAdresse
            var personService = Container.Resolve<BaPersonService>();
            BaPerson personToDelete;

            try
            {
                personToDelete = personService.GetByIdWithBaAdresse(unitOfWork, _personID);
            }
            catch (EntityNotFoundException)
            {
                personToDelete = null;
            }

            if (personToDelete != null)
            {
                List<BaAdresse> adresseToDeleteList = personToDelete.BaAdresse.ToList();
                adresseToDeleteList.ForEach(x => x.MarkAsDeleted());
                adresseToDeleteList.ForEach(x => _repositoryAdresse.ApplyChanges(x));

                personToDelete.MarkAsDeleted();
                _repositoryPerson.ApplyChanges(personToDelete);
                unitOfWork.SaveChanges();
            }
        }

        [TestMethod]
        public void DeleteData_personExists_returnOk()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var personService = Container.Resolve<BaPersonService>();
            BaPerson personToDelete = personService.GetById(unitOfWork, _personID);

            // Act
            var serviceResult = personService.DeleteData(unitOfWork, personToDelete);

            // Assert
            Assert.IsTrue(serviceResult.IsOk);
        }

        [TestMethod]
        public void GetByIdWithAdresse_validId_returnPersonWithAdresse()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var personService = Container.Resolve<BaPersonService>();

            // Act
            BaPerson personRes = personService.GetByIdWithBaAdresse(unitOfWork, _personID);
            var adressen = personRes.BaAdresse.ToList();

            // Assert
            Assert.IsNotNull(personRes);
            Assert.AreEqual("NameTest", personRes.Name);
            Assert.IsNotNull(adressen);
            Assert.AreEqual(1, adressen.Count());
            Assert.AreEqual("3018", adressen[0].PLZ);
        }

        [TestMethod]
        public void GetById_validId_returnPerson()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var personService = Container.Resolve<BaPersonService>();

            // Act
            BaPerson personRes = personService.GetById(unitOfWork, _personID);

            // Assert
            Assert.IsNotNull(personRes);
            Assert.AreEqual("NameTest", personRes.Name);
        }

        [TestMethod]
        public void NewData_createNewPerson_returnOk()
        {
            // Arrange
            var personService = Container.Resolve<BaPersonService>();
            BaPerson personNew;

            // Act
            var serviceResult = personService.NewData(out personNew);

            // Assert
            Assert.IsTrue(serviceResult.IsOk);
            Assert.IsNotNull(personNew);
        }

        [TestMethod]
        public void SaveData_validPerson_returnOk()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var personService = Container.Resolve<BaPersonService>();
            BaPerson person = personService.GetById(unitOfWork, _personID);

            // Act
            var serviceResult = personService.SaveData(unitOfWork, person);

            // Assert
            Assert.IsTrue(serviceResult.IsOk);
        }

        [TestMethod]
        public void SearchWithAdresse_validName_ListNotEmpty()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var personService = Container.Resolve<BaPersonService>();

            // Act
            var persons = personService.Search(unitOfWork, "NameTest");

            // Assert
            Assert.IsTrue(persons.Count > 0);
        }

        #endregion
    }
}