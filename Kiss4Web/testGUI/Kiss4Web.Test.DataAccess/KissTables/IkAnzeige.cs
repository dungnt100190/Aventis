namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkAnzeige")]
    public partial class IkAnzeige
    {
        public int IkAnzeigeID { get; set; }

        public int FaLeistungID { get; set; }

        public int IkAnzeigeTypCode { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? IkAnzeigeEroeffnungGrundCode { get; set; }

        [StringLength(64)]
        public string EroeffnungGrund { get; set; }

        public int? IkAnzeigeAbschlussGrundCode { get; set; }

        [StringLength(1024)]
        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkAnzeigeTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
