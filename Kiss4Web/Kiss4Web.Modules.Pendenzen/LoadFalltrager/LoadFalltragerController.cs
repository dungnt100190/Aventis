using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.LoadFalltrager
{
    [Authorize]
    public class LoadFalltragerController : Controller
	{
		private readonly IMediator _mediator;

		public LoadFalltragerController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("/api/Pendenzen/LoadFalltrager")]
		public Task<IEnumerable<FalltragerItem>> LoadFalltrager()
		{
			var query = new LoadFalltragerQuery()
			{
				SearchString = ""
			};

			return _mediator.Process(query);
		}
	}
}
