using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Crud;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Modules.Basis.Personen
{
    [Authorize]
    [Route("api/Personen")]
    public class PersonenController : Controller
    {
        private readonly IMediator _mediator;

        public PersonenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public Task<BaPerson> Get(int id)
        {
            return _mediator.Process(new PersonQuery { BaPersonId = id });
        }

        [HttpPost("{id:int}")]
        public Task Save([FromBody] BaPerson person)
        {
            return _mediator.Process(new SaveCommand<BaPerson> { Entity = person });
        }
    }
}