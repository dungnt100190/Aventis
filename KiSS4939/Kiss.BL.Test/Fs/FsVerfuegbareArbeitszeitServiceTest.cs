using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fs;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Fs;

namespace Kiss.BL.Test.Fs
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class FsVerfuegbareArbeitszeitServiceTest : TransactionTestBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FsDienstleistungspaketHelper _dlpHelper = new FsDienstleistungspaketHelper();
        private readonly FaPhaseHelper _phaseHelper = new FaPhaseHelper();
        private readonly FsReduktionMitarbeiterHelper _reduktionMitarbeiterHelper = new FsReduktionMitarbeiterHelper();

        #endregion

        #region Private Fields

        private FaPhase _phase;
        private List<FsReduktionMitarbeiter> _reduktionenMitarbeiter;

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

            var dlp = _dlpHelper.Create(unitOfWork);
            _phase = _phaseHelper.Create(unitOfWork);
            _phase.FsDienstleistungspaket_Zugewiesen = dlp;

            _reduktionenMitarbeiter = _reduktionMitarbeiterHelper.CreateList(unitOfWork);

            //Datumsbereich der Phase korrigieren, so dass der Unittest etwas findet
            _phase.DatumVon = new DateTime(DateTime.Today.Year - 1, 12, 1);
            _phase.DatumBis = new DateTime(DateTime.Today.Year, 12, 31);

            _phase.XUser = _reduktionMitarbeiterHelper.Users[0];

            _phaseHelper.ApplyChanges();
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
        public void GetMitarbeiterArbeitszeit_ListeOk()
        {
            // Arrange
            var service = Container.Resolve<FsVerfuegbareArbeitszeitService>();
            DateTime von = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);

            // Act
            List<FsMitarbeiterArbeitszeitDTO> result;
            service.GetMitarbeiterArbeitszeit(null, out result, new MonthYear(von), null);

            // Assert
            Assert.AreEqual(10, result.First(u => u.User.UserID == _reduktionMitarbeiterHelper.Users[0].UserID).Reduktionen[_reduktionMitarbeiterHelper.Reduktionen[1].FsReduktionID].OriginalReduktionZeit);
        }

        [TestMethod]
        public void GetMitarbeiterArbeitszeit_NurUserMitPhase()
        {
            // Arrange
            var service = Container.Resolve<FsVerfuegbareArbeitszeitService>();
            DateTime von = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);

            // Act
            List<FsMitarbeiterArbeitszeitDTO> result;
            service.GetMitarbeiterArbeitszeit(null, out result, new MonthYear(von), null);

            // Assert
            Assert.IsFalse(result.Any(m => m.User == _reduktionMitarbeiterHelper.Users[1]));

            _phase.XUser = _reduktionMitarbeiterHelper.Users[1];
            _phaseHelper.ApplyChanges();

            service.GetMitarbeiterArbeitszeit(null, out result, new MonthYear(von), null);

            Assert.IsTrue(result.Any(m => m.User.UserID == _reduktionMitarbeiterHelper.Users[1].UserID));
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void GetMitarbeiterArbeitszeit_DecimalOk()
        {
            // Arrange
            var service = Container.Resolve<FsVerfuegbareArbeitszeitService>();
            DateTime von = new DateTime(DateTime.Today.Year, 1, 1);
            DateTime bis = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            TimePeriod timePeriod = new TimePeriod(von, bis);
            decimal result;

            // Act
            service.GetMitarbeiterArbeitszeit(null, out  result, timePeriod, _reduktionMitarbeiterHelper.Users[0].UserID);

            // Assert
        }

        #endregion
    }
}