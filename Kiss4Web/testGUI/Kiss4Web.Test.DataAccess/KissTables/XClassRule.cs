namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XClassRule")]
    public partial class XClassRule
    {
        public int XClassRuleID { get; set; }

        [Required]
        [StringLength(255)]
        public string ClassName { get; set; }

        [StringLength(255)]
        public string ControlName { get; set; }

        [StringLength(255)]
        public string ComponentName { get; set; }

        public int XRuleID { get; set; }

        public int SortKey { get; set; }

        public bool Active { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XClassRuleTS { get; set; }

        public virtual XClassComponent XClassComponent { get; set; }

        public virtual XClassControl XClassControl { get; set; }

        public virtual XRule XRule { get; set; }
    }
}
