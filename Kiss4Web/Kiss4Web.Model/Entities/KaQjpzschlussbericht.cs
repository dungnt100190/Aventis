using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQjpzschlussbericht
    {
        public int KaQjpzschlussberichtId { get; set; }
        public int FaLeistungId { get; set; }
        public int? AqualitaetCode { get; set; }
        public int? AtempoCode { get; set; }
        public int? AorganisationCode { get; set; }
        public int? LernfaehigkeitCode { get; set; }
        public int? LandesspracheCode { get; set; }
        public int? SelbstaendigCode { get; set; }
        public int? ZuverlaessigCode { get; set; }
        public int? PuenktlichCode { get; set; }
        public int? AusdauerCode { get; set; }
        public int? OrdnungCode { get; set; }
        public int? SorgfaltCode { get; set; }
        public int? AuftretenCode { get; set; }
        public int? KommunikationCode { get; set; }
        public int? TeamfaehigCode { get; set; }
        public int? KritikfaehigCode { get; set; }
        public int? FlexibilitaetCode { get; set; }
        public int? MotivationCode { get; set; }
        public int? ErscheinungCode { get; set; }
        public bool DeutschFlag { get; set; }
        public bool FranzFlag { get; set; }
        public string BemKompetenz { get; set; }
        public string BemBildung { get; set; }
        public string BemZielvereinbarung { get; set; }
        public string BemAbsenzen { get; set; }
        public string BemEmpfehlung { get; set; }
        public bool EingVermittelbarFlag { get; set; }
        public string EingVermittelbar { get; set; }
        public int? SchlussberichtDokId { get; set; }
        public DateTime? BeurteilungDat { get; set; }
        public bool SichtbarSdflag { get; set; }
        public byte[] KaQjpzschlussberichtTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
