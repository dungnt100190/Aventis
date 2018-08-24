namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaZeitlichePlanung")]
    public partial class FaZeitlichePlanung
    {
        public int FaZeitlichePlanungID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? Phase1Ende { get; set; }

        public DateTime? Phase1SitAnalyse { get; set; }

        public string Phase1Bemerkungen { get; set; }

        public DateTime? Phase2Beginn { get; set; }

        public DateTime? Phase2Ende { get; set; }

        public DateTime? Phase2SitAnalyse { get; set; }

        public string Phase2Bemerkungen { get; set; }

        public DateTime? Phase3Beginn { get; set; }

        public DateTime? Phase3SitAnalyse { get; set; }

        public string Phase3Bemerkungen { get; set; }

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
        public byte[] FaZeitlichePlanungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
