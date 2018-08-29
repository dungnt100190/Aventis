namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GvBewilligung")]
    public partial class GvBewilligung
    {
        public int GvBewilligungID { get; set; }

        public int GvGesuchID { get; set; }

        public int UserID { get; set; }

        public int GvBewilligungCode { get; set; }

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
        public byte[] GvBewilligungTS { get; set; }

        public virtual GvGesuch GvGesuch { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
