namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FsReduktion")]
    public partial class FsReduktion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FsReduktion()
        {
            FsReduktionMitarbeiters = new HashSet<FsReduktionMitarbeiter>();
        }

        public int FsReduktionID { get; set; }

        public int? BDELeistungsartID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal StandardAufwand { get; set; }

        public bool AbhaengigVonBG { get; set; }

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
        public byte[] FsReduktionTS { get; set; }

        public virtual BDELeistungsart BDELeistungsart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FsReduktionMitarbeiter> FsReduktionMitarbeiters { get; set; }
    }
}
