using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class WhAsvseintrag
    {
        public WhAsvseintrag()
        {
            SstAsvsexportEintrag = new HashSet<SstAsvsexportEintrag>();
        }

        public int WhAsvseintragId { get; set; }
        public int FaLeistungId { get; set; }
        public int BaPersonId { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int AsvseintragStatusCode { get; set; }
        public string Bemerkung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public string Modified { get; set; }
        public byte[] WhAsvseintragTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public ICollection<SstAsvsexportEintrag> SstAsvsexportEintrag { get; set; }
    }
}
