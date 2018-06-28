using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaAmmBesch
    {
        public int KaAmmBeschId { get; set; }
        public int BaPersonId { get; set; }
        public int KaEinsatzId { get; set; }
        public int? KaEinsatzplatzId { get; set; }
        public int? ZustaendigKaId { get; set; }
        public int? Monat { get; set; }
        public int? Jahr { get; set; }
        public int? ProfilCode { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public bool GedrucktFlag { get; set; }
        public byte[] KaAkzuweiserTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public KaEinsatz KaEinsatz { get; set; }
        public KaEinsatzplatz2 KaEinsatzplatz { get; set; }
    }
}
