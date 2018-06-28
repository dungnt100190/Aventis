using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Basis.Trees
{
    [Authorize]
    [Route("api/trees")]
    public class TreesController : Controller
    {
        private readonly IMediator _mediator;

        public TreesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<TreeDisplayItem>> GetTrees(TreesQuery query)
        {
            return _mediator.Process(query);
        }
    }
}