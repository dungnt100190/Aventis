namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FbBarauszahlungZyklu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FbBarauszahlungZyklu()
        {
            FbBarauszahlungAusbezahlts = new HashSet<FbBarauszahlungAusbezahlt>();
        }

        [Key]
        public int FbBarauszahlungZyklusID { get; set; }

        public int FbBarauszahlungAuftragID { get; set; }

        public DateTime DatumStart { get; set; }

        public int DauerNaechsteZahlung { get; set; }

        public int DauerTypCode { get; set; }

        public int? WochentagCode { get; set; }

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
        public byte[] FbBarauszahlungZyklusTS { get; set; }

        public virtual FbBarauszahlungAuftrag FbBarauszahlungAuftrag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBarauszahlungAusbezahlt> FbBarauszahlungAusbezahlts { get; set; }
    }
}
