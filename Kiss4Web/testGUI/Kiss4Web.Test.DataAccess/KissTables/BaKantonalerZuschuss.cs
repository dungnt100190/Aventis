namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaKantonalerZuschuss")]
    public partial class BaKantonalerZuschuss
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaKantonalerZuschuss()
        {
            BaPerson_KantonalerZuschuss = new HashSet<BaPerson_KantonalerZuschuss>();
        }

        public int BaKantonalerZuschussID { get; set; }

        [Required]
        [StringLength(255)]
        public string Bezeichnung { get; set; }

        public int? BezeichnungTID { get; set; }

        public int KantonCode { get; set; }

        public bool Aktiv { get; set; }

        [StringLength(2000)]
        public string Bemerkungen { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaKantonalerZuschussTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson_KantonalerZuschuss> BaPerson_KantonalerZuschuss { get; set; }
    }
}
