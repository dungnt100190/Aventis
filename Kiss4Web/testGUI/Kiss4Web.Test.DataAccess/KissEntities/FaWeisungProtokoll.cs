namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaWeisungProtokoll")]
    public partial class FaWeisungProtokoll
    {
        public int FaWeisungProtokollID { get; set; }

        public int FaWeisungID { get; set; }

        [StringLength(100)]
        public string Aktion { get; set; }

        [StringLength(200)]
        public string Bemerkung { get; set; }

        public DateTime? Termin { get; set; }

        [StringLength(50)]
        public string Verantwortlich { get; set; }

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
        public byte[] FaWeisung_ProtokollTS { get; set; }

        public virtual FaWeisung FaWeisung { get; set; }
    }
}
