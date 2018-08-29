namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbZahlungskonto")]
    public partial class KbZahlungskonto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbZahlungskonto()
        {
            GvFonds = new HashSet<GvFond>();
            KbBuchungs = new HashSet<KbBuchung>();
            KbKontoes = new HashSet<KbKonto>();
            KbZahlungskonto_XOrgUnit = new HashSet<KbZahlungskonto_XOrgUnit>();
            KbZahlungslaufs = new HashSet<KbZahlungslauf>();
        }

        public int KbZahlungskontoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string VertragNr { get; set; }

        [Required]
        [StringLength(50)]
        public string KontoNr { get; set; }

        public int? BaBankID { get; set; }

        public int KbFinanzInstitutCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbDTAZugangTS { get; set; }

        public virtual BaBank BaBank { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvFond> GvFonds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbKonto> KbKontoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbZahlungskonto_XOrgUnit> KbZahlungskonto_XOrgUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbZahlungslauf> KbZahlungslaufs { get; set; }
    }
}
