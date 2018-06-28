using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbKonto
    {
        public KbKonto()
        {
            InverseGruppeKonto = new HashSet<KbKonto>();
            KbBelegKreis = new HashSet<KbBelegKreis>();
        }

        public int KbKontoId { get; set; }
        public int? KbPeriodeId { get; set; }
        public int? GruppeKontoId { get; set; }
        public bool Kontogruppe { get; set; }
        public int? KbKontoklasseCode { get; set; }
        public string KbKontoartCodes { get; set; }
        public string KontoNr { get; set; }
        public string KontoName { get; set; }
        public decimal Vorsaldo { get; set; }
        public string SaldoGruppeName { get; set; }
        public bool? Saldovortrag { get; set; }
        public byte[] KbKontoTs { get; set; }
        public int? SortKey { get; set; }
        public int? KbZahlungskontoId { get; set; }

        public KbKonto GruppeKonto { get; set; }
        public KbPeriode KbPeriode { get; set; }
        public KbZahlungskonto KbZahlungskonto { get; set; }
        public ICollection<KbKonto> InverseGruppeKonto { get; set; }
        public ICollection<KbBelegKreis> KbBelegKreis { get; set; }
    }
}
