namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XDBVersion")]
    public partial class XDBVersion
    {
        public int XDBVersionID { get; set; }

        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }

        public int Build { get; set; }

        public int Revision { get; set; }

        public DateTime VersionDate { get; set; }

        [Required]
        [StringLength(500)]
        public string SQLServerVersionInfo { get; set; }

        public string ChangesSinceLastVersion { get; set; }

        [Required]
        [StringLength(20)]
        public string BackwardCompatibleDownToClientVersion { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

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
        public byte[] XDBVersionTS { get; set; }
    }
}
