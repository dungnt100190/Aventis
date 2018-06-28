using Kiss4Web.Infrastructure.Authorization;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;

namespace Kiss4Web.Modules.Basis.Personen
{
    [Kiss4Right("CtlBaPerson")]
    public class PersonQuery : Message<BaPerson>
    {
        public int BaPersonId { get; set; }
    }
}