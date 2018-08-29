namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KaKur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaKur()
        {
            KaKurserfassungs = new HashSet<KaKurserfassung>();
        }

        [Key]
        public int KaKursID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Nr { get; set; }

        public int? AnzLektionen { get; set; }

        public int? Plaetze { get; set; }

        public int SektionCode { get; set; }

        public bool ClosedFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaKursTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaKurserfassung> KaKurserfassungs { get; set; }
    }
}
