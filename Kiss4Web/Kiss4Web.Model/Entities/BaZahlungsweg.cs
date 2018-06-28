using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaZahlungsweg
    {
        public BaZahlungsweg()
        {
            BgAuszahlungPerson = new HashSet<BgAuszahlungPerson>();
            BgFinanzplanBaPerson = new HashSet<BgFinanzplanBaPerson>();
            BgZahlungsmodus = new HashSet<BgZahlungsmodus>();
            GvAbklaerendeStelle = new HashSet<GvAbklaerendeStelle>();
            GvAuszahlungPosition = new HashSet<GvAuszahlungPosition>();
            IkGlaeubiger = new HashSet<IkGlaeubiger>();
            KbBuchung = new HashSet<KbBuchung>();
        }

        public int BaZahlungswegId { get; set; }
        public int? BaPersonId { get; set; }
        public int? BaInstitutionId { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? EinzahlungsscheinCode { get; set; }
        public int? BaBankId { get; set; }
        public string BankKontoNummer { get; set; }
        public string Ibannummer { get; set; }
        public string PostKontoNummer { get; set; }
        public string ReferenzNummer { get; set; }
        public string AdresseName { get; set; }
        public string AdresseName2 { get; set; }
        public string AdresseStrasse { get; set; }
        public string AdresseHausNr { get; set; }
        public string AdressePostfach { get; set; }
        public string AdressePlz { get; set; }
        public string AdresseOrt { get; set; }
        public int? AdresseLandCode { get; set; }
        public string BaZahlwegModulStdCodes { get; set; }
        public byte[] BaZahlungswegTs { get; set; }

        public BaLand AdresseLandCodeNavigation { get; set; }
        public BaBank BaBank { get; set; }
        public BaInstitution BaInstitution { get; set; }
        public BaPerson BaPerson { get; set; }
        public ICollection<BgAuszahlungPerson> BgAuszahlungPerson { get; set; }
        public ICollection<BgFinanzplanBaPerson> BgFinanzplanBaPerson { get; set; }
        public ICollection<BgZahlungsmodus> BgZahlungsmodus { get; set; }
        public ICollection<GvAbklaerendeStelle> GvAbklaerendeStelle { get; set; }
        public ICollection<GvAuszahlungPosition> GvAuszahlungPosition { get; set; }
        public ICollection<IkGlaeubiger> IkGlaeubiger { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
    }
}
