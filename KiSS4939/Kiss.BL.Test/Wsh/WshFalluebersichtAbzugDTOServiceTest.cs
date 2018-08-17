using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class WshFalluebersichtAbzugDTOServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshAbzugHelper _abzugHelper = new WshAbzugHelper();
        private readonly WshKategorieHelper _kategorieHelper = new WshKategorieHelper();

        #endregion

        #region Private Fields

        private WshAbzugDTO _abzugDTO;

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
                IUnitOfWork unitOfWork = UnitOfWork.GetNew;

                _kategorieHelper.FillWshKategorieMock(unitOfWork);
                _abzugDTO = _abzugHelper.CreateAbzugVerrechnung(unitOfWork);

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
                // Create some temporary test objects and store the entities
                IUnitOfWork unitOfWork = UnitOfWork.GetNew;

                _abzugHelper.Delete(unitOfWork);

                transaction.Complete();
            }
        }

        [TestMethod]
        public void GetFalluebersichtAbzug_TestOk()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if(!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            //Arrange
            var service = Container.Resolve<WshFalluebersichtAbzugDTOService>();
            int faFallID = _abzugDTO.WshAbzug.WshGrundbudgetPosition.FaLeistung.FaFallID;

            //Act
            var result = service.GetFalluebersichtAbzug(null, faFallID, true);

            //Assert
            //Noch keine grossen Asserts, da sich einiges ändern könnte und Zeit zu kanpp ist.
            Assert.AreEqual(1, result.Count);
        }

        #endregion
    }
}
