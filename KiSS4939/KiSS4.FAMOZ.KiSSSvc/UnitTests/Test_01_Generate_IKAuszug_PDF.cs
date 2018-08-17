using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KiSSSvc.SVA;

namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class Test_01_Generate_IKAuszug_PDF
    {
        private TestContext testContextInstance;

        public Test_01_Generate_IKAuszug_PDF()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

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

        [TestMethod]
        public void IKAuszugHelper_GenerateAndSaveReport_PdfIsGenerated()
        {
            /*
            Auf der DB zuerst die DucumentID auf NULL setzen damit den Status = 3 ist

            UPDATE IKA SET DocumentID = NULL FROM SstIKAuszug IKA WHERE SstIKAuszugID = 47288

             */

            var table = new DataTable();
            table.Columns.Add(new DataColumn("SstIKAuszugID", typeof(int)));
            var row = table.NewRow();

            row["SstIKAuszugID"] = 47288;

            IKAuszugHelper.GenerateAndSaveReport(row, true);
        }

        [TestMethod]
        public void Test_01_Generate_IKAuszug_PDF_Test1()
        {
            IKAuszugHelper.GenerateIKAuszuege();
        }
    }
}