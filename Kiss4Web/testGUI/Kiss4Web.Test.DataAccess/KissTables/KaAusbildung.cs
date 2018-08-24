namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaAusbildung")]
    public partial class KaAusbildung
    {
        public int KaAusbildungID { get; set; }

        public int FaLeistungID { get; set; }

        public string Andere { get; set; }

        public int? KaAusbildungVorbildungCode { get; set; }

        public int? KaBecoErlernterBerufCode { get; set; }

        public int? KaVermittlBiBerufsbilCode { get; set; }

        public int? KaVermittlBiBerufserfCode { get; set; }

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
        public byte[] KaAusbildungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
