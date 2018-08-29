namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmKlientenbudget")]
    public partial class VmKlientenbudget
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VmKlientenbudget()
        {
            VmPositions = new HashSet<VmPosition>();
        }

        public int VmKlientenbudgetID { get; set; }

        public int FaLeistungID { get; set; }

        public int UserID { get; set; }

        public int VmKlientenbudgetStatusCode { get; set; }

        public DateTime GueltigAb { get; set; }

        public int VmKlientenbudgetMutationsgrundCode { get; set; }

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
        public byte[] VmKlientenbudgetTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmPosition> VmPositions { get; set; }
    }
}
