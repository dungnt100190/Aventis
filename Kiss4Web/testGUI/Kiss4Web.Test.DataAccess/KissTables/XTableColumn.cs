namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XTableColumn")]
    public partial class XTableColumn
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string TableName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string ColumnName { get; set; }

        public int? FieldCode { get; set; }

        [StringLength(255)]
        public string DisplayText { get; set; }

        public int? DisplayTextTID { get; set; }

        [StringLength(255)]
        public string LOVName { get; set; }

        public bool System { get; set; }

        [StringLength(2000)]
        public string Comment { get; set; }

        public int? SortKey { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XTableColumnTS { get; set; }

        public virtual XTable XTable { get; set; }
    }
}
