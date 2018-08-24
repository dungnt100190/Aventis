namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaLeistungBewertung")]
    public partial class FaLeistungBewertung
    {
        [Key]
        public int FaBewertungID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? Termin { get; set; }

        public DateTime? Datum { get; set; }

        public int? FaBewertungCode { get; set; }

        [StringLength(100)]
        public string FaKriterienCodes { get; set; }

        public int? UserID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FaLeistungBewertungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
