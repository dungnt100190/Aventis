namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaVermittlungBIBIP")]
    public partial class KaVermittlungBIBIP
    {
        public int KaVermittlungBIBIPID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? AnmeldungCode { get; set; }

        public bool Priorisiert { get; set; }

        public int? ZuweiserID { get; set; }

        public DateTime? DossierAnCoach { get; set; }

        public bool DossierInaktiv { get; set; }

        public int? DocumentID_Schlussbericht { get; set; }

        public DateTime? AbschlussDatum { get; set; }

        public bool WechselKAIntern { get; set; }

        public int? WechselKAInternGrundCode { get; set; }

        public bool DossierRetourAnSD { get; set; }

        public int? DossierRetourAnSDGrundCode { get; set; }

        [StringLength(1000)]
        public string Bemerkungen { get; set; }

        public int? MigrationKA { get; set; }

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
        public byte[] KaVermittlungBIBIPTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
