using System.Collections.Generic;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class WshGrundbudgetVorschlagServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshHaushaltPersonHelper _haushaltPersonHelper = new WshHaushaltPersonHelper();

        #endregion

        #region Private Fields

        private IList<WshHaushaltPerson> _haushaltPerson;

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
                var unitOfWork = UnitOfWork.GetNew;
                _haushaltPerson = _haushaltPersonHelper.Create(unitOfWork);
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
                _haushaltPersonHelper.Delete(unitOfWork);
                transaction.Complete();
            }
        }

        [TestMethod]
        public void GetGrundbudgetVorschlag_OK()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            //Arrange
            var service = Container.Resolve<WshGrundbudgetVorschlagService>();

            //Act
            var list = service.GetGrundbudgetVorschlag(null, _haushaltPerson[0].FaLeistungID);

            //Assert
            Assert.AreEqual(1, list.Count);
        }

        #endregion
    }
}