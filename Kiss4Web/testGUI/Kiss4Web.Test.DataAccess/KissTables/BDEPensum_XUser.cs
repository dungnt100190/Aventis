namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDEPensum_XUser
    {
        public int BDEPensum_XUserID { get; set; }

        public int UserID { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int PensumProzent { get; set; }

        public bool ManualEdit { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BDEPensum_XUserTS { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
