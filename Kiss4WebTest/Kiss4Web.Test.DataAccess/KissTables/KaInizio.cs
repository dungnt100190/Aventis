namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaInizio")]
    public partial class KaInizio
    {
        public int KaInizioID { get; set; }

        public int? FaLeistungID { get; set; }

        public DateTime? MappeVerschickt { get; set; }

        public DateTime? AnmeldungEingegangen { get; set; }

        public int? AnmeldungDurchCode { get; set; }

        public int? SchulabschlussCode { get; set; }

        public int? EmpfehlungInizioCode { get; set; }

        public int? AbschlussPhaseCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaInizioTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
