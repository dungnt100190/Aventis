namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaRelation")]
    public partial class BaRelation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaRelation()
        {
            BaPerson_Relation = new HashSet<BaPerson_Relation>();
        }

        public int BaRelationID { get; set; }

        [Required]
        [StringLength(100)]
        public string NameRelation { get; set; }

        [Required]
        [StringLength(75)]
        public string NameGenerisch1 { get; set; }

        [Required]
        [StringLength(75)]
        public string NameGenerisch2 { get; set; }

        [Required]
        [StringLength(50)]
        public string NameMaennlich1 { get; set; }

        [Required]
        [StringLength(50)]
        public string NameWeiblich1 { get; set; }

        [Required]
        [StringLength(50)]
        public string NameMaennlich2 { get; set; }

        [Required]
        [StringLength(50)]
        public string NameWeiblich2 { get; set; }

        public bool symmetrisch { get; set; }

        public int BfsCode12 { get; set; }

        public int BfsCode21 { get; set; }

        public int SortKey { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaRelationTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson_Relation> BaPerson_Relation { get; set; }
    }
}
