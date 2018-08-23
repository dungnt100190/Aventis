namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaVermittlungSIZwischenbericht")]
    public partial class KaVermittlungSIZwischenbericht
    {
        public int KaVermittlungSIZwischenberichtID { get; set; }

        public int? KaVermittlungVorschlagID { get; set; }

        public DateTime? Anfrage { get; set; }

        public DateTime? Mahnung { get; set; }

        public DateTime? Eingang { get; set; }

        [StringLength(2000)]
        public string Bemerkung { get; set; }

        public int? InterventionCode { get; set; }

        public int? VorgeseheneMassnahmenCode { get; set; }

        public DateTime? ZwischenberichtSD { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaVermittlungSIZwischenberichtTS { get; set; }

        public virtual KaVermittlungVorschlag KaVermittlungVorschlag { get; set; }
    }
}
