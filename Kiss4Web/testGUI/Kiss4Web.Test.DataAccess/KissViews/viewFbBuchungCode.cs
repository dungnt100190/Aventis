namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewFbBuchungCode")]
    public partial class viewFbBuchungCode
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FbBuchungCodeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Code { get; set; }

        public int? BaPersonID { get; set; }

        public int? SollKtoNr { get; set; }

        public int? HabenKtoNr { get; set; }

        [Column(TypeName = "money")]
        public decimal? Betrag { get; set; }

        [StringLength(200)]
        public string Text { get; set; }

        public int? UserID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbBuchungCodeTS { get; set; }

        [StringLength(100)]
        public string SollKtoName { get; set; }

        [StringLength(100)]
        public string HabenKtoName { get; set; }

        [StringLength(202)]
        public string Mandant { get; set; }

        [StringLength(61)]
        public string PlzOrt { get; set; }

        [StringLength(200)]
        public string MTLogon { get; set; }

        [StringLength(402)]
        public string MTName { get; set; }
    }
}
