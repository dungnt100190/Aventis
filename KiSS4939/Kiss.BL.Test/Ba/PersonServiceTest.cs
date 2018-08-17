using System;

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
    /// Summary description for PersonServiceTest
    /// </summary>
    [TestClass]
    [Obsolete]
    public class PersonServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private IRepository<BaPerson> _repositoryPerson;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestMethod]
        public void Test_AddPerson_GetPerson_DeletePerson_Via_Different_UnitOfWork()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            _repositoryPerson = Container.Resolve<IRepository<BaPerson>>(unitOfWork);

            // Act - Add person
            var person = new BaPerson
            {
                BaPersonID = 1000001,
                Name = "NameTest",
                Vorname = "VornameTest",
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };
            SystemService.NewHistoryVersion(unitOfWork);
            _repositoryPerson.ApplyChanges(person);
            unitOfWork.SaveChanges();

            // Act - Get person
            unitOfWork = UnitOfWork.GetNew;
            var personService = Container.Resolve<BaPersonService>();
            BaPerson personToDelete = personService.GetById(unitOfWork, person.BaPersonID);

            // Act - Delete person
            unitOfWork = UnitOfWork.GetNew;
            _repositoryPerson = Container.Resolve<IRepository<BaPerson>>(unitOfWork);
            personToDelete.MarkAsDeleted();
            _repositoryPerson.ApplyChanges(personToDelete);
            unitOfWork.SaveChanges();

            // Act - Try get deleted person
            BaPerson personDeleted;
            unitOfWork = UnitOfWork.GetNew;
            try
            {
                personDeleted = personService.GetById(unitOfWork, personToDelete.BaPersonID);
            }
            catch (EntityNotFoundException)
            {
                personDeleted = null;
            }

            // Assert
            Assert.IsNull(personDeleted);
        }

        [TestMethod]
        public void Test_AddPerson_GetPerson_UpdatePerson_Via_Different_UnitOfWork()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            _repositoryPerson = Container.Resolve<IRepository<BaPerson>>(unitOfWork);

            // Act - Add person
            var person = new BaPerson
            {
                BaPersonID = 1000002,
                Name = "NameTest",
                Vorname = "VornameTest",
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };
            SystemService.NewHistoryVersion(unitOfWork);
            _repositoryPerson.ApplyChanges(person);
            unitOfWork.SaveChanges();
            person.AcceptChanges();

            // Act - Get person
            unitOfWork = UnitOfWork.GetNew;
            var personService = Container.Resolve<BaPersonService>();
            BaPerson personRes = personService.GetById(unitOfWork, person.BaPersonID);

            // Act - Update person
            unitOfWork = UnitOfWork.GetNew;
            _repositoryPerson = Container.Resolve<IRepository<BaPerson>>(unitOfWork);
            personRes.Name = "NewName";
            _repositoryPerson.ApplyChanges(personRes);
            unitOfWork.SaveChanges();
            personRes.AcceptChanges();

            // Act - Get updated person
            unitOfWork = UnitOfWork.GetNew;
            BaPerson personUpdated = personService.GetById(unitOfWork, personRes.BaPersonID);

            // Assert
            Assert.IsNotNull(personUpdated);
            Assert.AreEqual("NewName", personUpdated.Name);
        }

        [TestMethod]
        public void Test_AddPerson_GetPerson_Via_Different_UnitOfWork()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            _repositoryPerson = Container.Resolve<IRepository<BaPerson>>(unitOfWork);

            // Act - Add
            var person = new BaPerson
            {
                BaPersonID = 1000003,
                Name = "NameTest",
                Vorname = "VornameTest",
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };
            SystemService.NewHistoryVersion(unitOfWork);
            _repositoryPerson.ApplyChanges(person);
            unitOfWork.SaveChanges();

            // Act - Get
            unitOfWork = UnitOfWork.GetNew;
            var personService = Container.Resolve<BaPersonService>();
            BaPerson personRes = personService.GetById(unitOfWork, person.BaPersonID);

            // Assert
            Assert.IsNotNull(personRes);
            Assert.AreEqual("NameTest", personRes.Name);
        }

        [TestMethod]
        public void Test_AddPerson_GetPerson_Via_Same_UnitOfWork()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            _repositoryPerson = Container.Resolve<IRepository<BaPerson>>(unitOfWork);

            // Act - Add
            var person = new BaPerson
            {
                BaPersonID = 1000004,
                Name = "NameTest",
                Vorname = "VornameTest",
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };
            SystemService.NewHistoryVersion(unitOfWork);
            _repositoryPerson.ApplyChanges(person);
            unitOfWork.SaveChanges();

            // Act - Get
            var personService = Container.Resolve<BaPersonService>();
            BaPerson personRes = personService.GetById(unitOfWork, person.BaPersonID);

            // Assert
            Assert.IsNotNull(personRes);
            Assert.AreEqual("NameTest", personRes.Name);
        }

        #endregion
    }
}