namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDEAusbezahlteUeberstunden_XUser
    {
        public int BDEAusbezahlteUeberstunden_XUserID { get; set; }

        public int UserID { get; set; }

        public int Jahr { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        [Column(TypeName = "money")]
        public decimal AusbezahlteStd { get; set; }

        public bool ManualEdit { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BDEAusbezahlteUeberstunden_XUserTS { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
