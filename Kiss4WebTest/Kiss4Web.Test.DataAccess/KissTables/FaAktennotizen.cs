namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaAktennotizen")]
    public partial class FaAktennotizen
    {
        [Key]
        public int FaAktennotizID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public DateTime? Datum { get; set; }

        public DateTime? Zeit { get; set; }

        public int? FaDauerCode { get; set; }

        public int? FaGespraechsStatusCode { get; set; }

        [StringLength(255)]
        public string FaThemaCodes { get; set; }

        public int? FaGespraechstypCode { get; set; }

        [StringLength(200)]
        public string Kontaktpartner { get; set; }

        public int? AlimentenstelleTypCode { get; set; }

        [StringLength(200)]
        public string BaPersonIDs { get; set; }

        [StringLength(200)]
        public string Stichwort { get; set; }

        public string InhaltRTF { get; set; }

        public bool Vertraulich { get; set; }

        public bool? BesprechungThema1 { get; set; }

        public bool? BesprechungThema2 { get; set; }

        public bool? BesprechungThema3 { get; set; }

        public bool? BesprechungThema4 { get; set; }

        [StringLength(200)]
        public string BesprechungThemaText1 { get; set; }

        [StringLength(200)]
        public string BesprechungThemaText2 { get; set; }

        [StringLength(200)]
        public string BesprechungThemaText3 { get; set; }

        [StringLength(200)]
        public string BesprechungThemaText4 { get; set; }

        [StringLength(200)]
        public string BesprechungZiel1 { get; set; }

        [StringLength(200)]
        public string BesprechungZiel2 { get; set; }

        [StringLength(200)]
        public string BesprechungZiel3 { get; set; }

        [StringLength(200)]
        public string BesprechungZiel4 { get; set; }

        public int? BesprechungZielGrad1 { get; set; }

        public int? BesprechungZielGrad2 { get; set; }

        public int? BesprechungZielGrad3 { get; set; }

        public int? BesprechungZielGrad4 { get; set; }

        public int? FaKontaktartCode { get; set; }

        [StringLength(200)]
        public string Pendenz1 { get; set; }

        [StringLength(200)]
        public string Pendenz2 { get; set; }

        [StringLength(200)]
        public string Pendenz3 { get; set; }

        [StringLength(200)]
        public string Pendenz4 { get; set; }

        public bool? PendenzErledigt1 { get; set; }

        public bool? PendenzErledigt2 { get; set; }

        public bool? PendenzErledigt3 { get; set; }

        public bool? PendenzErledigt4 { get; set; }

        public bool IsDeleted { get; set; }

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
        public byte[] FaAktennotizTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
