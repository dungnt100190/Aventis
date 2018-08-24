namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaPhase")]
    public partial class FaPhase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FaPhase()
        {
            DynaValues = new HashSet<DynaValue>();
        }

        public int FaPhaseID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int? FsDienstleistungspaketID_Zugewiesen { get; set; }

        public int? FsDienstleistungspaketID_Bedarf { get; set; }

        public int FaPhaseCode { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? AbschlussGrundCode { get; set; }

        public string Bemerkung { get; set; }

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
        public byte[] FaPhaseTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DynaValue> DynaValues { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual FsDienstleistungspaket FsDienstleistungspaket { get; set; }

        public virtual FsDienstleistungspaket FsDienstleistungspaket1 { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
