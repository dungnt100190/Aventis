namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgSpezkontoAbschluss")]
    public partial class BgSpezkontoAbschluss
    {
        public int BgSpezkontoAbschlussID { get; set; }

        public int BgSpezkontoID { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

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
        public byte[] BgSpezkontoAbschlussTS { get; set; }

        public virtual BgSpezkonto BgSpezkonto { get; set; }
    }
}
