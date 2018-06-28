using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgAuszahlungPerson
    {
        public BgAuszahlungPerson()
        {
            BgAuszahlungPersonTermin = new HashSet<BgAuszahlungPersonTermin>();
        }

        public int BgAuszahlungPersonId { get; set; }
        public int BgPositionId { get; set; }
        public int? BaPersonId { get; set; }
        public int? BgZahlungsmodusId { get; set; }
        public int? KbAuszahlungsArtCode { get; set; }
        public int? BgAuszahlungsTerminCode { get; set; }
        public string BgWochentagCodes { get; set; }
        public int? BaZahlungswegId { get; set; }
        public string Zahlungsgrund { get; set; }
        public string ReferenzNummer { get; set; }
        public string MitteilungZeile1 { get; set; }
        public string MitteilungZeile2 { get; set; }
        public string MitteilungZeile3 { get; set; }
        public string MitteilungZeile4 { get; set; }
        public byte[] BgAuszahlungPersonTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public BaZahlungsweg BaZahlungsweg { get; set; }
        public BgPosition BgPosition { get; set; }
        public BgZahlungsmodus BgZahlungsmodus { get; set; }
        public ICollection<BgAuszahlungPersonTermin> BgAuszahlungPersonTermin { get; set; }
    }
}
