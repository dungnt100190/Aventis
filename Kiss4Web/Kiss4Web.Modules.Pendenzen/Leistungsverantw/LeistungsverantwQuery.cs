using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;

namespace Kiss4Web.Modules.Pendenzen.Leistungsverantw
{
    public class LeistungsverantwQuery : Message<IEnumerable<LeistungsverantwItem>>
	{
        public string Keyword { get; set; }
    }
}
