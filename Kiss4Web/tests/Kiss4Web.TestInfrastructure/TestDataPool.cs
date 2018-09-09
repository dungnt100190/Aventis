using Kiss4Web.TestInfrastructure.Client;
using System.Collections.Generic;
using System.Net.Http;

namespace Kiss4Web.TestInfrastructure
{
    public static class TestDataPool
    {
        internal static readonly IDictionary<string, string> IdConventionExceptions = new Dictionary<string, string>
        {
            {"XUser", "UserID"},
            {"XUserGroup", "UserGroupID"},
            {"XRight", "RightID"},
            {"XModul", "ModulID"},
        };

        internal static readonly List<string> NoneIdentityEntities = new List<string>
        {
            "XModul"
        };

        internal static HttpClient Client;
        public static readonly List<object> TempEntities = new List<object>();

        internal static readonly IDictionary<string, List<object>> CreatedEntities = new Dictionary<string, List<object>>();
        internal static readonly IDictionary<string, IDictionary<string, int>> IdentifierLookup = new Dictionary<string, IDictionary<string, int>>();

        internal static IServiceResult CallResult;
        internal static readonly List<object> ReturnData = new List<object>();
    }
}
