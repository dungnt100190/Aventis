namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GvFond
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GvFond()
        {
            GvFonds_XOrgUnit = new HashSet<GvFonds_XOrgUnit>();
            GvGesuches = new HashSet<GvGesuch>();
        }

        [Key]
        public int GvFondsID { get; set; }

        public int? KbZahlungskontoID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        [Required]
        [StringLength(200)]
        public string NameKurz { get; set; }

        [Required]
        [StringLength(500)]
        public string NameLang { get; set; }

        public string Bemerkung { get; set; }

        public int? BemerkungTID { get; set; }

        public int GvFondsTypCode { get; set; }

        public bool IstCH { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] GvFondsTS { get; set; }

        public virtual KbZahlungskonto KbZahlungskonto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvFonds_XOrgUnit> GvFonds_XOrgUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvGesuch> GvGesuches { get; set; }
    }
}
