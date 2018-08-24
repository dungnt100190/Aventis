namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDESollProTag_XUser
    {
        public int BDESollProTag_XUserID { get; set; }

        public int UserID { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        [Column(TypeName = "money")]
        public decimal SollStundenProTag { get; set; }

        public bool ManualEdit { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BDESollProTag_XUserTS { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
