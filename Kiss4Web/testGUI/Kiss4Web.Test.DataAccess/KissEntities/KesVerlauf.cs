namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesVerlauf")]
    public partial class KesVerlauf
    {
        public int KesVerlaufID { get; set; }

        public int FaLeistungID { get; set; }

        public int KesVerlaufTypCode { get; set; }

        public int? UserID { get; set; }

        public int? BaPersonID_Adressat { get; set; }

        public int? BaInstitutionID_Adressat { get; set; }

        public int? DocumentID { get; set; }

        public DateTime? Datum { get; set; }

        public int? KesKontaktartCode { get; set; }

        public int? KesDienstleistungCode { get; set; }

        public string Stichwort { get; set; }

        public int? FaDauerCode { get; set; }

        public string Inhalt { get; set; }

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
        public byte[] KesVerlaufTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
