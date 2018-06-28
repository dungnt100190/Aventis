using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Controllers
{
    [Route("api/Features")]
    public class FeatureConfigurationController : Controller
    {
        private readonly IFeatureRegistry _featureRegistry;

        public FeatureConfigurationController(IFeatureRegistry featureRegistry)
        {
            _featureRegistry = featureRegistry;
        }

        [HttpGet]
        [Route("GetFeatureConfiguration")]
        public object GetFeatureConfiguration(string typename)
        {
            return _featureRegistry.GetFeatureConfiguration(typename);
        }

        [HttpGet]
        public object GetFeatureConfiguration(string typename, string language = null, string key = null)
        {
            return _featureRegistry.GetFeatureConfiguration(typename, new Language(language), key);
        }
    }
}