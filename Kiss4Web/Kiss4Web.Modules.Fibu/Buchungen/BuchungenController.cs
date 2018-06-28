using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Modules.Fibu.Buchungen
{
    [Authorize]
    [Route("api/fibu/buchungen")]
    public class BuchungenController : Controller
    {
        private readonly IMediator _mediator;

        public BuchungenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<FbBuchung> SaveBuchung([FromBody]FbBuchung buchung, bool? dtaQuestion)
        {
            await _mediator.Process(new SaveBuchungCommand { Buchung = buchung, DtaQuestion = dtaQuestion });
            return buchung;
        }
    }
}