using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Model.Sozialhilfe;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Modules.Sozialhilfe.Spezialkonten
{
    public class SpezialkontenController : Controller
    {
        private readonly IMediator _mediator;

        public SpezialkontenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/leistungen/{faLeistungId:int}/spezialkonten")]
        public Task<IEnumerable<SpezialkontoDisplayItem>> GetSpezialkontenOfLeistung(int faLeistungId, BgSpezkontoTyp typ, bool nurAktive)
        {
            var query = new SpezialkontenQuery { FaLeistungId = faLeistungId, Typ = typ, NurAktive = nurAktive };

            return _mediator.Process(query);
        }
    }
}