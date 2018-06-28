using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Model.Sozialhilfe;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Modules.Sozialhilfe.Positionen
{
    public class PositionenController : Controller
    {
        private readonly IMediator _mediator;

        public PositionenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/spezialkonten/{bgSpezkontoId:int}/positionen")]
        public Task<IEnumerable<PositionDisplayItem>> GetPositionenOfSpezialkonto(int bgSpezkontoId, BgSpezkontoTyp typ)
        {
            var query = new PositionenQuery { BgSpezkontoId = bgSpezkontoId, Typ = typ };

            return _mediator.Process(query);
        }
    }
}