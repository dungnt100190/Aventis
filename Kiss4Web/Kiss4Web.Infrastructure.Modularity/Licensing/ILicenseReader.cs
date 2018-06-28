using System.Collections.Generic;

namespace Kiss4Web.Infrastructure.Modularity.Licensing
{
    public interface ILicenseReader
    {
        IEnumerable<KissModul> GetLicensedModules();
    }
}