using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Modules.Pendenzen;
using Kiss4Web.Modules.Pendenzen.Positionsarten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.MasterData
{
    [Authorize]
    public class PendenzenController : Controller
    {
		private readonly IMediator _mediator;

		public PendenzenController(IMediator mediator)
		{
			_mediator = mediator;
		}

	
		[HttpGet("/api/GetMasterData")]
		public Task<MasterDataItem> GetMasterData()
		{
			var query = new CreateUpQuery();

			return _mediator.Process(query);
		}

	}
}
