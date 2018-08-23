namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgBudget")]
    public partial class BgBudget
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BgBudget()
        {
            BgBewilligungs = new HashSet<BgBewilligung>();
            BgDokuments = new HashSet<BgDokument>();
            BgPositions = new HashSet<BgPosition>();
            KbBuchungs = new HashSet<KbBuchung>();
            ShEinzelzahlungs = new HashSet<ShEinzelzahlung>();
        }

        public int BgBudgetID { get; set; }

        public int BgBewilligungStatusCode { get; set; }

        public int? BgFinanzplanID { get; set; }

        public int? Jahr { get; set; }

        public int? Monat { get; set; }

        public string Bemerkung { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgBudgetTS { get; set; }

        public bool MasterBudget { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgBewilligung> BgBewilligungs { get; set; }

        public virtual BgFinanzplan BgFinanzplan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgDokument> BgDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShEinzelzahlung> ShEinzelzahlungs { get; set; }
    }
}
