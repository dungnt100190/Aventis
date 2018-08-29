namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaTransfer")]
    public partial class KaTransfer
    {
        public int KaTransferID { get; set; }

        public int FaLeistungID { get; set; }

        public bool SichtbarSDFlag { get; set; }

        public DateTime? TelErstkontaktDat { get; set; }

        public int? RueckmeldungRAVDokID { get; set; }

        public DateTime? DatumVG { get; set; }

        public int? SituationserfassungVGDokID { get; set; }

        public int? EntwicklungsverlaufDokID { get; set; }

        public int? PersonalblattDokID { get; set; }

        public int? FaehigkeitsprofilDokID { get; set; }

        public int? ArbeitsprobenDokID { get; set; }

        public int? SchlussberichtDokID { get; set; }

        public int? TeilnahmebestaetigungDokID { get; set; }

        public string AllgZiele { get; set; }

        public int? AllgZieleDokID { get; set; }

        public string Bewerbungsstrategie { get; set; }

        public DateTime? MuendAufforderungDat1 { get; set; }

        public DateTime? MuendAufforderungDat2 { get; set; }

        public string MuendAufforderungBem1 { get; set; }

        public string MuendAufforderungBem2 { get; set; }

        public int? Aufforderung1DokID { get; set; }

        public int? Aufforderung2DokID { get; set; }

        public int? Aufforderung3DokID { get; set; }

        public int? Vereinbarung1DokID { get; set; }

        public int? Vereinbarung2DokID { get; set; }

        public int? RegelverstossDokID { get; set; }

        public int? NichterscheinenDokID { get; set; }

        public int? ProgrammabbruchDokID { get; set; }

        public DateTime? AustrittDat { get; set; }

        public int? AustrittGrund { get; set; }

        public int? AustrittCode { get; set; }

        public string AustrittBem { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaTransferTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
