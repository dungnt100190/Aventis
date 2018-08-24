namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MigAssignment")]
    public partial class MigAssignment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Lookup { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string OldValue { get; set; }

        [StringLength(200)]
        public string NewValue { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] MigAssignmentTS { get; set; }
    }
}
