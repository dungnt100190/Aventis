using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL.Kbu;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BL.Test.Kbu
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class KbuBelegVerbuchungServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        //private List<TEntity> _entities;
        private readonly KbuBelegHelper _belegHelper = new KbuBelegHelper();

        #endregion

        #region Private Fields

        private KbuBeleg _beleg;

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
            //using (var transaction = new TransactionScope())
            //{

            // Create some temporary test objects and store the entities
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;

            _beleg = _belegHelper.CreateBelegFreigegeben(unitOfWork);

            //Auf der DB sind die dinger schon da, im Mock nicht.
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                var repBelegKreis = UnitOfWork.GetRepository<KbuBelegKreis>(unitOfWork);
                KbuBelegKreis belegKreis = new KbuBelegKreis
                {
                    BelegNrVon = 1,
                    BelegNrBis = 1000000,
                    NaechsteBelegNr = 1,
                    KbuBelegKreisCode = 1,
                    Creator = "UnitTest",
                    Created = DateTime.Now,
                    Modifier = "UnitTest",
                    Modified = DateTime.Now
                };
                repBelegKreis.ApplyChanges(belegKreis);
                unitOfWork.SaveChanges();
            }

            //transaction.Complete();
            //}
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //using (var transaction = new TransactionScope())
            //{
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            _belegHelper.Delete(unitOfWork);
            //transaction.Complete();
            //}
        }

        [TestMethod]
        public void BelegeVerbuchen_Test1()
        {
            // Arrange
            var service = Container.Resolve<KbuBelegVerbuchungService>();
            IList<int> belegIDs = new List<int> { _beleg.KbuBelegID };
            var valutaDatum = new DateTime(2012, 07, 16); //Ist ein Montag.

            // Act
            KissServiceResult result = service.BelegeVerbuchen(null, belegIDs, valutaDatum);

            // Assert
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void GetFreigegebeneBelege_WithoutErrors()
        {

            if(!TestUtils.IsDbTest(UnitOfWork.GetNew))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<KbuBelegVerbuchungService>();

            // Act
            List<KbuBelegLaufDTO> result = service.GetFreigegebeneBelege(null, DateTime.Today, false);

            // Assert
            int count = result.Where(x => x.KbuBelegID == _beleg.KbuBelegID).Count();
            Assert.AreEqual(1, count);
        }

        #endregion
    }
}