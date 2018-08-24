namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaLeistungArchiv")]
    public partial class FaLeistungArchiv
    {
        public int FaLeistungArchivID { get; set; }

        public int ArchiveID { get; set; }

        public int FaLeistungID { get; set; }

        [StringLength(100)]
        public string ArchivNr { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public int CheckInUserID { get; set; }

        public int? CheckOutUserID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FaLeistungArchivTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XArchive XArchive { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUser XUser1 { get; set; }
    }
}
