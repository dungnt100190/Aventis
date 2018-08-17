using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.IoC;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class KbuGeldbetragRundungsServiceTest
    {
        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize(DatabaseTestUtil.CONNECTION_STRING_NAME_KISS5);
        }

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void GeldbetragRunden_99and91()
        {
            //Arrage
            var service = Container.Resolve<KbuGeldbetragRundungsService>();
            decimal betrag = 99.91M;

            //Act
            decimal result = service.GeldbetragRunden(betrag);

            //Assert
            Assert.AreEqual(99.90M, result);
        }

        [TestMethod]
        public void GeldbetragRunden_99and94()
        {
            //Arrage
            var service = Container.Resolve<KbuGeldbetragRundungsService>();
            decimal betrag = 99.94M;

            //Act
            decimal result = service.GeldbetragRunden(betrag);

            //Assert
            Assert.AreEqual(99.95M, result);
        }

        [TestMethod]
        public void GeldbetragRunden_99and99()
        {
            //Arrage
            var service = Container.Resolve<KbuGeldbetragRundungsService>();
            decimal betrag = 99.99M;

            //Act
            decimal result = service.GeldbetragRunden(betrag);

            //Assert
            Assert.AreEqual(100, result);
        }

        #endregion
    }
}