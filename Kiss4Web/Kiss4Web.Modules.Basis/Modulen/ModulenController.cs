using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Modules.Basis.Modulen
{
    [Authorize]
    [Route("api/modulen")]
    public class ModulenController
    {
        private readonly IMediator _mediator;

        public ModulenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<ModulDisplayItem>> GetModules()
        {
            return _mediator.Process(new ModulenQuery());
        }
    }
}