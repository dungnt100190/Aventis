namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XMessage")]
    public partial class XMessage
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string MaskName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string MessageName { get; set; }

        public int? MessageTID { get; set; }

        public int? MessageCode { get; set; }

        [StringLength(100)]
        public string Context { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XMessageTS { get; set; }
    }
}
