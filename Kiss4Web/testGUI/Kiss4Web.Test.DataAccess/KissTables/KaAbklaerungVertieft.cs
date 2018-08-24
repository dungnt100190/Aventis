namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaAbklaerungVertieft")]
    public partial class KaAbklaerungVertieft
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaAbklaerungVertieft()
        {
            KaAbklaerungVertieftProbeeinsatzs = new HashSet<KaAbklaerungVertieftProbeeinsatz>();
        }

        public int KaAbklaerungVertieftID { get; set; }

        public int FaLeistungID { get; set; }

        public int? KaKurserfassungID { get; set; }

        public DateTime? Datum { get; set; }

        public int? KaAbklaerungPhaseVertiefteAbklaerungenCode { get; set; }

        public int? KaAbklaerungStatusDossierCode { get; set; }

        public DateTime? DatumKursAbbruch { get; set; }

        public int? KaAbklaerungPraesenzCode { get; set; }

        public int? KaAbklaerungProbeeinsatzInCode { get; set; }

        public DateTime? EinsatzVon { get; set; }

        public DateTime? EinsatzBis { get; set; }

        public string Bemerkung { get; set; }

        public DateTime? DatumIntegration { get; set; }

        public int? KaAbklaerungIntegrBeurCode { get; set; }

        public int? DocumentID_Integration { get; set; }

        public int? KaAbklaerungGrundDossCode { get; set; }

        public DateTime? DatumAustritt { get; set; }

        public int? DocumentID_Schlussbericht { get; set; }

        public bool SichtbarSDFlag { get; set; }

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
        public byte[] KaAbklaerungVertieftTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual KaKurserfassung KaKurserfassung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAbklaerungVertieftProbeeinsatz> KaAbklaerungVertieftProbeeinsatzs { get; set; }
    }
}
