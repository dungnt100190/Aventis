using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Activities.Test
{
    [TestClass]
    [DeploymentItem("TestFiles", "TestFiles")]
    public class DeleteItemsTest
    {
        [TestMethod]
        public void DeleteItemsInternal()
        {
            var itemsToDelete = new List<Regex>
            {
                new Regex(".*")
            };
            var itemsToKeep = new List<Regex>
            {
                new Regex("^TestFolder$")
            };

            var deleteItems = new DeleteItems();
            deleteItems.DeleteItemsInternal(null, new DirectoryInfo("TestFiles"), itemsToDelete, itemsToKeep);

            Assert.IsTrue(File.Exists("TestFiles/TestFolder/TextFile1.txt"));
            Assert.IsTrue(File.Exists("TestFiles/TestFolder/TextFile2.txt"));
            Assert.IsFalse(File.Exists("TestFiles/TextFile1.txt"));
        }
    }
}