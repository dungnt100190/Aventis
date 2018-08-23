namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmSachversicherung")]
    public partial class VmSachversicherung
    {
        public int VmSachversicherungID { get; set; }

        public int FaLeistungID { get; set; }

        public int? BaPersonID { get; set; }

        public int? BaInstitutionID { get; set; }

        public int? VmPriMaID { get; set; }

        public int? DocumentID_Mutation { get; set; }

        public int? DocumentID_MittAnm { get; set; }

        public int? DocumentID_AufhKuend { get; set; }

        public int? VmVersicherungsartSachversicherungCode { get; set; }

        [StringLength(100)]
        public string Policenummer { get; set; }

        public decimal? Selbstbehalt { get; set; }

        [StringLength(100)]
        public string Grundpraemie { get; set; }

        public int? VmZahlungsturnusCode { get; set; }

        public DateTime? LaufzeitVon { get; set; }

        public DateTime? LaufzeitBis { get; set; }

        public DateTime? VersichertSeit { get; set; }

        [StringLength(200)]
        public string Person { get; set; }

        public string Bemerkungen { get; set; }

        public bool IsDeleted { get; set; }

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
        public byte[] VmSachversicherungTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual VmPriMa VmPriMa { get; set; }
    }
}
