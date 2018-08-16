using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.Leistungsverantw
{
    [Authorize]
    public class LeistungsverantwController : Controller
    {
		private readonly IMediator _mediator;

		public LeistungsverantwController(IMediator mediator)
		{
			_mediator = mediator;
		}

        //[HttpGet]
        //[Route("/api/Pendenzen/GetLeistungsverantw")]
        [HttpGet("/api/Pendenzen/GetLeistungsverantw")]
		public Task<IEnumerable<LeistungsverantwItem>> GetEmpfangerPendenzen(string keyword)
		{
			var query = new LeistungsverantwQuery() {
                Keyword = keyword
            };

			return _mediator.Process(query);
		}
	}
}
