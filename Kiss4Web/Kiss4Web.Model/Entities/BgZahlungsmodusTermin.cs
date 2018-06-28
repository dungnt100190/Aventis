using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgZahlungsmodusTermin
    {
        public int BgZahlungsmodusTerminId { get; set; }
        public int BgZahlungsmodusId { get; set; }
        public DateTime? Datum { get; set; }
        public int? TagImMonat { get; set; }
        public bool? ImVormonat { get; set; }
        public short NMonatlich { get; set; }
        public bool? BetragGleich { get; set; }
        public byte[] BgZahlungsmodusTerminTs { get; set; }

        public BgZahlungsmodus BgZahlungsmodus { get; set; }
    }
}
