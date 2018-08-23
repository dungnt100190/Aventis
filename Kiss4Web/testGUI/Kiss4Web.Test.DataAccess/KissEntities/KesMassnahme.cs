namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesMassnahme")]
    public partial class KesMassnahme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KesMassnahme()
        {
            KesMandatsfuehrendePersons = new HashSet<KesMandatsfuehrendePerson>();
            KesMassnahme_KesArtikel = new HashSet<KesMassnahme_KesArtikel>();
            KesMassnahmeAuftrags = new HashSet<KesMassnahmeAuftrag>();
            KesMassnahmeBerichts = new HashSet<KesMassnahmeBericht>();
        }

        public int KesMassnahmeID { get; set; }

        public int FaLeistungID { get; set; }

        public bool IsKS { get; set; }

        public int? DocumentID_Errichtungsbeschluss { get; set; }

        public int? DocumentID_Aufhebungsbeschluss { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        [StringLength(255)]
        public string KesAufgabenbereichCodes { get; set; }

        [StringLength(255)]
        public string KesIndikationCodes { get; set; }

        public string Auftragstext { get; set; }

        public int? KesElterlicheSorgeObhutCode_ElterlicheSorge { get; set; }

        public int? KesElterlicheSorgeObhutCode_Obhut { get; set; }

        public DateTime? UebernahmeVon_Datum { get; set; }

        public int? UebernahmeVon_OrtschaftCode { get; set; }

        [StringLength(10)]
        public string UebernahmeVon_PLZ { get; set; }

        [StringLength(50)]
        public string UebernahmeVon_Ort { get; set; }

        public string UebernahmeVon_Kanton { get; set; }

        public int? UebernahmeVon_KesBehoerdeID { get; set; }

        public DateTime? AenderungVom_Datum { get; set; }

        public int? KesAenderungsgrundCode { get; set; }

        public DateTime? UebertragungAn_Datum { get; set; }

        public int? UebertragungAn_OrtschaftCode { get; set; }

        [StringLength(10)]
        public string UebertragungAn_PLZ { get; set; }

        [StringLength(50)]
        public string UebertragungAn_Ort { get; set; }

        public string UebertragungAn_Kanton { get; set; }

        public int? UebertragungAn_KesBehoerdeID { get; set; }

        public int? KesAufhebungsgrundCode { get; set; }

        public string Bemerkung { get; set; }

        public int? Zustaendig_KesBehoerdeID { get; set; }

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
        public byte[] KesMassnahmeTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual KesBehoerde KesBehoerde { get; set; }

        public virtual KesBehoerde KesBehoerde1 { get; set; }

        public virtual KesBehoerde KesBehoerde2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMandatsfuehrendePerson> KesMandatsfuehrendePersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahme_KesArtikel> KesMassnahme_KesArtikel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahmeAuftrag> KesMassnahmeAuftrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahmeBericht> KesMassnahmeBerichts { get; set; }
    }
}
