namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbDTAJournal")]
    public partial class FbDTAJournal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FbDTAJournal()
        {
            FbDTABuchungs = new HashSet<FbDTABuchung>();
        }

        public int FbDTAJournalID { get; set; }

        [Required]
        [StringLength(512)]
        public string FilePath { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalBetrag { get; set; }

        public DateTime? TransferDatum { get; set; }

        public int? FbDTAZugangID { get; set; }

        [StringLength(35)]
        public string PaymentMessageID { get; set; }

        public int UserID { get; set; }

        public bool Transferiert { get; set; }

        public string Zahlungsdaten { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbDTAJournalTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbDTABuchung> FbDTABuchungs { get; set; }

        public virtual FbDTAZugang FbDTAZugang { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
