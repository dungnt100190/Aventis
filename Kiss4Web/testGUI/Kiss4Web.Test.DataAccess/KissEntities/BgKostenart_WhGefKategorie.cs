namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BgKostenart_WhGefKategorie
    {
        public int BgKostenart_WhGefKategorieID { get; set; }

        public int BgKostenartID { get; set; }

        public int WhGefKategorieID { get; set; }

        public bool IsInkassoprovision { get; set; }

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
        public byte[] BgKostenart_WhGefKategorieTS { get; set; }

        public virtual BgKostenart BgKostenart { get; set; }

        public virtual WhGefKategorie WhGefKategorie { get; set; }
    }
}
