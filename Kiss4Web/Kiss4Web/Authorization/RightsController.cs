using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Authorization;
using Kiss4Web.Infrastructure.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Authorization
{
    [Authorize]
    //[Route("api/rights")]
    public class RightsController : Controller
    {
        private readonly IMediator _mediator;

        public RightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/me/rights")]
        public Task<IEnumerable<Kiss4UserRight>> GetRightsOfCurrentUser()
        {
            return _mediator.Process(new AllUserRightsQuery());
        }
    }
}