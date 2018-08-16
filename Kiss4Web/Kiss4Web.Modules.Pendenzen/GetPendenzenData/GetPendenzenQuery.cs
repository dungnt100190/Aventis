using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;

namespace Kiss4Web.Modules.Pendenzen.GetPendenzenData
{
    public class GetPendenzenQuery : Message<IEnumerable<PendenzenItem>>
	{
		public string ItemType { get; set; }
        public string  UserId{ get; set; }
    }
}
