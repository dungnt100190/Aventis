namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesMandatsfuehrendePerson")]
    public partial class KesMandatsfuehrendePerson
    {
        public int KesMandatsfuehrendePersonID { get; set; }

        public int KesMassnahmeID { get; set; }

        public DateTime? DatumMandatVon { get; set; }

        public DateTime? DatumMandatBis { get; set; }

        public int? DocumentID_Ernennungsurkunde { get; set; }

        public int? UserID { get; set; }

        public int? BaInstitutionID { get; set; }

        public int? KesBeistandsartCode { get; set; }

        public DateTime? DatumVorgeschlagenAm { get; set; }

        public DateTime? DatumRechnungsfuehrungVon { get; set; }

        public DateTime? DatumRechnungsfuehrungBis { get; set; }

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
        public byte[] KesMandatsfuehrendePersonTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual KesMassnahme KesMassnahme { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
