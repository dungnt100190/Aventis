namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesDokument")]
    public partial class KesDokument
    {
        public int KesDokumentID { get; set; }

        public int? KesAuftragID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int? BaPersonID_Adressat { get; set; }

        public int? BaInstitutionID_Adressat { get; set; }

        public string Stichwort { get; set; }

        public int? KesDokumentResultatCode { get; set; }

        public int? KesDokumentArtCode { get; set; }

        public int? XDocumentID_Dokument { get; set; }

        public int? XDocumentID_Versand { get; set; }

        public int KesDokumentTypCode { get; set; }

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
        public byte[] KesDokumentTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual KesAuftrag KesAuftrag { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
