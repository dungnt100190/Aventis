using System.Collections.Generic;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public class CreateDocumentCommand : Message<XDocument>
    {
        public IEnumerable<ContextValue> ContextValues { get; set; }
        public int XDocTemplateId { get; set; }
    }
}