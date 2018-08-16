using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;

namespace Kiss4Web.Modules.Pendenzen.LoadFalltrager
{
    public class LoadFalltragerQuery : Message<IEnumerable<FalltragerItem>>
	{
        public string SearchString { get; set; }
    }
}
