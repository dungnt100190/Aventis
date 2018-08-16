using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Modules.Pendenzen;
using Kiss4Web.Modules.Pendenzen.Positionsarten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.Pendenzen
{
    [Authorize]
    public class PendenzenController : Controller
    {
		private readonly IMediator _mediator;

		public PendenzenController(IMediator mediator)
		{
			_mediator = mediator;
		}

		//[HttpGet]
		//[Route("/api/Pendenzen/GetListPendenzen")]
		[HttpGet("/api/pendenzencount")]
		public Task<NavBarItemItem> GetListPendenzen()
        {
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.Where(c => c.Type == Kiss4WebClaims.UserId)
                   .Select(c => c.Value).SingleOrDefault();
            var query = new CreateUpQuery() { UserId = userId };
            
        

            return _mediator.Process(query);
		}


		[HttpGet("/api/positionsarten113333")]
		public Task<IEnumerable<PositionsartDisplayItem>> GetPositionsarten()
		{
			var query = new PositionsartenQuery();

			return _mediator.Process(query);
		}
	}
}
