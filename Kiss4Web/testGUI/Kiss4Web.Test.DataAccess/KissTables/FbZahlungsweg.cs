namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbZahlungsweg")]
    public partial class FbZahlungsweg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FbZahlungsweg()
        {
            FbBuchungs = new HashSet<FbBuchung>();
            FbDauerauftrags = new HashSet<FbDauerauftrag>();
        }

        public int FbZahlungswegID { get; set; }

        public int FbKreditorID { get; set; }

        public int? BaBankID { get; set; }

        [StringLength(50)]
        public string PCKontoNr { get; set; }

        [StringLength(50)]
        public string BankKontoNr { get; set; }

        [StringLength(50)]
        public string IBAN { get; set; }

        public int? ZahlungsArtCode { get; set; }

        public int? Zahlungsfrist { get; set; }

        [StringLength(50)]
        public string BelegBankKontoNr { get; set; }

        public bool IsActive { get; set; }

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
        public byte[] FbZahlungswegTS { get; set; }

        public virtual BaBank BaBank { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBuchung> FbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbDauerauftrag> FbDauerauftrags { get; set; }

        public virtual FbKreditor FbKreditor { get; set; }
    }
}
