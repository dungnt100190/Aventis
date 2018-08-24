namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQJIntake")]
    public partial class KaQJIntake
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaQJIntake()
        {
            KaQJIntakeGespraeches = new HashSet<KaQJIntakeGespraech>();
        }

        public int KaQJIntakeID { get; set; }

        public int FaLeistungID { get; set; }

        public int? ZuweiserID { get; set; }

        public int? ZuteilungCode { get; set; }

        public int? WerkstattCode { get; set; }

        public bool ExternFlag { get; set; }

        [StringLength(100)]
        public string Eintritt { get; set; }

        public int? WartelisteCode { get; set; }

        public int? KaQjIntakeSpracheCode_Hauptsprache { get; set; }

        public int? KaQjIntakeSpracheCode_Erstsprache { get; set; }

        public string Bemerkung { get; set; }

        public bool SichtbarSDFlag { get; set; }

        public bool? AbgemeldetALVFlag { get; set; }

        public bool? NichtErschFlag { get; set; }

        public bool? GesprStattgefFlag { get; set; }

        public int? DocumentID_Intakegespraech { get; set; }

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
        public byte[] KaQJIntakeTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQJIntakeGespraech> KaQJIntakeGespraeches { get; set; }
    }
}
