namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmPositionsart")]
    public partial class VmPositionsart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VmPositionsart()
        {
            VmPositions = new HashSet<VmPosition>();
        }

        public int VmPositionsartID { get; set; }

        public int VmKategorieCode { get; set; }

        public int? VmPositionsartTypCode { get; set; }

        public bool IstTemplate { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int SortKey { get; set; }

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
        public byte[] VmPositionsartTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmPosition> VmPositions { get; set; }
    }
}
