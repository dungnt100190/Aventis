using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;

namespace Kiss4Web.Modules.Pendenzen.EmpfangerPendenzen
{
    public class EmpfangerPendenzenQuery : Message<IEnumerable<EmpfangerItem>>
	{
        public string Keyword { get; set; }
    }
}
