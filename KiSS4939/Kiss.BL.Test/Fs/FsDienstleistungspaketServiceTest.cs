using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fs;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Fs
{
    [TestClass]
    public class FsDienstleistungspaketServiceTest : TransactionTestBase
    {
        #region Fields

        #region Private Fields

        private int _countDlpBeforTest;
        private List<FsDienstleistung> _dienstleistungen;
        private List<FsDienstleistung_FsDienstleistungspaket> _dl2Dlps;
        private List<FsDienstleistungspaket> _pakete;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            ClassInitialize();
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            // Create some temporary test objects and store the entities
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;

            // Create some FsDienstleistungspaket entities
            IRepository<FsDienstleistungspaket> repositoryPaket = UnitOfWork.GetRepository<FsDienstleistungspaket>(unitOfWork);

            // Get number of entries before test setup
            _countDlpBeforTest = repositoryPaket.Count();

            _pakete = new List<FsDienstleistungspaket>
                {
                    new FsDienstleistungspaket
                    {
                        Name = "Test Dienstleistungspaket 1",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    },
                    new FsDienstleistungspaket
                    {
                        Name = "Test Dienstleistungspaket 2 mit Dl",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    }
                };

            _pakete.ForEach(repositoryPaket.ApplyChanges);
            unitOfWork.SaveChanges();

            // Create some FsDienstleistung entities
            IRepository<FsDienstleistung> repositoryDienstleistung = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);

            _dienstleistungen = new List<FsDienstleistung>
                {
                    new FsDienstleistung
                    {
                        Name = "Test Dienstleistung 1",
                        StandardAufwand = (decimal)1.5,
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    },
                    new FsDienstleistung
                    {
                        Name = "Test Dienstleistung 2",
                        StandardAufwand = (decimal)2.75,
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    },
                    new FsDienstleistung
                    {
                        Name = "Test Dienstleistung 3",
                        StandardAufwand = 3,
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    }
                };

            _dienstleistungen.ForEach(repositoryDienstleistung.ApplyChanges);
            unitOfWork.SaveChanges();

            // Create some relations between FsDienstleistung and FsDienstleichstungspaket
            IRepository<FsDienstleistung_FsDienstleistungspaket> repositoryDl2Dlp = UnitOfWork.GetRepository<FsDienstleistung_FsDienstleistungspaket>(unitOfWork);

            _dl2Dlps = new List<FsDienstleistung_FsDienstleistungspaket>
                {
                    new FsDienstleistung_FsDienstleistungspaket
                    {
                        FsDienstleistung = _dienstleistungen[1],
                        FsDienstleistungspaket = _pakete[1],
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    },
                    new FsDienstleistung_FsDienstleistungspaket
                    {
                        FsDienstleistung = _dienstleistungen[2],
                        FsDienstleistungspaket = _pakete[1],
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    }
                };

            _dl2Dlps.ForEach(repositoryDl2Dlp.ApplyChanges);

            unitOfWork.SaveChanges();
        }

        [ClassCleanup]
        public static new void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void DeleteData_paketHasAssignedDienstleistung_resultIsOkRelationsAreAlsoDeleted()
        {
            //Arrange
            var dlpService = Container.Resolve<FsDienstleistungspaketService>();
            var dlp = _pakete[1];
            int dlpIdToDelete = dlp.FsDienstleistungspaketID;
            var unitOfWork = UnitOfWork.GetNew;
            IRepository<FsDienstleistung_FsDienstleistungspaket> repositoryDl2Dlp = UnitOfWork.GetRepository<FsDienstleistung_FsDienstleistungspaket>(unitOfWork);

            //Act
            var resultDelete = dlpService.DeleteData(null, dlp);
            var count = repositoryDl2Dlp.Where(dl2Dlp => dl2Dlp.FsDienstleistungspaketID == dlpIdToDelete).Count();

            //Assert
            Assert.IsTrue(resultDelete.IsOk);
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void GetAssignedDienstleistungRelationen_assign2Dienstleistungen_Has2DienstleistungRelationen()
        {
            //Arrange
            var dlpService = Container.Resolve<FsDienstleistungspaketService>();

            //Act
            var dl2Dlp = dlpService.GetAssignedDienstleistungRelationen(null, _pakete[1].FsDienstleistungspaketID);

            //Assert
            Assert.IsNotNull(dl2Dlp);
            Assert.AreEqual(2, dl2Dlp.Count);
            Assert.AreEqual(_dl2Dlps[0].FsDienstleistung_FsDienstleistungspaketID, dl2Dlp[0].FsDienstleistung_FsDienstleistungspaketID);
            Assert.AreEqual(_dl2Dlps[1].FsDienstleistung_FsDienstleistungspaketID, dl2Dlp[1].FsDienstleistung_FsDienstleistungspaketID);
        }

        [TestMethod]
        public void GetAssignedDienstleistungen_assign2Dienstleistungen_Has2AssignedDienstleistungen()
        {
            //Arrange
            var dlpService = Container.Resolve<FsDienstleistungspaketService>();

            //Act
            var dienstleistungen = dlpService.GetAssignedDienstleistungen(null, _pakete[1].FsDienstleistungspaketID);

            //Assert
            Assert.IsNotNull(dienstleistungen);
            Assert.AreEqual(2, dienstleistungen.Count);
            Assert.IsNotNull(dienstleistungen[0]);
            Assert.IsNotNull(dienstleistungen[1]);
        }

        [TestMethod]
        public void GetData_getInsertedData_DienstleistungExists()
        {
            // Arrange
            var service = Container.Resolve<FsDienstleistungspaketService>();

            // Act
            var dls = service.GetData(null);

            // Assert
            Assert.IsNotNull(dls);
            Assert.AreEqual(2, dls.Count - _countDlpBeforTest);
        }

        [TestMethod]
        public void SaveAssignedDienstleistungen_assign2Dienstleistungen_resultIsOk()
        {
            //Arrange
            var dlpService = Container.Resolve<FsDienstleistungspaketService>();
            var dlp = _pakete[0];
            var unitOfWork = UnitOfWork.GetNew;
            var repositoryDl2Dlp = UnitOfWork.GetRepository<FsDienstleistung_FsDienstleistungspaket>(unitOfWork);

            //Act
            var dienstleistungList = new List<FsDienstleistung> { _dienstleistungen[0], _dienstleistungen[1] };
            var result = dlpService.SaveAssignedDienstleistungen(null, dlp, dienstleistungList);
            var count = repositoryDl2Dlp.Where(dl2Dlp => dl2Dlp.FsDienstleistungspaketID == dlp.FsDienstleistungspaketID).Count();

            //Assert
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void SaveAssignedDienstleistungen_withEmptyList_resultIsOk()
        {
            //Arrange
            var dlpService = Container.Resolve<FsDienstleistungspaketService>();

            //Act
            var dienstleistungList = new List<FsDienstleistung>();
            var result = dlpService.SaveAssignedDienstleistungen(null, _pakete[0], dienstleistungList);

            //Assert
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void SaveData_GetNewDataWithEmptyName_ResultIsError()
        {
            // Arrange
            var service = Container.Resolve<FsDienstleistungspaketService>();

            // Act
            FsDienstleistungspaket newDienstleistung;
            var result = service.NewData(out newDienstleistung);

            result += service.SaveData(null, newDienstleistung);

            var dls = service.GetData(null);

            // Assert
            Assert.IsTrue(result.IsError);
            Assert.IsNotNull(dls);
            Assert.AreEqual(2, dls.Count - _countDlpBeforTest);
        }

        [TestMethod]
        public void SaveData_GetNewData_ResultIsOk()
        {
            const string newDienstleistungspaketDescritpion = "Neues Dienstleistungspaket";

            // Arrange
            var service = Container.Resolve<FsDienstleistungspaketService>();

            // Act
            FsDienstleistungspaket newDienstleistung;
            var result = service.NewData(out newDienstleistung);
            newDienstleistung.Name = newDienstleistungspaketDescritpion;
            _pakete.Add(newDienstleistung);

            result += service.SaveData(null, newDienstleistung);

            var dls = service.GetData(null);

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.IsNotNull(dls);
            Assert.AreEqual(3, dls.Count - _countDlpBeforTest);
        }

        #endregion
    }
}