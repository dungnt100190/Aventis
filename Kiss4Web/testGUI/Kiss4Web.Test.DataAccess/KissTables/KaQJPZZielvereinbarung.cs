namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQJPZZielvereinbarung")]
    public partial class KaQJPZZielvereinbarung
    {
        public int KaQJPZZielvereinbarungID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? ZielDatum { get; set; }

        public string VereinbartesZiel { get; set; }

        public string ErreichenBis { get; set; }

        public string KriterienPruefen { get; set; }

        public int? BeurteilungID { get; set; }

        public DateTime? DatumBeurteilung { get; set; }

        public int? ZielvereinbarungDokID { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaQJPZZielvereinbarungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
