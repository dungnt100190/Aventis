namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GvAuszahlungPositionValuta")]
    public partial class GvAuszahlungPositionValuta
    {
        public int GvAuszahlungPositionValutaID { get; set; }

        public int GvAuszahlungPositionID { get; set; }

        public DateTime Datum { get; set; }

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
        public byte[] GvAuszahlungPositionValutaTS { get; set; }

        public virtual GvAuszahlungPosition GvAuszahlungPosition { get; set; }
    }
}
