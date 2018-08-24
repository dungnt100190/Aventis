namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaAssistenz")]
    public partial class KaAssistenz
    {
        public int KaAssistenzID { get; set; }

        public int FaLeistungID { get; set; }

        public bool Abgemeldet { get; set; }

        public bool NichtErschienen { get; set; }

        public bool GespraechStattgefunden { get; set; }

        public bool Programmbeginn { get; set; }

        [StringLength(500)]
        public string Einsatzplatz { get; set; }

        [StringLength(50)]
        public string Stufe { get; set; }

        public bool Personalien { get; set; }

        public bool Vereinbarung { get; set; }

        public bool Zielvereinbarung { get; set; }

        public bool Schlussbericht { get; set; }

        public bool Testat { get; set; }

        [StringLength(2000)]
        public string Bemerkungen { get; set; }

        public int? KaAssistenzprojektAustrittsgrundCode { get; set; }

        public DateTime? Austrittsdatum { get; set; }

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
        public byte[] KaAssistenzTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
