namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaWeisung")]
    public partial class FaWeisung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FaWeisung()
        {
            FaWeisung_BaPerson = new HashSet<FaWeisung_BaPerson>();
            FaWeisungProtokolls = new HashSet<FaWeisungProtokoll>();
        }

        public int FaWeisungID { get; set; }

        public int FaLeistungID { get; set; }

        public int UserID_Creator { get; set; }

        public int? UserID_VerantwortlichRD { get; set; }

        public int? UserID_VerantwortlichSAR { get; set; }

        public int? XTaskID_SAR { get; set; }

        public int StatusCode { get; set; }

        public int WeisungsartCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Betreff { get; set; }

        public string Ausganslage { get; set; }

        public string Auflage { get; set; }

        public int KonsequenzCodeAngedroht { get; set; }

        public int KuerzungGBAngedroht { get; set; }

        public DateTime? TerminWeisung { get; set; }

        public int? XDocumentID_Weisung { get; set; }

        public DateTime? TerminMahnung1 { get; set; }

        public int? XDocumentID_Mahnung1 { get; set; }

        public DateTime? TerminMahnung2 { get; set; }

        public int? XDocumentID_Mahnung2 { get; set; }

        public DateTime? TerminMahnung3 { get; set; }

        public int? XDocumentID_Mahnung3 { get; set; }

        public DateTime? DatumVerfuegung { get; set; }

        public int? XDocumentID_Verfuegung { get; set; }

        public int? KonsequenzCodeVerfuegt { get; set; }

        public DateTime? KonsequenzDatumVon { get; set; }

        public DateTime? KonsequenzDatumBis { get; set; }

        public int? KuerzungGBVerfuegt { get; set; }

        public DateTime? KuerzungDatumVon { get; set; }

        public DateTime? KuerzungDatumBis { get; set; }

        public bool WeisungVerschoben { get; set; }

        public bool WeisungErfuellt { get; set; }

        public bool CanDelete { get; set; }

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
        public byte[] FaWeisungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaWeisung_BaPerson> FaWeisung_BaPerson { get; set; }

        public virtual XTask XTask { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUser XUser1 { get; set; }

        public virtual XUser XUser2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaWeisungProtokoll> FaWeisungProtokolls { get; set; }
    }
}
