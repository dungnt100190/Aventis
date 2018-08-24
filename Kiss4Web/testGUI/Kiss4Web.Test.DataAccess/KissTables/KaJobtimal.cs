namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaJobtimal")]
    public partial class KaJobtimal
    {
        public int KaJobtimalID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? ZuweiserID { get; set; }

        public int? AnmeldungCode { get; set; }

        public int? DocumentID_Faehigkeitsprofil { get; set; }

        public int? DocumentID_Rahmenvertrag { get; set; }

        public DateTime? SozialhilfebezugAb { get; set; }

        public int? KaSozialhilfebezugCode { get; set; }

        public int? DocumentID_Schlussbericht { get; set; }

        public DateTime? AbschlussDatum { get; set; }

        public int? AustrittgrundCode { get; set; }

        public int? DossierRetourAnSDGrundCode { get; set; }

        [StringLength(1000)]
        public string Bemerkungen { get; set; }

        public bool SichtbarSDFlag { get; set; }

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
        public byte[] KaJobtimalTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
