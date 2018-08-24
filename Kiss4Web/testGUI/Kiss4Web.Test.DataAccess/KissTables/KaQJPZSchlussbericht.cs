namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQJPZSchlussbericht")]
    public partial class KaQJPZSchlussbericht
    {
        public int KaQJPZSchlussberichtID { get; set; }

        public int FaLeistungID { get; set; }

        public int? AQualitaetCode { get; set; }

        public int? ATempoCode { get; set; }

        public int? AOrganisationCode { get; set; }

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

        public int? SchlussberichtDokID { get; set; }

        public DateTime? BeurteilungDat { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaQJPZSchlussberichtTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
