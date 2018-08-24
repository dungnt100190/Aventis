namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaGesundheit")]
    public partial class BaGesundheit
    {
        public int BaGesundheitID { get; set; }

        public int BaPersonID { get; set; }

        public int Jahr { get; set; }

        public int? KVGOrganisationID { get; set; }

        [StringLength(100)]
        public string KVGKontaktPerson { get; set; }

        [StringLength(100)]
        public string KVGKontaktTelefon { get; set; }

        [StringLength(50)]
        public string KVGMitgliedNr { get; set; }

        public DateTime? KVGVersichertSeit { get; set; }

        [Column(TypeName = "money")]
        public decimal? KVGGrundPraemie { get; set; }

        [Column(TypeName = "money")]
        public decimal? KVGUnfallPraemie { get; set; }

        [Column(TypeName = "money")]
        public decimal? KVGGesundFoerdPraemie { get; set; }

        [Column(TypeName = "money")]
        public decimal? KVGZuschussBetrag { get; set; }

        [Column(TypeName = "money")]
        public decimal? KVGUmweltabgabeBetrag { get; set; }

        [Column(TypeName = "money")]
        public decimal? KVGPraemie { get; set; }

        [Column(TypeName = "money")]
        public decimal? KVGFranchise { get; set; }

        public int? KVGZahlungsPeriodeCode { get; set; }

        public int? VVGOrganisationID { get; set; }

        [StringLength(100)]
        public string VVGKontaktPerson { get; set; }

        [StringLength(100)]
        public string VVGKontaktTelefon { get; set; }

        [StringLength(50)]
        public string VVGMitgliedNr { get; set; }

        public DateTime? VVGVersichertSeit { get; set; }

        [Column(TypeName = "money")]
        public decimal? VVGPraemie { get; set; }

        [Column(TypeName = "money")]
        public decimal? VVGFranchise { get; set; }

        public int? VVGZahlungsPeriodeCode { get; set; }

        [StringLength(2000)]
        public string VVGZusaetzeRTF { get; set; }

        public bool? ZuschussInAbklaerungFlag { get; set; }

        public int? IVEingliederungsmassnahmeCode { get; set; }

        public int? PflegeDurchCode { get; set; }

        public bool? PflegebeduerftigFlag { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? ASVSAbmeldung { get; set; }

        public DateTime? ASVSAnmeldung { get; set; }

        public string Bemerkung { get; set; }

        public bool AbtretungKK { get; set; }

        public DateTime? EVAZDatum { get; set; }

        public int? ZahnarztBaInstitutionID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaGesundheitTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaInstitution BaInstitution1 { get; set; }

        public virtual BaInstitution BaInstitution2 { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
