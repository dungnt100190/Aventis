namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XLog")]
    public partial class XLog
    {
        public int XLogID { get; set; }

        [Required]
        [StringLength(255)]
        public string Source { get; set; }

        public int? SourceKey { get; set; }

        public int XLogLevelCode { get; set; }

        [Required]
        public string Message { get; set; }

        public string Comment { get; set; }

        [StringLength(100)]
        public string ReferenceTable { get; set; }

        public int? ReferenceID { get; set; }

        public bool NonPurgeable { get; set; }

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
        public byte[] XLogTS { get; set; }
    }
}
