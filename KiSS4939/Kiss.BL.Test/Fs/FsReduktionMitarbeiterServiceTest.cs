using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fs;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Fs
{
    /// <summary>
    /// Tests the FsReduktionMitarbeiterService service.
    /// </summary>
    [TestClass]
    public class FsReduktionMitarbeiterServiceTest : TransactionTestBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FsReduktionMitarbeiterHelper _reduktionMitarbeiterHelper = new FsReduktionMitarbeiterHelper();

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

            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            _reduktionMitarbeiterHelper.CreateList(unitOfWork);
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
        public void AreEntriesGenerated_Interval()
        {
            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();

            DateTime von = new DateTime(2011, 1, 1);
            DateTime bis = new DateTime(2011, 6, 15);
            TimePeriod timePeriod = new TimePeriod(von, bis);

            //Act
            KissServiceResult serviceResult = service.AreEntriesGenerated(null, _reduktionMitarbeiterHelper.Users[0].UserID, timePeriod);

            //Assert
            Assert.IsTrue(serviceResult.IsWarning);
            Assert.IsFalse(serviceResult.IsError);
        }

        [TestMethod]
        public void CreateEntires_ThisMonthForAllUsers()
        {
            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();

            //Act
            KissServiceResult serviceResult = service.CreateEntries(null, MonthYear.CurrentMonth);

            //Assert
            Assert.IsTrue(serviceResult.IsOk);
            service.DeleteEntries(null, new MonthYear(DateTime.Today));
        }

        [TestMethod]
        public void CreateEntries_PreviousMonth()
        {
            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();
            var month = new MonthYear(DateTime.Today);
            month--;

            //Act
            KissServiceResult serviceResult = service.CreateEntries(null, _reduktionMitarbeiterHelper.Users[0].UserID, month, 0); //wir nehmen ein 100% Pensum an (0 -> default: 100)

            //Assert
            Assert.IsTrue(serviceResult.IsOk);

            //Es muss so viele Einträge in FsFaktorenMitarbeiter für den Monat wie FsFaktoren geben.
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var repositoryReduktionMitarbeiter = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            var repositoryReduktionen = UnitOfWork.GetRepository<FsReduktion>(unitOfWork);
            int userId = _reduktionMitarbeiterHelper.Users[0].UserID;
            var queryReduktionMitarbeiter = from x in repositoryReduktionMitarbeiter
                                            where x.UserID == userId
                                            where x.Jahr == month.Year
                                            where x.Monat == month.Month
                                            select x;
            var queryReduktionen = from x in repositoryReduktionen
                                   select x;
            Assert.AreEqual(queryReduktionen.Count(), queryReduktionMitarbeiter.Count());

            //Cleanup
            service.DeleteEntries(null, _reduktionMitarbeiterHelper.Users[0].UserID, month);
        }

        [TestMethod]
        public void CreateEntries_ThisMonth()
        {
            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();

            //Act
            KissServiceResult serviceResult = service.CreateEntries(null, _reduktionMitarbeiterHelper.Users[0].UserID, MonthYear.CurrentMonth, 0); //wir nehmen ein 100% Pensum an (0 -> default: 100)

            //Assert
            Assert.IsTrue(serviceResult.IsOk);

            //Es muss so viele Einträge in FsFaktorenMitarbeiter für den Monat wie FsFaktoren geben.
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var repositoryReduktionMitarbeiter = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            var repositoryReduktionen = UnitOfWork.GetRepository<FsReduktion>(unitOfWork);
            int userId = _reduktionMitarbeiterHelper.Users[0].UserID;
            var queryReduktionMitarbeiter = from x in repositoryReduktionMitarbeiter
                                            where x.UserID == userId
                                            where x.Jahr == DateTime.Today.Year
                                            where x.Monat == DateTime.Today.Month
                                            select x;
            var queryReduktionen = from x in repositoryReduktionen
                                   select x;
            Assert.AreEqual(queryReduktionen.Count(), queryReduktionMitarbeiter.Count());

            //Cleanup
            service.DeleteEntries(null, _reduktionMitarbeiterHelper.Users[0].UserID, MonthYear.CurrentMonth);
        }

        [TestMethod]
        public void DeleteEntries_LastMonth()
        {
            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();

            var month = new MonthYear(DateTime.Today.Year, DateTime.Today.Month);
            month--;

            //Act
            KissServiceResult serviceResult = service.DeleteEntries(null, _reduktionMitarbeiterHelper.Users[0].UserID, month);

            //Assert
            Assert.IsTrue(serviceResult.IsOk);
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            int userId = _reduktionMitarbeiterHelper.Users[0].UserID;
            var repositoryReduktionMitarbeiter = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            var queryReduktionMitarbeiter = from x in repositoryReduktionMitarbeiter
                                            where x.UserID == userId
                                            where x.Jahr == month.Year
                                            where x.Monat == month.Month
                                            select x;
            Assert.AreEqual(0, queryReduktionMitarbeiter.Count());
        }

        [TestMethod]
        public void DeleteEntries_LastMonthAllUser()
        {
            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();

            var month = new MonthYear(DateTime.Today.Year, DateTime.Today.Month);
            month--;

            //Act
            KissServiceResult serviceResult = service.DeleteEntries(null, month);

            //Assert
            Assert.IsTrue(serviceResult.IsOk);
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var repositoryReduktionMitarbeiter = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            var queryReduktionMitarbeiter = from x in repositoryReduktionMitarbeiter
                                            where x.Jahr == month.Year
                                            where x.Monat == month.Month
                                            select x;
            Assert.AreEqual(0, queryReduktionMitarbeiter.Count());
        }

        [TestMethod]
        public void DeleteEntries_ThisMonth()
        {
            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();

            //Act
            KissServiceResult serviceResult = service.DeleteEntries(null, _reduktionMitarbeiterHelper.Users[0].UserID, MonthYear.CurrentMonth);

            //Assert, Für diesen Monat gab es keine Einträge. Zum schauen, ob der Service keine Exception wirft.
            Assert.IsTrue(serviceResult.IsOk);
        }

        [TestMethod]
        public void EntriesGenerated_LastMonthAllUser()
        {
            var month = new MonthYear(DateTime.Today.Year, DateTime.Today.Month);
            month--;

            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();

            //Act
            bool alreadyGenerated = service.AreEntriesGenerated(null, month);

            //Assert, Keine Reduktionen Mitarbeiter für den aktuellen Monat im Setup.
            Assert.IsTrue(alreadyGenerated);
        }

        [TestMethod]
        public void EntriesGenerated_ThisMonthAllUser()
        {
            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();

            //Act
            bool alreadyGenerated = service.AreEntriesGenerated(null, DateTime.Today.Year, MonthYear.CurrentMonth);

            //Assert, Keine Reduktionen Mitarbeiter für den aktuellen Monat im Setup.
            Assert.IsFalse(alreadyGenerated);
        }

        [TestMethod]
        public void EntriesGenerated_ThisMonthSingleUser()
        {
            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();

            //Act
            bool alreadyGenerated = service.AreEntriesGenerated(null, _reduktionMitarbeiterHelper.Users[0].UserID, MonthYear.CurrentMonth);

            //Assert, Keine Reduktionen Mitarbeiter für den aktuellen Monat im Setup.
            Assert.IsFalse(alreadyGenerated);
        }

        [TestMethod]
        public void GetModifiedEntriesOfPreviousMonth_ThisMonth()
        {
            //Arrange
            var service = Container.Resolve<FsReduktionMitarbeiterService>();
            List<FsReduktionMitarbeiter> result;

            //Act
            KissServiceResult serviceResult = service.GetModifiedEntriesOfPreviousMonth(null, out result, _reduktionMitarbeiterHelper.Users[0].UserID, MonthYear.CurrentMonth);

            //Assert
            Assert.IsTrue(serviceResult.IsOk);
            Assert.AreEqual(1, result.Count);
        }

        #endregion
    }
}