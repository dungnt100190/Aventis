namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShEinzelzahlung")]
    public partial class ShEinzelzahlung
    {
        public int ShEinzelzahlungID { get; set; }

        public int BgBudgetID { get; set; }

        public int? BaPersonID { get; set; }

        public int ShBelegID { get; set; }

        public int? FlKostenartID { get; set; }

        public int? BgSpezkontoID { get; set; }

        public int? BgPositionsartID { get; set; }

        public DateTime? RechnungDatum { get; set; }

        [StringLength(100)]
        public string NameEinzelzahlung { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragAnfrage { get; set; }

        public int ShStatusEinzelzahlungCode { get; set; }

        [Column(TypeName = "text")]
        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] ShEinzelzahlungTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BgBudget BgBudget { get; set; }

        public virtual BgPositionsart BgPositionsart { get; set; }

        public virtual BgSpezkonto BgSpezkonto { get; set; }
    }
}
