namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQJPZAssessment")]
    public partial class KaQJPZAssessment
    {
        public int KaQJPZAssessmentID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? DatumAssessment { get; set; }

        public bool AufgA { get; set; }

        public bool AufgB { get; set; }

        public bool AufgC { get; set; }

        public bool AufgD { get; set; }

        public bool? KandDokIn { get; set; }

        public bool ProjGefaehrFlag { get; set; }

        public string ProjGefaehrGrund { get; set; }

        public bool NichtAufgFlag { get; set; }

        public string NichtAufgGrund { get; set; }

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
        public byte[] KaQJPZAssessmentTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
