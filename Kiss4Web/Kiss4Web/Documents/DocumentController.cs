using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DocumentCreation;
using Kiss4Web.Infrastructure.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Documents
{
    [Authorize]
    [Route("api/documents")]
    public class DocumentsController : Controller
    {
        private readonly IMediator _mediator;

        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<int> CreateFromTemplate(int templateId, [FromBody]IEnumerable<ContextValue> contextValues)
        {
            return (await _mediator.Process(new CreateDocumentCommand { XDocTemplateId = templateId, ContextValues = contextValues })).Id;
        }
    }
}