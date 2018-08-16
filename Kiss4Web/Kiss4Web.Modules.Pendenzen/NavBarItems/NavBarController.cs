using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.NavBarItems
{
    [Authorize]
    public class NavBarController : Controller
    {
		private readonly IMediator _mediator;

		public NavBarController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("/api/Pendenzen/LoadNavBarItems")]
		public Task<NavBarItemItem> LoadNavBarItems()
		{
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.Where(c => c.Type == Kiss4WebClaims.UserId)
                   .Select(c => c.Value).SingleOrDefault();

            var query = new NavBarQuery() { UserId = userId };

			return _mediator.Process(query);
		}
	}
}
