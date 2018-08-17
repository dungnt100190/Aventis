using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Activities.Test
{
    [TestClass]
    [DeploymentItem("TestFiles")]
    public class CopyItemsTest
    {
        #region Test Methods

        [TestMethod]
        public void TestCopyItems()
        {
            var regexes = new List<Regex>
            {
                new Regex(".*\\.txt", RegexOptions.Compiled | RegexOptions.IgnoreCase),
                new Regex(".*TestFolder.*", RegexOptions.Compiled | RegexOptions.IgnoreCase)
            };

            CopyItems.CopyItemsInternal(null, regexes, new DirectoryInfo("TestFiles"), new DirectoryInfo("..\\Destination"));

            Assert.IsTrue(Directory.Exists("..\\Destination"));
            Assert.IsTrue(File.Exists("..\\Destination\\TextFile1.txt"));
        }

        #endregion
    }
}