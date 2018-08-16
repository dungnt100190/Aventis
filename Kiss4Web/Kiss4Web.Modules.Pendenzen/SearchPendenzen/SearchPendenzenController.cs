using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using Kiss4Web.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Kiss4Web.Modules.Pendenzen.SearchPendenzen
{
    [Authorize]
    public class SearchPendenzenController : Controller
    {
		private readonly IMediator _mediator;

		public SearchPendenzenController(IMediator mediator)
		{
			_mediator = mediator;
		}

        //[HttpGet]
        //[Route("/api/Pendenzen/GetControlData")]
        [HttpPost("/api/Pendenzen/Search")]
        public Task<IEnumerable<TablePendenzenItem>> SearchOption([FromBody] SearchPendenzenQuery objSearch)
        {
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.Where(c => c.Type == Kiss4WebClaims.UserId)
                   .Select(c => c.Value).SingleOrDefault();
            objSearch.UserId = userId;
            return _mediator.Process(objSearch);
        }
    }
}
