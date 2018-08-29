namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbBuchungCode")]
    public partial class FbBuchungCode
    {
        public int FbBuchungCodeID { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public int? BaPersonID { get; set; }

        public int? SollKtoNr { get; set; }

        public int? HabenKtoNr { get; set; }

        [Column(TypeName = "money")]
        public decimal? Betrag { get; set; }

        [StringLength(200)]
        public string Text { get; set; }

        public int? UserID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbBuchungCodeTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
