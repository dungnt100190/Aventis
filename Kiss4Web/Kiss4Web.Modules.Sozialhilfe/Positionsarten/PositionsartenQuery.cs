using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;

namespace Kiss4Web.Modules.Sozialhilfe.Positionsarten
{
    public class PositionsartenQuery : Message<IEnumerable<PositionsartDisplayItem>>
    {
    }
}
