namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbKreditor")]
    public partial class FbKreditor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FbKreditor()
        {
            FbZahlungswegs = new HashSet<FbZahlungsweg>();
        }

        public int FbKreditorID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(20)]
        public string KurzName { get; set; }

        [StringLength(50)]
        public string Zusatz { get; set; }

        [StringLength(200)]
        public string Strasse { get; set; }

        [Required]
        [StringLength(8)]
        public string PLZ { get; set; }

        [Required]
        [StringLength(50)]
        public string Ort { get; set; }

        public bool Aktiv { get; set; }

        public int? AufwandKonto { get; set; }

        public int? BaLandID { get; set; }

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
        public byte[] FbKreditorTS { get; set; }

        public virtual BaLand BaLand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbZahlungsweg> FbZahlungswegs { get; set; }
    }
}
