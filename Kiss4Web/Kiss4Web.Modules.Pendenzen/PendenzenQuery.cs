using System.Collections.Generic;
using Kiss4Web.Infrastructure.Authorization;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.Pendenzen;
namespace Kiss4Web.Modules.Pendenzen
{
	[Kiss4Right("CtlFallNavigator")]
	public class PendenzenQuery : Message<IEnumerable<NavBarItemsModel>>
	{
		public bool Active { get; set; }
		public bool Closed { get; set; }
		public bool Archived { get; set; }
		public bool IncludeGroup { get; set; }
		public bool IncludeGuest { get; set; }
		public bool IncludeTasks { get; set; }
	}
}
