using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaEinsatz
    {
        public KaEinsatz()
        {
            KaAmmBesch = new HashSet<KaAmmBesch>();
        }

        public int KaEinsatzId { get; set; }
        public int BaPersonId { get; set; }
        public int KaEinsatzplatzId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? AnweisungCode { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime DatumBis { get; set; }
        public bool SamstagAktiv { get; set; }
        public bool SonntagAktiv { get; set; }
        public int? BeschGrad { get; set; }
        public int? ApvzusatzCode { get; set; }
        public int? PersonenNr { get; set; }
        public DateTime? RahmenfristBis { get; set; }
        public int? AlkasseId { get; set; }
        public int? ZuweiserId { get; set; }
        public bool SichtbarSdflag { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaEinsatzTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public KaEinsatzplatz2 KaEinsatzplatz { get; set; }
        public ICollection<KaAmmBesch> KaAmmBesch { get; set; }
    }
}
