using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen.Positionsarten
{
    [Authorize]
    public class PositionsartenController : Controller
    {
        private readonly IMediator _mediator;

        public PositionsartenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/positionsarten11")]
        public Task<IEnumerable<PositionsartDisplayItem>> GetPositionsarten()
        {
            var query = new PositionsartenQuery();

            return _mediator.Process(query);
        }
    }
}
