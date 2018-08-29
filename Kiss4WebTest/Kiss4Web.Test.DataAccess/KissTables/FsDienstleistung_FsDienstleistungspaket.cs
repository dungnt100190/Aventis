namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FsDienstleistung_FsDienstleistungspaket
    {
        public int FsDienstleistung_FsDienstleistungspaketID { get; set; }

        public int FsDienstleistungID { get; set; }

        public int FsDienstleistungspaketID { get; set; }

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
        public byte[] FsDienstleistung_FsDienstleistungspaketTS { get; set; }

        public virtual FsDienstleistung FsDienstleistung { get; set; }

        public virtual FsDienstleistungspaket FsDienstleistungspaket { get; set; }
    }
}
