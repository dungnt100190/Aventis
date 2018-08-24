namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaExterneBildungZahlung")]
    public partial class KaExterneBildungZahlung
    {
        public int KaExterneBildungZahlungID { get; set; }

        public int? KaExterneBildungID { get; set; }

        public DateTime? Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Betrag { get; set; }

        [StringLength(200)]
        public string Zweck { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaExterneBildungZahlungTS { get; set; }

        public virtual KaExterneBildung KaExterneBildung { get; set; }
    }
}
