namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vwIxBDELeistung_BDELeistungsart_AuswDLCode
    {
        public int? BaPersonID { get; set; }

        [Key]
        public DateTime Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? DauerSUM { get; set; }

        public int? AuswDienstleistungCode { get; set; }

        public long? cBig { get; set; }
    }
}
