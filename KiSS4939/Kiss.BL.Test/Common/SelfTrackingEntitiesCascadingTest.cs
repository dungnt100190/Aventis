using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Common
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class SelfTrackingEntitiesCascadingTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CREATOR = "creator";

        #endregion

        #region Private Fields

        private bool _deleted;
        private FsDienstleistung _dienstleistung;
        private FsDienstleistungspaket _dienstleistungspaket;
        private FsDienstleistung_FsDienstleistungspaket _dlDlp;

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
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            var repDl = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);

            //Dienstleistung
            _dienstleistung = new FsDienstleistung();
            _dienstleistung.Name = "UnitTestCascading";
            _dienstleistung.StandardAufwand = 23;
            _dienstleistung.Creator = CREATOR;
            _dienstleistung.Created = DateTime.Now;
            _dienstleistung.Modifier = CREATOR;
            _dienstleistung.Modified = DateTime.Now;

            //Dienstleistungspaket
            _dienstleistungspaket = new FsDienstleistungspaket();
            _dienstleistungspaket.Name = "UnitTestCascading";
            _dienstleistungspaket.MaximaleLaufzeit = 12;
            _dienstleistungspaket.Creator = CREATOR;
            _dienstleistungspaket.Created = DateTime.Now;
            _dienstleistungspaket.Modifier = CREATOR;
            _dienstleistungspaket.Modified = DateTime.Now;

            //FsDienstleistung_FsDienstleistungspaket
            _dlDlp = new FsDienstleistung_FsDienstleistungspaket();
            _dlDlp.FsDienstleistungspaket = _dienstleistungspaket;
            _dlDlp.FsDienstleistung = _dienstleistung;
            _dlDlp.Creator = CREATOR;
            _dlDlp.Created = DateTime.Now;
            _dlDlp.Modifier = CREATOR;
            _dlDlp.Modified = DateTime.Now;

            repDl.ApplyChanges(_dienstleistung);
            unitOfWork.SaveChanges();

            //Tracking ist bereits eingeschaltet wegen ApplyChanges
            //_dienstleistung.StartTracking();
            //_dlDlp.StartTracking();
            //_dienstleistungspaket.StartTracking();
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
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }
            if (!_deleted)
            {
                unitOfWork = UnitOfWork.GetNew;
                IRepository<FsDienstleistung> repository = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
                _dlDlp.MarkAsDeleted();
                _dienstleistung.MarkAsDeleted();
                _dienstleistungspaket.MarkAsDeleted();
                repository.ApplyChanges(_dienstleistung);
                unitOfWork.SaveChanges();
            }
        }

        /// <summary>
        /// Testet Cascading delete
        /// Dl, dlDlp, und Dlp werden in einem Wisch gelöscht.
        /// </summary>
        [TestMethod]
        public void Test_CascadingDelete()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }
            var repDl = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            _dienstleistung.MarkAsDeleted();
            _dlDlp.MarkAsDeleted();
            _dienstleistungspaket.MarkAsDeleted();
            repDl.ApplyChanges(_dienstleistung);
            unitOfWork.SaveChanges();
            _deleted = true;

            //Assert
            unitOfWork = UnitOfWork.GetNew;
            var rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            var count = rep
                .Where(x => x.FsDienstleistungID == _dienstleistung.FsDienstleistungID)
                .Include(
                    x =>
                    x.FsDienstleistung_FsDienstleistungspaket.SubInclude(
                        z => z.FsDienstleistungspaket))
                .Select(x => x).Count();
            Assert.AreEqual(0, count);
        }

        /// <summary>
        /// Nur DlDlp und Dlp werden gelöscht, nicht aber die Dl.
        /// Alles in einem Wisch.
        /// </summary>
        [TestMethod]
        public void Test_CascadingDelete_Dl_Dlp()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            var repDl = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            _dlDlp.MarkAsDeleted();
            repDl.ApplyChanges(_dienstleistung);
            unitOfWork.SaveChanges();

            //Assert
            unitOfWork = UnitOfWork.GetNew;
            var rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            var dl = rep
                .Where(x => x.FsDienstleistungID == _dienstleistung.FsDienstleistungID)
                .Include(
                    x =>
                    x.FsDienstleistung_FsDienstleistungspaket.SubInclude(
                        z => z.FsDienstleistungspaket))
                .Select(x => x).First();
            Assert.AreEqual(0, dl.FsDienstleistung_FsDienstleistungspaket.Count);

            //Löschen dl
            dl.MarkAsDeleted();
            rep.ApplyChanges(dl);
            unitOfWork.SaveChanges();

            //Löschen dlp
            var repDlp = UnitOfWork.GetRepository<FsDienstleistungspaket>(unitOfWork);
            var dlp = repDlp.Where(x => x.FsDienstleistungspaketID == _dienstleistungspaket.FsDienstleistungspaketID).Select(x => x).First();
            dlp.MarkAsDeleted();
            repDlp.ApplyChanges(dlp);
            unitOfWork.SaveChanges();

            _deleted = true;
        }

        /// <summary>
        /// Insert ist immer Cascading.
        /// </summary>
        [TestMethod]
        public void Test_CascadingInsert()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            var repDl = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);

            //Dienstleistung
            FsDienstleistung dienstleistung = new FsDienstleistung();
            dienstleistung.Name = "UnitTestCascading";
            dienstleistung.StandardAufwand = 23;
            dienstleistung.Creator = CREATOR;
            dienstleistung.Created = DateTime.Now;
            dienstleistung.Modifier = CREATOR;
            dienstleistung.Modified = DateTime.Now;

            //Dienstleistungspaket
            FsDienstleistungspaket dienstleistungspaket = new FsDienstleistungspaket();
            dienstleistungspaket.Name = "UnitTestCascading";
            dienstleistungspaket.MaximaleLaufzeit = 12;
            dienstleistungspaket.Creator = CREATOR;
            dienstleistungspaket.Created = DateTime.Now;
            dienstleistungspaket.Modifier = CREATOR;
            dienstleistungspaket.Modified = DateTime.Now;

            //FsDienstleistung_FsDienstleistungspaket
            FsDienstleistung_FsDienstleistungspaket dlDlp = new FsDienstleistung_FsDienstleistungspaket();
            dlDlp.FsDienstleistungspaket = dienstleistungspaket;
            dlDlp.FsDienstleistung = dienstleistung;
            dlDlp.Creator = CREATOR;
            dlDlp.Created = DateTime.Now;
            dlDlp.Modifier = CREATOR;
            dlDlp.Modified = DateTime.Now;

            repDl.ApplyChanges(dienstleistung);
            unitOfWork.SaveChanges();

            //Assert
            unitOfWork = UnitOfWork.GetNew;
            var rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            var count = rep
                .Where(x => x.FsDienstleistungID == dienstleistung.FsDienstleistungID)
                .Include(
                    x =>
                    x.FsDienstleistung_FsDienstleistungspaket.SubInclude(
                        z => z.FsDienstleistungspaket))
                .Select(x => x).Count();
            Assert.AreEqual(1, count);

            //Delete
            unitOfWork = UnitOfWork.GetNew;
            dlDlp.MarkAsDeleted();
            dienstleistung.MarkAsDeleted();
            dienstleistungspaket.MarkAsDeleted();
            repDl.ApplyChanges(dienstleistung);

            unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Cascading update. DL und DLP werden geändert.
        /// </summary>
        [TestMethod]
        public void Test_CascadingUpdateDlAndDlp()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            _dienstleistung.Name = "DL-Neu";
            _dienstleistungspaket.Name = "DLP-Neu";

            var repDl = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            repDl.ApplyChanges(_dienstleistung);
            unitOfWork.SaveChanges();

            //Assert
            unitOfWork = UnitOfWork.GetNew;
            var rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            var dl = rep
                .Where(x => x.FsDienstleistungID == _dienstleistung.FsDienstleistungID)
                .Include(
                    x =>
                    x.FsDienstleistung_FsDienstleistungspaket.SubInclude(
                        z => z.FsDienstleistungspaket))
                .Select(x => x).First();
            Assert.AreEqual("DL-Neu", dl.Name);
            Assert.AreEqual("DLP-Neu", dl.FsDienstleistung_FsDienstleistungspaket.Single().FsDienstleistungspaket.Name);
        }

        /// <summary>
        /// Cascading update. Nur DLP wird geändert.
        /// Scheint die Daten korrekt zu speichern, auch 
        /// wenn ApplyChanges über DL erfolgt.
        /// Update im selben UnitOfWork (ObjectContext),
        /// daher kein StartTracking nötig.
        /// </summary>
        [TestMethod]
        public void Test_CascadingUpdateOnlyDl()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            _dienstleistungspaket.Name = "DLP-Neu";
            var repDl = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            repDl.ApplyChanges(_dienstleistung);
            unitOfWork.SaveChanges();

            //Assert
            unitOfWork = UnitOfWork.GetNew;
            var rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            var dl = rep
                .Where(x => x.FsDienstleistungID == _dienstleistung.FsDienstleistungID)
                .Include(
                    x =>
                    x.FsDienstleistung_FsDienstleistungspaket.SubInclude(
                        z => z.FsDienstleistungspaket))
                .Select(x => x).First();
            Assert.AreEqual("DLP-Neu", dl.FsDienstleistung_FsDienstleistungspaket.Single().FsDienstleistungspaket.Name);
        }

        /// <summary>
        /// Zuerst werden die Daten neu geholt 
        /// geändert und im selben context gespeichert. 
        /// </summary>
        [TestMethod]
        public void Test_CascadingUpdateWithNewSearch()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            var rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            var dl = rep
                .Where(x => x.FsDienstleistungID == _dienstleistung.FsDienstleistungID)
                .Include(
                    x =>
                    x.FsDienstleistung_FsDienstleistungspaket.SubInclude(
                        z => z.FsDienstleistungspaket))
                .Select(x => x).First();
            var dlp = dl.FsDienstleistung_FsDienstleistungspaket.First().FsDienstleistungspaket;
            dlp.Name = "NewName";
            rep.ApplyChanges(dl);
            unitOfWork.SaveChanges();

            //Assert
            unitOfWork = UnitOfWork.GetNew;
            rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            dl = rep
                .Where(x => x.FsDienstleistungID == _dienstleistung.FsDienstleistungID)
                .Include(
                    x =>
                    x.FsDienstleistung_FsDienstleistungspaket.SubInclude(
                        z => z.FsDienstleistungspaket))
                .Select(x => x).First();
            Assert.AreEqual("NewName", dl.FsDienstleistung_FsDienstleistungspaket.First().FsDienstleistungspaket.Name);
        }

        /// <summary>
        /// Zuerst werden die Daten neu geholt 
        /// geändert und in einem neuen Context gespeichert. 
        /// StartTracking ist nötig.
        /// </summary>
        [TestMethod]
        public void Test_CascadingUpdateWithNewSearch_NewContext_OnlyDLP()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            var rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            var dl = rep
                .Where(x => x.FsDienstleistungID == _dienstleistung.FsDienstleistungID)
                .Include(
                    x =>
                    x.FsDienstleistung_FsDienstleistungspaket.SubInclude(
                        z => z.FsDienstleistungspaket))
                .Select(x => x).First();
            var dlp = dl.FsDienstleistung_FsDienstleistungspaket.First().FsDienstleistungspaket;
            dlp.StartTracking();

            unitOfWork = UnitOfWork.GetNew;
            rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            dlp.Name = "NewName";
            rep.ApplyChanges(dl);
            unitOfWork.SaveChanges();

            //Assert
            unitOfWork = UnitOfWork.GetNew;
            rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            dl = rep
                .Where(x => x.FsDienstleistungID == _dienstleistung.FsDienstleistungID)
                .Include(
                    x =>
                    x.FsDienstleistung_FsDienstleistungspaket.SubInclude(
                        z => z.FsDienstleistungspaket))
                .Select(x => x).First();
            Assert.AreEqual("NewName", dl.FsDienstleistung_FsDienstleistungspaket.First().FsDienstleistungspaket.Name);
        }

        /// <summary>
        /// Testet löschen über EF direkt ohne apply changes.
        /// Dl, dlDlp, und Dlp werden in einem Wisch gelöscht.
        /// </summary>
        [TestMethod]
        public void Test_DeleteObjectSet()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            //dlDlp
            var repositoryDlDlp = UnitOfWork.GetRepository<FsDienstleistung_FsDienstleistungspaket>(unitOfWork);
            var dlDlp =
                repositoryDlDlp.Where(x => x.FsDienstleistung_FsDienstleistungspaketID == _dlDlp.FsDienstleistung_FsDienstleistungspaketID).Single();
            repositoryDlDlp.ObjectSet.DeleteObject(dlDlp);
            unitOfWork.SaveChanges();

            //dl
            var repositoryDl = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            var dl =
                repositoryDl.Where(x => x.FsDienstleistungID == _dienstleistung.FsDienstleistungID).Single();
            repositoryDl.ObjectSet.DeleteObject(dl);
            unitOfWork.SaveChanges();

            //dlp
            var repositoryDlp = UnitOfWork.GetRepository<FsDienstleistungspaket>(unitOfWork);
            var dlp =
                repositoryDlp.Where(x => x.FsDienstleistungspaketID == _dienstleistungspaket.FsDienstleistungspaketID).Single();
            repositoryDlp.ObjectSet.DeleteObject(dlp);
            unitOfWork.SaveChanges();

            _deleted = true;
        }

        /// <summary>
        /// Zusätzliches DlDlp und Dlp für eine DL.
        /// </summary>
        [TestMethod]
        public void Test_InsertDlDlp()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            //Dienstleistungspaket
            FsDienstleistungspaket dienstleistungspaket = new FsDienstleistungspaket();
            dienstleistungspaket.Name = "UnitTestCascading";
            dienstleistungspaket.MaximaleLaufzeit = 12;
            dienstleistungspaket.Creator = CREATOR;
            dienstleistungspaket.Created = DateTime.Now;
            dienstleistungspaket.Modifier = CREATOR;
            dienstleistungspaket.Modified = DateTime.Now;

            //FsDienstleistung_FsDienstleistungspaket
            FsDienstleistung_FsDienstleistungspaket dlDlp = new FsDienstleistung_FsDienstleistungspaket();
            dlDlp.FsDienstleistungspaket = dienstleistungspaket;
            dlDlp.FsDienstleistung = _dienstleistung;
            dlDlp.Creator = CREATOR;
            dlDlp.Created = DateTime.Now;
            dlDlp.Modifier = CREATOR;
            dlDlp.Modified = DateTime.Now;

            //Act
            _dienstleistung.FsDienstleistung_FsDienstleistungspaket.Add(dlDlp);
            var rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            rep.ApplyChanges(_dienstleistung);
            unitOfWork.SaveChanges();

            //Assert
            unitOfWork = UnitOfWork.GetNew;
            rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            var dl = rep
                .Where(x => x.FsDienstleistungID == _dienstleistung.FsDienstleistungID)
                .Include(
                    x =>
                    x.FsDienstleistung_FsDienstleistungspaket.SubInclude(
                        z => z.FsDienstleistungspaket))
                .Select(x => x).First();
            Assert.AreEqual(2, dl.FsDienstleistung_FsDienstleistungspaket.Count);

            //Delete geht nicht.
            /*
            unitOfWork = UnitOfWork.GetNew;
            rep = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            foreach (var t in dl.FsDienstleistung_FsDienstleistungspaket.ToList())
            {
                t.MarkAsDeleted();
                //t.FsDienstleistungspaket.MarkAsDeleted();
            }
            dl.MarkAsDeleted();
            rep.ApplyChanges(dl);
            unitOfWork.SaveChanges();*/
            _deleted = true;
        }

        #endregion
    }
}