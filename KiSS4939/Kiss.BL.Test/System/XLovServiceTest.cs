using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Test.System
{
    /// <summary>
    /// Summary description for PersonServiceTest
    /// </summary>
    [TestClass]
    public class XLovServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string NAME_LOV_1 = "NewLOV 1";
        private const string NAME_LOV_2 = "NewLOV 2";

        #endregion

        #region Private Fields

        private List<XLOVCode> _lovCodes;
        private List<XLOV> _lovs;
        private IRepository<XLOV> _repositoryLov;
        private IRepository<XLOVCode> _repositoryLovCode;

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
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                IUnitOfWork unitOfWork = UnitOfWork.GetNew;

                // Create some FsDienstleistungspaket entities
                _repositoryLov = UnitOfWork.GetRepository<XLOV>(unitOfWork);

                _lovs = new List<XLOV>();

                var lov1 = _repositoryLov.FirstOrDefault(x => x.LOVName == NAME_LOV_1) ??
                           new XLOV
                           {
                               LOVName = NAME_LOV_1,
                           };
                _lovs.Add(lov1);

                var lov2 = _repositoryLov.FirstOrDefault(x => x.LOVName == NAME_LOV_2) ??
                           new XLOV
                           {
                               LOVName = NAME_LOV_2,
                           };
                _lovs.Add(lov2);

                _lovs.ForEach(x => _repositoryLov.ApplyChanges(x));
                unitOfWork.SaveChanges();

                // Create some FsDienstleistung entities
                _repositoryLovCode = UnitOfWork.GetRepository<XLOVCode>(unitOfWork);

                _lovCodes = new List<XLOVCode>();
                var lov = _repositoryLovCode.FirstOrDefault(x => x.LOVName == NAME_LOV_1 && x.Code == 1) ??
                          new XLOVCode
                          {
                              XLOV = _lovs[0],
                              LOVName = _lovs[0].LOVName,
                              Code = 1,
                              Text = "a",
                              Value3 = "ZH",
                          };
                _lovCodes.Add(lov);

                lov = _repositoryLovCode.FirstOrDefault(x => x.LOVName == NAME_LOV_2 && x.Code == 1) ??
                      new XLOVCode
                      {
                          XLOV = _lovs[1],
                          LOVName = _lovs[1].LOVName,
                          Code = 1,
                          Text = "first",
                          Value3 = "ZH",
                      };
                _lovCodes.Add(lov);

                lov = _repositoryLovCode.FirstOrDefault(x => x.LOVName == NAME_LOV_2 && x.Code == 2) ??
                      new XLOVCode
                      {
                          XLOV = _lovs[1],
                          LOVName = _lovs[1].LOVName,
                          Code = 2,
                          Text = "second",
                          Value3 = "ZHH",
                      };
                _lovCodes.Add(lov);

                lov = _repositoryLovCode.FirstOrDefault(x => x.LOVName == NAME_LOV_2 && x.Code == 3) ??
                      new XLOVCode
                      {
                          XLOV = _lovs[1],
                          LOVName = _lovs[1].LOVName,
                          Code = 3,
                          Text = "third",
                          Value3 = "A,I,W,WIK,F",
                      };
                _lovCodes.Add(lov);

                _lovCodes.ForEach(x => _repositoryLovCode.ApplyChanges(x));
                unitOfWork.SaveChanges();

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
                _repositoryLov = UnitOfWork.GetRepository<XLOV>(unitOfWork);
                _repositoryLovCode = UnitOfWork.GetRepository<XLOVCode>(unitOfWork);

                // delete the entities that have not been deleted yet
                var lovsToDelete = _lovs.Where(dlp => dlp.ChangeTracker.State != ObjectState.Deleted).ToList();
                var lovCodesToDelete = _lovCodes.Where(dl => dl.ChangeTracker.State != ObjectState.Deleted).ToList();

                // Delete the temporary test objects
                // Delete all LovCodes
                lovCodesToDelete.ForEach(x => x.MarkAsDeleted());
                lovCodesToDelete.ForEach(x => _repositoryLovCode.ApplyChanges(x));
                unitOfWork.SaveChanges();

                // Delete all Lovs
                lovsToDelete.ForEach(x => x.MarkAsDeleted());
                lovsToDelete.ForEach(x => _repositoryLov.ApplyChanges(x));

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void GetLovCodeByLovName_FilterList()
        {
            // Arrange
            var xlovService = Container.Resolve<XLovService>();

            string[] filterlist = { "A", "I", "W" };

            // Act
            var result = xlovService.GetLovCodeByLovName(null, _lovs[1].LOVName, filterlist);

            //assert
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetLovCodeByLovName_FilteredEmtyString()
        {
            // Arrange
            var xlovService = Container.Resolve<XLovService>();

            //Act
            List<XLOVCode> xLovCodes = xlovService.GetLovCodeByLovName(null, _lovs[1].LOVName, "");

            //Assert
            Assert.AreEqual(3, xLovCodes.Count);
        }

        [TestMethod]
        public void GetLovCodeByLovName_LovFilteredWithComma_ResultIsFiltered()
        {
            // Arrange
            var xlovService = Container.Resolve<XLovService>();

            // Act
            var xLovCodes = xlovService.GetLovCodeByLovName(null, _lovs[1].LOVName, "W");

            // Assert
            Assert.AreEqual(1, xLovCodes.Count);
        }

        [TestMethod]
        public void GetLovCodeByLovName_LovFiltered_ResultIsFiltered()
        {
            // Arrange
            var xlovService = Container.Resolve<XLovService>();

            // Act
            var xLovCodes = xlovService.GetLovCodeByLovName(null, _lovs[1].LOVName, "ZH");

            // Assert
            Assert.AreEqual(1, xLovCodes.Count);
        }

        [TestMethod]
        public void GetLovCode_LovWithCodeExists_ReturnListOfCodes()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            _repositoryLov = Container.Resolve<IRepository<XLOV>>(unitOfWork);
            _repositoryLovCode = Container.Resolve<IRepository<XLOVCode>>(unitOfWork);

            // Act
            var xlovService = Container.Resolve<XLovService>();
            var xlovCodes = xlovService.GetLovCodeByLovName(unitOfWork, _lovs[1].LOVName);

            // Assert
            Assert.IsNotNull(xlovCodes);
            Assert.AreEqual(3, xlovCodes.Count);
            Assert.AreEqual(_lovs[1].LOVName, xlovCodes[0].LOVName);
            Assert.AreEqual(_lovs[1].LOVName, xlovCodes[1].LOVName);
            Assert.AreEqual(_lovs[1].LOVName, xlovCodes[2].LOVName);
            Assert.AreEqual(1, xlovCodes[0].Code);
            Assert.AreEqual(2, xlovCodes[1].Code);
            Assert.AreEqual(3, xlovCodes[2].Code);
            Assert.AreEqual("first", xlovCodes[0].Text);
            Assert.AreEqual("second", xlovCodes[1].Text);
            Assert.AreEqual("third", xlovCodes[2].Text);
        }

        [TestMethod]
        public void GetLov_LovExists_NameIsEqual()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            _repositoryLov = Container.Resolve<IRepository<XLOV>>(unitOfWork);

            // Act
            var xlovService = Container.Resolve<XLovService>();
            var xlovRes = xlovService.GetByLovName(unitOfWork, _lovs[0].LOVName);

            // Assert
            Assert.IsNotNull(xlovRes);
            Assert.AreEqual("NewLOV 1", xlovRes.LOVName);
        }

        [TestMethod]
        [ExpectedException(typeof(ResultEmptyException))]
        public void GetLovCodeByLovName_LovEmptyFilteredNoResult_ExpectException()
        {
            // Arrange
            var xlovService = Container.Resolve<XLovService>();

            // Act
            xlovService.GetLovCodeByLovName(null, _lovs[1].LOVName, "_ThisFilterShouldNotExist_");

            // Assert
            Assert.IsFalse(true);   // not expected to be reached
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetLovCodeByLovName_LovNameDoesNotExist_ExpectException()
        {
            // Arrange
            var xlovService = Container.Resolve<XLovService>();

            // Act
            xlovService.GetLovCodeByLovName(null, "_ThisLOVNameShouldNotExist_");

            // Assert
            Assert.IsFalse(true);   // not expected to be reached
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetLovCodeByLovName_LovNameIsNull_ExpectException()
        {
            // Arrange
            var xlovService = Container.Resolve<XLovService>();

            // Act
            xlovService.GetLovCodeByLovName(null, null);

            // Assert
            Assert.IsFalse(true); // not expected to be reached
        }

        #endregion
    }
}