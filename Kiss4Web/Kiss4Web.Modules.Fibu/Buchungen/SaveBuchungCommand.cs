using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;

namespace Kiss4Web.Modules.Fibu.Buchungen
{
    public class SaveBuchungCommand : Message
    {
        public FbBuchung Buchung { get; set; }
        public bool? DtaQuestion { get; set; }
    }
}