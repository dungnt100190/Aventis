namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaIntegBildung")]
    public partial class KaIntegBildung
    {
        public int KaIntegBildungID { get; set; }

        public int BaPersonID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? KaKurserfassungID { get; set; }

        public DateTime? Eintritt { get; set; }

        public DateTime? Austritt { get; set; }

        public int? AbschlussCode { get; set; }

        public int? AbschlussDokID { get; set; }

        public int? RueckmeldungDokID { get; set; }

        public string Bemerkung { get; set; }

        public bool KursbestFlag { get; set; }

        public bool SichtbarSDFlag { get; set; }

        public int? KaProgrammCode { get; set; }

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
        public byte[] KaIntegBildungTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual KaKurserfassung KaKurserfassung { get; set; }
    }
}
