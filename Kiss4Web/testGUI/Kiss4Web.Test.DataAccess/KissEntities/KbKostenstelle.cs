namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbKostenstelle")]
    public partial class KbKostenstelle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbKostenstelle()
        {
            BgFinanzplan_BaPerson = new HashSet<BgFinanzplan_BaPerson>();
            BgFinanzplan_BaPerson1 = new HashSet<BgFinanzplan_BaPerson>();
            KbBuchungKostenarts = new HashSet<KbBuchungKostenart>();
            KbKostenstelle_BaPerson = new HashSet<KbKostenstelle_BaPerson>();
            KbWVEinzelpostens = new HashSet<KbWVEinzelposten>();
        }

        public int KbKostenstelleID { get; set; }

        [StringLength(200)]
        public string Nr { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? Vorsaldo { get; set; }

        public bool Aktiv { get; set; }

        public int? ModulID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbKostenstelleTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgFinanzplan_BaPerson> BgFinanzplan_BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgFinanzplan_BaPerson> BgFinanzplan_BaPerson1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchungKostenart> KbBuchungKostenarts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbKostenstelle_BaPerson> KbKostenstelle_BaPerson { get; set; }

        public virtual XModul XModul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVEinzelposten> KbWVEinzelpostens { get; set; }
    }
}
