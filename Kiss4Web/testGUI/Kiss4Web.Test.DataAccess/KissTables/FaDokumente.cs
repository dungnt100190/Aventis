namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaDokumente")]
    public partial class FaDokumente
    {
        public int FaDokumenteID { get; set; }

        public int FaLeistungID { get; set; }

        public int? BaPersonID_LT { get; set; }

        public int? BaPersonID_Adressat { get; set; }

        public int? BaInstitutionID_Adressat { get; set; }

        public int? VmPriMaID_Adressat { get; set; }

        public int? UserID_Absender { get; set; }

        public int? UserID_VisumBeantragtDurch { get; set; }

        public int? UserID_VisumBeantragtBei { get; set; }

        public int? UserID_VisiertDurch { get; set; }

        public int? UserID_EkVisumUser { get; set; }

        public int? DocumentID { get; set; }

        public int? DocumentID_Merkblatt { get; set; }

        [StringLength(200)]
        public string BaPersonIDs { get; set; }

        public DateTime? DatumErstellung { get; set; }

        public int? StatusCode { get; set; }

        public DateTime? PendenzDatum { get; set; }

        public bool? PendenzErledigt { get; set; }

        public int? VmErbDienstCode { get; set; }

        public int? FaDauerCode { get; set; }

        [StringLength(200)]
        public string Stichwort { get; set; }

        public int? EingangAusgang { get; set; }

        public int? ThemaCode { get; set; }

        public DateTime? VisumBeantragtDatum { get; set; }

        public DateTime? VisiertDatum { get; set; }

        public int? EkStatusCode { get; set; }

        public int? EkLaufNr { get; set; }

        public int? EkKW { get; set; }

        public int? EkJahr { get; set; }

        public DateTime? EkVisumDatum { get; set; }

        [StringLength(500)]
        public string Bemerkung { get; set; }

        [StringLength(200)]
        public string FaThemaCodes { get; set; }

        public bool Vertraulich { get; set; }

        public bool IsDeleted { get; set; }

        public bool IstBericht { get; set; }

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
        public byte[] FaDokumenteTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BaPerson BaPerson1 { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual VmPriMa VmPriMa { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUser XUser1 { get; set; }

        public virtual XUser XUser2 { get; set; }

        public virtual XUser XUser3 { get; set; }

        public virtual XUser XUser4 { get; set; }
    }
}
