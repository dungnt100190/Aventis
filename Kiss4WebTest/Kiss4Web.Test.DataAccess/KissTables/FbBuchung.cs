namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbBuchung")]
    public partial class FbBuchung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FbBuchung()
        {
            FbBarauszahlungAusbezahlts = new HashSet<FbBarauszahlungAusbezahlt>();
            FbDTABuchungs = new HashSet<FbDTABuchung>();
        }

        public int FbBuchungID { get; set; }

        public int FbPeriodeID { get; set; }

        public int BuchungTypCode { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(15)]
        public string BelegNr { get; set; }

        public int BelegNrPos { get; set; }

        public DateTime BuchungsDatum { get; set; }

        public int? SollKtoNr { get; set; }

        public int? HabenKtoNr { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        public DateTime? ValutaDatum { get; set; }

        public DateTime? ValutaDatumOriginal { get; set; }

        public int? Zahlungsfrist { get; set; }

        public int? BuchungStatusCode { get; set; }

        public int? FbDauerauftragID { get; set; }

        public DateTime? ErfassungsDatum { get; set; }

        public int? UserID { get; set; }

        public int? FbZahlungswegID { get; set; }

        [StringLength(50)]
        public string PCKontoNr { get; set; }

        [StringLength(50)]
        public string BankKontoNr { get; set; }

        [StringLength(50)]
        public string IBAN { get; set; }

        public int? ZahlungsArtCode { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        [StringLength(200)]
        public string Zahlungsgrund { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Zusatz { get; set; }

        [StringLength(200)]
        public string Strasse { get; set; }

        [StringLength(8)]
        public string PLZ { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

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
        public byte[] FbBuchungTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBarauszahlungAusbezahlt> FbBarauszahlungAusbezahlts { get; set; }

        public virtual FbDauerauftrag FbDauerauftrag { get; set; }

        public virtual FbPeriode FbPeriode { get; set; }

        public virtual FbZahlungsweg FbZahlungsweg { get; set; }

        public virtual XUser XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbDTABuchung> FbDTABuchungs { get; set; }
    }
}
