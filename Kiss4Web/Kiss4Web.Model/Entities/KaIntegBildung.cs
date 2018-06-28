using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaIntegBildung
    {
        public int KaIntegBildungId { get; set; }
        public int BaPersonId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? KaKurserfassungId { get; set; }
        public DateTime? Eintritt { get; set; }
        public DateTime? Austritt { get; set; }
        public int? AbschlussCode { get; set; }
        public int? AbschlussDokId { get; set; }
        public int? RueckmeldungDokId { get; set; }
        public string Bemerkung { get; set; }
        public bool KursbestFlag { get; set; }
        public bool SichtbarSdflag { get; set; }
        public int? KaProgrammCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaIntegBildungTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public KaKurserfassung KaKurserfassung { get; set; }
    }
}
