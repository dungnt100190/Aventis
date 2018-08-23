namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaVermittlungEinsatz")]
    public partial class KaVermittlungEinsatz
    {
        public int KaVermittlungEinsatzID { get; set; }

        public int? KaVermittlungVorschlagID { get; set; }

        public DateTime? Lehrvertrag { get; set; }

        public DateTime? EinsatzVon { get; set; }

        public DateTime? EinsatzBis { get; set; }

        public bool? Unbefristet { get; set; }

        public bool? Verlaengerung { get; set; }

        public int? Arbeitspensum { get; set; }

        [StringLength(100)]
        public string ArbeitspensumErgaenzungen { get; set; }

        public int? Leistungsfaehigkeit { get; set; }

        public int? EinsatzVereinbarungDokID { get; set; }

        public DateTime? EinsatzVereinbarungErhalten { get; set; }

        public bool? EinsatzVereinbarungUnterschrieben { get; set; }

        public int? EinsatzEinladungDokID { get; set; }

        public DateTime? BIEAZDatumVon { get; set; }

        public DateTime? BIEAZDatumBis { get; set; }

        public bool? BIEAZVerlaengert { get; set; }

        public int? BIEAZVereinbarungDokID { get; set; }

        public bool? BIEAZVereinbarungUnterschrieben { get; set; }

        [StringLength(1000)]
        public string BIEAZBemerkung { get; set; }

        [Column(TypeName = "money")]
        public decimal? BIBruttolohn { get; set; }

        public int? BIFinanzierungsgradEAZ { get; set; }

        [Column(TypeName = "money")]
        public decimal? BIBeteilungEAZ { get; set; }

        public DateTime? BIPZwischenbericht1Datum { get; set; }

        public bool? BIPZwischenbericht1Erhalten { get; set; }

        public DateTime? BIPZwischenbericht2Datum { get; set; }

        public bool? BIPZwischenbericht2Erhalten { get; set; }

        public int? InizioEinsatzAbbruchDurchCode { get; set; }

        public DateTime? InizioEinsatzAbbruch { get; set; }

        public DateTime? Abschluss { get; set; }

        [StringLength(100)]
        public string InizioAbschlussGrund { get; set; }

        [StringLength(100)]
        public string InizioLoesung { get; set; }

        public int? InizioAnschlussloesungCode { get; set; }

        public int? BIAbschlussGrundCode { get; set; }

        public int? BIPAbschlussGrundCode { get; set; }

        public int? BIBIPSIAbschlussDurchCode { get; set; }

        public int? SIAbschlussGrundCode { get; set; }

        public int? Attest { get; set; }

        [StringLength(1000)]
        public string EinsatzBemerkungen { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaVermittlungEinsatzTS { get; set; }

        public int? MigrationKA { get; set; }

        public virtual KaVermittlungVorschlag KaVermittlungVorschlag { get; set; }
    }
}
