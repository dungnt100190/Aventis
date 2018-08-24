namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IkForderung_BgKostenart
    {
        public int IkForderung_BgKostenartID { get; set; }

        public int BgKostenartID_Auszahlung { get; set; }

        public int BgKostenartID_Forderung { get; set; }

        public int? IkForderungEinmaligCode { get; set; }

        public int? IkForderungPeriodischCode { get; set; }

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
        public byte[] IkForderung_BgKostenartTS { get; set; }

        public virtual BgKostenart BgKostenart { get; set; }

        public virtual BgKostenart BgKostenart1 { get; set; }
    }
}
