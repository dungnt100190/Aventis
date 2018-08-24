namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaInstitutionKontakt")]
    public partial class BaInstitutionKontakt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaInstitutionKontakt()
        {
            BaPerson_BaInstitution = new HashSet<BaPersonBaInstitution>();
        }

        public int BaInstitutionKontaktID { get; set; }

        public int BaInstitutionID { get; set; }

        public bool Aktiv { get; set; }

        public bool ManuelleAnrede { get; set; }

        [StringLength(100)]
        public string Anrede { get; set; }

        [StringLength(255)]
        public string Briefanrede { get; set; }

        [StringLength(100)]
        public string Titel { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Vorname { get; set; }

        public int? GeschlechtCode { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        public int? SprachCode { get; set; }

        public string Bemerkung { get; set; }

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
        public byte[] BaInstitutionKontaktTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPersonBaInstitution> BaPerson_BaInstitution { get; set; }
    }
}
