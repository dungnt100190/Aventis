namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbZahlungslauf")]
    public partial class KbZahlungslauf
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbZahlungslauf()
        {
            KbTransfers = new HashSet<KbTransfer>();
        }

        public int KbZahlungslaufID { get; set; }

        public int KbZahlungskontoID { get; set; }

        [StringLength(35)]
        public string PaymentMessageID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(512)]
        public string FilePath { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalBetrag { get; set; }

        public DateTime? TransferDatum { get; set; }

        public bool Transferiert { get; set; }

        [Required]
        public string Zahlungsdaten { get; set; }

        public DateTime? FaelligkeitDatum { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbZahlungslaufTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbTransfer> KbTransfers { get; set; }

        public virtual KbZahlungskonto KbZahlungskonto { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
