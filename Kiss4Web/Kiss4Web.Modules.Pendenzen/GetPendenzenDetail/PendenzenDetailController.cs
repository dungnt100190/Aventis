using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.GetPendenzenDetail
{
    [Authorize]
    public class UserInformationController : Controller
    {
		private readonly IMediator _mediator;

		public UserInformationController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("/api/Pendenzen/GetPendenzenDetail/{taskId}")]
		public Task<PendenzenDetailItem> GetPendenzenDetail(int taskId)
		{


            var query = new PendenzenDetailQuery { TaskId = taskId };

			return _mediator.Process(query);
		}
	}
}
