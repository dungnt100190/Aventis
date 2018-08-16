using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.ErstellerPendenzen
{
    [Authorize]
    public class ErstellerPendenzenController : Controller
	{
		private readonly IMediator _mediator;

		public ErstellerPendenzenController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("/api/Pendenzen/GetErsteller/{id}")]
		public Task<string> GetErstellerPendenzen(int id)
		{
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userLogin = claims.Where(c => c.Type == Kiss4WebClaims.LogonName)
                   .Select(c => c.Value).SingleOrDefault();

            var query = new ErstellerPendenzenQuery { UserLoginName = userLogin };

			return _mediator.Process(query);
		}
	}
}
