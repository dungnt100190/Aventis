namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaZuteilFachbereich")]
    public partial class KaZuteilFachbereich
    {
        public int KaZuteilFachbereichID { get; set; }

        public int BaPersonID { get; set; }

        public DateTime? ZuteilungVon { get; set; }

        public DateTime? ZuteilungBis { get; set; }

        public int? FachbereichID { get; set; }

        public int? NiveauCode { get; set; }

        public int? ZustaendigKaID { get; set; }

        public int? FachleitungID { get; set; }

        public int? ZuteilDokID { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaZuteilFachbereichTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
