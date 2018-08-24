namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BDEZeitrechner")]
    public partial class BDEZeitrechner
    {
        public int BDEZeitrechnerID { get; set; }

        public int UserID { get; set; }

        public DateTime Datum { get; set; }

        public DateTime ZeitVon { get; set; }

        public DateTime? ZeitBis { get; set; }

        public DateTime? Verbucht { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BDEZeitrechnerTS { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
