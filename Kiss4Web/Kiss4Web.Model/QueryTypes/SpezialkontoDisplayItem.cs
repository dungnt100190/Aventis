using System;
using Kiss4Web.Model.Sozialhilfe;

namespace Kiss4Web.Model.QueryTypes
{
    public class SpezialkontoDisplayItem
    {
        public int BgSpezkontoId { get; set; }
        public int FaLeistungId { get; set; }
        public BgSpezkontoTyp BgSpezkontoTypCode { get; set; }
        public string NameSpezkonto { get; set; }
        public decimal StartSaldo { get; set; }
        public bool OhneEinzelzahlung { get; set; }
        public decimal? BetragProMonat { get; set; }
        public int? BgPositionsartId { get; set; }
        public DateTime? ErsterMonat { get; set; }
        public int? BgKostenartId { get; set; }
        public string Bemerkung { get; set; }
        public byte[] BgSpezkontoTs { get; set; }
        public int? BaInstitutionId { get; set; }
        public int? BaPersonId { get; set; }
        public bool Inaktiv { get; set; }
        public int? KuerzungLaufzeitMonate { get; set; }
        public decimal? KuerzungAnteilGbl { get; set; }
        public string AbschlussBegruendung { get; set; }
        public int? AbzahlungskontoRueckerstattungCode { get; set; }
        public int? AbschlussgrundCode { get; set; }
        public decimal Saldo { get; set; }
        public int DatumVonJahr { get; set; }
        public int DatumVonMonat { get; set; }
        public int? DatumBisJahr { get; set; }
        public int? DatumBisMonat { get; set; }
        public string GueltigVon { get; set; }
        public string GueltigBis { get; set; }
        public string InstitutionName { get; set; }
        public int BewilligungStatusCode { get; set; }
        public bool ProPerson { get; set; }
        public bool ProUe { get; set; }
    }
}