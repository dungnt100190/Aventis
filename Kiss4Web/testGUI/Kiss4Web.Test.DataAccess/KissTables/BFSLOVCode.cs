namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BFSLOVCode")]
    public partial class BFSLOVCode
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string LOVName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        public int? TextTID { get; set; }

        [StringLength(20)]
        public string KurzText { get; set; }

        public int? KurzTextTID { get; set; }

        [StringLength(50)]
        public string Filter { get; set; }

        public int? SortKey { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BFSLOVCodeTS { get; set; }

        public virtual BFSLOV BFSLOV { get; set; }
    }
}
