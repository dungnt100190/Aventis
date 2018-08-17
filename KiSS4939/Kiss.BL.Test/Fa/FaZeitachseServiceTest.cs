using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fa;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Fa
{
    /// <summary>
    /// Tests the FaZeitachseService service.
    /// </summary>
    [TestClass]
    public class FaZeitachseServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FaZeitachseHelper _faZeitachseHelper = new FaZeitachseHelper();

        #endregion

        #region Private Fields

        private BaPerson _baPerson;

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
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;

                _baPerson = _faZeitachseHelper.CreateHauptachseData(unitOfWork);

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

                _faZeitachseHelper.Delete(unitOfWork);

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void Test_Dokumente()
        {
            var service = Container.Resolve<FaZeitachseService>();

            var besprechungen = service.GetBesprechungen(null, _baPerson.BaPersonID).ToList();
            var korrespondenz = service.GetKorrespondenz(null, _baPerson.BaPersonID).ToList();

            // Assert
            Assert.IsNotNull(besprechungen);
            Assert.IsTrue(besprechungen.Count > 0);
            // Gelöschte Dokumente dürfen nicht erscheinen
            Assert.IsTrue(besprechungen.All(x => x.Title != FaZeitachseHelper.STICHWORT_DELETED));

            Assert.IsNotNull(korrespondenz);
            Assert.IsTrue(korrespondenz.Count > 0);
            Assert.IsTrue(korrespondenz.All(x => x.Title != FaZeitachseHelper.STICHWORT_DELETED));
        }

        [TestMethod]
        public void Test_GetZeitachse()
        {
            // Arrange
            var service = Container.Resolve<FaZeitachseService>();

            // Act
            var result = service.GetZeitachse(null, _baPerson.BaPersonID);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        #endregion
    }
}