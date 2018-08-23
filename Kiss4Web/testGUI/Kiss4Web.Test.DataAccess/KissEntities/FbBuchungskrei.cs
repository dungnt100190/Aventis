namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FbBuchungskrei
    {
        [Key]
        public int FbBuchungskreisID { get; set; }

        public int FbBuchungskreisCode { get; set; }

        public int BaPersonID { get; set; }

        public DateTime? BuchungsDatum { get; set; }

        public int SollKtoNr { get; set; }

        public int HabenKtoNr { get; set; }

        [Column(TypeName = "money")]
        public decimal? Betrag { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbBuchungskreisTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
