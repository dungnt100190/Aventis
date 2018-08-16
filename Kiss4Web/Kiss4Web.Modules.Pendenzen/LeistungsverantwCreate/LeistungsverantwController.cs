using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.LeistungsverantwCreate
{
    [Authorize]
    public class LeistungsverantwCreateController : Controller
    {
		private readonly IMediator _mediator;

		public LeistungsverantwCreateController(IMediator mediator)
		{
			_mediator = mediator;
		}

        //[HttpGet]
        //[Route("/api/Pendenzen/LeistungsverantwCreate")]
        [HttpPost("/api/Pendenzen/LeistungsverantwCreate/{faFallId:int}")]
        public Task<LeistungsverantwCreateItem> LeistungsverantwCreate(int? faFallId)
        {
            if (faFallId == null)
                return null;
            var query = new LeistungsverantwCreateQuery()
            {
                FaFallId = faFallId
            };
            return _mediator.Process(query);
		}
	}
}
