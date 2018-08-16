using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;

namespace Kiss4Web.Modules.Pendenzen.LeistungsverantwCreate
{
    public class LeistungsverantwCreateQuery : Message<LeistungsverantwCreateItem>
	{
        public int? FaFallId { get; set; }
    }
}
