namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XClassReference")]
    public partial class XClassReference
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string ClassName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string ClassName_Ref { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XClassReferenceTS { get; set; }
    }
}
