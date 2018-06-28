using System.Collections.Generic;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Model.Sozialhilfe;

namespace Kiss4Web.Modules.Sozialhilfe.Kostenarten
{
    public class KostenartenQuery : Message<IEnumerable<KostenartDisplayItem>>
    {
        public int FaLeistungId { get; set; }
        public BgSpezkontoTyp Typ { get; set; }
    }
}