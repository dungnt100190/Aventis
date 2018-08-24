namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbZahlungslaufValuta")]
    public partial class KbZahlungslaufValuta
    {
        public int KbZahlungslaufValutaID { get; set; }

        public int Jahr { get; set; }

        public int Monat { get; set; }

        public DateTime? DatMonatlich { get; set; }

        public DateTime? DatTeil1 { get; set; }

        public DateTime? DatTeil2 { get; set; }

        public DateTime? Dat14Tage1 { get; set; }

        public DateTime? Dat14Tage2 { get; set; }

        public DateTime? Dat14Tage3 { get; set; }

        public DateTime? DatWoche1 { get; set; }

        public DateTime? DatWoche2 { get; set; }

        public DateTime? DatWoche3 { get; set; }

        public DateTime? DatWoche4 { get; set; }

        public DateTime? DatWoche5 { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbZahlungslaufValutaTS { get; set; }
    }
}
