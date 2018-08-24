namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQJPZBericht")]
    public partial class KaQJPZBericht
    {
        public int KaQJPZBerichtID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? Datum { get; set; }

        public int? KaQJPZBerichtTypCode { get; set; }

        public int? DocumentID { get; set; }

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
        public byte[] KaQJPZBerichtTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
