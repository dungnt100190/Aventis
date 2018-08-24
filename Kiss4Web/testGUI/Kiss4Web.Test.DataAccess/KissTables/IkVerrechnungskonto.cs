namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkVerrechnungskonto")]
    public partial class IkVerrechnungskonto
    {
        public int IkVerrechnungskontoID { get; set; }

        public int IkRechtstitelID { get; set; }

        public int BaPersonID { get; set; }

        [Column(TypeName = "money")]
        public decimal Grundforderung { get; set; }

        public DateTime? VereinbarungVom { get; set; }

        [Column(TypeName = "money")]
        public decimal BetragProMonat { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime DatumBis { get; set; }

        [Column(TypeName = "money")]
        public decimal LetzterMonat { get; set; }

        public string Bemerkung { get; set; }

        public bool IstErledigt { get; set; }

        public bool IstAnnulliert { get; set; }

        public DateTime? AnnulliertAm { get; set; }

        public int? IkVerrechnungsartCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkVerrechnungskontoTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual IkRechtstitel IkRechtstitel { get; set; }
    }
}
