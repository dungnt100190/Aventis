namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesPraevention")]
    public partial class KesPraevention
    {
        public int KesPraeventionID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? KesPraeventionsartCode { get; set; }

        public int? KesPraeventionsabschlussCode { get; set; }

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
        public byte[] KesPraeventionTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
