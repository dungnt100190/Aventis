using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Model.Sozialhilfe;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Modules.Sozialhilfe.Kostenarten
{
    public class KostenartenController : Controller
    {
        private readonly IMediator _mediator;

        public KostenartenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/leistungen/{faLeistungId:int}/kostenarten")]
        public Task<IEnumerable<KostenartDisplayItem>> GetKostenartenOfLeistung(int faLeistungId, BgSpezkontoTyp typ)
        {
            var query = new KostenartenQuery { FaLeistungId = faLeistungId, Typ = typ };

            return _mediator.Process(query);
        }
    }
}