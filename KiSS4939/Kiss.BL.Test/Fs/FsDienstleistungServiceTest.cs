using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fs;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Fs
{
    /// <summary>
    /// Summary description for FsDienstleistungServiceTest
    /// </summary>
    [TestClass]
    public class FsDienstleistungServiceTest : TransactionTestBase
    {
        #region Fields

        #region Private Fields

        private int _countBeforTest;
        private List<FsDienstleistung> _fsDienstleistungEntities;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            // Get number of entries before test setup
            var service = Container.Resolve<FsDienstleistungService>();
            var dls = service.GetData(null);
            _countBeforTest = dls.Count;

            // Create some temporary test objects and store the entities
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            IRepository<FsDienstleistung> repositoryFsDienstleistung = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);

            _fsDienstleistungEntities = new List<FsDienstleistung>
            {
                new FsDienstleistung
                {
                    Name = "Test Dienstleistung 1",
                    StandardAufwand = 10,
                    Creator = "UnitTester",
                    Created = DateTime.Now,
                    Modifier = "UnitTester",
                    Modified = DateTime.Now
                },
                new FsDienstleistung
                {
                    Name = "Test Dienstleistung 2",
                    StandardAufwand = 20,
                    Creator = "UnitTester",
                    Created = DateTime.Now,
                    Modifier = "UnitTester",
                    Modified = DateTime.Now
                }
            };

            _fsDienstleistungEntities.ForEach(repositoryFsDienstleistung.ApplyChanges);
            unitOfWork.SaveChanges();
            _fsDienstleistungEntities.ForEach(x => x.AcceptChanges());
        }

        [ClassCleanup]
        public new static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void GetData_GetInsertedData_DienstleistungExists()
        {
            // Arrange
            var service = Container.Resolve<FsDienstleistungService>();

            // Act
            var dls = service.GetData(null);

            // Assert
            Assert.IsNotNull(dls);
            Assert.AreEqual(2, dls.Count - _countBeforTest);
        }

        [TestMethod]
        public void SaveData_GetNewDataWithEmptyName_ResultIsError()
        {
            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var service = Container.Resolve<FsDienstleistungService>();

            // Act
            FsDienstleistung newDienstleistung;
            var result = service.NewData(out newDienstleistung);

            result += service.SaveData(unitOfWork, newDienstleistung);

            var dls = service.GetData(unitOfWork);

            // Assert
            Assert.IsTrue(result.IsError);
            Assert.IsNotNull(dls);
            Assert.AreEqual(2, dls.Count - _countBeforTest);
        }

        [TestMethod]
        public void SaveData_GetNewData_ResultIsOk()
        {
            const string newDienstleistungDescritpion = "Neues Dienstleistungspaket";

            // Arrange
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var service = Container.Resolve<FsDienstleistungService>();

            // Act
            FsDienstleistung newDienstleistung;
            var result = service.NewData(out newDienstleistung);
            newDienstleistung.Name = newDienstleistungDescritpion;
            _fsDienstleistungEntities.Add(newDienstleistung);

            result += service.SaveData(unitOfWork, newDienstleistung);

            var dls = service.GetData(unitOfWork);

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.IsNotNull(dls);
            Assert.AreEqual(3, dls.Count - _countBeforTest);
        }

        [TestMethod]
        public void Validate_NameIsNull_ResultIsNameError()
        {
            // Arrange
            var service = Container.Resolve<FsDienstleistungService>();
            var dienstleistung = _fsDienstleistungEntities[0];
            dienstleistung.Name = null;

            // Act
            var result = service.ValidateInMemory(dienstleistung);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(PropertyName.GetPropertyName(() => dienstleistung.Name), result.KissServiceResultEntries[0].PropertyName);
        }

        [TestMethod]
        public void Validate_StandardAufwandIsGreaterThan744_ResultIsStandardAufwandError()
        {
            // Arrange
            var service = Container.Resolve<FsDienstleistungService>();
            var dienstleistung = _fsDienstleistungEntities[0];
            dienstleistung.StandardAufwand = 745;

            // Act
            var result = service.ValidateInMemory(dienstleistung);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(PropertyName.GetPropertyName(() => dienstleistung.StandardAufwand), result.KissServiceResultEntries[0].PropertyName);
        }

        [TestMethod]
        public void Validate_StandardAufwandIsLessThan0_ResultIsStandardAufwandError()
        {
            // Arrange
            var service = Container.Resolve<FsDienstleistungService>();
            var dienstleistung = _fsDienstleistungEntities[0];
            dienstleistung.StandardAufwand = -1;

            // Act
            var result = service.ValidateInMemory(dienstleistung);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(PropertyName.GetPropertyName(() => dienstleistung.StandardAufwand), result.KissServiceResultEntries[0].PropertyName);
        }

        [TestMethod]
        public void Validate_ValidateEntity_ResultIsOk()
        {
            // Arrange
            var service = Container.Resolve<FsDienstleistungService>();
            var dienstleistung = _fsDienstleistungEntities[0];

            // Act
            var result = service.ValidateInMemory(dienstleistung);

            // Assert
            Assert.IsTrue(result);
        }

        #endregion
    }
}