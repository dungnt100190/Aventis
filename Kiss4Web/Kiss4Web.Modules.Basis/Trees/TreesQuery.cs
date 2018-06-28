using System.Collections.Generic;
using Kiss4Web.Infrastructure.Authorization;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Modules.Basis.Trees
{
    [Kiss4Right("CtlFallNavigator")]
    public class TreesQuery : Message<IEnumerable<TreeDisplayItem>>
    {
        public bool Active { get; set; }
        public bool Closed { get; set; }
        public bool Archived { get; set; }
        public bool IncludeGroup { get; set; }
        public bool IncludeGuest { get; set; }
        public bool IncludeTasks { get; set; }
    }
}