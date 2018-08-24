namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaMietvertrag")]
    public partial class BaMietvertrag
    {
        public int BaMietvertragID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        [Column(TypeName = "money")]
        public decimal? Mietkosten { get; set; }

        [Column(TypeName = "money")]
        public decimal? Nebenkosten { get; set; }

        [Column(TypeName = "money")]
        public decimal? KostenanteilUE { get; set; }

        [Column(TypeName = "money")]
        public decimal? Mietdepot { get; set; }

        public int? BaInstitutionID { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaMietvertragTS { get; set; }

        public int? BaPersonID { get; set; }

        public DateTime? GarantieBis { get; set; }

        public bool? MieteAbgetreten { get; set; }

        [Column(TypeName = "money")]
        public decimal? Mietzinsgarantie { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
