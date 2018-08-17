using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fs;
using Kiss.Infrastructure;
using Kiss.Interfaces.Database;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Fs
{
    [TestClass]
    public class FsReduktionServiceTest : TransactionTestBase
    {
        #region Fields

        #region Private Fields

        private List<FsReduktion> _fsReduktionEntities;

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

            // Create some temporary test objects and store the entities
            var unitOfWork = UnitOfWork.GetNew;
            IRepository<FsReduktion> repositoryFsReduktion = UnitOfWork.GetRepository<FsReduktion>(unitOfWork);

            _fsReduktionEntities = new List<FsReduktion>
            {
                new FsReduktion
                {
                    Name = "Test Reduktion 1",
                    StandardAufwand = 10,
                    AbhaengigVonBG = false,
                    Creator = "UnitTester",
                    Created = DateTime.Now,
                    Modifier = "UnitTester",
                    Modified = DateTime.Now
                },
                new FsReduktion
                {
                    Name = "Test Reduktion 2",
                    StandardAufwand = 20,
                    AbhaengigVonBG = true,
                    Creator = "UnitTester",
                    Created = DateTime.Now,
                    Modifier = "UnitTester",
                    Modified = DateTime.Now
                }
            };

            _fsReduktionEntities.ForEach(repositoryFsReduktion.ApplyChanges);
            unitOfWork.SaveChanges();
            _fsReduktionEntities.ForEach(x => x.AcceptChanges());
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
        public void Validate_NameIsNull_ResultIsNameError()
        {
            // Arrange
            var service = Container.Resolve<FsReduktionService>();
            var reduktion = _fsReduktionEntities[0];
            reduktion.Name = null;

            // Act
            var result = service.ValidateInMemory(reduktion);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(PropertyName.GetPropertyName(() => reduktion.Name), result.KissServiceResultEntries[0].PropertyName);
        }

        [TestMethod]
        public void Validate_StandardAufwandIsGreaterThan8760_ResultIsStandardAufwandError()
        {
            // Arrange
            var service = Container.Resolve<FsReduktionService>();
            var reduktion = _fsReduktionEntities[0];
            reduktion.StandardAufwand = 8761;

            // Act
            var result = service.ValidateInMemory(reduktion);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(PropertyName.GetPropertyName(() => reduktion.StandardAufwand), result.KissServiceResultEntries[0].PropertyName);
        }

        [TestMethod]
        public void Validate_StandardAufwandIsLessThan0_ResultIsStandardAufwandError()
        {
            // Arrange
            var service = Container.Resolve<FsReduktionService>();
            var reduktion = _fsReduktionEntities[0];
            reduktion.StandardAufwand = -1;

            // Act
            var result = service.ValidateInMemory(reduktion);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(PropertyName.GetPropertyName(() => reduktion.StandardAufwand), result.KissServiceResultEntries[0].PropertyName);
        }

        [TestMethod]
        public void Validate_ValidateEntity_ResultIsOk()
        {
            // Arrange
            var service = Container.Resolve<FsReduktionService>();
            var reduktion = _fsReduktionEntities[0];

            // Act
            var result = service.ValidateInMemory(reduktion);

            // Assert
            Assert.IsTrue(result);
        }

        #endregion
    }
}