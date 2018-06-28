using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Kiss4Configuration.ListOfValues;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Configuration
{
    [AllowAnonymous]
    [Route("api/lookups")]
    public class LookupsController : Controller
    {
        private readonly IMediator _mediator;

        public LookupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{lovname}")]
        public Task<IEnumerable<XLovCode>> GetLovLookup(string lovName)
        {
            return _mediator.Process(new LookupQuery { LookupName = lovName });
        }
    }
}