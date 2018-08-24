namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaVermittlungVorschlag")]
    public partial class KaVermittlungVorschlag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaVermittlungVorschlag()
        {
            KaJobtimalVertrags = new HashSet<KaJobtimalVertrag>();
            KaVermittlungEinsatzs = new HashSet<KaVermittlungEinsatz>();
            KaVermittlungSIZwischenberichts = new HashSet<KaVermittlungSIZwischenbericht>();
        }

        public int KaVermittlungVorschlagID { get; set; }

        public int? KaEinsatzplatzID { get; set; }

        public int? FaLeistungID { get; set; }

        public DateTime? Vorschlag { get; set; }

        public DateTime? DossierGesendet { get; set; }

        public DateTime? Vorstellungsgespraech { get; set; }

        public DateTime? SchnuppernVon { get; set; }

        public DateTime? SchnuppernBis { get; set; }

        public DateTime? VorschlagResultatDatum { get; set; }

        public int? VorschlagResultat { get; set; }

        public DateTime? VorschlagErfasst { get; set; }

        public int? VorschlagAblehnungsgrundBICode { get; set; }

        public int? VorschlagAblehnungsgrundBIPCode { get; set; }

        public int? VorschlagAblehnungsgrundSICode { get; set; }

        [StringLength(1000)]
        public string VorschlagBemerkungen { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaVermittlungVorschlagTS { get; set; }

        public int? MigrationKA { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual KaEinsatzplatz KaEinsatzplatz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaJobtimalVertrag> KaJobtimalVertrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaVermittlungEinsatz> KaVermittlungEinsatzs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaVermittlungSIZwischenbericht> KaVermittlungSIZwischenberichts { get; set; }
    }
}
