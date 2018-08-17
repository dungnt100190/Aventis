using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.Kbu;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Kbu
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class KbuBelegKreisServiceTest
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
        public void GetNextSequence_Test()
        {
            //Wir testen nur auf der DB
            if (!TestUtils.IsDbTest(UnitOfWork.GetNew))
            {
                return;
            }

            //Arrange
            KbuBelegKreisService service = Container.Resolve<KbuBelegKreisService>();

            //Act 
            int next1 = service.GetNextSequence(null, LOVsGenerated.KbuBelegKreis.AuszahlungenKISS, 10);
            int next2 = service.GetNextSequence(null, LOVsGenerated.KbuBelegKreis.AuszahlungenKISS, 1);

            //Assert
            Assert.IsTrue(next2 >= next1 + 10);

        }

        #endregion
    }
}