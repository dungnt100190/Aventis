namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XDeleteRule")]
    public partial class XDeleteRule
    {
        public int XDeleteRuleID { get; set; }

        [Required]
        [StringLength(128)]
        public string TableName { get; set; }

        [Required]
        [StringLength(128)]
        public string ColumnName { get; set; }

        public int XDeleteRuleCode { get; set; }

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
        public byte[] XDeleteRuleTS { get; set; }
    }
}
