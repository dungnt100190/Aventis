namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesAuftrag")]
    public partial class KesAuftrag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KesAuftrag()
        {
            KesAuftrag_BaPerson = new HashSet<KesAuftrag_BaPerson>();
            KesDokuments = new HashSet<KesDokument>();
        }

        public int KesAuftragID { get; set; }

        public int FaLeistungID { get; set; }

        public bool IsKS { get; set; }

        public DateTime? DatumAuftrag { get; set; }

        public int? DocumentID_Auftrag { get; set; }

        public int? UserID { get; set; }

        public DateTime? DatumFrist { get; set; }

        public int? KesGefaehrdungsmeldungDurchCode { get; set; }

        public int? KesAuftragDurchCode { get; set; }

        public int? KesAuftragAbklaerungsartCode { get; set; }

        public string Anlass { get; set; }

        public string Auftrag { get; set; }

        public DateTime? AbschlussDatum { get; set; }

        public int? KesAuftragAbschlussgrundCode { get; set; }

        public int? DocumentID_BeschlussRueckmeldung { get; set; }

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
        public byte[] KesAuftragTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesAuftrag_BaPerson> KesAuftrag_BaPerson { get; set; }

        public virtual XUser XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesDokument> KesDokuments { get; set; }
    }
}
