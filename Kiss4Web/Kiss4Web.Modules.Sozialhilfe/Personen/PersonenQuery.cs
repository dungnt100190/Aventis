using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System.Collections.Generic;

namespace Kiss4Web.Modules.Sozialhilfe.Personen
{
    public class PersonenQuery : Message<IEnumerable<PersonDisplayItem>>
    {
        public int FaLeistungId { get; set; }
    }
}
