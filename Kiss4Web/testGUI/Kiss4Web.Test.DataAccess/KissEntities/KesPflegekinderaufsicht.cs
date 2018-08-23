namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesPflegekinderaufsicht")]
    public partial class KesPflegekinderaufsicht
    {
        public int KesPflegekinderaufsichtID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int? BaInstitutionID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? KesPflegeartCode { get; set; }

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
        public byte[] KesPflegekinderaufsichtTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
