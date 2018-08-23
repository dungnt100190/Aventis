namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkRatenplanForderung")]
    public partial class IkRatenplanForderung
    {
        public int IkRatenplanForderungID { get; set; }

        public int? IkRatenplanID { get; set; }

        public int? IkRechtstitelID { get; set; }

        public int? IkPositionID { get; set; }

        public int? IkForderungID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkRatenplanForderungTS { get; set; }

        public virtual IkForderung IkForderung { get; set; }

        public virtual IkPosition IkPosition { get; set; }

        public virtual IkRatenplan IkRatenplan { get; set; }

        public virtual IkRechtstitel IkRechtstitel { get; set; }
    }
}
