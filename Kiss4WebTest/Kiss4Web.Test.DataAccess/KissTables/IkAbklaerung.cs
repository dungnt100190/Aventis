namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkAbklaerung")]
    public partial class IkAbklaerung
    {
        public int IkAbklaerungID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int? IkAbklaerungArtCode { get; set; }

        public int? IkAbklaerungAuswertungCode { get; set; }

        public DateTime? DatumAbklaerung { get; set; }

        public DateTime? DatumAuswertung { get; set; }

        public string Bemerkung { get; set; }

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
        public byte[] IkAbklaerungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
