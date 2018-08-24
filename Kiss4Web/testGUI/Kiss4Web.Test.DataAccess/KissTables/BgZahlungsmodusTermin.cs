namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgZahlungsmodusTermin")]
    public partial class BgZahlungsmodusTermin
    {
        public int BgZahlungsmodusTerminID { get; set; }

        public int BgZahlungsmodusID { get; set; }

        public DateTime? Datum { get; set; }

        public int? TagImMonat { get; set; }

        public bool ImVormonat { get; set; }

        public short nMonatlich { get; set; }

        public bool BetragGleich { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgZahlungsmodusTerminTS { get; set; }

        public virtual BgZahlungsmodu BgZahlungsmodu { get; set; }
    }
}
