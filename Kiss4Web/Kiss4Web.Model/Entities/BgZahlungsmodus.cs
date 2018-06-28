using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgZahlungsmodus
    {
        public BgZahlungsmodus()
        {
            BgAuszahlungPerson = new HashSet<BgAuszahlungPerson>();
            BgZahlungsmodusTermin = new HashSet<BgZahlungsmodusTermin>();
        }

        public int BgZahlungsmodusId { get; set; }
        public int FaLeistungId { get; set; }
        public string NameZahlungsmodus { get; set; }
        public int KbAuszahlungsArtCode { get; set; }
        public bool? KontoKlient { get; set; }
        public int? BaZahlungswegId { get; set; }
        public string ReferenzNummer { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? OldId { get; set; }
        public byte[] BgZahlungsmodusTs { get; set; }

        public BaZahlungsweg BaZahlungsweg { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public ICollection<BgAuszahlungPerson> BgAuszahlungPerson { get; set; }
        public ICollection<BgZahlungsmodusTermin> BgZahlungsmodusTermin { get; set; }
    }
}
