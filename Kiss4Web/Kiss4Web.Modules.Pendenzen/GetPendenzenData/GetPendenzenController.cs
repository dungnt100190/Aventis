using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.GetPendenzenData
{
    [Authorize]
    public class GetPendenzenController : Controller
    {
		private readonly IMediator _mediator;

		public GetPendenzenController(IMediator mediator)
		{
			_mediator = mediator;
		}

        [HttpGet("/api/Pendenzen/GetPendenzenData/{itemType}")]
		public Task<IEnumerable<PendenzenItem>> GetPendenzenData(string itemType)
		{
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.Where(c => c.Type == Kiss4WebClaims.UserId)
                   .Select(c => c.Value).SingleOrDefault();

            var query = new GetPendenzenQuery { ItemType = itemType, UserId = userId };

			return _mediator.Process(query);
		}
	}
}
