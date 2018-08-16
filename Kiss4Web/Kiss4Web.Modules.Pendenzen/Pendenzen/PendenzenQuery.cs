using System.Collections.Generic;
using Kiss4Web.Infrastructure.Authorization;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Modules.Pendenzen.Pendenzen
{
	public class CreateUpQuery : Message<NavBarItemItem>
    {
        public string UserId { get; set; }
    }
}
