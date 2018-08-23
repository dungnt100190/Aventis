namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BaPersonBaInstitution
    {
        public int BaPersonBaInstitutionID { get; set; }

        public int BaPersonID { get; set; }

        public int BaInstitutionID { get; set; }

        public int? BaInstitutionKontaktID { get; set; }

        public int? BaInstitutionTypID { get; set; }

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
        public byte[] BaPersonBaInstitutionTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaInstitutionKontakt BaInstitutionKontakt { get; set; }

        public virtual BaInstitutionTyp BaInstitutionTyp { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
