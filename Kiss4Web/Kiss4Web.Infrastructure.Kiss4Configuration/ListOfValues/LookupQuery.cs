using System.Collections.Generic;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;

namespace Kiss4Web.Infrastructure.Kiss4Configuration.ListOfValues
{
    public class LookupQuery : Message<IEnumerable<XLovCode>>
    {
        public string LookupName { get; set; }
    }
}