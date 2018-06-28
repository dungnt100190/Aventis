using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Sozialhilfe.Positionsarten
{
    public class PositionsartenController : Controller
    {
        private readonly IMediator _mediator;

        public PositionsartenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/positionsarten")]
        public Task<IEnumerable<PositionsartDisplayItem>> GetPositionsarten()
        {
            var query = new PositionsartenQuery();

            return _mediator.Process(query);
        }
    }
}
