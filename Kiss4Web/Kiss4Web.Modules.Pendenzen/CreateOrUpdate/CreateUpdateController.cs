using Kiss4Web.Infrastructure.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.CreateOrUpdate
{
    [Authorize]
    public class CreateUpdateController : Controller
    {
		private readonly IMediator _mediator;

		public CreateUpdateController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("/api/Pendenzen/CreateUpdateTask")]
		public Task<bool> CreateUpdateTask([FromBody] CreateUpdateQuery pendenzen)
		{
			return _mediator.Process(pendenzen);
		}
	}
}
