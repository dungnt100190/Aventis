using System.Collections.Generic;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Model.Sozialhilfe;

namespace Kiss4Web.Modules.Sozialhilfe.Positionen
{
    public class PositionenQuery : Message<IEnumerable<PositionDisplayItem>>
    {
        public int BgSpezkontoId { get; set; }
        public BgSpezkontoTyp Typ { get; set; }
    }
}