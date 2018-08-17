using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.Model;

namespace Kiss.BL.Test
{
    [TestClass]
    public sealed class TransactionTest : TransactionTestBase
    {
        #region Fields

        #region Private Fields

        private int _entityId = -1;

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

            // Es darf kein Datensatz eingefügt worden sein!
            if (_entityId > 0)
            {
                var unitOfWork = UnitOfWork.GetNew;
                var repo = UnitOfWork.GetRepository<BaLand>(unitOfWork);
                var entity = repo.FirstOrDefault(x => x.BaLandID == _entityId);

                Assert.IsNull(entity);
            }
        }

        [TestMethod]
        public void SaveChangesOk()
        {
            var testEntity = CreateValidTestLand();
            var unitOfWork = UnitOfWork.GetNew;
            var repo = UnitOfWork.GetRepository<BaLand>(unitOfWork);
            repo.ApplyChanges(testEntity);
            unitOfWork.SaveChanges();
            testEntity.AcceptChanges();
            _entityId = testEntity.BaLandID;
        }

        [TestMethod]
        [ExpectedException(typeof(SystemException), AllowDerivedTypes = true)]
        public void SaveChangesError()
        {
            var unitOfWork = UnitOfWork.GetNew;

            if (!TestUtils.IsDbTest(unitOfWork))
            {
                throw new SystemException("MOCK");
            }

            var testEntity = CreateValidTestLand();
            // should generate error
            testEntity.Creator = null;
            var repo = UnitOfWork.GetRepository<BaLand>(unitOfWork);
            repo.ApplyChanges(testEntity);
            unitOfWork.SaveChanges();
        }

        #endregion

        #region Methods

        #region Private Methods

        private BaLand CreateValidTestLand()
        {
            return new BaLand
            {
                Text = "TestLand12345",
                TextFR = "TestLand12345",
                TextEN = "TestLand12345",
                TextIT = "TestLand12345",
                DatumVon = DateTime.Today,
                DatumBis = DateTime.Today.AddDays(1d),
                Creator = "TransactionTest",
                Created = DateTime.Now,
                Modifier = "TransactionTest",
                Modified = DateTime.Now
            };
        }

        #endregion

        #endregion
    }
}