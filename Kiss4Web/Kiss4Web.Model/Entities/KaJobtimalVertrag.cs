using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaJobtimalVertrag
    {
        public int KaJobtimalVertragId { get; set; }
        public int? KaVermittlungVorschlagId { get; set; }
        public DateTime? Datum { get; set; }
        public int KaJobtimalVertragTypCode { get; set; }
        public int? DocumentId { get; set; }
        public byte[] KaJobtimalVertragTs { get; set; }

        public KaVermittlungVorschlag KaVermittlungVorschlag { get; set; }
    }
}
