namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbBarauszahlungAuftrag")]
    public partial class FbBarauszahlungAuftrag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FbBarauszahlungAuftrag()
        {
            FbBarauszahlungZyklus = new HashSet<FbBarauszahlungZyklu>();
        }

        public int FbBarauszahlungAuftragID { get; set; }

        public int FaLeistungID { get; set; }

        public int UserID_Creator { get; set; }

        public int UserID_Modifier { get; set; }

        public int? XDocumentID { get; set; }

        public bool AuszahlungenVorhanden { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        [Required]
        [StringLength(200)]
        public string Buchungstext { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int FbBarauszahlungPeriodizitaetCode { get; set; }

        public int SollKtoNr { get; set; }

        public int HabenKtoNr { get; set; }

        public int Vorbezug { get; set; }

        public int Nachbezug { get; set; }

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
        public byte[] FbBarauszahlungAuftragTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUser XUser1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBarauszahlungZyklu> FbBarauszahlungZyklus { get; set; }
    }
}
