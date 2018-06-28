using System.Collections.Generic;
using Kiss4Web.Infrastructure.Modularity;
using Kiss4Web.Infrastructure.Modularity.Licensing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Authorization
{
    [AllowAnonymous]
    [Route("api/modules")]
    public class LicensedModulesController : Controller
    {
        private readonly ILicenseReader _licenseReader;

        public LicensedModulesController(ILicenseReader licenseReader)
        {
            _licenseReader = licenseReader;
        }

        public IEnumerable<KissModul> GetLicensedModules()
        {
            return _licenseReader.GetLicensedModules();
        }
    }
}