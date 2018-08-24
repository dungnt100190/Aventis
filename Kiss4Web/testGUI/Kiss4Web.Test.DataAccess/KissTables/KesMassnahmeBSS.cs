namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesMassnahmeBSS")]
    public partial class KesMassnahmeBSS
    {
        public int KesMassnahmeBSSID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int? VmPriMaID { get; set; }

        public int? BaInstitutionID { get; set; }

        public int? KesArtikelID_MassnahmegebundeneGeschaefte { get; set; }

        public int? KesArtikelID_NichtMassnahmegebundeneGeschaefte { get; set; }

        public int? Platzierung_BaInstitutionID { get; set; }

        public int KesMassnahmeTypCode { get; set; }

        public int? KesBeistandsartCode { get; set; }

        public int? KesGefaehrdungsmeldungDurchCode { get; set; }

        public int? KesAenderungsgrundCode { get; set; }

        public int? KesAufhebungsgrundCode { get; set; }

        public int? KESBDocumentID { get; set; }

        public int? DocumentID_Urkunde { get; set; }

        public DateTime? ErrichtungVom { get; set; }

        public DateTime? AenderungVom { get; set; }

        public DateTime? UebernahmeVom { get; set; }

        public DateTime? BerichtsgenehmigungVom { get; set; }

        public DateTime? Beistandswechsel { get; set; }

        public DateTime? UebertragungVom { get; set; }

        public DateTime? AufhebungVom { get; set; }

        [StringLength(255)]
        public string KesAufgabenbereichCodes { get; set; }

        public int? KesGrundlageCode { get; set; }

        [StringLength(255)]
        public string KesIndikationCodes { get; set; }

        public int? KesElterlicheSorgeObhutCode_ElterlicheSorge { get; set; }

        public int? KesElterlicheSorgeObhutCode_Obhut { get; set; }

        [StringLength(10)]
        public string PLZ { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        public int? OrtschaftCode { get; set; }

        [StringLength(10)]
        public string Kanton { get; set; }

        public bool FuersorgerischeUnterbringung { get; set; }

        public string Bemerkung { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KesMassnahmeBSSTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaInstitution BaInstitution1 { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual KesArtikel KesArtikel { get; set; }

        public virtual KesArtikel KesArtikel1 { get; set; }

        public virtual VmPriMa VmPriMa { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
