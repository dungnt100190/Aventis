namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaAbklaerungIntake")]
    public partial class KaAbklaerungIntake
    {
        public int KaAbklaerungIntakeID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? Datum { get; set; }

        public int? KaAbklaerungPhaseIntakeCode { get; set; }

        public int? KaAbklaerungStatusDossierCode { get; set; }

        public string AsdFragen { get; set; }

        public DateTime? Gespraechstermin { get; set; }

        public int? KaAbklaerungPraesenzCode { get; set; }

        public string Bemerkung { get; set; }

        public DateTime? DatumIntegration { get; set; }

        public int? KaAbklaerungIntegrBeurCode { get; set; }

        public int? KaAbklaerungGrundDossCode { get; set; }

        public bool SichtbarSDFlag { get; set; }

        public int? DocumentID_Integration { get; set; }

        public int? DocumentID_FormularAsD { get; set; }

        public int? DocumentID_ZusammenfassungEG { get; set; }

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
        public byte[] KaAbklaerungIntakeTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
