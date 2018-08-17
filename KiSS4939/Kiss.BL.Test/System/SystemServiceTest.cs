using System.Collections.Generic;
using Kiss.BL.Cache;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BL.Test.System
{
    [TestClass]
    public class SystemServiceTest
    {
        #region Test Methods

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
        }

        [TestMethod]
        public void CheckDbName_Nok()
        {
            //Arrange
            //In case we are in Mock, we will not execute this test.
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            SqlService sqlService = Container.Resolve<SqlService>();

            string previousValue = (string)sqlService.ExecuteScalar(unitOfWork, @"
               SELECT ValueVarchar
               FROM dbo.XConfig
               WHERE KeyPath LIKE 'System\Allgemein\DbName'
            ", new object[0]);

            sqlService.ExecuteScalar(unitOfWork, @"
               UPDATE dbo.XConfig
               SET  ValueVarchar = 'Hugo'
               WHERE KeyPath LIKE 'System\Allgemein\DbName'
            ", new object[0]);

            bool exceptionOccurred = false;

            //Act
            try
            {
                CacheManager.Instance.ClearCache();
                SystemService.CheckDbName(null);
            }
            catch (KissConfigurationException)
            {
                exceptionOccurred = true;
            }

            //Assert
            try
            {
                Assert.IsTrue(exceptionOccurred);
            }
            finally
            {
                //Cleanup
                sqlService.ExecuteScalar(unitOfWork, @"
                    UPDATE dbo.XConfig
                    SET  ValueVarchar = @ConfigVal
                    WHERE KeyPath LIKE 'System\Allgemein\DbName'",
                    new KeyValuePair<string, object>("@ConfigVal", previousValue));
            }
        }

        [TestMethod]
        public void CheckDbName_Ok()
        {
            //Arrange
            //In case we are in Mock, we will not execute this test.
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }

            //Act
            CacheManager.Instance.ClearCache();
            SystemService.CheckDbName(null);

            //Assert
            //Nothing to assert, no exception expected.
        }

        #endregion
    }
}