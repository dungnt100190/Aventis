using OpenQA.Selenium;
using System.Collections.Generic;

namespace Kiss4Web.Test.TestInfrastructure
{
    public class TestDataPool
    {
        public static IWebDriver Driver { get; set; }
        internal static List<object> TempEntities { get; private set; } = new List<object>();

        internal static readonly IDictionary<string, List<object>> CreatedEntities = new Dictionary<string, List<object>>();
        internal static readonly IDictionary<string, IDictionary<string, int>> IdentifierLookup = new Dictionary<string, IDictionary<string, int>>();
    }
}
