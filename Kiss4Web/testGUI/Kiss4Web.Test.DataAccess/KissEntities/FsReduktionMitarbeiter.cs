namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FsReduktionMitarbeiter")]
    public partial class FsReduktionMitarbeiter
    {
        public int FsReduktionMitarbeiterID { get; set; }

        public int FsReduktionID { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "money")]
        public decimal OriginalReduktionZeit { get; set; }

        [Column(TypeName = "money")]
        public decimal? AngepassteReduktionZeit { get; set; }

        public int Monat { get; set; }

        public int Jahr { get; set; }

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
        public byte[] FsReduktionMitarbeiterTS { get; set; }

        public virtual FsReduktion FsReduktion { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
