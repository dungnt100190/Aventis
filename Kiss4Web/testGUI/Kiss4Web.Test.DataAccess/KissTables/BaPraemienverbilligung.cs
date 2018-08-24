namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaPraemienverbilligung")]
    public partial class BaPraemienverbilligung
    {
        public int BaPraemienverbilligungID { get; set; }

        public int BaPersonID { get; set; }

        public int? Jahr { get; set; }

        public int? Folgenummer { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragAnspruch { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragAuszahlung { get; set; }

        [StringLength(100)]
        public string ZahlungAn { get; set; }

        [StringLength(10)]
        public string ZahlungAn_Krankenkassennummer { get; set; }

        public DateTime? LetzteMutation { get; set; }

        [StringLength(100)]
        public string Grund { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaPraemienverbilligungTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
