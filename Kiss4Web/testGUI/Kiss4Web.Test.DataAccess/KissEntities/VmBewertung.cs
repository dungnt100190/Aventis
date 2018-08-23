namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmBewertung")]
    public partial class VmBewertung
    {
        public int VmBewertungID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? Datum { get; set; }

        public int? VmMandatstypCode { get; set; }

        [StringLength(100)]
        public string VmKriterienCodes { get; set; }

        [StringLength(100)]
        public string VmKriterienListe { get; set; }

        public int? UserID { get; set; }

        public int VmFallgewichtungStichtagCode { get; set; }

        public int VmFallgewichtungJahr { get; set; }

        public int? VmMandatstypBewilligtCode { get; set; }

        public int? ProduktID { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmBewertungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
