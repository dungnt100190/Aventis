namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbBelegNr")]
    public partial class FbBelegNr
    {
        public int FbBelegNrID { get; set; }

        public int BelegNrCode { get; set; }

        public int? UserID { get; set; }

        public int? BaPersonID { get; set; }

        public int NaechsteBelegNr { get; set; }

        public int BelegNrVon { get; set; }

        public int BelegNrBis { get; set; }

        [StringLength(10)]
        public string Praefix { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbBelegNrTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
