namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbDauerauftrag")]
    public partial class FbDauerauftrag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FbDauerauftrag()
        {
            FbBuchungs = new HashSet<FbBuchung>();
        }

        public int FbDauerauftragID { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        public int BaPersonID { get; set; }

        public int SollKtoNr { get; set; }

        public int HabenKtoNr { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        public int FbZahlungswegID { get; set; }

        public DateTime DatumVon { get; set; }

        public int PeriodizitaetCode { get; set; }

        public int? WochentagCode { get; set; }

        public int? Monatstag1 { get; set; }

        public int? Monatstag2 { get; set; }

        public bool VorWochenende { get; set; }

        public DateTime? DatumBis { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        [StringLength(50)]
        public string Zahlungsgrund { get; set; }

        public int Status { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbDauerauftragTS { get; set; }

        public int? DauerauftragDokID { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBuchung> FbBuchungs { get; set; }

        public virtual FbZahlungsweg FbZahlungsweg { get; set; }
    }
}
