using System.Collections.Generic;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Model.Sozialhilfe;

namespace Kiss4Web.Modules.Sozialhilfe.Spezialkonten
{
    public class SpezialkontenQuery : Message<IEnumerable<SpezialkontoDisplayItem>>
    {
        public int FaLeistungId { get; set; }
        public BgSpezkontoTyp Typ { get; set; }
        public bool NurAktive { get; set; }
    }
}