using System;
using System.Activities;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Build.Workflow.Activities;
using Microsoft.TeamFoundation.Build.Workflow.Tracking;

namespace Kiss.Activities
{
    #region Enumerations

    public enum TestRunOutcome
    {
        Completed,
        Inconclusive,
        Failed,
        Unknown
    }

    #endregion

    [ActivityTracking(ActivityTrackingOption.None)]
    [BuildActivity(HostEnvironmentOption.All)]
    [Description("Parses an MSTest results file and supplies detailed info about the test run.")]
    public class ParseTestOutput : CodeActivity
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string TRX_NAMESPACE = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";

        #endregion

        #endregion

        #region Properties

        public OutArgument<TestRunCounterInfo> CounterInfo
        {
            get;
            set;
        }

        [RequiredArgument]
        public InArgument<string> FileName
        {
            get;
            set;
        }

        public OutArgument<TestRunOutcome> Outcome
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Internal Methods

        internal TestRunCounterInfo GetCounterInfo(XElement resultSummary)
        {
            var counters = resultSummary.Descendants(XName.Get("Counters", TRX_NAMESPACE)).First();
            return new TestRunCounterInfo
            {
                Aborted = GetCounter(counters, "aborted"),
                Error = GetCounter(counters, "error"),
                Executed = GetCounter(counters, "executed"),
                Failed = GetCounter(counters, "failed"),
                Inconclusive = GetCounter(counters, "inconclusive"),
                Passed = GetCounter(counters, "passed"),
                Timeout = GetCounter(counters, "timeout"),
                Total = GetCounter(counters, "total"),
                Warning = GetCounter(counters, "warning"),
            };
        }

        internal TestRunOutcome GetOutcome(XElement resultSummary)
        {
            var outcome = resultSummary.Attribute("outcome");

            if (outcome != null)
            {
                switch (outcome.Value)
                {
                    case "Completed":
                        return TestRunOutcome.Completed;

                    case "Inconclusive":
                        return TestRunOutcome.Inconclusive;

                    case "Failed":
                        return TestRunOutcome.Failed;
                }
            }

            return TestRunOutcome.Unknown;
        }

        internal XElement GetResultSummary(XDocument document)
        {
            return document.Descendants(XName.Get("ResultSummary", TRX_NAMESPACE)).First();
        }

        #endregion

        #region Protected Methods

        protected override void Execute(CodeActivityContext context)
        {
            var fileName = FileName.Get(context);

            if (!File.Exists(fileName))
            {
                context.TrackBuildError(string.Format("File '{0}' not found.", fileName));
                return;
            }

            try
            {
                var document = XDocument.Load(File.OpenRead(fileName));
                var resultSummary = GetResultSummary(document);

                var outcome = GetOutcome(resultSummary);
                Outcome.Set(context, outcome);

                var counterInfo = GetCounterInfo(resultSummary);
                CounterInfo.Set(context, counterInfo);
            }
            catch (Exception ex)
            {
                context.TrackBuildError(string.Format("Error while parsing the test output:\r\n{0}", ex));
            }
        }

        #endregion

        #region Private Methods

        private int GetCounter(XElement counters, string attributeName)
        {
            var attribute = counters.Attribute(attributeName);

            if (attribute != null)
            {
                return int.Parse(attribute.Value);
            }

            return -1;
        }

        #endregion

        #endregion
    }

    public class TestRunCounterInfo
    {
        #region Properties

        public int Aborted
        {
            get;
            set;
        }

        public int Error
        {
            get;
            set;
        }

        public int Executed
        {
            get;
            set;
        }

        public int Failed
        {
            get;
            set;
        }

        public int Inconclusive
        {
            get;
            set;
        }

        public int Passed
        {
            get;
            set;
        }

        public int Timeout
        {
            get;
            set;
        }

        public int Total
        {
            get;
            set;
        }

        public int Warning
        {
            get;
            set;
        }

        #endregion
    }
}