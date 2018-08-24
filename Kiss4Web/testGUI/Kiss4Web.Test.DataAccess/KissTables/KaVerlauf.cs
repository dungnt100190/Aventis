namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaVerlauf")]
    public partial class KaVerlauf
    {
        public int KaVerlaufID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public DateTime? Datum { get; set; }

        public int? KaAllgemKontaktartCode { get; set; }

        [StringLength(255)]
        public string Kontaktperson { get; set; }

        [StringLength(255)]
        public string Stichwort { get; set; }

        [StringLength(255)]
        public string KaAllgemThemaCodes { get; set; }

        public string InhaltRTF { get; set; }

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
        public byte[] KaVerlaufTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
