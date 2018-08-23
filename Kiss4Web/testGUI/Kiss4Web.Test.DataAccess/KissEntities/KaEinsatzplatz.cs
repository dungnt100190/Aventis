namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaEinsatzplatz")]
    public partial class KaEinsatzplatz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaEinsatzplatz()
        {
            KaVermittlungVorschlags = new HashSet<KaVermittlungVorschlag>();
        }

        public int KaEinsatzplatzID { get; set; }

        [StringLength(200)]
        public string Bezeichnung { get; set; }

        public int? BrancheCode { get; set; }

        public int? KaBetriebID { get; set; }

        public bool Aktiv { get; set; }

        public int? KaProgrammCode { get; set; }

        public int? ZustaendigKA { get; set; }

        public int? LehrberufCode { get; set; }

        public int? BerufsAusbildungTyp { get; set; }

        public bool? NeuGeschaffeneLehrstelle { get; set; }

        [StringLength(2000)]
        public string Details { get; set; }

        public DateTime? ErfassungsDatum { get; set; }

        public DateTime? EinsatzAb { get; set; }

        public bool? DauerUnbefristet { get; set; }

        public int? GesamtPensum { get; set; }

        public bool? PensumAufteilbar { get; set; }

        public int? EinzelpensumMinimum { get; set; }

        public int? EinzelpensumMaximum { get; set; }

        public bool? PensumUnbestimmt { get; set; }

        public bool? Fuehrerausweis { get; set; }

        public int? FuehrerausweisKategorieCode { get; set; }

        public bool? PCKenntnisse { get; set; }

        public int? GeschlechtCode { get; set; }

        public int? DeutschMuendlichCode { get; set; }

        public int? DeutschSchriftlichCode { get; set; }

        public int? AusbildungCode { get; set; }

        [StringLength(2000)]
        public string WeitereAnforderungen { get; set; }

        public int? KaKontaktpersonID { get; set; }

        public int? FunktionCode { get; set; }

        [StringLength(2000)]
        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaEinsatzplatzTS { get; set; }

        public int? MigrationKA { get; set; }

        public virtual KaBetrieb KaBetrieb { get; set; }

        public virtual KaBetriebKontakt KaBetriebKontakt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaVermittlungVorschlag> KaVermittlungVorschlags { get; set; }
    }
}
