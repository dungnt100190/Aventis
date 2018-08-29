namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaBetriebKontakt")]
    public partial class KaBetriebKontakt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaBetriebKontakt()
        {
            BaAdresses = new HashSet<BaAdresse>();
            KaEinsatzplatzs = new HashSet<KaEinsatzplatz>();
        }

        public int KaBetriebKontaktID { get; set; }

        public int? KaBetriebID { get; set; }

        [StringLength(50)]
        public string Titel { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Vorname { get; set; }

        [StringLength(100)]
        public string Funktion { get; set; }

        public int? GeschlechtCode { get; set; }

        public bool? Aktiv { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string TelefonMobil { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(7000)]
        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaBetriebKontaktTS { get; set; }

        public bool UseZusatzadresse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaAdresse> BaAdresses { get; set; }

        public virtual KaBetrieb KaBetrieb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaEinsatzplatz> KaEinsatzplatzs { get; set; }
    }
}
