namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HistoryVersion")]
    public partial class HistoryVersion
    {
        [Key]
        public int VerID { get; set; }

        public DateTime VersionDate { get; set; }

        [Required]
        [StringLength(100)]
        public string HostName { get; set; }

        [Required]
        [StringLength(100)]
        public string SystemUser { get; set; }

        [Required]
        [StringLength(100)]
        public string AppName { get; set; }

        [Required]
        [StringLength(128)]
        public string dbUser { get; set; }

        public int SessionID { get; set; }

        [StringLength(100)]
        public string AppUser { get; set; }

        [StringLength(1000)]
        public string UserAction { get; set; }
    }
}
