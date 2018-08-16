using System.Collections.Generic;
using Kiss4Web.Infrastructure.Authorization;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Modules.Pendenzen.NavBarItems
{
	public class NavBarQuery : Message<NavBarItemItem>
	{
        public string UserId { get; set; }
    }
}
