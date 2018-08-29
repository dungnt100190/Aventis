namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GvAuflage")]
    public partial class GvAuflage
    {
        public int GvAuflageID { get; set; }

        public int GvGesuchID { get; set; }

        public int GvAuflageTypCode { get; set; }

        public DateTime Erfasst { get; set; }

        [Required]
        [StringLength(200)]
        public string Gegenstand { get; set; }

        [Column(TypeName = "money")]
        public decimal? Betrag { get; set; }

        public DateTime Faellig { get; set; }

        public bool SchriftlicheVerpflichtung { get; set; }

        public bool Erledigt { get; set; }

        public bool Erlassen { get; set; }

        public string Bemerkung { get; set; }

        public string Erlassungsgrund { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate1Betrag { get; set; }

        public DateTime? Rate1Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate2Betrag { get; set; }

        public DateTime? Rate2Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate3Betrag { get; set; }

        public DateTime? Rate3Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate4Betrag { get; set; }

        public DateTime? Rate4Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate5Betrag { get; set; }

        public DateTime? Rate5Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate6Betrag { get; set; }

        public DateTime? Rate6Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate7Betrag { get; set; }

        public DateTime? Rate7Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate8Betrag { get; set; }

        public DateTime? Rate8Datum { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] GvAuflageTS { get; set; }

        public virtual GvGesuch GvGesuch { get; set; }
    }
}
