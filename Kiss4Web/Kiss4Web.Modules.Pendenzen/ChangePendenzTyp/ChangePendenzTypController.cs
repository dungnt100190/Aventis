using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.ChangePendenzTyp
{
    [Authorize]
    public class ChangePendenzTypController : Controller
	{
		private readonly IMediator _mediator;

		public ChangePendenzTypController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("/api/Pendenzen/ChangePendenzTyp")]
		public Task<ChangePendenzTypItem> ChangePendenzTyp([FromBody] ChangePendenzTypQuery query)
		{
			return _mediator.Process(query);
		}
	}
}
