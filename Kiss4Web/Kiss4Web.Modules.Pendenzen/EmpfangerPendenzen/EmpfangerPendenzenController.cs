using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.EmpfangerPendenzen
{
    [Authorize]
    public class EmpfangerPendenzenController : Controller
    {
		private readonly IMediator _mediator;

		public EmpfangerPendenzenController(IMediator mediator)
		{
			_mediator = mediator;
		}

        //[HttpGet]
        //[Route("/api/Pendenzen/GetEmpfanger")]
        [HttpGet("/api/Pendenzen/GetEmpfanger")]
		public Task<IEnumerable<EmpfangerItem>> GetEmpfangerPendenzen()
		{
			var query = new EmpfangerPendenzenQuery()
			{
				Keyword = ""
			};

			return _mediator.Process(query);
		}
	}
}
