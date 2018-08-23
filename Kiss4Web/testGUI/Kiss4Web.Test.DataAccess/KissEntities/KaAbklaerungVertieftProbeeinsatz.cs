namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaAbklaerungVertieftProbeeinsatz")]
    public partial class KaAbklaerungVertieftProbeeinsatz
    {
        public int KaAbklaerungVertieftProbeeinsatzID { get; set; }

        public int KaAbklaerungVertieftID { get; set; }

        public DateTime? Datum { get; set; }

        public int? KaAbklaerungProzessschrittCode { get; set; }

        public int? DocumentID_Prozessschritt { get; set; }

        public bool HatStattgefunden { get; set; }

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
        public byte[] KaAbklaerungVertieftProbeeinsatzTS { get; set; }

        public virtual KaAbklaerungVertieft KaAbklaerungVertieft { get; set; }
    }
}
