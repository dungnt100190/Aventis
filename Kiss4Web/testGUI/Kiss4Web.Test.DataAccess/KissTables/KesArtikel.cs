namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesArtikel")]
    public partial class KesArtikel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KesArtikel()
        {
            KesMassnahme_KesArtikel = new HashSet<KesMassnahme_KesArtikel>();
            KesMassnahmeBSSes = new HashSet<KesMassnahmeBSS>();
            KesMassnahmeBSSes1 = new HashSet<KesMassnahmeBSS>();
        }

        public int KesArtikelID { get; set; }

        [Required]
        [StringLength(7)]
        public string CodeKokes { get; set; }

        [Required]
        [StringLength(50)]
        public string Artikel { get; set; }

        [StringLength(50)]
        public string Absatz { get; set; }

        [StringLength(50)]
        public string Ziffer { get; set; }

        [Required]
        [StringLength(50)]
        public string Gesetz { get; set; }

        public string Bezeichnung { get; set; }

        public string BezeichnungKurz { get; set; }

        public int KesMassnahmeTypCode { get; set; }

        public bool IsMassnahmeGebunden { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

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
        public byte[] KesArtikelTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahme_KesArtikel> KesMassnahme_KesArtikel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahmeBSS> KesMassnahmeBSSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahmeBSS> KesMassnahmeBSSes1 { get; set; }
    }
}
