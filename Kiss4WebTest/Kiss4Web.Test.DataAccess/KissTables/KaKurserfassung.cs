namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaKurserfassung")]
    public partial class KaKurserfassung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaKurserfassung()
        {
            KaAbklaerungVertiefts = new HashSet<KaAbklaerungVertieft>();
            KaIntegBildungs = new HashSet<KaIntegBildung>();
        }

        public int KaKurserfassungID { get; set; }

        public int KursID { get; set; }

        [StringLength(25)]
        public string KursNr { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public bool SistiertFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaKurserfassungTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAbklaerungVertieft> KaAbklaerungVertiefts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaIntegBildung> KaIntegBildungs { get; set; }

        public virtual KaKur KaKur { get; set; }
    }
}
