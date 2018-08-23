namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaGemeinde")]
    public partial class BaGemeinde
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaGemeinde()
        {
            BaPersons = new HashSet<BaPerson>();
            BaPersons1 = new HashSet<BaPerson>();
            BaPersons2 = new HashSet<BaPerson>();
            BaPersons3 = new HashSet<BaPerson>();
            BgFinanzplan_BaPerson = new HashSet<BgFinanzplan_BaPerson>();
            VmMandants = new HashSet<VmMandant>();
        }

        public int BaGemeindeID { get; set; }

        public int? BFSCode { get; set; }

        public int? PLZ { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(150)]
        public string NameLang { get; set; }

        public int? NameTID { get; set; }

        public int? GemeindeEintragArt { get; set; }

        public int? GemeindeStatus { get; set; }

        public int? GemeindeAufnahmeNummer { get; set; }

        public int? GemeindeAufnahmeModus { get; set; }

        public DateTime? GemeindeAufnahmeDatum { get; set; }

        public int? GemeindeAufhebungNummer { get; set; }

        public int? GemeindeAufhebungModus { get; set; }

        public DateTime? GemeindeAufhebungDatum { get; set; }

        public DateTime? GemeindeAenderungDatum { get; set; }

        public int? GemeindeHistorisierungID { get; set; }

        public int? BezirkCode { get; set; }

        [StringLength(100)]
        public string BezirkName { get; set; }

        [StringLength(150)]
        public string BezirkNameLang { get; set; }

        public int? BezirkNameTID { get; set; }

        public int? BezirkEintragArt { get; set; }

        public int? BezirkAufnahmeNummer { get; set; }

        public int? BezirkAufnahmeModus { get; set; }

        public DateTime? BezirkAufnahmeDatum { get; set; }

        public int? BezirkAufhebungNummer { get; set; }

        public int? BezirkAufhebungModus { get; set; }

        public DateTime? BezirkAufhebungDatum { get; set; }

        public DateTime? BezirkAenderungDatum { get; set; }

        public int? KantonID { get; set; }

        [StringLength(2)]
        public string Kanton { get; set; }

        [StringLength(100)]
        public string KantonNameLang { get; set; }

        public bool? BFSDelivered { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaGemeindeTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPersons1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPersons2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPersons3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgFinanzplan_BaPerson> BgFinanzplan_BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmMandant> VmMandants { get; set; }
    }
}
