namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesBehoerde")]
    public partial class KesBehoerde
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KesBehoerde()
        {
            KesMassnahmes = new HashSet<KesMassnahme>();
            KesMassnahmes1 = new HashSet<KesMassnahme>();
            KesMassnahmes2 = new HashSet<KesMassnahme>();
        }

        public int KesBehoerdeID { get; set; }

        [Required]
        [StringLength(50)]
        public string KESBID { get; set; }

        [Required]
        [StringLength(10)]
        public string Kanton { get; set; }

        [Required]
        [StringLength(500)]
        public string KESBName { get; set; }

        public bool IsActive { get; set; }

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
        public byte[] KesBehoerdeTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahme> KesMassnahmes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahme> KesMassnahmes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahme> KesMassnahmes2 { get; set; }
    }
}
