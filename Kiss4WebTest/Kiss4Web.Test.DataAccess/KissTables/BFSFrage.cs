namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BFSFrage")]
    public partial class BFSFrage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BFSFrage()
        {
            BFSFarbCodes = new HashSet<BFSFarbCode>();
            BFSWerts = new HashSet<BFSWert>();
        }

        public int BFSFrageID { get; set; }

        public int BFSKatalogVersionID { get; set; }

        [Required]
        [StringLength(10)]
        public string Variable { get; set; }

        [Required]
        [StringLength(200)]
        public string Frage { get; set; }

        [StringLength(50)]
        public string BFSLeistungsfilterCodes { get; set; }

        public int BFSPersonCode { get; set; }

        public int PersonIndex { get; set; }

        public int BFSFeldCode { get; set; }

        [StringLength(20)]
        public string BFSFormat { get; set; }

        [StringLength(100)]
        public string FFLOVName { get; set; }

        [StringLength(100)]
        public string BFSLOVName { get; set; }

        public int? BFSValidierungCode { get; set; }

        public int? BFSKategorieCode { get; set; }

        public int HerkunftCode { get; set; }

        public string HerkunftBeschreibung { get; set; }

        public string HerkunftSQL { get; set; }

        [StringLength(100)]
        public string FFTabelle { get; set; }

        [StringLength(100)]
        public string FFFeld { get; set; }

        [StringLength(100)]
        public string FFPKFeld { get; set; }

        public bool Editierbar { get; set; }

        [StringLength(100)]
        public string ExportNode { get; set; }

        [StringLength(100)]
        public string ExportAttribute { get; set; }

        [StringLength(100)]
        public string ExportPredicate { get; set; }

        [StringLength(200)]
        public string HilfeTitel { get; set; }

        public string HilfeText { get; set; }

        public int? Reihenfolge { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BFSFrageTS { get; set; }

        [StringLength(500)]
        public string FilterRegel { get; set; }

        public bool? UpdateOK { get; set; }

        [StringLength(10)]
        public string VariableAntragsteller { get; set; }

        [StringLength(15)]
        public string VariableExpandiert { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BFSFarbCode> BFSFarbCodes { get; set; }

        public virtual BFSKatalogVersion BFSKatalogVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BFSWert> BFSWerts { get; set; }
    }
}
