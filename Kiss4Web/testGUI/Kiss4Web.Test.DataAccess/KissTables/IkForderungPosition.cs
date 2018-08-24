namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkForderungPosition")]
    public partial class IkForderungPosition
    {
        public int IkForderungPositionID { get; set; }

        public int IkForderungID { get; set; }

        public int IkPositionID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkForderungPositionTS { get; set; }

        public virtual IkForderung IkForderung { get; set; }

        public virtual IkPosition IkPosition { get; set; }
    }
}
