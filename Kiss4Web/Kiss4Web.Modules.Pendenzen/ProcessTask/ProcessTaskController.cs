using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.ProcessTask
{
    [Authorize]
    public class ProcessTaskController : Controller
    {
		private readonly IMediator _mediator;

		public ProcessTaskController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("/api/Pendenzen/ProcessTask")]
		public Task<bool> ProcessTask([FromBody] ProcessTaskQuery processCon)
		{
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.Where(c => c.Type == Kiss4WebClaims.UserId)
                   .Select(c => c.Value).SingleOrDefault();
            processCon.UserId = userId;
            return _mediator.Process(processCon);
		}
	}
}
