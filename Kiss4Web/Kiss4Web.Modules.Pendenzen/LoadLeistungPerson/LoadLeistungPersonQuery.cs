using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;

namespace Kiss4Web.Modules.Pendenzen.LoadLeistungPerson
{
    public class LoadLeistungPersonQuery : Message<LeistungPersonItem>
	{
        public int FaFallID { get; set; }
	}
}
