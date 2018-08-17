using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fa;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Fa
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class FaFallServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();

        #endregion

        #region Private Fields

        private FaLeistung _leistung;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize(DatabaseTestUtil.CONNECTION_STRING_NAME_KISS5);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;
                _leistung = _leistungHelper.CreateWsh(unitOfWork);
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
                _leistungHelper.Delete(unitOfWork);
                transaction.Complete();
            }
        }

        [TestMethod]
        [TestCategory("KiSS5")]
        public void GetAktuelleFaFallId_Ok()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<FaFallService>();

            // Act
            int? faFallid = service.GetAktuelleFaFallId(null, _leistung.BaPersonID);

            // Assert, nur bei nicht mock.
            Assert.AreEqual(faFallid, _leistung.BaPersonID);
        }

        #endregion
    }
}