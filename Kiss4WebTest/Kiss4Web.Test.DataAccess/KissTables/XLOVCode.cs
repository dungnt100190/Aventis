namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XLOVCode")]
    public partial class XLOVCode
    {
        public int XLOVCodeID { get; set; }

        public int XLOVID { get; set; }

        [Required]
        [StringLength(100)]
        public string LOVName { get; set; }

        public int Code { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        public int? TextTID { get; set; }

        public int? SortKey { get; set; }

        [StringLength(20)]
        public string ShortText { get; set; }

        public int? ShortTextTID { get; set; }

        public int? BFSCode { get; set; }

        [StringLength(2000)]
        public string Value1 { get; set; }

        public int? Value1TID { get; set; }

        [StringLength(255)]
        public string Value2 { get; set; }

        public int? Value2TID { get; set; }

        [StringLength(255)]
        public string Value3 { get; set; }

        public int? Value3TID { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(200)]
        public string LOVCodeName { get; set; }

        public bool IsActive { get; set; }

        public bool System { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XLOVCodeTS { get; set; }

        public virtual XLOV XLOV { get; set; }
    }
}
