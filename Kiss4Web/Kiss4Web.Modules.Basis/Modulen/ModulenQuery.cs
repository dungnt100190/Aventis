using System.Collections.Generic;
using Kiss4Web.Infrastructure.Authorization;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Modules.Basis.Modulen
{
    [Kiss4Right("CtlFallNavigator")]
    public class ModulenQuery : Message<IEnumerable<ModulDisplayItem>>
    {
    }
}