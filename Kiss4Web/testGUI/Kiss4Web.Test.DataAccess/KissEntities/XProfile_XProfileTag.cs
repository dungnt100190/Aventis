namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XProfile_XProfileTag
    {
        public int XProfile_XProfileTagID { get; set; }

        public int XProfileID { get; set; }

        public int XProfileTagID { get; set; }

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
        public byte[] XProfile_XProfileTagTS { get; set; }

        public virtual XProfile XProfile { get; set; }

        public virtual XProfileTag XProfileTag { get; set; }
    }
}
