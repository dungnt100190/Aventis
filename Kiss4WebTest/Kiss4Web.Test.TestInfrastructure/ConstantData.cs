using System.Collections.Generic;

namespace Kiss4Web.Test.TestInfrastructure
{
    internal class ConstantData
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
    }
}
