using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaWvcode
    {
        public BaWvcode()
        {
            KbWveinzelposten = new HashSet<KbWveinzelposten>();
        }

        public int BaWvcodeId { get; set; }
        public int BaPersonId { get; set; }
        public int? BaWvcode1 { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? StatusCode { get; set; }
        public string Bemerkung { get; set; }
        public string HeimatKantonNr { get; set; }
        public string WohnKantonNr { get; set; }
        public string KantonKuerzel { get; set; }
        public bool? Auslandschweizer { get; set; }
        public byte[] BaWvcodeTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public ICollection<KbWveinzelposten> KbWveinzelposten { get; set; }
    }
}
