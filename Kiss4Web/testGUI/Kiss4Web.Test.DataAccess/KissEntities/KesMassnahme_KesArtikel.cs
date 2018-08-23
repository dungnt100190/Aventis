namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KesMassnahme_KesArtikel
    {
        public int KesMassnahme_KesArtikelID { get; set; }

        public int KesMassnahmeID { get; set; }

        public int KesArtikelID { get; set; }

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
        public byte[] KesMassnahme_KesArtikelTS { get; set; }

        public virtual KesArtikel KesArtikel { get; set; }

        public virtual KesMassnahme KesMassnahme { get; set; }
    }
}
