namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XDBServerVersion")]
    public partial class XDBServerVersion
    {
        public int XDBServerVersionID { get; set; }

        [Required]
        [StringLength(255)]
        public string ServerVersion { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XDBServerVersionTS { get; set; }
    }
}
