using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;

namespace Kiss4Web.Modules.Pendenzen.ErstellerPendenzen
{
    public class ErstellerPendenzenQuery : Message<string>
	{
		public int Id { get; set; }
        public string UserLoginName { get; set; }
    }
}
