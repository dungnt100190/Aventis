namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaBetrieb")]
    public partial class KaBetrieb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaBetrieb()
        {
            BaAdresses = new HashSet<BaAdresse>();
            KaBetriebBesprechungs = new HashSet<KaBetriebBesprechung>();
            KaBetriebDokuments = new HashSet<KaBetriebDokument>();
            KaBetriebKontakts = new HashSet<KaBetriebKontakt>();
            KaEinsatzplatzs = new HashSet<KaEinsatzplatz>();
        }

        public int KaBetriebID { get; set; }

        [Required]
        [StringLength(100)]
        public string BetriebName { get; set; }

        public int? OrganisationTypCode_OBSOLETE { get; set; }

        public int? DmgAdresseID_OBSOLETE { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        public int? SprachCode { get; set; }

        public string Bemerkung { get; set; }

        public bool Aktiv { get; set; }

        [StringLength(100)]
        public string Homepage { get; set; }

        [StringLength(150)]
        public string KontaktPerson_OBSOLETE { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaBetriebTS { get; set; }

        public int? TeilbetriebID { get; set; }

        public int? CharakterCode { get; set; }

        public bool? InAusbildungsverbund { get; set; }

        public int? MigrationKA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaAdresse> BaAdresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaBetriebBesprechung> KaBetriebBesprechungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaBetriebDokument> KaBetriebDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaBetriebKontakt> KaBetriebKontakts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaEinsatzplatz> KaEinsatzplatzs { get; set; }
    }
}
