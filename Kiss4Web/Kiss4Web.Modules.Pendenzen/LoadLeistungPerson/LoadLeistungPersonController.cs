using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.LoadLeistungPerson
{
    [Authorize]
    public class LoadLeistungPersonController : Controller
	{
		private readonly IMediator _mediator;

		public LoadLeistungPersonController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("/api/Pendenzen/LoadLeistungPerson/{faFallID:int}")]
		public Task<LeistungPersonItem> LoadLeistungPerson(int faFallID)
		{
			var query = new LoadLeistungPersonQuery()
			{
				FaFallID = faFallID
			};

			return _mediator.Process(query);
		}
	}
}
