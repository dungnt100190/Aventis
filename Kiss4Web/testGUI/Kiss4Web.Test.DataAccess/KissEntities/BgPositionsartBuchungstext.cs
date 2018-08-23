namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgPositionsartBuchungstext")]
    public partial class BgPositionsartBuchungstext
    {
        public int BgPositionsartBuchungstextID { get; set; }

        public int BgPositionsartID { get; set; }

        public int? BgPositionsartID_UseText { get; set; }

        [StringLength(100)]
        public string Buchungstext { get; set; }

        public bool Standardwert { get; set; }

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
        public byte[] BgPositionsartBuchungstextTS { get; set; }

        public virtual BgPositionsart BgPositionsart { get; set; }

        public virtual BgPositionsart BgPositionsart1 { get; set; }
    }
}
