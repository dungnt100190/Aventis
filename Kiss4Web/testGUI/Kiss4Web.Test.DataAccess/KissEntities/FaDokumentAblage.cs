namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaDokumentAblage")]
    public partial class FaDokumentAblage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FaDokumentAblage()
        {
            FaDokumentAblage_BaPerson = new HashSet<FaDokumentAblageBaPerson>();
        }

        public int FaDokumentAblageID { get; set; }

        public int FaLeistungID { get; set; }

        public int UserID { get; set; }

        public int? BaPersonID_Adressat { get; set; }

        public int? BaInstitutionID_Adressat { get; set; }

        public int? FaDokumentAblageInhaltCode { get; set; }

        [StringLength(250)]
        public string FaThemaDokAblageCodes { get; set; }

        public DateTime? DatumErstellung { get; set; }

        public DateTime? DatumGueltigVon { get; set; }

        public DateTime? DatumGueltigBis { get; set; }

        public string Stichwort { get; set; }

        public string Bemerkung { get; set; }

        public int? DocumentID { get; set; }

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
        public byte[] FaDokumentAblageTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumentAblageBaPerson> FaDokumentAblage_BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
