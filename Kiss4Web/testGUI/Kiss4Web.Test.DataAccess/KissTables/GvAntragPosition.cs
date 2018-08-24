namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GvAntragPosition")]
    public partial class GvAntragPosition
    {
        public int GvAntragPositionID { get; set; }

        public int GvGesuchID { get; set; }

        public int GvAntragPositionTypCode { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

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
        public byte[] GvAntragPositionTS { get; set; }

        public virtual GvGesuch GvGesuch { get; set; }
    }
}
