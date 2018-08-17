using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS4.Common.Test
{
    /// <summary>
    /// Utils tests
    /// </summary>
    [TestClass]
    public class UtilsTest
    {
        #region Properties

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get;
            set;
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void Test_Utils_ConvertToBool()
        {
            bool a = Utils.ConvertToBool(true);
            Assert.IsTrue(a);

            bool b = Utils.ConvertToBool(null);
            Assert.IsFalse(b);

            bool c = Utils.ConvertToBool(DBNull.Value);
            Assert.IsFalse(c);
        }

        [TestMethod]
        public void Test_Utils_ConvertToInt()
        {
            int a = Utils.ConvertToInt("100", 5);
            Assert.AreEqual(5, a);

            int b = Utils.ConvertToInt(10);
            Assert.AreEqual(10, b);

            int c = Utils.ConvertToInt(DBNull.Value);
            Assert.AreEqual(0, c);
        }

        [TestMethod]
        public void Test_Utils_RoundMoney()
        {
            const decimal unit = 0.05m;

            var rounded = Utils.RoundMoney(1.123m, unit);
            Assert.AreEqual(1.10m, rounded);

            var swiss = Utils.RoundMoney_CH(1.123m);
            Assert.AreEqual(rounded, swiss);

            rounded = Utils.RoundMoney(1.132m, unit);
            Assert.AreEqual(1.15m, rounded);
        }

        #endregion

        #region Other

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion
    }
}