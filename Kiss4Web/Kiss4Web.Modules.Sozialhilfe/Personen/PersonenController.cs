using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Sozialhilfe.Personen
{
    public class PersonenController : Controller
    {
        private readonly IMediator _mediator; 

        public PersonenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/leistungen/{faLeistungId:int}/personen")]
        public Task<IEnumerable<PersonDisplayItem>> GetPersonenOfLeistung(int faLeistungId)
        {
            var query = new PersonenQuery { FaLeistungId = faLeistungId };

            return _mediator.Process(query);
        }
    }
}
