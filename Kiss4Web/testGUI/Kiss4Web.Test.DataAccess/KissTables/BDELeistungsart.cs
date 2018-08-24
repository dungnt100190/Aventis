namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BDELeistungsart")]
    public partial class BDELeistungsart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BDELeistungsart()
        {
            BDELeistungs = new HashSet<BDELeistung>();
            BDEUserGroup_BDELeistungsart = new HashSet<BDEUserGroup_BDELeistungsart>();
            FsReduktions = new HashSet<FsReduktion>();
        }

        public int BDELeistungsartID { get; set; }

        [Required]
        [StringLength(200)]
        public string Bezeichnung { get; set; }

        public int? BezeichnungTID { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? SortKey { get; set; }

        public int? KlientErfassungCode { get; set; }

        public int? AnzahlCode { get; set; }

        [StringLength(50)]
        public string ArtikelNr { get; set; }

        public int LeistungsartTypCode { get; set; }

        public int? KostenartCode { get; set; }

        [StringLength(20)]
        public string KTRStandard { get; set; }

        [StringLength(20)]
        public string KTRIV { get; set; }

        [StringLength(20)]
        public string KTRAHV { get; set; }

        [StringLength(20)]
        public string KTRNichtberechtigte { get; set; }

        [StringLength(1000)]
        public string Beschreibung { get; set; }

        public int? AuswDienstleistungCode { get; set; }

        public int? AuswFakturaCode { get; set; }

        public int? AuswProduktCode { get; set; }

        public int? AuswPIAuftragCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BDELeistungsartTS { get; set; }

        public int? VerID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDELeistung> BDELeistungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDEUserGroup_BDELeistungsart> BDEUserGroup_BDELeistungsart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FsReduktion> FsReduktions { get; set; }
    }
}
