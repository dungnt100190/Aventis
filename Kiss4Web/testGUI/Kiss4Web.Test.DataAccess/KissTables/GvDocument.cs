namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GvDocument")]
    public partial class GvDocument
    {
        public int GvDocumentID { get; set; }

        public int GvGesuchID { get; set; }

        public int UserID { get; set; }

        public int? BaPersonID { get; set; }

        public int? BaInstitutionID { get; set; }

        public int? DocumentID { get; set; }

        [Required]
        [StringLength(100)]
        public string Stichworte { get; set; }

        public string Bemerkungen { get; set; }

        public DateTime Datum { get; set; }

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
        public byte[] GvDocumentTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual GvGesuch GvGesuch { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
