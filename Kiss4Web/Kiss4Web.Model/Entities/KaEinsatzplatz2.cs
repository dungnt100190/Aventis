using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaEinsatzplatz2
    {
        public KaEinsatzplatz2()
        {
            KaAmmBesch = new HashSet<KaAmmBesch>();
            KaEinsatz = new HashSet<KaEinsatz>();
        }

        public int KaEinsatzplatzId { get; set; }
        public string Name { get; set; }
        public int ProjektCode { get; set; }
        public int? ProfilCode { get; set; }
        public int? Apvcode { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public byte[] KaEinsatzplatz2Ts { get; set; }

        public ICollection<KaAmmBesch> KaAmmBesch { get; set; }
        public ICollection<KaEinsatz> KaEinsatz { get; set; }
    }
}
