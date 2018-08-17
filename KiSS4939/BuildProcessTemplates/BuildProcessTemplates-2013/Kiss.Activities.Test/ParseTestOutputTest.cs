using System.IO;
using System.Xml.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Activities.Test
{
    [TestClass]
    [DeploymentItem("TestFiles\\TestResults")]
    public class ParseTestOutputTest
    {
        #region Test Methods

        [TestMethod]
        public void GetCounterInfo()
        {
            var activity = new ParseTestOutput();
            var document = XDocument.Load(File.OpenRead("TestFiles\\TestResults.trx"));
            var resultSummary = activity.GetResultSummary(document);

            var counterInfo = activity.GetCounterInfo(resultSummary);

            Assert.AreEqual(354, counterInfo.Total);
            Assert.AreEqual(352, counterInfo.Passed);
            Assert.AreEqual(2, counterInfo.Inconclusive);
        }

        [TestMethod]
        public void GetOutcome()
        {
            var activity = new ParseTestOutput();
            var document = XDocument.Load(File.OpenRead("TestFiles\\TestResults.trx"));
            var resultSummary = activity.GetResultSummary(document);

            var outcome = activity.GetOutcome(resultSummary);

            Assert.AreEqual(TestRunOutcome.Inconclusive, outcome);
        }

        #endregion
    }
}