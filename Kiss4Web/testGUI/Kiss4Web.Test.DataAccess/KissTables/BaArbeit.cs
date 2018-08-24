namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaArbeit")]
    public partial class BaArbeit
    {
        [Key]
        [Column("BaArbeit")]
        public int BaArbeit1 { get; set; }

        public int BaPersonID { get; set; }

        public int? BaInstitutionID { get; set; }

        public int? TypCode { get; set; }

        public int? PensumCode { get; set; }

        public int? BaSprachniveauCode { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public string Bemerkung { get; set; }

        public string Adresse { get; set; }

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
        public byte[] BaArbeitTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }
    }
}
