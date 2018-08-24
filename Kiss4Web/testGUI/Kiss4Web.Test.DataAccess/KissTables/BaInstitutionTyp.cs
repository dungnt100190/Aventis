namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaInstitutionTyp")]
    public partial class BaInstitutionTyp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaInstitutionTyp()
        {
            BaInstitution_BaInstitutionTyp = new HashSet<BaInstitution_BaInstitutionTyp>();
            BaPerson_BaInstitution = new HashSet<BaPersonBaInstitution>();
        }

        public int BaInstitutionTypID { get; set; }

        public int? OrgUnitID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? NameTID { get; set; }

        public bool Aktiv { get; set; }

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
        public byte[] BaInstitutionTypTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaInstitution_BaInstitutionTyp> BaInstitution_BaInstitutionTyp { get; set; }

        public virtual XOrgUnit XOrgUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPersonBaInstitution> BaPerson_BaInstitution { get; set; }
    }
}
