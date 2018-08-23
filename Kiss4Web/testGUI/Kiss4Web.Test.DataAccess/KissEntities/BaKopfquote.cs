namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaKopfquote")]
    public partial class BaKopfquote
    {
        public int BaKopfquoteID { get; set; }

        public int? BaPersonID { get; set; }

        public DateTime RechnungDatum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Betrag { get; set; }

        [StringLength(200)]
        public string Zeitspanne { get; set; }

        [StringLength(500)]
        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] BaKopfquoteTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
